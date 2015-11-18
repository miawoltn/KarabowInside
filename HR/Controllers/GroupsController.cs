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
    public class GroupsController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/Groups
        public IQueryable<Group> GetGroups()
        {
            return db.Groups;
        }

        // GET api/Groups/5
        [ResponseType(typeof(GroupView))]
        public async Task<IHttpActionResult> GetGroup(int id)
        {
            var gr = await db.Groups.FindAsync(id);
            var emps = (from emp in db.Employees join empgrp in db.EmployeeGroups on emp.EmployeeId equals empgrp.EmployeeId where empgrp.GroupId == gr.GroupId select emp).ToList();
            GroupView group = new GroupView
            {
                GroupId = gr.GroupId,
                Name = gr.Name,
                About = gr.About,
                CoverPicture1 = gr.CoverPicture1,
                CoverPicture2 = gr.CoverPicture2,
                CoverPicture3 = gr.CoverPicture3,
                CoverPicture4 = gr.CoverPicture4,
                Head = await db.Employees.FindAsync(gr.Head),
                Members = emps

            };

            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        // PUT api/Groups/5
        public async Task<IHttpActionResult> PutGroup(int id, Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != group.GroupId)
            {
                return BadRequest();
            }

            db.Entry(group).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST api/Groups
        [ResponseType(typeof(Group))]
        public async Task<IHttpActionResult> PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Groups.Add(group);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = group.GroupId }, group);
        }

        // DELETE api/Groups/5
        [ResponseType(typeof(Group))]
        public async Task<IHttpActionResult> DeleteGroup(int id)
        {
            Group group = await db.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            db.Groups.Remove(group);
            await db.SaveChangesAsync();

            return Ok(group);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GroupExists(int id)
        {
            return db.Groups.Count(e => e.GroupId == id) > 0;
        }
    }
}