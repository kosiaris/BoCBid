namespace BoCBid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SetBids", "MakeAnOffer", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SetBids", "MakeAnOffer");
        }
    }
}
