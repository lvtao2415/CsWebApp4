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
    public class HouseController : Controller
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: House
        public ActionResult Index()
        {
            var project_House = db.Project_House.Include(p => p.Project_Build);
            return View(project_House.ToList());
        }

        // GET: House/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_House project_House = db.Project_House.Find(id);
            if (project_House == null)
            {
                return HttpNotFound();
            }
            return View(project_House);
        }

        // GET: House/Create
        public ActionResult Create()
        {
            ViewBag.BuildID = new SelectList(db.Project_Build, "ID", "BuildName");
            return View();
        }

        // POST: House/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BuildID,UnitName,UnitShort,FloorName,FloorShort,HouseName,HouseShort,HouseStatus,HouseIntro,HouseModel,HouseType,HouseClass,HouseCategory,HouseArea,HousePrice,HouseTotal,Remark,OrderID,Status")] Project_House project_House)
        {
            if (ModelState.IsValid)
            {
                db.Project_House.Add(project_House);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BuildID = new SelectList(db.Project_Build, "ID", "BuildName", project_House.BuildID);
            return View(project_House);
        }

        // GET: House/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_House project_House = db.Project_House.Find(id);
            if (project_House == null)
            {
                return HttpNotFound();
            }
            ViewBag.BuildID = new SelectList(db.Project_Build, "ID", "BuildName", project_House.BuildID);
            return View(project_House);
        }

        // POST: House/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BuildID,UnitName,UnitShort,FloorName,FloorShort,HouseName,HouseShort,HouseStatus,HouseIntro,HouseModel,HouseType,HouseClass,HouseCategory,HouseArea,HousePrice,HouseTotal,Remark,OrderID,Status")] Project_House project_House)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project_House).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuildID = new SelectList(db.Project_Build, "ID", "BuildName", project_House.BuildID);
            return View(project_House);
        }

        // GET: House/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project_House project_House = db.Project_House.Find(id);
            if (project_House == null)
            {
                return HttpNotFound();
            }
            return View(project_House);
        }

        // POST: House/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Project_House project_House = db.Project_House.Find(id);
            db.Project_House.Remove(project_House);
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
