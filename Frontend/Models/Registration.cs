using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Registration
    {
        public Registration()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
            Sponsorship = new HashSet<Sponsorship>();
        }

        [Key]
        public int RegistrationId { get; set; }
        public int RunnerId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RegistrationDateTime { get; set; }
        [Required]
        [StringLength(1)]
        public string RaceKitOptionId { get; set; }
        public byte RegistrationStatusId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }
        public int CharityId { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal SponsorshipTarget { get; set; }

        [ForeignKey(nameof(CharityId))]
        [InverseProperty("Registration")]
        public virtual Charity Charity { get; set; }
        [ForeignKey(nameof(RaceKitOptionId))]
        [InverseProperty("Registration")]
        public virtual RaceKitOption RaceKitOption { get; set; }
        [ForeignKey(nameof(RegistrationStatusId))]
        [InverseProperty("Registration")]
        public virtual RegistrationStatus RegistrationStatus { get; set; }
        [ForeignKey(nameof(RunnerId))]
        [InverseProperty("Registration")]
        public virtual Runner Runner { get; set; }
        [InverseProperty("Registration")]
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
        [InverseProperty("Registration")]
        public virtual ICollection<Sponsorship> Sponsorship { get; set; }
    }
}
