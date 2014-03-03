using System.Collections.Generic;
using NVoucher.Model;

namespace NVoucher.Service
{
   public interface IFunder
   {
       decimal Balance { get; }
       bool Credit(decimal value);

       int Debit(decimal value);
       bool IsAffordable(decimal value);
       IEnumerable<TransactionDetail> Statment();
   }
}
