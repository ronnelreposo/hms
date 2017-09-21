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
        public SignInForm ()
        {
            InitializeComponent();

            const int Threshold = 6;
            const string Required = "Required";
            var ShortValue = $"Must at least {Threshold} characters.";

            Func<string, string> hasStrError = str => str.HasValue() ?  ( str.IsLengthLessThan(Threshold) ? ShortValue : string.Empty ) : Required;

            var sUsernameError = username_tb.StreamStringTextChanged().Select(hasStrError);
            sUsernameError.Subscribe(str => errUsername_label.Text = str);

            var sPasswordError = password_tb.StreamStringTextChanged().Select(hasStrError);
            sPasswordError.Subscribe(str => errPassword_label.Text = str);

            Func<string, bool> hasError = err => err.Equals(string.Empty);
            var sHasNoError = sUsernameError
                .Select(hasError)
                .CombineLatest(sPasswordError.Select(hasError), (a, b) => a && b);
            sHasNoError.Subscribe(hasNoError => signIn_button.Enabled = hasNoError);

            var sEventThisLoad = this.StreamEventLoad();
            sEventThisLoad.Subscribe(_ => Util.clearLabels(errUsername_label, errPassword_label));
            sEventThisLoad.Subscribe(_ => signIn_button.Enabled = false);

            var sExist = signIn_button
                .StreamClick()
                .Select(_ => Account.Create(Username: username_tb.Text, Password: password_tb.Text))
                .Select(account => AccountDatabase.Accounts.Exists(account_ => account_.Equals(account)));

            var sAccountNonExist = sExist.Where(accountExist => accountExist.Equals(false));
            sAccountNonExist.Subscribe(_ => password_tb.Clear());
            sAccountNonExist.Subscribe(_ => MessageBox.Show("Your account is not registered."));

            var sAccountExist = sExist.Where(accountExist => accountExist.Equals(true));
            sAccountExist.Subscribe(_ => new MainForm().UShow());
            sAccountExist.Subscribe(_ => this.UHide());

            register_button
                .StreamClick()
                .Select(_ => new RegistrationForm())
                .Subscribe(form => form.UShowDialog());
        } /* end constructor. */
    } /* end class. */
}