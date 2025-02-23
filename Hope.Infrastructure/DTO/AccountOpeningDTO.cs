using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Infrastructure.DTO
{
   public class AccountOpeningDTO
    {
        public int AccountOpeningId { get; set; }
        public int AccountTypeId { get; set; }
        public DateTime OpeningDate { get; set; }
        public int ClientId { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }
    }
}
