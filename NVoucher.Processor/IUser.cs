using NVoucher.Data;

namespace NVoucher.Service
{
        public class User : IUser
        {
            //private IUnitOfWork _worker;
            private IFunder _funder;
            public User(IUnitOfWork worker,string id)
            {
                Id = id;
                _funder = new FundService(worker,id);
             //   HttpContext.Current.Request.LogonUserIdentity

             
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
