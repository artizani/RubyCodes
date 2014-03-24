using System;


namespace NVoucher.Model
{

    public class Product : IProduct
    {

        public string Name { get; set; }
        public string Code { get; set; }

        public Category Category { get; set; }

        public decimal Price { get; set; }
        
        public Vendor Vendor { get; set; }
        public int Quantity { get; set; }
        public string Secret { get; set; }
        public DateTime Date { get; set; }

      
       
    }

    public class ProductValue : Product
    {


        public string ProductValueId { get; set; }
        public string ApplicationUserId { get; set; }
        
        public bool Valid { get; set; }
        public DateTime FirstTimestamp { get; set; }
        public DateTime LastTimestamp { get; set; }

    }


}
