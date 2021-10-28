using System;
using System.Net;

namespace Puzzel.SmsGateway.Client.Exceptions
{
    /// <summary>
    /// Gateway exception.
    /// </summary>
    public class SmsGatewayException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsGatewayException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="statusCode">HTTP status code</param>
        /// <param name="reasonPhrase">Reason phrase</param>
        public SmsGatewayException(string message, HttpStatusCode statusCode, string reasonPhrase)
            : base(message)
        {
            StatusCode = statusCode;
            ReasonPhrase = reasonPhrase;
        }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the reason phrase.
        /// </summary>
        public string ReasonPhrase { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(StatusCode)}: {StatusCode}, {nameof(ReasonPhrase)}: {ReasonPhrase}";
        }
    }
}