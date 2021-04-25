using BandcampOnlinePlayer.Models.JSON;
using Newtonsoft.Json;
using onlineplayer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BandcampOnlinePlayer.Core
{
    public class Discover
    {
        private JsonDiscoverQuery.Root DiscoverQuery;
        public int Page { get; set; }
        public List<JsonDiscover.Item> Content = new List<JsonDiscover.Item>();
        private int MaxLoad { get; }
        private readonly HttpClient client = new HttpClient();

        // TODO: make enums
        public Discover(List<string> tags, string format = "all", string sort = "pop", int location = 0, int page = 1, int maxLoad = 2)
        {
            Page = page;
            MaxLoad = maxLoad;
            DiscoverQuery = new JsonDiscoverQuery.Root()
            {
                page = Page,
                filters = new JsonDiscoverQuery.Filters()
                {
                    format = format,
                    location = location,
                    sort = sort,
                    tags = tags
                }
            };
        }


        public async Task GetDiscover()
        {
            for (int i = Page; i < Page + MaxLoad; i++)
            {
                HttpContent c = new StringContent(JsonConvert.SerializeObject(DiscoverQuery), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://bandcamp.com/api/hub/2/dig_deeper", c);
                string responseString = await response.Content.ReadAsStringAsync();
                Page = i;

                try
                {
                    JsonDiscover.RootObject discover = JsonConvert.DeserializeObject<JsonDiscover.RootObject>(responseString);

                    if (!discover.more_available)
                    {
                        break;
                    }

                    if (discover.items.Any())
                    {
                        foreach (var item in discover.items)
                        {
                            Content.Add(item);
                        }
                    }
                }
                catch (JsonSerializationException)
                {
                    Log.Warning("cannot find tracks for request");
                }
            }
        }
    }
}
