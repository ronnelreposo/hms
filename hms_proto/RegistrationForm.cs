using hms_proto.Controllers;
using hms_proto.Records;
using hms_proto.Utils;
using hms_proto.Extensions;
using System;
using System.Reactive.Linq;
using System.Windows.Forms;
using System.Reactive.Subjects;

namespace hms_proto
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm ()
        {
            InitializeComponent();

            Func<string, string> err = str => str.Equals(string.Empty) ? "required" :
                (str.IsLengthLessThan(6) ? "too short" : string.Empty);

            var sUsernameErr = username_tb
                .StreamStringTextChanged()
                .Select(err);

            var b = new BehaviorSubject<string>(string.Empty);
            sUsernameErr.Subscribe(b);
            b.Subscribe(str => errUsername_label.Text = str);

            var c = new BehaviorSubject<bool>(false);
            sUsernameErr
                .Select(str => !str.HasValue())
                .Subscribe(c);
            c.Subscribe(enable => password_tb.Enabled = enable);

            

        } /* end constructor. */
    } /* end class. */
}