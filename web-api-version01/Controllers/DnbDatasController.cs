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
    public class DnbDatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DnbDatas
        public IQueryable<DnbData> GetDnbDatas()
        {
            return db.DnbDatas;
        }

        //GET api/DnbData/Company/{name}
        [Route("api/Dnb/Company/{name}")]
        public IHttpActionResult GetDnbDatasByname(string name)
        {


            var dnbData = from d in db.DnbDatas
                               where d.Company.Equals(name)
                               select d;
                        

            if (dnbData == null)
            {
                return NotFound();
            }
            return Ok(dnbData);
        }
    // GET: api/DnbDatas/5
    [ResponseType(typeof(DnbData))]
        public IHttpActionResult GetDnbData(int id)
        {
            DnbData dnbData = db.DnbDatas.Find(id);
            if (dnbData == null)
            {
                return NotFound();
            }

            return Ok(dnbData);
        }

        // PUT: api/DnbDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDnbData(int id, DnbData dnbData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dnbData.ID)
            {
                return BadRequest();
            }

            db.Entry(dnbData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DnbDataExists(id))
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

        // POST: api/DnbDatas
        [ResponseType(typeof(DnbData))]
        public IHttpActionResult PostDnbData(DnbData dnbData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DnbDatas.Add(dnbData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dnbData.ID }, dnbData);
        }

        // DELETE: api/DnbDatas/5
        [ResponseType(typeof(DnbData))]
        public IHttpActionResult DeleteDnbData(int id)
        {
            DnbData dnbData = db.DnbDatas.Find(id);
            if (dnbData == null)
            {
                return NotFound();
            }

            db.DnbDatas.Remove(dnbData);
            db.SaveChanges();

            return Ok(dnbData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DnbDataExists(int id)
        {
            return db.DnbDatas.Count(e => e.ID == id) > 0;
        }
    }
}