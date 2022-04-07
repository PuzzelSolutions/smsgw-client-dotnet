using System.Collections.Generic;
using System.Text.Json.Serialization;
using Puzzel.SmsGateway.Client.Extensions;

namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Gateway request.
    /// </summary>
    public class SmsGatewayRequest
    {
        /// <summary>
        /// Gets or sets the service ID. Provided by Puzzel service desk.
        /// </summary>
        public uint ServiceId { get; set; }

        /// <summary>
        /// Gets or sets the username. Provided by Puzzel service desk.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the password. Provided by Puzzel service desk.
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the reference ID that will be returned in the response.
        /// </summary>
        public string? BatchReference { get; set; }

        /// <summary>
        /// Gets or sets the message(s) that will be sent to the gateway.
        /// </summary>
        [JsonPropertyName("message")]
        public IEnumerable<Message>? Messages { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() =>
            $"{nameof(ServiceId)}: {ServiceId}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}, {nameof(BatchReference)}: {BatchReference}, {nameof(Messages)}: {Messages?.Dump()}";
    }
}