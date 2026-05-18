using ActivityService.Models.Enums;

namespace ActivityService.DTOs.Response
{
    public class ActivityTrackingResponse
    {
        public Guid ActivityId { get; set; }
        public System.Diagnostics.Activity Activity { get; set; } = null!;

        public Guid UserId { get; set; }

        public DateTime? Date { get; set; }

        public ActivityStatus Status { get; set; }

        public int? ActualCount { get; set; } // e.g. pages read

        public string? Notes { get; set; }
    }
}
