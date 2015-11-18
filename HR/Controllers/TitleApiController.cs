using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HR.Models;

namespace HR.Controllers
{
    public class TitleApiController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/TitleApi
        public IQueryable<Title> GetTitle()
        {
            return db.Title;
        }

        // GET api/TitleApi/5
        [ResponseType(typeof(Title))]
        public async Task<IHttpActionResult> GetTitle(int id)
        {
            Title title = await db.Title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT api/TitleApi/5
        public async Task<IHttpActionResult> PutTitle(int id, Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.TitleId)
            {
                return BadRequest();
            }

            db.Entry(title).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
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

        // POST api/TitleApi
        [ResponseType(typeof(Title))]
        public async Task<IHttpActionResult> PostTitle(Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Title.Add(title);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = title.TitleId }, title);
        }

        // DELETE api/TitleApi/5
        [ResponseType(typeof(Title))]
        public async Task<IHttpActionResult> DeleteTitle(int id)
        {
            Title title = await db.Title.FindAsync(id);
            if (title == null)
            {
                return NotFound();
            }

            db.Title.Remove(title);
            await db.SaveChangesAsync();

            return Ok(title);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TitleExists(int id)
        {
            return db.Title.Count(e => e.TitleId == id) > 0;
        }
    }
}