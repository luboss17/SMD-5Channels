namespace WindowsFormsApplication1
{
    partial class StreamingForm
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
            this.targetGrid = new System.Windows.Forms.DataGridView();
            this.saveResult_btn = new System.Windows.Forms.Button();
            this.to9600baudrate_btn = new System.Windows.Forms.Button();
            this.to25kbaud_btn = new System.Windows.Forms.Button();
            this.stropStream_btn = new System.Windows.Forms.Button();
            this.startDualStream_btn = new System.Windows.Forms.Button();
            this.doneStream_btn = new System.Windows.Forms.Button();
            this.startSingleStream_btn = new System.Windows.Forms.Button();
            this.streamGridCh1 = new System.Windows.Forms.DataGridView();
            this.close_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.retakeStreaming_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dualStream_btn = new System.Windows.Forms.Button();
            this.streamRate_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.streamGridCh2 = new System.Windows.Forms.DataGridView();
            this.frequency_comboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.targetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamGridCh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamGridCh2)).BeginInit();
            this.SuspendLayout();
            // 
            // targetGrid
            // 
            this.targetGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.targetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.targetGrid.Location = new System.Drawing.Point(28, 1246);
            this.targetGrid.Margin = new System.Windows.Forms.Padding(6);
            this.targetGrid.Name = "targetGrid";
            this.targetGrid.RowHeadersWidth = 82;
            this.targetGrid.Size = new System.Drawing.Size(946, 529);
            this.targetGrid.TabIndex = 144;
            // 
            // saveResult_btn
            // 
            this.saveResult_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveResult_btn.Location = new System.Drawing.Point(1286, 1487);
            this.saveResult_btn.Margin = new System.Windows.Forms.Padding(6);
            this.saveResult_btn.Name = "saveResult_btn";
            this.saveResult_btn.Size = new System.Drawing.Size(720, 138);
            this.saveResult_btn.TabIndex = 143;
            this.saveResult_btn.Text = "Save";
            this.saveResult_btn.UseVisualStyleBackColor = true;
            this.saveResult_btn.Click += new System.EventHandler(this.saveResult_btn_Click);
            // 
            // to9600baudrate_btn
            // 
            this.to9600baudrate_btn.Location = new System.Drawing.Point(986, 1404);
            this.to9600baudrate_btn.Margin = new System.Windows.Forms.Padding(6);
            this.to9600baudrate_btn.Name = "to9600baudrate_btn";
            this.to9600baudrate_btn.Size = new System.Drawing.Size(246, 44);
            this.to9600baudrate_btn.TabIndex = 142;
            this.to9600baudrate_btn.Text = "9600 Baud";
            this.to9600baudrate_btn.UseVisualStyleBackColor = true;
            this.to9600baudrate_btn.Click += new System.EventHandler(this.to9600baudrate_btn_Click);
            // 
            // to25kbaud_btn
            // 
            this.to25kbaud_btn.Location = new System.Drawing.Point(986, 1348);
            this.to25kbaud_btn.Margin = new System.Windows.Forms.Padding(6);
            this.to25kbaud_btn.Name = "to25kbaud_btn";
            this.to25kbaud_btn.Size = new System.Drawing.Size(246, 44);
            this.to25kbaud_btn.TabIndex = 141;
            this.to25kbaud_btn.Text = "25000 Baud";
            this.to25kbaud_btn.UseVisualStyleBackColor = true;
            this.to25kbaud_btn.Click += new System.EventHandler(this.to25kbaud_btn_Click);
            // 
            // stropStream_btn
            // 
            this.stropStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stropStream_btn.Location = new System.Drawing.Point(2018, 1177);
            this.stropStream_btn.Margin = new System.Windows.Forms.Padding(6);
            this.stropStream_btn.Name = "stropStream_btn";
            this.stropStream_btn.Size = new System.Drawing.Size(720, 138);
            this.stropStream_btn.TabIndex = 140;
            this.stropStream_btn.Text = "Stop Stream";
            this.stropStream_btn.UseVisualStyleBackColor = true;
            this.stropStream_btn.Click += new System.EventHandler(this.stropStream_btn_Click);
            // 
            // startDualStream_btn
            // 
            this.startDualStream_btn.Location = new System.Drawing.Point(2182, 1696);
            this.startDualStream_btn.Margin = new System.Windows.Forms.Padding(6);
            this.startDualStream_btn.Name = "startDualStream_btn";
            this.startDualStream_btn.Size = new System.Drawing.Size(282, 98);
            this.startDualStream_btn.TabIndex = 139;
            this.startDualStream_btn.Text = "Dual Stream";
            this.startDualStream_btn.UseVisualStyleBackColor = true;
            this.startDualStream_btn.Visible = false;
            this.startDualStream_btn.Click += new System.EventHandler(this.startDualStream_btn_Click);
            // 
            // doneStream_btn
            // 
            this.doneStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneStream_btn.Location = new System.Drawing.Point(2182, 1631);
            this.doneStream_btn.Margin = new System.Windows.Forms.Padding(6);
            this.doneStream_btn.Name = "doneStream_btn";
            this.doneStream_btn.Size = new System.Drawing.Size(272, 60);
            this.doneStream_btn.TabIndex = 138;
            this.doneStream_btn.Text = "Done Stream";
            this.doneStream_btn.UseVisualStyleBackColor = true;
            this.doneStream_btn.Visible = false;
            this.doneStream_btn.Click += new System.EventHandler(this.doneStream_btn_Click);
            // 
            // startSingleStream_btn
            // 
            this.startSingleStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.startSingleStream_btn.Location = new System.Drawing.Point(1286, 1337);
            this.startSingleStream_btn.Margin = new System.Windows.Forms.Padding(6);
            this.startSingleStream_btn.Name = "startSingleStream_btn";
            this.startSingleStream_btn.Size = new System.Drawing.Size(720, 138);
            this.startSingleStream_btn.TabIndex = 137;
            this.startSingleStream_btn.Text = "Single Stream-Peak";
            this.startSingleStream_btn.UseVisualStyleBackColor = true;
            this.startSingleStream_btn.Click += new System.EventHandler(this.startSingleStream_btn_Click);
            // 
            // streamGridCh1
            // 
            this.streamGridCh1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.streamGridCh1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.streamGridCh1.Location = new System.Drawing.Point(24, 77);
            this.streamGridCh1.Margin = new System.Windows.Forms.Padding(6);
            this.streamGridCh1.Name = "streamGridCh1";
            this.streamGridCh1.RowHeadersWidth = 82;
            this.streamGridCh1.Size = new System.Drawing.Size(490, 1067);
            this.streamGridCh1.TabIndex = 136;
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.Location = new System.Drawing.Point(1286, 1637);
            this.close_btn.Margin = new System.Windows.Forms.Padding(6);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(720, 138);
            this.close_btn.TabIndex = 145;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(302, 1181);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 63);
            this.label1.TabIndex = 146;
            this.label1.Text = "Points to Save";
            // 
            // retakeStreaming_btn
            // 
            this.retakeStreaming_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retakeStreaming_btn.Location = new System.Drawing.Point(2018, 1487);
            this.retakeStreaming_btn.Margin = new System.Windows.Forms.Padding(6);
            this.retakeStreaming_btn.Name = "retakeStreaming_btn";
            this.retakeStreaming_btn.Size = new System.Drawing.Size(720, 138);
            this.retakeStreaming_btn.TabIndex = 147;
            this.retakeStreaming_btn.Text = "Retake";
            this.retakeStreaming_btn.UseVisualStyleBackColor = true;
            this.retakeStreaming_btn.Visible = false;
            this.retakeStreaming_btn.Click += new System.EventHandler(this.retakeStreaming_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(340, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 63);
            this.label2.TabIndex = 148;
            this.label2.Text = "Stream Data";
            // 
            // dualStream_btn
            // 
            this.dualStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dualStream_btn.Location = new System.Drawing.Point(1286, 1177);
            this.dualStream_btn.Margin = new System.Windows.Forms.Padding(6);
            this.dualStream_btn.Name = "dualStream_btn";
            this.dualStream_btn.Size = new System.Drawing.Size(720, 138);
            this.dualStream_btn.TabIndex = 149;
            this.dualStream_btn.Text = "Stream-Track";
            this.dualStream_btn.UseVisualStyleBackColor = true;
            this.dualStream_btn.Click += new System.EventHandler(this.DualStream_btn_Click);
            // 
            // streamRate_txt
            // 
            this.streamRate_txt.Location = new System.Drawing.Point(986, 1577);
            this.streamRate_txt.Margin = new System.Windows.Forms.Padding(6);
            this.streamRate_txt.Name = "streamRate_txt";
            this.streamRate_txt.Size = new System.Drawing.Size(196, 31);
            this.streamRate_txt.TabIndex = 150;
            this.streamRate_txt.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1004, 1246);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 25);
            this.label3.TabIndex = 151;
            this.label3.Text = "Stream Rate";
            // 
            // streamGridCh2
            // 
            this.streamGridCh2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.streamGridCh2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.streamGridCh2.Location = new System.Drawing.Point(526, 77);
            this.streamGridCh2.Margin = new System.Windows.Forms.Padding(6);
            this.streamGridCh2.Name = "streamGridCh2";
            this.streamGridCh2.RowHeadersWidth = 82;
            this.streamGridCh2.Size = new System.Drawing.Size(490, 1067);
            this.streamGridCh2.TabIndex = 152;
            // 
            // frequency_comboBox
            // 
            this.frequency_comboBox.FormattingEnabled = true;
            this.frequency_comboBox.Location = new System.Drawing.Point(986, 1282);
            this.frequency_comboBox.Name = "frequency_comboBox";
            this.frequency_comboBox.Size = new System.Drawing.Size(246, 33);
            this.frequency_comboBox.TabIndex = 153;
            // 
            // StreamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2740, 1760);
            this.Controls.Add(this.frequency_comboBox);
            this.Controls.Add(this.streamGridCh2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.streamRate_txt);
            this.Controls.Add(this.dualStream_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.retakeStreaming_btn);
            this.Controls.Add(this.stropStream_btn);
            this.Controls.Add(this.startDualStream_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.targetGrid);
            this.Controls.Add(this.saveResult_btn);
            this.Controls.Add(this.to9600baudrate_btn);
            this.Controls.Add(this.to25kbaud_btn);
            this.Controls.Add(this.doneStream_btn);
            this.Controls.Add(this.startSingleStream_btn);
            this.Controls.Add(this.streamGridCh1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "StreamingForm";
            this.Text = "StreamingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.targetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamGridCh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamGridCh2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.DataGridView targetGrid;
        private System.Windows.Forms.Button saveResult_btn;
        private System.Windows.Forms.Button to9600baudrate_btn;
        private System.Windows.Forms.Button to25kbaud_btn;
        private System.Windows.Forms.Button stropStream_btn;
        private System.Windows.Forms.Button startDualStream_btn;
        private System.Windows.Forms.Button doneStream_btn;
        private System.Windows.Forms.Button startSingleStream_btn;
        private System.Windows.Forms.DataGridView streamGridCh1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button retakeStreaming_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dualStream_btn;
        private System.Windows.Forms.TextBox streamRate_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView streamGridCh2;
        private System.Windows.Forms.ComboBox frequency_comboBox;
    }
}