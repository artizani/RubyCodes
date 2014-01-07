namespace NVoucher.Auth.Hmac
{
    public interface ISecretRepository
    {
        string GetSecretForUser(string username);
    }
}