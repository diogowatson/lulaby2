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
using System.Net.Mail;//libary to send email from the server

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

        //GET all companies pending aproval
        [Route("api/Applications/ProcessStatus/Pending")]
        public IHttpActionResult GetApproval()
        {
            var result = (from a in db.Applications
                          where a.ProcessStatus == false
                          select a
                          );
            if(result==null)
            {
                return Ok("None application spendding aproval");
            }
            return Ok(result);
        }
        //get all credit peddding aproval
        [Route("api/Applications/AllCreditPendingApproval")]
        public IHttpActionResult GetAllCreditApproval()
        {
            var result = (from a in db.Applications
                          where a.ProcessStatus == false
                          select a
                          );
            if (result == null)
            {
                return Ok("None application spendding aproval");
            }
            return Ok(result);
        }

        // GET: api/Applications/score
        [Route("api/Applications/score")]
        public IHttpActionResult GetScore()
        {
            float sumProd = db.Applications.Sum(a => a.Score * a.CreditAproved);
            float sumCreditApproved = db.Applications.Sum(a => a.CreditAproved);
            float result = sumProd / sumCreditApproved;
            return Ok(result);
        }

        // GET: api/Applications/newappcount
        [Route("api/Applications/newappcount")]
        public IHttpActionResult GetNewAppCount()
        {
            int appCount = db.Applications.Where(a => a.ProcessStatus == false).Count();
           
            return Ok(appCount);
        }

        // GET: api/Applications/newappcredit
        [Route("api/Applications/newappcredit")]
        public IHttpActionResult GetNewAppCredit()
        {
            int appCredit = db.Applications.Where(a => a.ProcessStatus==false).Sum(a => a.CreditAproved);
            
            return Ok(appCredit);
        }

        // GET: api/Applications/newapplications
        [Route("api/Applications/newapplications")]
        public IHttpActionResult GetNewApplications()
        {
            var newAppQuery = db.Applications.Where(a => a.ProcessStatus==false);
            if (newAppQuery == null)
            {
                return NotFound();
            }
            return Ok(newAppQuery);
        }

        // GET: api/Applications/creditriskdist
        [Route("api/Applications/creditriskdist")]
        public IHttpActionResult GetCreditRiskDist()
        {
            var creditRiskDist = db.Applications.Where(a => a.DateProcessed.Year <= 2018)
                                                .GroupBy(a => a.Score, a => a.CreditAproved)
                                                .Select(g => new CreditRiskDist()
                                                {
                                                    score = g.Key,
                                                    credit = g.ToList().Sum()
                                                });
            return Ok(creditRiskDist);
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
        // POST to send email
        [Route("api/SendEmail/{email}")]
        public string PostSendEmail(string email)
        {
            return email;
            
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