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
    public class CollectController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/Collect
        public IQueryable<User_Collect> GetUser_Collect()
        {
            return db.User_Collect;
        }

        // GET: api/Collect/5
        [ResponseType(typeof(User_Collect))]
        public IHttpActionResult GetUser_Collect(long id)
        {
            User_Collect user_Collect = db.User_Collect.Find(id);
            if (user_Collect == null)
            {
                return NotFound();
            }

            return Ok(user_Collect);
        }

        // PUT: api/Collect/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_Collect(long id, User_Collect user_Collect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Collect.ID)
            {
                return BadRequest();
            }

            db.Entry(user_Collect).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_CollectExists(id))
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

        // POST: api/Collect
        [ResponseType(typeof(User_Collect))]
        public IHttpActionResult PostUser_Collect(User_Collect user_Collect)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Collect.Add(user_Collect);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user_Collect.ID }, user_Collect);
        }

        // DELETE: api/Collect/5
        [ResponseType(typeof(User_Collect))]
        public IHttpActionResult DeleteUser_Collect(long id)
        {
            User_Collect user_Collect = db.User_Collect.Find(id);
            if (user_Collect == null)
            {
                return NotFound();
            }

            db.User_Collect.Remove(user_Collect);
            db.SaveChanges();

            return Ok(user_Collect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_CollectExists(long id)
        {
            return db.User_Collect.Count(e => e.ID == id) > 0;
        }
    }
}