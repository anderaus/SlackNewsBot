using Microsoft.AspNet.Mvc;
using SlackNewsBot.Models;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromForm] SlackRequestBody requestBody)
        {
            return Ok(GenerateResponse(requestBody));
        }

        private static string GenerateResponse(SlackRequestBody requestBody)
        {
            return string.Format("Hi, {0}! Thanks for passing in '{1}'. (I have no idea what to do with it)",
                requestBody.User_Name, requestBody.Text);
        }
    }
}