using ActivityService.BusinessLogic.Interface;
using ActivityService.DTOs.Response;
using Microsoft.OpenApi.Any;

namespace ActivityService.BusinessLogic.Implementation
{
    public class AnalyticService : IAnalyticService
    {
        public Task<AnalysticConsistencyResponse> GetConsistencyAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnalyticMissedActivityResponse> GetMissedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnalyticStreakResponse> GetStreaksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnalyticsSummaryResponse> GetSummaryAsync()
        {
            throw new NotImplementedException();
        }
    }
}
