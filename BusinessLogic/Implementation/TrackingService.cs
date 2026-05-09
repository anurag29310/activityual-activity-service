using ActivityService.BusinessLogic.Interface;
using Microsoft.OpenApi.Any;

namespace ActivityService.BusinessLogic.Implementation
{
    public class TrackingService : ITrackingService
    {
        public Task<List<int>> AddBulkTrackingDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddUserTrackingDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserTrackingDataByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AnyType>> GetAllUserTrackingDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnyType> GetUserTrackingDataByIdAsync()
        {
            throw new NotImplementedException();
        }
    }
}
