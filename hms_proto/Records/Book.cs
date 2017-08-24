using System;

namespace hms_proto.Records
{
    struct Book
    {
        internal Room Room { get; private set; }
        internal Customer Customer { get; private set; }
        internal DateTime DateIn { get; private set; }
        internal DateTime DateOut { get; private set; }
        internal Book (Room Room, Customer Customer, DateTime DateIn, DateTime DateOut)
        {
            this.Room = Room;
            this.Customer = Customer;
            this.DateIn = DateIn;
            this.DateOut = DateOut;
        }
        public override string ToString () =>
            string.Format($"Book\n{Room.ToString()},\n{Customer.ToString()},\n@{DateIn.ToString()}-{DateOut.ToString()}");
    }
}
