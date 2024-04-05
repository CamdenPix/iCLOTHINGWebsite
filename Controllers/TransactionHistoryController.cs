using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iCLOTHINGWebsite.Models;

namespace iCLOTHINGWebsite.Controllers
{
    public class TransactionHistoryController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: TransactionHistory
        public ActionResult Index()
        {
            var data = db.ORDERS.Include("USERS");
            return View(data.ToList());
        }
    }
}