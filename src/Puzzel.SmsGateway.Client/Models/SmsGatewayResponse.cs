using System.Collections.Generic;
using Puzzel.SmsGateway.Client.Extensions;

namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Gateway response.
    /// </summary>
    public class SmsGatewayResponse
    {
        /// <summary>
        /// Gets or sets the unique system generated reference to the batch.
        /// </summary>
        public string? BatchReference { get; set; }

        /// <summary>
        /// Gets or sets the status of each message sent to the gateway.
        /// </summary>
        public List<MessageStatus>? MessageStatus { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() =>
            $"{nameof(BatchReference)}: {BatchReference}, {nameof(MessageStatus)}: {MessageStatus?.Dump()}";
    }
}