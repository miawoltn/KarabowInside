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
    public class EmployementStatusApiController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/EmployementStatusApi
        public IQueryable<EmployementStatus> GetEmployementStatus()
        {
            return db.EmployementStatus;
        }

        // GET api/EmployementStatusApi/5
        [ResponseType(typeof(EmployementStatus))]
        public async Task<IHttpActionResult> GetEmployementStatus(int id)
        {
            EmployementStatus employementstatus = await db.EmployementStatus.FindAsync(id);
            if (employementstatus == null)
            {
                return NotFound();
            }

            return Ok(employementstatus);
        }

        // PUT api/EmployementStatusApi/5
        public async Task<IHttpActionResult> PutEmployementStatus(int id, EmployementStatus employementstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employementstatus.EmployementStatusdId)
            {
                return BadRequest();
            }

            db.Entry(employementstatus).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployementStatusExists(id))
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

        // POST api/EmployementStatusApi
        [ResponseType(typeof(EmployementStatus))]
        public async Task<IHttpActionResult> PostEmployementStatus(EmployementStatus employementstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployementStatus.Add(employementstatus);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employementstatus.EmployementStatusdId }, employementstatus);
        }

        // DELETE api/EmployementStatusApi/5
        [ResponseType(typeof(EmployementStatus))]
        public async Task<IHttpActionResult> DeleteEmployementStatus(int id)
        {
            EmployementStatus employementstatus = await db.EmployementStatus.FindAsync(id);
            if (employementstatus == null)
            {
                return NotFound();
            }

            db.EmployementStatus.Remove(employementstatus);
            await db.SaveChangesAsync();

            return Ok(employementstatus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployementStatusExists(int id)
        {
            return db.EmployementStatus.Count(e => e.EmployementStatusdId == id) > 0;
        }
    }
}