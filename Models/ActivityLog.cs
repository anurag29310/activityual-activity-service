using ActivityService.Models.Enums;
using System.Diagnostics;

namespace ActivityService.Models
{
    public class ActivityLog : BaseEntity
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
