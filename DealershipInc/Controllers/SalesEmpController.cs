using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using DealershipInc.Models;
using Microsoft.Ajax.Utilities;

namespace DealershipInc.Controllers
{
    public class SalesEmpController : Controller
    {

        private DealershipDBEntities db = new DealershipDBEntities();
        

        // GET: SalesEmp
        public ActionResult Index()
        {
            ViewBag.Total = db.Vehicles.Sum(x => x.Price);
            var vehicles = db.Vehicles.Include(v => v.DealerBranch).Include(v => v.Manufacturer);
            return View(vehicles.ToList());
        }

        //GET: /SalesEmp/Cust
        public ActionResult Cust(string searchString)
        {
            var cust = from c in db.Customers
                select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                cust = cust.Where(c => c.CustomerID.ToString().Contains(searchString));
            }
            return View(cust.ToList());
        }

        //GET: /SalesEmp/Vehicles
        public ActionResult Vehicles(string searchString)
        {
            var vehicles = from v in db.Vehicles.Include(v => v.DealerBranch).Include(v => v.Manufacturer)
                           select v;
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.Type.ToString().Contains(searchString));
            }
            return View(vehicles.ToList());
        }

        //GET: /SalesEmp/ActiveCust
         public ActionResult ActiveCust()
         {
             var activeCustomer = from c in db.Customers
                 join csf in db.CarSalesForms on c.CustomerID equals csf.CustomerID
                                  where csf.CustomerID.Equals(c.CustomerID)
                                  select c;
             return View(activeCustomer);  
         }

        // GET: /SalesEmp/NewForm
        public ActionResult NewForm()
        {

            ViewBag.AddOnID = new SelectList(db.VehicleAddOns, "AddOnID", "AddOnID");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerID");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "EmployeeID");
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "VIN");
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "BranchID");
            return View();
        }

        // POST: CarSalesForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewForm([Bind(Include = "CarSaleFormID,CreateDate,AddOnID,CustomerID,EmployeeID,VIN,BranchID")] CarSalesForm carSalesForm)
        {
            if (ModelState.IsValid)
            {
                db.CarSalesForms.Add(carSalesForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddOnID = new SelectList(db.VehicleAddOns, "AddOnID", "Manufacturer", carSalesForm.AddOnID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "EMail", carSalesForm.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FullName", carSalesForm.EmployeeID);
            ViewBag.VIN = new SelectList(db.Vehicles, "VIN", "isNewFlag", carSalesForm.VIN);
            ViewBag.BranchID = new SelectList(db.DealerBranches, "BranchID", "Address", carSalesForm.BranchID);
            return View(carSalesForm);
        }

        // GET: VehicleAddOns
        public ActionResult AddOns()
        {
            return View(db.VehicleAddOns.ToList());
        }
    }
}
