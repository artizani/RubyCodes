namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Email" });
            RenameColumn(table: "dbo.AspNetUsers", name: "Profile_Email", newName: "Profile_Username");
            AddColumn("dbo.Profiles", "Username", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Profiles");
            AddPrimaryKey("dbo.Profiles", "Username");
            CreateIndex("dbo.AspNetUsers", "Profile_Username");
            AddForeignKey("dbo.AspNetUsers", "Profile_Username", "dbo.Profiles", "Username");
            DropColumn("dbo.Profiles", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Email", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "Profile_Username", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Username" });
            DropPrimaryKey("dbo.Profiles");
            AddPrimaryKey("dbo.Profiles", "Email");
            DropColumn("dbo.Profiles", "Username");
            RenameColumn(table: "dbo.AspNetUsers", name: "Profile_Username", newName: "Profile_Email");
            CreateIndex("dbo.AspNetUsers", "Profile_Email");
            AddForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles", "Email");
        }
    }
}
