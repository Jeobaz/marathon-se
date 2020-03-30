using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Runner = new HashSet<Runner>();
            Volunteer = new HashSet<Volunteer>();
        }

        [Key]
        [Column("Gender")]
        [StringLength(10)]
        public string Gender1 { get; set; }

        [InverseProperty("GenderNavigation")]
        public virtual ICollection<Runner> Runner { get; set; }
        [InverseProperty("GenderNavigation")]
        public virtual ICollection<Volunteer> Volunteer { get; set; }
    }
}
