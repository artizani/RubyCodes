using System;


namespace NVoucher.Model
{

    public class Product:IProduct
    {

        public string Name { get; set; }
        decimal IProduct.Amount
        {
            get { return Amount; }
            set { Amount = value; }
        }

        public Category Category { get; set; }

        public decimal Amount { get; set; }
       

        
        public Vendor Vendor { get; set; }
       
        public string Secret { get; set; }
        public byte[] Timestamp { get; set; }

        public string Date { get; set; }

      
       
    }
}
