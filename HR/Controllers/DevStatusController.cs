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
    public class DevStatusController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/DevStatus
        public IQueryable<DevelopmentStatus> GetDevelopmentStatus()
        {
            return db.DevelopmentStatus;
        }

        // GET api/DevStatus/5
        [ResponseType(typeof(DevelopmentStatus))]
        public async Task<IHttpActionResult> GetDevelopmentStatus(int id)
        {
            DevelopmentStatus developmentstatus = await db.DevelopmentStatus.FindAsync(id);
            if (developmentstatus == null)
            {
                return NotFound();
            }

            return Ok(developmentstatus);
        }

        // PUT api/DevStatus/5
        public async Task<IHttpActionResult> PutDevelopmentStatus(int id, DevelopmentStatus developmentstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != developmentstatus.Id)
            {
                return BadRequest();
            }

            db.Entry(developmentstatus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevelopmentStatusExists(id))
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

        // POST api/DevStatus
        [ResponseType(typeof(DevelopmentStatus))]
        public async Task<IHttpActionResult> PostDevelopmentStatus(DevelopmentStatus developmentstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DevelopmentStatus.Add(developmentstatus);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = developmentstatus.Id }, developmentstatus);
        }

        // DELETE api/DevStatus/5
        [ResponseType(typeof(DevelopmentStatus))]
        public async Task<IHttpActionResult> DeleteDevelopmentStatus(int id)
        {
            DevelopmentStatus developmentstatus = await db.DevelopmentStatus.FindAsync(id);
            if (developmentstatus == null)
            {
                return NotFound();
            }

            db.DevelopmentStatus.Remove(developmentstatus);
            await db.SaveChangesAsync();

            return Ok(developmentstatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DevelopmentStatusExists(int id)
        {
            return db.DevelopmentStatus.Count(e => e.Id == id) > 0;
        }
    }
}