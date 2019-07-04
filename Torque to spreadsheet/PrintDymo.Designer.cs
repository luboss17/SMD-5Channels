namespace WindowsFormsApplication1
{
    partial class PrintDymo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintDymo));
            this.StrToPrint_txtBox = new System.Windows.Forms.TextBox();
            this.print_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.refreshPrinter_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StrToPrint_txtBox
            // 
            this.StrToPrint_txtBox.Location = new System.Drawing.Point(0, 42);
            this.StrToPrint_txtBox.Multiline = true;
            this.StrToPrint_txtBox.Name = "StrToPrint_txtBox";
            this.StrToPrint_txtBox.Size = new System.Drawing.Size(284, 84);
            this.StrToPrint_txtBox.TabIndex = 4;
            // 
            // print_btn
            // 
            this.print_btn.Location = new System.Drawing.Point(12, 162);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(75, 23);
            this.print_btn.TabIndex = 5;
            this.print_btn.Text = "Print";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(209, 162);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // refreshPrinter_btn
            // 
            this.refreshPrinter_btn.Location = new System.Drawing.Point(113, 162);
            this.refreshPrinter_btn.Name = "refreshPrinter_btn";
            this.refreshPrinter_btn.Size = new System.Drawing.Size(75, 23);
            this.refreshPrinter_btn.TabIndex = 7;
            this.refreshPrinter_btn.Text = "Refresh";
            this.refreshPrinter_btn.UseVisualStyleBackColor = true;
            this.refreshPrinter_btn.Click += new System.EventHandler(this.refreshPrinter_btn_Click);
            // 
            // PrintDymo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 263);
            this.Controls.Add(this.refreshPrinter_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.StrToPrint_txtBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintDymo";
            this.Text = "Print Label";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StrToPrint_txtBox;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button refreshPrinter_btn;
    }
}