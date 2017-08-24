namespace hms_proto.Records
{
    struct Account
    {
        internal string Username { get; private set; }
        internal string Password { get; private set; }
        internal Account (string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
        public override string ToString () => $"Account Username: {Username}";
    }
}
