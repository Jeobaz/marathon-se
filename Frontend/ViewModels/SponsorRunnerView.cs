using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models;
using Frontend.Models;

namespace Frontend.ViewModels
{
    public enum TypeExprires
    {
        Month,
        Year
    }
    public class SponsorRunnerView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string RunnerId { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required]
        [IntegerValidator(16, ErrorMessage = "Credit card must be 16 digits")]
        public string CreditCard { get; set; }

        [Required]
        [ExpiryDateValidator(ErrorMessage = "Error expiry date")]
        public ExpiryDate ExpiryDate { get; set; }

        [Required]
        [IntegerValidator(3, ErrorMessage = "CVC digits = 3")]
        public string CVC { get; set; }
        [Required]
        [Range(10, 1000000)]
        public int Amount { get; set; }

        public Registration Register { get; set; }

    }
    public class ExpiryDateValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var expDate = value as ExpiryDate;
            if (expDate != null &&
                int.TryParse(expDate.Month, out int month) &&
                int.TryParse(expDate.Year, out int year))
            {
                var now = DateTime.Now;
                var currentDate = new DateTime(now.Year, now.Month, 1);
                var otherDate = new DateTime(year, month, 1);
                return otherDate >= currentDate;
            }

            return false;
        }
    }

    public class IntegerValidator : ValidationAttribute
    {
        private int digits;
        public IntegerValidator(int digits)
        {
            this.digits = digits;
        }
        public override bool IsValid(object value)
        {

            return value.ToString().All(x => int.TryParse(x.ToString(), out var dummy)) && value.ToString().Length == digits;
        }
    }
}
