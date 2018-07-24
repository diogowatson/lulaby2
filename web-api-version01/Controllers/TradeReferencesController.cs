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
    public class TradeReferencesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/TradeReferences
        public IQueryable<TradeReference> GettradeReferences()
        {
            return db.tradeReferences;
        }

        // GET: api/TradeReferences/5
        [ResponseType(typeof(TradeReference))]
        public IHttpActionResult GetTradeReference(int id)
        {
            TradeReference tradeReference = db.tradeReferences.Find(id);
            if (tradeReference == null)
            {
                return NotFound();
            }

            return Ok(tradeReference);
        }

        // PUT: api/TradeReferences/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTradeReference(int id, TradeReference tradeReference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tradeReference.ID)
            {
                return BadRequest();
            }

            db.Entry(tradeReference).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeReferenceExists(id))
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

        // POST: api/TradeReferences
        [ResponseType(typeof(TradeReference))]
        public IHttpActionResult PostTradeReference(TradeReference tradeReference)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tradeReferences.Add(tradeReference);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tradeReference.ID }, tradeReference);
        }

        // DELETE: api/TradeReferences/5
        [ResponseType(typeof(TradeReference))]
        public IHttpActionResult DeleteTradeReference(int id)
        {
            TradeReference tradeReference = db.tradeReferences.Find(id);
            if (tradeReference == null)
            {
                return NotFound();
            }

            db.tradeReferences.Remove(tradeReference);
            db.SaveChanges();

            return Ok(tradeReference);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TradeReferenceExists(int id)
        {
            return db.tradeReferences.Count(e => e.ID == id) > 0;
        }
    }
}