using System.Windows.Forms;

namespace hms_proto.Records
{
    struct SignInControls
    {
        internal Form ThisForm {get; private set;}
        internal Form MainForm { get; private set; }
        internal TextBox UserNameField { get; private set; }
        internal TextBox PasswordField { get; private set; }
        internal Label UserNameError { get; private set; }
        internal Label PasswordError { get; private set; }

        internal TextBox[] Fields
        {
            get { return new[] { UserNameField, PasswordField }; }
        }

        internal Label[] ErrorLabels
        {
            get { return new[] { UserNameError, PasswordError }; }
        }

        internal SignInControls(Form ThisForm,
            Form MainForm,
            TextBox UserNameField,
            TextBox PasswordField,
            Label UserNameError,
            Label PasswordError)
        {
            this.ThisForm = ThisForm;
            this.MainForm = MainForm;
            this.UserNameField = UserNameField;
            this.PasswordField = PasswordField;
            this.UserNameError = UserNameError;
            this.PasswordError = PasswordError;
        }
    }
}
