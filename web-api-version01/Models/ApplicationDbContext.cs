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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}