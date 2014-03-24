namespace NVoucher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nv3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductValues", "ProductValueId", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductValues", "ProductValueId", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
