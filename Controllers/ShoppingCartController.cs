using iCLOTHINGWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCLOTHINGWebsite.Controllers
{
    public class ShoppingCartController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: ShoppingCart
        public ActionResult Index()
        {
            var data = db.SHOPPINGCART.Include("ITEM").Include("USERS");
            return View(data.ToList());
        }
    }
}