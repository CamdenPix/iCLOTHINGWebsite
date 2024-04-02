using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iCLOTHINGWebsite.Models;

namespace iCLOTHINGWebsite.Controllers
{
    public class ORDERSController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: ORDERS
        public ActionResult Index()
        {
            var oRDERS = db.ORDERS.Include(o => o.USERS);
            return View(oRDERS.ToList());
        }

        // GET: ORDERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERS oRDERS = db.ORDERS.Find(id);
            if (oRDERS == null)
            {
                return HttpNotFound();
            }
            return View(oRDERS);
        }

        // GET: ORDERS/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: ORDERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,StatusDate,Status")] ORDERS oRDERS)
        {
            if (ModelState.IsValid)
            {
                db.ORDERS.Add(oRDERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", oRDERS.UserID);
            return View(oRDERS);
        }

        // GET: ORDERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERS oRDERS = db.ORDERS.Find(id);
            if (oRDERS == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", oRDERS.UserID);
            return View(oRDERS);
        }

        // POST: ORDERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,StatusDate,Status")] ORDERS oRDERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", oRDERS.UserID);
            return View(oRDERS);
        }

        // GET: ORDERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDERS oRDERS = db.ORDERS.Find(id);
            if (oRDERS == null)
            {
                return HttpNotFound();
            }
            return View(oRDERS);
        }

        // POST: ORDERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDERS oRDERS = db.ORDERS.Find(id);
            db.ORDERS.Remove(oRDERS);
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
