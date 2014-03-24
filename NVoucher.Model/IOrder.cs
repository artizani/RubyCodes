using System;
using System.Collections.Generic;

namespace NVoucher.Model
{
    public interface IOrder
    {

        string Id { get; set; }
        decimal Totalvalue { get; set; }
        int TotalItems { get; set; }
        IDictionary<IProduct, int> Item { get; set; }

    }
}