namespace hms_proto.Extensions
{
    internal static class StringExt
    {
        internal static string IfNullOrEmptyReplace(this string str, string Default) => string.IsNullOrEmpty(str) ? Default : str;
    }
}
