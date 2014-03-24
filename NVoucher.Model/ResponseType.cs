namespace NVoucher.Model
{
    public enum PurchaseResponse
    {
        Success,
        Failure,
        Error
    }

    public enum DebitResponse
    {
        Insufficient,
        Empty,
        OK,
        Error

    }

    public enum CreditResponse
    {
        Insufficient,
        Empty,
        OK,
        Error

    }
}