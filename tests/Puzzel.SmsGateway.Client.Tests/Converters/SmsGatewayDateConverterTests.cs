using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Puzzel.SmsGateway.Client.Converters;
using Puzzel.SmsGateway.Client.Tests.Helpers;
using Xunit;

namespace Puzzel.SmsGateway.Client.Tests.Converters
{
    public class SmsGatewayDateConverterTests
    {
        private readonly SmsGatewayDateConverter _converter;

        public SmsGatewayDateConverterTests()
        {
            _converter = new SmsGatewayDateConverter();
        }

        [Theory]
        [InlineData("2021-01-02", 2021, 1, 2)]
        [InlineData("1990-03-04", 1990, 3, 4)]
        public void ShouldReadDate(string value, int year, int month, int day)
        {
            var result = _converter.ReadValue(value);

            using (new AssertionScope())
            {
                result.Year.Should().Be(year);
                result.Month.Should().Be(month);
                result.Day.Should().Be(day);
            }
        }

        [Theory]
        [InlineData("2021-01-02")]
        [InlineData("1990-03-04")]
        public async Task ShouldWriteDate(string date)
        {
            var result = await _converter.WriteAndReturnValueAsync(date);

            result.Should().Be($"\"{date}\"");
        }
    }
}