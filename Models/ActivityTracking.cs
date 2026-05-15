using ActivityService.Models.Enums;

namespace ActivityService.Models
{
    public class ActivityTracking : BaseEntity
    {
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public ActivityStatus Status { get; set; }

        public int? ActualCount { get; set; } // e.g. pages read

        public string? Notes { get; set; }
    }
}
