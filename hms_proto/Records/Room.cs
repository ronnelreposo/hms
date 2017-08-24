namespace hms_proto.Records
{
    internal struct Room
    {
        internal int No { get; private set; }
        internal RoomType Type { get; private set; }
        internal RoomStatus Status { get; private set; }
        internal Room (int No, RoomType Type, RoomStatus Status)
        {
            this.No = No;
            this.Type = Type;
            this.Status = Status;
        }
        public override string ToString () =>
                    string.Format($"Room No:{No}, Status:{Status}");
    }
}