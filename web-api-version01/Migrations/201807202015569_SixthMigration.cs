namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SixthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Application", "TradeReferenceEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Application", "TradeReferenceEmail");
        }
    }
}
