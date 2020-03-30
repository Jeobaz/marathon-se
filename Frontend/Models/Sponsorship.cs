using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Sponsorship
    {
        [Key]
        public int SponsorshipId { get; set; }
        [Required]
        [StringLength(150)]
        public string SponsorName { get; set; }
        public int RegistrationId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [ForeignKey(nameof(RegistrationId))]
        [InverseProperty("Sponsorship")]
        public virtual Registration Registration { get; set; }
    }
}
