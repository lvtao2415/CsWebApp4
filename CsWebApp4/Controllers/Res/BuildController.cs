using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CsWebApp4.Models;

namespace CsWebApp4.Controllers.Res
{
    public class BuildController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/Build
        public IQueryable<Project_Build> GetProject_Build()
        {
            return db.Project_Build;
        }

        // GET: api/Build/5
        [ResponseType(typeof(Project_Build))]
        public IHttpActionResult GetProject_Build(long id)
        {
            Project_Build project_Build = db.Project_Build.Find(id);
            if (project_Build == null)
            {
                return NotFound();
            }

            return Ok(project_Build);
        }

        // PUT: api/Build/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject_Build(long id, Project_Build project_Build)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_Build.ID)
            {
                return BadRequest();
            }

            db.Entry(project_Build).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Project_BuildExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Build
        [ResponseType(typeof(Project_Build))]
        public IHttpActionResult PostProject_Build(Project_Build project_Build)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Project_Build.Add(project_Build);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_Build.ID }, project_Build);
        }

        // DELETE: api/Build/5
        [ResponseType(typeof(Project_Build))]
        public IHttpActionResult DeleteProject_Build(long id)
        {
            Project_Build project_Build = db.Project_Build.Find(id);
            if (project_Build == null)
            {
                return NotFound();
            }

            db.Project_Build.Remove(project_Build);
            db.SaveChanges();

            return Ok(project_Build);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Project_BuildExists(long id)
        {
            return db.Project_Build.Count(e => e.ID == id) > 0;
        }
    }
}