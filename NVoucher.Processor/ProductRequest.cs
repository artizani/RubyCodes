using System;
using System.Collections.Generic;
using System.Linq;
using NVoucher.Data;
using NVoucher.Model;

namespace NVoucher.Service
{
    public class ProductRequest : IProductRequest
    {
        public Order item { get; private set; }

        private OrderResponse Fulfill(Order order)
        {
            //validate user ballance
            if (this.Validate(order))

            //fulfill order
            {
               return this.Retrieve(order);
            }

            //respons object


            return null;
        }


        public OrderResponse Retrieve(Order order)
        {
            var response = new OrderResponse();
            var responseList = new List<IProduct>();
            List<EntityMap> products =
                order.Items.Select(
                    result =>
                        new EntityMap
                        {
                            Table = string.Format("{0}_{1}", result.Value.Vendor, result.Value.Amount),
                            Count = result.Key,
                            product = result.Value
                        }).ToList();

            var Repo = new DataResultRepository();
            var newVouchers = Repo.GetNewVouchers(products) as List<EntityMap>;
           
            foreach (var source in order.Items)
            {
                string table = string.Format("{0}_{1}", source.Value.Vendor, source.Value.Amount);

                foreach (EntityMap items in newVouchers.Where(v => (v.Table == table)))
                {
                    for (int i = 0; i < source.Key; i++)
                    {
                        string secret = items.Result[i];

                        responseList.Add(new Product
                        {
                            Name = source.Value.Name,
                            Amount = source.Value.Amount,
                            Date = DateTime.UtcNow,
                            Secret = secret,
                            Owner = source.Value.Owner,
                            Vendor = source.Value.Vendor

                        });


                    }
                }
            }

            response.Items = responseList;
            return response;
            //tbc
        }

        private bool Validate(Order order)
        {
            return true;
        }
    }
}
