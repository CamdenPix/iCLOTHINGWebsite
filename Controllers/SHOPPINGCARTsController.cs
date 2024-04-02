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
    public class SHOPPINGCARTsController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: SHOPPINGCARTs
        public ActionResult Index()
        {
            var sHOPPINGCART = db.SHOPPINGCART.Include(s => s.ITEM).Include(s => s.USERS);
            return View(sHOPPINGCART.ToList());
        }

        // GET: SHOPPINGCARTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPPINGCART);
        }

        // GET: SHOPPINGCARTs/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name");
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: SHOPPINGCARTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ItemID,Quantity")] SHOPPINGCART sHOPPINGCART)
        {
            if (ModelState.IsValid)
            {
                db.SHOPPINGCART.Add(sHOPPINGCART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", sHOPPINGCART.ItemID);
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", sHOPPINGCART.UserID);
            return View(sHOPPINGCART);
        }

        // GET: SHOPPINGCARTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", sHOPPINGCART.ItemID);
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", sHOPPINGCART.UserID);
            return View(sHOPPINGCART);
        }

        // POST: SHOPPINGCARTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,ItemID,Quantity")] SHOPPINGCART sHOPPINGCART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOPPINGCART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", sHOPPINGCART.ItemID);
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", sHOPPINGCART.UserID);
            return View(sHOPPINGCART);
        }

        // GET: SHOPPINGCARTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            if (sHOPPINGCART == null)
            {
                return HttpNotFound();
            }
            return View(sHOPPINGCART);
        }

        // POST: SHOPPINGCARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOPPINGCART sHOPPINGCART = db.SHOPPINGCART.Find(id);
            db.SHOPPINGCART.Remove(sHOPPINGCART);
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
