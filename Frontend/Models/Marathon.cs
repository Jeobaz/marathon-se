using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Marathon
    {
        public Marathon()
        {
            Event = new HashSet<Event>();
        }

        [Key]
        public byte MarathonId { get; set; }
        [Required]
        [StringLength(80)]
        public string MarathonName { get; set; }
        [StringLength(80)]
        public string CityName { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }
        public short? YearHeld { get; set; }

        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.Marathon))]
        public virtual Country CountryCodeNavigation { get; set; }
        [InverseProperty("Marathon")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
