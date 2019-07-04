using System;
using System.Windows.Forms;
namespace WindowsFormsApplication1

{
    partial class PrintLabel2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /*
            this.SuspendLayout();
            // 
            // PrintLabel2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "PrintLabel2";
            this.Text = "PrintLabel2";
            this.ResumeLayout(false);
            */

        

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        /// <summary>
        /// Required designer variable.
        /// </summary>

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox FileNameEdit;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.ComboBox ObjectNameCmb;
        private System.Windows.Forms.TextBox ObjectDataEdit;
        private System.Windows.Forms.ComboBox LabelWriterCmb;
        private System.Windows.Forms.ComboBox TrayCmb;
        private System.Windows.Forms.Button PrintLabelBtn;
        private System.Windows.Forms.Button CloseBtn;
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameEdit = new System.Windows.Forms.TextBox();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CloseBtn = new System.Windows.Forms.Button();
            this.PrintLabelBtn = new System.Windows.Forms.Button();
            this.ObjectDataEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ObjectNameCmb = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TrayCmb = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LabelWriterCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(178, 480);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select a label file here: (click Browse... to browse to the file)";
            this.label1.Visible = false;
            // 
            // FileNameEdit
            // 
            this.FileNameEdit.Location = new System.Drawing.Point(178, 500);
            this.FileNameEdit.Name = "FileNameEdit";
            this.FileNameEdit.ReadOnly = true;
            this.FileNameEdit.Size = new System.Drawing.Size(424, 20);
            this.FileNameEdit.TabIndex = 1;
            this.FileNameEdit.Visible = false;
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(610, 500);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 2;
            this.BrowseBtn.Text = "Browse...";
            this.BrowseBtn.Visible = false;
            this.BrowseBtn.Click += new System.EventHandler(this.Browse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CloseBtn);
            this.groupBox1.Controls.Add(this.PrintLabelBtn);
            this.groupBox1.Controls.Add(this.ObjectDataEdit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 179);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label";
            // 
            // CloseBtn
            // 
            this.CloseBtn.Location = new System.Drawing.Point(211, 136);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(84, 23);
            this.CloseBtn.TabIndex = 5;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // PrintLabelBtn
            // 
            this.PrintLabelBtn.Location = new System.Drawing.Point(8, 136);
            this.PrintLabelBtn.Name = "PrintLabelBtn";
            this.PrintLabelBtn.Size = new System.Drawing.Size(84, 23);
            this.PrintLabelBtn.TabIndex = 4;
            this.PrintLabelBtn.Text = "Print Label";
            this.PrintLabelBtn.Click += new System.EventHandler(this.PrintLabelBtn_Click);
            // 
            // ObjectDataEdit
            // 
            this.ObjectDataEdit.Location = new System.Drawing.Point(8, 34);
            this.ObjectDataEdit.Multiline = true;
            this.ObjectDataEdit.Name = "ObjectDataEdit";
            this.ObjectDataEdit.Size = new System.Drawing.Size(284, 84);
            this.ObjectDataEdit.TabIndex = 3;
            this.ObjectDataEdit.Leave += new System.EventHandler(this.ObjectDataEdit_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tool Infos:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(228, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select a label object here:";
            this.label2.Visible = false;
            // 
            // ObjectNameCmb
            // 
            this.ObjectNameCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectNameCmb.Location = new System.Drawing.Point(228, 459);
            this.ObjectNameCmb.Name = "ObjectNameCmb";
            this.ObjectNameCmb.Size = new System.Drawing.Size(172, 21);
            this.ObjectNameCmb.TabIndex = 0;
            this.ObjectNameCmb.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TrayCmb);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(20, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 132);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LabelWriter Selection";
            this.groupBox2.Visible = false;
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
            this.LabelWriterCmb.Location = new System.Drawing.Point(20, 39);
            this.LabelWriterCmb.Name = "LabelWriterCmb";
            this.LabelWriterCmb.Size = new System.Drawing.Size(280, 21);
            this.LabelWriterCmb.TabIndex = 1;
            this.LabelWriterCmb.SelectedIndexChanged += new System.EventHandler(this.LabelWriterCmb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(28, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select a LabelWriter here:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "lwl";
            this.openFileDialog1.Filter = "DYMO Label File (*.lwl)|*.lwl";
            this.openFileDialog1.Title = "Open DYMO Label File";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PrintLabel2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(839, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ObjectNameCmb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.LabelWriterCmb);
            this.Controls.Add(this.FileNameEdit);
            this.Controls.Add(this.label1);
            this.Name = "PrintLabel2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DYMO Printer";
            this.Closed += new System.EventHandler(this.PrintLabel2_Close);
            this.Load += new System.EventHandler(this.PrintLabel2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }
        #endregion

        private ContextMenuStrip contextMenuStrip1;
    }
}