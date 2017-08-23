namespace hms_proto.Records
{
    internal struct Customer
    {
        internal string FirstName { get; private set; }
        internal string LastName { get; private set; }
        internal string Phone { get; private set; }
        internal Customer (string FirstName, string LastName, string Phone)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
        }
    }
}
