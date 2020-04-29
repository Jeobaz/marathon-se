using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public partial class Charity
    {
        public Charity()
        {
            Registration = new HashSet<Registration>();
        }
        public int CharityId { get; set; }
        [Required]
        public string CharityName { get; set; }
        [Required]
        public string CharityDescription { get; set; }
        [Required]
        public string CharityLogo { get; set; }

        public virtual ICollection<Registration> Registration { get; set; }
    }
}
