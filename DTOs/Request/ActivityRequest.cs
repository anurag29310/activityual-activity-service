using ActivityService.Models;
using ActivityService.Models.Enums;

namespace ActivityService.DTOs.Request
{
    public class ActivityRequest 
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = null!;
        public string? Notes { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ActivityFrequencyType FrequencyType { get; set; }

        public int? TargetCount { get; set; } // e.g. 3 times/week

        public bool IsActive { get; set; } = true;
    }
}
