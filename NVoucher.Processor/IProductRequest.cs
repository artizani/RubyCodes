using System.Collections.Generic;
using NVoucher.Model;

namespace NVoucher.Service
{
    interface IProductRequest
    {
        IUser User { get; }
        Order Item { get;  }
    }
}
