using Intelecom.SmsGateway.Client.Constants;
using Intelecom.SmsGateway.Client.Exceptions;
using Intelecom.SmsGateway.Client.Models;
using Intelecom.SmsGateway.Client.Tests.Helpers;
using NUnit.Framework;
using Should;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Intelecom.SmsGateway.Client.Tests
{
    public class SmsGatewayClientTests
    {
        private const string DummyBaseAddress = "https://www.dummy.com";
        private readonly SmsGatewayCredentials _dummyCredentials = new SmsGatewayCredentials(1, "foo", "bar");
        private Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _requestHandler;

        private SmsGatewayClient CreateClient(string baseAddress, SmsGatewayCredentials credentials)
        {
            return new SmsGatewayClient(baseAddress, credentials, new FakeSmsGatewayResponseGenerator(_requestHandler));
        }

        public class Ctor : SmsGatewayClientTests
        {
            [Test]
            public void WhenBaseAddressIsNull_ShouldThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => CreateClient(null, _dummyCredentials));
            }

            [Test]
            public void WhenBaseAddressIsMalformed_ShouldThrowUriFormatException()
            {
                Assert.Throws<UriFormatException>(() => CreateClient("foo", _dummyCredentials));
            }

            [Test]
            public void WhenCredentialsIsNull_ShouldThrowArgumentNullException()
            {
                Assert.Throws<ArgumentNullException>(() => CreateClient(DummyBaseAddress, null));
            }

            [Test]
            public void WhenArgumentsAreValid_ShouldNotThrowException()
            {
                Assert.DoesNotThrow(() => CreateClient(DummyBaseAddress, _dummyCredentials));
            }
        }

        public class SendAsync : SmsGatewayClientTests
        {
            [Test]
            public async Task WhenGatewayReturnsOkResponse_ShouldReceiveMessageStatus()
            {
                _requestHandler = (message, token) =>
                                  {
                                      var responseMessage = FakeSmsGatewayResponseGenerator.GenerateResponseMessage(new MessageStatus
                                      {
                                          MessageId = "123",
                                          StatusCode = SmsGatewayStatusCode.MessageDeliveredOk
                                      });
                                      return Task.FromResult(responseMessage);
                                  };
                var client = CreateClient(DummyBaseAddress, _dummyCredentials);

                var smsGatewayResponse = await client.SendAsync(new Message());
                var messageStatus = smsGatewayResponse.MessageStatus.First();

                messageStatus.MessageId.ShouldEqual("123");
                messageStatus.StatusCode.ShouldEqual(SmsGatewayStatusCode.MessageDeliveredOk);
            }

            [Test]
            public void WhenGatewayReturnsInternalServerErrorResponse_ShouldThrowSmsGatewayException()
            {
                _requestHandler = (message, token) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
                var client = CreateClient(DummyBaseAddress, _dummyCredentials);

                Assert.Throws<SmsGatewayException>(async () => await client.SendAsync(new Message()));
            }
        }
    }
}