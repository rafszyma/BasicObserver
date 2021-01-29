using System.Net;
using System.Threading.Tasks;
using API.Services;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("{tenant}/stats")]
    public class TimeSeriesController : ControllerBase
    {
        private readonly ITimeSeriesService _service;

        public TimeSeriesController(ITimeSeriesService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(TimeSeriesStatsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetStatistics([FromQuery]long from, [FromQuery]long to)
        {
            var (average, sum) = await _service.GetTimeSeriesStatsAsync(from, to);
            return Ok(new TimeSeriesStatsResponse
            {
                Avg = average,
                Sum = sum
            });
        }
    }
}