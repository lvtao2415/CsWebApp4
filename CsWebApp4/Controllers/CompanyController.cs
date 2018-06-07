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
    public class CompanyController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.System_Company.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Company system_Company = db.System_Company.Find(id);
            if (system_Company == null)
            {
                return HttpNotFound();
            }
            return View(system_Company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,CompanyShort,CompanyAddress,CompanyPhone,CompanyImg,CompanyKey,UrlAPI,NeedBindMobile,NeedBindCard,OrderID,Status")] System_Company system_Company)
        {
            if (ModelState.IsValid)
            {
                db.System_Company.Add(system_Company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(system_Company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Company system_Company = db.System_Company.Find(id);
            if (system_Company == null)
            {
                return HttpNotFound();
            }
            return View(system_Company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,CompanyShort,CompanyAddress,CompanyPhone,CompanyImg,CompanyKey,UrlAPI,NeedBindMobile,NeedBindCard,OrderID,Status")] System_Company system_Company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(system_Company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(system_Company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Company system_Company = db.System_Company.Find(id);
            if (system_Company == null)
            {
                return HttpNotFound();
            }
            return View(system_Company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            System_Company system_Company = db.System_Company.Find(id);
            db.System_Company.Remove(system_Company);
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
