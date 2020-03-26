using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class RaceKitOption
    {
        public RaceKitOption()
        {
            Registration = new HashSet<Registration>();
        }

        public string RaceKitOptionId { get; set; }
        public string RaceKitOption1 { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
