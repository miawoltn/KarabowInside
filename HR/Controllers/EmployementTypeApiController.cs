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
    public class EmployementTypeApiController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/EmployementTypeApi
        public IQueryable<EmployementType> GetEmployementType()
        {
            return db.EmployementType;
        }

        // GET api/EmployementTypeApi/5
        [ResponseType(typeof(EmployementType))]
        public async Task<IHttpActionResult> GetEmployementType(int id)
        {
            EmployementType employementtype = await db.EmployementType.FindAsync(id);
            if (employementtype == null)
            {
                return NotFound();
            }

            return Ok(employementtype);
        }

        // PUT api/EmployementTypeApi/5
        public async Task<IHttpActionResult> PutEmployementType(int id, EmployementType employementtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employementtype.EmploymentTypeId)
            {
                return BadRequest();
            }

            db.Entry(employementtype).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployementTypeExists(id))
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

        // POST api/EmployementTypeApi
        [ResponseType(typeof(EmployementType))]
        public async Task<IHttpActionResult> PostEmployementType(EmployementType employementtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployementType.Add(employementtype);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employementtype.EmploymentTypeId }, employementtype);
        }

        // DELETE api/EmployementTypeApi/5
        [ResponseType(typeof(EmployementType))]
        public async Task<IHttpActionResult> DeleteEmployementType(int id)
        {
            EmployementType employementtype = await db.EmployementType.FindAsync(id);
            if (employementtype == null)
            {
                return NotFound();
            }

            db.EmployementType.Remove(employementtype);
            await db.SaveChangesAsync();

            return Ok(employementtype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployementTypeExists(int id)
        {
            return db.EmployementType.Count(e => e.EmploymentTypeId == id) > 0;
        }
    }
}