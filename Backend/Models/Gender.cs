using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Runner = new HashSet<Runner>();
            Volunteer = new HashSet<Volunteer>();
        }

        public string Gender1 { get; set; }

        public virtual ICollection<Runner> Runner { get; set; }
        public virtual ICollection<Volunteer> Volunteer { get; set; }
    }
}
