using SpotifyCompanion.Models;
using SpotifyCompanion.Utils;

namespace SpotifyCompanion.Controllers
{
    public static class TrackController
    {
        private static readonly string _entrypoint = "https://api.spotify.com/v1/tracks";
        public static async Task<Models.Track> GetTrack(string id)
        {
            return await HttpRequest.Get<Models.Track>($"{_entrypoint}/{id}");
        }
        public static async Task<Tracks> GetTracks(string[] ids)
        {
            return await HttpRequest.Get<Tracks>($"{_entrypoint}?ids={string.Join(",", ids)}");
        }
        public static async Task<Models.Track[]> GetUserSavedTracks(int offset, int limit)
        {
            return await HttpRequest.Get<Models.Track[]>($"{_entrypoint}/me/tracks?offset={offset}&limit={limit}");
        }
        public static async Task SaveTrack(string[] ids)
        {
            await HttpRequest.Put($"{_entrypoint}/me/tracks?ids={string.Join(",", ids)}");
        }
        public static async Task UnsaveTrack(string[] ids)
        {
            await HttpRequest.Delete($"{_entrypoint}/me/tracks?ids={string.Join(",", ids)}");
        }
        public static async Task<bool[]> IsTrackSaved(string[] ids)
        {
            return await HttpRequest.Get<bool[]>($"{_entrypoint}/me/tracks/contains?ids={string.Join(",", ids)}");
        }
        public static async Task<AudioFeatures> GetAudioFeatures(string id)
        {
            return await HttpRequest.Get<AudioFeatures>($"{_entrypoint}/audio-features?id={id}");
        }
        public static async Task<AudioFeatures[]> GetAudioFeatures(string[] ids)
        {
            return await HttpRequest.Get<AudioFeatures[]>($"{_entrypoint}/audio-features?ids={string.Join(",", ids)}");
        }
        public static async void GetAudioAnalysis()
        {

        }
        public static async void GetRecommendations()
        {

        }
    }
}
