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
    public class CartController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: Cart
        public ActionResult Index()
        {
            var user_Cart = db.User_Cart.Include(u => u.Project_House).Include(u => u.System_User);
            return View(user_Cart.ToList());
        }

        // GET: Cart/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Cart user_Cart = db.User_Cart.Find(id);
            if (user_Cart == null)
            {
                return HttpNotFound();
            }
            return View(user_Cart);
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName");
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,HouseID,UserID,CartDate,CartStatus,OrderID,Status")] User_Cart user_Cart)
        {
            if (ModelState.IsValid)
            {
                db.User_Cart.Add(user_Cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName", user_Cart.HouseID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_Cart.UserID);
            return View(user_Cart);
        }

        // GET: Cart/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Cart user_Cart = db.User_Cart.Find(id);
            if (user_Cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName", user_Cart.HouseID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_Cart.UserID);
            return View(user_Cart);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,HouseID,UserID,CartDate,CartStatus,OrderID,Status")] User_Cart user_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseID = new SelectList(db.Project_House, "ID", "UnitName", user_Cart.HouseID);
            ViewBag.UserID = new SelectList(db.System_User, "ID", "UserName", user_Cart.UserID);
            return View(user_Cart);
        }

        // GET: Cart/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Cart user_Cart = db.User_Cart.Find(id);
            if (user_Cart == null)
            {
                return HttpNotFound();
            }
            return View(user_Cart);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User_Cart user_Cart = db.User_Cart.Find(id);
            db.User_Cart.Remove(user_Cart);
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
