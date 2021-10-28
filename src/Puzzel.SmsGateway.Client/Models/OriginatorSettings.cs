namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Originator settings.
    /// </summary>
    public class OriginatorSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OriginatorSettings"/> class.
        /// </summary>
        /// <param name="originator"><see cref="Originator"/></param>
        /// <param name="originatorType"><see cref="OriginatorType"/></param>
        public OriginatorSettings(string originator, string originatorType)
        {
            Originator = originator;
            OriginatorType = originatorType;
        }

        /// <summary>
        /// Gets the originator, which depends on the OriginatorType. Example: +4799999999, Puzzel, 1960.
        /// </summary>
        public string Originator { get; }

        /// <summary>
        /// Gets the type of originator, one of <see cref="Constants.OriginatorType"/>.
        /// </summary>
        public string OriginatorType { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => $"{nameof(Originator)}: {Originator}, {nameof(OriginatorType)}: {OriginatorType}";
    }
}