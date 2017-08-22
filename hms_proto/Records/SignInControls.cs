using System.Windows.Forms;

namespace hms_proto.Records
{
    internal class SignInControls
    {
        internal Form ThisForm {get; set;}
        internal Form MainForm { get; set; }
        internal TextBox UserNameField { get; set; }
        internal TextBox PasswordField { get; set; }
        internal Label UserNameError { get; set; }
        internal Label PasswrodError { get; set; }

        internal TextBox[] Fields
        {
            get { return new[] { UserNameField, PasswordField }; }
        }

        internal Label[] ErrorLabels
        {
            get { return new[] { UserNameError, PasswrodError }; }
        }
    }
}
