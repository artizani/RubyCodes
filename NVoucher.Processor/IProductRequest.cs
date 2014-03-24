using System.Collections.Generic;
using NVoucher.Model;

namespace NVoucher.Service
{
    public interface IProductRequest
    {
        IUser User { get; }
        IOrder Order { get;  }
    }
}
