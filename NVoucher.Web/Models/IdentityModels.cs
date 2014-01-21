using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NVoucher.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace NVoucher.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<Profile>().HasKey(t => t.Email);
            modelBuilder.Entity<Credit>().HasKey(t => t.CreditId);
            modelBuilder.Entity<Balance>().HasKey(t => t.BalanceId);
            modelBuilder.Entity<Debit>().HasKey(t => t.DebitId);
            modelBuilder.Entity<Transaction>().HasKey(t => t.TransactionId);

            modelBuilder.Entity<Transaction>().Property(t => t.Username)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Balance> Balance { get; set; }
        public DbSet<Debit> Debit { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        // HomeTown will be stored in the same table as Users
        public decimal? Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public bool? Term { get; set; }
        public bool? IsVerified { get; set; }
        public int? Numbers { get; set; }

    }
    public class ToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    public class Credit
    {
        public long CreditId { get; set; }
        public string Username { get; set; }
        public string OldValue { get; set; }
        public string Amount { get; set; }
        public string NewValue { get; set; }
        public string InFlight { get; set; }
    }

      public class Balance
    {
        public long BalanceId { get; set; }
        public string Username { get; set; }
        public string Value { get; set; }
        public string InFlight { get; set; }
    }

     public class Debit
    {
        public long DebitId { get; set; }
         public string Username { get; set; }
        public string OldValue { get; set; }
        public string Amount { get; set; }
        public string NewValue { get; set; }
        public string InFlight { get; set; }
    }

     public class Transaction
    {
        public long TransactionId { get; set; }
        public string Username { get; set; }
        public int? ProductCode { get; set; }
        public int CostPrice { get; set; }
        public int Saleprice { get; set; }
        public DateTime? DateTime { get; set; }

    }

    
    //public class MyDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    //public MyDbContext()
    //    //    : base("DefaultConnection")
    //    //{
    //    //}

    //    //protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    //{
    //    //    base.OnModelCreating(modelBuilder);

    //    //    // Change the name of the table to be Users instead of AspNetUsers
    //    //    modelBuilder.Entity<IdentityUser>()
    //    //        .ToTable("Users");
    //    //    modelBuilder.Entity<ApplicationUser>()
    //    //        .ToTable("Users");
    //    //}

    //    //public DbSet<ToDo> ToDoes { get; set; }

    //    //public DbSet<MyUserInfo> MyUserInfo { get; set; }
    //}

}