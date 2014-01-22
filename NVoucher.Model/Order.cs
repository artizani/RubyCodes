using System.Collections.Generic;

namespace NVoucher.Model
{
    public class Order:IOrder
    {
        public int Id { get; set; }
        public decimal Totalvalue { get; set; }
        public IEnumerable<KeyValuePair<int, IProduct>> Items { get; set; }

        
    }
}
