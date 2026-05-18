using ActivityService.DTOs.Request;
using ActivityService.DTOs.Response;
using Microsoft.OpenApi.Any;

namespace ActivityService.BusinessLogic.Interface
{
    public interface ITrackingService
    {
        Task<ActivityTrackingResponse> AddUserTrackingDataAsync(ActivityTrackingRequest request);

        Task<List<ActivityTrackingResponse>> AddBulkTrackingDataAsync(List<ActivityTrackingRequest> requests);

        Task<List<ActivityTrackingResponse>> GetAllUserTrackingDataAsync();

        Task<ActivityTrackingResponse?> GetUserTrackingDataByIdAsync(Guid id);

        Task<bool> DeleteUserTrackingDataByIdAsync(Guid id);
    }
}
