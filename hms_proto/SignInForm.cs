using hms_proto.Database;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Data;
using System.Linq;
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
      var clearedErrorLabels = Util.clearLabels(errLabels);

      var username = username_tb.Text;
      var password = password_tb.Text;

      var rawValues = new[] { username, password };
      Func<string, string> trim = str => str.Trim();
      var values = rawValues.Select(trim);
      
      var fieldsAndValues = clearedErrorLabels.Zip(values, Tuple.Create).ToArray();
      
      Func<Tuple<Label, string>, bool> emptyField = fieldAndValue => string.IsNullOrEmpty(fieldAndValue.Item2);
      Func<string, Func<Label, Label>> changeText = text => label => { label.Text = text; return label; };
      Action<Label[]> showRequiredField = labels => { labels.Select(changeText("is required.")).ToArray(); };
      var hasOneEmptyFieldValue = Util.IsValidValuedField(
        Validation: emptyField,
        OnInValidField: showRequiredField,
        ErrorFieldsAndValues: fieldsAndValues);
      if (hasOneEmptyFieldValue) { return; }

      var MinChars = 6;
      Func<Tuple<Label, string>, bool> shortValueField = fieldAndValue => fieldAndValue.Item2.Length < MinChars;
      Action<Label[]> showShortField = labels => { labels.Select(changeText("is too short.")).ToArray(); };
      var hasOneShortFieldValue = Util.IsValidValuedField(
        Validation: shortValueField,
        OnInValidField: showShortField,
        ErrorFieldsAndValues: fieldsAndValues);
      if (hasOneShortFieldValue) { return; }

      var account = new Account { Username = username_tb.Text, Password = password_tb.Text };

      var Accounts = AccountDatabase.Accounts;
      Predicate<Account> matchUsername = acc => acc.Username.Equals(acc.Username);
      var accountExist = Accounts.Exists(matchUsername);
      if (!accountExist) { MessageBox.Show("Your account is not registered."); return; }

      #region Clear all Textbox contents.
      var textBoxFields = new[] { username_tb, password_tb };
      Func<TextBox, TextBox> clearTextBox = TextBox => { TextBox.Clear(); return TextBox; };
      textBoxFields.Select(clearTextBox).ToArray();
      #endregion

      MessageBox.Show("Welcome.");
    }

    private void register_button_Click(object sender, EventArgs e) => new RegistrationForm().ShowDialog();
  }
}