namespace web_api_version01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationReceived",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreditRequested = c.Int(nullable: false),
                        CreditTerms = c.String(),
                        Name = c.String(),
                        Industry = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        StyleOfBusiness = c.String(),
                        YearsEstablished = c.Int(nullable: false),
                        ProvinceEstablished = c.String(),
                        NumOfEmployees = c.Int(nullable: false),
                        AnnualSales = c.Single(nullable: false),
                        DunsNumber = c.Int(nullable: false),
                        TaxId = c.Int(nullable: false),
                        TaxExempt = c.Single(nullable: false),
                        ContactTitle = c.String(),
                        ContactFirstname = c.String(),
                        ContactLastName = c.String(),
                        ContactPhone = c.String(),
                        ContactEmail = c.String(),
                        Company_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Company", t => t.Company_ID)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.TradeReference",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Applicant = c.String(),
                        Creditor = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        YearsInBusiness = c.Int(nullable: false),
                        DateOfLastSale = c.Int(nullable: false),
                        TotalCredit = c.Int(nullable: false),
                        CreditLimit = c.Single(nullable: false),
                        CurrentOutstandingBalance = c.Single(nullable: false),
                        BalancePastDue = c.Single(nullable: false),
                        HighestBalance = c.Single(nullable: false),
                        CreditTerms = c.String(),
                        PaymentExperience = c.String(),
                        rating = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationReceived", "Company_ID", "dbo.Company");
            DropIndex("dbo.ApplicationReceived", new[] { "Company_ID" });
            DropTable("dbo.TradeReference");
            DropTable("dbo.ApplicationReceived");
        }
    }
}
