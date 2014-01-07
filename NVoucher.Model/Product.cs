namespace NVoucher.Model
{
    public class Product:IProduct
    {
        public string Name { get; set; }
        public Category Owner { get; set; }
        public Vendor Vendor { get; set; }
        public string Secret { get; set; }
        public int Value { get; set; }
       
    }
}
