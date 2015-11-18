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
    public class BranchOfficeApiController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/BranchOfficeApi
        public IQueryable<BranchOffice> GetBranchOffices()
        {
            return db.BranchOffices;
        }

        // GET api/BranchOfficeApi/5
        [ResponseType(typeof(BranchOffice))]
        public async Task<IHttpActionResult> GetBranchOffice(int id)
        {
            BranchOffice branchoffice = await db.BranchOffices.FindAsync(id);

            if (branchoffice == null)
            {
                return NotFound();
            }

            return Ok(branchoffice);
        }

        // PUT api/BranchOfficeApi/5
        public async Task<IHttpActionResult> PutBranchOffice(int id, BranchOffice branchoffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branchoffice.BranchId)
            {
                return BadRequest();
            }

            db.Entry(branchoffice).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchOfficeExists(id))
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

        // POST api/BranchOfficeApi
        [ResponseType(typeof(BranchOffice))]
        public async Task<IHttpActionResult> PostBranchOffice(BranchOffice branchoffice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BranchOffices.Add(branchoffice);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = branchoffice.BranchId }, branchoffice);
        }

        // DELETE api/BranchOfficeApi/5
        [ResponseType(typeof(BranchOffice))]
        public async Task<IHttpActionResult> DeleteBranchOffice(int id)
        {
            BranchOffice branchoffice = await db.BranchOffices.FindAsync(id);
            if (branchoffice == null)
            {
                return NotFound();
            }

            db.BranchOffices.Remove(branchoffice);
            await db.SaveChangesAsync();

            return Ok(branchoffice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchOfficeExists(int id)
        {
            return db.BranchOffices.Count(e => e.BranchId == id) > 0;
        }
    }
}