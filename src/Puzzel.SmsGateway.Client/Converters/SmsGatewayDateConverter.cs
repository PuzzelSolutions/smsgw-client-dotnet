using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Puzzel.SmsGateway.Client.Converters
{
    /// <summary>
    /// SMS gateway date converter.
    /// </summary>
    public class SmsGatewayDateConverter : JsonConverter<DateTimeOffset>
    {
        private const string Format = "yyyy-MM-dd";

        /// <inheritdoc />
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.ParseExact(reader.GetString(), Format, CultureInfo.InvariantCulture);
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format, CultureInfo.InvariantCulture));
        }
    }
}