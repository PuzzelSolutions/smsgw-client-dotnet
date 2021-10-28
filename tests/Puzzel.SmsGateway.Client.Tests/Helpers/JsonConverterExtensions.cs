using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Puzzel.SmsGateway.Client.Tests.Helpers
{
    public static class JsonConverterExtensions
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static DateTimeOffset ReadValue(this JsonConverter<DateTimeOffset> converter, string value)
        {
            var reader = new Utf8JsonReader(Encoding.UTF8.GetBytes($"\"{value}\""));
            reader.Read();

            return converter.Read(ref reader, typeof(DateTimeOffset), SerializerOptions);
        }

        public static async Task<string> WriteAndReturnValueAsync(this JsonConverter<DateTimeOffset> converter, string date)
        {
            var buffer = new byte[32];
            await using var memoryStream = new MemoryStream(buffer);
            await using var writer = new Utf8JsonWriter(memoryStream);
            converter.Write(writer, DateTimeOffset.Parse(date), SerializerOptions);
            await writer.FlushAsync();

            return Encoding.UTF8.GetString(buffer, 0, Convert.ToInt32(memoryStream.Position));
        }
    }
}