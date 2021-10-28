namespace Puzzel.SmsGateway.Client.Constants
{
    /// <summary>
    /// Prioritization between messages sent from the same service.
    /// </summary>
    public static class Priority
    {
        /// <summary>
        /// Low (slower).
        /// </summary>
        public const int Low = 1;

        /// <summary>
        /// Medium.
        /// </summary>
        public const int Medium = 2;

        /// <summary>
        /// High (faster).
        /// </summary>
        public const int High = 3;
    }
}