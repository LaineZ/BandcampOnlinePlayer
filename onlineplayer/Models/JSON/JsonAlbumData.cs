using Newtonsoft.Json;

namespace onlineplayer
{

    internal class JsonAlbumData
    {

        [JsonProperty("title")]
        public string AlbumTitle { get; set; }
    }
}