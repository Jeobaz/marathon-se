using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Charity
    {
        public Charity()
        {
            Registration = new HashSet<Registration>();
        }

        public int CharityId { get; set; }
        public string CharityName { get; set; }
        public string CharityDescription { get; set; }
        public string CharityLogo { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
