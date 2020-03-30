using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Country
    {
        public Country()
        {
            Marathon = new HashSet<Marathon>();
            Runner = new HashSet<Runner>();
            Volunteer = new HashSet<Volunteer>();
        }

        [Key]
        [StringLength(3)]
        public string CountryCode { get; set; }
        [Required]
        [StringLength(100)]
        public string CountryName { get; set; }
        [Required]
        [StringLength(100)]
        public string CountryFlag { get; set; }

        [InverseProperty("CountryCodeNavigation")]
        public virtual ICollection<Marathon> Marathon { get; set; }
        [InverseProperty("CountryCodeNavigation")]
        public virtual ICollection<Runner> Runner { get; set; }
        [InverseProperty("CountryCodeNavigation")]
        public virtual ICollection<Volunteer> Volunteer { get; set; }
    }
}
