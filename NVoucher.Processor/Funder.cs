using System.Collections.Generic;
using NVoucher.Data;
using NVoucher.Model;

namespace NVoucher.Service
{
    public class FundService: IFunder
    {
       
        public FundService(IUser user)
        {
            _user = user;
            this.Refresh();
        }
        public decimal Balance()
        {
            return _user.Balance;
        }
        public void Credit(decimal value)
        {
         
            this.Refresh();
            var newBalance =_user.Balance + value;
            if(!UpdateCredit(newBalance));
            //log failure

        }
        public int Debit(decimal value)
        {
            this.Refresh();
            var newBalance = _user.Balance - value;
            if (!UpdateDebit(newBalance)) ;
            //log failure
            return 1;
        }
        public bool IsAffordable(decimal value)
        {
            this.Refresh();
            return _user.Balance > value;

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
            // ToDo: db call using _user.UserName to get up to date Balance
        }
        private bool UpdateDebit(decimal newBalance)
        {
            // ToDo: db call using _user.UserName to get up to date Balance
            return false;
        }
        private bool UpdateCredit(decimal newBalance)
        {
            // ToDo: db call using _user.UserName to get up to date Balance
            return false;
        }
        #endregion
    }

 
}