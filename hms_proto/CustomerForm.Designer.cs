namespace hms_proto
{
    partial class CustomerForm
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
            this.create_cust_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstname_tb = new System.Windows.Forms.TextBox();
            this.lastname_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // create_cust_button
            // 
            this.create_cust_button.Location = new System.Drawing.Point(97, 100);
            this.create_cust_button.Name = "create_cust_button";
            this.create_cust_button.Size = new System.Drawing.Size(100, 23);
            this.create_cust_button.TabIndex = 0;
            this.create_cust_button.Text = "Create Customer";
            this.create_cust_button.UseVisualStyleBackColor = true;
            this.create_cust_button.Click += new System.EventHandler(this.create_cust_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "First Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Name:";
            // 
            // firstname_tb
            // 
            this.firstname_tb.Location = new System.Drawing.Point(97, 38);
            this.firstname_tb.Name = "firstname_tb";
            this.firstname_tb.Size = new System.Drawing.Size(100, 20);
            this.firstname_tb.TabIndex = 3;
            // 
            // lastname_tb
            // 
            this.lastname_tb.Location = new System.Drawing.Point(97, 64);
            this.lastname_tb.Name = "lastname_tb";
            this.lastname_tb.Size = new System.Drawing.Size(100, 20);
            this.lastname_tb.TabIndex = 4;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 147);
            this.Controls.Add(this.lastname_tb);
            this.Controls.Add(this.firstname_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.create_cust_button);
            this.Name = "CustomerForm";
            this.Text = "Customer Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button create_cust_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox firstname_tb;
        private System.Windows.Forms.TextBox lastname_tb;
    }
}

