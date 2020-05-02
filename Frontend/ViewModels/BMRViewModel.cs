using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    public class BMRViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int? Height { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? Weight { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int? Age { get; set; }
    }
}