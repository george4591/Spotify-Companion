using SpotifyCompanion.Models;
using SpotifyCompanion.Utils;

namespace SpotifyCompanion.Player
{
    public static class Player
    {
        private static readonly string _entrypoint = "https://api.spotify.com/v1/me/player";
        private static readonly List<string> repeatModes = new List<string> {"off", "track", "context"};

        private static async Task<PlaybackState> GetPlaybackState()
        {
            return await HttpRequest.Get<PlaybackState>($"{_entrypoint}");
        }

        public static async void TransferPlayback()
        {
        }

        public static async void GetAvailableDevices()
        {
        }

        public static async Task GetRecentlyPlayedTracks()
        {
            var recentTracks = await HttpRequest.Get<Tracks>($"{_entrypoint}/recently-played");
            foreach (var item in recentTracks.tracks)
            {
                Console.WriteLine(item.name);
            }
        }

        public static async Task<CurrentTrack> GetCurrentlyPlayingTrack()
        {
            return await HttpRequest.Get<CurrentTrack>($"{_entrypoint}/currently-playing");
        }

        private static async Task PlayPlayback()
        {
            await HttpRequest.Put($"{_entrypoint}/play");
        }

        private static async Task PausePlayback()
        {
            await HttpRequest.Put($"{_entrypoint}/pause");
        }

        public static async Task PauseStartPlayback()
        {
            var state = await GetPlaybackState();
            if (state.is_playing)
                PausePlayback();
            else
                PlayPlayback();
        }

        public static async Task SkipToNext()
        {
            await HttpRequest.Post($"{_entrypoint}/next");
        }

        public static async Task SkipToPrevious()
        {
            await HttpRequest.Post($"{_entrypoint}/previous");
        }

        // FIXME Magic number.
        public static async Task SeekToPosition()
        {
            await HttpRequest.Put($"{_entrypoint}/seek?position_ms={2500}");
        }

        public static async Task SetRepeatMode()
        {
            var playbackState = await GetPlaybackState();
            var indexOfCurrentMode = repeatModes.IndexOf(playbackState.repeat_state);

            string repeatMode = repeatModes[(indexOfCurrentMode + 1) % repeatModes.Count];

            await HttpRequest.Put($"{_entrypoint}/repeat?state={repeatMode}");
        }

        // FIXME Magic number.
        public static async Task SetPlaybackVolume()
        {
            await HttpRequest.Put($"{_entrypoint}/volume?volume_percent={50}");
        }

        public static async Task TogglePlaybackShuffle()
        {
            var playbackState = await GetPlaybackState();

            // In playback state the shuffle is stored as a string but we need to pass a boolean here for some reason.
            var shuffleMode = playbackState.shuffle_state;
            bool newMode = !(shuffleMode == "true");

            await HttpRequest.Put($"{_entrypoint}/shuffle?state={newMode}");
        }

        public static void AddItemToPlaybackQueue(string itemUri)
        {
            HttpRequest.Post($"{_entrypoint}/queue?uri={itemUri}");
        }
    }
}