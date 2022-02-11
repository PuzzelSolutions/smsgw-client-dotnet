using System;

namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// SMS message with mandatory properties.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="recipient"><see cref="Recipient"/></param>
        /// <param name="content"><see cref="Content"/></param>
        /// <param name="price"><see cref="Price"/></param>
        /// <param name="clientReference"><see cref="ClientReference"/></param>
        /// <param name="settings"><see cref="Settings"/></param>
        /// <exception cref="ArgumentException">Thrown if one of more arguments are invalid.</exception>
        public Message(
            string recipient,
            string content,
            uint price = 0,
            string? clientReference = null,
            Settings? settings = null)
        {
            if (string.IsNullOrEmpty(recipient))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(recipient));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(content));
            }

            Recipient = recipient;
            Content = content;
            Price = price;
            ClientReference = clientReference;
            Settings = settings;
        }

        /// <summary>
        /// Gets the MSISDN of the recipient. The format should follow the ITU-T E.164 standard with a + prefix.
        /// </summary>
        public string Recipient { get; }

        /// <summary>
        /// Gets the message payload to send, typically the message text.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// Gets the cost for the recipient to receive the message. In lowest monetary unit.
        /// </summary>
        public uint Price { get; }

        /// <summary>
        /// Gets an arbitrary client reference ID that will be returned in the message response.
        /// </summary>
        public string? ClientReference { get; }

        /// <summary>
        /// Gets the advanced message settings.
        /// </summary>
        public Settings? Settings { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return
                $"{nameof(Recipient)}: {Recipient}, {nameof(Content)}: {Content}, {nameof(Price)}: {Price}, {nameof(ClientReference)}: {ClientReference}, {nameof(Settings)}: {Settings}";
        }
    }
}