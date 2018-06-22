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
    public class FinanceEmpController : Controller
    {
        private DealershipDBEntities db = new DealershipDBEntities();

        // GET: FinanceEmp
        public ActionResult Index(String searchString)
        {
            return View();
        }

        // GET: FinanceEmp/Banks
        public ActionResult Banks(String searchString)
        {
            var banks = from b in db.PartnerBanks
                select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                banks = banks.Where(c => c.BankID.ToString().Contains(searchString));
            }
            return View(banks.ToList());
        }

        // GET: FinanceEmp/Contracts
        public ActionResult Contracts()
        {
            var saleContracts = db.SaleContracts.Include(s => s.CarSalesForm).Include(s => s.PartnerBank);
            return View(saleContracts.ToList());
        }
    }
}