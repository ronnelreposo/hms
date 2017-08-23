using hms_proto.Database;
using hms_proto.Records;
using hms_proto.Utils;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace hms_proto
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm ()
        {
            InitializeComponent();

            var errorLabels = new[] { errUsername_label, errPassword_label, errConfirmPassword_label };
            Util.clearLabels(errorLabels);
        }

        private void reg_button_Click (object sender, EventArgs e)
        {
            var errorLabels = new[] { errUsername_label, errPassword_label, errConfirmPassword_label };
            var clearedErrorLabels = Util.clearLabels(errorLabels);

            var username = username_tb.Text;
            var password = password_tb.Text;
            var passwordConfirmation = confirmPassword_tb.Text;

            var rawValues = new[] { username, password, passwordConfirmation };
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
            if ( hasOneEmptyFieldValue ) { return; }

            var MinChars = 6;
            Func<Tuple<Label, string>, bool> shortValueField = fieldAndValue => fieldAndValue.Item2.Length < MinChars;
            Action<Label[]> showShortField = labels => { labels.Select(changeText("is too short.")).ToArray(); };
            var hasOneShortFieldValue = Util.IsValidValuedField(
              Validation: shortValueField,
              OnInValidField: showShortField,
              ErrorFieldsAndValues: fieldsAndValues);
            if ( hasOneShortFieldValue ) { return; }

            #region Ensures that the password confirmation matches.
            var passwordConfirmationMatched = password.Equals(passwordConfirmation);
            if ( !passwordConfirmationMatched )
            {
                MessageBox.Show("Your password confirmation did not match.");
                return;
            }
            #endregion end password match confirmation.

            var Accounts = AccountDatabase.Accounts;

            #region Ensures that the username doesn't exist in the database.
            Predicate<Account> matchUsername = Record => Record.Username.Equals(username);
            var isAccountExist = Accounts.Exists(matchUsername);
            if ( isAccountExist )
            {
                MessageBox.Show("Username is already registered. Please pick another one.");
                return;
            }
            #endregion isAccountExist condition.

            #region Save Account.
            Accounts.Add(new Account(Username: username, Password: password));
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