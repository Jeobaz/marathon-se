using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class RegistrationStatus
    {
        public RegistrationStatus()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        public byte RegistrationStatusId { get; set; }
        [Required]
        [Column("RegistrationStatus")]
        [StringLength(80)]
        public string RegistrationStatus1 { get; set; }

        [InverseProperty("RegistrationStatus")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
