﻿using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok();
        }
    }
}