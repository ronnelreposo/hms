using hms_proto.Controllers;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace hms_proto
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm ()
        {
            InitializeComponent();

            var errLabels = new[] { errUsername_label, errPassword_label, errConfirmPassword_label };

            var sThisLoad = Observable.FromEventPattern(this, "Load");
            sThisLoad.Subscribe(_ => Util.clearLabels(errLabels));

            var sRegButtonClick = Observable.FromEventPattern(reg_button, "Click");
            sRegButtonClick.Subscribe(_ =>
            AccountController.Register(new RegisterControls(
                ThisForm: this,
                MainForm: new MainForm(),
                UserNameField: username_tb,
                PasswordField: password_tb,
                ConfirmPasswordField: confirmPassword_tb,
                UserNameError: errUsername_label,
                PasswordError: errPassword_label,
                ConfirmPasswordError: errConfirmPassword_label)));

        } /* end constructor.*/
    } /* end class.*/
}