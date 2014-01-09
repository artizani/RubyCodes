using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NVoucher.Model
{
    [DataContract]
     public class TransactionDetail
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }
        [DataMember(Name = "withdrawn")]
        public decimal Debit { get; set; }
        [DataMember(Name = "credit")]
        public decimal Credit { get; set; }
        [DataMember(Name = "balance")]
        public decimal Balance { get; set; }
        [DataMember(Name = "transaction")]
        public int OrderId { get; set; }
    }

     [DataContract]
    public class TransactionDetailList
    {
         [DataMember( Name = "items")]
        public IList<TransactionDetail> Items { get; set; }
    }
}