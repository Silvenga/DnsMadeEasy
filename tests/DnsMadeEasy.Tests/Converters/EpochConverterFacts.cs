using System;

using DnsMadeEasy.Converters;

using FluentAssertions;

using Newtonsoft.Json;

using Xunit;

namespace DnsMadeEasy.Tests.Converters
{
    public class EpochConverterFacts
    {
        [Fact]
        public void Can_read_epoch_to_date_time_offset()
        {
            const string json = "{\"Date\":1508039596704}";

            // Act
            var result = JsonConvert.DeserializeObject<ConverterFixture>(json);

            // Assert
            result.Date.Should().Be(DateTimeOffset.Parse("Sunday, October 15, 2017 3:53:16.704 AM GMT"));
        }

        private class ConverterFixture
        {
            [JsonConverter(typeof(EpochConverter))]
            public DateTimeOffset Date { get; set; }
        }
    }
}