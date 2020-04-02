using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class ExpiryDate
    {
        [StringLength(2)]
        public string Month { get; set; }
        [StringLength(4)]
        public string Year { get; set; }
    }
}
