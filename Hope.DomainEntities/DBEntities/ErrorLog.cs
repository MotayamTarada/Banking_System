using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class ErrorLog
    {
        public int ErrorLogId { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorDate { get; set; }
        public string ModuleName { get; set; }
    }
}
