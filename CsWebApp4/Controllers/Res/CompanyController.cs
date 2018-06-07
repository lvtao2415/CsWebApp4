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
    public class CompanyController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/Company
        public IQueryable<System_Company> GetSystem_Company()
        {
            return db.System_Company;
        }

        // GET: api/Company/5
        [ResponseType(typeof(System_Company))]
        public IHttpActionResult GetSystem_Company(long id)
        {
            System_Company system_Company = db.System_Company.Find(id);
            if (system_Company == null)
            {
                return NotFound();
            }

            return Ok(system_Company);
        }

        // PUT: api/Company/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSystem_Company(long id, System_Company system_Company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != system_Company.ID)
            {
                return BadRequest();
            }

            db.Entry(system_Company).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!System_CompanyExists(id))
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

        // POST: api/Company
        [ResponseType(typeof(System_Company))]
        public IHttpActionResult PostSystem_Company(System_Company system_Company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.System_Company.Add(system_Company);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = system_Company.ID }, system_Company);
        }

        // DELETE: api/Company/5
        [ResponseType(typeof(System_Company))]
        public IHttpActionResult DeleteSystem_Company(long id)
        {
            System_Company system_Company = db.System_Company.Find(id);
            if (system_Company == null)
            {
                return NotFound();
            }

            db.System_Company.Remove(system_Company);
            db.SaveChanges();

            return Ok(system_Company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool System_CompanyExists(long id)
        {
            return db.System_Company.Count(e => e.ID == id) > 0;
        }
    }
}