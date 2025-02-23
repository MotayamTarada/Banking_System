using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Infrastructure.DTO
{
    public class DashboardDTO
    {
        public int NumberOfClients { get; set; }

        public int NumberOfEmployees { get; set; }

        public int NumberOfAccountOpening { get; set; }

        public int NumberOfLoans { get; set; }
    }
}
