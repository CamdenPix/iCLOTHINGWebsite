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
    public class FEEDBACKsController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: FEEDBACKs
        public ActionResult Index()
        {
            var fEEDBACK = db.FEEDBACK.Include(f => f.USERS);
            return View(fEEDBACK.ToList());
        }

        // GET: FEEDBACKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEEDBACK fEEDBACK = db.FEEDBACK.Find(id);
            if (fEEDBACK == null)
            {
                return HttpNotFound();
            }
            return View(fEEDBACK);
        }

        // GET: FEEDBACKs/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: FEEDBACKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Feedback1,Date")] FEEDBACK fEEDBACK)
        {
            if (ModelState.IsValid)
            {
                db.FEEDBACK.Add(fEEDBACK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", fEEDBACK.UserId);
            return View(fEEDBACK);
        }

        // GET: FEEDBACKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEEDBACK fEEDBACK = db.FEEDBACK.Find(id);
            if (fEEDBACK == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", fEEDBACK.UserId);
            return View(fEEDBACK);
        }

        // POST: FEEDBACKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Feedback1,Date")] FEEDBACK fEEDBACK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fEEDBACK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", fEEDBACK.UserId);
            return View(fEEDBACK);
        }

        // GET: FEEDBACKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FEEDBACK fEEDBACK = db.FEEDBACK.Find(id);
            if (fEEDBACK == null)
            {
                return HttpNotFound();
            }
            return View(fEEDBACK);
        }

        // POST: FEEDBACKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FEEDBACK fEEDBACK = db.FEEDBACK.Find(id);
            db.FEEDBACK.Remove(fEEDBACK);
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
