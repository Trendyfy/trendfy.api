using Microsoft.AspNetCore.Mvc;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ApiController : ControllerBase
    {
        public ApiController() { }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public string Welcome()
        {
            return "Welcome to TrendyFy API 1.0";
        }
    }
}
