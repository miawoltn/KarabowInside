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
    public class EmployeeProfileApiController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/EmployeeProfileApi
        public IQueryable<EmployeeProfile> GetEmployeeProfile()
        {
            return db.EmployeeProfile;
        }

        // GET api/EmployeeProfileApi/5
        [ResponseType(typeof(ProfileViewModel))]
        public async Task<IHttpActionResult> GetEmployeeProfile(int id)
        {
            EmployeeProfile employeeprofile = await db.EmployeeProfile.FindAsync(id);
            var emp = db.Employees.Single(e => e.EmployeeId == id);
            var state = db.EmployementStatus.Single(s => s.EmployementStatusdId == emp.EmployementStatusId);
            var type = db.EmployementType.Single(t => t.EmploymentTypeId == emp.EmployementStatusId);
            if (employeeprofile == null)
            {
                return NotFound();
            }
            string coverpic = "default";
            var profile = new ProfileViewModel
            {
                Name = employeeprofile.Name,
                Gender = emp.Gender,
                Birthdate = emp.Birthdate,
                EmployementStatus = state.Status,
                EmployementType = type.Type,
                CompanyEmail = emp.CompanyEmail,
                CompanyPhoneNumber = emp.CompanyPhoneNumber,
                About = employeeprofile.About,
                JobInterests = employeeprofile.JobInterest,
                JobTools = employeeprofile.JobTools,
                JobWebsites = employeeprofile.Websites,
                CoverPicture1 = employeeprofile.CoverPicture1 ?? coverpic
                
            };

            return Ok(profile);
        }

        // PUT api/EmployeeProfileApi/5
        public async Task<IHttpActionResult> PutEmployeeProfile(int id, EmployeeProfile employeeprofile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeprofile.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employeeprofile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeProfileExists(id))
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

        // POST api/EmployeeProfileApi
        [ResponseType(typeof(EmployeeProfile))]
        public async Task<IHttpActionResult> PostEmployeeProfile(EmployeeProfile employeeprofile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeProfile.Add(employeeprofile);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeProfileExists(employeeprofile.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeeprofile.EmployeeId }, employeeprofile);
        }

        // DELETE api/EmployeeProfileApi/5
        [ResponseType(typeof(EmployeeProfile))]
        public async Task<IHttpActionResult> DeleteEmployeeProfile(int id)
        {
            EmployeeProfile employeeprofile = await db.EmployeeProfile.FindAsync(id);
            if (employeeprofile == null)
            {
                return NotFound();
            }

            db.EmployeeProfile.Remove(employeeprofile);
            await db.SaveChangesAsync();

            return Ok(employeeprofile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeProfileExists(int id)
        {
            return db.EmployeeProfile.Count(e => e.EmployeeId == id) > 0;
        }
    }
}