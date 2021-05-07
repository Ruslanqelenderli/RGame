namespace MvcFinalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RGameDbContext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String());
        }
    }
}
