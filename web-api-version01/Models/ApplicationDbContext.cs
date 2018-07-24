using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace web_api_version01.Models
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext() : base("intelligentCredit")
        { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CreditTransaction> CreditTransactions { get; set; }
        public DbSet<DnbData> DnbDatas { get; set; }
        public DbSet<EquifaxData> EquifaxDatas{get;set;}
        public DbSet<ApplicationReceived> applicationReceiveds { get; set; }//added in 2018-07-20
        public DbSet<TradeReference> tradeReferences { get; set; }//added in 2018-07-20

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}