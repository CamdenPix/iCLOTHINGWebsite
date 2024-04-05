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
    public class USERPASSWORDsController : Controller
    {
        private iCLOTHINGEntities db = new iCLOTHINGEntities();

        // GET: USERPASSWORDs
        public ActionResult Index()
        {
            var uSERPASSWORD = db.USERPASSWORD.Include(u => u.USERS);
            return View(uSERPASSWORD.ToList());
        }

        // GET: USERPASSWORDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            if (uSERPASSWORD == null)
            {
                return HttpNotFound();
            }
            return View(uSERPASSWORD);
        }

        // GET: USERPASSWORDs/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        // POST: USERPASSWORDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserId,Password,passwordExpiryTime,passwordExpiryDate")] USERPASSWORD uSERPASSWORD)
        {
            if (ModelState.IsValid)
            {
                db.USERPASSWORD.Add(uSERPASSWORD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", uSERPASSWORD.UserId);
            return View(uSERPASSWORD);
        }

        // GET: USERPASSWORDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            if (uSERPASSWORD == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", uSERPASSWORD.UserId);
            return View(uSERPASSWORD);
        }

        // POST: USERPASSWORDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserId,Password,passwordExpiryTime,passwordExpiryDate")] USERPASSWORD uSERPASSWORD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uSERPASSWORD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username", uSERPASSWORD.UserId);
            return View(uSERPASSWORD);
        }

        // GET: USERPASSWORDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            if (uSERPASSWORD == null)
            {
                return HttpNotFound();
            }
            return View(uSERPASSWORD);
        }

        // POST: USERPASSWORDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            USERPASSWORD uSERPASSWORD = db.USERPASSWORD.Find(id);
            db.USERPASSWORD.Remove(uSERPASSWORD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: USERPASSWORD/Login
        public ActionResult Login()
        {
            Console.WriteLine("To Login Page");
            ViewBag.UserId = new SelectList(db.USERS, "ID", "Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            Console.WriteLine("Login Authentication Started");
            if (Username == null || Password == null) 
            {
                Console.WriteLine(Username + ": " + Password);
                return View();
            }

            var user = db.USERS.FirstOrDefault(u => u.Username == Username);
            if (user == null)
            {
                Console.WriteLine("Invalid User");
                return View();
            }
            int userID = user.ID;
            var retrivedUser = db.USERPASSWORD.SingleOrDefault(u => u.UserId == userID && u.Password == Password);
            if (retrivedUser == null)
            {
                Console.WriteLine("Invalid Password");
                return View();
            }

            Session["user"] = userID;
            Session["username"] = Username;
            Console.WriteLine("Session Set");
            return RedirectToAction("Index", "Items");
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
