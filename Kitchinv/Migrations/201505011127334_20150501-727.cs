namespace Kitchinv.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20150501727 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        owner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.owner_Id)
                .Index(t => t.owner_Id);
            
            CreateTable(
                "dbo.InventoryItems",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        qty = c.Double(nullable: false),
                        expiration = c.DateTime(nullable: false),
                        added = c.DateTime(nullable: false),
                        notes = c.String(),
                        product_id = c.Guid(),
                        uom_id = c.Guid(),
                        Inventory_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.product_id)
                .ForeignKey("dbo.Uoms", t => t.uom_id)
                .ForeignKey("dbo.Inventories", t => t.Inventory_id)
                .Index(t => t.product_id)
                .Index(t => t.uom_id)
                .Index(t => t.Inventory_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        upc = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Uoms",
                c => new
                    {
                        id = c.Guid(nullable: false),
                        name = c.String(),
                        parent_conversion = c.Double(nullable: false),
                        parent_id = c.Guid(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Uoms", t => t.parent_id)
                .Index(t => t.parent_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "owner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.InventoryItems", "Inventory_id", "dbo.Inventories");
            DropForeignKey("dbo.InventoryItems", "uom_id", "dbo.Uoms");
            DropForeignKey("dbo.Uoms", "parent_id", "dbo.Uoms");
            DropForeignKey("dbo.InventoryItems", "product_id", "dbo.Products");
            DropIndex("dbo.Uoms", new[] { "parent_id" });
            DropIndex("dbo.InventoryItems", new[] { "Inventory_id" });
            DropIndex("dbo.InventoryItems", new[] { "uom_id" });
            DropIndex("dbo.InventoryItems", new[] { "product_id" });
            DropIndex("dbo.Inventories", new[] { "owner_Id" });
            DropTable("dbo.Uoms");
            DropTable("dbo.Products");
            DropTable("dbo.InventoryItems");
            DropTable("dbo.Inventories");
        }
    }
}
