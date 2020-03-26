using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class RegistrationEvent
    {
        public int RegistrationEventId { get; set; }
        public int RegistrationId { get; set; }
        public string EventId { get; set; }
        public short? BibNumber { get; set; }
        public int? RaceTime { get; set; }

        public virtual Event Event { get; set; }
        public virtual Registration Registration { get; set; }
    }
}
