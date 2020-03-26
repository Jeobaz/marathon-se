using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Country
    {
        public Country()
        {
            Marathon = new HashSet<Marathon>();
            Runner = new HashSet<Runner>();
            Volunteer = new HashSet<Volunteer>();
        }

        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }

        public virtual ICollection<Marathon> Marathon { get; set; }
        public virtual ICollection<Runner> Runner { get; set; }
        public virtual ICollection<Volunteer> Volunteer { get; set; }
    }
}
