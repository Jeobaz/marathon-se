using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
