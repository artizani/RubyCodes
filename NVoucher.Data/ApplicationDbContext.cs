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
            modelBuilder.Entity<Credit>().HasKey(t => t.Id);
            modelBuilder.Entity<Balance>().HasKey(t => t.Id);
            modelBuilder.Entity<Debit>().HasKey(t => t.Id);
            modelBuilder.Entity<PhoneProduct>().HasKey(t =>t.Id );
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            modelBuilder.Entity<Transaction>().Property(t => t.Username)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }


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

    }

