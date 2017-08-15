namespace hms_proto.Records
{
    internal struct Customer
    {
        internal int _id { get; private set; }
        internal string _firstname { get; private set; }
        internal string _lastname { get; private set; }
        Customer(int id, string firstname, string lastname)
        {
            _id = id;
            _firstname = firstname;
            _lastname = lastname;
        }
        internal static Customer Create(int id, string firstname, string lastname) => new Customer(id, firstname, lastname);
        internal Customer withFirstName(string firstname) => new Customer(_id, firstname, _lastname);
        internal Customer withLastName(string lastname) => new Customer(_id, _firstname, lastname);
    }
}
