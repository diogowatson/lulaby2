namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationReceived", "Company_ID", "dbo.Company");
            DropIndex("dbo.ApplicationReceived", new[] { "Company_ID" });
            AddColumn("dbo.ApplicationReceived", "Company", c => c.String());
            DropColumn("dbo.ApplicationReceived", "Company_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationReceived", "Company_ID", c => c.Int());
            DropColumn("dbo.ApplicationReceived", "Company");
            CreateIndex("dbo.ApplicationReceived", "Company_ID");
            AddForeignKey("dbo.ApplicationReceived", "Company_ID", "dbo.Company", "ID");
        }
    }
}
