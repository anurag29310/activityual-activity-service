using ActivityService.BusinessLogic.Interface;
using ActivityService.DTOs.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpPost("addTracking")]
        public async Task<IActionResult> AddUserTrackingDataAsync(
            [FromBody] ActivityTrackingRequest request)
        {
            var result = await _trackingService.AddUserTrackingDataAsync(request);

            return Ok(result);
        }

        [HttpPost("addBulkTracking")]
        public async Task<IActionResult> AddBulkTrackingDataAsync(
            [FromBody] List<ActivityTrackingRequest> requests)
        {
            var result = await _trackingService.AddBulkTrackingDataAsync(requests);

            return Ok(result);
        }

        [HttpGet("trackingData")]
        public async Task<IActionResult> GetAllUserTrackingDataAsync()
        {
            var result = await _trackingService.GetAllUserTrackingDataAsync();

            return Ok(result);
        }

        [HttpGet("trackingDataById/{id}")]
        public async Task<IActionResult> GetUserTrackingDataByIdAsync(Guid id)
        {
            var result = await _trackingService.GetUserTrackingDataByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("removeTracking/{id}")]
        public async Task<IActionResult> DeleteUserTrackingDataByIdAsync(Guid id)
        {
            var result = await _trackingService.DeleteUserTrackingDataByIdAsync(id);

            if (!result)
                return NotFound();

            return Ok("Tracking deleted successfully.");
        }
    }
}