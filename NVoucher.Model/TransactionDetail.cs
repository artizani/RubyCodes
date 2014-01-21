using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NVoucher.Model
{
   
     public class TransactionDetail
    {
      
        public string Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balance { get; set; }
        public int OrderId { get; set; }
    }

     
      public class TransactionDetailList
    {
        public IEnumerable<TransactionDetail> Items { get; set; }
    }
}