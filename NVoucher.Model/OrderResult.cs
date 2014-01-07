using System.Collections.Generic;

namespace NVoucher.Model
{
    public class OrderResponse 
    {
        //look into making this simpler by abstracting into interface
        public IList<IProduct> Items { get; set; }
        string Message { get; set; }

        ResponseType Response { get; set; }
        
    }
}