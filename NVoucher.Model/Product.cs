using System;


namespace NVoucher.Model
{

    public class Product:IProduct
    {

        public string Name { get; set; }


        public Category Category { get; set; }

        public decimal Price { get; set; }
        
        public Vendor Vendor { get; set; }
        public int Quantity { get; set; }

        public string Secret { get; set; }
        public byte[] Timestamp { get; set; }

        public string Date { get; set; }

      
       
    }
}
