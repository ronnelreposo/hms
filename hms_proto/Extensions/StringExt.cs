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
        internal static string _(this string str, string Default) => string.IsNullOrEmpty(str) ? Default : str;
    }
}
