using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NVoucher.Model;

namespace NVoucher.Service
{
   public interface IFunder
   {
       decimal Balance();
       decimal Credit();

       decimal Debit();
       IEnumerable<TransactionDetail> Statment();
   }
}
