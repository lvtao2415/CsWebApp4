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
    public class BuildController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: Build
        public ActionResult Index()
        {
            var project_Build = db.Project_Build.Include(p => p.System_Project);
            return View(project_Build.ToList());
        }

        // GET: Build/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Build project_Build = db.Project_Build.Find(id);
            if (project_Build == null)
            {
                return HttpNotFound();
            }
            return View(project_Build);
        }

        // GET: Build/Create
        public ActionResult Create()
        {
            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName");
            return View();
        }

        // POST: Build/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProjectID,BuildName,BuildShort,Remark,OrderID,Status")] Project_Build project_Build)
        {
            if (ModelState.IsValid)
            {
                db.Project_Build.Add(project_Build);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName", project_Build.ProjectID);
            return View(project_Build);
        }

        // GET: Build/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Build project_Build = db.Project_Build.Find(id);
            if (project_Build == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName", project_Build.ProjectID);
            return View(project_Build);
        }

        // POST: Build/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProjectID,BuildName,BuildShort,Remark,OrderID,Status")] Project_Build project_Build)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_Build).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectID = new SelectList(db.System_Project, "ID", "ProjectName", project_Build.ProjectID);
            return View(project_Build);
        }

        // GET: Build/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_Build project_Build = db.Project_Build.Find(id);
            if (project_Build == null)
            {
                return HttpNotFound();
            }
            return View(project_Build);
        }

        // POST: Build/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Project_Build project_Build = db.Project_Build.Find(id);
            db.Project_Build.Remove(project_Build);
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
