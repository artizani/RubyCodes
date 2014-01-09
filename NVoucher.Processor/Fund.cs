using System.Collections.Generic;
using NVoucher.Data;
using NVoucher.Model;

namespace NVoucher.Service
{
    public class Funder : IFunder
    {
        private decimal Balance { get; set; }
        public decimal GetBalance()
        {
            return new decimal(1000.00);
        }

        public void Update(decimal amount)
        {
            this.Balance += amount;
        }

        public IEnumerable<TransactionDetail> Statment()
        {
            var repo = new DataResultRepository();
            return repo.GetFundHistory();
        }
    }
}