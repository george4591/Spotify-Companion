namespace SpotifyCompanion.Models;

public class Album
{
    public string album_type { get; set; } = default!;
    public List<Artist> artists { get; set; } = default!;
    public List<Image> images { get; set; } = default!;
    public string href { get; set; } = default!;
    public string id { get; set; } = default!;
    public string name { get; set; } = default!;
    public string release_date { get; set; } = default!;
    public string release_date_precision { get; set; } = default!;
    public int total_tracks { get; set; }
    public string uri { get; set; } = default!;
    public string type { get; set; } = default!;
}