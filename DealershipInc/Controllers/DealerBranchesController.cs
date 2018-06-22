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
    public class DealerBranchesController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: DealerBranches
        public ActionResult Index()
        {
            return View(db.DealerBranches.ToList());
        }

        // GET: DealerBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerBranch dealerBranch = db.DealerBranches.Find(id);
            if (dealerBranch == null)
            {
                return HttpNotFound();
            }
            return View(dealerBranch);
        }

        // GET: DealerBranches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DealerBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchID,Address,OpenTime,CloseTime,TargetSalesYear,TargetSalesMonth")] DealerBranch dealerBranch)
        {
            if (ModelState.IsValid)
            {
                db.DealerBranches.Add(dealerBranch);
                db.SaveChanges();
                return RedirectToAction("Index", "Manager");
            }

            return View(dealerBranch);
        }

        // GET: DealerBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerBranch dealerBranch = db.DealerBranches.Find(id);
            if (dealerBranch == null)
            {
                return HttpNotFound();
            }
            return View(dealerBranch);
        }

        // POST: DealerBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchID,Address,OpenTime,CloseTime,TargetSalesYear,TargetSalesMonth")] DealerBranch dealerBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealerBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Manager");
            }
            return View(dealerBranch);
        }

        // GET: DealerBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerBranch dealerBranch = db.DealerBranches.Find(id);
            if (dealerBranch == null)
            {
                return HttpNotFound();
            }
            return View(dealerBranch);
        }

        // POST: DealerBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DealerBranch dealerBranch = db.DealerBranches.Find(id);
            db.DealerBranches.Remove(dealerBranch);
            db.SaveChanges();
            return RedirectToAction("Index", "Manager");
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
