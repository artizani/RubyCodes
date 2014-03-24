using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using NVoucher.Data;
using NVoucher.Model;
using NVoucher.Service;

namespace NVoucher.Web.Controllers
{
    public class PurchaseController : ApiController
    {

        public HttpResponseMessage Post([FromBody]IEnumerable<Product> product)
        {
            var work = new UnitOfWork();
            var mapper = new MapOrder();
            var order = mapper.FromProduct(product);
            var user = new User(work, this.User.Identity.GetUserId());
            var productRequest = new ProductRequest(user) {Order = order};
            var purchase = new PurchaseService(productRequest);
            var response = purchase.Deliver();
            return Request.CreateResponse(HttpStatusCode.OK, response);



        }
    }
}
