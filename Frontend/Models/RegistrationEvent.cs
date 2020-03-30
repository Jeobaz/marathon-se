using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class RegistrationEvent
    {
        [Key]
        public int RegistrationEventId { get; set; }
        public int RegistrationId { get; set; }
        [Required]
        [StringLength(6)]
        public string EventId { get; set; }
        public short? BibNumber { get; set; }
        public int? RaceTime { get; set; }

        [ForeignKey(nameof(EventId))]
        [InverseProperty("RegistrationEvent")]
        public virtual Event Event { get; set; }
        [ForeignKey(nameof(RegistrationId))]
        [InverseProperty("RegistrationEvent")]
        public virtual Registration Registration { get; set; }
    }
}
