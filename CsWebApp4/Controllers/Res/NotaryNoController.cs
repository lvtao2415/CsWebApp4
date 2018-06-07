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
    public class NotaryNoController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/NotaryNo
        public IQueryable<User_NotaryNo> GetUser_NotaryNo()
        {
            return db.User_NotaryNo;
        }

        // GET: api/NotaryNo/5
        [ResponseType(typeof(User_NotaryNo))]
        public IHttpActionResult GetUser_NotaryNo(long id)
        {
            User_NotaryNo user_NotaryNo = db.User_NotaryNo.Find(id);
            if (user_NotaryNo == null)
            {
                return NotFound();
            }

            return Ok(user_NotaryNo);
        }

        // PUT: api/NotaryNo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_NotaryNo(long id, User_NotaryNo user_NotaryNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_NotaryNo.ID)
            {
                return BadRequest();
            }

            db.Entry(user_NotaryNo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_NotaryNoExists(id))
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

        // POST: api/NotaryNo
        [ResponseType(typeof(User_NotaryNo))]
        public IHttpActionResult PostUser_NotaryNo(User_NotaryNo user_NotaryNo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_NotaryNo.Add(user_NotaryNo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user_NotaryNo.ID }, user_NotaryNo);
        }

        // DELETE: api/NotaryNo/5
        [ResponseType(typeof(User_NotaryNo))]
        public IHttpActionResult DeleteUser_NotaryNo(long id)
        {
            User_NotaryNo user_NotaryNo = db.User_NotaryNo.Find(id);
            if (user_NotaryNo == null)
            {
                return NotFound();
            }

            db.User_NotaryNo.Remove(user_NotaryNo);
            db.SaveChanges();

            return Ok(user_NotaryNo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_NotaryNoExists(long id)
        {
            return db.User_NotaryNo.Count(e => e.ID == id) > 0;
        }
    }
}