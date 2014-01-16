namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Username", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Username" });
            CreateIndex("dbo.Profiles", "Username");
            AddForeignKey("dbo.Profiles", "Username", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Profile_Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Profile_Username", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Profiles", "Username", "dbo.AspNetUsers");
            DropIndex("dbo.Profiles", new[] { "Username" });
            CreateIndex("dbo.AspNetUsers", "Profile_Username");
            AddForeignKey("dbo.AspNetUsers", "Profile_Username", "dbo.Profiles", "Username");
        }
    }
}
