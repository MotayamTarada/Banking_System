using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Client
    {
        public Client()
        {
            AccountOpenings = new HashSet<AccountOpening>();
            Loans = new HashSet<Loan>();
        }

        public int ClientId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public string NationalId { get; set; }
        public int? NationalityId { get; set; }
        public string PassportNumber { get; set; }
        public string Email { get; set; }

        public virtual Nationality Nationality { get; set; }
        public virtual ICollection<AccountOpening> AccountOpenings { get; set; }
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
