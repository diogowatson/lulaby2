namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "Industry", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "Industry");
        }
    }
}
