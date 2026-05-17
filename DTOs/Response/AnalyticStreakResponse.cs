namespace ActivityService.DTOs.Response
{
    public class AnalyticStreakResponse
    {
        public Guid ActivityId { get; set; }

        public string ActivityTitle { get; set; }

        public int CurrentStreak { get; set; }

        public int LongestStreak { get; set; }
    }
}
