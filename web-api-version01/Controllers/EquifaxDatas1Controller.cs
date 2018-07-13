using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_api_version01.Models;

namespace web_api_version01.Controllers
{
    public class EquifaxDatas1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EquifaxDatas1
        public ActionResult Index()
        {
            return View(db.EquifaxDatas.ToList());
        }

        // GET: EquifaxDatas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquifaxData equifaxData = db.EquifaxDatas.Find(id);
            if (equifaxData == null)
            {
                return HttpNotFound();
            }
            return View(equifaxData);
        }

        // GET: EquifaxDatas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquifaxDatas1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Company,Date,CreditIndex,PaymentIndex,Cds,Bfrs")] EquifaxData equifaxData)
        {
            if (ModelState.IsValid)
            {
                db.EquifaxDatas.Add(equifaxData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equifaxData);
        }

        // GET: EquifaxDatas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquifaxData equifaxData = db.EquifaxDatas.Find(id);
            if (equifaxData == null)
            {
                return HttpNotFound();
            }
            return View(equifaxData);
        }

        // POST: EquifaxDatas1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Company,Date,CreditIndex,PaymentIndex,Cds,Bfrs")] EquifaxData equifaxData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equifaxData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equifaxData);
        }

        // GET: EquifaxDatas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquifaxData equifaxData = db.EquifaxDatas.Find(id);
            if (equifaxData == null)
            {
                return HttpNotFound();
            }
            return View(equifaxData);
        }

        // POST: EquifaxDatas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquifaxData equifaxData = db.EquifaxDatas.Find(id);
            db.EquifaxDatas.Remove(equifaxData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
