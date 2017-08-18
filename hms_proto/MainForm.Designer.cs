namespace hms_proto
{
  partial class MainForm
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
      this.main_tabControl = new System.Windows.Forms.TabControl();
      this.walkIn_tab = new System.Windows.Forms.TabPage();
      this.walkIn_review_checkBox = new System.Windows.Forms.CheckBox();
      this.walkIn_customerInfo_button = new System.Windows.Forms.Button();
      this.label6 = new System.Windows.Forms.Label();
      this.walkIn_dateOut_dateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.walkIn_roomNo_label = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.walkIn_checkIn_button = new System.Windows.Forms.Button();
      this.walkIn_dataGridView = new System.Windows.Forms.DataGridView();
      this.reservation_tab = new System.Windows.Forms.TabPage();
      this.reservation_review_checkBox = new System.Windows.Forms.CheckBox();
      this.reservation_customerInfo_button = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.reservation_dateIn_dateTimePicker = new System.Windows.Forms.DateTimePicker();
      this.reservation_roomNo_label = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.reservation_reserve_button = new System.Windows.Forms.Button();
      this.reservation_dataGridView = new System.Windows.Forms.DataGridView();
      this.customers_tab = new System.Windows.Forms.TabPage();
      this.customer_isReserved_label = new System.Windows.Forms.Label();
      this.label15 = new System.Windows.Forms.Label();
      this.customer_dateOut_label = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.customer_dateIn_label = new System.Windows.Forms.Label();
      this.label11 = new System.Windows.Forms.Label();
      this.customer_name_label = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.customer_roomNo_label = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.customers_dataGridView = new System.Windows.Forms.DataGridView();
      this.main_tabControl.SuspendLayout();
      this.walkIn_tab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.walkIn_dataGridView)).BeginInit();
      this.reservation_tab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.reservation_dataGridView)).BeginInit();
      this.customers_tab.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.customers_dataGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // main_tabControl
      // 
      this.main_tabControl.Controls.Add(this.walkIn_tab);
      this.main_tabControl.Controls.Add(this.reservation_tab);
      this.main_tabControl.Controls.Add(this.customers_tab);
      this.main_tabControl.Location = new System.Drawing.Point(12, 12);
      this.main_tabControl.Name = "main_tabControl";
      this.main_tabControl.SelectedIndex = 0;
      this.main_tabControl.Size = new System.Drawing.Size(665, 249);
      this.main_tabControl.TabIndex = 0;
      // 
      // walkIn_tab
      // 
      this.walkIn_tab.Controls.Add(this.walkIn_review_checkBox);
      this.walkIn_tab.Controls.Add(this.walkIn_customerInfo_button);
      this.walkIn_tab.Controls.Add(this.label6);
      this.walkIn_tab.Controls.Add(this.walkIn_dateOut_dateTimePicker);
      this.walkIn_tab.Controls.Add(this.walkIn_roomNo_label);
      this.walkIn_tab.Controls.Add(this.label1);
      this.walkIn_tab.Controls.Add(this.walkIn_checkIn_button);
      this.walkIn_tab.Controls.Add(this.walkIn_dataGridView);
      this.walkIn_tab.Location = new System.Drawing.Point(4, 22);
      this.walkIn_tab.Name = "walkIn_tab";
      this.walkIn_tab.Padding = new System.Windows.Forms.Padding(3);
      this.walkIn_tab.Size = new System.Drawing.Size(657, 223);
      this.walkIn_tab.TabIndex = 0;
      this.walkIn_tab.Text = "Walk In";
      this.walkIn_tab.UseVisualStyleBackColor = true;
      // 
      // walkIn_review_checkBox
      // 
      this.walkIn_review_checkBox.AutoSize = true;
      this.walkIn_review_checkBox.Location = new System.Drawing.Point(84, 76);
      this.walkIn_review_checkBox.Name = "walkIn_review_checkBox";
      this.walkIn_review_checkBox.Size = new System.Drawing.Size(62, 17);
      this.walkIn_review_checkBox.TabIndex = 11;
      this.walkIn_review_checkBox.Text = "Review";
      this.walkIn_review_checkBox.UseVisualStyleBackColor = true;
      // 
      // walkIn_customerInfo_button
      // 
      this.walkIn_customerInfo_button.Location = new System.Drawing.Point(84, 99);
      this.walkIn_customerInfo_button.Name = "walkIn_customerInfo_button";
      this.walkIn_customerInfo_button.Size = new System.Drawing.Size(94, 23);
      this.walkIn_customerInfo_button.TabIndex = 10;
      this.walkIn_customerInfo_button.Text = "Customer Info...";
      this.walkIn_customerInfo_button.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(22, 56);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(53, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "Date Out:";
      // 
      // walkIn_dateOut_dateTimePicker
      // 
      this.walkIn_dateOut_dateTimePicker.Location = new System.Drawing.Point(84, 50);
      this.walkIn_dateOut_dateTimePicker.Name = "walkIn_dateOut_dateTimePicker";
      this.walkIn_dateOut_dateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.walkIn_dateOut_dateTimePicker.TabIndex = 8;
      // 
      // walkIn_roomNo_label
      // 
      this.walkIn_roomNo_label.AutoSize = true;
      this.walkIn_roomNo_label.Location = new System.Drawing.Point(81, 34);
      this.walkIn_roomNo_label.Name = "walkIn_roomNo_label";
      this.walkIn_roomNo_label.Size = new System.Drawing.Size(16, 13);
      this.walkIn_roomNo_label.TabIndex = 6;
      this.walkIn_roomNo_label.Text = "---";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(20, 34);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(55, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Room No:";
      // 
      // walkIn_checkIn_button
      // 
      this.walkIn_checkIn_button.Location = new System.Drawing.Point(84, 128);
      this.walkIn_checkIn_button.Name = "walkIn_checkIn_button";
      this.walkIn_checkIn_button.Size = new System.Drawing.Size(94, 23);
      this.walkIn_checkIn_button.TabIndex = 1;
      this.walkIn_checkIn_button.Text = "Check In";
      this.walkIn_checkIn_button.UseVisualStyleBackColor = true;
      // 
      // walkIn_dataGridView
      // 
      this.walkIn_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.walkIn_dataGridView.Location = new System.Drawing.Point(327, 6);
      this.walkIn_dataGridView.Name = "walkIn_dataGridView";
      this.walkIn_dataGridView.Size = new System.Drawing.Size(324, 211);
      this.walkIn_dataGridView.TabIndex = 0;
      // 
      // reservation_tab
      // 
      this.reservation_tab.Controls.Add(this.reservation_review_checkBox);
      this.reservation_tab.Controls.Add(this.reservation_customerInfo_button);
      this.reservation_tab.Controls.Add(this.label2);
      this.reservation_tab.Controls.Add(this.reservation_dateIn_dateTimePicker);
      this.reservation_tab.Controls.Add(this.reservation_roomNo_label);
      this.reservation_tab.Controls.Add(this.label4);
      this.reservation_tab.Controls.Add(this.reservation_reserve_button);
      this.reservation_tab.Controls.Add(this.reservation_dataGridView);
      this.reservation_tab.Location = new System.Drawing.Point(4, 22);
      this.reservation_tab.Name = "reservation_tab";
      this.reservation_tab.Padding = new System.Windows.Forms.Padding(3);
      this.reservation_tab.Size = new System.Drawing.Size(657, 223);
      this.reservation_tab.TabIndex = 1;
      this.reservation_tab.Text = "Reservation";
      this.reservation_tab.UseVisualStyleBackColor = true;
      // 
      // reservation_review_checkBox
      // 
      this.reservation_review_checkBox.AutoSize = true;
      this.reservation_review_checkBox.Location = new System.Drawing.Point(84, 76);
      this.reservation_review_checkBox.Name = "reservation_review_checkBox";
      this.reservation_review_checkBox.Size = new System.Drawing.Size(62, 17);
      this.reservation_review_checkBox.TabIndex = 19;
      this.reservation_review_checkBox.Text = "Review";
      this.reservation_review_checkBox.UseVisualStyleBackColor = true;
      // 
      // reservation_customerInfo_button
      // 
      this.reservation_customerInfo_button.Location = new System.Drawing.Point(84, 99);
      this.reservation_customerInfo_button.Name = "reservation_customerInfo_button";
      this.reservation_customerInfo_button.Size = new System.Drawing.Size(94, 23);
      this.reservation_customerInfo_button.TabIndex = 18;
      this.reservation_customerInfo_button.Text = "Customer Info...";
      this.reservation_customerInfo_button.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(30, 57);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(45, 13);
      this.label2.TabIndex = 17;
      this.label2.Text = "Date In:";
      // 
      // reservation_dateIn_dateTimePicker
      // 
      this.reservation_dateIn_dateTimePicker.Location = new System.Drawing.Point(84, 50);
      this.reservation_dateIn_dateTimePicker.Name = "reservation_dateIn_dateTimePicker";
      this.reservation_dateIn_dateTimePicker.Size = new System.Drawing.Size(200, 20);
      this.reservation_dateIn_dateTimePicker.TabIndex = 16;
      // 
      // reservation_roomNo_label
      // 
      this.reservation_roomNo_label.AutoSize = true;
      this.reservation_roomNo_label.Location = new System.Drawing.Point(81, 34);
      this.reservation_roomNo_label.Name = "reservation_roomNo_label";
      this.reservation_roomNo_label.Size = new System.Drawing.Size(16, 13);
      this.reservation_roomNo_label.TabIndex = 15;
      this.reservation_roomNo_label.Text = "---";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(20, 34);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(55, 13);
      this.label4.TabIndex = 14;
      this.label4.Text = "Room No:";
      // 
      // reservation_reserve_button
      // 
      this.reservation_reserve_button.Location = new System.Drawing.Point(84, 128);
      this.reservation_reserve_button.Name = "reservation_reserve_button";
      this.reservation_reserve_button.Size = new System.Drawing.Size(94, 23);
      this.reservation_reserve_button.TabIndex = 13;
      this.reservation_reserve_button.Text = "Reserve";
      this.reservation_reserve_button.UseVisualStyleBackColor = true;
      // 
      // reservation_dataGridView
      // 
      this.reservation_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.reservation_dataGridView.Location = new System.Drawing.Point(327, 6);
      this.reservation_dataGridView.Name = "reservation_dataGridView";
      this.reservation_dataGridView.Size = new System.Drawing.Size(324, 211);
      this.reservation_dataGridView.TabIndex = 12;
      // 
      // customers_tab
      // 
      this.customers_tab.Controls.Add(this.customer_isReserved_label);
      this.customers_tab.Controls.Add(this.label15);
      this.customers_tab.Controls.Add(this.customer_dateOut_label);
      this.customers_tab.Controls.Add(this.label13);
      this.customers_tab.Controls.Add(this.customer_dateIn_label);
      this.customers_tab.Controls.Add(this.label11);
      this.customers_tab.Controls.Add(this.customer_name_label);
      this.customers_tab.Controls.Add(this.label9);
      this.customers_tab.Controls.Add(this.customer_roomNo_label);
      this.customers_tab.Controls.Add(this.label5);
      this.customers_tab.Controls.Add(this.customers_dataGridView);
      this.customers_tab.Location = new System.Drawing.Point(4, 22);
      this.customers_tab.Name = "customers_tab";
      this.customers_tab.Size = new System.Drawing.Size(657, 223);
      this.customers_tab.TabIndex = 2;
      this.customers_tab.Text = "Customers";
      this.customers_tab.UseVisualStyleBackColor = true;
      // 
      // customer_isReserved_label
      // 
      this.customer_isReserved_label.AutoSize = true;
      this.customer_isReserved_label.Location = new System.Drawing.Point(129, 128);
      this.customer_isReserved_label.Name = "customer_isReserved_label";
      this.customer_isReserved_label.Size = new System.Drawing.Size(16, 13);
      this.customer_isReserved_label.TabIndex = 24;
      this.customer_isReserved_label.Text = "---";
      // 
      // label15
      // 
      this.label15.AutoSize = true;
      this.label15.Location = new System.Drawing.Point(56, 128);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(67, 13);
      this.label15.TabIndex = 23;
      this.label15.Text = "Is Reserved:";
      // 
      // customer_dateOut_label
      // 
      this.customer_dateOut_label.AutoSize = true;
      this.customer_dateOut_label.Location = new System.Drawing.Point(129, 106);
      this.customer_dateOut_label.Name = "customer_dateOut_label";
      this.customer_dateOut_label.Size = new System.Drawing.Size(16, 13);
      this.customer_dateOut_label.TabIndex = 22;
      this.customer_dateOut_label.Text = "---";
      // 
      // label13
      // 
      this.label13.AutoSize = true;
      this.label13.Location = new System.Drawing.Point(70, 106);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(53, 13);
      this.label13.TabIndex = 21;
      this.label13.Text = "Date Out:";
      // 
      // customer_dateIn_label
      // 
      this.customer_dateIn_label.AutoSize = true;
      this.customer_dateIn_label.Location = new System.Drawing.Point(129, 82);
      this.customer_dateIn_label.Name = "customer_dateIn_label";
      this.customer_dateIn_label.Size = new System.Drawing.Size(16, 13);
      this.customer_dateIn_label.TabIndex = 20;
      this.customer_dateIn_label.Text = "---";
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(78, 82);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(45, 13);
      this.label11.TabIndex = 19;
      this.label11.Text = "Date In:";
      // 
      // customer_name_label
      // 
      this.customer_name_label.AutoSize = true;
      this.customer_name_label.Location = new System.Drawing.Point(129, 59);
      this.customer_name_label.Name = "customer_name_label";
      this.customer_name_label.Size = new System.Drawing.Size(16, 13);
      this.customer_name_label.TabIndex = 18;
      this.customer_name_label.Text = "---";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(85, 59);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(38, 13);
      this.label9.TabIndex = 17;
      this.label9.Text = "Name:";
      // 
      // customer_roomNo_label
      // 
      this.customer_roomNo_label.AutoSize = true;
      this.customer_roomNo_label.Location = new System.Drawing.Point(129, 36);
      this.customer_roomNo_label.Name = "customer_roomNo_label";
      this.customer_roomNo_label.Size = new System.Drawing.Size(16, 13);
      this.customer_roomNo_label.TabIndex = 16;
      this.customer_roomNo_label.Text = "---";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(68, 36);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(55, 13);
      this.label5.TabIndex = 15;
      this.label5.Text = "Room No:";
      // 
      // customers_dataGridView
      // 
      this.customers_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.customers_dataGridView.Location = new System.Drawing.Point(330, 5);
      this.customers_dataGridView.Name = "customers_dataGridView";
      this.customers_dataGridView.Size = new System.Drawing.Size(324, 215);
      this.customers_dataGridView.TabIndex = 13;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(689, 273);
      this.Controls.Add(this.main_tabControl);
      this.Name = "MainForm";
      this.Text = "HMS";
      this.main_tabControl.ResumeLayout(false);
      this.walkIn_tab.ResumeLayout(false);
      this.walkIn_tab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.walkIn_dataGridView)).EndInit();
      this.reservation_tab.ResumeLayout(false);
      this.reservation_tab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.reservation_dataGridView)).EndInit();
      this.customers_tab.ResumeLayout(false);
      this.customers_tab.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.customers_dataGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl main_tabControl;
    private System.Windows.Forms.TabPage walkIn_tab;
    private System.Windows.Forms.TabPage reservation_tab;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button walkIn_checkIn_button;
    private System.Windows.Forms.DataGridView walkIn_dataGridView;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker walkIn_dateOut_dateTimePicker;
    private System.Windows.Forms.Label walkIn_roomNo_label;
    private System.Windows.Forms.Button walkIn_customerInfo_button;
    private System.Windows.Forms.CheckBox walkIn_review_checkBox;
    private System.Windows.Forms.TabPage customers_tab;
    private System.Windows.Forms.CheckBox reservation_review_checkBox;
    private System.Windows.Forms.Button reservation_customerInfo_button;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.DateTimePicker reservation_dateIn_dateTimePicker;
    private System.Windows.Forms.Label reservation_roomNo_label;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Button reservation_reserve_button;
    private System.Windows.Forms.DataGridView reservation_dataGridView;
    private System.Windows.Forms.DataGridView customers_dataGridView;
    private System.Windows.Forms.Label customer_dateOut_label;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Label customer_dateIn_label;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label customer_name_label;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label customer_roomNo_label;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label customer_isReserved_label;
    private System.Windows.Forms.Label label15;
  }
}