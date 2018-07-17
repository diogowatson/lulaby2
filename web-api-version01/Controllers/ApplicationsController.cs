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
   

    public class ApplicationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

           
        // GET: api/Applications
        public IQueryable<Application> GetApplications()
        {
            return db.Applications;
        }

        // GET: api/Applications/score
        [Route("api/Applications/score")]
        public float GetScore()
        {
            float sumProd = db.Applications.Sum(a => a.Score * a.CreditAproved);
            float sumCreditApproved = db.Applications.Sum(a => a.CreditAproved);
            return sumProd / sumCreditApproved;
        }

        // GET: api/Applications/newappcount
        [Route("api/Applications/newappcount")]
        public int GetNewAppCount()
        {
            int appCount = db.Applications.Where(a => a.DateProcessed.Year > 2018).Count();
            return appCount;
        }

        // GET: api/Applications/newappcredit
        [Route("api/Applications/newappcredit")]
        public int GetNewAppCredit()
        {
            int appCredit = db.Applications.Where(a => a.DateProcessed.Year > 2018).Sum(a => a.CreditAproved);
            return appCredit;
        }

        // GET: api/Applications/newapplications
        [Route("api/Applications/newapplications")]
        public IQueryable<Application> GetNewApplications()
        {
            var newAppQuery = db.Applications.Where(a => a.DateProcessed.Year > 2018);
            return newAppQuery;
        }

        // GET: api/Applications/creditriskdist
        [Route("api/Applications/creditriskdist")]
        public IQueryable<CreditRiskDist> GetCreditRiskDist()
        {
            var creditRiskDist = db.Applications.Where(a => a.DateProcessed.Year <= 2018)
                                                .GroupBy(a => a.Score, a => a.CreditAproved)
                                                .Select(g => new CreditRiskDist()
                                                {
                                                    score = g.Key,
                                                    credit = g.ToList().Sum()
                                                });
            return creditRiskDist;
        }

        // GET: api/Applications/creditindustrydist
        //[Route("api/Applications/creditindustrydist")]
        //public IQueryable<CreditIndustryDist> GetCreditIndustryDist()
        //{
        //    var industries = db.Companies.Select(c => new { c.ID,  });
        //    var creditIndustryDist = db.Applications.Where(a => a.DateProcessed.Year <= 2018)
        //                                            .GroupBy(a => a.Indus, a => a.CreditAproved)
        //                                            .Select(g => new CreditIndustryDist()
        //                                            {
        //                                                industry = g.Key,
        //                                                credit = g.ToList().Sum()
        //                                            });
        //    return creditIndustryDist;
        //}

        // GET: api/Applications/5
        [ResponseType(typeof(Application))]
        public IHttpActionResult GetApplication(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplication(int id, Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != application.ID)
            {
                return BadRequest();
            }

            db.Entry(application).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Applications
        [ResponseType(typeof(Application))]
        public IHttpActionResult PostApplication(Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(application);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = application.ID }, application);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Application))]
        public IHttpActionResult DeleteApplication(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            db.Applications.Remove(application);
            db.SaveChanges();

            return Ok(application);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationExists(int id)
        {
            return db.Applications.Count(e => e.ID == id) > 0;
        }
    }

    ///inner classes
    public class CreditRiskDist
    {
        public int score { get; set; }
        public int credit { get; set; }
    }

    public class CreditIndustryDist
    {
        public string industry { get; set; }
        public int credit { get; set; }
    }
}