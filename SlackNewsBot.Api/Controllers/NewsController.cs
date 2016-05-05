using Microsoft.AspNet.Mvc;
using SlackNewsBot.Models;
using SlackNewsBot.Services;
using System.Threading.Tasks;

namespace SlackNewsBot.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsFetcher _newsFetcher;

        public NewsController(INewsFetcher newsFetcher)
        {
            _newsFetcher = newsFetcher;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] SlackRequestBody requestBody)
        {
            var numberOfItems = GetRequestedNumberOfItems(requestBody);

            return Ok(await GenerateResponseAsync(numberOfItems));
        }

        private static int GetRequestedNumberOfItems(SlackRequestBody requestBody)
        {
            int numberOfItems;

            if (int.TryParse(requestBody.Text, out numberOfItems))
            {
                numberOfItems = numberOfItems < 1 ? 1 : numberOfItems;
                numberOfItems = numberOfItems > 10 ? 10 : numberOfItems;
            }
            else
            {
                numberOfItems = 3;
            }

            return numberOfItems;
        }

        private async Task<SlackResponse> GenerateResponseAsync(int numberOfItems)
        {
            return new SlackResponse
            {
                Text = string.Format("{0} siste nyheter fra aftenposten.no", numberOfItems),
                Attachments = await _newsFetcher.GetNewsAsync(numberOfItems)
            };
        }
    }
}