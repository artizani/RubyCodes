using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NVoucher.Model
{

    public class UserPreference
    {
        
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int Id { get; set; }
        public virtual ApplicationUser  ApplicationUser  { get; set; }
    }

    public  class Transaction
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public long DebitOrderId { get; set; }
        public string ProductCode { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public System.DateTime DateTime { get; set; }
        public virtual ApplicationUser  ApplicationUser { get; set; }
        public virtual Debit Debit { get; set; }
    }



    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public bool Term { get; set; }
        public long Numbers { get; set; }
        public bool IsVerified { get; set; }
        public string Email { get; set; }
        public System.DateTime DateTime { get; set; }

        public virtual ApplicationUser  ApplicationUser  { get; set; }
    }

    public partial class Debit
    {
        public Debit()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        public long DebitId { get; set; }
        public string ApplicationUserId { get; set; }
        public decimal OldValue { get; set; }
        public decimal Amount { get; set; }
        public decimal NewValue { get; set; }
        public bool InFlight { get; set; }
        public System.DateTime DateTime { get; set; }

        public virtual ApplicationUser  ApplicationUser  { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }


    public class Credit
    {
        public long CreditId { get; set; }
        public string ApplicationUserId { get; set; }
        public decimal OldValue { get; set; }
        public decimal Amount { get; set; }
        public decimal NewValue { get; set; }
        public bool InFlight { get; set; }
        public System.DateTime DateTime { get; set; }

        public virtual ApplicationUser  ApplicationUser  { get; set; }
    }

    public class Balance
    {
        public Balance()
        {
            InFlight = false;
        }
        public long BalanceId { get; set; }
        public decimal Value { get; set; }
        public bool InFlight { get; set; }

        //[ForeignKey("ApplicationUserId")]
        public string ApplicationUserId { get; set; }
        public System.DateTime DateTime { get; set; }

        public override string ToString()
        {
            return Value + " "+ ApplicationUserId ;
        }
    }

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser ()
        {
       
            this.ToDoes = new HashSet<UserPreference>();
            this.Transactions = new HashSet<Transaction>();
            this.Credits = new HashSet<Credit>();
            this.Debits = new HashSet<Debit>();
        }

   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public bool? Term { get; set; }
        public bool? IsVerified { get; set; }
        public int? Numbers { get; set; }



        public virtual ICollection<UserPreference> ToDoes { get; set; }
        public virtual Balance UserBalance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Credit> Credits { get; set; }
        public virtual ICollection<Debit> Debits { get; set; }
        //public virtual Profile Profile { get; set; }
    }

   


    
    //public class Profile
    //{
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string Country { get; set; }
    //    public bool Term { get; set; }
    //    public bool IsVerified { get; set; }
    //    public long Numbers { get; set; }
       
    //}

    //public class Credit
    //{
    //    public long Id { get; set; }
    //    public string OrderId { get; set; }
    //    public string OldValue { get; set; }
    //    public string Amount { get; set; }
    //    public string NewValue { get; set; }
    //    public string InFlight { get; set; }
    //}

    //public class Balance
    //{
    //    public long Id { get; set; }
    //    public string OrderId { get; set; }
    //    public string Value { get; set; }
    //    public string InFlight { get; set; }
    //}

    //public class Debit
    //{
    //    public long Id { get; set; }
    //    public string OrderId { get; set; }
    //    public string OldValue { get; set; }
    //    public string Amount { get; set; }
    //    public string NewValue { get; set; }
    //    public string InFlight { get; set; }
    //}

    //public class Transaction
    //{
    //    public long Id { get; set; }
    //    public string UserId { get; set; }
    //    public string OrderId { get; set; }
    //    public int? ProductCode { get; set; }
    //    public int CostPrice { get; set; }
    //    public int Saleprice { get; set; }
    //    public DateTime? DateTime { get; set; }

    //}

    //public class PhoneProduct
    //{
    //    public long Id { get; set; }
    //    string Name { get; set; }
    //    string Description { get; set; }
    //    decimal Amount { get; set; }
    //    Category Category { get; set; }
    //    Vendor Vendor { get; set; }
    //    string Secret { get; set; }
    //    Byte[] Timestamp { get; set; }
    //}
}