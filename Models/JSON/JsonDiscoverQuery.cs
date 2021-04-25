using System;
using System.Collections.Generic;
using System.Text;

namespace BandcampOnlinePlayer.Models.JSON
{
    public class JsonDiscoverQuery
    {
        public class Filters
        {
            public string format { get; set; }
            public int location { get; set; }
            public string sort { get; set; }
            public List<string> tags { get; set; }
        }

        public class Root
        {
            public Filters filters { get; set; }
            public int page { get; set; }
        }
    }
}
