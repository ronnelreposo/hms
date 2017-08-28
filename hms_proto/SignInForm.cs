using hms_proto.Controllers;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Windows.Forms;
using hms_proto.Extensions;
using hms_proto.Core;

namespace hms_proto {
    public partial class SignInForm: Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        Unit signIn_button_Click(object sender, EventArgs e) =>
            AccountController.SignIn(new SignInControls(
                UserNameField: username_tb,
                PasswordField: password_tb,
                UserNameError: errUsername_label,
                PasswordError: errPassword_label,
                ThisForm: this,
                MainForm: new MainForm()));

        Unit register_button_Click (object sender, EventArgs e) => new RegistrationForm().UShowDialog();
        protected override void OnLoad(EventArgs _) => Util.clearLabels(errUsername_label, errPassword_label);
    }
}