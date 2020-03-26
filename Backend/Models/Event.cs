using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Event
    {
        public Event()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
        }

        public string EventId { get; set; }
        public string EventName { get; set; }
        public string EventTypeId { get; set; }
        public byte MarathonId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public decimal? Cost { get; set; }
        public short? MaxParticipants { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual Marathon Marathon { get; set; }
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
    }
}
