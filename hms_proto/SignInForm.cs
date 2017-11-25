using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Windows.Forms;
using hms_proto.Extensions;
using System.Reactive.Linq;
using hms_proto.Database;

namespace hms_proto {

    public partial class SignInForm: Form
    {
        internal static readonly int Threshold = 6;
        internal static readonly string Required = "Required";
        internal static readonly string ShortValue = $"Must at least {Threshold} characters.";
        internal static readonly Func<string, string> hasStrError = str => str.HasValue() ?
                ( str.IsLengthLessThan(Threshold) ? ShortValue : string.Empty ) : Required;

        public SignInForm ()
        {
            InitializeComponent();

            var sUsernameError = username_tb.StreamStringTextChanged().Select(hasStrError);
            sUsernameError.Subscribe(str => errUsername_label.Text = str);

            var sPasswordError = password_tb.StreamStringTextChanged().Select(hasStrError);
            sPasswordError.Subscribe(str => errPassword_label.Text = str);

            Func<string, bool> hasError = err => err.Equals(string.Empty);
            sUsernameError
                .Select(hasError)
                .CombineLatest(sPasswordError.Select(hasError), (a, b) => a && b)
                .Subscribe(b => signIn_button.Enabled = b);

            var sEventThisLoad = this.StreamEventLoad();
            sEventThisLoad
                .Select(_ => new[] { errUsername_label, errPassword_label })
                .Subscribe(labels => Util.clearLabels(labels));
            sEventThisLoad
                .Select(_ => false)
                .Subscribe(no => signIn_button.Enabled = no);

            var sExist = signIn_button
                .StreamClick()
                .Select(_ => Account.Create(Username: username_tb.Text, Password: password_tb.Text))
                .Select(account => AccountDatabase.Accounts.Exists(account_ => account_.Equals(account)));

            var sAccountNonExist = sExist
                .Where(accountExist => accountExist.Equals(false));
            sAccountNonExist
                .Select(_ => password_tb)
                .Subscribe(textBox => textBox.Clear());
            sAccountNonExist
                .Select(_ => "Your account is not registered.")
                .Subscribe(message => MessageBox.Show(message));

            var sAccountExist = sExist
                .Where(accountExist => accountExist.Equals(true));
            sAccountExist.Select(_ => new MainForm()).Subscribe(form => form.UShow());
            sAccountExist.Select(_ => this).Subscribe(form => form.UHide());

            register_button
                .StreamClick()
                .Select(_ => new RegistrationForm())
                .Subscribe(form => form.UShowDialog());
        } /* end constructor. */
    } /* end class. */
}