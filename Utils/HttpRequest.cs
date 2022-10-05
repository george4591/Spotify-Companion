using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyCompanion.Utils
{
    public static class HttpRequest
    {
        private static readonly StringContent EmptyContent = new(string.Empty);

        private static async Task<T> SendRequest<T>(HttpMethod method, string url, HttpContent? content = null)
        {
            var request = new HttpRequestMessage(method, url)
            {
                Content = content ?? EmptyContent
            };

            using HttpResponseMessage response = await App.Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<T>();
        }

        public static async Task<T> Get<T>(string endpoint)
        {
            return await SendRequest<T>(HttpMethod.Get, endpoint);
        }

        public static async Task Post(string endpoint)
        {
            await SendRequest<object>(HttpMethod.Post, endpoint);
        }

        public static async Task<T> Post<T>(string endpoint, HttpContent requestBody)
        {
            return await SendRequest<T>(HttpMethod.Post, endpoint, requestBody);
        }

        public static async Task Put(string endpoint, HttpContent? requestBody = null)
        {
            await SendRequest<object>(HttpMethod.Put, endpoint, requestBody);
        }

        public static async Task Delete(string endpoint, HttpContent? requestBody = null)
        {
            await SendRequest<object>(HttpMethod.Delete, endpoint, requestBody);
        }
    }
}