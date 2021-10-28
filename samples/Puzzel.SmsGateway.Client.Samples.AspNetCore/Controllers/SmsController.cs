using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Puzzel.SmsGateway.Client.Constants;
using Puzzel.SmsGateway.Client.Exceptions;
using Puzzel.SmsGateway.Client.Models;

namespace Puzzel.SmsGateway.Client.Samples.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmsController : ControllerBase
    {
        private readonly ILogger<SmsController> _logger;
        private readonly ISmsGatewayClient _client;
        private readonly SmsGatewayCredentials _credentials;

        public SmsController(
            ILogger<SmsController> logger,
            ISmsGatewayClient client,
            IOptions<SmsGatewayCredentials> options)
        {
            _logger = logger;
            _client = client;
            _credentials = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            try
            {
                // Single message
                var message = new Message("+4712345678", "This is a test");

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

                // Multiple messages
                // var messages = new List<Message>
                // {
                //     new("+4712345678", "This is a test"),
                //     new("+4712345678", "This is a test")
                // };

                var response = await _client.SendAsync(_credentials, message);
                _logger.LogInformation("SMS gateway response: {Response}", response);

                return Ok();
            }
            catch (SmsGatewayException e)
            {
                const string errorMessge = "SMS gateway error";
                _logger.LogError(e, errorMessge);
                return Problem(errorMessge);
            }
        }
    }
}