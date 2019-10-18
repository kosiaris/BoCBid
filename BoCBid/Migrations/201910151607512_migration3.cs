namespace BoCBid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "StatusId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Cif", c => c.String());
            CreateIndex("dbo.Products", "StatusId");
            AddForeignKey("dbo.Products", "StatusId", "dbo.Status", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Status", c => c.String());
            DropForeignKey("dbo.Products", "StatusId", "dbo.Status");
            DropIndex("dbo.Products", new[] { "StatusId" });
            DropColumn("dbo.AspNetUsers", "Cif");
            DropColumn("dbo.Products", "StatusId");
            DropTable("dbo.Status");
        }
    }
}
