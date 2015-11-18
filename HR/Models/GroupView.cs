using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class GroupView
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string CoverPicture1 { get; set; }
        public string CoverPicture2 { get; set; }
        public string CoverPicture3 { get; set; }
        public string CoverPicture4 { get; set; }
        public Employee Head { get; set; }
        public string ProfilePicture { get; set; }
        public List<Employee> Members { get; set; }
    }
}