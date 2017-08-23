using hms_proto.Records;
using System;
using System.Diagnostics.Contracts;

namespace hms_proto.Extensions
{
    internal static class ArrayExt
    {
        internal static Room ToRoom(this string[] Data)
        {
            #region PreConditions
            Contract.Requires(Data != null);
            Contract.Requires(Data.Length > 3);
            Contract.Requires(!string.IsNullOrEmpty(Data[0]));
            Contract.Requires(!string.IsNullOrEmpty(Data[1]));
            Contract.Requires(!string.IsNullOrEmpty(Data[2]));
            #endregion PreConditions

            RoomType roomType;
            Enum.TryParse(value: Data[1], result: out roomType);

            RoomStatus status;
            Enum.TryParse(value: Data[2], result: out status);

            return new Room(
                No: Convert.ToInt16(Data[0]),
                Type: roomType,
                Status: status);
        }
    }
}
