using ActivityService.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ActivityService.Controllers
{
    [ApiController]
    [Route("api/tracking")]
    public class TrackingController : Controller
    {
        private readonly ITrackingService _trackingService;

        public TrackingController(ITrackingService trackingService)
        {
            _trackingService = trackingService;
        }

        [HttpPost("addTracking")]
        public IActionResult AddUserTrackingDataAsync()
        {
            var trackingService = _trackingService.AddUserTrackingDataAsync();
            return View();
        }

        [HttpPost("addBulkTracking")]
        public IActionResult AddBulkTrackingDataAsync()
        {
            var trackingService = _trackingService.AddBulkTrackingDataAsync();
            return View();
        }

        [HttpGet("trackingData")]
        public IActionResult GetAllUserTrackingDataAsync()
        {
            var trackingService = _trackingService.GetAllUserTrackingDataAsync();
            return View();
        }

        [HttpGet("trackingDataById")]
        public IActionResult GetUserTrackingDataByIdAsync(string id)
        {
            var trackingService = _trackingService.GetUserTrackingDataByIdAsync();
            return View();
        }

        [HttpDelete("removeTracking")]
        public IActionResult DeleteUserTrackingDataByIdAsync()
        {
            var trackingService = _trackingService.DeleteUserTrackingDataByIdAsync();
            return View();
        }
    }
}
