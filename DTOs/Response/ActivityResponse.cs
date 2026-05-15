using ActivityService.DTOs.Common;
using ActivityService.Models.Enums;

namespace ActivityService.DTOs.Response
{
    public class ActivityResponse 
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = null!;
        public string? Notes { get; set; }

        public Guid CategoryId { get; set; }
        public CategoryRequestResponse Category { get; set; } = null!;

        public ActivityFrequencyType FrequencyType { get; set; }

        public int? TargetCount { get; set; } // e.g. 3 times/week

        public bool IsActive { get; set; } = true;
    }
}
