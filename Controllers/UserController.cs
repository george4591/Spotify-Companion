using Newtonsoft.Json;
using SpotifyCompanion.Utils;

namespace SpotifyCompanion.Controllers
{
    public static class UserController
    {
        private static readonly string _entrypoint = "https://api.spotify.com/v1";
        public static async Task<Models.User> GetCurrentUser()
        {
            return await HttpRequest.Get<Models.User>($"{_entrypoint}/me/");
        }
        public static async void GetUserTopItems()
        {

        }
        public static async Task<Models.User> GetUser(string userId)
        {
            return await HttpRequest.Get<Models.User>($"{_entrypoint}/users/{userId}");
        }
        public static async void FollowPlaylist(string playlistId)
        {
            var endpoint = $"{_entrypoint}/playlists/{playlistId}/followers";
            await HttpRequest.Put(endpoint, new StringContent("public: true"));
        }
        public static async void UnfollowPlaylist(string playlistId)
        {
            var endpoint = $"{_entrypoint}/playlists/{playlistId}/followers";
            await HttpRequest.Delete(endpoint);
        }
        public static async void GetFollowedArtists()
        {

        }
        public static async void Follow(List<string> ids, string type = "user")
        {
            var endpoint = $"{_entrypoint}/me/following?type={type}";
            var serializedIds = JsonConvert.SerializeObject(ids);
            var requestBody = new StringContent(serializedIds);

            await HttpRequest.Put(endpoint, requestBody);
        }
        public static async void Unfollow(List<string> ids, string type = "user")
        {
            var endpoint = $"{_entrypoint}/me/following?type={type}";
            var serializedIds = JsonConvert.SerializeObject(ids);
            var requestBody = new StringContent(serializedIds);

            await HttpRequest.Delete(endpoint, requestBody);
        }

        //public static async Task<List<bool>> IsFollowingUser(List<string> ids, string type = "user")
        //{
        //    var endpoint = $"https://api.spotify.com/v1/me/following?type={type}";
        //    var serializedIds = JsonConvert.SerializeObject(ids);
        //    var RequestBody = new StringContent(serializedIds);

        //    await SpotifyHttpRequest.Get(endpoint, RequestBody);
        //}
        public static async void IsFollwingPlaylist()
        {

        }
    }
}
