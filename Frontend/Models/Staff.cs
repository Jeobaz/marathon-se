using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend.Models
{
    public partial class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(80)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        public byte PostionId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(2000)]
        public string Comments { get; set; }

        [ForeignKey(nameof(PostionId))]
        [InverseProperty(nameof(Position.Staff))]
        public virtual Position Postion { get; set; }
    }
}
