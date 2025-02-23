using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class StocksRate
    {
        public int StockRateId { get; set; }
        public int NationalityId { get; set; }
        public decimal Rate { get; set; }

        public virtual Nationality Nationality { get; set; }
    }
}
