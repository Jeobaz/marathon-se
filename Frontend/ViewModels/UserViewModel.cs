using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.ViewModels
{
    public class UserViewModel
    {
        [RegularExpression(@"((?=.*\d)(?=[a-z]{0,})(?=.*[A-Z])(?=.*[!@#$%^]).{6,})",
                           ErrorMessage = "Password must contain: 1 digit, 1 uppercase and special symbols: !@#$%^")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string RoleId { get; set; }
    }

    public class UserViewModelPasswords
    {
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
        public string Email { get; set; }
        [Required]
        public string RoleId { get; set; }
    }
}
