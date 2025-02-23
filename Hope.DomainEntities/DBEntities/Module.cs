using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Module
    {
        public Module()
        {
            RoleModules = new HashSet<RoleModule>();
        }

        public int ModuleId { get; set; }
        public string ModuleName { get; set; }

        public virtual ICollection<RoleModule> RoleModules { get; set; }
    }
}
