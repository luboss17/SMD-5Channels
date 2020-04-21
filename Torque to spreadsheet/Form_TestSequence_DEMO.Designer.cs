namespace WindowsFormsApplication1
{
    partial class Form_TestSequence_DEMO
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.manufacture_text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.model_text = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dueDate_text = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.calDate_text = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.asset_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.serial_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.toolName_text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chan1Capacity_Text = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chan2Capacity_Text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clearFields_button = new System.Windows.Forms.Button();
            this.highLimitUnit_comboBox = new System.Windows.Forms.ComboBox();
            this.lowLimitUnit_comboBox = new System.Windows.Forms.ComboBox();
            this.samples_text = new System.Windows.Forms.TextBox();
            this.highLimit_Text = new System.Windows.Forms.TextBox();
            this.lowLimit_Text = new System.Windows.Forms.TextBox();
            this.FS_text = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.FSTarget_label = new System.Windows.Forms.Label();
            this.addPoint_button = new System.Windows.Forms.Button();
            this.customPoint_Text = new System.Windows.Forms.TextBox();
            this.customPoint_label = new System.Windows.Forms.Label();
            this.pointGrid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chan1Frequency_comboxBox = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.chan1Unit_comboBox = new System.Windows.Forms.ComboBox();
            this.chan1Mode_comboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.channel2Settings_groupBox = new System.Windows.Forms.GroupBox();
            this.copyChan1Settings_checkBox = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.chan2Mode_comboBox = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chan2Unit_comboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.saveTest_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.testSequence_List = new System.Windows.Forms.ListBox();
            this.testType_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.testPoints_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.channel2Settings_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.manufacture_text);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.model_text);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dueDate_text);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.calDate_text);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.asset_text);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.serial_text);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.toolName_text);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(1281, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tool Detail";
            // 
            // manufacture_text
            // 
            this.manufacture_text.Location = new System.Drawing.Point(309, 150);
            this.manufacture_text.Name = "manufacture_text";
            this.manufacture_text.Size = new System.Drawing.Size(100, 20);
            this.manufacture_text.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Manufacture";
            // 
            // model_text
            // 
            this.model_text.Location = new System.Drawing.Point(90, 150);
            this.model_text.Name = "model_text";
            this.model_text.Size = new System.Drawing.Size(100, 20);
            this.model_text.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Model #";
            // 
            // dueDate_text
            // 
            this.dueDate_text.Location = new System.Drawing.Point(309, 107);
            this.dueDate_text.Name = "dueDate_text";
            this.dueDate_text.Size = new System.Drawing.Size(100, 20);
            this.dueDate_text.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(223, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Due Date";
            // 
            // calDate_text
            // 
            this.calDate_text.Location = new System.Drawing.Point(90, 107);
            this.calDate_text.Name = "calDate_text";
            this.calDate_text.Size = new System.Drawing.Size(100, 20);
            this.calDate_text.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Cal Date";
            // 
            // asset_text
            // 
            this.asset_text.Location = new System.Drawing.Point(309, 71);
            this.asset_text.Name = "asset_text";
            this.asset_text.Size = new System.Drawing.Size(100, 20);
            this.asset_text.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Asset #";
            // 
            // serial_text
            // 
            this.serial_text.Location = new System.Drawing.Point(90, 71);
            this.serial_text.Name = "serial_text";
            this.serial_text.Size = new System.Drawing.Size(100, 20);
            this.serial_text.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Serial #";
            // 
            // toolName_text
            // 
            this.toolName_text.Location = new System.Drawing.Point(90, 30);
            this.toolName_text.Name = "toolName_text";
            this.toolName_text.Size = new System.Drawing.Size(100, 20);
            this.toolName_text.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tool Name *";
            // 
            // chan1Capacity_Text
            // 
            this.chan1Capacity_Text.Location = new System.Drawing.Point(83, 49);
            this.chan1Capacity_Text.Name = "chan1Capacity_Text";
            this.chan1Capacity_Text.Size = new System.Drawing.Size(100, 20);
            this.chan1Capacity_Text.TabIndex = 21;
            this.chan1Capacity_Text.TextChanged += new System.EventHandler(this.chan1Capacity_Text_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Capacity";
            // 
            // chan2Capacity_Text
            // 
            this.chan2Capacity_Text.Location = new System.Drawing.Point(84, 49);
            this.chan2Capacity_Text.Name = "chan2Capacity_Text";
            this.chan2Capacity_Text.Size = new System.Drawing.Size(100, 20);
            this.chan2Capacity_Text.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Capacity";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.testType_comboBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.testPoints_comboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.clearFields_button);
            this.groupBox2.Controls.Add(this.highLimitUnit_comboBox);
            this.groupBox2.Controls.Add(this.lowLimitUnit_comboBox);
            this.groupBox2.Controls.Add(this.samples_text);
            this.groupBox2.Controls.Add(this.highLimit_Text);
            this.groupBox2.Controls.Add(this.lowLimit_Text);
            this.groupBox2.Controls.Add(this.FS_text);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.FSTarget_label);
            this.groupBox2.Controls.Add(this.addPoint_button);
            this.groupBox2.Controls.Add(this.customPoint_Text);
            this.groupBox2.Controls.Add(this.customPoint_label);
            this.groupBox2.Location = new System.Drawing.Point(503, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 184);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Setup";
            // 
            // clearFields_button
            // 
            this.clearFields_button.Location = new System.Drawing.Point(378, 153);
            this.clearFields_button.Name = "clearFields_button";
            this.clearFields_button.Size = new System.Drawing.Size(98, 23);
            this.clearFields_button.TabIndex = 17;
            this.clearFields_button.Text = "Clear Fields";
            this.clearFields_button.UseVisualStyleBackColor = true;
            this.clearFields_button.Click += new System.EventHandler(this.clearFields_button_Click);
            // 
            // highLimitUnit_comboBox
            // 
            this.highLimitUnit_comboBox.FormattingEnabled = true;
            this.highLimitUnit_comboBox.Location = new System.Drawing.Point(502, 122);
            this.highLimitUnit_comboBox.Name = "highLimitUnit_comboBox";
            this.highLimitUnit_comboBox.Size = new System.Drawing.Size(92, 21);
            this.highLimitUnit_comboBox.TabIndex = 14;
            this.highLimitUnit_comboBox.SelectedIndexChanged += new System.EventHandler(this.highLimitUnit_comboBox_SelectedIndexChanged);
            // 
            // lowLimitUnit_comboBox
            // 
            this.lowLimitUnit_comboBox.FormattingEnabled = true;
            this.lowLimitUnit_comboBox.Location = new System.Drawing.Point(502, 92);
            this.lowLimitUnit_comboBox.Name = "lowLimitUnit_comboBox";
            this.lowLimitUnit_comboBox.Size = new System.Drawing.Size(92, 21);
            this.lowLimitUnit_comboBox.TabIndex = 13;
            this.lowLimitUnit_comboBox.SelectedIndexChanged += new System.EventHandler(this.lowLimitUnit_comboBox_SelectedIndexChanged);
            // 
            // samples_text
            // 
            this.samples_text.Location = new System.Drawing.Point(123, 127);
            this.samples_text.Name = "samples_text";
            this.samples_text.Size = new System.Drawing.Size(100, 20);
            this.samples_text.TabIndex = 12;
            this.samples_text.Text = "1";
            this.samples_text.TextChanged += new System.EventHandler(this.samples_text_TextChanged);
            // 
            // highLimit_Text
            // 
            this.highLimit_Text.Location = new System.Drawing.Point(384, 122);
            this.highLimit_Text.Name = "highLimit_Text";
            this.highLimit_Text.Size = new System.Drawing.Size(100, 20);
            this.highLimit_Text.TabIndex = 11;
            this.highLimit_Text.TextChanged += new System.EventHandler(this.highLimit_Text_TextChanged);
            // 
            // lowLimit_Text
            // 
            this.lowLimit_Text.Location = new System.Drawing.Point(384, 92);
            this.lowLimit_Text.Name = "lowLimit_Text";
            this.lowLimit_Text.Size = new System.Drawing.Size(100, 20);
            this.lowLimit_Text.TabIndex = 10;
            this.lowLimit_Text.TextChanged += new System.EventHandler(this.lowLimit_Text_TextChanged);
            // 
            // FS_text
            // 
            this.FS_text.Location = new System.Drawing.Point(384, 63);
            this.FS_text.Name = "FS_text";
            this.FS_text.Size = new System.Drawing.Size(100, 20);
            this.FS_text.TabIndex = 9;
            this.FS_text.TextChanged += new System.EventHandler(this.FS_text_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(117, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Samples per point *";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(263, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "High Limit *";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(263, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Low Limit *";
            // 
            // FSTarget_label
            // 
            this.FSTarget_label.AutoSize = true;
            this.FSTarget_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSTarget_label.Location = new System.Drawing.Point(263, 66);
            this.FSTarget_label.Name = "FSTarget_label";
            this.FSTarget_label.Size = new System.Drawing.Size(115, 13);
            this.FSTarget_label.TabIndex = 5;
            this.FSTarget_label.Text = "Full Scale/Target *";
            // 
            // addPoint_button
            // 
            this.addPoint_button.Location = new System.Drawing.Point(265, 153);
            this.addPoint_button.Name = "addPoint_button";
            this.addPoint_button.Size = new System.Drawing.Size(100, 23);
            this.addPoint_button.TabIndex = 4;
            this.addPoint_button.Text = "Add Points";
            this.addPoint_button.UseVisualStyleBackColor = true;
            this.addPoint_button.Click += new System.EventHandler(this.addPoint_button_Click);
            // 
            // customPoint_Text
            // 
            this.customPoint_Text.Location = new System.Drawing.Point(123, 91);
            this.customPoint_Text.Name = "customPoint_Text";
            this.customPoint_Text.Size = new System.Drawing.Size(100, 20);
            this.customPoint_Text.TabIndex = 3;
            this.customPoint_Text.TextChanged += new System.EventHandler(this.customPoint_Text_TextChanged);
            // 
            // customPoint_label
            // 
            this.customPoint_label.AutoSize = true;
            this.customPoint_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customPoint_label.Location = new System.Drawing.Point(9, 94);
            this.customPoint_label.Name = "customPoint_label";
            this.customPoint_label.Size = new System.Drawing.Size(96, 13);
            this.customPoint_label.TabIndex = 2;
            this.customPoint_label.Text = "Custom Points *";
            // 
            // pointGrid
            // 
            this.pointGrid.AllowDrop = true;
            this.pointGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pointGrid.Location = new System.Drawing.Point(506, 230);
            this.pointGrid.MultiSelect = false;
            this.pointGrid.Name = "pointGrid";
            this.pointGrid.Size = new System.Drawing.Size(642, 265);
            this.pointGrid.TabIndex = 2;
            this.pointGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pointGrid_CellContentClick);
            this.pointGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.pointGrid_DragDrop);
            this.pointGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.pointGrid_DragEnter);
            this.pointGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pointGrid_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.channel2Settings_groupBox);
            this.groupBox3.Location = new System.Drawing.Point(37, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(438, 239);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tester Settings";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chan1Capacity_Text);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.chan1Frequency_comboxBox);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.chan1Unit_comboBox);
            this.groupBox5.Controls.Add(this.chan1Mode_comboBox);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(6, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(201, 194);
            this.groupBox5.TabIndex = 47;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Channel 1 Settings";
            // 
            // chan1Frequency_comboxBox
            // 
            this.chan1Frequency_comboxBox.FormattingEnabled = true;
            this.chan1Frequency_comboxBox.Location = new System.Drawing.Point(83, 149);
            this.chan1Frequency_comboxBox.Name = "chan1Frequency_comboxBox";
            this.chan1Frequency_comboxBox.Size = new System.Drawing.Size(100, 21);
            this.chan1Frequency_comboxBox.TabIndex = 46;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(4, 85);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 13);
            this.label22.TabIndex = 40;
            this.label22.Text = "Unit";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(4, 157);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(75, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "Frequency *";
            // 
            // chan1Unit_comboBox
            // 
            this.chan1Unit_comboBox.FormattingEnabled = true;
            this.chan1Unit_comboBox.Location = new System.Drawing.Point(83, 76);
            this.chan1Unit_comboBox.Name = "chan1Unit_comboBox";
            this.chan1Unit_comboBox.Size = new System.Drawing.Size(100, 21);
            this.chan1Unit_comboBox.TabIndex = 41;
            this.chan1Unit_comboBox.SelectedIndexChanged += new System.EventHandler(this.chan1Unit_comboBox_SelectedIndexChanged);
            // 
            // chan1Mode_comboBox
            // 
            this.chan1Mode_comboBox.FormattingEnabled = true;
            this.chan1Mode_comboBox.Location = new System.Drawing.Point(83, 113);
            this.chan1Mode_comboBox.Name = "chan1Mode_comboBox";
            this.chan1Mode_comboBox.Size = new System.Drawing.Size(100, 21);
            this.chan1Mode_comboBox.TabIndex = 44;
            this.chan1Mode_comboBox.SelectedIndexChanged += new System.EventHandler(this.chan1Mode_comboBox_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 121);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "Mode *";
            // 
            // channel2Settings_groupBox
            // 
            this.channel2Settings_groupBox.Controls.Add(this.copyChan1Settings_checkBox);
            this.channel2Settings_groupBox.Controls.Add(this.label8);
            this.channel2Settings_groupBox.Controls.Add(this.chan2Capacity_Text);
            this.channel2Settings_groupBox.Controls.Add(this.label17);
            this.channel2Settings_groupBox.Controls.Add(this.chan2Mode_comboBox);
            this.channel2Settings_groupBox.Controls.Add(this.checkBox1);
            this.channel2Settings_groupBox.Controls.Add(this.chan2Unit_comboBox);
            this.channel2Settings_groupBox.Controls.Add(this.label21);
            this.channel2Settings_groupBox.Location = new System.Drawing.Point(226, 16);
            this.channel2Settings_groupBox.Name = "channel2Settings_groupBox";
            this.channel2Settings_groupBox.Size = new System.Drawing.Size(201, 194);
            this.channel2Settings_groupBox.TabIndex = 34;
            this.channel2Settings_groupBox.TabStop = false;
            this.channel2Settings_groupBox.Text = "Channel 2 Settings";
            // 
            // copyChan1Settings_checkBox
            // 
            this.copyChan1Settings_checkBox.AutoSize = true;
            this.copyChan1Settings_checkBox.Location = new System.Drawing.Point(6, 19);
            this.copyChan1Settings_checkBox.Name = "copyChan1Settings_checkBox";
            this.copyChan1Settings_checkBox.Size = new System.Drawing.Size(134, 17);
            this.copyChan1Settings_checkBox.TabIndex = 47;
            this.copyChan1Settings_checkBox.Text = "Use Channel1 Settings";
            this.copyChan1Settings_checkBox.UseVisualStyleBackColor = true;
            this.copyChan1Settings_checkBox.CheckedChanged += new System.EventHandler(this.copyChan1Settings_checkBox_CheckedChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Mode *";
            // 
            // chan2Mode_comboBox
            // 
            this.chan2Mode_comboBox.FormattingEnabled = true;
            this.chan2Mode_comboBox.Location = new System.Drawing.Point(84, 113);
            this.chan2Mode_comboBox.Name = "chan2Mode_comboBox";
            this.chan2Mode_comboBox.Size = new System.Drawing.Size(100, 21);
            this.chan2Mode_comboBox.TabIndex = 33;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(84, 154);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 36;
            this.checkBox1.Text = "Auto Clear";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // chan2Unit_comboBox
            // 
            this.chan2Unit_comboBox.FormattingEnabled = true;
            this.chan2Unit_comboBox.Location = new System.Drawing.Point(84, 77);
            this.chan2Unit_comboBox.Name = "chan2Unit_comboBox";
            this.chan2Unit_comboBox.Size = new System.Drawing.Size(100, 21);
            this.chan2Unit_comboBox.TabIndex = 42;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(12, 85);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 13);
            this.label21.TabIndex = 39;
            this.label21.Text = "Unit";
            // 
            // saveTest_button
            // 
            this.saveTest_button.Location = new System.Drawing.Point(568, 501);
            this.saveTest_button.Name = "saveTest_button";
            this.saveTest_button.Size = new System.Drawing.Size(75, 23);
            this.saveTest_button.TabIndex = 32;
            this.saveTest_button.Text = "Save Test";
            this.saveTest_button.UseVisualStyleBackColor = true;
            this.saveTest_button.Click += new System.EventHandler(this.saveTest_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(701, 501);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // testSequence_List
            // 
            this.testSequence_List.FormattingEnabled = true;
            this.testSequence_List.Location = new System.Drawing.Point(43, 40);
            this.testSequence_List.Name = "testSequence_List";
            this.testSequence_List.Size = new System.Drawing.Size(432, 238);
            this.testSequence_List.TabIndex = 34;
            // 
            // testType_comboBox
            // 
            this.testType_comboBox.FormattingEnabled = true;
            this.testType_comboBox.Location = new System.Drawing.Point(125, 50);
            this.testType_comboBox.Name = "testType_comboBox";
            this.testType_comboBox.Size = new System.Drawing.Size(100, 21);
            this.testType_comboBox.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Test Type *";
            // 
            // testPoints_comboBox
            // 
            this.testPoints_comboBox.FormattingEnabled = true;
            this.testPoints_comboBox.Location = new System.Drawing.Point(125, 13);
            this.testPoints_comboBox.Name = "testPoints_comboBox";
            this.testPoints_comboBox.Size = new System.Drawing.Size(311, 21);
            this.testPoints_comboBox.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Test Points *";
            // 
            // Form_TestSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1185, 581);
            this.Controls.Add(this.testSequence_List);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.saveTest_button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pointGrid);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form_TestSequence";
            this.Text = "Form_TestSequence";
            this.Load += new System.EventHandler(this.Form_TestSequence_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.channel2Settings_groupBox.ResumeLayout(false);
            this.channel2Settings_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox manufacture_text;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox model_text;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox dueDate_text;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox calDate_text;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox chan1Capacity_Text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox chan2Capacity_Text;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox asset_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox serial_text;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox toolName_text;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label customPoint_label;
        private System.Windows.Forms.TextBox samples_text;
        private System.Windows.Forms.TextBox highLimit_Text;
        private System.Windows.Forms.TextBox lowLimit_Text;
        private System.Windows.Forms.TextBox FS_text;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label FSTarget_label;
        private System.Windows.Forms.Button addPoint_button;
        private System.Windows.Forms.TextBox customPoint_Text;
        private System.Windows.Forms.DataGridView pointGrid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox chan2Mode_comboBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox highLimitUnit_comboBox;
        private System.Windows.Forms.ComboBox lowLimitUnit_comboBox;
        private System.Windows.Forms.ComboBox chan1Frequency_comboxBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox chan1Mode_comboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox chan2Unit_comboBox;
        private System.Windows.Forms.ComboBox chan1Unit_comboBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button saveTest_button;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox copyChan1Settings_checkBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox channel2Settings_groupBox;
        private System.Windows.Forms.Button clearFields_button;
        private System.Windows.Forms.ListBox testSequence_List;
        private System.Windows.Forms.ComboBox testType_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox testPoints_comboBox;
        private System.Windows.Forms.Label label2;
    }
}