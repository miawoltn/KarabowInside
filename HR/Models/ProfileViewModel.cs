using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public List<Title> Titles { get; set; }
        public object EmployementType { get; set; }
        public object EmployementStatus { get; set; }
       // public List<Workspace> WorkSpaces { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public string About { get; set; }
        public string JobInterests { get; set; }
        public string JobTools { get; set; }
        public string JobWebsites { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPicture2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }
    }
}