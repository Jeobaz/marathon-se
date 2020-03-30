using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class RaceKitOption
    {
        public RaceKitOption()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        [StringLength(1)]
        public string RaceKitOptionId { get; set; }
        [Required]
        [Column("RaceKitOption")]
        [StringLength(80)]
        public string RaceKitOption1 { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cost { get; set; }

        [InverseProperty("RaceKitOption")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
