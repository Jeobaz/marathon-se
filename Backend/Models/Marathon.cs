using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Marathon
    {
        public Marathon()
        {
            Event = new HashSet<Event>();
        }

        public byte MarathonId { get; set; }
        public string MarathonName { get; set; }
        public string CityName { get; set; }
        public string CountryCode { get; set; }
        public short? YearHeld { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
