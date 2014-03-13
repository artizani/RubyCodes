using System.Collections.Generic;

namespace NVoucher.Model
{
    public interface IOrder
    {
        
        IEnumerable<KeyValuePair<int, IProduct>> Items { get; set; }
        IDictionary<IProduct, int> Item { get; set; }

    }
}