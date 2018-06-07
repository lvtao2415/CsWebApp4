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
    public class CartController : ApiController
    {
        private HouseMoreEntities db = new HouseMoreEntities();

        // GET: api/Cart
        public IQueryable<User_Cart> GetUser_Cart()
        {
            return db.User_Cart;
        }

        // GET: api/Cart/5
        [ResponseType(typeof(User_Cart))]
        public IHttpActionResult GetUser_Cart(long id)
        {
            User_Cart user_Cart = db.User_Cart.Find(id);
            if (user_Cart == null)
            {
                return NotFound();
            }

            return Ok(user_Cart);
        }

        // PUT: api/Cart/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser_Cart(long id, User_Cart user_Cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_Cart.ID)
            {
                return BadRequest();
            }

            db.Entry(user_Cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!User_CartExists(id))
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

        // POST: api/Cart
        [ResponseType(typeof(User_Cart))]
        public IHttpActionResult PostUser_Cart(User_Cart user_Cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.User_Cart.Add(user_Cart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user_Cart.ID }, user_Cart);
        }

        // DELETE: api/Cart/5
        [ResponseType(typeof(User_Cart))]
        public IHttpActionResult DeleteUser_Cart(long id)
        {
            User_Cart user_Cart = db.User_Cart.Find(id);
            if (user_Cart == null)
            {
                return NotFound();
            }

            db.User_Cart.Remove(user_Cart);
            db.SaveChanges();

            return Ok(user_Cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool User_CartExists(long id)
        {
            return db.User_Cart.Count(e => e.ID == id) > 0;
        }
    }
}