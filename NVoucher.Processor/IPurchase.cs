using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVoucher.Model;

namespace NVoucher.Service
{
    internal interface IPurchaseService
    {
        bool IsAuthorized(IProductRequest request);

        OrderResponse Deliver();

    }

    internal class PurchaseService : IPurchaseService
    {
        public PurchaseService(IFunder funder)
        {
            
        }

        public bool IsAuthorized(IProductRequest request)
        {
            throw new NotImplementedException();
        }

        public OrderResponse Deliver()
        {
            throw new NotImplementedException();
        }
    }

    
    

}
