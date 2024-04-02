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
    public class SUBCATEGORY_ITEMSController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: SUBCATEGORY_ITEMS
        public ActionResult Index()
        {
            var sUBCATEGORY_ITEMS = db.SUBCATEGORY_ITEMS.Include(s => s.ITEM).Include(s => s.SUBCATEGORY1);
            return View(sUBCATEGORY_ITEMS.ToList());
        }

        // GET: SUBCATEGORY_ITEMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY_ITEMS sUBCATEGORY_ITEMS = db.SUBCATEGORY_ITEMS.Find(id);
            if (sUBCATEGORY_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY_ITEMS);
        }

        // GET: SUBCATEGORY_ITEMS/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name");
            ViewBag.Subcategory = new SelectList(db.SUBCATEGORY, "ID", "Name");
            return View();
        }

        // POST: SUBCATEGORY_ITEMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,Subcategory,Description")] SUBCATEGORY_ITEMS sUBCATEGORY_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.SUBCATEGORY_ITEMS.Add(sUBCATEGORY_ITEMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", sUBCATEGORY_ITEMS.ItemID);
            ViewBag.Subcategory = new SelectList(db.SUBCATEGORY, "ID", "Name", sUBCATEGORY_ITEMS.Subcategory);
            return View(sUBCATEGORY_ITEMS);
        }

        // GET: SUBCATEGORY_ITEMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY_ITEMS sUBCATEGORY_ITEMS = db.SUBCATEGORY_ITEMS.Find(id);
            if (sUBCATEGORY_ITEMS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", sUBCATEGORY_ITEMS.ItemID);
            ViewBag.Subcategory = new SelectList(db.SUBCATEGORY, "ID", "Name", sUBCATEGORY_ITEMS.Subcategory);
            return View(sUBCATEGORY_ITEMS);
        }

        // POST: SUBCATEGORY_ITEMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemID,Subcategory,Description")] SUBCATEGORY_ITEMS sUBCATEGORY_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBCATEGORY_ITEMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", sUBCATEGORY_ITEMS.ItemID);
            ViewBag.Subcategory = new SelectList(db.SUBCATEGORY, "ID", "Name", sUBCATEGORY_ITEMS.Subcategory);
            return View(sUBCATEGORY_ITEMS);
        }

        // GET: SUBCATEGORY_ITEMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBCATEGORY_ITEMS sUBCATEGORY_ITEMS = db.SUBCATEGORY_ITEMS.Find(id);
            if (sUBCATEGORY_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(sUBCATEGORY_ITEMS);
        }

        // POST: SUBCATEGORY_ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUBCATEGORY_ITEMS sUBCATEGORY_ITEMS = db.SUBCATEGORY_ITEMS.Find(id);
            db.SUBCATEGORY_ITEMS.Remove(sUBCATEGORY_ITEMS);
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
