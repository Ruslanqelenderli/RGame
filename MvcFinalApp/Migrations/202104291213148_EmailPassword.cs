namespace MvcFinalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "EmailPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "EmailPassword");
        }
    }
}
