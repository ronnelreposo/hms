using hms_proto.Controllers;
using hms_proto.Records;
using hms_proto.Utils;
using hms_proto.Extensions;
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

            var controls = new RegisterControls(
                ThisForm: this,
                MainForm: new MainForm(),
                UserNameField: username_tb,
                PasswordField: password_tb,
                ConfirmPasswordField: confirmPassword_tb,
                UserNameError: errUsername_label,
                PasswordError: errPassword_label,
                ConfirmPasswordError: errConfirmPassword_label);

            var sRegButtonClick = reg_button
                .StreamClick()
                .Subscribe(_ => AccountController.Register(controls));

        } /* end constructor.*/
    } /* end class.*/
}