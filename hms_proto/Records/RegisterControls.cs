using System.Windows.Forms;

namespace hms_proto.Records
{
    class RegisterControls
    {
        internal SignInControls SignInControls { get; private set; }

        public Form ThisForm { get; private set; }
        public Form MainForm { get; private set; }
        public TextBox UserNameField { get; private set; }
        public TextBox PasswordField { get; private set; } 
        public TextBox ConfirmPasswordField { get; private set; }
        public Label UserNameError { get; private set; }
        public Label PasswordError { get; private set; }
        public Label ConfirmPasswordError { get; private set; }

        public TextBox[] Fields
        {
            get {
                var field = new[] { UserNameField, PasswordField, ConfirmPasswordField };
                var copy = field.Clone();
                return copy as TextBox[];
            }
        }

        public Label[] ErrorLabels
        {
            get {
                var field = new[] { UserNameError, PasswordError, ConfirmPasswordError };
                var copy = field.Clone();
                return copy as Label[];
            }
        }

        public RegisterControls(Form ThisForm,
            Form MainForm,
            TextBox UserNameField,
            TextBox PasswordField,
            TextBox ConfirmPasswordField,
            Label UserNameError,
            Label PasswordError,
            Label ConfirmPasswordError)
        {
            this.ThisForm = ThisForm;
            this.MainForm = MainForm;
            this.UserNameField = UserNameField;
            this.PasswordField = PasswordField;
            this.ConfirmPasswordField = ConfirmPasswordField;
            this.UserNameError = UserNameError;
            this.PasswordError = PasswordError;
            this.ConfirmPasswordError = ConfirmPasswordError;
        }
    }
}
