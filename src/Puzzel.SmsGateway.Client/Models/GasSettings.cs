namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Goods and services settings.
    /// </summary>
    public class GasSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GasSettings"/> class.
        /// </summary>
        /// <param name="serviceCode">Service code, constants are defined in <see cref="Constants.ServiceCode"/>.</param>
        /// <param name="description"><see cref="Description"/></param>
        public GasSettings(string serviceCode, string description)
            : this(serviceCode)
        {
            Description = description;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GasSettings"/> class.
        /// </summary>
        /// <param name="serviceCode">Service code, constants are defined in <see cref="Constants.ServiceCode"/>.</param>
        public GasSettings(string serviceCode)
        {
            ServiceCode = serviceCode;
        }

        /// <summary>
        /// Gets the identifier for the category of Goods and services.
        /// </summary>
        public string ServiceCode { get; }

        /// <summary>
        /// Gets further details for the category of Goods and services.
        /// The description may occur on the end-user invoice(together with category) for certain Mobile Network Operators.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => $"{nameof(ServiceCode)}: {ServiceCode}, {nameof(Description)}: {Description}";
    }
}