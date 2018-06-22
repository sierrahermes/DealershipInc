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
    public class VehiclesController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: Vehicles
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.DealerBranch).Include(v => v.Manufacturer);
            return View(vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address");
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "CompanyName");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VIN,Type,Price,isNewFlag,Description,Photo,DateAdded,ManufacturerID,BranchID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index", "ProcurementEmp");
            }

            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", vehicle.BranchID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "CompanyName", vehicle.ManufacturerID);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", vehicle.BranchID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "CompanyName", vehicle.ManufacturerID);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VIN,Type,Price,isNewFlag,Description,Photo,DateAdded,ManufacturerID,BranchID")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "ProcurementEmp");
            }
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", vehicle.BranchID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ManufacturerID", "CompanyName", vehicle.ManufacturerID);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index", "ProcurementEmp");
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
