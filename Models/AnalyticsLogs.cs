using ActivityService.Models.Enums;

namespace ActivityService.Models
{
    public class AnalyticsLogs
    {
        public Guid Id { get; set; }

        public Guid ActivityId { get; set; }

        public Guid UserId { get; set; }

        public DateOnly LogDate { get; set; }

        public ActivityStatus Status { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        // Navigation Properties
        public Activity Activity { get; set; } = default!;
    }
}
