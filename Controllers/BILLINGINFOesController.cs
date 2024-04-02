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
    public class BILLINGINFOesController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: BILLINGINFOes
        public ActionResult Index()
        {
            var bILLINGINFO = db.BILLINGINFO.Include(b => b.USERS);
            return View(bILLINGINFO.ToList());
        }

        // GET: BILLINGINFOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILLINGINFO bILLINGINFO = db.BILLINGINFO.Find(id);
            if (bILLINGINFO == null)
            {
                return HttpNotFound();
            }
            return View(bILLINGINFO);
        }

        // GET: BILLINGINFOes/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: BILLINGINFOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Address,PaymentInfo")] BILLINGINFO bILLINGINFO)
        {
            if (ModelState.IsValid)
            {
                db.BILLINGINFO.Add(bILLINGINFO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", bILLINGINFO.UserID);
            return View(bILLINGINFO);
        }

        // GET: BILLINGINFOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILLINGINFO bILLINGINFO = db.BILLINGINFO.Find(id);
            if (bILLINGINFO == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", bILLINGINFO.UserID);
            return View(bILLINGINFO);
        }

        // POST: BILLINGINFOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Address,PaymentInfo")] BILLINGINFO bILLINGINFO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bILLINGINFO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", bILLINGINFO.UserID);
            return View(bILLINGINFO);
        }

        // GET: BILLINGINFOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BILLINGINFO bILLINGINFO = db.BILLINGINFO.Find(id);
            if (bILLINGINFO == null)
            {
                return HttpNotFound();
            }
            return View(bILLINGINFO);
        }

        // POST: BILLINGINFOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BILLINGINFO bILLINGINFO = db.BILLINGINFO.Find(id);
            db.BILLINGINFO.Remove(bILLINGINFO);
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
