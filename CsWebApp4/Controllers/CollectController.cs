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
    public class CollectController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: Collect
        public ActionResult Index()
        {
            var user_Collect = db.User_Collect.Include(u => u.Project_House).Include(u => u.System_User);
            return View(user_Collect.ToList());
        }

        // GET: Collect/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Collect user_Collect = db.User_Collect.Find(id);
            if (user_Collect == null)
            {
                return HttpNotFound();
            }
            return View(user_Collect);
        }

        // GET: Collect/Create
        public ActionResult Create()
        {
            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName");
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName");
            return View();
        }

        // POST: Collect/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HouseID,UserID,CollectDate,OrderID,Status")] User_Collect user_Collect)
        {
            if (ModelState.IsValid)
            {
                db.User_Collect.Add(user_Collect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName", user_Collect.HouseID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_Collect.UserID);
            return View(user_Collect);
        }

        // GET: Collect/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Collect user_Collect = db.User_Collect.Find(id);
            if (user_Collect == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName", user_Collect.HouseID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_Collect.UserID);
            return View(user_Collect);
        }

        // POST: Collect/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HouseID,UserID,CollectDate,OrderID,Status")] User_Collect user_Collect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Collect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName", user_Collect.HouseID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_Collect.UserID);
            return View(user_Collect);
        }

        // GET: Collect/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Collect user_Collect = db.User_Collect.Find(id);
            if (user_Collect == null)
            {
                return HttpNotFound();
            }
            return View(user_Collect);
        }

        // POST: Collect/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User_Collect user_Collect = db.User_Collect.Find(id);
            db.User_Collect.Remove(user_Collect);
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
