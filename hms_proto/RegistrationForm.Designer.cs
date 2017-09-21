namespace hms_proto
{
  partial class RegistrationForm
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
            this.reg_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.confirmPassword_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errUsername_label = new System.Windows.Forms.Label();
            this.errPassword_label = new System.Windows.Forms.Label();
            this.errConfirmPassword_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // reg_button
            // 
            this.reg_button.Location = new System.Drawing.Point(99, 134);
            this.reg_button.Name = "reg_button";
            this.reg_button.Size = new System.Drawing.Size(100, 23);
            this.reg_button.TabIndex = 0;
            this.reg_button.Text = "Register";
            this.reg_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // username_tb
            // 
            this.username_tb.Location = new System.Drawing.Point(99, 53);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(100, 20);
            this.username_tb.TabIndex = 3;
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(99, 82);
            this.password_tb.Name = "password_tb";
            this.password_tb.PasswordChar = '*';
            this.password_tb.Size = new System.Drawing.Size(100, 20);
            this.password_tb.TabIndex = 4;
            // 
            // confirmPassword_tb
            // 
            this.confirmPassword_tb.Location = new System.Drawing.Point(99, 108);
            this.confirmPassword_tb.Name = "confirmPassword_tb";
            this.confirmPassword_tb.PasswordChar = '*';
            this.confirmPassword_tb.Size = new System.Drawing.Size(100, 20);
            this.confirmPassword_tb.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm:";
            // 
            // errUsername_label
            // 
            this.errUsername_label.AutoSize = true;
            this.errUsername_label.Location = new System.Drawing.Point(205, 56);
            this.errUsername_label.Name = "errUsername_label";
            this.errUsername_label.Size = new System.Drawing.Size(20, 13);
            this.errUsername_label.TabIndex = 7;
            this.errUsername_label.Text = "Err";
            this.errUsername_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errPassword_label
            // 
            this.errPassword_label.AutoSize = true;
            this.errPassword_label.Location = new System.Drawing.Point(205, 85);
            this.errPassword_label.Name = "errPassword_label";
            this.errPassword_label.Size = new System.Drawing.Size(20, 13);
            this.errPassword_label.TabIndex = 8;
            this.errPassword_label.Text = "Err";
            this.errPassword_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // errConfirmPassword_label
            // 
            this.errConfirmPassword_label.AutoSize = true;
            this.errConfirmPassword_label.Location = new System.Drawing.Point(205, 111);
            this.errConfirmPassword_label.Name = "errConfirmPassword_label";
            this.errConfirmPassword_label.Size = new System.Drawing.Size(20, 13);
            this.errConfirmPassword_label.TabIndex = 9;
            this.errConfirmPassword_label.Text = "Err";
            this.errConfirmPassword_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 182);
            this.Controls.Add(this.errConfirmPassword_label);
            this.Controls.Add(this.errPassword_label);
            this.Controls.Add(this.errUsername_label);
            this.Controls.Add(this.confirmPassword_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.username_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reg_button);
            this.Name = "RegistrationForm";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button reg_button;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox username_tb;
    private System.Windows.Forms.TextBox password_tb;
    private System.Windows.Forms.TextBox confirmPassword_tb;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label errUsername_label;
    private System.Windows.Forms.Label errPassword_label;
    private System.Windows.Forms.Label errConfirmPassword_label;
  }
}