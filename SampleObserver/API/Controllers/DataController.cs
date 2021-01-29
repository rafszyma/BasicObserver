using System.Net;
using System.Threading.Tasks;
using API.Services;
using Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("data")]
    public class DataController : ControllerBase
    {
        
        private readonly ITimeSeriesService _service;
        
        public DataController(ITimeSeriesService service)
        {
            _service = service;
        }
        
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> SubmitTimeSeries([FromBody]TimeSeriesModel[] records)
        {
            await _service.SubmitTimeSeriesData(records);
            return Accepted();
        }
    }
}