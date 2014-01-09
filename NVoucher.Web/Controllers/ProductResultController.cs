using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NVoucher.Model;
using NVoucher.Service;

namespace NVoucher.Web.Controllers
{
    public class ProductResultController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<IProduct> Get()
        {
            return Mock().Items;
        }

        private OrderResponse Mock()
        {
            var dataitem = new List<KeyValuePair<int, IProduct>>
            {
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 100
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "GLO",
                    Vendor = Vendor.GLO,
                    Amount = 50
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 1000
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 200
                })
            };

           return new ProductRequest().Retrieve(
                new Order
                {
                    User = null,
                    Items = dataitem
                });
        }
    }
}