using System.Collections.Generic;
using NVoucher.Model;

namespace NVoucher.Service
{
   public interface IFunder
   {
       decimal Balance { get; }
       CreditResponse Credit(decimal value);

       DebitResponse Debit(decimal value);
       bool IsAffordable(decimal value);

       IEnumerable<IProduct> FulfillOrder(IOrder order);
       IEnumerable<TransactionDetail> Statment();
   }
}
