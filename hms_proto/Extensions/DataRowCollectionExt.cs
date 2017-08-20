using System.Data;
using System.Diagnostics.Contracts;

namespace hms_proto.Extensions
{
    static class DataRowCollectionExt
    {
        internal static DataRowCollection AddRow(this DataRowCollection collection, object[] values)
        {
            Contract.Requires(collection != null);
            Contract.Requires(values != null);

            collection.Add(values);
            return collection;
        }
    }
}
