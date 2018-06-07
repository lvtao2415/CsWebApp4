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
    public class NotaryNoController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: NotaryNo
        public ActionResult Index()
        {
            var user_NotaryNo = db.User_NotaryNo.Include(u => u.System_Project).Include(u => u.System_User);
            return View(user_NotaryNo.ToList());
        }

        // GET: NotaryNo/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_NotaryNo user_NotaryNo = db.User_NotaryNo.Find(id);
            if (user_NotaryNo == null)
            {
                return HttpNotFound();
            }
            return View(user_NotaryNo);
        }

        // GET: NotaryNo/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName");
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName");
            return View();
        }

        // POST: NotaryNo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,UserID,NotaryNo,SignNo,NotaryDate,OrderID,Status")] User_NotaryNo user_NotaryNo)
        {
            if (ModelState.IsValid)
            {
                db.User_NotaryNo.Add(user_NotaryNo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName", user_NotaryNo.ProjectID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_NotaryNo.UserID);
            return View(user_NotaryNo);
        }

        // GET: NotaryNo/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_NotaryNo user_NotaryNo = db.User_NotaryNo.Find(id);
            if (user_NotaryNo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName", user_NotaryNo.ProjectID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_NotaryNo.UserID);
            return View(user_NotaryNo);
        }

        // POST: NotaryNo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,UserID,NotaryNo,SignNo,NotaryDate,OrderID,Status")] User_NotaryNo user_NotaryNo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_NotaryNo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName", user_NotaryNo.ProjectID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_NotaryNo.UserID);
            return View(user_NotaryNo);
        }

        // GET: NotaryNo/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_NotaryNo user_NotaryNo = db.User_NotaryNo.Find(id);
            if (user_NotaryNo == null)
            {
                return HttpNotFound();
            }
            return View(user_NotaryNo);
        }

        // POST: NotaryNo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User_NotaryNo user_NotaryNo = db.User_NotaryNo.Find(id);
            db.User_NotaryNo.Remove(user_NotaryNo);
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
