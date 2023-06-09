using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimbleIntegration.Controllers
{
    [Route("LimbleApi")]
    [ApiController]
    public class LimbleApiController : ControllerBase
    {
        private readonly LimbleApiClient _limbleApiClient;

        public LimbleApiController(LimbleApiClient limbleApiClient)
        {
            _limbleApiClient = limbleApiClient;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetData(string endpoint)
        {
            try
            {
                string apiData = await _limbleApiClient.GetApiData(endpoint);
                return Ok(apiData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}