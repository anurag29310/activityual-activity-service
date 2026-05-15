using ActivityService.DTOs.Response;
using ActivityService.Models.Enums;

namespace ActivityService.DTOs.Request
{
    public class ActivityTrackingRequest
    {
        public Guid ActivityId { get; set; }
        public ActivityResponse Activity { get; set; } = null!;

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public ActivityStatus Status { get; set; }

        public int? ActualCount { get; set; } // e.g. pages read

        public string? Notes { get; set; }
    }
}
