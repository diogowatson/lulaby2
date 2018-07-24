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
    public class EquifaxDatasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EquifaxDatas
        public IQueryable<EquifaxData> GetEquifaxDatas()
        {
            return db.EquifaxDatas;
        }


        //GET api/EquifaxDatas/Company/{name}
        [Route("api/EquifaxDatas/Company/{name}")]
        public IHttpActionResult GetEquifaxdatasByname(string name)
        {
            var dnbData = from d in db.EquifaxDatas
                          where d.Company.Equals(name)
                          select d;
            
            if (dnbData == null)
            {
                return NotFound();
            }
            return Ok(dnbData);
        }

        // GET: api/EquifaxDatas/5
        [ResponseType(typeof(EquifaxData))]
        public IHttpActionResult GetEquifaxData(int id)
        {
            EquifaxData equifaxData = db.EquifaxDatas.Find(id);
            if (equifaxData == null)
            {
                return NotFound();
            }

            return Ok(equifaxData);
        }

        // PUT: api/EquifaxDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEquifaxData(int id, EquifaxData equifaxData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != equifaxData.ID)
            {
                return BadRequest();
            }

            db.Entry(equifaxData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquifaxDataExists(id))
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

        // POST: api/EquifaxDatas
        [ResponseType(typeof(EquifaxData))]
        public IHttpActionResult PostEquifaxData(EquifaxData equifaxData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EquifaxDatas.Add(equifaxData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = equifaxData.ID }, equifaxData);
        }

        // DELETE: api/EquifaxDatas/5
        [ResponseType(typeof(EquifaxData))]
        public IHttpActionResult DeleteEquifaxData(int id)
        {
            EquifaxData equifaxData = db.EquifaxDatas.Find(id);
            if (equifaxData == null)
            {
                return NotFound();
            }

            db.EquifaxDatas.Remove(equifaxData);
            db.SaveChanges();

            return Ok(equifaxData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EquifaxDataExists(int id)
        {
            return db.EquifaxDatas.Count(e => e.ID == id) > 0;
        }
    }
}