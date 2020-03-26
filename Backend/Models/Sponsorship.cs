using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Sponsorship
    {
        public int SponsorshipId { get; set; }
        public string SponsorName { get; set; }
        public int RegistrationId { get; set; }
        public decimal Amount { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
