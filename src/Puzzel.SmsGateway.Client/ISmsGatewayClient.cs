using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Puzzel.SmsGateway.Client.Models;

[assembly: AssemblyKeyFile("key.snk")]

namespace Puzzel.SmsGateway.Client
{
    /// <summary>
    /// SMS Gateway client.
    /// </summary>
    public interface ISmsGatewayClient
    {
        /// <summary>
        /// Sends a message to the gateway.
        /// </summary>
        /// <param name="credentials">SMS gateway service credentials.</param>
        /// <param name="message">The message to send.</param>
        /// <returns>Gateway response.</returns>
        Task<SmsGatewayResponse> SendAsync(SmsGatewayCredentials credentials, Message message);

        /// <summary>
        /// Send one or more messages to the gateway.
        /// </summary>
        /// <param name="credentials">SMS gateway service credentials.</param>
        /// <param name="messages">The message(s) to send.</param>
        /// <returns>Gateway response.</returns>
        Task<SmsGatewayResponse> SendAsync(SmsGatewayCredentials credentials, IEnumerable<Message> messages);
    }
}