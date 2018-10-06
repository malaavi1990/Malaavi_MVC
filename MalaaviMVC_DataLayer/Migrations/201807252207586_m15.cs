namespace MalaaviMVC_DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ImageName", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
