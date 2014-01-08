using System;
using System.Runtime.Serialization;

namespace NVoucher.Model
{
    [DataContract]
    public class Product:IProduct
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public Category Owner { get; set; }
        [DataMember]
        public Vendor Vendor { get; set; }
        [DataMember]
        public string Secret { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

      
       
    }
}
