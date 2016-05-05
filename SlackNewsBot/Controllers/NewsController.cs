using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SlackNewsBot.Models;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {       
        [HttpPost]
        public IActionResult Post([FromBody] SlackRequestBody requestBody) {
            return Ok(requestBody.UserName);
        }
    }
}