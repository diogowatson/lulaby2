using System;
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

using System.Web.Http.Cors;
using System.IO;
using emailApp;


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

        //get application with statua appproved, processed group by credit term = 30 days
        [Route("api/Applications/Processed30")]
        public IHttpActionResult GetApplicationsProcessedGroupByCreditTerm()
        {
            var sumProd = db.Applications
                                        .Where(a => a.Aproved == 1 && a.ProcessStatus == true)
                                        .GroupBy(a => a.CreditTerm)
                                        .Select(e => new { CreditTerm = e.Key, Credit = e.Sum(c => c.CreditAproved) })
                                        .ToList();

            return Ok(sumProd);
        }

        //Get all PROCESSED Applications with Approval status Approved
        [Route("api/Applications/ProcessStatus/Approved")]
            public IHttpActionResult GetAllAplicationWithStatusApproved()
        
        {
            var result = (from a in db.Applications
                          where a.ProcessStatus == true && a.Aproved==1//one equals to approved
                          select a
                          );
            if (result == null)
            {
                return Ok("None application spendding aproval");
            }
            return Ok(result);
        }

        // Get all PROCESSED Applications with Approval status Denied
        [Route("api/Applications/ProcessStatus/Denied")]
        public IHttpActionResult GetAllAplicationWithStatusDenied()

        {
            var result = (from a in db.Applications
                          where a.ProcessStatus == true && a.Aproved == 0//one equals to approved
                          select a
                          );
            if (result == null)
            {
                return Ok("None application spendding aproval");
            }
            return Ok(result);
        }
        //Get all PROCESSED Applications with Approval status Approved and sum the approved Amount
        //Get all PROCESSED Applications with Approval status Approved
        [Route("api/Applications/ProcessStatus/ApprovedWithSum")]
        public IHttpActionResult GetAllAplicationWithStatusApprovedWithSum()

        {
            var result = (from a in db.Applications
                          where a.ProcessStatus == true && a.Aproved == 1//one equals to approved
                          select a.CreditAproved
                          ).Sum();
            if (result == null)
            {
                return Ok("None application spendding aproval");
            }
            return Ok(result);
        }
        
        //Get all PROCESSED Applications with Approval status Approved and sum the approved Amount sorted by Score
        [Route("api/Applications/ProcessStatus/ApprovedWithSumGroupedByScore")]//working
        public IHttpActionResult GetAllAplicationWithStatusApprovedWithSumGroupedByScore()
        {
            var sumProd = db.Applications
                .Where(a => a.Aproved == 1 && a.ProcessStatus == true)
                .GroupBy(a => a.Score)
                .Select(e => new { IndustrygGroup = e.Key, Credit = e.Sum(c => c.CreditAproved) })
                .ToList();
                 
            return Ok(sumProd);
        }

        //Get all PROCESSED Applications with Approval status Approved and sum the approved Amount sorted by Industry

        [Route("api/Applications/ProcessStatus/ApprovedWithSumGroupedByIndustry")]
        public IHttpActionResult GetAllAplicationWithStatusApprovedWithSumGroupedByIndustry()
        {
           
            var sumProd = db.Applications
                                         .Where(a => a.Aproved == 1 && a.ProcessStatus == true)
                                         .GroupBy(a => a.Industry )
                                         .Select(e => new {IndustryGroup = e.Key ,Credit = e.Sum(c => c.CreditAproved) })
                                         .ToList();
           
            return Ok(sumProd);
        }


        //GET all companies pending aproval
        [Route("api/Applications/ProcessStatus/Pending")]
        public IHttpActionResult GetApproval()
        {


            var result = (from a in db.Applications
                          where a.ProcessStatus == false
                          select a
                          );
            if (result==null)
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
                          where a.ProcessStatus == false && a.Aproved == 1
                          select a
                          );
            if (result == null)
            {
                return Ok("None application spendding aproval");
            }
            return Ok(result);
        }

        // GET: api/Applications/Score
        [Route("api/Applications/Score")]
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
                                                    Score = g.Key,
                                                    Credit = g.ToList().Sum()
                                                });
            return Ok(creditRiskDist);
        }

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
        //[EnableCors(origins:"*", headers:"*", methods:"*")]
        [ResponseType(typeof(Application))]
        public IHttpActionResult PostApplication([FromBody]Application application)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sendmail m = new Sendmail(application.AplicantEmail, "Adastra Onbording");
            m.SendWithHTMLBody();
            db.Applications.Add(application);
            db.SaveChanges();
            
            return CreatedAtRoute("DefaultApi", new { id = application.ID }, application);
        }
        // POST to send email
        [Route("api/SendEmail/{email}")]
        public void PostEmail(string email)
        {
            Sendmail m = new Sendmail("test",email, "test");
            ///submit


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

    internal class Sendmail
    {
        //global variable
        private string LocationOfFileBody { get; set; }
        private string MailAddress { get; set; }
        private string Subject { get; set; }
        private string Message { get; set; }
        //public StreamReader reader = File.OpenText("C:/Users/diogo.watson/source/repos/emailApp/emailApp/emailBody.html");

        public static string bodyLocation = "C:/Users/diogo.watson/source/repos/emailApp/emailApp/emailBody.html";

        //contructor that uses an HTML file as body message
        public Sendmail(string mailAddress,
                        string subject
                        )
        {
            try
            {
                
                MailAddress = mailAddress;
                Subject = subject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }
        
        public Sendmail(string message,
                        string mailAddress,
                        string subject
                        )
        {
            try
            {
                Message = Message;
                MailAddress = mailAddress;
                Subject = subject;
            }
            catch (Exception e)
            {
                
            }

        }
        //this function take 3 parameters
        //param 1 -> an Streamreader Object that points to HTML of the email body
        //ex:StreamReader reader = File.OpenText("C:/Users/diogo.watson/source/repos/emailApp/emailApp/emailBody.html");
        //param 2 teh email address to send the email
        //param 3 the subject of the email

        public void SendWithHTMLBody()
        {
            StreamReader reader = File.OpenText("C:/Users/diogo.watson/source/repos/web-api-version01/web-api-version01/Resources/emailBody.html");
            string message = reader.ReadToEnd();
            MailMessage mail = new MailMessage("adastra.credit.project@gmail.com", MailAddress);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;//important
            client.Credentials = new NetworkCredential("adastra.credit.project@gmail.com", "Adastra10");
            mail.IsBodyHtml = true;


            mail.Subject = Subject;
            mail.Body = message;

            try
            {
                client.Send(mail);
            }
            catch (System.Exception e) {  }

        }


        //this function take 3 parameters
        //param 1 -> an message string
        //param 2 teh email address to send the email
        //param 3 the subject of the email
        public void SendMessage()
        {

            MailMessage mail = new MailMessage("adastra.credit.project@gmail.com", MailAddress);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            // client.Host = "";
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;//important
            client.Credentials = new NetworkCredential("adastra.credit.project@gmail.com", "Adastra10");
            mail.IsBodyHtml = true;
            mail.Subject = Subject;
            mail.Body = Message;

            try
            {
                client.Send(mail);
            }
            catch (System.Exception e) { }
            
        }
    }
}

    ///inner classes
    public class CreditRiskDist
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Credit { get; set; }
    }

    public class CreditIndustryDist
    {
        public string Name { get; set; }
        public string Industry { get; set; }
        public int Credit { get; set; }
    }
