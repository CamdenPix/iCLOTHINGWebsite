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
    public class EMAILsController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: EMAILs
        public ActionResult Index()
        {
            var eMAIL = db.EMAIL.Include(e => e.ADMINS);
            return View(eMAIL.ToList());
        }

        // GET: EMAILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL eMAIL = db.EMAIL.Find(id);
            if (eMAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMAIL);
        }

        // GET: EMAILs/Create
        public ActionResult Create()
        {
            ViewBag.SentBy = new SelectList(db.ADMINS, "ID", "Name");
            return View();
        }

        // POST: EMAILs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Subject,Body,SentBy")] EMAIL eMAIL)
        {
            if (ModelState.IsValid)
            {
                db.EMAIL.Add(eMAIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SentBy = new SelectList(db.ADMINS, "ID", "Name", eMAIL.SentBy);
            return View(eMAIL);
        }

        // GET: EMAILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL eMAIL = db.EMAIL.Find(id);
            if (eMAIL == null)
            {
                return HttpNotFound();
            }
            ViewBag.SentBy = new SelectList(db.ADMINS, "ID", "Name", eMAIL.SentBy);
            return View(eMAIL);
        }

        // POST: EMAILs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Subject,Body,SentBy")] EMAIL eMAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SentBy = new SelectList(db.ADMINS, "ID", "Name", eMAIL.SentBy);
            return View(eMAIL);
        }

        // GET: EMAILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL eMAIL = db.EMAIL.Find(id);
            if (eMAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMAIL);
        }

        // POST: EMAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMAIL eMAIL = db.EMAIL.Find(id);
            db.EMAIL.Remove(eMAIL);
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
