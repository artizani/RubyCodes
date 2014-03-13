using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NVoucher.Model;

namespace NVoucher.Web.Controllers
{
    public class PurchaseController : ApiController
    {

        public HttpResponseMessage Post([FromBody]IList<Product> product)
        {
            var work = product;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
