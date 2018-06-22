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
    public class VehicleAddOnsController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: VehicleAddOns
        public ActionResult Index()
        {
            return View(db.VehicleAddOns.ToList());
        }

        // GET: VehicleAddOns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAddOn vehicleAddOn = db.VehicleAddOns.Find(id);
            if (vehicleAddOn == null)
            {
                return HttpNotFound();
            }
            return View(vehicleAddOn);
        }

        // GET: VehicleAddOns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleAddOns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddOnID,Manufacturer,Description,Price,ForVehicleType,QuantityAvail")] VehicleAddOn vehicleAddOn)
        {
            if (ModelState.IsValid)
            {
                db.VehicleAddOns.Add(vehicleAddOn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleAddOn);
        }

        // GET: VehicleAddOns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAddOn vehicleAddOn = db.VehicleAddOns.Find(id);
            if (vehicleAddOn == null)
            {
                return HttpNotFound();
            }
            return View(vehicleAddOn);
        }

        // POST: VehicleAddOns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddOnID,Manufacturer,Description,Price,ForVehicleType,QuantityAvail")] VehicleAddOn vehicleAddOn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleAddOn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleAddOn);
        }

        // GET: VehicleAddOns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleAddOn vehicleAddOn = db.VehicleAddOns.Find(id);
            if (vehicleAddOn == null)
            {
                return HttpNotFound();
            }
            return View(vehicleAddOn);
        }

        // POST: VehicleAddOns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleAddOn vehicleAddOn = db.VehicleAddOns.Find(id);
            db.VehicleAddOns.Remove(vehicleAddOn);
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
