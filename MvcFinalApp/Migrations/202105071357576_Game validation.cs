namespace MvcFinalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gamevalidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "DownloadLink", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Language", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "Processor", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "GraphicsCard", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "DiskSpace", c => c.String(nullable: false));
            AlterColumn("dbo.Games", "GamePhoto", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "GamePhoto", c => c.String());
            AlterColumn("dbo.Games", "DiskSpace", c => c.String());
            AlterColumn("dbo.Games", "GraphicsCard", c => c.String());
            AlterColumn("dbo.Games", "Processor", c => c.String());
            AlterColumn("dbo.Games", "Language", c => c.String());
            AlterColumn("dbo.Games", "DownloadLink", c => c.String());
            AlterColumn("dbo.Games", "Description", c => c.String());
        }
    }
}
