using hms_proto.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using hms_proto.Extensions;
using hms_proto.Records;
using hms_proto.Database;
using System.Collections.Generic;

namespace hms_proto.Controllers
{
    static class SignInController
    {

        static readonly int MinChars = 6;
        static Func<string, Func<Label, Label>> changeText = text => label => label.ChangeText(text);

        static bool hasEmptyFields (Tuple<Label, string>[] fieldsAndValues)
        {
            Func<Tuple<Label, string>, bool> emptyField = fieldAndValue => !fieldAndValue.Item2.HasValue();
            Action<Label[]> showRequiredField = labels => labels.Select(changeText("is required.")).ToArray();
            return Util.IsValidValuedField(
              Validation: emptyField,
              OnInValidField: showRequiredField,
              ErrorFieldsAndValues: fieldsAndValues);
        }

        static bool hasLessInputFields (Tuple<Label, string>[] fieldsAndValues)
        {
            Func<Tuple<Label, string>, bool> shortValueField = fieldAndValue => fieldAndValue.Item2.IsLengthLessThan(MinChars);
            Action<Label[]> showShortField = labels => labels.Select(changeText("is too short.")).ToArray();
            return Util.IsValidValuedField(
              Validation: shortValueField,
              OnInValidField: showShortField,
              ErrorFieldsAndValues: fieldsAndValues);
        }

        static bool AccountExist (Account account, List<Account> accountList)
        {
            Predicate<Account> matchUsername = _ => true; /* temporary */
            return accountList.Exists(matchUsername);
        }

        static TextBox[] clearAllTextBox(TextBox[] textboxes)
        {
            Func<TextBox, TextBox> clearTextBox = TextBox => { TextBox.Clear(); return TextBox; };
            return textboxes.Select(clearTextBox).ToArray();
        }

        /// <summary>
        /// This method performs step by step side effect in signing in.
        /// </summary>
        /// <param name="controls">The input controls.</param>
        internal static void SignIn (SignInControls controls)
        {
            var clearedErrorLabels = Util.clearLabels(controls.ErrorLabels);

            var username = controls.UserNameField.Text;
            var password = controls.PasswordField.Text;

            var rawValues = new[] { username, password };
            Func<string, string> trim = str => str.Trim();
            var values = rawValues.Select(trim);

            var fieldsAndValues = clearedErrorLabels.Zip(values, Tuple.Create).ToArray();

            if ( hasEmptyFields(fieldsAndValues) ) return;

            if ( hasLessInputFields(fieldsAndValues) ) return;

            var account = new Account { Username = username, Password = password };
            var Accounts = AccountDatabase.Accounts;
            if ( AccountExist(account, Accounts) ) { MessageBox.Show("Your account is not registered."); return; }

            clearAllTextBox(controls.Fields);

            #region Continuation
            controls.MainForm.Show();
            controls.ThisForm.Hide();
            #endregion
        } /* end Sign In. */
    }
}