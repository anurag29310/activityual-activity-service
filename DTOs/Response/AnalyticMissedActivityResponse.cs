namespace ActivityService.DTOs.Response
{
    public class AnalyticMissedActivityResponse
    {
        public Guid ActivityId { get; set; }
        public string ActivityTitle { get; set; }
        public int MissedCount { get; set; }
        public DateTime? Date { get; set; } = new DateTime();
        public string Notes { get; set; }
        public Guid UserId { get; set; }

    }
}
