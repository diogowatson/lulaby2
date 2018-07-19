namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Application", "Aproved", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Application", "Aproved", c => c.Boolean(nullable: false));
        }
    }
}
