
namespace ActivityService.DTOs.Request
{
    public class ActivityScheduleRequest 
    {
        public Guid ActivityId { get; set; }

        public DayOfWeek? DayOfWeek { get; set; }

        public TimeSpan? PreferredTime { get; set; }

        public int? RepeatIntervalDays { get; set; } // for custom frequency
    }
}
