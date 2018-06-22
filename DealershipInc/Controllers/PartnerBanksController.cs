using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DealershipInc.Models;

namespace DealershipInc.Controllers
{
    public class PartnerBanksController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: PartnerBanks
        public ActionResult Index()
        {
            return View(db.PartnerBanks.ToList());
        }

        // GET: PartnerBanks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerBank partnerBank = db.PartnerBanks.Find(id);
            if (partnerBank == null)
            {
                return HttpNotFound();
            }
            return View(partnerBank);
        }

        // GET: PartnerBanks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartnerBanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankID,BadCreditRate,FairCreditRate,GoodCreditRate,ExcellentCreditRate,MaxLoanTerm")] PartnerBank partnerBank)
        {
            if (ModelState.IsValid)
            {
                db.PartnerBanks.Add(partnerBank);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partnerBank);
        }

        // GET: PartnerBanks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerBank partnerBank = db.PartnerBanks.Find(id);
            if (partnerBank == null)
            {
                return HttpNotFound();
            }
            return View(partnerBank);
        }

        // POST: PartnerBanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankID,BadCreditRate,FairCreditRate,GoodCreditRate,ExcellentCreditRate,MaxLoanTerm")] PartnerBank partnerBank)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partnerBank).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partnerBank);
        }

        // GET: PartnerBanks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartnerBank partnerBank = db.PartnerBanks.Find(id);
            if (partnerBank == null)
            {
                return HttpNotFound();
            }
            return View(partnerBank);
        }

        // POST: PartnerBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartnerBank partnerBank = db.PartnerBanks.Find(id);
            db.PartnerBanks.Remove(partnerBank);
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
