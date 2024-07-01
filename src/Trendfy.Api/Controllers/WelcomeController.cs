using Microsoft.AspNetCore.Mvc;

namespace Trendfy.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class WelcomeController : ControllerBase
    {
        public WelcomeController() { }

        [HttpGet]
        public string Welcome(string email, CancellationToken cancellationToken)
        {
            return "Welcome to TrendyFy API 1.0";
        }
    }
}
