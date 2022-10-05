using SpotifyCompanion.Utils;

namespace SpotifyCompanion.Controllers
{
    public static class ArtistController
    {
        private static readonly string _entrypoint = "https://api.spotify.com/v1/artists";

        public static async Task<Models.Artist> GetArtist(string id)
        {
            return await HttpRequest.Get<Models.Artist>($"{_entrypoint}/{id}");
        }

        public static async Task<List<Models.Artist>> GetSeveralArtist(IEnumerable<string> ids)
        {
            var artists = new List<Models.Artist>();
            foreach (var id in ids)
            {
                artists.Add(await GetArtist(id));
            }
            
            return artists;
        }

        public static async void GetArtistAlbums()
        {
          
        }

        public static async void GetArtistTopTracks()
        {
        }

        public static async void GetRelatedArtists()
        {
        }
    }
}