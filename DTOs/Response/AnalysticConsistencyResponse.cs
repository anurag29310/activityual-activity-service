namespace ActivityService.DTOs.Response
{
    public class AnalysticConsistencyResponse
    {
        public Guid ActivityId { get; set; }

        public string ActivityTitle { get; set; }

        public int ConsistencyPercentage { get; set; }

        public int TotalTracked { get; set; }

        public int CompletedTracked { get; set; }

    }
}
