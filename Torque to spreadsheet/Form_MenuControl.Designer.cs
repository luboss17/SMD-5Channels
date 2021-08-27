namespace WindowsFormsApplication1
{
    partial class Form_MenuControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MenuControl));
            this.signLock_comboBox = new System.Windows.Forms.ComboBox();
            this.peakBlanking_comboBox = new System.Windows.Forms.ComboBox();
            this.Filter_comboBox = new System.Windows.Forms.ComboBox();
            this.signLock_ori_label = new System.Windows.Forms.Label();
            this.peak_ori_label = new System.Windows.Forms.Label();
            this.freq_ori_label = new System.Windows.Forms.Label();
            this.AC_ori_label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cancel_button = new System.Windows.Forms.Button();
            this.submit_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.autoClear_comboBox = new System.Windows.Forms.ComboBox();
            this.clear_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mode_comboBox = new System.Windows.Forms.ComboBox();
            this.unit_comboBox = new System.Windows.Forms.ComboBox();
            this.mode_ori_label = new System.Windows.Forms.Label();
            this.unit_ori_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signLock_comboBox
            // 
            this.signLock_comboBox.FormattingEnabled = true;
            this.signLock_comboBox.Items.AddRange(new object[] {
            "Off",
            "On"});
            this.signLock_comboBox.Location = new System.Drawing.Point(126, 174);
            this.signLock_comboBox.Name = "signLock_comboBox";
            this.signLock_comboBox.Size = new System.Drawing.Size(115, 21);
            this.signLock_comboBox.TabIndex = 29;
            // 
            // peakBlanking_comboBox
            // 
            this.peakBlanking_comboBox.FormattingEnabled = true;
            this.peakBlanking_comboBox.Location = new System.Drawing.Point(126, 137);
            this.peakBlanking_comboBox.Name = "peakBlanking_comboBox";
            this.peakBlanking_comboBox.Size = new System.Drawing.Size(115, 21);
            this.peakBlanking_comboBox.TabIndex = 28;
            // 
            // Filter_comboBox
            // 
            this.Filter_comboBox.FormattingEnabled = true;
            this.Filter_comboBox.Items.AddRange(new object[] {
            "125 Hz",
            "250 Hz",
            "500 Hz",
            "750 Hz",
            "1500 Hz"});
            this.Filter_comboBox.Location = new System.Drawing.Point(126, 98);
            this.Filter_comboBox.Name = "Filter_comboBox";
            this.Filter_comboBox.Size = new System.Drawing.Size(115, 21);
            this.Filter_comboBox.TabIndex = 27;
            this.Filter_comboBox.SelectedIndexChanged += new System.EventHandler(this.Filter_comboBox_SelectedIndexChanged);
            // 
            // signLock_ori_label
            // 
            this.signLock_ori_label.AutoSize = true;
            this.signLock_ori_label.Location = new System.Drawing.Point(283, 182);
            this.signLock_ori_label.Name = "signLock_ori_label";
            this.signLock_ori_label.Size = new System.Drawing.Size(35, 13);
            this.signLock_ori_label.TabIndex = 26;
            this.signLock_ori_label.Text = "label9";
            // 
            // peak_ori_label
            // 
            this.peak_ori_label.AutoSize = true;
            this.peak_ori_label.Location = new System.Drawing.Point(283, 145);
            this.peak_ori_label.Name = "peak_ori_label";
            this.peak_ori_label.Size = new System.Drawing.Size(35, 13);
            this.peak_ori_label.TabIndex = 25;
            this.peak_ori_label.Text = "label8";
            // 
            // freq_ori_label
            // 
            this.freq_ori_label.AutoSize = true;
            this.freq_ori_label.Location = new System.Drawing.Point(283, 106);
            this.freq_ori_label.Name = "freq_ori_label";
            this.freq_ori_label.Size = new System.Drawing.Size(35, 13);
            this.freq_ori_label.TabIndex = 24;
            this.freq_ori_label.Text = "label7";
            // 
            // AC_ori_label
            // 
            this.AC_ori_label.AutoSize = true;
            this.AC_ori_label.Location = new System.Drawing.Point(283, 64);
            this.AC_ori_label.Name = "AC_ori_label";
            this.AC_ori_label.Size = new System.Drawing.Size(35, 13);
            this.AC_ori_label.TabIndex = 23;
            this.AC_ori_label.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(283, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Current Setting";
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(286, 293);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 21;
            this.cancel_button.Text = "Close";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // submit_button
            // 
            this.submit_button.Location = new System.Drawing.Point(37, 293);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(75, 23);
            this.submit_button.TabIndex = 20;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Sign Lock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Peak Planking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Filter";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Auto Clear";
            // 
            // autoClear_comboBox
            // 
            this.autoClear_comboBox.FormattingEnabled = true;
            this.autoClear_comboBox.Items.AddRange(new object[] {
            "Off",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.autoClear_comboBox.Location = new System.Drawing.Point(126, 56);
            this.autoClear_comboBox.Name = "autoClear_comboBox";
            this.autoClear_comboBox.Size = new System.Drawing.Size(115, 21);
            this.autoClear_comboBox.TabIndex = 30;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(166, 293);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(75, 23);
            this.clear_button.TabIndex = 31;
            this.clear_button.Text = "Clear";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Mode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Unit";
            // 
            // mode_comboBox
            // 
            this.mode_comboBox.FormattingEnabled = true;
            this.mode_comboBox.Items.AddRange(new object[] {
            "Track",
            "Peak",
            "First Peak"});
            this.mode_comboBox.Location = new System.Drawing.Point(126, 219);
            this.mode_comboBox.Name = "mode_comboBox";
            this.mode_comboBox.Size = new System.Drawing.Size(115, 21);
            this.mode_comboBox.TabIndex = 34;
            // 
            // unit_comboBox
            // 
            this.unit_comboBox.FormattingEnabled = true;
            this.unit_comboBox.Location = new System.Drawing.Point(126, 256);
            this.unit_comboBox.Name = "unit_comboBox";
            this.unit_comboBox.Size = new System.Drawing.Size(115, 21);
            this.unit_comboBox.TabIndex = 35;
            // 
            // mode_ori_label
            // 
            this.mode_ori_label.AutoSize = true;
            this.mode_ori_label.Location = new System.Drawing.Point(283, 227);
            this.mode_ori_label.Name = "mode_ori_label";
            this.mode_ori_label.Size = new System.Drawing.Size(35, 13);
            this.mode_ori_label.TabIndex = 36;
            this.mode_ori_label.Text = "label8";
            // 
            // unit_ori_label
            // 
            this.unit_ori_label.AutoSize = true;
            this.unit_ori_label.Location = new System.Drawing.Point(283, 264);
            this.unit_ori_label.Name = "unit_ori_label";
            this.unit_ori_label.Size = new System.Drawing.Size(35, 13);
            this.unit_ori_label.TabIndex = 37;
            this.unit_ori_label.Text = "label9";
            // 
            // Form_MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 354);
            this.Controls.Add(this.unit_ori_label);
            this.Controls.Add(this.mode_ori_label);
            this.Controls.Add(this.unit_comboBox);
            this.Controls.Add(this.mode_comboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.autoClear_comboBox);
            this.Controls.Add(this.signLock_comboBox);
            this.Controls.Add(this.peakBlanking_comboBox);
            this.Controls.Add(this.Filter_comboBox);
            this.Controls.Add(this.signLock_ori_label);
            this.Controls.Add(this.peak_ori_label);
            this.Controls.Add(this.freq_ori_label);
            this.Controls.Add(this.AC_ori_label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MenuControl";
            this.Text = "Tester Setting";
            this.Load += new System.EventHandler(this.Form_MenuControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox signLock_comboBox;
        private System.Windows.Forms.ComboBox peakBlanking_comboBox;
        private System.Windows.Forms.ComboBox Filter_comboBox;
        private System.Windows.Forms.Label signLock_ori_label;
        private System.Windows.Forms.Label peak_ori_label;
        private System.Windows.Forms.Label freq_ori_label;
        private System.Windows.Forms.Label AC_ori_label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox autoClear_comboBox;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox mode_comboBox;
        private System.Windows.Forms.ComboBox unit_comboBox;
        private System.Windows.Forms.Label mode_ori_label;
        private System.Windows.Forms.Label unit_ori_label;
    }
}