using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using Microsoft.Practices.Unity;
using NVoucher.Data;
using NVoucher.Model;
using NVoucher.Service;

namespace NVoucher.Web.Controllers
{
    [Authorize]
    public class ProductResultController : ApiController
    {
        // GET api/<controller>
        //[Dependency("basic")]
        //IUnitOfWork Work { get; set; }
        public IEnumerable<IProduct> Get()
        {
            var work = new UnitOfWork();
            var id = this.User.Identity.GetUserId();
            var x = HttpContext.Current.User.Identity.GetUserId();
            var user = new User(work,id);
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
                    Price = 100
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "GLO",
                    Vendor = Vendor.GLO,
                    Price = 50
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Price = 1000
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Price = 200
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