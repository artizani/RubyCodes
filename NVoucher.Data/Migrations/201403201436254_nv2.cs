namespace NVoucher.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nv2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Credits", "OldValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Credits", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Credits", "NewValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Credits", "InFlight", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Debits", "OldValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Debits", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Debits", "NewValue", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Debits", "InFlight", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Debits", "InFlight", c => c.String());
            AlterColumn("dbo.Debits", "NewValue", c => c.String());
            AlterColumn("dbo.Debits", "Amount", c => c.String());
            AlterColumn("dbo.Debits", "OldValue", c => c.String());
            AlterColumn("dbo.Credits", "InFlight", c => c.String());
            AlterColumn("dbo.Credits", "NewValue", c => c.String());
            AlterColumn("dbo.Credits", "Amount", c => c.String());
            AlterColumn("dbo.Credits", "OldValue", c => c.String());
        }
    }
}
