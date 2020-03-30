using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Runner
    {
        public Runner()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        public int RunnerId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [ForeignKey(nameof(CountryCode))]
        [InverseProperty(nameof(Country.Runner))]
        public virtual Country CountryCodeNavigation { get; set; }
        [ForeignKey(nameof(Email))]
        [InverseProperty(nameof(User.Runner))]
        public virtual User EmailNavigation { get; set; }
        [ForeignKey(nameof(Gender))]
        [InverseProperty("Runner")]
        public virtual Gender GenderNavigation { get; set; }
        [InverseProperty("Runner")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
