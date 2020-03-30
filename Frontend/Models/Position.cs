using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Position
    {
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        [Key]
        public byte PositionId { get; set; }
        [Required]
        [StringLength(50)]
        public string PositionName { get; set; }
        [StringLength(1000)]
        public string PositionDescription { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Payrate { get; set; }

        [InverseProperty("Postion")]
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
