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
    public class CreditTransactionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CreditTransactions
        public IQueryable<CreditTransaction> GetCreditTransactions()
        {
            return db.CreditTransactions;
        }

        // GET: api/CreditTransactions/5
        [ResponseType(typeof(CreditTransaction))]
        public IHttpActionResult GetCreditTransaction(int id)
        {
            CreditTransaction creditTransaction = db.CreditTransactions.Find(id);
            if (creditTransaction == null)
            {
                return NotFound();
            }

            return Ok(creditTransaction);
        }

        // PUT: api/CreditTransactions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCreditTransaction(int id, CreditTransaction creditTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditTransaction.CreditTransactionID)
            {
                return BadRequest();
            }

            db.Entry(creditTransaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditTransactionExists(id))
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

        // POST: api/CreditTransactions
        [ResponseType(typeof(CreditTransaction))]
        public IHttpActionResult PostCreditTransaction(CreditTransaction creditTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CreditTransactions.Add(creditTransaction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = creditTransaction.CreditTransactionID }, creditTransaction);
        }

        // DELETE: api/CreditTransactions/5
        [ResponseType(typeof(CreditTransaction))]
        public IHttpActionResult DeleteCreditTransaction(int id)
        {
            CreditTransaction creditTransaction = db.CreditTransactions.Find(id);
            if (creditTransaction == null)
            {
                return NotFound();
            }

            db.CreditTransactions.Remove(creditTransaction);
            db.SaveChanges();

            return Ok(creditTransaction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CreditTransactionExists(int id)
        {
            return db.CreditTransactions.Count(e => e.CreditTransactionID == id) > 0;
        }
    }
}