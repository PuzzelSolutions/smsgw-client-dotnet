namespace Puzzel.SmsGateway.Client.Constants
{
    /// <summary>
    /// Gateway status code.
    /// </summary>
    public enum SmsGatewayStatusCode
    {
        /// <summary>
        /// OK.
        /// </summary>
        MessageDeliveredOk = 1,

        /// <summary>
        /// No access. Authentication failed.
        /// </summary>
        AccessError,

        /// <summary>
        /// An illegal operation was tried.
        /// </summary>
        IllegalAction,

        /// <summary>
        /// An illegal service was tried.
        /// </summary>
        IllegalService,

        /// <summary>
        /// The request contained syntax errors.
        /// </summary>
        SyntaxError,

        /// <summary>
        /// An internal error occurred in the gateway.
        /// </summary>
        InternalError
    }
}