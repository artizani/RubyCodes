namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher5 : DbMigration
    {

        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Term");    
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Term", c => c.Boolean(nullable: false));
        }
    }
}
