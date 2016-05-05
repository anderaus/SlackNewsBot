using Microsoft.AspNet.Mvc;
using System.Collections.Generic;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Dette ser jo ut til å funke!");
        }
    }
}