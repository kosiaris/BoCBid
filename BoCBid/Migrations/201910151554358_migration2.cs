namespace BoCBid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.SetBids", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.SetBids", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.SetBids", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.SetBids", name: "ApplicationUser_Id", newName: "ApplicationUserId");
        }
    }
}
