using System.Data;
using System.Diagnostics.Contracts;

namespace hms_proto.Extensions
{
    static class DataColumnCollectionExt
    {
        internal static DataColumnCollection Add(this DataColumnCollection collection, int i = 0, params string[] values)
        {
            Contract.Requires(collection != null);

            if (i > (values.Length - 1)) { return collection; }
            collection.Add(values[i]);
            return Add(collection, (i + 1), values);
        }

        internal static DataColumnCollection Add(this DataColumnCollection collection, params string[] values) => Add(collection, 0, values);
    }
}
