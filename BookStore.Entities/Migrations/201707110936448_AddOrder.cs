namespace BookStore.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Order_Id", c => c.Int());
            CreateIndex("dbo.Books", "Order_Id");
            AddForeignKey("dbo.Books", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Books", new[] { "Order_Id" });
            DropColumn("dbo.Books", "Order_Id");
            DropTable("dbo.Orders");
        }
    }
}
