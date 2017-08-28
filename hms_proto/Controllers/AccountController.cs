using hms_proto.Utils;
using System;
using System.Linq;
using System.Windows.Forms;
using hms_proto.Extensions;
using hms_proto.Records;
using hms_proto.Database;
using System.Collections.Generic;
using hms_proto.Core;

namespace hms_proto.Controllers
{
    static class AccountController
    {
        static bool AccountExist (Account account, List<Account> accountList)
        {
            Predicate<Account> matchUsername = savedAccount => savedAccount.Equals(account);
            return accountList.Exists(matchUsername);
        }

        static TextBox[] clearAllTextBox(TextBox[] textboxes)
        {
            Func<TextBox, TextBox> clearTextBox = TextBox => { TextBox.Clear(); return TextBox; };
            return textboxes.Select(clearTextBox).ToArray();
        }

        internal static Tuple<Label, string>[] FieldsAndValues (Label[] fields, string[] values)
        {
            Func<string, string> trim = str => str.Trim();
            var trimmedValues = values.Select(trim);
            return fields.Zip(trimmedValues, Tuple.Create).ToArray();
        }

        /// <summary>
        /// This method performs step by step side effect in registration.
        /// </summary>
        /// <param name="controls">The Form Controls.</param>
        /// <returns>Unit</returns>
        internal static Unit Register (RegisterControls controls)
        {
            var clearedErrorLabels = Util.clearLabels(controls.ErrorLabels);

            var username = controls.UserNameField.Text;
            var password = controls.PasswordField.Text;
            var passwordConfirmation = controls.ConfirmPasswordField.Text;

            var rawValues = new[] { username, password, passwordConfirmation };

            var fieldsAndValues = FieldsAndValues(fields: clearedErrorLabels, values: rawValues);

            if ( Validator.hasEmptyFields(fieldsAndValues) ) return Unit.Unit;

            if ( Validator.hasLessInputFields(fieldsAndValues) ) return Unit.Unit;

            #region Ensures that the password confirmation matches.
            var passwordConfirmationMatched = password.Equals(passwordConfirmation);
            if ( !passwordConfirmationMatched )
            {
                MessageBox.Show("Your password confirmation did not match.");
                return Unit.Unit;
            }
            #endregion end password match confirmation.

            var Accounts = AccountDatabase.Accounts;

            #region Ensures that the username doesn't exist in the database.
            Predicate<Account> matchUsername = Record => Record.Username.Equals(username);
            var isAccountExist = Accounts.Exists(matchUsername);
            if ( isAccountExist )
            {
                MessageBox.Show("Username is already registered. Please pick another one.");
                return Unit.Unit;
            }
            #endregion isAccountExist condition.

            #region Save Account.
            Accounts.Add(new Account(Username: username, Password: password));
            #endregion

            #region Show success message.
            MessageBox.Show("Your account has been successfully registered.");
            #endregion

            #region Clear all Textbox contents.
            Func<TextBox, TextBox> clearTextBox = TextBox => { TextBox.Clear(); return TextBox; };
            controls.Fields.Select(clearTextBox).ToArray();
            #endregion

            return Unit.Unit;
        } /* end Registration. */

        /// <summary>
        /// This method performs step by step side effect in signing in.
        /// </summary>
        /// <param name="controls">The input controls.</param>
        /// <returns>Unit</returns>
        internal static Unit SignIn (SignInControls controls)
        {
            var clearedErrorLabels = Util.clearLabels(controls.ErrorLabels);

            var username = controls.UserNameField.Text;
            var password = controls.PasswordField.Text;

            var rawValues = new[] { username, password };

            var fieldsAndValues = FieldsAndValues(fields: clearedErrorLabels, values: rawValues);

            if ( Validator.hasEmptyFields(fieldsAndValues) ) return Unit.Unit;

            if ( Validator.hasLessInputFields(fieldsAndValues) ) return Unit.Unit;

            var account = new Account(Username: username, Password: password);
            var Accounts = AccountDatabase.Accounts;
            if ( !AccountExist(account, Accounts) ) { MessageBox.Show("Your account is not registered."); return Unit.Unit; }

            clearAllTextBox(controls.Fields);

            #region Continuation
            controls.MainForm.UShow();
            return controls.ThisForm.UHide();
            #endregion
        } /* end Sign In. */
    }
}