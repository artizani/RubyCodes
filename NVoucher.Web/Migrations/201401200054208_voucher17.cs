namespace NVoucher.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class voucher17 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Balances",
                c => new
                    {
                        BalanceId = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        Value = c.String(),
                        InFlight = c.String(),
                    })
                .PrimaryKey(t => t.BalanceId);
            
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditId = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        OldValue = c.String(),
                        Amount = c.String(),
                        NewValue = c.String(),
                        InFlight = c.String(),
                    })
                .PrimaryKey(t => t.CreditId);
            
            CreateTable(
                "dbo.Debits",
                c => new
                    {
                        DebitId = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        OldValue = c.String(),
                        Amount = c.String(),
                        NewValue = c.String(),
                        InFlight = c.String(),
                    })
                .PrimaryKey(t => t.DebitId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        ProductCode = c.Int(),
                        CostPrice = c.Int(nullable: false),
                        Saleprice = c.Int(nullable: false),
                        DateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.TransactionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
            DropTable("dbo.Debits");
            DropTable("dbo.Credits");
            DropTable("dbo.Balances");
        }
    }
}
