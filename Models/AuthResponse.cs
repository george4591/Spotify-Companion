using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpotifyCompanion.Models
{
    public struct AuthResponse
    {
        [JsonPropertyName("access_token")]
        public string? access_token { get; set; }

        [JsonPropertyName("token_type")]
        public string? token_type { get; set; }

        [JsonPropertyName("expires_in")]
        public long? expires_in { get; set; }

        [JsonPropertyName("refresh_token")]
        public string? refresh_token { get; set; }

    }
}
