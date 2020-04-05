using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Frontend.ViewModels
{
    public class RegisterForEventView
    {
        [Required(ErrorMessage = "Race kit option is required")]
        public string RaceKitOptionId { get; set; }
        [Required(ErrorMessage = "Charity is required")]
        public string CharityId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Target to raise must be a positive value.")]
        public decimal SponsorTarget { get; set; }

        [Required]
        [ListCountValidator(1, ErrorMessage = "At least 1 event must be chosen.")]
        public List<(string eventId, int eventCost)> EventData { get; set; }
    }

    public class ListCountValidator : ValidationAttribute
    {
        private int _minCount, _maxCount;
        public ListCountValidator(int minCount, int maxCount = int.MaxValue)
        {
            _minCount = minCount;
            _maxCount = maxCount;
        }

        public override bool IsValid(object value)
        {
            var evntIds = value as List<(string, int)>;
            if (evntIds != null)
                return evntIds.Count >= _minCount && evntIds.Count <= _maxCount;

            return false;
        }
    }
}
