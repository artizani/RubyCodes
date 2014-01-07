namespace NVoucher.Auth.Hmac
{
    public interface ICalculteSignature
    {
        string Signature(string secret, string value);
    }
}