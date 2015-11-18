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
using System.Web.Mvc;
using System.Collections;

namespace HR.Controllers
{
    public class EmployeeController : ApiController
    {
        private HRContext db = new HRContext();

        // GET api/Employee
        [System.Web.Http.Route("api/ListEmployees")]
        public IQueryable<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>();
                
               foreach(Employee emp in db.Employees)
               {
                   var branch = db.BranchOffices.Find(emp.BranchId);
                   var status = GetStatus(emp.EmployementStatusId);
                   var type = GetType(emp.EmployementTypeId);
                   var wrksp =  (from ws in db.Workspaces join empws in db.EmployeeWorkspaces on ws.WorkspaceId equals empws.WorkspaceId
                                 where empws.EmployeeId == emp.EmployeeId select ws).ToList();
                   //var titles = (from tl in db.Title
                   //              join emptl in db.EmployeeTitles on tl.TitleId equals emptl.TitleId
                   //              where emptl.EmployeeId == emp.EmployeeId
                   //              select ws).ToList();
                   var empview = new EmployeeViewModel
                   {
                       EmployeeId = emp.EmployeeId,
                       FirstName = emp.FirstName,
                       LastName = emp.LastName,
                       OtherName = emp.OtherName,
                       Email = emp.Email,
                       PhoneNumber = emp.PhoneNumber,
                       Passport = emp.Passport,
                       Birthdate = emp.Birthdate,
                       Gender = emp.Gender,
                       ResidentialAddress = emp.ResidentialAddress,
                       Nationality = emp.Nationality,
                       Branch = new BranchOffice { BranchId = branch.BranchId, BranchName = branch.BranchName },
                       CompanyEmail = emp.CompanyEmail,
                       CompanyPhoneNumber = emp.CompanyPhoneNumber,
                       EmployementStatus = status.Status,
                       EmployementType = type.Type,
                       Workspaces = wrksp
                   };
                   employees.Add(empview);
               }
           
            return employees.AsQueryable();
        }

        // GET api/Employee/5
        [ResponseType(typeof(EmployeeViewModel))]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
           var employee =  await db.Employees.FindAsync(id);
            //if employee not found return a 404 error
            if (employee == null)
            {
                return NotFound();
            }

            //else get the other details associated with the employee
            var branch = await db.BranchOffices.FindAsync(employee.BranchId);
            var status = GetStatus(employee.EmployementStatusId);
            var type = GetType(employee.EmployementTypeId);


            List<string> str = new List<string>();
            str.Add("MCTS");
            str.Add("Faculty");
            var emp = new EmployeeViewModel
            {
                EmployeeId = id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                OtherName = employee.OtherName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Passport = employee.Passport,
                Birthdate = employee.Birthdate,
                Gender = employee.Gender,
                ResidentialAddress = employee.ResidentialAddress,
                Nationality = employee.Nationality,
                Branch = new BranchOffice { BranchId = branch.BranchId, BranchName = branch.BranchName },
                CompanyEmail = employee.CompanyEmail,
                CompanyPhoneNumber = employee.CompanyPhoneNumber,
                EmployementStatus = status.Status,
                EmployementType = type.Type,
               // Roles = str
            };
           

            return Ok(emp);
        }

        // PUT api/Employee/5
        public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST api/Employee
        [ResponseType(typeof(EmployeeViewModel))]
        public async Task<IHttpActionResult> PostEmployee(EmployeeViewModel emp)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var branch = GetBranch(emp.Branch);//getting branch data
            var empstatus = GetStatus(emp.EmployementStatus);//getting employee status
            var emptype = GetType(emp.EmployementType);//getting employement status of employee

            //creating a new employee
            var employee = new Employee();
            employee.FirstName = emp.FirstName;
            employee.LastName = emp.LastName;
            employee.OtherName = emp.OtherName;
            employee.Email = emp.Email;
            employee.PhoneNumber = emp.PhoneNumber;
            employee.Passport = emp.Passport;
            employee.Birthdate = emp.Birthdate;
            employee.Gender = emp.Gender;
            employee.ResidentialAddress = emp.ResidentialAddress;
            employee.Nationality = emp.Nationality;
            employee.BranchId = branch.BranchId;
            employee.CompanyEmail = emp.CompanyEmail;
            employee.CompanyPhoneNumber = emp.CompanyPhoneNumber;
            employee.EmployementStatusId = empstatus.EmployementStatusdId;
            employee.EmployementTypeId = emptype.EmploymentTypeId;

            //adding the employee to roles

            //adding titles to emloyee

            //adding a user profile
           
            db.Employees.Add(employee);
            var profile = new EmployeeProfile
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.FirstName.Substring(0,3)+employee.LastName.Substring(employee.LastName.Length-3)
            };
            db.EmployeeProfile.Add(profile);
            await db.SaveChangesAsync();
            emp.EmployeeId = employee.EmployeeId;

            //returning back back employee along with his/her branch details
            //avoiding circular reference exception by returning from the model
            BranchOffice b = new BranchOffice
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName
            };
            emp.Branch = b;
            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, emp);
        }
         
        // DELETE api/Employee/5
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> DeleteEmployee(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            await db.SaveChangesAsync();

            return Ok("Deleted");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.Employees.Count(e => e.EmployeeId == id) > 0;
        }

        //Helper methods
        public BranchOffice GetBranch(object branch)
        {
            int result;
            if(int.TryParse(branch.ToString(),out result))
                  return db.BranchOffices.Single(b => b.BranchId == (int)branch);
            else
                return db.BranchOffices.Single(b => b.BranchName == (string)branch);
        }

        public EmployementStatus GetStatus(object status)
        {
            int result;
            if (int.TryParse(status.ToString(), out result))
                 return db.EmployementStatus.Single(es => es.EmployementStatusdId == (int)status);
            else
                return db.EmployementStatus.Single(es => es.Status == (string)status);
        }

        public EmployementType GetType(object type)
        {
            int result;
            if (int.TryParse(type.ToString(), out result))
                 return db.EmployementType.Single(et => et.EmploymentTypeId == (int)type);
            else
                return db.EmployementType.Single(et => et.Type == (string)type);
        }

        //public Role GetRoles(object type)
        //{

        //}
    }
}