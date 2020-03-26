using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class Registration
    {
        public Registration()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
            Sponsorship = new HashSet<Sponsorship>();
        }

        public int RegistrationId { get; set; }
        public int RunnerId { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public string RaceKitOptionId { get; set; }
        public byte RegistrationStatusId { get; set; }
        public decimal Cost { get; set; }
        public int CharityId { get; set; }
        public decimal SponsorshipTarget { get; set; }

        public virtual Charity Charity { get; set; }
        public virtual RaceKitOption RaceKitOption { get; set; }
        public virtual RegistrationStatus RegistrationStatus { get; set; }
        public virtual Runner Runner { get; set; }
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
        public virtual ICollection<Sponsorship> Sponsorship { get; set; }
    }
}
