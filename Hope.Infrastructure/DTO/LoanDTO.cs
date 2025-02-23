using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Infrastructure.DTO
{
    public class LoanDTO
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
    }
}
