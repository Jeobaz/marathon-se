using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Gender GenderNavigation { get; set; }
    }
}
