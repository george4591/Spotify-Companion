using Hanssens.Net;
using SpotifyCompanion.Models;
using System.Net.Http.Headers;
using System.Text;

namespace SpotifyCompanion
{
    public class Client
    {
        public static HttpClient client { get; } = new();
        private readonly LocalStorage _storage = new();
        private readonly string _clientId;
        private readonly string _clientSecret;
        private bool _clientIsRunning;

        public Client(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;

            client.BaseAddress = new Uri(AppDetails.BaseAdress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            _clientIsRunning = true;
        }

        public async Task Login()
        {
            if (!File.Exists(".localstorage"))
            {
                AuthResponse loginInfo = OAuth2.Authorize(_clientId, _clientSecret);

                _storage.Store("access_token", loginInfo.access_token);
                _storage.Store("token_type", loginInfo.token_type);
                _storage.Store("refresh_token", loginInfo.refresh_token);
                _storage.Store("expires_at", DateTime.Now.Add(TimeSpan.FromSeconds(loginInfo.expires_in ?? 0)));

                _storage.Persist();
                Console.WriteLine("You are now logged in!");
            }
            else
            {
                await RefreshTokenIfNeeded();
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _storage.Get<string>("access_token"));
        }

        public async Task Run()
        {
            while (_clientIsRunning)
            {
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        _clientIsRunning = false;
                        break;
                    case ConsoleKey.UpArrow:
                        await Player.Player.GetRecentlyPlayedTracks();
                        break;
                    case ConsoleKey.F6:
                        User.User.FollowPlaylist("7wJufnewhs4Ue8MpeJ7hIe");
                        break;
                    case ConsoleKey.RightArrow:
                        var user = await User.User.GetCurrentUser();
                        Console.WriteLine(user.email);
                        break;
                    case ConsoleKey.F8:
                        User.User.UnfollowPlaylist("7wJufnewhs4Ue8MpeJ7hIe");
                        break;
                }
            }
        }

        private void StoreToken(string accessToken)
        {
            _storage.Store("access_token", accessToken);
            _storage.Store("expires_at", DateTime.Now.Add(TimeSpan.FromSeconds(3600)));
            _storage.Persist();
        }

        public async Task RefreshTokenIfNeeded()
        {
            var tokenExpirationTime = _storage.Get<DateTime>("expires_at");

            if (DateTime.Compare(DateTime.Now, tokenExpirationTime) > 0)
            {
                Console.WriteLine("The token is expired. Refreshing...");

                var refreshToken = _storage.Get<string>("refresh_token");
                AuthResponse refreshedToken = await OAuth2.RefreshAccessToken(refreshToken);

                StoreToken(refreshedToken.access_token);
                Console.WriteLine("Token Refreshed!");
            }
            else
            {
                Console.WriteLine($"The current token will expire at: {tokenExpirationTime.ToShortTimeString()}");
            }
        }
    }
}