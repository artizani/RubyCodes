using System;


namespace NVoucher.Model
{

    public class Product:IProduct
    {

        public string Name { get; set; }
  
        public int Amount { get; set; }
       
        public Category Owner { get; set; }
        
        public Vendor Vendor { get; set; }
       
        public string Secret { get; set; }
      
        public string Date { get; set; }

      
       
    }
}
