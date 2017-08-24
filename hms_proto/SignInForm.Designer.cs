namespace hms_proto
{
  partial class SignInForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.signIn_button = new System.Windows.Forms.Button();
            this.username_label = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.register_button = new System.Windows.Forms.Button();
            this.errUsername_label = new System.Windows.Forms.Label();
            this.errPassword_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signIn_button
            // 
            this.signIn_button.Location = new System.Drawing.Point(114, 96);
            this.signIn_button.Name = "signIn_button";
            this.signIn_button.Size = new System.Drawing.Size(100, 23);
            this.signIn_button.TabIndex = 0;
            this.signIn_button.Text = "Sign In";
            this.signIn_button.UseVisualStyleBackColor = true;
            this.signIn_button.Click += new System.EventHandler(this.signIn_button_Click);
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.Location = new System.Drawing.Point(52, 47);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(58, 13);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "Username:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(52, 73);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(56, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // username_tb
            // 
            this.username_tb.Location = new System.Drawing.Point(114, 44);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(100, 20);
            this.username_tb.TabIndex = 3;
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(114, 70);
            this.password_tb.Name = "password_tb";
            this.password_tb.PasswordChar = '*';
            this.password_tb.Size = new System.Drawing.Size(100, 20);
            this.password_tb.TabIndex = 4;
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(114, 125);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(100, 23);
            this.register_button.TabIndex = 5;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // errUsername_label
            // 
            this.errUsername_label.AutoSize = true;
            this.errUsername_label.Location = new System.Drawing.Point(220, 47);
            this.errUsername_label.Name = "errUsername_label";
            this.errUsername_label.Size = new System.Drawing.Size(19, 13);
            this.errUsername_label.TabIndex = 6;
            this.errUsername_label.Text = "err";
            this.errUsername_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errPassword_label
            // 
            this.errPassword_label.AutoSize = true;
            this.errPassword_label.Location = new System.Drawing.Point(220, 73);
            this.errPassword_label.Name = "errPassword_label";
            this.errPassword_label.Size = new System.Drawing.Size(19, 13);
            this.errPassword_label.TabIndex = 7;
            this.errPassword_label.Text = "err";
            this.errPassword_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 176);
            this.Controls.Add(this.errPassword_label);
            this.Controls.Add(this.errUsername_label);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.username_tb);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.signIn_button);
            this.Name = "SignInForm";
            this.Text = "Sign In";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button signIn_button;
    private System.Windows.Forms.Label username_label;
    private System.Windows.Forms.Label passwordLabel;
    private System.Windows.Forms.TextBox username_tb;
    private System.Windows.Forms.TextBox password_tb;
    private System.Windows.Forms.Button register_button;
    private System.Windows.Forms.Label errUsername_label;
    private System.Windows.Forms.Label errPassword_label;
  }
}