namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Numbers", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Numbers", c => c.Long());
        }
    }
}
