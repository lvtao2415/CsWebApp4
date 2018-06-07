using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CsWebApp4.Models;

namespace CsWebApp4.Controllers
{
    public class UserController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: User
        public ActionResult Index()
        {
            var system_User = db.System_User.Include(s => s.System_Company);
            return View(system_User.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_User system_User = db.System_User.Find(id);
            if (system_User == null)
            {
                return HttpNotFound();
            }
            return View(system_User);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,UserName,UserShort,UserSex,UserAddress,UserAccont,UserPasswd,IsBindMobile,UserMobile,IsBindCard,UserCard,WxOpenId,WxUnionid,UserGrade,LoginDate,OrderID,Status")] System_User system_User)
        {
            if (ModelState.IsValid)
            {
                db.System_User.Add(system_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName", system_User.CompanyID);
            return View(system_User);
        }

        // GET: User/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_User system_User = db.System_User.Find(id);
            if (system_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName", system_User.CompanyID);
            return View(system_User);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,UserName,UserShort,UserSex,UserAddress,UserAccont,UserPasswd,IsBindMobile,UserMobile,IsBindCard,UserCard,WxOpenId,WxUnionid,UserGrade,LoginDate,OrderID,Status")] System_User system_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(system_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName", system_User.CompanyID);
            return View(system_User);
        }

        // GET: User/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_User system_User = db.System_User.Find(id);
            if (system_User == null)
            {
                return HttpNotFound();
            }
            return View(system_User);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            System_User system_User = db.System_User.Find(id);
            db.System_User.Remove(system_User);
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
