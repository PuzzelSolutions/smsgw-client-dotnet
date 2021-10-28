using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Puzzel.SmsGateway.Client.Exceptions;
using Puzzel.SmsGateway.Client.Models;

namespace Puzzel.SmsGateway.Client.Samples.ConsoleAppAdvanced
{
    public class SmsService : BackgroundService
    {
        private readonly ILogger<SmsService> _logger;
        private readonly ISmsGatewayClient _client;
        private readonly SmsGatewayCredentials _credentials;

        public SmsService(
            ILogger<SmsService> logger,
            ISmsGatewayClient client,
            IOptions<SmsGatewayCredentials> options)
        {
            _client = client;
            _logger = logger;
            _credentials = options.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                // Settings example
                // var settings = new Settings
                // {
                //     Priority = Priority.Medium,
                //     Age = Age.Sixteen,
                //     Parameters = new List<Parameter>
                //     {
                //         new(ParameterKey.StrexConfirmChannel, StrexConfirmChannel.Sms),
                //         new(ParameterKey.StrexMerchantSellOption, StrexMerchantSellOption.Confirmation),
                //         new(ParameterKey.ParsingType, ParsingType.AutoDetect),
                //         new(ParameterKey.BusinessModel, BusinessModel.Donation)
                //     }
                // };

                // Single message
                var message = new Message("+4712345678", "This is a test");

                // Multiple messages
                // var messages = new List<Message>
                // {
                //     new("+4712345678", "This is a test"),
                //     new("+4712345678", "This is a test")
                // };

                var response = await _client.SendAsync(_credentials, message);
                _logger.LogInformation("SMS gateway response: {Response}", response);
            }
            catch (SmsGatewayException e)
            {
                const string errorMessage = "SMS gateway error";
                _logger.LogError(e, errorMessage);
            }
        }
    }
}