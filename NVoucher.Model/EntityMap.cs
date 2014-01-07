using System.Collections.Generic;

namespace NVoucher.Model
{
    public class EntityMap
    {
        public string Table { get; set; }
        public int Count { get; set; }

        public IProduct product { get; set; }
    
        public IList<string> Result { get; set; } 
    }
}