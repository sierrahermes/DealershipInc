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
    public class CarSalesFormsController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: CarSalesForms
        public ActionResult Index()
        {
            var carSalesForms = db.CarSalesForms.Include(c => c.VehicleAddOn).Include(c => c.Customer).Include(c => c.Employee).Include(c => c.Vehicle).Include(c => c.DealerBranch);
            return View(carSalesForms.ToList());
        }

        // GET: CarSalesForms/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSalesForm carSalesForm = db.CarSalesForms.Find(id);
            if (carSalesForm == null)
            {
                return HttpNotFound();
            }
            return View(carSalesForm);
        }

        // GET: CarSalesForms/Create
        public ActionResult Create()
        {
            ViewBag.AddOnID = new SelectList(db.VehicleAddOns, "AddOnID", "Manufacturer");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "EMail");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName");
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "isNewFlag");
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address");
            return View();
        }

        // POST: CarSalesForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarSaleFormID,CreateDate,AddOnID,CustomerID,EmployeeID,VIN,BranchID")] CarSalesForm carSalesForm)
        {
            if (ModelState.IsValid)
            {
                db.CarSalesForms.Add(carSalesForm);
                db.SaveChanges();
                return RedirectToAction("Index", "SalesEmp");
            }

            ViewBag.AddOnID = new SelectList(db.VehicleAddOns, "AddOnID", "Manufacturer", carSalesForm.AddOnID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "EMail", carSalesForm.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", carSalesForm.EmployeeID);
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "isNewFlag", carSalesForm.VIN);
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", carSalesForm.BranchID);
            return View(carSalesForm);
        }

        // GET: CarSalesForms/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSalesForm carSalesForm = db.CarSalesForms.Find(id);
            if (carSalesForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddOnID = new SelectList(db.VehicleAddOns, "AddOnID", "Manufacturer", carSalesForm.AddOnID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "EMail", carSalesForm.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", carSalesForm.EmployeeID);
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "isNewFlag", carSalesForm.VIN);
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", carSalesForm.BranchID);
            return View(carSalesForm);
        }

        // POST: CarSalesForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarSaleFormID,CreateDate,AddOnID,CustomerID,EmployeeID,VIN,BranchID")] CarSalesForm carSalesForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carSalesForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "SalesEmp");
            }
            ViewBag.AddOnID = new SelectList(db.VehicleAddOns, "AddOnID", "Manufacturer", carSalesForm.AddOnID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "EMail", carSalesForm.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", carSalesForm.EmployeeID);
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "isNewFlag", carSalesForm.VIN);
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", carSalesForm.BranchID);
            return View(carSalesForm);
        }

        // GET: CarSalesForms/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSalesForm carSalesForm = db.CarSalesForms.Find(id);
            if (carSalesForm == null)
            {
                return HttpNotFound();
            }
            return View(carSalesForm);
        }

        // POST: CarSalesForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CarSalesForm carSalesForm = db.CarSalesForms.Find(id);
            db.CarSalesForms.Remove(carSalesForm);
            db.SaveChanges();
            return RedirectToAction("Index", "SalesEmp");
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
