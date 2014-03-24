using System;
using System.Collections.Generic;
using System.Linq;

namespace NVoucher.Model
{
    public class Order:IOrder
    {
        public string Id { get; set; }
        public decimal Totalvalue { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<KeyValuePair<int, IProduct>> Items { get; set; }
        public IDictionary<IProduct,int> Item {get; set; } 


        
    }

    public class MapOrder
    {
        private IOrder order;

        private string CreateActivityId()
        {
            var guid = Guid.NewGuid();
            var str = guid.ToString("N");
            return str;

        }
        public IOrder FromProduct(IEnumerable<IProduct> productList)
        {
            order = new Order();
            order.Item= new Dictionary<IProduct, int>();
            var items = 0;
            var value = 0.0m;

            productList.ToList().ForEach(product =>
            {
                product.Price = PriceStore.GetPrice(product.Code);
                order.Item.Add(product, product.Quantity);
                value += product.Price * product.Quantity;
                items += product.Quantity;
                
            });

            order.Id = CreateActivityId();
            order.TotalItems = items;
            order.Totalvalue = value;
            return order;
        }



    }

    public static class PriceStore
    {
        public static decimal GetPrice(string productCode)
        {
            return new decimal(100.00);
        }

        public static int ValidateQuantity(int quantity)
        {
            if(quantity <= 0 || quantity >5)
                throw new Exception("exceeded purchase limit");
            return quantity;
        }
    }
}
