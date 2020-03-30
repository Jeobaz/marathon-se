
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public partial class Charity
    {
        public Charity()
        {
            Registration = new HashSet<Registration>();
        }

        [Key]
        public int CharityId { get; set; }
        [Required]
        [StringLength(100)]
        public string CharityName { get; set; }
        [StringLength(2000)]
        public string CharityDescription { get; set; }
        [StringLength(50)]
        public string CharityLogo { get; set; }

        [InverseProperty("Charity")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
