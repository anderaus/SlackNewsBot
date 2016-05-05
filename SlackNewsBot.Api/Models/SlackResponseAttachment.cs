using Newtonsoft.Json;

namespace SlackNewsBot.Models
{
    public class SlackResponseAttachment
    {
        public string Title { get; set; }

        [JsonProperty("title_link")]
        public string Link { get; set; }

        public string Text { get; set; }

        [JsonProperty("thumb_url")]
        public string ThumbnailUrl { get; set; }
    }
}