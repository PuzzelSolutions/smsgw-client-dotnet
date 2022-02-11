using System;

namespace Puzzel.SmsGateway.Client
{
    /// <summary>
    /// Gateway credentials.
    /// </summary>
    public class SmsGatewayCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SmsGatewayCredentials"/> class.
        /// </summary>
        public SmsGatewayCredentials()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsGatewayCredentials"/> class.
        /// </summary>
        /// <param name="serviceId">Service ID.</param>
        /// <param name="username">Service username.</param>
        /// <param name="password">Service password.</param>
        /// <exception cref="ArgumentException">If any of the parameters are invalid.</exception>
        public SmsGatewayCredentials(uint serviceId, string username, string password)
        {
            if (serviceId == 0)
            {
                throw new ArgumentException(nameof(serviceId));
            }

            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException(nameof(password));
            }

            ServiceId = serviceId;
            Username = username;
            Password = password;
        }

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
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => $"{nameof(ServiceId)}: {ServiceId}, {nameof(Username)}: {Username}, {nameof(Password)}: {Password}";
    }
}