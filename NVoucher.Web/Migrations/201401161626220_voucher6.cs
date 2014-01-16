namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Term", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
        }
    }
}
