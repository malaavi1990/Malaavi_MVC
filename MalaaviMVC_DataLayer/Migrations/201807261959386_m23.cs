namespace MalaaviMVC_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m23 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductGalleries", "ImageName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductGalleries", "ImageName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
