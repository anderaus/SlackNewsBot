using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        [HttpPost]
        public IActionResult Post() {
            return Ok("Dette ser jo ut til å funke!");
        }
    }
}
