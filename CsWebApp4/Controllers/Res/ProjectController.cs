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
    public class ProjectController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/Project
        public IQueryable<System_Project> GetSystem_Project()
        {
            return db.System_Project;
        }

        // GET: api/Project/5
        [ResponseType(typeof(System_Project))]
        public IHttpActionResult GetSystem_Project(long id)
        {
            System_Project system_Project = db.System_Project.Find(id);
            if (system_Project == null)
            {
                return NotFound();
            }

            return Ok(system_Project);
        }

        // PUT: api/Project/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSystem_Project(long id, System_Project system_Project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != system_Project.ID)
            {
                return BadRequest();
            }

            db.Entry(system_Project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!System_ProjectExists(id))
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

        // POST: api/Project
        [ResponseType(typeof(System_Project))]
        public IHttpActionResult PostSystem_Project(System_Project system_Project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.System_Project.Add(system_Project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = system_Project.ID }, system_Project);
        }

        // DELETE: api/Project/5
        [ResponseType(typeof(System_Project))]
        public IHttpActionResult DeleteSystem_Project(long id)
        {
            System_Project system_Project = db.System_Project.Find(id);
            if (system_Project == null)
            {
                return NotFound();
            }

            db.System_Project.Remove(system_Project);
            db.SaveChanges();

            return Ok(system_Project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool System_ProjectExists(long id)
        {
            return db.System_Project.Count(e => e.ID == id) > 0;
        }
    }
}