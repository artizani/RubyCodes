using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using NVoucher.Data;
using NVoucher.Model;


namespace NVoucher.Service
{
    public class FundService: IFunder
    {
        private decimal _balance;
        private string _userId;

        private readonly IUnitOfWork _worker;
        public FundService(IUnitOfWork worker, string userId)
        {
            _worker = worker;
            _userId = userId;
            this.Refresh();
        }

        public decimal Balance
        {
            get
            {
               // this.Refresh();
                return _balance;
            }
       
        }

        public CreditResponse Credit(decimal value)
        {
         
            this.Refresh();
            var newBalance = this.Balance + value;
            if (newBalance < 0)
                return CreditResponse.Error;
            var credit = new Credit
            {
                ApplicationUserId = _userId,
                OldValue = this.Balance,
                Amount = value,
                NewValue = newBalance,
                DateTime = DateTime.UtcNow
            };
            this.UpdateCredit(credit);
            return CreditResponse.OK;
        }
        public DebitResponse Debit(decimal value)
        {
            
            var newBalance = this.Balance - value;
            if (newBalance < 0)
                return DebitResponse.Insufficient;
            var debit = new Debit
            {
                ApplicationUserId = _userId,
                OldValue = this.Balance,
                Amount = value,
                NewValue = newBalance,
                DateTime = DateTime.UtcNow
            };
            UpdateDebit(debit);

            return DebitResponse.OK;
        }
        public bool IsAffordable(decimal value)
        {
            this.Refresh();
            return this.Balance > value;

        }

        public IEnumerable<IProduct> FulfillOrder(IOrder order)
        {
            IList<IProduct> products = new List<IProduct>();

            foreach (var item in order.Item)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    products.Add(item.Key);
                }
            }

            var productValue = this.MapResult(products);
            return productValue;

        }
        private IEnumerable<IProduct> MapResult(IEnumerable<IProduct> flattenedList)
        {
            IList<IProduct> products = new List<IProduct>();
              foreach (var Item in flattenedList)
              {
                 var product = _worker.ProductValueRepository.Get((prod => prod.Code == Item.Code && prod.Valid) ,
                     orderBy: q => q.OrderBy(d => d.FirstTimestamp)).FirstOrDefault();
                  if (product != null)
                  {
                      product.LastTimestamp = DateTime.UtcNow;
                      product.Valid = false;
                      _worker.ProductValueRepository.Update(product);
                      products.Add(product);
                  }

              }
            return products;

        }
        public IEnumerable<TransactionDetail> Statment()
        {
            var repo = new DataResultRepository();
            return repo.GetFundHistory();
        }
        #region privates
        private IUser _user;
        private void Refresh()
        {
            var balance = _worker.BalanceRepository.Get(bal => bal.ApplicationUserId == _userId);
            _balance = Convert.ToDecimal(balance.FirstOrDefault().Value);
            // ToDo: db call using _user.UserName to get up to date Balance
           Console.WriteLine(" refreshing balance");
        }
        private void UpdateDebit(Debit debit)
        {
            // ToDo: db call using _user.UserName to get up to date Balance
            try
            {
                _worker.DebitRepository.Insert(debit);
            }
            catch (DataException data)
            {
                var c = data;
            }

        }
        private void UpdateCredit(Credit credit)
        {
            // ToDo: db call using _user.UserName to get up to date Balance
            _worker.CreditRepository.Insert(credit);
        }
        #endregion
    }

   
 
}