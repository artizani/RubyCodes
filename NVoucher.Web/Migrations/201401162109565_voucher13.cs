namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher13 : DbMigration
    {
    
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Decimal(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Balance");
        }
    }
}
