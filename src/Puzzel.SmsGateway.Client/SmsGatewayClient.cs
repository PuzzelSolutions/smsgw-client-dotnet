using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Puzzel.SmsGateway.Client.Exceptions;
using Puzzel.SmsGateway.Client.Models;

namespace Puzzel.SmsGateway.Client
{
    /// <summary>
    /// SMS Gateway client.
    /// </summary>
    public class SmsGatewayClient : ISmsGatewayClient
    {
        private const string RelativeUri = "gw/rs/sendMessages";
        private const string MediaType = "application/json";
        private readonly HttpClient _httpClient;

        private readonly JsonSerializerOptions _serializerOptions = new()
        {
            IgnoreNullValues = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsGatewayClient"/> class.
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        public SmsGatewayClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            if (httpClient.BaseAddress == null)
            {
                httpClient.BaseAddress = new Uri("https://smsgw.puzzel.com");
            }
        }

        /// <inheritdoc />
        public async Task<SmsGatewayResponse> SendAsync(SmsGatewayCredentials credentials, Message message)
        {
            return await SendAsync(credentials, new[] { message }).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<SmsGatewayResponse> SendAsync(SmsGatewayCredentials credentials, IEnumerable<Message> messages)
        {
            var requestMessage = CreateRequestMessage(credentials, messages);
            var responseMessage = await _httpClient.SendAsync(requestMessage).ConfigureAwait(false);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new SmsGatewayException("SMS gateway error", responseMessage.StatusCode, responseMessage.ReasonPhrase);
            }

            var response = await CreateResponseAsync(responseMessage);

            return response;
        }

        private HttpRequestMessage CreateRequestMessage(SmsGatewayCredentials credentials, IEnumerable<Message> messages)
        {
            var request = new SmsGatewayRequest
            {
                ServiceId = credentials.ServiceId,
                Username = credentials.Username,
                Password = credentials.Password,
                Messages = messages
            };
            var serialized = JsonSerializer.Serialize(request, _serializerOptions);
            var content = new StringContent(serialized, Encoding.UTF8, MediaType);
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, RelativeUri);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaType));
            requestMessage.Content = content;

            return requestMessage;
        }

        private async Task<SmsGatewayResponse> CreateResponseAsync(HttpResponseMessage responseMessage)
        {
            var responseContentStream = await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var response = await JsonSerializer.DeserializeAsync<SmsGatewayResponse>(responseContentStream, _serializerOptions).ConfigureAwait(false);

            return response;
        }
    }
}