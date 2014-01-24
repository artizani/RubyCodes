using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NVoucher.Model;

namespace NVoucher.Service
{
   public interface IFunder
   {
       decimal Balance();
       bool Credit(decimal value);

       int Debit(decimal value);
       bool IsAffordable(decimal value);
       IEnumerable<TransactionDetail> Statment();
   }
}
