namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "ProcessStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Application", "ProcessStatus");
        }
    }
}
