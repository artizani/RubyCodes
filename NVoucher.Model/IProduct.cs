using System;

namespace NVoucher.Model
{
    public interface IProduct
    {
        string Name { get; set; }
        decimal Price { get; set; }
        Category Category { get; set; }
        Vendor Vendor { get; set; }
       
        int Quantity { get; set; }
       
        
     
    }

    public interface IOrderedProduct : IProduct
    {
        string Id { get; set; }
    }
}
