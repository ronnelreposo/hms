using System;
using System.Diagnostics.Contracts;

namespace hms_proto.Extensions
{
    internal static class Collection
    {
        internal static S ToCollection<S, T>(int i, S accumulator, Func<int, bool> condition, Action<S, int> accumulation, T collection)
        {
            #region PostConditions
            Contract.Requires(i > -1);
            Contract.Requires(condition != null);
            Contract.Requires(accumulator != null);
            Contract.Requires(collection != null);
            #endregion PostConditions

            if (condition(i)) { return accumulator; }
            accumulation(accumulator, i);
            return ToCollection((i + 1), accumulator, condition, accumulation, collection);
        }
    }
}
