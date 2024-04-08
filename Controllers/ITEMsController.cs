using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.UI.WebControls.Expressions;
using iCLOTHINGWebsite.Models;
using Microsoft.Win32;

namespace iCLOTHINGWebsite.Controllers
{
    public class ITEMsController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: ITEMs
        public ActionResult Index(string SearchBy, string search)
        {
            var iTEM = db.ITEM.Include(i => i.BRAND1).Include(i => i.DEPARTMENT1);
            if (String.IsNullOrEmpty(search))
            {
                return View(iTEM);
            }
            else if (SearchBy == "Brand")
            {

                string input = "'" + search + "'";
                string query = "SELECT I.* FROM ITEM AS I, BRAND AS B WHERE B.ID = I.Brand AND B.Brand = " + input;
                var list = db.ITEM.SqlQuery(query).ToList();
                return View(list);
            }
            else
            {
                string input = "'" + search + "'";
                string query = "SELECT * FROM ITEM WHERE Name = " + input;
                var list = db.ITEM.SqlQuery(query).ToList();
                return View(list);
            }
        
        }

        // GET: ITEMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // GET: ITEMs/Create
        public ActionResult Create()
        {
            ViewBag.Brand = new SelectList(db.BRAND, "ID", "Brand1");
            ViewBag.Department = new SelectList(db.DEPARTMENT, "ID", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Brand,Department,Price,Size,Description,Quantity")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.ITEM.Add(iTEM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand = new SelectList(db.BRAND, "ID", "Brand1", iTEM.Brand);
            ViewBag.Department = new SelectList(db.DEPARTMENT, "ID", "Name", iTEM.Department);
            return View(iTEM);
        }


        public ActionResult Add(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index");
            }
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            int userID = (int)Session["user"];

            Random rnd = new Random();
            SHOPPINGCART addedCart = new SHOPPINGCART();
            addedCart.ID = rnd.Next(100);
            addedCart.ItemID = iTEM.ID;
            addedCart.UserID = userID;
            addedCart.Quantity = 1;

            if (ModelState.IsValid)
            {
                db.SHOPPINGCART.Add(addedCart);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");


        }


        // GET: ITEMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand = new SelectList(db.BRAND, "ID", "Brand1", iTEM.Brand);
            ViewBag.Department = new SelectList(db.DEPARTMENT, "ID", "Name", iTEM.Department);
            return View(iTEM);
        }

        // POST: ITEMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Brand,Department,Price,Size,Description,Quantity")] ITEM iTEM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iTEM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand = new SelectList(db.BRAND, "ID", "Brand1", iTEM.Brand);
            ViewBag.Department = new SelectList(db.DEPARTMENT, "ID", "Name", iTEM.Department);
            return View(iTEM);
        }

        // GET: ITEMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ITEM iTEM = db.ITEM.Find(id);
            if (iTEM == null)
            {
                return HttpNotFound();
            }
            return View(iTEM);
        }

        // POST: ITEMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ITEM iTEM = db.ITEM.Find(id);
            db.ITEM.Remove(iTEM);
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
