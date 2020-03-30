using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class User
    {
        public User()
        {
            Runner = new HashSet<Runner>();
        }

        [Key]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(80)]
        public string FirstName { get; set; }
        [StringLength(80)]
        public string LastName { get; set; }
        [Required]
        [StringLength(1)]
        public string RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("User")]
        public virtual Role Role { get; set; }
        [InverseProperty("EmailNavigation")]
        public virtual ICollection<Runner> Runner { get; set; }
    }
}
