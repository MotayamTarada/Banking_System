using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class AccountOpening
    {
        public int AccountOpeningId { get; set; }
        public int AccountTypeId { get; set; }
        public DateTime OpeningDate { get; set; }
        public int ClientId { get; set; }
        public string Iban { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public bool Status { get; set; }

        public virtual AccountType AccountType { get; set; }
        public virtual Client Client { get; set; }
    }
}
