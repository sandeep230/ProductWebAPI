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
    public class SubCategoryController : ApiController
    {
        private ProductWebAPIContext db = new ProductWebAPIContext();

        // GET api/SubCategory
        public IQueryable<SubCategory> GetSubCategory()
        {
            return db.SubCategory;
        }

        // GET api/SubCategory/5
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult GetSubCategory(int id)
        {
            SubCategory subcategory = db.SubCategory.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return Ok(subcategory);
        }

        // PUT api/SubCategory/5
        public IHttpActionResult PutSubCategory(int id, SubCategory subcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subcategory.Id)
            {
                return BadRequest();
            }

            db.Entry(subcategory).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubCategoryExists(id))
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

        // POST api/SubCategory
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult PostSubCategory(SubCategory subcategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCategory.Add(subcategory);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subcategory.Id }, subcategory);
        }

        // DELETE api/SubCategory/5
        [ResponseType(typeof(SubCategory))]
        public IHttpActionResult DeleteSubCategory(int id)
        {
            SubCategory subcategory = db.SubCategory.Find(id);
            if (subcategory == null)
            {
                return NotFound();
            }

            db.SubCategory.Remove(subcategory);
            db.SaveChanges();

            return Ok(subcategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubCategoryExists(int id)
        {
            return db.SubCategory.Count(e => e.Id == id) > 0;
        }
    }
}