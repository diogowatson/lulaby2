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
    public class DnbDatas1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DnbDatas1
        public ActionResult Index()
        {
            return View(db.DnbDatas.ToList());
        }

        // GET: DnbDatas1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnbData dnbData = db.DnbDatas.Find(id);
            if (dnbData == null)
            {
                return HttpNotFound();
            }
            return View(dnbData);
        }

        // GET: DnbDatas1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DnbDatas1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Company,Date,FailureScore,DelinquencyScore,Paydex,ViabilityRating")] DnbData dnbData)
        {
            if (ModelState.IsValid)
            {
                db.DnbDatas.Add(dnbData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dnbData);
        }

        // GET: DnbDatas1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnbData dnbData = db.DnbDatas.Find(id);
            if (dnbData == null)
            {
                return HttpNotFound();
            }
            return View(dnbData);
        }

        // POST: DnbDatas1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Company,Date,FailureScore,DelinquencyScore,Paydex,ViabilityRating")] DnbData dnbData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dnbData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dnbData);
        }

        // GET: DnbDatas1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnbData dnbData = db.DnbDatas.Find(id);
            if (dnbData == null)
            {
                return HttpNotFound();
            }
            return View(dnbData);
        }

        // POST: DnbDatas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DnbData dnbData = db.DnbDatas.Find(id);
            db.DnbDatas.Remove(dnbData);
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
