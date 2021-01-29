using System.Net;
using System.Threading.Tasks;
using Contracts;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using SampleObserver.API.DataProvider;

namespace SampleObserver.API.Controllers
{
    [ApiController]
    [Route("{tenant}/timeseries")]
    public class TimeSeriesController : ControllerBase
    {

        private readonly ITimeSeriesService _service;

        public TimeSeriesController(ITimeSeriesService service)
        {
            _service = service;
        }

        [HttpPut]
        public async Task<IActionResult> SubmitTimeSeries([FromBody]TimeSeriesRecord[] records)
        {
            await _service.SubmitTimeSeriesData(records);
            return Accepted();
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