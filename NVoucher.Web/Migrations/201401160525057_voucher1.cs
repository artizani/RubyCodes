namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Email" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Email", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Term", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "IsVerified", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "Numbers", c => c.Long());
            DropColumn("dbo.AspNetUsers", "Profile_Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Profile_Email", c => c.String(maxLength: 128));
            DropColumn("dbo.AspNetUsers", "Numbers");
            DropColumn("dbo.AspNetUsers", "IsVerified");
            DropColumn("dbo.AspNetUsers", "Term");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "Email");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.AspNetUsers", "Profile_Email");
            AddForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles", "Email");
        }
    }
}
