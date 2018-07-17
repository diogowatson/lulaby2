using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using web_api_version01.Models;

namespace web_api_version01.Controllers
{
    public class TestController :ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public string GetApplicationScore()
        {
            //var queryString = "SELECT SUM(Score * CreditApproved) FROM dbo.Applications";
            //var result = db.Applications.SqlQuery(queryString).ToString();
            //result = "test";
            //return result;
            // return db.Applications.ForEachAsync(b=>b.Equals(Score) )
            return "test";
        }
    }
}