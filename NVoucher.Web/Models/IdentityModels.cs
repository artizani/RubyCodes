﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NVoucher.Model;

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
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ToDo> ToDoes { get; set; }

        public DbSet<Profile> Profile { get; set; }
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