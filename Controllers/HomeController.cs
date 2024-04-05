using iCLOTHINGWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCLOTHINGWebsite.Controllers
{
    public class HomeController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();
        public ActionResult Index()
        {
            var Admin = new IsAdmin(false);
            if (Session["user"] == null)
            {
                return View(Admin);
            }
            var aDMINS = db.ADMINS.SqlQuery("SELECT * FROM ADMINS WHERE UserID = " + Session["user"]);
            if (aDMINS.Count() == 0)
            {
                return View(Admin);
            }
            Admin.state = true;
            return View(Admin);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}