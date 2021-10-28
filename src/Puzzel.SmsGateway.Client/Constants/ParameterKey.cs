namespace Puzzel.SmsGateway.Client.Constants
{
    /// <summary>
    /// Parameter keys.
    /// More info: https://github.com/PuzzelSolutions/SMS/blob/master/sections/common.md#parameters
    /// </summary>
    public static class ParameterKey
    {
        /// <summary>
        /// May be used to specify operator specific business models.
        /// Example: productA
        /// Constants are defined in <see cref="Constants.BusinessModel"/>.
        /// </summary>
        public const string BusinessModel = "businessModel";

        /// <summary>
        /// Data Coding Scheme for message
        /// Specifies what data coding scheme to be used for this message. This feature is defined in 3GPP TS 23.038 ch. 4.
        /// Should be one octet (2 hex digits). For example '15' or 'F5'.
        /// Example: F5
        /// </summary>
        public const string Dcs = "dcs";

        /// <summary>
        /// User Data Header
        /// If non-empty will set the TP-User Data Header Indicator (UDHI) for the message.
        /// Defined in 3GPP TS 23.040 ch. 9.2.3.24 TP-User Data (TP-UD).
        /// Example: 0B0504158200000023AB0201
        /// </summary>
        public const string Udh = "udh";

        /// <summary>
        /// Protocol Identifier – replace short message feature
        /// A message containing a PID will replace an existing message having the same PID. Valid values are 65 – 71.
        /// Note: It will only be replaced if the service center address and originating address match the previous message.
        /// Also note that this functionality is only guaranteed to work for messages that are free of charge to receive for the end user.
        /// Many MNOs does not allow this setting for premium SMS.
        /// </summary>
        public const string Pid = "pid";

        /// <summary>
        /// Valid values: True (case-insensitive) - All other values, or if omitted means false.
        /// A flash SMS is a type of text message that - without user action - appears directly and fullscreen on the the mobile phone.
        /// Some terminals will allow you to store this message, other will not.
        /// This functionality may be useful in case of emergencies or if you want to send confidential information, such as a One Time Password.
        /// Note that these messages often are not displayed on lock screens if the phone OS do not already display messages on lockscreen as default (such as iOS).
        /// Also note that this functionality is only guaranteed to work for messages that are free of charge to receive for the end user.
        /// Many MNOs does not allow this setting for premium SMS.
        /// </summary>
        public const string Flash = "flash";

        /// <summary>
        /// The parsing type can be set on the service level and it is recommended to only specify this parameter if you need to override it.
        /// Constants are defined in <see cref="Constants.ParsingType"/>.
        /// </summary>
        public const string ParsingType = "parsing-type";

        /// <summary>
        /// Do not request delivery report (overrides service configuration).
        /// </summary>
        public const string SkipCustomerReportDelivery = "skip_customer_report_delivery";

        /// <summary>
        /// Used for Strex verification process. Specified time in minutes to wait for an end user to complete verification before timing out.
        /// Valid Values: 0-30
        /// </summary>
        public const string StrexVerificationTimeout = "strex_verification_timeout";

        /// <summary>
        /// Used for Strex verification process. Specifies the type of verification process to be used. Use "confirmation" if nothing else is agreed with Strex.
        /// Constants are defined in <see cref="Constants.StrexMerchantSellOption"/>.
        /// </summary>
        public const string StrexMerchantSellOption = "strex_merchant_sell_option";

        /// <summary>
        /// Used for Strex verification process. Specifies the type of channel to to be used for the verification process. Use "sms" if nothing else is agreed with Strex.
        /// Constants are defined in <see cref="Constants.StrexConfirmChannel"/>.
        /// </summary>
        public const string StrexConfirmChannel = "strex_confirm_channel";

        /// <summary>
        /// Used for Strex pre-authentication / authentication process.
        /// Only applies to premium messages sent to Strex customers.
        /// Specifies a Strex authentication token to be used for recurring
        /// premium messages that verifies that users has accepted the payment agreement.
        /// </summary>
        public const string StrexAuthorizationToken = "strex_authorization_token";
    }
}