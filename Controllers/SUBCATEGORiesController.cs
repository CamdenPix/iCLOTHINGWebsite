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
    public class SUBCATEGORiesController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: SUBCATEGORies
        public ActionResult Index()
        {
            var sUBCATEGORY = db.SUBCATEGORY.Include(s => s.CATEGORY1);
            return View(sUBCATEGORY.ToList());
        }

        // GET: SUBCATEGORies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORY.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name");
            return View();
        }

        // POST: SUBCATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Category")] SUBCATEGORY sUBCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.SUBCATEGORY.Add(sUBCATEGORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name", sUBCATEGORY.Category);
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORY.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name", sUBCATEGORY.Category);
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Category")] SUBCATEGORY sUBCATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBCATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name", sUBCATEGORY.Category);
            return View(sUBCATEGORY);
        }

        // GET: SUBCATEGORies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORY.Find(id);
            if (sUBCATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY);
        }

        // POST: SUBCATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUBCATEGORY sUBCATEGORY = db.SUBCATEGORY.Find(id);
            db.SUBCATEGORY.Remove(sUBCATEGORY);
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
