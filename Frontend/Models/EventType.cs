using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        [Key]
        [StringLength(2)]
        public string EventTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string EventTypeName { get; set; }

        [InverseProperty("EventType")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
