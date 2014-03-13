namespace NVoucher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nv1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Balances", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Balances", "Value", c => c.String());
        }
    }
}
