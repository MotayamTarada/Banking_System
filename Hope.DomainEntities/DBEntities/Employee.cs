using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Employee
    {
        public Employee()
        {
            RoleUsers = new HashSet<RoleUser>();
        }

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public decimal Salary { get; set; }
        public int QualificationId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IdcardPath { get; set; }

        public virtual Qualification Qualification { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
