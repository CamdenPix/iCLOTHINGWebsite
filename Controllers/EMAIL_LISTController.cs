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
    public class EMAIL_LISTController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: EMAIL_LIST
        public ActionResult Index()
        {
            var eMAIL_LIST = db.EMAIL_LIST.Include(e => e.EMAIL).Include(e => e.USERS);
            return View(eMAIL_LIST.ToList());
        }

        // GET: EMAIL_LIST/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL_LIST eMAIL_LIST = db.EMAIL_LIST.Find(id);
            if (eMAIL_LIST == null)
            {
                return HttpNotFound();
            }
            return View(eMAIL_LIST);
        }

        // GET: EMAIL_LIST/Create
        public ActionResult Create()
        {
            ViewBag.EmailID = new SelectList(db.EMAIL, "ID", "Date");
            ViewBag.Recepient = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: EMAIL_LIST/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmailID,Recepient")] EMAIL_LIST eMAIL_LIST)
        {
            if (ModelState.IsValid)
            {
                db.EMAIL_LIST.Add(eMAIL_LIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmailID = new SelectList(db.EMAIL, "ID", "Date", eMAIL_LIST.EmailID);
            ViewBag.Recepient = new SelectList(db.USERS, "ID", "Username", eMAIL_LIST.Recepient);
            return View(eMAIL_LIST);
        }

        // GET: EMAIL_LIST/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL_LIST eMAIL_LIST = db.EMAIL_LIST.Find(id);
            if (eMAIL_LIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmailID = new SelectList(db.EMAIL, "ID", "Date", eMAIL_LIST.EmailID);
            ViewBag.Recepient = new SelectList(db.USERS, "ID", "Username", eMAIL_LIST.Recepient);
            return View(eMAIL_LIST);
        }

        // POST: EMAIL_LIST/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmailID,Recepient")] EMAIL_LIST eMAIL_LIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMAIL_LIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmailID = new SelectList(db.EMAIL, "ID", "Date", eMAIL_LIST.EmailID);
            ViewBag.Recepient = new SelectList(db.USERS, "ID", "Username", eMAIL_LIST.Recepient);
            return View(eMAIL_LIST);
        }

        // GET: EMAIL_LIST/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMAIL_LIST eMAIL_LIST = db.EMAIL_LIST.Find(id);
            if (eMAIL_LIST == null)
            {
                return HttpNotFound();
            }
            return View(eMAIL_LIST);
        }

        // POST: EMAIL_LIST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EMAIL_LIST eMAIL_LIST = db.EMAIL_LIST.Find(id);
            db.EMAIL_LIST.Remove(eMAIL_LIST);
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
