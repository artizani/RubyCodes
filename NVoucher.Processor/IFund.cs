using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using NVoucher.Model;

namespace NVoucher.Service
{
   public interface IFunder
   {
       decimal GetBalance();
       void Update(decimal amount);
       IEnumerable<TransactionDetail> Statment();
   }
}
