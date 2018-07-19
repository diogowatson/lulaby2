namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Company", "EquifaxScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Company", "EquifaxScore", c => c.Single(nullable: false));
        }
    }
}
