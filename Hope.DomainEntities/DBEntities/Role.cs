using System;
using System.Collections.Generic;

#nullable disable

namespace Hope.DomainEntities.DBEntities
{
    public partial class Role
    {
        public Role()
        {
            RoleModules = new HashSet<RoleModule>();
            RoleUsers = new HashSet<RoleUser>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<RoleModule> RoleModules { get; set; }
        public virtual ICollection<RoleUser> RoleUsers { get; set; }
    }
}
