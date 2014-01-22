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
    

        OrderResponse Deliver();

    }

    internal class PurchaseService : IPurchaseService
    {
        private IFunder _funder;
        private IProductRequest _request;
        private int _debitId;
        private decimal _totalValue { get; set; }
      
        //private decimal Cost()
       
        public PurchaseService(IFunder funder,IProductRequest request)
        {
            
            try
            {
                _funder = funder;
                _request = request;
                this._debitId = 0;
                _totalValue = _request.Item.Totalvalue;
            }
            catch (Exception assignmentException)
            {
                //Log exceptions
            }
        }

        public bool Fundable()
        {
            
            if (_funder.IsAffordable(_totalValue))
            return true; return false;
            //log exception if false and return insufficient funds message
        }
        private bool Purchase()
        {
            try
            {
               _debitId= _funder.Debit(_totalValue);
                return true;
            }
            catch (Exception purchaException)
            {
                //log ex
                return false;
            }

        }

        public OrderResponse Deliver()
        {
            if (!this.Purchase() || _debitId == 0)
                return new OrderResponse {Message = "Yawa dey", Response = ResponseType.Error, Items = null};

            UpdateTransaction(_debitId);
            var result = PopulateResult();
            return result;

        }

        private OrderResponse PopulateResult()
        {
            //ToDo: Retrieve relevant voucher codes in response
            return new OrderResponse();
        }

        private void UpdateTransaction(int orderId)
        {
            _request.Item.Id = orderId;
            //ToDo: use debit Id to write to transaction table
        }
    }

    
    

}
