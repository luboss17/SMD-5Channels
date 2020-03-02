namespace WindowsFormsApplication1
{
    partial class Form_PointSaveCount
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
            this.saveClose_btn = new System.Windows.Forms.Button();
            this.pointCount_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveALL_radioBtn = new System.Windows.Forms.RadioButton();
            this.savePoint_radioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveClose_btn
            // 
            this.saveClose_btn.Location = new System.Drawing.Point(79, 93);
            this.saveClose_btn.Name = "saveClose_btn";
            this.saveClose_btn.Size = new System.Drawing.Size(124, 23);
            this.saveClose_btn.TabIndex = 0;
            this.saveClose_btn.Text = "Save && Close";
            this.saveClose_btn.UseVisualStyleBackColor = true;
            this.saveClose_btn.Click += new System.EventHandler(this.saveCloseBtn_Click);
            // 
            // pointCount_txt
            // 
            this.pointCount_txt.Location = new System.Drawing.Point(198, 58);
            this.pointCount_txt.Name = "pointCount_txt";
            this.pointCount_txt.Size = new System.Drawing.Size(75, 20);
            this.pointCount_txt.TabIndex = 1;
            this.pointCount_txt.TextChanged += new System.EventHandler(this.pointCount_txt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "How many points will be saved?";
            // 
            // saveALL_radioBtn
            // 
            this.saveALL_radioBtn.AutoSize = true;
            this.saveALL_radioBtn.Checked = true;
            this.saveALL_radioBtn.Location = new System.Drawing.Point(14, 61);
            this.saveALL_radioBtn.Name = "saveALL_radioBtn";
            this.saveALL_radioBtn.Size = new System.Drawing.Size(64, 17);
            this.saveALL_radioBtn.TabIndex = 3;
            this.saveALL_radioBtn.TabStop = true;
            this.saveALL_radioBtn.Text = "Save All";
            this.saveALL_radioBtn.UseVisualStyleBackColor = true;
            this.saveALL_radioBtn.CheckedChanged += new System.EventHandler(this.saveALL_radioBtn_CheckedChanged);
            // 
            // savePoint_radioBtn
            // 
            this.savePoint_radioBtn.AutoSize = true;
            this.savePoint_radioBtn.Location = new System.Drawing.Point(112, 61);
            this.savePoint_radioBtn.Name = "savePoint_radioBtn";
            this.savePoint_radioBtn.Size = new System.Drawing.Size(80, 17);
            this.savePoint_radioBtn.TabIndex = 4;
            this.savePoint_radioBtn.Text = "Save Only: ";
            this.savePoint_radioBtn.UseVisualStyleBackColor = true;
            this.savePoint_radioBtn.CheckedChanged += new System.EventHandler(this.savePoint_radioBtn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.savePoint_radioBtn);
            this.groupBox1.Controls.Add(this.saveClose_btn);
            this.groupBox1.Controls.Add(this.saveALL_radioBtn);
            this.groupBox1.Controls.Add(this.pointCount_txt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Form_PointSaveCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 162);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_PointSaveCount";
            this.Text = "Form_PointSaveCount";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveClose_btn;
        private System.Windows.Forms.TextBox pointCount_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton saveALL_radioBtn;
        private System.Windows.Forms.RadioButton savePoint_radioBtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}