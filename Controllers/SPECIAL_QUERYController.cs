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
    public class SPECIAL_QUERYController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: SPECIAL_QUERY
        public ActionResult Index()
        {
            var sPECIAL_QUERY = db.SPECIAL_QUERY.Include(s => s.USERS);
            return View(sPECIAL_QUERY.ToList());
        }

        // GET: SPECIAL_QUERY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECIAL_QUERY sPECIAL_QUERY = db.SPECIAL_QUERY.Find(id);
            if (sPECIAL_QUERY == null)
            {
                return HttpNotFound();
            }
            return View(sPECIAL_QUERY);
        }

        // GET: SPECIAL_QUERY/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: SPECIAL_QUERY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Query,Date")] SPECIAL_QUERY sPECIAL_QUERY)
        {
            if (ModelState.IsValid)
            {
                db.SPECIAL_QUERY.Add(sPECIAL_QUERY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", sPECIAL_QUERY.UserId);
            return View(sPECIAL_QUERY);
        }

        // GET: SPECIAL_QUERY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECIAL_QUERY sPECIAL_QUERY = db.SPECIAL_QUERY.Find(id);
            if (sPECIAL_QUERY == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", sPECIAL_QUERY.UserId);
            return View(sPECIAL_QUERY);
        }

        // POST: SPECIAL_QUERY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Query,Date")] SPECIAL_QUERY sPECIAL_QUERY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPECIAL_QUERY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", sPECIAL_QUERY.UserId);
            return View(sPECIAL_QUERY);
        }

        // GET: SPECIAL_QUERY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPECIAL_QUERY sPECIAL_QUERY = db.SPECIAL_QUERY.Find(id);
            if (sPECIAL_QUERY == null)
            {
                return HttpNotFound();
            }
            return View(sPECIAL_QUERY);
        }

        // POST: SPECIAL_QUERY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SPECIAL_QUERY sPECIAL_QUERY = db.SPECIAL_QUERY.Find(id);
            db.SPECIAL_QUERY.Remove(sPECIAL_QUERY);
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
