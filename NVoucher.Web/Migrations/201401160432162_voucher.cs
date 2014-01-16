namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "IsVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Profile_Email", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "Profile_Email");
            AddForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Profile_Email", "dbo.Profiles");
            DropIndex("dbo.AspNetUsers", new[] { "Profile_Email" });
            DropColumn("dbo.AspNetUsers", "Profile_Email");
            DropColumn("dbo.Profiles", "IsVerified");
        }
    }
}
