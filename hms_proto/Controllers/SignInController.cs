using hms_proto.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using hms_proto.Extensions;
using hms_proto.Records;
using hms_proto.Database;

namespace hms_proto.Controllers
{
    

    static class SignInController
    {
        /// <summary>
        /// This method performs step by step side effect in signing in.
        /// </summary>
        /// <param name="controls">The input controls.</param>
        internal static void SignIn(SignInControls controls)
        {
            var clearedErrorLabels = Util.clearLabels(controls.ErrorLabels);

            var username = controls.UserNameField.Text;
            var password = controls.PasswordField.Text;

            var rawValues = new[] { username, password };
            Func<string, string> trim = str => str.Trim();
            var values = rawValues.Select(trim);

            var fieldsAndValues = clearedErrorLabels.Zip(values, Tuple.Create).ToArray();

            #region Check Has Empty Fields.
            Func<Tuple<Label, string>, bool> emptyField = fieldAndValue => string.IsNullOrEmpty(fieldAndValue.Item2);
            Func<string, Func<Label, Label>> changeText = text => label => label.ChangeText(text);
            Action<Label[]> showRequiredField = labels => labels.Select(changeText("is required.")).ToArray();
            if (Util.IsValidValuedField(
              Validation: emptyField,
              OnInValidField: showRequiredField,
              ErrorFieldsAndValues: fieldsAndValues)) return;
            #endregion

            #region Check Has Min Chars.
            var MinChars = 6;
            Func<Tuple<Label, string>, bool> shortValueField = fieldAndValue => fieldAndValue.Item2.Length < MinChars;
            Action<Label[]> showShortField = labels => labels.Select(changeText("is too short.")).ToArray();
            if (Util.IsValidValuedField(
              Validation: shortValueField,
              OnInValidField: showShortField,
              ErrorFieldsAndValues: fieldsAndValues)) return;
            #endregion check has min chars.

            #region Check Account Existence.
            var account = new Account { Username = username, Password = password };
            var Accounts = AccountDatabase.Accounts;
            Predicate<Account> matchUsername = acc => acc.Username.Equals(acc.Username);
            if (!Accounts.Exists(matchUsername)) { MessageBox.Show("Your account is not registered."); return; }
            #endregion check account existence.

            #region Clear All Textbox Contents.
            Func<TextBox, TextBox> clearTextBox = TextBox => { TextBox.Clear(); return TextBox; };
            controls.Fields.Select(clearTextBox).ToArray();
            #endregion

            controls.MainForm.Show();
            controls.ThisForm.Hide();
        } /* end Sign In. */
    }
}
