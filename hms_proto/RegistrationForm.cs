using hms_proto.Controllers;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Windows.Forms;

namespace hms_proto
{
    public partial class RegistrationForm : Form
    {
        private Label[] ErrLabels { get; set; }

        public RegistrationForm ()
        {
            InitializeComponent();

            ErrLabels = new[] { errUsername_label, errPassword_label, errConfirmPassword_label };
            Util.clearLabels(ErrLabels);
        }

        private void reg_button_Click (object sender, EventArgs e) =>
            AccountController.Register(new RegisterControls(
                ThisForm: this,
                MainForm: new MainForm(),
                UserNameField: username_tb,
                PasswordField: password_tb,
                ConfirmPasswordField: confirmPassword_tb,
                UserNameError: errUsername_label,
                PasswordError: errPassword_label,
                ConfirmPasswordError: errConfirmPassword_label));
        /* end register event. */
    }
}