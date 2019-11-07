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
            this.startStream_btn = new System.Windows.Forms.Button();
            this.streamGrid = new System.Windows.Forms.DataGridView();
            this.close_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.retakeStreaming_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.targetGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // targetGrid
            // 
            this.targetGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.targetGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.targetGrid.Location = new System.Drawing.Point(14, 648);
            this.targetGrid.Name = "targetGrid";
            this.targetGrid.Size = new System.Drawing.Size(473, 275);
            this.targetGrid.TabIndex = 144;
            // 
            // saveResult_btn
            // 
            this.saveResult_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveResult_btn.Location = new System.Drawing.Point(643, 773);
            this.saveResult_btn.Name = "saveResult_btn";
            this.saveResult_btn.Size = new System.Drawing.Size(360, 72);
            this.saveResult_btn.TabIndex = 143;
            this.saveResult_btn.Text = "Save Trait+Point";
            this.saveResult_btn.UseVisualStyleBackColor = true;
            this.saveResult_btn.Click += new System.EventHandler(this.saveResult_btn_Click);
            // 
            // to9600baudrate_btn
            // 
            this.to9600baudrate_btn.Location = new System.Drawing.Point(1091, 974);
            this.to9600baudrate_btn.Name = "to9600baudrate_btn";
            this.to9600baudrate_btn.Size = new System.Drawing.Size(123, 23);
            this.to9600baudrate_btn.TabIndex = 142;
            this.to9600baudrate_btn.Text = "9600 Baud";
            this.to9600baudrate_btn.UseVisualStyleBackColor = true;
            this.to9600baudrate_btn.Visible = false;
            this.to9600baudrate_btn.Click += new System.EventHandler(this.to9600baudrate_btn_Click);
            // 
            // to25kbaud_btn
            // 
            this.to25kbaud_btn.Location = new System.Drawing.Point(1089, 945);
            this.to25kbaud_btn.Name = "to25kbaud_btn";
            this.to25kbaud_btn.Size = new System.Drawing.Size(123, 23);
            this.to25kbaud_btn.TabIndex = 141;
            this.to25kbaud_btn.Text = "25000 Baud";
            this.to25kbaud_btn.UseVisualStyleBackColor = true;
            this.to25kbaud_btn.Visible = false;
            this.to25kbaud_btn.Click += new System.EventHandler(this.to25kbaud_btn_Click);
            // 
            // stropStream_btn
            // 
            this.stropStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stropStream_btn.Location = new System.Drawing.Point(643, 695);
            this.stropStream_btn.Name = "stropStream_btn";
            this.stropStream_btn.Size = new System.Drawing.Size(360, 72);
            this.stropStream_btn.TabIndex = 140;
            this.stropStream_btn.Text = "Stop Stream";
            this.stropStream_btn.UseVisualStyleBackColor = true;
            this.stropStream_btn.Click += new System.EventHandler(this.stropStream_btn_Click);
            // 
            // startDualStream_btn
            // 
            this.startDualStream_btn.Location = new System.Drawing.Point(1091, 882);
            this.startDualStream_btn.Name = "startDualStream_btn";
            this.startDualStream_btn.Size = new System.Drawing.Size(141, 51);
            this.startDualStream_btn.TabIndex = 139;
            this.startDualStream_btn.Text = "Dual Stream";
            this.startDualStream_btn.UseVisualStyleBackColor = true;
            this.startDualStream_btn.Visible = false;
            this.startDualStream_btn.Click += new System.EventHandler(this.startDualStream_btn_Click);
            // 
            // doneStream_btn
            // 
            this.doneStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneStream_btn.Location = new System.Drawing.Point(1091, 848);
            this.doneStream_btn.Name = "doneStream_btn";
            this.doneStream_btn.Size = new System.Drawing.Size(136, 31);
            this.doneStream_btn.TabIndex = 138;
            this.doneStream_btn.Text = "Done Stream";
            this.doneStream_btn.UseVisualStyleBackColor = true;
            this.doneStream_btn.Visible = false;
            this.doneStream_btn.Click += new System.EventHandler(this.doneStream_btn_Click);
            // 
            // startStream_btn
            // 
            this.startStream_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStream_btn.Location = new System.Drawing.Point(1091, 760);
            this.startStream_btn.Name = "startStream_btn";
            this.startStream_btn.Size = new System.Drawing.Size(154, 84);
            this.startStream_btn.TabIndex = 137;
            this.startStream_btn.Text = "Single Stream";
            this.startStream_btn.UseVisualStyleBackColor = true;
            this.startStream_btn.Visible = false;
            this.startStream_btn.Click += new System.EventHandler(this.startStream_btn_Click);
            // 
            // streamGrid
            // 
            this.streamGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.streamGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.streamGrid.Location = new System.Drawing.Point(12, 40);
            this.streamGrid.Name = "streamGrid";
            this.streamGrid.Size = new System.Drawing.Size(473, 555);
            this.streamGrid.TabIndex = 136;
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.Location = new System.Drawing.Point(643, 851);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(360, 72);
            this.close_btn.TabIndex = 145;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 31);
            this.label1.TabIndex = 146;
            this.label1.Text = "Points to Save";
            // 
            // retakeStreaming_btn
            // 
            this.retakeStreaming_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retakeStreaming_btn.Location = new System.Drawing.Point(643, 614);
            this.retakeStreaming_btn.Name = "retakeStreaming_btn";
            this.retakeStreaming_btn.Size = new System.Drawing.Size(360, 72);
            this.retakeStreaming_btn.TabIndex = 147;
            this.retakeStreaming_btn.Text = "Retake";
            this.retakeStreaming_btn.UseVisualStyleBackColor = true;
            this.retakeStreaming_btn.Click += new System.EventHandler(this.retakeStreaming_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(170, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 31);
            this.label2.TabIndex = 148;
            this.label2.Text = "Stream Data";
            // 
            // StreamingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 936);
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
            this.Controls.Add(this.startStream_btn);
            this.Controls.Add(this.streamGrid);
            this.Name = "StreamingForm";
            this.Text = "StreamingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.targetGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.streamGrid)).EndInit();
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
        private System.Windows.Forms.Button startStream_btn;
        private System.Windows.Forms.DataGridView streamGrid;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button retakeStreaming_btn;
        private System.Windows.Forms.Label label2;
    }
}