using hms_proto.Records;

namespace hms_proto.Extensions
{
    internal static class RoomExt
    {
        internal static bool IsVacant(this Room room)
            => room.Status == RoomStatus.Vacant;
        internal static string[] ToStringArray(this Room room)
            => new[] { room.No.ToString(), room.Type.ToString(), room.Status.ToString() };
    }
}
