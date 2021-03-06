﻿using System;
using System.Windows.Forms;

namespace hms_proto.Records
{
    struct SignInControls
    {
        public Form ThisForm {get; private set;}
        public Form MainForm { get; private set; }
        public TextBox UserNameField { get; private set; }
        public TextBox PasswordField { get; private set; }
        public Label UserNameError { get; private set; }
        public Label PasswordError { get; private set; }

        public TextBox[] Fields
        {
            get {
                var field = new[] { UserNameField, PasswordField };
                var copy = field.Clone();
                return copy as TextBox[];
            }
        }

        public Label[] ErrorLabels
        {
            get {
                var field = new[] { UserNameError, PasswordError };
                var copy = field.Clone();
                return copy as Label[];
            }
        }

        public SignInControls(Form ThisForm,
            Form MainForm,
            TextBox UserNameField,
            TextBox PasswordField,
            Label UserNameError,
            Label PasswordError)
        {
            this.ThisForm = ThisForm;
            this.MainForm = MainForm;
            this.UserNameField = UserNameField;
            this.PasswordField = PasswordField;
            this.UserNameError = UserNameError;
            this.PasswordError = PasswordError;
        }
    }
}
