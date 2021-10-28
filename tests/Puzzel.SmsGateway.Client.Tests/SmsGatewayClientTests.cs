using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Execution;
using Puzzel.SmsGateway.Client.Constants;
using Puzzel.SmsGateway.Client.Exceptions;
using Puzzel.SmsGateway.Client.Models;
using Puzzel.SmsGateway.Client.Tests.Helpers;
using Xunit;

namespace Puzzel.SmsGateway.Client.Tests
{
    public class SmsGatewayClientTests
    {
        private const string DummyRecipient = "+4740000000";
        private readonly SmsGatewayCredentials _dummyCredentials = new(1, Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        private Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _requestHandler;

        [Fact]
        public void WhenHttpClientIsNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SmsGatewayClient(null));
        }

        [Fact]
        public async Task WhenGatewayReturnsOkResponse_ShouldReceiveMessageStatus()
        {
            const string messageId = "123";
            _requestHandler = (_, _) =>
                Task.FromResult(SmsGatewayResponseGenerator.GenerateResponseMessage(
                    new MessageStatus
                    {
                        MessageId = messageId,
                        StatusCode = SmsGatewayStatusCode.MessageDeliveredOk
                    }));
            var client = CreateClient();

            var smsGatewayResponse = await client.SendAsync(_dummyCredentials, new Message(DummyRecipient, Guid.NewGuid().ToString()));

            var messageStatus = smsGatewayResponse.MessageStatus.First();
            using (new AssertionScope())
            {
                messageStatus.MessageId.Should().Be(messageId);
                messageStatus.StatusCode.Should().Be(SmsGatewayStatusCode.MessageDeliveredOk);
            }
        }

        [Fact]
        public async Task WhenGatewayReturnsInternalServerErrorResponse_ShouldThrowSmsGatewayException()
        {
            _requestHandler = (_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            var client = CreateClient();

            Func<Task<SmsGatewayResponse>> func = async () => await client.SendAsync(_dummyCredentials, new Message(DummyRecipient, Guid.NewGuid().ToString()));

            using (new AssertionScope())
            {
                var exceptionAssertions = await func.Should().ThrowAsync<SmsGatewayException>();
                exceptionAssertions.And.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
                exceptionAssertions.And.ReasonPhrase.Should().Be("Internal Server Error");
            }
        }

        [Fact]
        public void WhenBaseAddressIsNull_ShouldSetBaseAddress()
        {
            var httpClient = new HttpClient();

            var _ = new SmsGatewayClient(httpClient);

            httpClient.BaseAddress.Should().Be("https://smsgw.puzzel.com");
        }

        [Fact]
        public async Task WhenSendingMessage_ShouldSetAcceptHeader()
        {
            var assertionDone = false;
            _requestHandler = (requestMessage, _) =>
            {
                requestMessage.Headers.Accept.ToString().Should().Be("application/json");
                assertionDone = true;
                return Task.FromResult(SmsGatewayResponseGenerator.GenerateResponseMessage(new MessageStatus()));
            };
            var client = CreateClient();

            await client.SendAsync(_dummyCredentials, new Message(DummyRecipient, Guid.NewGuid().ToString()));

            assertionDone.Should().BeTrue();
        }

        [Fact]
        public async Task WhenSendingMessage_ShouldInvokeHttpClient()
        {
            var clientInvoked = false;
            _requestHandler = (_, _) =>
            {
                clientInvoked = true;
                return Task.FromResult(SmsGatewayResponseGenerator.GenerateResponseMessage(new MessageStatus()));
            };
            var client = CreateClient();

            await client.SendAsync(_dummyCredentials, new Message(DummyRecipient, Guid.NewGuid().ToString()));

            clientInvoked.Should().BeTrue();
        }

        private SmsGatewayClient CreateClient()
        {
            return new SmsGatewayClient(new HttpClient(new SmsGatewayResponseGenerator(_requestHandler)));
        }
    }
}