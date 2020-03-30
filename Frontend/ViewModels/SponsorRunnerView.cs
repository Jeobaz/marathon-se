using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models;

namespace Frontend.ViewModels
{
    public class SponsorRunnerView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string RunnerId { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required, CreditCard]
        public string CreditCard { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "CVC length = 3")]
        public string CVC { get; set; }
        [Required]
        [Range(10, 1000000)]
        public int Amount { get; set; }

        public Registration Register { get; set; }

    }
}
