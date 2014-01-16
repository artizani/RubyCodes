namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "Balance", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "Profile_Email", c => c.String(maxLength: 128));
            AlterColumn("dbo.Profiles", "Term", c => c.Boolean());
            AlterColumn("dbo.Profiles", "IsVerified", c => c.Boolean());
            AlterColumn("dbo.Profiles", "Numbers", c => c.Long());
            CreateIndex("dbo.AspNetUsers", "Profile_Email");
            AddForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles", "Email");
            DropColumn("dbo.AspNetUsers", "Balance");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Term");
            DropColumn("dbo.AspNetUsers", "IsVerified");
            DropColumn("dbo.AspNetUsers", "Numbers");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Numbers", c => c.Int());
            AddColumn("dbo.AspNetUsers", "IsVerified", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "Term", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Double());
            DropForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Email" });
            AlterColumn("dbo.Profiles", "Numbers", c => c.Long(nullable: false));
            AlterColumn("dbo.Profiles", "IsVerified", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Profiles", "Term", c => c.Boolean(nullable: false));
            DropColumn("dbo.AspNetUsers", "Profile_Email");
            DropColumn("dbo.Profiles", "Balance");
        }
    }
}
