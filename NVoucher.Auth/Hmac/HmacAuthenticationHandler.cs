using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace NVoucher.Auth.Hmac
{
    public class HmacAuthenticationHandler : DelegatingHandler
    {
        private const string UnauthorizedMessage = "Unauthorized request";

        private readonly ISecretRepository _secretRepository;
        private readonly IBuildMessageRepresentation _representationBuilder;
        private readonly ICalculteSignature _signatureCalculator;

        public HmacAuthenticationHandler(ISecretRepository secretRepository,
            IBuildMessageRepresentation representationBuilder,
            ICalculteSignature signatureCalculator)
        {
            this._secretRepository = secretRepository;
            this._representationBuilder = representationBuilder;
            this._signatureCalculator = signatureCalculator;
        }

        protected async Task<bool> IsAuthenticated(HttpRequestMessage requestMessage)
        {
            if (!requestMessage.Headers.Contains(Configuration.UsernameHeader))
            {
                return false;
            }

            var isDateValid = this.IsDateValid(requestMessage);
            if (!isDateValid)
            {
                return false;
            }

            if (requestMessage.Headers.Authorization == null 
                || requestMessage.Headers.Authorization.Scheme != Configuration.AuthenticationScheme)
            {
                return false;
            }
            string username = requestMessage.Headers.GetValues(Configuration.UsernameHeader).First();
            var secret = this._secretRepository.GetSecretForUser(username);
            if (secret == null)
            {
                return false;
            }

            var representation = this._representationBuilder.BuildRequestRepresentation(requestMessage);
            if (representation == null)
            {
                return false;
            }

            if (requestMessage.Content.Headers.ContentMD5 != null 
                && !await this.IsMd5Valid(requestMessage))
            {
                return false;
            }

            var signature = this._signatureCalculator.Signature(secret, representation);

            if(MemoryCache.Default.Contains(signature))
            {
                return false;
            }

            var result = requestMessage.Headers.Authorization.Parameter == signature;
            if (result == true)
            {
                MemoryCache.Default.Add(signature, username,
                                        DateTimeOffset.UtcNow.AddMinutes(Configuration.ValidityPeriodInMinutes));
            }
            return result;
        }

        private async Task<bool> IsMd5Valid(HttpRequestMessage requestMessage)
        {
            var hashHeader = requestMessage.Content.Headers.ContentMD5;
            if (requestMessage.Content == null)
            {
                return hashHeader == null || hashHeader.Length == 0;
            }
            var hash = await MD5Helper.ComputeHash(requestMessage.Content);
            return hash.SequenceEqual(hashHeader);
        }

        private bool IsDateValid(HttpRequestMessage requestMessage)
        {
            var utcNow = DateTime.UtcNow;
            var date = requestMessage.Headers.Date.Value.UtcDateTime;
            if (date >= utcNow.AddMinutes(Configuration.ValidityPeriodInMinutes)
                || date <= utcNow.AddMinutes(-Configuration.ValidityPeriodInMinutes))
            {
                return false;
            }
            return true;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var isAuthenticated = await this.IsAuthenticated(request);

            if (!isAuthenticated)
            {
               
                
                var response = request.CreateErrorResponse(HttpStatusCode.Unauthorized, UnauthorizedMessage);
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(
                    Configuration.AuthenticationScheme));
                return response;
            }
            return await base.SendAsync(request, cancellationToken);
        }
    }
}