using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NVoucher.Data;
using NVoucher.Model;

namespace NVoucher.Service
{
    internal interface IPurchaseService
    {
        OrderResponse Deliver();

    }

    public class PurchaseService : IPurchaseService
    {
        private readonly IFunder _funder;
        private readonly IProductRequest _request;
        private DebitResponse debitResponse;
       
        private decimal TotalValue { get; set; }
      
        //private decimal Cost()
       
        public PurchaseService(IProductRequest request)
        {
            
            try
            {
                _request = request;
                _funder =_request.User.Funds;
                this.TotalValue = _request.Order.Totalvalue;
            }
            catch (Exception assignmentException)
            {
                //Log exceptions
            }
        }

        private bool Fundable()
        {
            
            if (_funder.IsAffordable(this.TotalValue))
            return true; return false;
            //log exception if false and return insufficient funds message
        }
        private bool Purchase()
        {
            if(!this.Fundable())
                return false;
            try
            {
               debitResponse = _funder.Debit(this.TotalValue);
                return true;
            }
            catch (Exception purchaseException)
            {
                //log ex
                return false;
            }

        }

        public OrderResponse Deliver()
        {
            if (this.Purchase() && debitResponse != DebitResponse.OK)
                return new OrderResponse
                {
                    Message = "Houston we have a problem !!",
                    Response = PurchaseResponse.Error,
                    Items = null
                };



            var result = _funder.FulfillOrder(_request.Order);
            return new OrderResponse {Message = "All Good", Response = PurchaseResponse.Success, Items = result};

        }


    }

    
    

}
