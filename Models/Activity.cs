using ActivityService.Models.Enums;

namespace ActivityService.Models
{
    public class Activity : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Title { get; set; } = null!;
        public string? Notes { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ActivityFrequencyType FrequencyType { get; set; }

        public int? TargetCount { get; set; } // e.g. 3 times/week

        public bool IsActive { get; set; } = true;

        public ICollection<ActivitySchedule> Schedules { get; set; } = new List<ActivitySchedule>();
        public ICollection<ActivityTracking> Logs { get; set; } = new List<ActivityTracking>();

        public ICollection<AnalyticsLogs> AnalyticsLogs { get; set; }
       = new List<AnalyticsLogs>();
    }
}
