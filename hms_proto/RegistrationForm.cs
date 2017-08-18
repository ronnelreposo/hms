using hms_proto.Database;
using hms_proto.Records;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hms_proto
{
  public partial class RegistrationForm: Form
  {
    public RegistrationForm()
    {
      InitializeComponent();

      var errorLabels = new[] { errUsername_label, passwordErr_label, errConfirmPassword_label };
      Func<Label, Label> clearTextBox = Label => { Label.Text = string.Empty; return Label; };
      errorLabels.Select(clearTextBox).ToArray();

    }

    bool isValidValuedField(Func<Tuple<string, string>, bool> Validation,
      Action<string> OnInValidField,
      Tuple<string, string>[] FieldsAndValues)
    {
      var firstFieldWithEmptyValue = FieldsAndValues.FirstOrDefault(Validation);
      if (firstFieldWithEmptyValue != null) { OnInValidField(firstFieldWithEmptyValue.Item1); return true; }
      return false;
    }

    private void reg_button_Click(object sender, EventArgs e)
    {
      var fields = new[] { "Username", "Password", "Password Confirmation" };

      var username = username_tb.Text;
      var password = password_tb.Text;
      var passwordConfirmation = confirmPassword_tb.Text;

      var rawValues = new[] { username, password, passwordConfirmation };
      Func<string, string> trim = str => str.Trim();
      var values = rawValues.Select(trim);
      
      var fieldsAndValues = fields.Zip(values, Tuple.Create).ToArray();

      Func<Tuple<string, string>, bool> emptyField = fieldAndValue => string.IsNullOrEmpty(fieldAndValue.Item2);
      Action<string> showRequiredField = field => MessageBox.Show(field + " is required.");
      var hasOneEmptyFieldValue = isValidValuedField(
        Validation: emptyField,
        OnInValidField: showRequiredField,
        FieldsAndValues: fieldsAndValues);
      if (hasOneEmptyFieldValue) { return; }

      var MinChars = 6;
      Func<Tuple<string, string>, bool> shortValueField = fieldAndValue => fieldAndValue.Item2.Length < MinChars;
      Action<string> showShortField = field => MessageBox.Show(field + " is too short.");
      var hasOneShortFieldValue = isValidValuedField(
        Validation: shortValueField,
        OnInValidField: showShortField,
        FieldsAndValues: fieldsAndValues);
      if (hasOneShortFieldValue) { return; }

      #region Ensures that the password confirmation matches.
      var passwordConfirmationMatched = password.Equals(passwordConfirmation);
      if (!passwordConfirmationMatched)
      {
        MessageBox.Show("Your password confirmation did not match.");
        return;
      }
      #endregion end password match confirmation.

      var Accounts = AccountDatabase.Accounts;

      #region Ensures that the username doesn't exist in the database.
      Predicate<Account> matchUsername = Record => Record.Username.Equals(username);
      var isAccountExist = Accounts.Exists(matchUsername);
      if (isAccountExist)
      {
        MessageBox.Show("Username is already registered. Please pick another one.");
        return;
      }
      #endregion isAccountExist condition.

      #region Save Account.
      Accounts.Add(new Account { Username = username, Password = password });
      #endregion

      #region Show success message.
      MessageBox.Show("Your account has been successfully registered.");
      #endregion

      #region Clear all Textbox contents.
      var textBoxFields = new[] { username_tb, password_tb, confirmPassword_tb };
      Func<TextBox, TextBox> clearTextBox = TextBox => { TextBox.Clear(); return TextBox; };
      textBoxFields.Select(clearTextBox).ToArray();
      #endregion

    } /* end register event. */

  }
}