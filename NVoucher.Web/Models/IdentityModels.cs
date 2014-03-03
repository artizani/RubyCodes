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
            //modelBuilder.Entity<Profile>().HasKey(t => t.Email);
            //modelBuilder.Entity<Credit>().HasKey(t => t.Id);
            //modelBuilder.Entity<Balance>().HasKey(t => t.Id);
            //modelBuilder.Entity<Debit>().HasKey(t => t.Id);
            //modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            //modelBuilder.Entity<Transaction>().Property(t => t.Username)
            //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            //modelBuilder.Entity<Profile>().HasKey(t => t.Email);
            //modelBuilder.Entity<Credit>().HasKey(t => t.CreditId);
            //modelBuilder.Entity<Balance>().HasKey(t => t.BalanceId);
            //modelBuilder.Entity<Debit>().HasKey(t => t.DebitId);
            //modelBuilder.Entity<Transaction>().HasKey(t => t.TranxId);
            //modelBuilder.Entity<UserPreference>().HasKey(t => t.UserId);
            //modelBuilder.Entity<AspNetUserLogin>().HasKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }


        //public DbSet<Profile> Profile { get; set; }
        //public DbSet<Credit> Credit { get; set; }
        //public DbSet<Balance> Balance { get; set; }
        //public DbSet<Debit> Debit { get; set; }
        //public DbSet<Transaction> Transaction { get; set; }


        public DbSet<Debit> Debits { get; set; }

        public DbSet<Credit> Credits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
        //public DbSet<AspNetRole> AspNetRoles { get; set; }
        //public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public DbSet<AspNetUser> AspNetUsers { get; set; }
        //public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
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





    //public class MyDbContext : IdentityDbContext<ApplicationUser>
    //{a
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