namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Username", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "Username" });
            AddColumn("dbo.Profiles", "Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Double());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Country", c => c.String());
            AddColumn("dbo.AspNetUsers", "Term", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "IsVerified", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "Numbers", c => c.Int());
            AlterColumn("dbo.Profiles", "Term", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Profiles", "IsVerified", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Profiles", "Numbers", c => c.Long(nullable: false));
            DropPrimaryKey("dbo.Profiles");
            AddPrimaryKey("dbo.Profiles", "Email");
            DropColumn("dbo.Profiles", "Username");
            DropColumn("dbo.Profiles", "Balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Balance", c => c.Double(nullable: false));
            AddColumn("dbo.Profiles", "Username", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Profiles");
            AddPrimaryKey("dbo.Profiles", "Username");
            AlterColumn("dbo.Profiles", "Numbers", c => c.Long());
            AlterColumn("dbo.Profiles", "IsVerified", c => c.Boolean());
            AlterColumn("dbo.Profiles", "Term", c => c.Boolean());
            DropColumn("dbo.AspNetUsers", "Numbers");
            DropColumn("dbo.AspNetUsers", "IsVerified");
            DropColumn("dbo.AspNetUsers", "Term");
            DropColumn("dbo.AspNetUsers", "Country");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "Balance");
            DropColumn("dbo.Profiles", "Email");
            CreateIndex("dbo.Profiles", "Username");
            AddForeignKey("dbo.Profiles", "Username", "dbo.AspNetUsers", "Id");
        }
    }
}
