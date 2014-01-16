namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher14 : DbMigration
    {
        public override void Up()
        {
           
            DropColumn("dbo.AspNetUsers", "Balance");
        }

        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Balance", c => c.Decimal(nullable: false));   
        }
    }
}
