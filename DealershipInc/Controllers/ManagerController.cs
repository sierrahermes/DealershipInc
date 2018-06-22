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
    public class ManagerController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: Manager
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department);
            return View(employees.ToList());
        }
    }
}