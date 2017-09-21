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

            var sThisLoad = Observable.FromEventPattern(this, "Load");
            sThisLoad.Subscribe(_ => Util.clearLabels(errUsername_label, errPassword_label));

            var sSignInButtonClick = Observable.FromEventPattern(signIn_button, "Click");

            var sUsernameHasValue = sSignInButtonClick.Select(_ => username_tb.Text.HasValue());
            var sPasswordHasValue = sSignInButtonClick.Select(_ => password_tb.Text.HasValue());

            const int Threshold = 6;

            var sUsernameIsShort = sSignInButtonClick.Select(_ => username_tb.Text.IsLengthLessThan(Threshold));
            var sPasswordIsShort = sSignInButtonClick.Select(_ => password_tb.Text.IsLengthLessThan(Threshold));

            Func<bool, bool, string> noValueOrIsShortError = (hasValue, isShort) => hasValue ? isShort ? $"Must at least {Threshold} characters." : string.Empty : "Required";

            var sUsernameHasValueOrNotShort = sUsernameHasValue.CombineLatest(sUsernameIsShort, noValueOrIsShortError);
            sUsernameHasValueOrNotShort.Subscribe(err => errUsername_label.Text = err);

            var sPasswordHasValueOrNotShort = sPasswordHasValue.CombineLatest(sPasswordIsShort, noValueOrIsShortError);
            sPasswordHasValueOrNotShort.Subscribe(err => errPassword_label.Text = err);

            var sExist = sSignInButtonClick
                .Where(_ =>
                    username_tb.Text.HasValue() &&
                    password_tb.Text.HasValue() &&
                    !username_tb.Text.IsLengthLessThan(Threshold) &&
                    !password_tb.Text.IsLengthLessThan(Threshold))
                .Select(_ => Account.Create(Username: username_tb.Text, Password: password_tb.Text))
                .Select(account => AccountDatabase.Accounts.Exists(account_ => account_.Equals(account)));

            var sNotExist = sExist.Where(accountExist => accountExist.Equals(false));
            sNotExist.Subscribe(_ => password_tb.Clear());
            sNotExist.Subscribe(_ => MessageBox.Show("Your account is not registered."));

            var exist = sExist.Where(accountExist => accountExist.Equals(true));
            exist.Subscribe(_ => new MainForm().UShow());
            exist.Subscribe(_ => this.UHide());

            var sRegisterButtonClick = Observable.FromEventPattern(register_button, "Click")
                .Select(_ => new RegistrationForm())
                .Subscribe(form => form.UShowDialog());

        } /* end constructor. */
    } /* end class. */
}