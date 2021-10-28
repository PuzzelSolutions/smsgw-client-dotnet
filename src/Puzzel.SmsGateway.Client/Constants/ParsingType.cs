namespace Puzzel.SmsGateway.Client.Constants
{
    /// <summary>
    /// Parsing type.
    /// </summary>
    public static class ParsingType
    {
        /// <summary>
        /// None.
        /// This is the default behaviour. Any invalid characters will lead to an error and the message will not be sent.
        /// </summary>
        public const string None = "NONE";

        /// <summary>
        /// Remove non-GSM characters.
        /// Any invalid characters will be removed and the message will be sent. E.g. "Testing: Клавдии áàóòúù" will result in "Testing àòù".
        /// </summary>
        public const string SafeRemoveNonGsmCharacters = "SAFE_REMOVE_NON_GSM";

        /// <summary>
        /// Replace non-GSM characters.
        /// Any invalid characters will be replaced or removed and the message will be sent.
        /// Characters that will be replaced are "accented" characters, e.g. "Testing Клавдии áàóòúù " will result in "Testing aàoòuù".
        /// </summary>
        public const string SafeRemoveNonGsmCharactersWithReplace = "SAFE_REMOVE_NON_GSM_WITH_REPLACE";

        /// <summary>
        /// Auto detect.
        /// </summary>
        public const string AutoDetect = "AUTO_DETECT";
    }
}