namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balance",
                c => new
                    {
                        BalanceId = c.Long(nullable: false, identity: true),
                        Value = c.String(),
                        InFlight = c.String(),
                        ApplicationUserId = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceId);
            
            CreateTable(
                "dbo.Credit",
                c => new
                    {
                        CreditId = c.Long(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        OldValue = c.String(),
                        Amount = c.String(),
                        NewValue = c.String(),
                        InFlight = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CreditId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Country = c.String(),
                        Term = c.Boolean(),
                        IsVerified = c.Boolean(),
                        Numbers = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        UserBalance_BalanceId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Balance", t => t.UserBalance_BalanceId)
                .Index(t => t.UserBalance_BalanceId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Debit",
                c => new
                    {
                        DebitId = c.Long(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        OldValue = c.String(),
                        Amount = c.String(),
                        NewValue = c.String(),
                        InFlight = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DebitId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        DebitOrderId = c.Long(nullable: false),
                        ProductCode = c.String(),
                        CostPrice = c.String(),
                        SalePrice = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Debit_DebitId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Debit", t => t.Debit_DebitId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Debit_DebitId);
            
            CreateTable(
                "dbo.UserPreference",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsDone = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Country = c.String(),
                        Term = c.Boolean(nullable: false),
                        Numbers = c.Long(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credit", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UserBalance_BalanceId", "dbo.Balance");
            DropForeignKey("dbo.UserPreference", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transaction", "Debit_DebitId", "dbo.Debit");
            DropForeignKey("dbo.Transaction", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Debit", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Credit", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserBalance_BalanceId" });
            DropIndex("dbo.UserPreference", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Transaction", new[] { "Debit_DebitId" });
            DropIndex("dbo.Transaction", new[] { "ApplicationUserId" });
            DropIndex("dbo.Debit", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.Profile");
            DropTable("dbo.UserPreference");
            DropTable("dbo.Transaction");
            DropTable("dbo.Debit");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Credit");
            DropTable("dbo.Balance");
        }
    }
}
