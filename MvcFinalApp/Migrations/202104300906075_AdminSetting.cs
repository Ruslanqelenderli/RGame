namespace MvcFinalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminSetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiteIcon = c.String(),
                        Footer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
