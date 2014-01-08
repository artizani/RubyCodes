using System;

namespace NVoucher.Model
{
    public interface IProduct
    {
        string Name { get; set; }
        int Amount { get; set; }
        Category Owner { get; set; }
        Vendor Vendor { get; set; }
        string Secret { get; set; }
        DateTime Date { get; set; }
    }

    public interface IOrderedProduct : IProduct
    {
        string Id { get; set; }
    }
}
