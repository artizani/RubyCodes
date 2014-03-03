using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using NVoucher.Model;
using NVoucher.Service;

namespace NVoucher.Web.Controllers
{
    [Authorize]
    public class ProductResultController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<IProduct> Get()
        {
            var id = this.User.Identity.GetUserId();
            var x = HttpContext.Current.User.Identity;
            var user = new User(id);
            Console.WriteLine(id);
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
            Service.IUser usr = null;
           return new ProductRequest(usr).Retrieve(
                new Order
                {
                   // User = null,
                    Items = dataitem
                });
        }
    }
}