using SlackNewsBot.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SlackNewsBot.Services
{
    public class RSSNewsFetcher : INewsFetcher
    {
        private const string FeedUrl = "http://www.aftenposten.no/rss";

        public async Task<IEnumerable<SlackResponseAttachment>> GetNewsAsync(int numberOfItems = 5)
        {
            var result = new List<SlackResponseAttachment>();

            var xml = await DownloadAsync(FeedUrl);
            if (xml == null) return result;

            foreach (var item in xml.Descendants("item"))
            {
                result.Add(new SlackResponseAttachment
                {
                    Title = item.Element("title")?.Value,
                    Text = item.Element("description")?.Value,
                    Link = item.Element("link")?.Value,
                    ThumbnailUrl = item.Element("enclosure")?.Attribute("url")?.Value
                });
            }

            return result.Take(numberOfItems);
        }

        protected async Task<XDocument> DownloadAsync(string url)
        {
            XDocument document = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    document = XDocument.Parse(content);
                }
            }

            return document;
        }
    }
}
