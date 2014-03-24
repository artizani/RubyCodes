namespace NVoucher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nv1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductValues", "Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductValues", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductValues", "Date", c => c.String());
            AlterColumn("dbo.ProductValues", "Timestamp", c => c.Binary());
        }
    }
}
