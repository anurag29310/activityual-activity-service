using Microsoft.OpenApi.Any;

namespace ActivityService.BusinessLogic.Interface
{
    public interface ITrackingService
    {
        Task<int> AddUserTrackingDataAsync();

        Task<List<int>> AddBulkTrackingDataAsync();

        Task<AnyType> GetUserTrackingDataByIdAsync();

        Task<List<AnyType>> GetAllUserTrackingDataAsync();

        Task<bool> DeleteUserTrackingDataByIdAsync();
    }
}
