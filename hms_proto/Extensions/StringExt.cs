namespace hms_proto.Extensions
{
    internal static class StringExt
    {
        /// <summary>
        /// Replaces the value of the string with Default value if it is null or empty.
        /// </summary>
        /// <param name="str">The given string.</param>
        /// <param name="Default">The default string.</param>
        /// <returns></returns>
        internal static string OrWithValue(this string str, string Default) => string.IsNullOrEmpty(str) ? Default : str;
        /// <summary>
        /// Determines if the length of the string is less than the given threshold.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        internal static bool IsLengthLessThan(this string str, int threshold) => str.Length < threshold;

        /// <summary>
        /// Determines if the string is niether null or empty.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static bool HasValue(this string str) => !string.IsNullOrEmpty(str.Trim());
    }
}
