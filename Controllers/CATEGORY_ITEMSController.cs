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
    public class CATEGORY_ITEMSController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: CATEGORY_ITEMS
        public ActionResult Index()
        {
            var cATEGORY_ITEMS = db.CATEGORY_ITEMS.Include(c => c.CATEGORY1).Include(c => c.ITEM);
            return View(cATEGORY_ITEMS.ToList());
        }

        // GET: CATEGORY_ITEMS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY_ITEMS cATEGORY_ITEMS = db.CATEGORY_ITEMS.Find(id);
            if (cATEGORY_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY_ITEMS);
        }

        // GET: CATEGORY_ITEMS/Create
        public ActionResult Create()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var admin = db.ADMINS.SqlQuery("SELECT * FROM ADMINS WHERE UserID = " + Session["user"]);
            if (admin.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name");
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name");
            return View();
        }

        // POST: CATEGORY_ITEMS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,Category,Description")] CATEGORY_ITEMS cATEGORY_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORY_ITEMS.Add(cATEGORY_ITEMS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name", cATEGORY_ITEMS.Category);
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", cATEGORY_ITEMS.ItemID);
            return View(cATEGORY_ITEMS);
        }

        // GET: CATEGORY_ITEMS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var admin = db.ADMINS.SqlQuery("SELECT * FROM ADMINS WHERE UserID = " + Session["user"]);
            if (admin.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY_ITEMS cATEGORY_ITEMS = db.CATEGORY_ITEMS.Find(id);
            if (cATEGORY_ITEMS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name", cATEGORY_ITEMS.Category);
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", cATEGORY_ITEMS.ItemID);
            return View(cATEGORY_ITEMS);
        }

        // POST: CATEGORY_ITEMS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemID,Category,Description")] CATEGORY_ITEMS cATEGORY_ITEMS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORY_ITEMS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.CATEGORY, "ID", "Name", cATEGORY_ITEMS.Category);
            ViewBag.ItemID = new SelectList(db.ITEM, "ID", "Name", cATEGORY_ITEMS.ItemID);
            return View(cATEGORY_ITEMS);
        }

        // GET: CATEGORY_ITEMS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var admin = db.ADMINS.SqlQuery("SELECT * FROM ADMINS WHERE UserID = " + Session["user"]);
            if (admin.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY_ITEMS cATEGORY_ITEMS = db.CATEGORY_ITEMS.Find(id);
            if (cATEGORY_ITEMS == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY_ITEMS);
        }

        // POST: CATEGORY_ITEMS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CATEGORY_ITEMS cATEGORY_ITEMS = db.CATEGORY_ITEMS.Find(id);
            db.CATEGORY_ITEMS.Remove(cATEGORY_ITEMS);
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
