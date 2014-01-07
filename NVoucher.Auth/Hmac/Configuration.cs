namespace NVoucher.Auth.Hmac
{
    public class Configuration
    {
        public const string UsernameHeader = "X-ApiAuth-Username";
        public const string AuthenticationScheme = "ApiAuth";
        public const int ValidityPeriodInMinutes = 5;
    }
}