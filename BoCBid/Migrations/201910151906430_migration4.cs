namespace BoCBid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SetBits", newName: "SetBids");
            AddColumn("dbo.SetBids", "Account", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SetBids", "Account");
            RenameTable(name: "dbo.SetBids", newName: "SetBits");
        }
    }
}
