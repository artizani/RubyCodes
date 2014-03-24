namespace NVoucher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceId = c.Long(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InFlight = c.Boolean(nullable: false),
                        ApplicationUserId = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BalanceId);
            
            CreateTable(
                "dbo.Credits",
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
                .ForeignKey("dbo.Balances", t => t.UserBalance_BalanceId)
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
                "dbo.Debits",
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
                "dbo.Transactions",
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
                .ForeignKey("dbo.Debits", t => t.Debit_DebitId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Debit_DebitId);
            
            CreateTable(
                "dbo.UserPreferences",
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
                "dbo.Profiles",
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
            
            CreateTable(
                "dbo.ProductValues",
                c => new
                    {
                        ProductValueId = c.String(nullable: false, maxLength: 128),
                        ApplicationUserId = c.String(),
                        Secret = c.String(),
                        Timestamp = c.Binary(),
                        Name = c.String(),
                        Code = c.String(),
                        Category = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vendor = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.ProductValueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Credits", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "UserBalance_BalanceId", "dbo.Balances");
            DropForeignKey("dbo.UserPreferences", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "Debit_DebitId", "dbo.Debits");
            DropForeignKey("dbo.Transactions", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Debits", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Credits", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserBalance_BalanceId" });
            DropIndex("dbo.UserPreferences", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Transactions", new[] { "Debit_DebitId" });
            DropIndex("dbo.Transactions", new[] { "ApplicationUserId" });
            DropIndex("dbo.Debits", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.ProductValues");
            DropTable("dbo.Profiles");
            DropTable("dbo.UserPreferences");
            DropTable("dbo.Transactions");
            DropTable("dbo.Debits");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Credits");
            DropTable("dbo.Balances");
        }
    }
}
