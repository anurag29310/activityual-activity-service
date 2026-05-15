using ActivityService.DTOs.Request;
using ActivityService.DTOs.Response;
using ActivityService.Models;

namespace ActivityService.BusinessLogic.Interface
{
    public interface IActivityService
    {
        Task<List<Activity>> GetUserActivityAsync();

        Task<string> CreateUserActivityAsync(ActivityRequest activity);

        Task<ActivityResponse> GetUserActivityByIdAsync(string id);

        Task<string> UpdateUserAcitivityByIdAsync(ActivityRequest activity); 

        Task<string> DeleteUserAcitivityByIdAsync(string activity);

       Task CompleteActivity();
    }
}
