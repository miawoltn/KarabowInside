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
    public class WorkspacesController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/Workspaces
        public IQueryable<Workspace> GetWorkspaces()
        {
            return db.Workspaces;
        }

        // GET api/Workspaces/5
        [ResponseType(typeof(Workspace))]
        public async Task<IHttpActionResult> GetWorkspace(int id)
        {
            Workspace workspace = await db.Workspaces.FindAsync(id);

            if (workspace == null)
            {
                return NotFound();
            }

            return Ok(workspace);
        }

        // PUT api/Workspaces/5
        public async Task<IHttpActionResult> PutWorkspace(int id, Workspace workspace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workspace.WorkspaceId)
            {
                return BadRequest();
            }

            db.Entry(workspace).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkspaceExists(id))
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

        // POST api/Workspaces
        [ResponseType(typeof(Workspace))]
        public async Task<IHttpActionResult> PostWorkspace(Workspace workspace)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Workspaces.Add(workspace);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = workspace.WorkspaceId }, workspace);
        }

        // DELETE api/Workspaces/5
        [ResponseType(typeof(Workspace))]
        public async Task<IHttpActionResult> DeleteWorkspace(int id)
        {
            Workspace workspace = await db.Workspaces.FindAsync(id);
            if (workspace == null)
            {
                return NotFound();
            }

            db.Workspaces.Remove(workspace);
            await db.SaveChangesAsync();

            return Ok(workspace);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkspaceExists(int id)
        {
            return db.Workspaces.Count(e => e.WorkspaceId == id) > 0;
        }
    }
}