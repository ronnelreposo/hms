namespace hms_proto.Records
{
    internal struct Room
    {
        internal int no { get; private set; }
        internal int type { get; private set; }
        Room(int no, int type)
        {
            this.no = no;
            this.type = type;
        }
        internal static Room Create(int no, int type) => new Room(no, type);
        internal Room withType(int type) => new Room(no, type);
    }
}