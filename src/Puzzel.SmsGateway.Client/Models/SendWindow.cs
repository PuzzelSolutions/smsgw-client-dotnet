using System;
using System.Text.Json.Serialization;
using Puzzel.SmsGateway.Client.Converters;

namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Send window.
    /// </summary>
    public class SendWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendWindow"/> class.
        /// </summary>
        /// <param name="startDate"><see cref="StartDate"/></param>
        /// <param name="startTime"><see cref="StartTime"/></param>
        public SendWindow(DateTimeOffset startDate, DateTimeOffset startTime)
        {
            StartDate = startDate;
            StartTime = startTime;
        }

        /// <summary>
        /// Gets the date to send the message.
        /// </summary>
        [JsonConverter(typeof(SmsGatewayDateConverter))]
        public DateTimeOffset StartDate { get; }

        /// <summary>
        /// Gets the time of day to start sending the message.
        /// </summary>
        [JsonConverter(typeof(SmsGatewayTimeConverter))]
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Gets or sets the date to stop sending the message if the message is still enqueued.
        /// </summary>
        [JsonConverter(typeof(SmsGatewayDateConverter))]
        public DateTimeOffset? StopDate { get; set; }

        /// <summary>
        /// Gets or sets the time to stop sending the message if the message is still enqueued.
        /// </summary>
        [JsonConverter(typeof(SmsGatewayTimeConverter))]
        public DateTimeOffset? StopTime { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() =>
            $"{nameof(StartDate)}: {StartDate}, {nameof(StartTime)}: {StartTime}, {nameof(StopDate)}: {StopDate}, {nameof(StopTime)}: {StopTime}";
    }
}