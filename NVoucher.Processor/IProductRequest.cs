﻿using System.Collections.Generic;
using NVoucher.Model;

namespace NVoucher.Service
{
    interface IProductRequest
    {
        Order Item { get;  }
    }
}
