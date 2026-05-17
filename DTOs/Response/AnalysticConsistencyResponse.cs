namespace ActivityService.DTOs.Response
{
    public class AnalysticConsistencyResponse
    {
        public Guid ActivityId { get; set; }

        public string ActivityTitle { get; set; }

        public decimal ConsistencyPercentage { get; set; }
    }
}
