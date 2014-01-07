using System.Net.Http;

namespace NVoucher.Auth.Hmac
{
    public interface IBuildMessageRepresentation
    {
        string BuildRequestRepresentation(HttpRequestMessage requestMessage);
    }
}