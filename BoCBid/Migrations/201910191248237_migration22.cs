namespace BoCBid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration22 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SetBids", "MakeAnOffer", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SetBids", "MakeAnOffer", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
