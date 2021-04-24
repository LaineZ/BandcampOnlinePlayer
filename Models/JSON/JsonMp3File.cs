using Newtonsoft.Json;

namespace onlineplayer
{

    internal class JsonMp3File
    {

        [JsonProperty("mp3-128")]
        public string Url { get; set; }
    }
}