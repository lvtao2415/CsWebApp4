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
    public class ProjectController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: Project
        public ActionResult Index()
        {
            var system_Project = db.System_Project.Include(s => s.System_Company);
            return View(system_Project.ToList());
        }

        // GET: Project/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Project system_Project = db.System_Project.Find(id);
            if (system_Project == null)
            {
                return HttpNotFound();
            }
            return View(system_Project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName");
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,ProjectName,ProjectShort,ProjectAddress,ProjectAgreement,ProjectNotes,ProjectStatus,StartDate,EndDate,OrderID,Status")] System_Project system_Project)
        {
            if (ModelState.IsValid)
            {
                db.System_Project.Add(system_Project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName", system_Project.CompanyID);
            return View(system_Project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Project system_Project = db.System_Project.Find(id);
            if (system_Project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName", system_Project.CompanyID);
            return View(system_Project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,ProjectName,ProjectShort,ProjectAddress,ProjectAgreement,ProjectNotes,ProjectStatus,StartDate,EndDate,OrderID,Status")] System_Project system_Project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(system_Project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.System_Company, "ID", "CompanyName", system_Project.CompanyID);
            return View(system_Project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Project system_Project = db.System_Project.Find(id);
            if (system_Project == null)
            {
                return HttpNotFound();
            }
            return View(system_Project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            System_Project system_Project = db.System_Project.Find(id);
            db.System_Project.Remove(system_Project);
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
