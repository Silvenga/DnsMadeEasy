using System;
using System.Linq;

using DnsMadeEasy.Helpers;

using FluentAssertions;

using Ploeh.AutoFixture;

using Xunit;

namespace DnsMadeEasy.Tests.Helpers
{
    public class HeadersHelperFacts
    {
        private static readonly Fixture Autofixture = new Fixture();

        [Fact]
        public void Creates_valid_date_header()
        {
            var apiKeyFake = Autofixture.Create<string>();
            var apiSecretFake = Autofixture.Create<string>();
            var requestDateFake = new DateTimeOffset(2011, 2, 12, 20, 59, 04, TimeSpan.FromHours(0));

            // Act
            var result = HeadersHelper.CreateAuthorizationHeaders(apiKeyFake, apiSecretFake, requestDateFake).ToList();

            // Assert
            result.Should().Contain(x => x.Key == "x-dnsme-requestDate")
                .Which.Value.Should().Be("Sat, 12 Feb 2011 20:59:04 GMT");
        }

        [Fact]
        public void Creates_valid_api_key_header()
        {
            var apiKeyFake = Autofixture.Create<string>();
            var apiSecretFake = Autofixture.Create<string>();
            var requestDateFake = Autofixture.Create<DateTimeOffset>();

            // Act
            var result = HeadersHelper.CreateAuthorizationHeaders(apiKeyFake, apiSecretFake, requestDateFake).ToList();

            // Assert
            result.Should().Contain(x => x.Key == "x-dnsme-apiKey")
                .Which.Value.Should().Be(apiKeyFake);
        }

        [Fact]
        public void Creates_valid_hash_header()
        {
            var apiKeyFake = Autofixture.Create<string>();
            const string apiSecretFake = "c9b5625f-9834-4ff8-baba-4ed5f32cae55";
            var requestDateFake = new DateTimeOffset(2011, 2, 12, 20, 59, 04, TimeSpan.FromHours(0));

            // Act
            var result = HeadersHelper.CreateAuthorizationHeaders(apiKeyFake, apiSecretFake, requestDateFake).ToList();

            // Assert
            result.Should().Contain(x => x.Key == "x-dnsme-hmac")
                .Which.Value.Should().Be("b3502e6116a324f3cf4a8ed693d78bcee8d8fe3c");
        }
    }
}