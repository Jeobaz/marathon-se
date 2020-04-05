using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    public class RegisterRunnerView
    {   
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"((?=.*\d)(?=[a-z]{0,})(?=.*[A-Z])(?=.*[!@#$%^]).{6,})",
                           ErrorMessage = "Password must contain: 1 digit, 1 uppercase and special symbols: !@#$%^")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [OldValidator(10, ErrorMessage = "The runner must be at least 10 years old")]
        public DateTime DateBirth { get; set; }

        [Required]
        public string GenderId { get; set; }
        [Required]
        public string CountryId { get; set; }
    }

    public class OldValidator : ValidationAttribute
    {
        private int _years;
        public OldValidator(int years)
        {
            _years = years;
        }
        public override bool IsValid(object value)
        {
            var dateBirth = (DateTime)value;
            var currentDate = DateTime.Now;
            var diffYears = currentDate.Year - dateBirth.Year;

            return diffYears >= _years;
        }
    }
}
