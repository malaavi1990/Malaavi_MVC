namespace MalaaviMVC_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductGalleries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Tag = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Products", "ImageName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 350));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Products", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductGalleries", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.ProductGalleries", new[] { "ProductId" });
            AlterColumn("dbo.Products", "Price", c => c.String());
            AlterColumn("dbo.Products", "Text", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Title", c => c.String());
            DropColumn("dbo.Products", "ImageName");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductGalleries");
        }
    }
}
