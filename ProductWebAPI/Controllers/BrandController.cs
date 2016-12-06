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
using ProductWebAPI.Models;

namespace ProductWebAPI.Controllers
{
    public class BrandController : ApiController
    {
        private ProductWebAPIContext db = new ProductWebAPIContext();

        // GET api/Brand
        public IQueryable<Brand> GetBrand()
        {
            return db.Brand;
        }

        // GET api/Brand/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult GetBrand(int id)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT api/Brand/5
        public IHttpActionResult PutBrand(int id, Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brand.Id)
            {
                return BadRequest();
            }

            db.Entry(brand).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(id))
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

        // POST api/Brand
        [ResponseType(typeof(Brand))]
        public IHttpActionResult PostBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brand.Add(brand);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = brand.Id }, brand);
        }

        // DELETE api/Brand/5
        [ResponseType(typeof(Brand))]
        public IHttpActionResult DeleteBrand(int id)
        {
            Brand brand = db.Brand.Find(id);
            if (brand == null)
            {
                return NotFound();
            }

            db.Brand.Remove(brand);
            db.SaveChanges();

            return Ok(brand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int id)
        {
            return db.Brand.Count(e => e.Id == id) > 0;
        }
    }
}