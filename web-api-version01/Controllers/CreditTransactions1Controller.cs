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
    public class CreditTransactions1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreditTransactions1
        public ActionResult Index()
        {
            return View(db.CreditTransactions.ToList());
        }

        // GET: CreditTransactions1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditTransaction creditTransaction = db.CreditTransactions.Find(id);
            if (creditTransaction == null)
            {
                return HttpNotFound();
            }
            return View(creditTransaction);
        }

        // GET: CreditTransactions1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditTransactions1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreditTransactionID,Company,CreditIssued,Amount,DueDate,Paid")] CreditTransaction creditTransaction)
        {
            if (ModelState.IsValid)
            {
                db.CreditTransactions.Add(creditTransaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creditTransaction);
        }

        // GET: CreditTransactions1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditTransaction creditTransaction = db.CreditTransactions.Find(id);
            if (creditTransaction == null)
            {
                return HttpNotFound();
            }
            return View(creditTransaction);
        }

        // POST: CreditTransactions1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreditTransactionID,Company,CreditIssued,Amount,DueDate,Paid")] CreditTransaction creditTransaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creditTransaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creditTransaction);
        }

        // GET: CreditTransactions1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreditTransaction creditTransaction = db.CreditTransactions.Find(id);
            if (creditTransaction == null)
            {
                return HttpNotFound();
            }
            return View(creditTransaction);
        }

        // POST: CreditTransactions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreditTransaction creditTransaction = db.CreditTransactions.Find(id);
            db.CreditTransactions.Remove(creditTransaction);
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
