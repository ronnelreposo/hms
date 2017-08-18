using hms_proto.Database;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms_proto
{
  public partial class SignInForm: Form
  {
    public SignInForm()
    {
      InitializeComponent();

      var errLabels = new[] { errUsername_label, errPassword_label };
      Util.clearLabels(errLabels);
    }

    private void signIn_button_Click(object sender, EventArgs e)
    {
      var errLabels = new[] { errUsername_label, errPassword_label };
      Util.clearLabels(errLabels);

      var account = new Account { Username = username_tb.Text, Password = password_tb.Text };

      var Accounts = AccountDatabase.Accounts;
      Predicate<Account> matchUsername = acc => acc.Username.Equals(acc.Username);
      var accountExist = Accounts.Exists(matchUsername);
      if (!accountExist) { MessageBox.Show("Your account is not registered."); return; }

      MessageBox.Show("Welcome.");
    }

    private void register_button_Click(object sender, EventArgs e) => new RegistrationForm().ShowDialog();
  }
}