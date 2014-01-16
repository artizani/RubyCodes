namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Balance", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Balance", c => c.Double());
        }
    }
}
