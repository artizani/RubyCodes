using System.Collections.Generic;
using NVoucher.Data;
using NVoucher.Model;

namespace NVoucher.Service
{
    public class Funder : IFunder
    {
        private IUser _user;
        public Funder(IUser user)
        {
            _user = user;
            this.Refresh();
        }
        public decimal Balance()
        {
            return _user.Balance;
        }

        public decimal Credit()
        {
            throw new System.NotImplementedException();
        }

        public decimal Debit()
        {
            throw new System.NotImplementedException();
        }

        private void Update(decimal amount)
        {
          //  this.Balance += amount;
        }

        public IEnumerable<TransactionDetail> Statment()
        {
            var repo = new DataResultRepository();
            return repo.GetFundHistory();
        }

        private void Refresh()
        {
            // ToDo: db call using _user.UserName to get up to date Balance
        }

        private void RecordCredit()
        {
            // ToDo: db call using _user.UserName to get up to date Balance
        }
    }
}