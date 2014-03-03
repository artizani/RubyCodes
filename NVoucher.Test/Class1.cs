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
                    Amount = 100
                }),
                new KeyValuePair<int, IProduct>(1, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 50
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 1000
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 200
                })
            };

            var data = new Order
            {
                
                Items = dataitem
            };
            IUser usr = null;
            var test = new ProductRequest(usr);
            var report = test.Retrieve(data);

            Assert.False(true);
        }

        [Fact]
        public void FirstInts()
        {

            var dataitem = new List<KeyValuePair<int, IProduct>>
            {
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 100
                }),
                new KeyValuePair<int, IProduct>(1, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 50
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 1000
                }),
                new KeyValuePair<int, IProduct>(2, new Product
                {
                    Name = "MTN",
                    Vendor = Vendor.MTN,
                    Amount = 200
                })
            };

            var data = new Order
            {

                Items = dataitem
            };
            IUser usr = null;
            var test = new ProductRequest(usr);
            var report = test.Retrieve(data);

            Assert.False(true);
        }
    }
}

