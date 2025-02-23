using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class LoanType
    {
        public LoanType()
        {
            Loans = new HashSet<Loan>();
        }

        public int LoanTypeId { get; set; }
        public string TypeName { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal? TaxValue { get; set; }
        public decimal? MaxLoan { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
