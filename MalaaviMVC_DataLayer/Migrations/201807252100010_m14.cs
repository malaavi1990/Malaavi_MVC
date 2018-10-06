namespace MalaaviMVC_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropIndex("dbo.Products", new[] { "UserId" });
            DropColumn("dbo.Products", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "UserId");
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
