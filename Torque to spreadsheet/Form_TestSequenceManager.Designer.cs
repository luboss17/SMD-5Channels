namespace WindowsFormsApplication1
{
    partial class Form_TestSequenceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TestSequenceManager));
            this.testSetups_listBox = new System.Windows.Forms.ListBox();
            this.up_btn = new System.Windows.Forms.Button();
            this.down_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.saveClose_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.copyAllStruct_btn = new System.Windows.Forms.Button();
            this.AFCW_grid = new System.Windows.Forms.DataGridView();
            this.ALCCWactive_label = new System.Windows.Forms.Label();
            this.ALCWactive_label = new System.Windows.Forms.Label();
            this.AFCCWactive_label = new System.Windows.Forms.Label();
            this.AFCWactive_label = new System.Windows.Forms.Label();
            this.ALCCW_grid = new System.Windows.Forms.DataGridView();
            this.AFCCW_grid = new System.Windows.Forms.DataGridView();
            this.ALCW_grid = new System.Windows.Forms.DataGridView();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.testSetup_groupBox = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.limitEngPercent_comboBox = new System.Windows.Forms.ComboBox();
            this.saveAsTest_btn = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.sampleNum_txt = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.maxPoint_txt = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.testOrder_list = new System.Windows.Forms.ListBox();
            this.resetCurrTestSettings_btn = new System.Windows.Forms.Button();
            this.testID_txt = new System.Windows.Forms.TextBox();
            this.saveTest_btn = new System.Windows.Forms.Button();
            this.AL_chkbox = new System.Windows.Forms.CheckBox();
            this.AF_chkbox = new System.Windows.Forms.CheckBox();
            this.highLimit_txt = new System.Windows.Forms.TextBox();
            this.lowLimit_txt = new System.Windows.Forms.TextBox();
            this.FS_txt = new System.Windows.Forms.TextBox();
            this.CCW_chkbox = new System.Windows.Forms.CheckBox();
            this.label35 = new System.Windows.Forms.Label();
            this.CW_chkbox = new System.Windows.Forms.CheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.FSTarget_label = new System.Windows.Forms.Label();
            this.testType_comboBox = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newTest_btn = new System.Windows.Forms.Button();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFCW_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCCW_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AFCCW_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCW_grid)).BeginInit();
            this.testSetup_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // testSetups_listBox
            // 
            this.testSetups_listBox.FormattingEnabled = true;
            this.testSetups_listBox.Location = new System.Drawing.Point(6, 30);
            this.testSetups_listBox.Name = "testSetups_listBox";
            this.testSetups_listBox.Size = new System.Drawing.Size(186, 173);
            this.testSetups_listBox.TabIndex = 0;
            this.testSetups_listBox.SelectedIndexChanged += new System.EventHandler(this.testSetups_listBox_SelectedIndexChanged);
            // 
            // up_btn
            // 
            this.up_btn.Location = new System.Drawing.Point(198, 100);
            this.up_btn.Name = "up_btn";
            this.up_btn.Size = new System.Drawing.Size(75, 23);
            this.up_btn.TabIndex = 1;
            this.up_btn.Text = "Move Up";
            this.up_btn.UseVisualStyleBackColor = true;
            this.up_btn.Click += new System.EventHandler(this.up_btn_Click);
            // 
            // down_btn
            // 
            this.down_btn.Location = new System.Drawing.Point(198, 129);
            this.down_btn.Name = "down_btn";
            this.down_btn.Size = new System.Drawing.Size(75, 23);
            this.down_btn.TabIndex = 2;
            this.down_btn.Text = "Move Down";
            this.down_btn.UseVisualStyleBackColor = true;
            this.down_btn.Click += new System.EventHandler(this.down_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(105, 209);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(75, 23);
            this.delete_btn.TabIndex = 3;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // saveClose_btn
            // 
            this.saveClose_btn.Location = new System.Drawing.Point(6, 238);
            this.saveClose_btn.Name = "saveClose_btn";
            this.saveClose_btn.Size = new System.Drawing.Size(105, 23);
            this.saveClose_btn.TabIndex = 5;
            this.saveClose_btn.Text = "Save Close";
            this.saveClose_btn.UseVisualStyleBackColor = true;
            this.saveClose_btn.Click += new System.EventHandler(this.saveClose_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(117, 238);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(75, 23);
            this.cancel_btn.TabIndex = 6;
            this.cancel_btn.Text = "Cancel";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Test Manager";
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.copyAllStruct_btn);
            this.groupBox17.Controls.Add(this.AFCW_grid);
            this.groupBox17.Controls.Add(this.ALCCWactive_label);
            this.groupBox17.Controls.Add(this.ALCWactive_label);
            this.groupBox17.Controls.Add(this.AFCCWactive_label);
            this.groupBox17.Controls.Add(this.AFCWactive_label);
            this.groupBox17.Controls.Add(this.ALCCW_grid);
            this.groupBox17.Controls.Add(this.AFCCW_grid);
            this.groupBox17.Controls.Add(this.ALCW_grid);
            this.groupBox17.Controls.Add(this.label20);
            this.groupBox17.Controls.Add(this.label22);
            this.groupBox17.Controls.Add(this.label19);
            this.groupBox17.Controls.Add(this.label18);
            this.groupBox17.Location = new System.Drawing.Point(12, 321);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(1160, 484);
            this.groupBox17.TabIndex = 3;
            this.groupBox17.TabStop = false;
            // 
            // copyAllStruct_btn
            // 
            this.copyAllStruct_btn.Location = new System.Drawing.Point(447, 10);
            this.copyAllStruct_btn.Name = "copyAllStruct_btn";
            this.copyAllStruct_btn.Size = new System.Drawing.Size(94, 23);
            this.copyAllStruct_btn.TabIndex = 1;
            this.copyAllStruct_btn.Text = "Copy All";
            this.copyAllStruct_btn.UseVisualStyleBackColor = true;
            this.copyAllStruct_btn.Click += new System.EventHandler(this.copyAllStruct_btn_Click);
            // 
            // AFCW_grid
            // 
            this.AFCW_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AFCW_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AFCW_grid.EnableHeadersVisualStyles = false;
            this.AFCW_grid.Location = new System.Drawing.Point(4, 39);
            this.AFCW_grid.Name = "AFCW_grid";
            this.AFCW_grid.Size = new System.Drawing.Size(537, 200);
            this.AFCW_grid.TabIndex = 2;
            // 
            // ALCCWactive_label
            // 
            this.ALCCWactive_label.AutoSize = true;
            this.ALCCWactive_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALCCWactive_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ALCCWactive_label.Location = new System.Drawing.Point(946, 242);
            this.ALCCWactive_label.Name = "ALCCWactive_label";
            this.ALCCWactive_label.Size = new System.Drawing.Size(65, 18);
            this.ALCCWactive_label.TabIndex = 50;
            this.ALCCWactive_label.Text = "ACTIVE";
            this.ALCCWactive_label.Visible = false;
            // 
            // ALCWactive_label
            // 
            this.ALCWactive_label.AutoSize = true;
            this.ALCWactive_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALCWactive_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ALCWactive_label.Location = new System.Drawing.Point(939, 11);
            this.ALCWactive_label.Name = "ALCWactive_label";
            this.ALCWactive_label.Size = new System.Drawing.Size(65, 18);
            this.ALCWactive_label.TabIndex = 49;
            this.ALCWactive_label.Text = "ACTIVE";
            this.ALCWactive_label.Visible = false;
            // 
            // AFCCWactive_label
            // 
            this.AFCCWactive_label.AutoSize = true;
            this.AFCCWactive_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AFCCWactive_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AFCCWactive_label.Location = new System.Drawing.Point(343, 242);
            this.AFCCWactive_label.Name = "AFCCWactive_label";
            this.AFCCWactive_label.Size = new System.Drawing.Size(65, 18);
            this.AFCCWactive_label.TabIndex = 48;
            this.AFCCWactive_label.Text = "ACTIVE";
            this.AFCCWactive_label.Visible = false;
            // 
            // AFCWactive_label
            // 
            this.AFCWactive_label.AutoSize = true;
            this.AFCWactive_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AFCWactive_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AFCWactive_label.Location = new System.Drawing.Point(343, 11);
            this.AFCWactive_label.Name = "AFCWactive_label";
            this.AFCWactive_label.Size = new System.Drawing.Size(65, 18);
            this.AFCWactive_label.TabIndex = 47;
            this.AFCWactive_label.Text = "ACTIVE";
            this.AFCWactive_label.Visible = false;
            // 
            // ALCCW_grid
            // 
            this.ALCCW_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ALCCW_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ALCCW_grid.EnableHeadersVisualStyles = false;
            this.ALCCW_grid.Location = new System.Drawing.Point(613, 265);
            this.ALCCW_grid.Name = "ALCCW_grid";
            this.ALCCW_grid.Size = new System.Drawing.Size(537, 200);
            this.ALCCW_grid.TabIndex = 5;
            // 
            // AFCCW_grid
            // 
            this.AFCCW_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AFCCW_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AFCCW_grid.EnableHeadersVisualStyles = false;
            this.AFCCW_grid.Location = new System.Drawing.Point(3, 265);
            this.AFCCW_grid.Name = "AFCCW_grid";
            this.AFCCW_grid.Size = new System.Drawing.Size(537, 200);
            this.AFCCW_grid.TabIndex = 3;
            // 
            // ALCW_grid
            // 
            this.ALCW_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ALCW_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ALCW_grid.EnableHeadersVisualStyles = false;
            this.ALCW_grid.Location = new System.Drawing.Point(613, 39);
            this.ALCW_grid.Name = "ALCW_grid";
            this.ALCW_grid.Size = new System.Drawing.Size(537, 200);
            this.ALCW_grid.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(872, 246);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "As Left-CCW";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(872, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "As Left-CW";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(257, 246);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 13);
            this.label19.TabIndex = 25;
            this.label19.Text = "As Found-CCW";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(264, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "As Found-CW";
            // 
            // testSetup_groupBox
            // 
            this.testSetup_groupBox.Controls.Add(this.label27);
            this.testSetup_groupBox.Controls.Add(this.limitEngPercent_comboBox);
            this.testSetup_groupBox.Controls.Add(this.saveAsTest_btn);
            this.testSetup_groupBox.Controls.Add(this.label28);
            this.testSetup_groupBox.Controls.Add(this.sampleNum_txt);
            this.testSetup_groupBox.Controls.Add(this.label30);
            this.testSetup_groupBox.Controls.Add(this.label31);
            this.testSetup_groupBox.Controls.Add(this.maxPoint_txt);
            this.testSetup_groupBox.Controls.Add(this.label32);
            this.testSetup_groupBox.Controls.Add(this.label33);
            this.testSetup_groupBox.Controls.Add(this.testOrder_list);
            this.testSetup_groupBox.Controls.Add(this.resetCurrTestSettings_btn);
            this.testSetup_groupBox.Controls.Add(this.testID_txt);
            this.testSetup_groupBox.Controls.Add(this.saveTest_btn);
            this.testSetup_groupBox.Controls.Add(this.AL_chkbox);
            this.testSetup_groupBox.Controls.Add(this.AF_chkbox);
            this.testSetup_groupBox.Controls.Add(this.highLimit_txt);
            this.testSetup_groupBox.Controls.Add(this.lowLimit_txt);
            this.testSetup_groupBox.Controls.Add(this.FS_txt);
            this.testSetup_groupBox.Controls.Add(this.CCW_chkbox);
            this.testSetup_groupBox.Controls.Add(this.label35);
            this.testSetup_groupBox.Controls.Add(this.CW_chkbox);
            this.testSetup_groupBox.Controls.Add(this.label36);
            this.testSetup_groupBox.Controls.Add(this.FSTarget_label);
            this.testSetup_groupBox.Controls.Add(this.testType_comboBox);
            this.testSetup_groupBox.Controls.Add(this.label37);
            this.testSetup_groupBox.Location = new System.Drawing.Point(309, 24);
            this.testSetup_groupBox.Name = "testSetup_groupBox";
            this.testSetup_groupBox.Size = new System.Drawing.Size(488, 273);
            this.testSetup_groupBox.TabIndex = 2;
            this.testSetup_groupBox.TabStop = false;
            this.testSetup_groupBox.Text = "Test Set up";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(238, 111);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(97, 13);
            this.label27.TabIndex = 59;
            this.label27.Text = "% or Eng. Unit *";
            // 
            // limitEngPercent_comboBox
            // 
            this.limitEngPercent_comboBox.FormattingEnabled = true;
            this.limitEngPercent_comboBox.Items.AddRange(new object[] {
            "%",
            "Eng. Unit"});
            this.limitEngPercent_comboBox.Location = new System.Drawing.Point(359, 108);
            this.limitEngPercent_comboBox.Name = "limitEngPercent_comboBox";
            this.limitEngPercent_comboBox.Size = new System.Drawing.Size(100, 21);
            this.limitEngPercent_comboBox.TabIndex = 9;
            // 
            // saveAsTest_btn
            // 
            this.saveAsTest_btn.Location = new System.Drawing.Point(306, 214);
            this.saveAsTest_btn.Name = "saveAsTest_btn";
            this.saveAsTest_btn.Size = new System.Drawing.Size(95, 23);
            this.saveAsTest_btn.TabIndex = 17;
            this.saveAsTest_btn.Text = "Save As New";
            this.saveAsTest_btn.UseVisualStyleBackColor = true;
            this.saveAsTest_btn.Click += new System.EventHandler(this.saveAsTest_btn_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(4, 178);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(117, 13);
            this.label28.TabIndex = 53;
            this.label28.Text = "(Drag to Change Order)";
            // 
            // sampleNum_txt
            // 
            this.sampleNum_txt.Location = new System.Drawing.Point(359, 30);
            this.sampleNum_txt.Name = "sampleNum_txt";
            this.sampleNum_txt.Size = new System.Drawing.Size(100, 20);
            this.sampleNum_txt.TabIndex = 6;
            this.sampleNum_txt.Text = "1";
            this.sampleNum_txt.TextChanged += new System.EventHandler(this.sampleNum_txt_TextChanged);
            this.sampleNum_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sampleNum_txt_KeyDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(238, 33);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(109, 13);
            this.label30.TabIndex = 51;
            this.label30.Text = "# Samples/point *";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(4, 88);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 13);
            this.label31.TabIndex = 49;
            this.label31.Text = "# of Points";
            // 
            // maxPoint_txt
            // 
            this.maxPoint_txt.Location = new System.Drawing.Point(125, 85);
            this.maxPoint_txt.Name = "maxPoint_txt";
            this.maxPoint_txt.Size = new System.Drawing.Size(100, 20);
            this.maxPoint_txt.TabIndex = 3;
            this.maxPoint_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maxPoint_txt_KeyDown);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(4, 163);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(57, 13);
            this.label32.TabIndex = 47;
            this.label32.Text = "Test Order";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(4, 33);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(58, 13);
            this.label33.TabIndex = 46;
            this.label33.Text = "Test ID *";
            // 
            // testOrder_list
            // 
            this.testOrder_list.AllowDrop = true;
            this.testOrder_list.FormattingEnabled = true;
            this.testOrder_list.Location = new System.Drawing.Point(125, 163);
            this.testOrder_list.Name = "testOrder_list";
            this.testOrder_list.Size = new System.Drawing.Size(100, 69);
            this.testOrder_list.TabIndex = 10;
            // 
            // resetCurrTestSettings_btn
            // 
            this.resetCurrTestSettings_btn.Location = new System.Drawing.Point(409, 214);
            this.resetCurrTestSettings_btn.Name = "resetCurrTestSettings_btn";
            this.resetCurrTestSettings_btn.Size = new System.Drawing.Size(73, 23);
            this.resetCurrTestSettings_btn.TabIndex = 18;
            this.resetCurrTestSettings_btn.Text = "Reset Fields";
            this.resetCurrTestSettings_btn.UseVisualStyleBackColor = true;
            // 
            // testID_txt
            // 
            this.testID_txt.Location = new System.Drawing.Point(125, 30);
            this.testID_txt.Name = "testID_txt";
            this.testID_txt.Size = new System.Drawing.Size(100, 20);
            this.testID_txt.TabIndex = 1;
            // 
            // saveTest_btn
            // 
            this.saveTest_btn.Location = new System.Drawing.Point(231, 214);
            this.saveTest_btn.Name = "saveTest_btn";
            this.saveTest_btn.Size = new System.Drawing.Size(71, 23);
            this.saveTest_btn.TabIndex = 16;
            this.saveTest_btn.Text = "Save Test";
            this.saveTest_btn.UseVisualStyleBackColor = true;
            this.saveTest_btn.Click += new System.EventHandler(this.saveTest_btn_Click);
            // 
            // AL_chkbox
            // 
            this.AL_chkbox.AutoSize = true;
            this.AL_chkbox.Location = new System.Drawing.Point(342, 160);
            this.AL_chkbox.Name = "AL_chkbox";
            this.AL_chkbox.Size = new System.Drawing.Size(59, 17);
            this.AL_chkbox.TabIndex = 13;
            this.AL_chkbox.Text = "As Left";
            this.AL_chkbox.UseVisualStyleBackColor = true;
            this.AL_chkbox.CheckedChanged += new System.EventHandler(this.AL_chkbox_CheckedChanged);
            // 
            // AF_chkbox
            // 
            this.AF_chkbox.AutoSize = true;
            this.AF_chkbox.Location = new System.Drawing.Point(240, 160);
            this.AF_chkbox.Name = "AF_chkbox";
            this.AF_chkbox.Size = new System.Drawing.Size(71, 17);
            this.AF_chkbox.TabIndex = 12;
            this.AF_chkbox.Text = "As Found";
            this.AF_chkbox.UseVisualStyleBackColor = true;
            this.AF_chkbox.CheckedChanged += new System.EventHandler(this.AF_chkbox_CheckedChanged);
            // 
            // highLimit_txt
            // 
            this.highLimit_txt.Location = new System.Drawing.Point(359, 82);
            this.highLimit_txt.Name = "highLimit_txt";
            this.highLimit_txt.Size = new System.Drawing.Size(100, 20);
            this.highLimit_txt.TabIndex = 8;
            this.highLimit_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.highLimit_txt_KeyDown);
            // 
            // lowLimit_txt
            // 
            this.lowLimit_txt.Location = new System.Drawing.Point(359, 56);
            this.lowLimit_txt.Name = "lowLimit_txt";
            this.lowLimit_txt.Size = new System.Drawing.Size(100, 20);
            this.lowLimit_txt.TabIndex = 7;
            this.lowLimit_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lowLimit_txt_KeyDown);
            // 
            // FS_txt
            // 
            this.FS_txt.Location = new System.Drawing.Point(125, 116);
            this.FS_txt.Name = "FS_txt";
            this.FS_txt.Size = new System.Drawing.Size(100, 20);
            this.FS_txt.TabIndex = 4;
            this.FS_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FS_txt_KeyDown);
            // 
            // CCW_chkbox
            // 
            this.CCW_chkbox.AutoSize = true;
            this.CCW_chkbox.Location = new System.Drawing.Point(342, 190);
            this.CCW_chkbox.Name = "CCW_chkbox";
            this.CCW_chkbox.Size = new System.Drawing.Size(114, 17);
            this.CCW_chkbox.TabIndex = 15;
            this.CCW_chkbox.Text = "Counter Clockwise";
            this.CCW_chkbox.UseVisualStyleBackColor = true;
            this.CCW_chkbox.CheckedChanged += new System.EventHandler(this.CCW_chkbox_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(240, 85);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 13);
            this.label35.TabIndex = 33;
            this.label35.Text = "High Limit *";
            // 
            // CW_chkbox
            // 
            this.CW_chkbox.AutoSize = true;
            this.CW_chkbox.Location = new System.Drawing.Point(240, 190);
            this.CW_chkbox.Name = "CW_chkbox";
            this.CW_chkbox.Size = new System.Drawing.Size(74, 17);
            this.CW_chkbox.TabIndex = 14;
            this.CW_chkbox.Text = "Clockwise";
            this.CW_chkbox.UseVisualStyleBackColor = true;
            this.CW_chkbox.CheckedChanged += new System.EventHandler(this.CW_chkbox_CheckedChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(238, 59);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(69, 13);
            this.label36.TabIndex = 32;
            this.label36.Text = "Low Limit *";
            // 
            // FSTarget_label
            // 
            this.FSTarget_label.AutoSize = true;
            this.FSTarget_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSTarget_label.Location = new System.Drawing.Point(4, 119);
            this.FSTarget_label.Name = "FSTarget_label";
            this.FSTarget_label.Size = new System.Drawing.Size(109, 13);
            this.FSTarget_label.TabIndex = 31;
            this.FSTarget_label.Text = "Target Full Scale*";
            // 
            // testType_comboBox
            // 
            this.testType_comboBox.FormattingEnabled = true;
            this.testType_comboBox.Items.AddRange(new object[] {
            "Single Channel Test",
            "Dual Channel Test"});
            this.testType_comboBox.Location = new System.Drawing.Point(125, 55);
            this.testType_comboBox.Name = "testType_comboBox";
            this.testType_comboBox.Size = new System.Drawing.Size(100, 21);
            this.testType_comboBox.TabIndex = 2;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(4, 58);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(73, 13);
            this.label37.TabIndex = 12;
            this.label37.Text = "Test Type *";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newTest_btn);
            this.groupBox1.Controls.Add(this.testSetups_listBox);
            this.groupBox1.Controls.Add(this.up_btn);
            this.groupBox1.Controls.Add(this.down_btn);
            this.groupBox1.Controls.Add(this.delete_btn);
            this.groupBox1.Controls.Add(this.cancel_btn);
            this.groupBox1.Controls.Add(this.saveClose_btn);
            this.groupBox1.Location = new System.Drawing.Point(18, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 291);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Manager";
            // 
            // newTest_btn
            // 
            this.newTest_btn.Location = new System.Drawing.Point(16, 208);
            this.newTest_btn.Name = "newTest_btn";
            this.newTest_btn.Size = new System.Drawing.Size(75, 23);
            this.newTest_btn.TabIndex = 7;
            this.newTest_btn.Text = "New Test";
            this.newTest_btn.UseVisualStyleBackColor = true;
            this.newTest_btn.Click += new System.EventHandler(this.newTest_btn_Click);
            // 
            // TestSequenceManager_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 828);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.testSetup_groupBox);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestSequenceManager_form";
            this.Text = "Test Manager";
            this.Load += new System.EventHandler(this.TestSequenceManager_form_Load);
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFCW_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCCW_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AFCCW_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCW_grid)).EndInit();
            this.testSetup_groupBox.ResumeLayout(false);
            this.testSetup_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox testSetups_listBox;
        private System.Windows.Forms.Button up_btn;
        private System.Windows.Forms.Button down_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button saveClose_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Button copyAllStruct_btn;
        private System.Windows.Forms.DataGridView AFCW_grid;
        private System.Windows.Forms.Label ALCCWactive_label;
        private System.Windows.Forms.Label ALCWactive_label;
        private System.Windows.Forms.Label AFCCWactive_label;
        private System.Windows.Forms.Label AFCWactive_label;
        private System.Windows.Forms.DataGridView ALCCW_grid;
        private System.Windows.Forms.DataGridView AFCCW_grid;
        private System.Windows.Forms.DataGridView ALCW_grid;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox testSetup_groupBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox limitEngPercent_comboBox;
        private System.Windows.Forms.Button saveAsTest_btn;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox sampleNum_txt;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox maxPoint_txt;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ListBox testOrder_list;
        private System.Windows.Forms.Button resetCurrTestSettings_btn;
        private System.Windows.Forms.TextBox testID_txt;
        private System.Windows.Forms.Button saveTest_btn;
        private System.Windows.Forms.CheckBox AL_chkbox;
        private System.Windows.Forms.CheckBox AF_chkbox;
        private System.Windows.Forms.TextBox highLimit_txt;
        private System.Windows.Forms.TextBox lowLimit_txt;
        private System.Windows.Forms.TextBox FS_txt;
        private System.Windows.Forms.CheckBox CCW_chkbox;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.CheckBox CW_chkbox;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label FSTarget_label;
        private System.Windows.Forms.ComboBox testType_comboBox;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button newTest_btn;
    }
}