namespace SpotifyCompanion.Models;

public class Artist
{
    // public class ExternalUrls
    // {
    //     public string spotify { get; set; }
    // }
    public Dictionary<string, string> ExternalUrls { get; set; } = default!;
    public IList<string> genres { get; set; } = default!;
    public string href { get; set; } = default!;
    public string id { get; set; } = default!;
    public string name { get; set; } = default!;
    public int popularity { get; set; } = default!;
    public string type { get; set; } = default!;
    public string uri { get; set; } = default!;
}