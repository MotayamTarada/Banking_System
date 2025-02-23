using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Nationality
    {
        public Nationality()
        {
            Clients = new HashSet<Client>();
            StocksRates = new HashSet<StocksRate>();
        }

        public int NationalityId { get; set; }
        public string NationalityName { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<StocksRate> StocksRates { get; set; }
    }
}
