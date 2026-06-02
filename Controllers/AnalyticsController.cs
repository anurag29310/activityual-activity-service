using ActivityService.BusinessLogic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActivityService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticService _analyticsService;

        public AnalyticsController(IAnalyticService analyticService)
        {
            _analyticsService = analyticService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> Summary()
        {
            var data = await _analyticsService.GetSummaryAsync();

            return Ok(data);
        }

        [HttpGet("streaks")]
        public async Task<IActionResult> Streaks()
        {
            var data = await _analyticsService.GetStreaksAsync();

            return Ok(data);
        }

        [HttpGet("consistency")]
        public async Task<IActionResult> Consistency()
        {
            var data = await _analyticsService.GetConsistencyAsync();

            return Ok(data);
        }

        [HttpGet("missed")]
        public async Task<IActionResult> Missed()
        {
            var data = await _analyticsService.GetMissedAsync();

            return Ok(data);
        }
    }
}