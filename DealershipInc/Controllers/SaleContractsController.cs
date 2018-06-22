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
    public class SaleContractsController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: SaleContracts
        public ActionResult Index()
        {
            var saleContracts = db.SaleContracts.Include(s => s.CarSalesForm).Include(s => s.PartnerBank);
            return View(saleContracts.ToList());
        }

        // GET: SaleContracts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleContract saleContract = db.SaleContracts.Find(id);
            if (saleContract == null)
            {
                return HttpNotFound();
            }
            return View(saleContract);
        }

        // GET: SaleContracts/Create
        public ActionResult Create()
        {
            ViewBag.CarSaleFormID = new SelectList(db.CarSalesForms, "CarSaleFormID", "VIN");
            ViewBag.BankID = new SelectList(db.PartnerBanks, "BankID", "BankID");
            return View();
        }

        // POST: SaleContracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaleContractID,ContractDate,isCashFlag,FinanceRate,FinanceTerm,DueMonthly,BankID,CarSaleFormID")] SaleContract saleContract)
        {
            if (ModelState.IsValid)
            {
                db.SaleContracts.Add(saleContract);
                db.SaveChanges();
                return RedirectToAction("Index", "FinanceEmp");
            }

            ViewBag.CarSaleFormID = new SelectList(db.CarSalesForms, "CarSaleFormID", "VIN", saleContract.CarSaleFormID);
            ViewBag.BankID = new SelectList(db.PartnerBanks, "BankID", "BankID", saleContract.BankID);
            return View(saleContract);
        }

        // GET: SaleContracts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleContract saleContract = db.SaleContracts.Find(id);
            if (saleContract == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarSaleFormID = new SelectList(db.CarSalesForms, "CarSaleFormID", "VIN", saleContract.CarSaleFormID);
            ViewBag.BankID = new SelectList(db.PartnerBanks, "BankID", "BankID", saleContract.BankID);
            return View(saleContract);
        }

        // POST: SaleContracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaleContractID,ContractDate,isCashFlag,FinanceRate,FinanceTerm,DueMonthly,BankID,CarSaleFormID")] SaleContract saleContract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleContract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "FinanceEmp");
            }
            ViewBag.CarSaleFormID = new SelectList(db.CarSalesForms, "CarSaleFormID", "VIN", saleContract.CarSaleFormID);
            ViewBag.BankID = new SelectList(db.PartnerBanks, "BankID", "BankID", saleContract.BankID);
            return View(saleContract);
        }

        // GET: SaleContracts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleContract saleContract = db.SaleContracts.Find(id);
            if (saleContract == null)
            {
                return HttpNotFound();
            }
            return View(saleContract);
        }

        // POST: SaleContracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleContract saleContract = db.SaleContracts.Find(id);
            db.SaleContracts.Remove(saleContract);
            db.SaveChanges();
            return RedirectToAction("Index", "FinanceEmp");
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
