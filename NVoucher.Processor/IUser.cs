using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NVoucher.Data;
using NVoucher.Service;

namespace NVoucher.Service
{
        public class User : IUser
        {
            private IUnitOfWork Worker;
            private IFunder _funder;
            public User(string id)
            {
                Id = id;
                _funder= new FundService(id);
             //   HttpContext.Current.Request.LogonUserIdentity
             //   Worker.
             //UserName = ,
             
            }
            public override string ToString()
            {
                return UserName.ToString();
            }

            public string Id { get; set; } 
            public IFunder Funds { get { return _funder; } } 
            

            public string UserName { get; set; }


        }
        public interface IUser
        {
            string UserName { get; }
            string Id { get; } 
            IFunder Funds { get; }
        }
    
}
