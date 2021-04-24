using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineplayer.Models.JSON
{
    public static class JsonSearch
    {
        public class Result
        {
            public string url { get; set; }
            public string band_name { get; set; }
            public object band_id { get; set; }
            public object art_id { get; set; }
            public string part { get; set; }
            public object img_id { get; set; }
            public string type { get; set; }
            public long album_id { get; set; }
            public string album_name { get; set; }
            public string stat_params { get; set; }
            public object id { get; set; }
            public string name { get; set; }
            public string img { get; set; }
        }

        public class Auto
        {
            public int time_ms { get; set; }
            public List<Result> results { get; set; }
            public string stat_params_for_tag { get; set; }
        }

        public class Genre
        {
        }

        public class Match
        {
            public int score { get; set; }
            public int count { get; set; }
            public string norm_name { get; set; }
            public string display_name { get; set; }
            public long display_tag_id { get; set; }
        }

        public class Tag
        {
            public int count { get; set; }
            public List<Match> matches { get; set; }
            public int time_ms { get; set; }
        }

        public class RootObject
        {
            public Auto auto { get; set; }
            public Genre genre { get; set; }
            public Tag tag { get; set; }
        }
    }
}
