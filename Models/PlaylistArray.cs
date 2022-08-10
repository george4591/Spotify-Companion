using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyCompanion.Models
{
    public class PlaylistArray
    {   
        public Playlist[] items { get; set; }
        public int limit { get; set; }
        //public string next { get; set; }
        //public int offset { get; set; }
        //public object previous { get; set; }
        public int total { get; set; }
        public class Tracks
        {
            public string href { get; set; }
            public int total { get; set; }
        }
    }
}
