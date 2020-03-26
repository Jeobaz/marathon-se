using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public partial class RegistrationStatus
    {
        public RegistrationStatus()
        {
            Registration = new HashSet<Registration>();
        }

        public byte RegistrationStatusId { get; set; }
        public string RegistrationStatus1 { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
