using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        [Key]
        [StringLength(1)]
        public string RoleId { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User> User { get; set; }
    }
}
