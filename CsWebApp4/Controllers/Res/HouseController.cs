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
    public class HouseController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/House
        public IQueryable<Project_House> GetProject_House()
        {
            return db.Project_House;
        }

        // GET: api/House/5
        [ResponseType(typeof(Project_House))]
        public IHttpActionResult GetProject_House(long id)
        {
            Project_House project_House = db.Project_House.Find(id);
            if (project_House == null)
            {
                return NotFound();
            }

            return Ok(project_House);
        }

        // PUT: api/House/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject_House(long id, Project_House project_House)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project_House.ID)
            {
                return BadRequest();
            }

            db.Entry(project_House).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Project_HouseExists(id))
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

        // POST: api/House
        [ResponseType(typeof(Project_House))]
        public IHttpActionResult PostProject_House(Project_House project_House)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Project_House.Add(project_House);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project_House.ID }, project_House);
        }

        // DELETE: api/House/5
        [ResponseType(typeof(Project_House))]
        public IHttpActionResult DeleteProject_House(long id)
        {
            Project_House project_House = db.Project_House.Find(id);
            if (project_House == null)
            {
                return NotFound();
            }

            db.Project_House.Remove(project_House);
            db.SaveChanges();

            return Ok(project_House);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Project_HouseExists(long id)
        {
            return db.Project_House.Count(e => e.ID == id) > 0;
        }
    }
}