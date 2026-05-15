
namespace ActivityService.DTOs.Response
{
    public class ActivityScheduleResponse 
    {
        public Guid ActivityId { get; set; }
        public System.Diagnostics.Activity Activity { get; set; } = null!;

        public DayOfWeek? DayOfWeek { get; set; }

        public TimeSpan? PreferredTime { get; set; }

        public int? RepeatIntervalDays { get; set; } // for custom frequency
    }
}
