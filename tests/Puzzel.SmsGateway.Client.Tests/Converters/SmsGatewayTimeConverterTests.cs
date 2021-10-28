using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Puzzel.SmsGateway.Client.Converters;
using Puzzel.SmsGateway.Client.Tests.Helpers;
using Xunit;

namespace Puzzel.SmsGateway.Client.Tests.Converters
{
    public class SmsGatewayTimeConverterTests
    {
        private readonly SmsGatewayTimeConverter _converter;

        public SmsGatewayTimeConverterTests()
        {
            _converter = new SmsGatewayTimeConverter();
        }

        [Theory]
        [InlineData("12:00:00", 12, 0, 0, 0)]
        [InlineData("12:00:00+02:00", 12, 0, 0, 2)]
        [InlineData("12:00:00-02:00", 12, 0, 0, -2)]
        public void ShouldReadTime(string value, int hour, int minute, int seconds, int offset)
        {
            var result = _converter.ReadValue(value);

            using (new AssertionScope())
            {
                result.Hour.Should().Be(hour);
                result.Minute.Should().Be(minute);
                result.Minute.Should().Be(seconds);
                result.Offset.Hours.Should().Be(offset);
            }
        }

        [Theory]
        [InlineData("12:00:00+06:00", 12, 0, 0, 6)]
        [InlineData("12:00:00+02:00", 12, 0, 0, 2)]
        [InlineData("12:00:00-02:00", 12, 0, 0, -2)]
        public async Task ShouldWriteTime(string value, int hour, int minute, int seconds, int offset)
        {
            var result = await _converter.WriteAndReturnValueAsync(value);

            result.Should().Be($"\"{hour:00}:{minute:00}:{seconds:00}{(offset > 0 ? "\\u002B" : string.Empty)}{offset:00}:00\"");
        }
    }
}