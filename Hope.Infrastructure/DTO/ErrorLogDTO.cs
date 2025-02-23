using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hope.Infrastructure.DTO
{
    public class ErrorLogDTO
    {
        public string ErrorMessage { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ModuleName { get; set; }
    }
}
