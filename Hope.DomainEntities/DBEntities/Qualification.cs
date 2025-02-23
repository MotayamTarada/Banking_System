using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Qualification
    {
        public Qualification()
        {
            Employees = new HashSet<Employee>();
        }

        public int QualificationId { get; set; }
        public string QualificationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
