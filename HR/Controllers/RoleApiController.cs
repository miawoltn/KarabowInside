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
    public class RoleApiController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/RoleApi
        public IQueryable<Role> GetRole()
        {
            return db.Role;
        }

        // GET api/RoleApi/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> GetRole(int id)
        {
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // PUT api/RoleApi/5
        public async Task<IHttpActionResult> PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST api/RoleApi
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Role.Add(role);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // DELETE api/RoleApi/5
        [ResponseType(typeof(Role))]
        public async Task<IHttpActionResult> DeleteRole(int id)
        {
            Role role = await db.Role.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            db.Role.Remove(role);
            await db.SaveChangesAsync();

            return Ok(role);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleExists(int id)
        {
            return db.Role.Count(e => e.Id == id) > 0;
        }
    }
}