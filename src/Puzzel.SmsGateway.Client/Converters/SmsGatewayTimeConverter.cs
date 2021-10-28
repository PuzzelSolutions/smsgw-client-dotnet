using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Puzzel.SmsGateway.Client.Converters
{
    /// <summary>
    /// SMS gateway date converter.
    /// </summary>
    public class SmsGatewayTimeConverter : JsonConverter<DateTimeOffset>
    {
        private const string FormatWithOffset = "HH:mm:sszzz";
        private const string FormatWithoutOffset = "HH:mm:ss";

        /// <inheritdoc />
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.ParseExact(
                reader.GetString(),
                new[] { FormatWithOffset, FormatWithoutOffset },
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(FormatWithOffset, CultureInfo.InvariantCulture));
        }
    }
}