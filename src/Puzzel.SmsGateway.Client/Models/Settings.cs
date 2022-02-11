using System.Collections.Generic;
using System.Text.Json.Serialization;
using Puzzel.SmsGateway.Client.Extensions;

namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets prioritization between messages sent from the same service.
        /// Uses service value unless specified.
        /// Constants are defined in <see cref="Constants.Priority"/>.
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets the TTL(time to live) for the message,
        /// i.e.how long before the message times out in cases
        /// where it cannot be delivered to a handset.
        /// Uses service value unless specified.
        /// Valid values may be found at https://github.com/PuzzelSolutions/SMS/blob/master/sections/about.md#validity-period.
        ///  </summary>
        public int? Validity { get; set; }

        /// <summary>
        /// Gets or sets an arbitrary string set by the client to enable grouping messages in certain statistic reports.
        /// </summary>
        public string? Differentiator { get; set; }

        /// <summary>
        /// Gets or sets an age limit for message content.
        /// The mobile network operators enforces this.
        /// Only relevant for CPA/GAS messages.
        /// IMPORTANT: If the service is a subscription service all CPA/GAS messages must have age set to 18.
        /// Constants are defined in <see cref="Constants.Age"/>.
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a new session or not.
        /// </summary>
        public bool NewSession { get; set; }

        /// <summary>
        /// Gets or sets a session ID which is used to continue an existing session.
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Gets or sets an arbitrary string which is used to enable grouping messages on the service invoice.
        /// </summary>
        public string? InvoiceNode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to auto detect message content encoding or not.
        /// The message content must consist of characters in the GSM 7-bit alphabet and messages containing any other characters will get an error message.
        /// However if you set this field to true, you are able to use all characters defined in the UCS-2 character set.
        /// (Please note that if you use any non GSM-7 characters in your message,
        /// the message will be UCS-2 encoded and you might end up sending more messages than intended - so use with care.)
        /// </summary>
        public bool AutoDetectEncoding { get; set; }

        /// <summary>
        /// Gets or sets originator settings.
        /// Uses service value unless specified.
        /// </summary>
        public OriginatorSettings? OriginatorSettings { get; set; }

        /// <summary>
        /// Gets or sets GAS settings.
        /// Uses service value unless specified.
        /// Used if the message is a CPA Goods and Services transaction.
        /// </summary>
        public GasSettings? GasSettings { get; set; }

        /// <summary>
        /// Gets or sets the send window.
        /// Used if the message should be queued and sent in the future instead of immediately.
        /// </summary>
        public SendWindow? SendWindow { get; set; }

        /// <summary>
        /// Gets or sets specify special settings including settings for binary message.
        /// Available parameter keys: <see cref="Constants.ParameterKey"/>.
        /// </summary>
        [JsonPropertyName("parameter")]
        public IEnumerable<Parameter>? Parameters { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() =>
            $"{nameof(Priority)}: {Priority}, {nameof(Validity)}: {Validity}, {nameof(Differentiator)}: {Differentiator}, {nameof(Age)}: {Age}, {nameof(NewSession)}: {NewSession}, {nameof(SessionId)}: {SessionId}, {nameof(InvoiceNode)}: {InvoiceNode}, {nameof(AutoDetectEncoding)}: {AutoDetectEncoding}, {nameof(OriginatorSettings)}: {OriginatorSettings}, {nameof(GasSettings)}: {GasSettings}, {nameof(SendWindow)}: {SendWindow}, {nameof(Parameters)}: {Parameters?.Dump()}";
    }
}