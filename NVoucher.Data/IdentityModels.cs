using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using NVoucher.Model;

namespace NVoucher.Data
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

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Change the name of the table to be Users instead of AspNetUsers
            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<Profile>().HasKey(t => t.Email);
            modelBuilder.Entity<Credit>().HasKey(t => t.CreditId);
            modelBuilder.Entity<Balance>().HasKey(t => t.BalanceId);
            modelBuilder.Entity<Debit>().HasKey(t => t.DebitId);
            modelBuilder.Entity<UserPreference>().HasKey(t => t.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            modelBuilder.Entity<Transaction>().Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserPreference>().Property(o => o.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(c => c.UserBalance);
               
              
                
            modelBuilder.Entity<Credit>()
             .HasRequired(c => c.ApplicationUser)
             .WithMany(c => c.Credits);

            modelBuilder.Entity<Debit>()
             .HasRequired(c => c.ApplicationUser)
             .WithMany(c => c.Debits);

            modelBuilder.Entity<Transaction>()
             .HasRequired(c => c.ApplicationUser)
             .WithMany(c => c.Transactions);
     


            base.OnModelCreating(modelBuilder);
        }


        //public DbSet<Profile> Profile { get; set; }
        //public DbSet<Credit> Credit { get; set; }
        //public DbSet<Balance> Balance { get; set; }
        //public DbSet<Debit> Debit { get; set; }
        //public DbSet<Transaction> Transaction { get; set; }


        public DbSet<Model.Debit> Debits { get; set; }

        public DbSet<Credit> Credits { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Balance> Balances { get; set; }
      
       // public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }


    }
    //public partial class ApplicationUser : IdentityUser
    //{
    //    // HomeTown will be stored in the same table as Users
    //    public decimal? Balance { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Country { get; set; }
    //    public bool? Term { get; set; }
    //    public bool? IsVerified { get; set; }
    //    public int? Numbers { get; set; }

    //}





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