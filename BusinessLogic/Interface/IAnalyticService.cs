
using ActivityService.DTOs.Response;

namespace ActivityService.BusinessLogic.Interface
{
    public interface IAnalyticService
    {
        Task<AnalyticsSummaryResponse> GetSummaryAsync();

        Task<List<AnalyticStreakResponse>> GetStreaksAsync();

        Task<AnalysticConsistencyResponse> GetConsistencyAsync();

        Task<List<AnalyticMissedActivityResponse>> GetMissedAsync();
    }
}
