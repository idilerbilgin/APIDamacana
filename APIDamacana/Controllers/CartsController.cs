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
using APIDamacana.Models;
using System.Threading.Tasks;

namespace APIDamacana.Controllers
{
    public class CartsController : ApiController
    {
        private APIDamacanaContext db = new APIDamacanaContext();

        // GET: api/Carts
        public IQueryable<Cart> GetCarts()
        {
            var carts = from b in db.Carts
                        select new CartDTO()
                        {
                            Id = b.Id,
                          
                        };

            return db.Carts;
        
        }

        // GET: api/Carts/5
        [ResponseType(typeof(CartDetailDTO))]
        public async Task<IHttpActionResult> GetCart(int id)
        {
            var cart = await db.Carts.Include(b => b.Product).Select(b =>
                new CartDetailDTO()
                {
                    Id = b.Id,
                  
                }).SingleOrDefaultAsync(b => b.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        } 

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCart(int id, Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cart.Id)
            {
                return BadRequest();
            }

            db.Entry(cart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(id))
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

        // POST: api/Carts
        [ResponseType(typeof(Cart))]
        public IHttpActionResult PostCart(Cart cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carts.Add(cart);
            db.SaveChanges();
            db.Entry(cart).Reference(x => x.Product).Load();

            var dto = new CartDTO()
            {
                Id = cart.Id,
               };


            return CreatedAtRoute("DefaultApi", new { id = cart.Id }, dto);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(Cart))]
        public IHttpActionResult DeleteCart(int id)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            db.Carts.Remove(cart);
            db.SaveChanges();

            return Ok(cart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartExists(int id)
        {
            return db.Carts.Count(e => e.Id == id) > 0;
        }
    }
}