using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class AccountType
    {
        public AccountType()
        {
            AccountOpenings = new HashSet<AccountOpening>();
        }

        public int AccountTypeId { get; set; }
        public string AccountName { get; set; }

        public virtual ICollection<AccountOpening> AccountOpenings { get; set; }
    }
}
