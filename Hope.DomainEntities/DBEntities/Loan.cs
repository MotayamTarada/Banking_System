using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Loan
    {
        public int LoanId { get; set; }
        public int LoanTypeId { get; set; }
        public int ClientId { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanPeriod { get; set; }
        public decimal LoanSattelmentAmount { get; set; }
        public decimal TotalAmountwithInterest { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TaxValue { get; set; }
        public string Curreny { get; set; }

        public virtual Client Client { get; set; }
        public virtual LoanType LoanType { get; set; }
    }
}
