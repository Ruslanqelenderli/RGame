namespace MvcFinalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        DownloadLink = c.String(),
                        Confirm = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Size = c.Single(nullable: false),
                        Language = c.String(),
                        Processor = c.String(),
                        RamSize = c.Int(nullable: false),
                        GraphicsCard = c.String(),
                        DiskSpace = c.String(),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        GamePhoto = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Role = c.String(),
                        Password = c.String(),
                        Description = c.String(),
                        UserPhoto = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "UserId", "dbo.Users");
            DropForeignKey("dbo.Games", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Games", new[] { "CategoryId" });
            DropIndex("dbo.Games", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Games");
            DropTable("dbo.Categories");
        }
    }
}
