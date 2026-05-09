using ActivityService.Models;

namespace IdentityService.BusinessLogic.Interface
{
    public interface IActivityService
    {
        Task<List<UserActivity>> GetUserActivityAsync();

        Task<UserActivity> CreateUserActivityAsync(UserActivity activity);

        Task<UserActivity> GetUserActivityByIdAsync(string id);

        Task<UserActivity> UpdateUserAcitivityByIdAsync(UserActivity activity); 

        Task<string> DeleteUserAcitivityByIdAsync(string activity); 
    }
}
