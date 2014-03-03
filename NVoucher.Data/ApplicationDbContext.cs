using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NVoucher.Model;

namespace NVoucher.Data
{

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("DefaultConnectionOne")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Profile>().HasKey(t => t.Email);
            //modelBuilder.Entity<Credit>().HasKey(t => t.CreditId);
            //modelBuilder.Entity<Balance>().HasKey(t => t.BalanceId);
            //modelBuilder.Entity<Debit>().HasKey(t => t.DebitId);
            //modelBuilder.Entity<Transaction>().HasKey(t => t.TransactionId);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            //modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<Debit> Debits { get; set; }

        //public DbSet<Credit> Credits { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Balance> Balances { get; set; }
        //public DbSet<AspNetRole> AspNetRoles { get; set; }
        //public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public DbSet<AspNetUser> AspNetUsers { get; set; }
        //public DbSet<Profile> Profiles { get; set; }
        //public DbSet<UserPreference> UserPreferences { get; set; }

       //Change the name of the table to be Users instead of AspNetUsers
        //modelBuilder.Entity<IdentityUser>().ToTable("Users");
        //modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        //modelBuilder.Entity<Profile>().HasKey(t => t.Email);
        //modelBuilder.Entity<Credit>().HasKey(t => t.Id);
        //modelBuilder.Entity<Balance>().HasKey(t => t.Id);
        //modelBuilder.Entity<Debit>().HasKey(t => t.Id);
        //modelBuilder.Entity<PhoneProduct>().HasKey(t =>t.Id );
        //modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

        //modelBuilder.Entity<Transaction>().Property(t => t.Id)
        //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);







        //public DbSet<Profile> Profile { get; set; }
        //public DbSet<Credit> Credit { get; set; }
        //public DbSet<Balance> Balance { get; set; }
        //public DbSet<Debit> Debit { get; set; }
        //public DbSet<Transaction> Transaction { get; set; }
    }
   

}

