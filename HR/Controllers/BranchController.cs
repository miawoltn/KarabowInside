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
    public class BranchController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/Branch
        public IQueryable<Branch> GetBranch()
        {
            return db.Branch;
        }

        // GET api/Branch/5
        [ResponseType(typeof(Branch))]
        public async Task<IHttpActionResult> GetBranch(int id)
        {
            Branch branch = await db.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        // PUT api/Branch/5
        public async Task<IHttpActionResult> PutBranch(int id, Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branch.BranchId)
            {
                return BadRequest();
            }

            db.Entry(branch).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchExists(id))
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

        // POST api/Branch
        [ResponseType(typeof(Branch))]
        public async Task<IHttpActionResult> PostBranch(Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Branch.Add(branch);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BranchExists(branch.BranchId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = branch.BranchId }, branch);
        }

        // DELETE api/Branch/5
        [ResponseType(typeof(Branch))]
        public async Task<IHttpActionResult> DeleteBranch(int id)
        {
            Branch branch = await db.Branch.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            db.Branch.Remove(branch);
            await db.SaveChangesAsync();

            return Ok(branch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BranchExists(int id)
        {
            return db.Branch.Count(e => e.BranchId == id) > 0;
        }
    }
}