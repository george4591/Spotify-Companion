using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyCompanion.Models
{
    public class Track
    {
        public Album album { get; set; } = default!;
        public List<Artist> artists { get; set; } = default!;
        public bool _explicit { get; set; }
        public string href { get; set; } = default!;
        public string id { get; set; } = default!;
        public bool is_local { get; set; }
        public string name { get; set; } = default!;
        public int duration { get; set; }

        public int popularity { get; set; }
        public string preview_url { get; set; } = default!;
        public string uri { get; set; } = default!;
    }
}