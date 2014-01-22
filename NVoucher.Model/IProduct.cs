using System;

namespace NVoucher.Model
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal Amount { get; set; }
        Category Category { get; set; }
        Vendor Vendor { get; set; }
        string Secret { get; set; }
        
        Byte[] Timestamp { get; set; }
    }

    public interface IOrderedProduct : IProduct
    {
        string Id { get; set; }
    }
}
