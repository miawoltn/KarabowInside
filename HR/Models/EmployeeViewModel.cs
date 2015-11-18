using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class EmployeeViewModel
    {
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string OtherName { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string Passport { get; set; }
            public DateTime Birthdate { get; set; }
            public string Gender { get; set; }
            public string ResidentialAddress { get; set; }
            public string Nationality { get; set; }
            public object Branch { get; set; }
            public string CompanyEmail { get; set; }
            public string CompanyPhoneNumber { get; set; }
            public object EmployementStatus { get; set; }
            public object EmployementType { get; set; }
            public List<Role> Roles { get; set; }
            public List<Title> Titles { get; set; }
            public List<Workspace> Workspaces { get; set; }
        
    }
}