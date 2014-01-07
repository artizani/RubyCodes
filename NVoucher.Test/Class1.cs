using System.Collections.Generic;
using NVoucher.Service;
using NVoucher.Model;
using Xunit;



namespace NVoucher.Test
{
    public class Classs
    {

        public Classs()
        {
            
        }
        [Fact]
        public void FirstInt()
        {

            var dataitem = new List<KeyValuePair<int, IProduct>>
            {
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Value = 100
                }),
                new KeyValuePair<int, IProduct>(1, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Value = 50
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Value = 1000
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Value = 200
                })
            };

            var data = new Order
            {
                User = null,
                Items = dataitem
            };
            var test = new ProductRequest();
            var report = test.Retrieve(data);

            Assert.False(true);
        }
    }
}

