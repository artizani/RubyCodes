using System;
using System.Runtime.Serialization;

namespace NVoucher.Model
{
    [DataContract]
    public class Product:IProduct
    {
        [DataMember(Name="name")]
        public string Name { get; set; }
        [DataMember(Name = "amount")]
        public int Amount { get; set; }
        [DataMember]
        public Category Owner { get; set; }
        [DataMember]
        public Vendor Vendor { get; set; }
        [DataMember(Name = "secret")]
        public string Secret { get; set; }
        [DataMember (Name="date")]
        public string Date { get; set; }

      
       
    }
}
