using System;
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
            
            get {
                var field = new[] { UserNameField, PasswordField };
                var copy = field.Clone();
                return (TextBox[]) copy;
            }
        }

        internal Label[] ErrorLabels
        {
            get {
                var field = new[] { UserNameError, PasswordError };
                var copy = field.Clone();
                return (Label[]) copy;
            }
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
