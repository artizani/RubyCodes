using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NVoucher.Auth.Hmac
{
    public class HmacSigningHandler : HttpClientHandler
    {
        private readonly ISecretRepository _secretRepository;
        private readonly IBuildMessageRepresentation _representationBuilder;
        private readonly ICalculteSignature _signatureCalculator;

        public string Username { get; set; }

        public HmacSigningHandler(ISecretRepository secretRepository,
                              IBuildMessageRepresentation representationBuilder,
                              ICalculteSignature signatureCalculator)
        {
            this._secretRepository = secretRepository;
            this._representationBuilder = representationBuilder;
            this._signatureCalculator = signatureCalculator;
        }

        protected  override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                System.Threading.CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains(Configuration.UsernameHeader))
            {
                request.Headers.Add(Configuration.UsernameHeader, this.Username);
            }
            request.Headers.Date = new DateTimeOffset(DateTime.Now,DateTime.Now-DateTime.UtcNow);
            var representation = this._representationBuilder.BuildRequestRepresentation(request);
            var secret = this._secretRepository.GetSecretForUser(this.Username);
            string signature = this._signatureCalculator.Signature(secret,
                representation);

            var header = new AuthenticationHeaderValue(Configuration.AuthenticationScheme, signature);

            request.Headers.Authorization = header;
            return base.SendAsync(request, cancellationToken);
        }
    }
}