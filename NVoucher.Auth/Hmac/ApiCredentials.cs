using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace NVoucher.Auth.Hmac
{
    public class ApiCredentials
    {
        public string Username { get; set; }
        public string Signature { get; set; }

        public static ApiCredentials GetFromRequestHeaders(HttpRequestHeaders requestHeaders)
        {
            //this could/should be another interface for testing purposes
            var authenticationHeader = requestHeaders.Authorization;
            if (authenticationHeader.Scheme != Configuration.AuthenticationScheme)
            {
                return null;
            }
            if (!requestHeaders.Contains(Configuration.UsernameHeader))
            {
                return null;
            }

            var username = requestHeaders.GetValues(Configuration.UsernameHeader).FirstOrDefault();
            if (username == null)
            {
                return null;
            }

            var decodedBytes = Convert.FromBase64String(authenticationHeader.Parameter);
            var signature = Encoding.UTF8.GetString(decodedBytes);
            return new ApiCredentials()
            {
                Signature = signature,
                Username = username
            };
        }

        public AuthenticationHeaderValue ToAuthenticationHeader()
        {
            var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(this.Signature));
            return new AuthenticationHeaderValue(Configuration.AuthenticationScheme, encoded);
        }
    }
}