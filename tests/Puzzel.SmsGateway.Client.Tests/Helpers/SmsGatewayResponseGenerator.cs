using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Puzzel.SmsGateway.Client.Models;

namespace Puzzel.SmsGateway.Client.Tests.Helpers
{
    public class SmsGatewayResponseGenerator : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _requestHandler;

        public SmsGatewayResponseGenerator(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> requestHandler)
        {
            _requestHandler = requestHandler;
        }

        public static HttpResponseMessage GenerateResponseMessage(MessageStatus messageStatus)
        {
            var gatewayResponse = new SmsGatewayResponse { MessageStatus = new List<MessageStatus> { messageStatus } };
            var serializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var responseMessage = new HttpResponseMessage { Content = new StringContent(JsonSerializer.Serialize(gatewayResponse, serializerOptions)) };

            return responseMessage;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _requestHandler(request, cancellationToken);
        }
    }
}