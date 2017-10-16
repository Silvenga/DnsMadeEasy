using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using DnsMadeEasy.Api;
using DnsMadeEasy.Helpers;

using Newtonsoft.Json;

using RestEase;

namespace DnsMadeEasy
{
    public class DnsMadeEasyClient : IDisposable
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public IManagedDomain Domains { get; }

        public IManagedRecord Records { get; }

        public DnsMadeEasyClient(string apiKey, string apiSecret, string url = "https://api.dnsmadeeasy.com/V2.0")
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Error
            };

            var client = new RestClient(url, RequestModifier)
            {
                JsonSerializerSettings = settings
            };

            Domains = client.For<IManagedDomain>();
            Records = client.For<IManagedRecord>();
        }

        private Task RequestModifier(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authHeaders = HeadersHelper.CreateAuthorizationHeaders(_apiKey, _apiSecret, DateTimeOffset.UtcNow);

            foreach (var header in authHeaders)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Domains?.Dispose();
            Records?.Dispose();
        }
    }
}