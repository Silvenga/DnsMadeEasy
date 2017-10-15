using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DnsMadeEasy.Converters
{
    public class EpochConverter : DateTimeConverterBase
    {
        // https://stackoverflow.com/a/19972214/2001966

        private DateTimeOffset Epoch => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - Epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return Epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }
}