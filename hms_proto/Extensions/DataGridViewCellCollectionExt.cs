using System;
using System.Diagnostics.Contracts;
using System.Windows.Forms;

namespace hms_proto.Extensions
{
    internal static class DataGridViewCellCollectionExt
    {
        internal static T[] ToArray<T>(this DataGridViewCellCollection Collection)
        {
            Contract.Requires(Collection != null);

            Func<int, bool> isGreaterThanCellCount = i => i > (Collection.Count - 1);
            Action<T[], int> accumulateSeed = (seed, i) => seed[i] = (T) Collection[i].Value;
            var accumulator = new T[Collection.Count];
            return Extensions.Collection.ToCollection(0,
                accumulator: accumulator,
                condition: isGreaterThanCellCount,
                accumulation: accumulateSeed,
                collection: Collection);
        }

        internal static string[] ToArray(this DataGridViewCellCollection Collection) => Collection.ToArray<string>();
    }
}
