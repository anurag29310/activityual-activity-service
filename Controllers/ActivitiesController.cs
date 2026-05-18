using ActivityService.BusinessLogic.Interface;
using ActivityService.DTOs.Request;
using ActivityService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActivityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _IActivityService;

        public ActivitiesController(IActivityService IActivityService)
        {
            _IActivityService = IActivityService;
        }

        [HttpGet("getActivity")]
        public async Task<IActionResult> GetUserActivity()
        {
            var data = await _IActivityService.GetUserActivityAsync();
            return Ok(data);
        }

        [HttpPost("addActivity")]
        public async Task<IActionResult> AddUserActivity(ActivityRequest activity)
        {
            await _IActivityService.CreateUserActivityAsync(activity);

            return Ok(activity);
        }

        [HttpGet("getActivityById")]
        public async Task<IActionResult> GetUserActivityById(string id)
        {
            var data = await _IActivityService.GetUserActivityByIdAsync(id);
            return Ok(data);
        }

        [HttpPatch("updateActivity")]
        public async Task<IActionResult> UpdateUserActivityById(ActivityRequest activity)
        { 
            var data = await _IActivityService.UpdateUserAcitivityByIdAsync(activity);
            return Ok(data);
        }

        [HttpDelete("removeActivity")]
        public async Task<IActionResult> DeleteUserActivityById(string id)
        {
            var data = await _IActivityService.DeleteUserAcitivityByIdAsync(id);
            return Ok(data); 
        }
    }
}
