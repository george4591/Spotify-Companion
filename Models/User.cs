using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyCompanion.Models
{
    public class User
    {
        public string? display_name { get; set; }
        public string? email { get; set; }
        public Dictionary<string, string> external_urls { get; set; } = default!;
        public Followers? followers { get; set; }
        public string? href { get; set; }
        public string? id { get; set; }
        public List<Image> images { get; set; } = default!;
        public string? type { get; set; }
        public string? uri { get; set; }
    }
}
