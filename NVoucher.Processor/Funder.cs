using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NVoucher.Data;
using NVoucher.Model;

namespace NVoucher.Service
{
    public class FundService: IFunder
    {
        private decimal _balance;
        private string _userId;
        IUnitOfWork Worker { get; set; }
        public FundService(string userId)
        {
            _userId = userId;
            this.Refresh();
        }

        public decimal Balance
        {
            get { return _balance; }
       
        }

        public bool Credit(decimal value)
        {
         
            this.Refresh();
            var newBalance = this.Balance + value;
            if (!UpdateCredit(newBalance))
                return true;
            return false;
            //log failure

        }
        public int Debit(decimal value)
        {
            this.Refresh();
            var newBalance = this.Balance - value;
            if (!UpdateDebit(newBalance)) ;
            //log failure
            return 1;
        }
        public bool IsAffordable(decimal value)
        {
            this.Refresh();
            return this.Balance > value;

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
            var balance = Worker.BalanceRepository.GetByID(_userId);
            _balance =  Convert.ToDecimal(balance.Value);
            // ToDo: db call using _user.UserName to get up to date Balance
           Console.WriteLine(" refreshing balance");
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