using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web_api_version01.Models;

namespace web_api_version01.Models
{
    public class ProjectInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var Application = new List<Application>
            {
                new Application {Company="Coca-cola", DateAplied=DateTime.Parse("12/12/12"),DateProcessed=DateTime.Parse("12-12-12"),CreditApplied=001,CreditAproved=001, Recomendation="none",
                Aproved=true, Score=121}

            };

            Application.ForEach(s => context.Applications.Add(s));
            context.SaveChanges();

            var Company = new List<Company>
            {
                new Company{Name="Coca-cola", Address="undefined",ParentCompany="undefined",CreditIssued=001,Terms="undefined"}
            };

            Company.ForEach(s => context.Companies.Add(s));
            context.SaveChanges();

            var CreditTransaction = new List<CreditTransaction>
            {
                new CreditTransaction{Company="Coca-cola", CreditIssued=DateTime.Parse("12-12-12"), Amount=001, DueDate=DateTime.Parse("12-12-12"), Paid=true}
            };

            CreditTransaction.ForEach(s => context.CreditTransactions.Add(s));
            context.SaveChanges();

            var Dnbdata = new List<DnbData>
            {
                new DnbData{Company="Coca-cola",Date=DateTime.Parse("12-12-12"), FailureScore=000,DelinquencyScore=001,Paydex=0011, ViabilityRating=001 }
            };
            Dnbdata.ForEach(s => context.DnbDatas.Add(s));
            context.SaveChanges();

            var EquifaxData = new List<EquifaxData>
            {
                new EquifaxData {Company="Coca_cola", Date=DateTime.Parse("12-12-12"), CreditIndex=001, PaymentIndex=001, Cds=001, Bfrs=0001}
            };

            EquifaxData.ForEach(s => context.EquifaxDatas.Add(s));
            context.SaveChanges();


            
        }
    }
}