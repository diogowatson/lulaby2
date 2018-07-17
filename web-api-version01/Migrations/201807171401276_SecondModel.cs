namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "EquifaxScore", c => c.Single(nullable: false));
            AddColumn("dbo.Company", "DbnScore", c => c.Single(nullable: false));
            AddColumn("dbo.DnbData", "Company_ID", c => c.Int());
            AddColumn("dbo.EquifaxData", "Company_ID", c => c.Int());
            CreateIndex("dbo.DnbData", "Company_ID");
            CreateIndex("dbo.EquifaxData", "Company_ID");
            AddForeignKey("dbo.DnbData", "Company_ID", "dbo.Company", "ID");
            AddForeignKey("dbo.EquifaxData", "Company_ID", "dbo.Company", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquifaxData", "Company_ID", "dbo.Company");
            DropForeignKey("dbo.DnbData", "Company_ID", "dbo.Company");
            DropIndex("dbo.EquifaxData", new[] { "Company_ID" });
            DropIndex("dbo.DnbData", new[] { "Company_ID" });
            DropColumn("dbo.EquifaxData", "Company_ID");
            DropColumn("dbo.DnbData", "Company_ID");
            DropColumn("dbo.Company", "DbnScore");
            DropColumn("dbo.Company", "EquifaxScore");
        }
    }
}
