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
    public class CompaniesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        //  GET Equifax Score of reciving the company name as parameter
        [Route("api/Companies/EquifaxScore/{name}")]
        public IHttpActionResult GetEquifaxScore(string name)

        {
            var company = (from c in db.EquifaxDatas
                           where  c.Company.Equals(name)
                           select c
                           );
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        //TODO
        //  GET Dnb Score Score of reciving the company name as parameter
        [Route("api/Companies/DbnScore/{name}")]
        public IHttpActionResult GetDbnScore(string name)

        {

            var company = (from c in db.DnbDatas
                           where c.Company.Equals(name)
                           select c
                          );
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
        // GET: api/Companies\

        public IQueryable<Company> GetCompanies()
        {

            return db.Companies;
        }

        // GET: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != company.ID)
            {
                return BadRequest();
            }

            db.Entry(company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        [ResponseType(typeof(Company))]
        public IHttpActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companies.Add(company);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = company.ID }, company);
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(Company))]
        public IHttpActionResult DeleteCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            db.Companies.Remove(company);
            db.SaveChanges();

            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.ID == id) > 0;
        }
    }
    class ResultsCustom { internal double? average; double averange; }
}