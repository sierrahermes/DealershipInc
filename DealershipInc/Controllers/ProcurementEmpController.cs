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
    public class ProcurementEmpController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();
        
        // GET: ProcurementEmp
        public ActionResult Index()
        {
            return View();
        }

        //GET: ProcurementEmp/VehicleInv
        public ActionResult VehicleInv()
        {
            var vehicles = db.Vehicles.Include(v => v.DealerBranch).Include(v => v.Manufacturer);
            return View(vehicles.ToList());
        }

        //GET: ProcurementEmp/AddOnInv
        public ActionResult AddOnInv()
        {
            return View(db.VehicleAddOns.ToList());
        }
    }
}