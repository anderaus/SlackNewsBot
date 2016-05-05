using Microsoft.AspNet.Mvc;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new
            {
                Status = "Very much alive!"
            });
        }
    }
}