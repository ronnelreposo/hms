using hms_proto.Controllers;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Windows.Forms;

namespace hms_proto {
    public partial class SignInForm: Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        void signIn_button_Click(object sender, EventArgs e) =>
            SignInController.SignIn(new SignInControls {
                UserNameField = username_tb,
                PasswordField = password_tb,
                UserNameError = errUsername_label,
                PasswrodError = errPassword_label,
                ThisForm = this,
                MainForm = new MainForm()
            });

        void register_button_Click(object sender, EventArgs e) => new RegistrationForm().ShowDialog();
        void SignInForm_Load(object sender, EventArgs e) => Util.clearLabels(errUsername_label, errPassword_label);
    }
}