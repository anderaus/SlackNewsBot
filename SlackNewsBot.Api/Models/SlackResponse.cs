using System.Collections.Generic;

namespace SlackNewsBot.Models
{
    public class SlackResponse
    {
        public string Text { get; set; }
        public IEnumerable<SlackResponseAttachment> Attachments { get; set; }
    }
}