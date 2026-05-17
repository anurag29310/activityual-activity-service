namespace ActivityService.DTOs.Response
{
    public class AnalyticMissedActivityResponse
    {
        public Guid ActivityId { get; set; }

        public string ActivityTitle { get; set; }

        public int MissedCount { get; set; }
    }
}
