namespace ActivityService.DTOs.Response
{
    public class AnalyticsSummaryResponse
    {
        public int TotalActivities { get; set; }

        public int CompletedCount { get; set; }

        public int MissedCount { get; set; }

        public decimal ConsistencyPercentage { get; set; }
    }
}
