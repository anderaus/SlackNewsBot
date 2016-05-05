using SlackNewsBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SlackNewsBot.Services
{
    public interface INewsFetcher
    {
        Task<IEnumerable<SlackResponseAttachment>> GetNewsAsync(int numberOfItems = 5);
    }
}