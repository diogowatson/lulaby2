namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "Industry", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Application", "Industry");
        }
    }
}
