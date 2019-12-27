using Newtonsoft.Json;
using System.Collections.Generic;

namespace onlineplayer.Models
{
    internal class Json
    {
        public class DiscoverSpec
        {
            public int discover_id { get; set; }
            public int format_type_id { get; set; }
            public string tag_pretty_name { get; set; }
            public object genre_name { get; set; }
            public string spec_name { get; set; }
            public string format { get; set; }
            public object geoname_name { get; set; }
            public object genre_pretty_name { get; set; }
            public int genre_id { get; set; }
            public int geoname_id { get; set; }
            public string tag_name { get; set; }
            public long tag_id { get; set; }
            public bool dig_deeper_followed { get; set; }
        }

        public class AudioUrl
        {
            [JsonProperty("mp3-128")]
            public string mp3 { get; set; }
        }

        public class Item
        {
            public object art_id { get; set; }
            public string band_url { get; set; }
            public string tralbum_type { get; set; }
            public string band_name { get; set; }
            public string slug_text { get; set; }
            public object band_id { get; set; }
            public int featured_track_number { get; set; }
            public string genre { get; set; }
            public object tralbum_id { get; set; }
            public string item_type { get; set; }
            public string tralbum_url { get; set; }
            public int genre_id { get; set; }
            public int? is_preorder { get; set; }
            public object item_id { get; set; }
            public object audio_track_id { get; set; }
            public string featured_track_title { get; set; }
            public string artist { get; set; }
            public string subdomain { get; set; }
            public List<object> packages { get; set; }
            public int num_comments { get; set; }
            public string title { get; set; }
            public object custom_domain { get; set; }
            public AudioUrl audio_url { get; set; }
            public object custom_domain_verified { get; set; }
        }

        public class RootObject
        {
            public DiscoverSpec discover_spec { get; set; }
            public bool more_available { get; set; }
            public string filters { get; set; }
            public bool ok { get; set; }
            public List<Item> items { get; set; }
        }
    }
}
