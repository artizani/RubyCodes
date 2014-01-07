using System.Collections.Generic;

namespace NVoucher.Model
{
    public class Order:IOrder
    {
        public User User { get; set; }
        public IEnumerable<KeyValuePair<int, IProduct>> Items { get; set; }
    }
}
