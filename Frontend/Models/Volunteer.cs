using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Volunteer
    {
        [Key]
        public int VolunteerId { get; set; }
        [StringLength(80)]
        public string FirstName { get; set; }
        [StringLength(80)]
        public string LastName { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.Volunteer))]
        public virtual Country CountryCodeNavigation { get; set; }
        [ForeignKey(nameof(Gender))]
        [InverseProperty("Volunteer")]
        public virtual Gender GenderNavigation { get; set; }
    }
}
