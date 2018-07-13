namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        DateAplied = c.DateTime(nullable: false),
                        DateProcessed = c.DateTime(nullable: false),
                        CreditApplied = c.Int(nullable: false),
                        CreditAproved = c.Int(nullable: false),
                        Recomendation = c.String(),
                        Aproved = c.Boolean(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        ParentCompany = c.String(),
                        CreditIssued = c.Int(nullable: false),
                        Terms = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CreditTransaction",
                c => new
                    {
                        CreditTransactionID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        CreditIssued = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        Paid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CreditTransactionID);
            
            CreateTable(
                "dbo.DnbData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Date = c.DateTime(nullable: false),
                        FailureScore = c.Int(nullable: false),
                        DelinquencyScore = c.Int(nullable: false),
                        Paydex = c.Int(nullable: false),
                        ViabilityRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EquifaxData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Date = c.DateTime(nullable: false),
                        CreditIndex = c.Int(nullable: false),
                        PaymentIndex = c.Int(nullable: false),
                        Cds = c.Int(nullable: false),
                        Bfrs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EquifaxData");
            DropTable("dbo.DnbData");
            DropTable("dbo.CreditTransaction");
            DropTable("dbo.Company");
            DropTable("dbo.Application");
        }
    }
}
