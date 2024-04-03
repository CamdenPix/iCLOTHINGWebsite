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
    public class ADMINSController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: ADMINS
        public ActionResult Index()
        {
            var aDMINS = db.ADMINS.Include(a => a.USERS);
            return View(aDMINS.ToList());
        }

        // GET: ADMINS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINS aDMINS = db.ADMINS.Find(id);
            if (aDMINS == null)
            {
                return HttpNotFound();
            }
            return View(aDMINS);
        }

        // GET: ADMINS/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: ADMINS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,Name,Email,dateHired")] ADMINS aDMINS)
        {
            if (ModelState.IsValid)
            {
                db.ADMINS.Add(aDMINS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", aDMINS.UserID);
            return View(aDMINS);
        }

        // GET: ADMINS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINS aDMINS = db.ADMINS.Find(id);
            if (aDMINS == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", aDMINS.UserID);
            return View(aDMINS);
        }

        // POST: ADMINS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,Name,Email,dateHired")] ADMINS aDMINS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMINS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.USERS, "ID", "Username", aDMINS.UserID);
            return View(aDMINS);
        }

        // GET: ADMINS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMINS aDMINS = db.ADMINS.Find(id);
            if (aDMINS == null)
            {
                return HttpNotFound();
            }
            return View(aDMINS);
        }
        public ActionResult ControlPanel()
        {
            return View();
        }

        // POST: ADMINS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMINS aDMINS = db.ADMINS.Find(id);
            db.ADMINS.Remove(aDMINS);
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
