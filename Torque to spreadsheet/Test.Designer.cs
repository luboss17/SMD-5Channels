namespace WindowsFormsApplication1
{
    partial class Test
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
            this.CloseBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrintLabelBtn = new System.Windows.Forms.Button();
            this.TrayCmb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelWriterCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ObjectDataEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ObjectNameCmb = new System.Windows.Forms.ComboBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.FileNameEdit = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(448, 369);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 11;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PrintLabelBtn);
            this.groupBox2.Controls.Add(this.TrayCmb);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.LabelWriterCmb);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(16, 229);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 132);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LabelWriter Selection";
            // 
            // PrintLabelBtn
            // 
            this.PrintLabelBtn.Location = new System.Drawing.Point(8, 96);
            this.PrintLabelBtn.Name = "PrintLabelBtn";
            this.PrintLabelBtn.Size = new System.Drawing.Size(84, 23);
            this.PrintLabelBtn.TabIndex = 4;
            this.PrintLabelBtn.Text = "Print Label";
            this.PrintLabelBtn.Click += new System.EventHandler(this.PrintLabelBtn_Click);
            // 
            // TrayCmb
            // 
            this.TrayCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrayCmb.Items.AddRange(new object[] {
            "Left Tray",
            "Right Tray",
            "Auto Switch"});
            this.TrayCmb.Location = new System.Drawing.Point(312, 64);
            this.TrayCmb.Name = "TrayCmb";
            this.TrayCmb.Size = new System.Drawing.Size(128, 21);
            this.TrayCmb.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(308, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Set tray selection (available only with LabelWriter TWIN TURBO)";
            // 
            // LabelWriterCmb
            // 
            this.LabelWriterCmb.Location = new System.Drawing.Point(8, 64);
            this.LabelWriterCmb.Name = "LabelWriterCmb";
            this.LabelWriterCmb.Size = new System.Drawing.Size(280, 21);
            this.LabelWriterCmb.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select a LabelWriter here:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ObjectDataEdit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ObjectNameCmb);
            this.groupBox1.Location = new System.Drawing.Point(16, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 148);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Object";
            // 
            // ObjectDataEdit
            // 
            this.ObjectDataEdit.Location = new System.Drawing.Point(204, 48);
            this.ObjectDataEdit.Multiline = true;
            this.ObjectDataEdit.Name = "ObjectDataEdit";
            this.ObjectDataEdit.Size = new System.Drawing.Size(284, 84);
            this.ObjectDataEdit.TabIndex = 3;
            this.ObjectDataEdit.Leave += new System.EventHandler(this.ObjectDataEdit_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(208, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tool Infos:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select a label object here:";
            // 
            // ObjectNameCmb
            // 
            this.ObjectNameCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectNameCmb.Location = new System.Drawing.Point(16, 48);
            this.ObjectNameCmb.Name = "ObjectNameCmb";
            this.ObjectNameCmb.Size = new System.Drawing.Size(172, 21);
            this.ObjectNameCmb.TabIndex = 0;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(444, 29);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 8;
            this.BrowseBtn.Text = "Browse...";
            // 
            // FileNameEdit
            // 
            this.FileNameEdit.Location = new System.Drawing.Point(12, 29);
            this.FileNameEdit.Name = "FileNameEdit";
            this.FileNameEdit.ReadOnly = true;
            this.FileNameEdit.Size = new System.Drawing.Size(424, 20);
            this.FileNameEdit.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select a label file here: (click Browse... to browse to the file)";
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 408);
            this.Controls.Add(this.CloseBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.FileNameEdit);
            this.Controls.Add(this.label1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button PrintLabelBtn;
        private System.Windows.Forms.ComboBox TrayCmb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LabelWriterCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ObjectDataEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ObjectNameCmb;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox FileNameEdit;
        private System.Windows.Forms.Label label1;
    }
}