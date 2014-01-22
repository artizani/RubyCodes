using System;
using System.Collections.Generic;

namespace NVoucher.Model
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public bool Term { get; set; }
        public bool IsVerified { get; set; }
        public long Numbers { get; set; }
       
    }

    public class Credit
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string OldValue { get; set; }
        public string Amount { get; set; }
        public string NewValue { get; set; }
        public string InFlight { get; set; }
    }

    public class Balance
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Value { get; set; }
        public string InFlight { get; set; }
    }

    public class Debit
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string OldValue { get; set; }
        public string Amount { get; set; }
        public string NewValue { get; set; }
        public string InFlight { get; set; }
    }

    public class Transaction
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public int? ProductCode { get; set; }
        public int CostPrice { get; set; }
        public int Saleprice { get; set; }
        public DateTime? DateTime { get; set; }

    }

    public class PhoneProduct
    {
        public long Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Amount { get; set; }
        Category Category { get; set; }
        Vendor Vendor { get; set; }
        string Secret { get; set; }
        Byte[] Timestamp { get; set; }
    }
}