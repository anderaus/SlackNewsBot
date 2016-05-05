using SlackNewsBot.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackNewsBot.Services
{
    public class HardcodedNewsFetcher : INewsFetcher
    {
        public async Task<IEnumerable<SlackResponseAttachment>> GetNewsAsync(int numberOfItems = 5)
        {
            if (numberOfItems < 1)
            {
                return await Task.FromResult(new List<SlackResponseAttachment>());
            }

            return await Task.FromResult(GetHardcodedNews().Take(numberOfItems > 3 ? 3 : numberOfItems));
        }

        private static IEnumerable<SlackResponseAttachment> GetHardcodedNews()
        {
            yield return new SlackResponseAttachment
            {
                Title = "17:50 - Syv russebusser fikk kjøreforbud",
                Text = "Syv av tolv kontrollerte busser fikk kjøreforbud. Men i morgen er de på vei til Kongeparken.",
                Link = "http://www.aftenposten.no/nyheter/iriks/Syv-russebusser-fikk-kjoreforbud-8457868.html#xtor=RSS-3",
                ThumbnailUrl = "http://ap.mnocdn.no/incoming/article8457876.ece/alternates/w180c169/blackJack.jpg?updated=050520161740"
            };

            yield return new SlackResponseAttachment
            {
                Title = "12:06 - 100 sjåfører tatt, 13 av dem mistet lappen.",
                Text = "«Nedslående», fastslår Utrykningspolitiet på Vestlandet, etter at et tresifret antall bilister råkjørte forbi UPs lasere.",
                Link = "http://www.aftenposten.no/nyheter/iriks/-100-sjaforer-tatt_-13-av-dem-mistet-lappen-8457691.html#xtor=RSS-3",
                ThumbnailUrl = "http://ap.mnocdn.no/migration_catalog/article6140812.ece/alternates/w180c169/Politi%20m%C3%A5ler%20farten%20-laser%20topp.jpg?updated=150620050840"
            };

            yield return new SlackResponseAttachment
            {
                Title = "10:14 - Fjellturister advares: Stor snøskredfare i fjellet i Sør-Norge",
                Text = "De varslede temperaturstigningen i Sør-Norge øker snøskredfaren i fjellet. NVE ber folk sjekke forholdene nøye før de legger ut på tur.",
                Link = "http://www.aftenposten.no/nyheter/iriks/Fjellturister-advares-Stor-snoskredfare-i-fjellet-i-Sor-Norge-8457581.html#xtor=RSS-3"
            };
        }
    }
}