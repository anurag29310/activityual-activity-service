using System.Diagnostics;

namespace ActivityService.Models
{
    public class ActivitySchedule : BaseEntity
    {
        public Guid ActivityId { get; set; }
        public Activity Activity { get; set; } = null!;

        public DayOfWeek? DayOfWeek { get; set; }

        public TimeSpan? PreferredTime { get; set; }

        public int? RepeatIntervalDays { get; set; } // for custom frequency
    }
}
