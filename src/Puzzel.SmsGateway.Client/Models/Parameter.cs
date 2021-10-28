namespace Puzzel.SmsGateway.Client.Models
{
    /// <summary>
    /// Parameter.
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="key">Parameter key, constants defined in <see cref="Constants.ParameterKey"/>.</param>
        /// <param name="value">Parameter value</param>
        public Parameter(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets the key. Example: dcs
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the value. Example: F5
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => $"{nameof(Key)}: {Key}, {nameof(Value)}: {Value}";
    }
}