using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Runner
    {
        public Runner()
        {
            Registration = new HashSet<Registration>();
        }

        public int RunnerId { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CountryCode { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual User EmailNavigation { get; set; }
        public virtual Gender GenderNavigation { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
