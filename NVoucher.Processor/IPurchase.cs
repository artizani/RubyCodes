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
        private int _debitId;
        private decimal TotalValue { get; set; }
      
        //private decimal Cost()
       
        public PurchaseService(IProductRequest request)
        {
            
            try
            {
                 _funder =_request.User.Funds;
                _request = request;
                this._debitId = 0;
                this.TotalValue = _request.Item.Totalvalue;
            }
            catch (Exception assignmentException)
            {
                //Log exceptions
            }
        }

        public bool Fundable()
        {
            
            if (_funder.IsAffordable(this.TotalValue))
            return true; return false;
            //log exception if false and return insufficient funds message
        }
        private bool Purchase()
        {
            try
            {
               _debitId= _funder.Debit(this.TotalValue);
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
            var order = new Order();
            var result = PopulateResult(order);
            return result;

        }

        private OrderResponse PopulateResult(Order order)
        {
            //ToDo: Retrieve relevant voucher codes in response
             var response = new OrderResponse();
            var responseList = new List<IProduct>();
            List<EntityMap> products =
                order.Items.Select(
                    result =>
                        new EntityMap
                        {
                            Table = string.Format("{0}_{1}", result.Value.Vendor, result.Value.Price),
                            Count = result.Key,
                            product = result.Value
                        }).ToList();

            var Repo = new DataResultRepository();
            var newVouchers = Repo.GetNewVouchers(products) as List<EntityMap>;
           
            foreach (var source in order.Items)
            {
                string table = string.Format("{0}_{1}", source.Value.Vendor, source.Value.Price);

                foreach (EntityMap items in newVouchers.Where(v => (v.Table == table)))
                {
                    for (int i = 0; i < source.Key; i++)
                    {
                        string secret = items.Result[i];

                        responseList.Add(new Product
                        {
                            Name = source.Value.Name,
                            Price = source.Value.Price,
                            Date = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm",
                                CultureInfo.InvariantCulture),
                            Secret = secret,
                            Category = source.Value.Category,
                            Vendor = source.Value.Vendor

                        });


                    }
                }
            }

            response.Items = responseList;
            return response;
            //tbc
        }
            //return new OrderResponse();
        

        private void UpdateTransaction(int orderId)
        {
            _request.Item.Id = orderId;
            //ToDo: use debit Id to write to transaction table
        }
    }

    
    

}
