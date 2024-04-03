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
    public class USERSController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: USERS
        public ActionResult Index()
        {
            return View(db.USERS.ToList());
        }

        // GET: USERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            return View(uSERS);
        }

        // GET: USERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: USERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(USERS uSERS, string Password, string ConfirmPassword)
        {
            if (!Password.Equals(ConfirmPassword) || Password.Length < 8) 
            {
                return View(uSERS);
            }
            uSERS.ID = GenUniqueID();
            if (ModelState.IsValid)
            {
                db.USERS.Add(uSERS);
                USERPASSWORD uSERPASSWORD = new USERPASSWORD();
                uSERPASSWORD.ID = GenUniqueIDPassword();
                uSERPASSWORD.UserId = uSERS.ID;
                uSERPASSWORD.Password = Password;
                uSERPASSWORD.passwordExpiryTime = (int)DateTime.Now.TimeOfDay.TotalSeconds;
                uSERPASSWORD.passwordExpiryDate = DateTime.Now.AddYears(1).ToShortDateString();
                db.USERPASSWORD.Add(uSERPASSWORD);
                db.SaveChanges();
                return RedirectToAction("Login", "USERPASSWORDs");
            }

            return View(uSERS);
        }
        //For security purposes, this should be changed to more random numbers
        private int GenUniqueID()
        {
            return db.USERS.Max(f => (int?)f.ID) + 1 ?? 0;
        }
        private int GenUniqueIDPassword()
        {
            return db.USERPASSWORD.Max(f => (int?)f.ID) + 1 ?? 0;
        }
        // GET: USERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            return View(uSERS);
        }

        // POST: USERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,ShippingAddress,BillingAddress,DOB,Gender")] USERS uSERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uSERS);
        }

        // GET: USERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERS uSERS = db.USERS.Find(id);
            if (uSERS == null)
            {
                return HttpNotFound();
            }
            return View(uSERS);
        }

        // POST: USERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERS uSERS = db.USERS.Find(id);
            db.USERS.Remove(uSERS);
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
