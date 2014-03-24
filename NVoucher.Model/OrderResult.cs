using System.Collections.Generic;

namespace NVoucher.Model
{
    public class OrderResponse 
    {
        //look into making this simpler by abstracting into interface
        public IEnumerable<IProduct> Items { get; set; }
        public string Message { get; set; }

        public PurchaseResponse Response { get; set; }
        
    }
}