using Microsoft.AspNet.Mvc;
using SlackNewsBot.Models;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody] SlackRequestBody requestBody)
        {
            return Ok(requestBody.UserName);
        }
    }
}