
using ActivityService.DTOs.Response;

namespace ActivityService.BusinessLogic.Interface
{
    public interface IAnalyticService
    {
        Task<AnalyticsSummaryResponse> GetSummaryAsync();

        Task<AnalyticStreakResponse> GetStreaksAsync();

        Task<AnalysticConsistencyResponse> GetConsistencyAsync();

        Task<AnalyticMissedActivityResponse> GetMissedAsync();
    }
}
