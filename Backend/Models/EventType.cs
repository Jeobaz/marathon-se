using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public string EventTypeId { get; set; }
        public string EventTypeName { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
