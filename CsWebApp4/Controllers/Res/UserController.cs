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
using CsWebApp4.Global;
using CsWebApp4.Models;

namespace CsWebApp4.Controllers.Res
{
    public class UserController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/User
        public ActionRes GetSystem_User()
        {
            var system_User = db.System_User.ToList();
            if (system_User == null)
            {
                return ActionRes.Fail("");
            }

            return ActionRes.Success(system_User);
        }

        // GET: api/User/5
        [ResponseType(typeof(System_User))]
        public ActionRes GetSystem_User(long id)
        {
            System_User system_User = db.System_User.Find(id);
            if (system_User == null)
            {
                return ActionRes.Fail("");
            }

            return ActionRes.Success(system_User);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSystem_User(long id, System_User system_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != system_User.ID)
            {
                return BadRequest();
            }

            db.Entry(system_User).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!System_UserExists(id))
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

        // POST: api/User
        [ResponseType(typeof(System_User))]
        public IHttpActionResult PostSystem_User(System_User system_User)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.System_User.Add(system_User);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = system_User.ID }, system_User);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(System_User))]
        public IHttpActionResult DeleteSystem_User(long id)
        {
            System_User system_User = db.System_User.Find(id);
            if (system_User == null)
            {
                return NotFound();
            }

            db.System_User.Remove(system_User);
            db.SaveChanges();

            return Ok(system_User);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool System_UserExists(long id)
        {
            return db.System_User.Count(e => e.ID == id) > 0;
        }
    }
}