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
    public class DnsMadeEasyClient
    {
        private readonly string _apiKey;
        private readonly string _apiSecret;

        public IManagedDns ManagedDns { get; }

        public DnsMadeEasyClient(string apiKey, string apiSecret, string url = "https://api.dnsmadeeasy.com")
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var client = new RestClient(url, RequestModifier)
            {
                JsonSerializerSettings = settings
            };

            ManagedDns = client.For<IManagedDns>();
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
    }
}