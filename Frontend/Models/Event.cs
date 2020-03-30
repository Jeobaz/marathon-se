using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Event
    {
        public Event()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
        }

        [Key]
        [StringLength(6)]
        public string EventId { get; set; }
        [Required]
        [StringLength(50)]
        public string EventName { get; set; }
        [Required]
        [StringLength(2)]
        public string EventTypeId { get; set; }
        public byte MarathonId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? Cost { get; set; }
        public short? MaxParticipants { get; set; }

        [ForeignKey(nameof(EventTypeId))]
        [InverseProperty("Event")]
        public virtual EventType EventType { get; set; }
        [ForeignKey(nameof(MarathonId))]
        [InverseProperty("Event")]
        public virtual Marathon Marathon { get; set; }
        [InverseProperty("Event")]
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
    }
}
