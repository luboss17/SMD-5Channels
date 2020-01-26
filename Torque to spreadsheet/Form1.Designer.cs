using System;
using System.Windows.Forms;
using Dymo;
namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.SpreadSheetModeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineQuickExportPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDateStampToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showALLCOMAvailableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableLiveReadingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteDataAtCursorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceAutoClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tester_Type_Label = new System.Windows.Forms.Label();
            this.checkBox_millivolt = new System.Windows.Forms.CheckBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.testerType = new System.Windows.Forms.Label();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.dualChannelTab = new System.Windows.Forms.TabPage();
            this.dualSeriesListView = new System.Windows.Forms.ListView();
            this.dualRunName2ErrorLabel = new System.Windows.Forms.Label();
            this.dualRunName1ErrorLabel = new System.Windows.Forms.Label();
            this.dualMasterGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.xySwitch_button = new System.Windows.Forms.Button();
            this.dualCurrRun_Label2 = new System.Windows.Forms.Label();
            this.dualCurrRun_label1 = new System.Windows.Forms.Label();
            this.dualCh2RunName_Text = new System.Windows.Forms.TextBox();
            this.dualCh1RunName_Text = new System.Windows.Forms.TextBox();
            this.switchTestCalMode_button = new System.Windows.Forms.Button();
            this.currRunDualSaveExcel = new System.Windows.Forms.Button();
            this.addDualRun = new System.Windows.Forms.Button();
            this.dualCertExport_button = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.clearBothData_button = new System.Windows.Forms.Button();
            this.deleteBothRow_button = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.unitCH2DualCHTab_lbl = new System.Windows.Forms.Label();
            this.dataCh2DualChTab_lbl = new System.Windows.Forms.Label();
            this.secondComConnect = new System.Windows.Forms.Label();
            this.chan2_menuControl_button = new System.Windows.Forms.Button();
            this.chan2_zeroControl_button = new System.Windows.Forms.Button();
            this.chan2_modeControl_button = new System.Windows.Forms.Button();
            this.chan2_unitControl_button = new System.Windows.Forms.Button();
            this.defineTest = new System.Windows.Forms.Button();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comList4 = new System.Windows.Forms.ListBox();
            this.openCloseSecondPort = new System.Windows.Forms.Button();
            this.openCloseFirstPort = new System.Windows.Forms.Button();
            this.refresh_dualTab = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lowLimitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highLimitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.theoreticalTarget = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chan1Reading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chan2Reading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveRun_button = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.currRunDualQuickExport = new System.Windows.Forms.Button();
            this.serieListBox = new System.Windows.Forms.CheckedListBox();
            this.button16 = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.noCurrDualMasterGrid = new System.Windows.Forms.DataGridView();
            this.test_save_button = new System.Windows.Forms.Button();
            this.dualTestName_Text = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.quickDualExport_button = new System.Windows.Forms.Button();
            this.renameDualRun = new System.Windows.Forms.Button();
            this.deleteDualRun_Button = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.unitCH1DualCHTab_lbl = new System.Windows.Forms.Label();
            this.chan1_captureControl_button = new System.Windows.Forms.Button();
            this.chann1_zeroControl_button = new System.Windows.Forms.Button();
            this.chan1_unitControl_button = new System.Windows.Forms.Button();
            this.chan1_modeControl_button = new System.Windows.Forms.Button();
            this.chan1_menuControl_button = new System.Windows.Forms.Button();
            this.dataCh1DualChanTab_lbl = new System.Windows.Forms.Label();
            this.firstComConnect = new System.Windows.Forms.Label();
            this.dualChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearSecond = new System.Windows.Forms.Button();
            this.deleteSecond = new System.Windows.Forms.Button();
            this.secondChannelGridView = new System.Windows.Forms.DataGridView();
            this.clearFirst = new System.Windows.Forms.Button();
            this.deleteLineFirst = new System.Windows.Forms.Button();
            this.firstChannelGrid = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.big_graph = new System.Windows.Forms.TabPage();
            this.Label_Data3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.read_graph_col = new System.Windows.Forms.TabPage();
            this.singleSeriesListView = new System.Windows.Forms.ListView();
            this.button10 = new System.Windows.Forms.Button();
            this.masterGridView = new System.Windows.Forms.DataGridView();
            this.command_text = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.masterGrid_noCurrent = new System.Windows.Forms.DataGridView();
            this.masterSave = new System.Windows.Forms.Button();
            this.masterQuickExport = new System.Windows.Forms.Button();
            this.rename_col = new System.Windows.Forms.Button();
            this.delete_column = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.testName_Text = new System.Windows.Forms.TextBox();
            this.test_label = new System.Windows.Forms.TextBox();
            this.singleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.unitSingleCH_lbl = new System.Windows.Forms.Label();
            this.enterControl_button = new System.Windows.Forms.Button();
            this.zeroControl_button = new System.Windows.Forms.Button();
            this.unitControl_button = new System.Windows.Forms.Button();
            this.modeControl_button = new System.Windows.Forms.Button();
            this.menuControl_button = new System.Windows.Forms.Button();
            this.COMconnect = new System.Windows.Forms.Label();
            this.DataSMDSingle_lbl = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comList3 = new System.Windows.Forms.ListBox();
            this.refresh2 = new System.Windows.Forms.Button();
            this.chan1ConnectButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.target = new System.Windows.Forms.TextBox();
            this.clear_limit = new System.Windows.Forms.Button();
            this.draw_limit = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.low_limit = new System.Windows.Forms.TextBox();
            this.low_unit = new System.Windows.Forms.RadioButton();
            this.low_percent = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.high_limit = new System.Windows.Forms.TextBox();
            this.high_unit = new System.Windows.Forms.RadioButton();
            this.high_percent = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dsad = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.notNumberWarning_lbl = new System.Windows.Forms.Label();
            this.useLimit_chkbox = new System.Windows.Forms.CheckBox();
            this.label46 = new System.Windows.Forms.Label();
            this.toolID_SC_comboBox = new System.Windows.Forms.ComboBox();
            this.average_lbl = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.USL_txt = new System.Windows.Forms.TextBox();
            this.LSL_txt = new System.Windows.Forms.TextBox();
            this.showCMK_chkBox = new System.Windows.Forms.CheckBox();
            this.CMKVal_lbl = new System.Windows.Forms.Label();
            this.CMK_lbl = new System.Windows.Forms.Label();
            this.CMVal_lbl = new System.Windows.Forms.Label();
            this.CM_lbl = new System.Windows.Forms.Label();
            this.runNameErrorLabel = new System.Windows.Forms.Label();
            this.currentRunText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.saveCurrent_button = new System.Windows.Forms.Button();
            this.add_serie = new System.Windows.Forms.Button();
            this.clearCh1CurrRun_btn = new System.Windows.Forms.Button();
            this.saveCurrRun_1chann_button = new System.Windows.Forms.Button();
            this.quickExport = new System.Windows.Forms.Button();
            this.deleteCh1Row_btn = new System.Windows.Forms.Button();
            this.singleChannel_gridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simple_col = new System.Windows.Forms.TabPage();
            this.Label_Data1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comList2 = new System.Windows.Forms.ListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.export = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.gridview = new System.Windows.Forms.DataGridView();
            this.mem_cell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simple_reading = new System.Windows.Forms.TabPage();
            this.commandResult_txt = new System.Windows.Forms.TextBox();
            this.command_btn = new System.Windows.Forms.Button();
            this.command_txt = new System.Windows.Forms.TextBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.Button_Aquire = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.RowCountMax = new System.Windows.Forms.NumericUpDown();
            this.Reading_Only_Box = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.unitTTS_lbl = new System.Windows.Forms.Label();
            this.COMconnect2 = new System.Windows.Forms.Label();
            this.DataTTS_lbl = new System.Windows.Forms.Label();
            this.comListRefresh = new System.Windows.Forms.Button();
            this.Button_Serial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comList = new System.Windows.Forms.ListBox();
            this.TabPages = new System.Windows.Forms.TabControl();
            this.big_reading = new System.Windows.Forms.TabPage();
            this.downSize_btn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ch1Connect_btn_bigReading = new System.Windows.Forms.Button();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.high_unitComboBox = new System.Windows.Forms.ComboBox();
            this.low_unitComboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.low_bigReading_txt = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.high_bigReading_txt = new System.Windows.Forms.TextBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.target_bigReading_txt = new System.Windows.Forms.RichTextBox();
            this.PassFail_lbl = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.refreshCOMList_btn_bigReading = new System.Windows.Forms.Button();
            this.comList_bigReading = new System.Windows.Forms.ListBox();
            this.upSize_btn = new System.Windows.Forms.Button();
            this.reading_bigReading_lbl = new System.Windows.Forms.Label();
            this.calibrationTab = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.ch2Target_select = new System.Windows.Forms.RadioButton();
            this.ch1Target_select = new System.Windows.Forms.RadioButton();
            this.startTest_btn = new System.Windows.Forms.Button();
            this.continue_pauseTest_btn = new System.Windows.Forms.Button();
            this.captureBtn_calTab = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
<<<<<<< HEAD
=======
            this.openOldStream_btn = new System.Windows.Forms.Button();
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.ALCCWChart_radio = new System.Windows.Forms.RadioButton();
            this.AFCCWChart_radio = new System.Windows.Forms.RadioButton();
            this.ALCWChart_radio = new System.Windows.Forms.RadioButton();
            this.AFCWChart_radio = new System.Windows.Forms.RadioButton();
            this.exportChart_btn = new System.Windows.Forms.Button();
<<<<<<< HEAD
            this.stream_btn = new System.Windows.Forms.Button();
=======
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.exportAverage_chckbox = new System.Windows.Forms.CheckBox();
            this.excelExport_calTab_btn = new System.Windows.Forms.Button();
            this.copyAllStruct_btn = new System.Windows.Forms.Button();
            this.AFCW_grid = new System.Windows.Forms.DataGridView();
            this.ALCCWactive_label = new System.Windows.Forms.Label();
            this.ALCWactive_label = new System.Windows.Forms.Label();
            this.AFCCWactive_label = new System.Windows.Forms.Label();
            this.AFCWactive_label = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lowColor_label = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.highColor_label = new System.Windows.Forms.Label();
            this.ALCCW_grid = new System.Windows.Forms.DataGridView();
            this.abandonTest_btn = new System.Windows.Forms.Button();
            this.AFCCW_grid = new System.Windows.Forms.DataGridView();
            this.ALCW_grid = new System.Windows.Forms.DataGridView();
            this.openCert_btn = new System.Windows.Forms.Button();
            this.saveTestToCert_btn = new System.Windows.Forms.Button();
            this.restartTest_btn = new System.Windows.Forms.Button();
            this.deleteLastTestRow_btn = new System.Windows.Forms.Button();
            this.copyCCW_btn = new System.Windows.Forms.Button();
            this.copyCW_btn = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.stream_btn = new System.Windows.Forms.Button();
            this.ch2Reading_groupBox = new System.Windows.Forms.GroupBox();
            this.ch2Trough_chckbox = new System.Windows.Forms.CheckBox();
            this.label39 = new System.Windows.Forms.Label();
            this.ch2UnitLabel_calTab = new System.Windows.Forms.Label();
            this.ch2ReadingLabel_calTab = new System.Windows.Forms.Label();
            this.ch2ConnectLabel_calTab = new System.Windows.Forms.Label();
            this.ch2MenuControlBtn_calTab = new System.Windows.Forms.Button();
            this.ch2ZeroBtn_calTab = new System.Windows.Forms.Button();
            this.ch2ModeControlBtn_calTab = new System.Windows.Forms.Button();
            this.ch2UnitBtn_calTab = new System.Windows.Forms.Button();
            this.testSetup_groupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.limitEngPercent_comboBox = new System.Windows.Forms.ComboBox();
            this.saveAsTest_btn = new System.Windows.Forms.Button();
            this.ch2Unit_txt = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.ch1Unit_txt = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.sampleNum_txt = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.maxPoint_txt = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.testID_lbl = new System.Windows.Forms.Label();
            this.testOrder_list = new System.Windows.Forms.ListBox();
            this.resetCurrTestSettings_btn = new System.Windows.Forms.Button();
            this.testID_txt = new System.Windows.Forms.TextBox();
            this.saveStartTest_btn = new System.Windows.Forms.Button();
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
            this.testSetup_comboBox = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.comList_calibration = new System.Windows.Forms.ListBox();
            this.ch2ConnectBtn_calTab = new System.Windows.Forms.Button();
            this.ch1ConnectBtn_calTab = new System.Windows.Forms.Button();
            this.comRefreshBtn_calTab = new System.Windows.Forms.Button();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.ch1Trough_chckbox = new System.Windows.Forms.CheckBox();
            this.label34 = new System.Windows.Forms.Label();
            this.ch1MenuControlBtn_calTab = new System.Windows.Forms.Button();
            this.ch1ZeroBtn_calTab = new System.Windows.Forms.Button();
            this.ch1ModeControlBtn_calTab = new System.Windows.Forms.Button();
            this.ch1UnitBtn_calTab = new System.Windows.Forms.Button();
            this.ch1UnitLabel_calTab = new System.Windows.Forms.Label();
            this.ch1ReadingLabel_calTab = new System.Windows.Forms.Label();
            this.ch1ConnectLabel_calTab = new System.Windows.Forms.Label();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.comment_txt = new System.Windows.Forms.TextBox();
            this.comment_lbl = new System.Windows.Forms.Label();
            this.toolID_comboBox = new System.Windows.Forms.ComboBox();
            this.toolOperatorID_txt = new System.Windows.Forms.TextBox();
            this.operatorID_lbl = new System.Windows.Forms.Label();
            this.toolProcedure_txt = new System.Windows.Forms.TextBox();
            this.procedure_lbl = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.toolCertLot_txt = new System.Windows.Forms.TextBox();
            this.certLot_lbl = new System.Windows.Forms.Label();
            this.toolManufacture_txt = new System.Windows.Forms.TextBox();
            this.manu_lbl = new System.Windows.Forms.Label();
            this.toolModel_txt = new System.Windows.Forms.TextBox();
            this.model_lbl = new System.Windows.Forms.Label();
            this.humid_txt = new System.Windows.Forms.TextBox();
            this.humid_lbl = new System.Windows.Forms.Label();
            this.temperature_txt = new System.Windows.Forms.TextBox();
            this.temperature_lbl = new System.Windows.Forms.Label();
            this.recall_txt = new System.Windows.Forms.TextBox();
            this.recall_lbl = new System.Windows.Forms.Label();
            this.toolSN_txt = new System.Windows.Forms.TextBox();
            this.toolSN_lbl = new System.Windows.Forms.Label();
            this.toolID_lbl = new System.Windows.Forms.Label();
            this.target_groupBox = new System.Windows.Forms.GroupBox();
            this.testTarget_lbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.dualChannelTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dualMasterGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noCurrDualMasterGrid)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dualChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelGrid)).BeginInit();
            this.big_graph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.read_graph_col.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).BeginInit();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid_noCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleChart)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleChannel_gridView)).BeginInit();
            this.simple_col.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).BeginInit();
            this.simple_reading.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowCountMax)).BeginInit();
            this.groupBox12.SuspendLayout();
            this.TabPages.SuspendLayout();
            this.big_reading.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.calibrationTab.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFCW_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCCW_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AFCCW_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCW_grid)).BeginInit();
            this.ch2Reading_groupBox.SuspendLayout();
            this.testSetup_groupBox.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.target_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.SpreadSheetModeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(894, 977);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1977, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel1.Text = "Port: ";
            this.toolStripStatusLabel1.MouseHover += new System.EventHandler(this.toolStripStatusLabel1_MouseHover);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(22, 20);
            this.toolStripDropDownButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripDropDownButton1_DropDownItemClicked);
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            this.toolStripDropDownButton1.MouseHover += new System.EventHandler(this.toolStripDropDownButton1_MouseHover);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(188, 17);
            this.toolStripStatusLabel2.Text = " Status: Closed";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(245, 17);
            this.toolStripStatusLabel3.Text = " Spreadsheet Mode:";
            // 
            // SpreadSheetModeLabel
            // 
            this.SpreadSheetModeLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpreadSheetModeLabel.Name = "SpreadSheetModeLabel";
            this.SpreadSheetModeLabel.Size = new System.Drawing.Size(150, 17);
            this.SpreadSheetModeLabel.Text = "Deactivated";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.toolsManagerToolStripMenuItem,
            this.testManagerToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.printToolToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
<<<<<<< HEAD
            this.menuStrip1.Size = new System.Drawing.Size(1784, 40);
=======
            this.menuStrip1.Size = new System.Drawing.Size(1731, 24);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // openMenuItem
            // 
            this.openMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openStripMenuItem,
            this.newTestToolStripMenuItem,
            this.defineQuickExportPathToolStripMenuItem,
            this.streamDataToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.openMenuItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(58, 36);
            this.openMenuItem.Text = "File";
            // 
            // openStripMenuItem
            // 
            this.openStripMenuItem.Name = "openStripMenuItem";
            this.openStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.openStripMenuItem.Text = "Open";
            this.openStripMenuItem.Click += new System.EventHandler(this.openStripMenuItem_Click);
            // 
            // newTestToolStripMenuItem
            // 
            this.newTestToolStripMenuItem.Name = "newTestToolStripMenuItem";
            this.newTestToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.newTestToolStripMenuItem.Text = "Restart App";
            this.newTestToolStripMenuItem.Click += new System.EventHandler(this.newTestToolStripMenuItem_Click);
            // 
            // defineQuickExportPathToolStripMenuItem
            // 
            this.defineQuickExportPathToolStripMenuItem.Name = "defineQuickExportPathToolStripMenuItem";
            this.defineQuickExportPathToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.defineQuickExportPathToolStripMenuItem.Text = "Define Quick Export Path";
            this.defineQuickExportPathToolStripMenuItem.Click += new System.EventHandler(this.defineQuickExportPathToolStripMenuItem_Click);
            // 
            // streamDataToolStripMenuItem
            // 
            this.streamDataToolStripMenuItem.Name = "streamDataToolStripMenuItem";
            this.streamDataToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.streamDataToolStripMenuItem.Text = "Stream Data";
            this.streamDataToolStripMenuItem.Visible = false;
            this.streamDataToolStripMenuItem.Click += new System.EventHandler(this.streamDataToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(350, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsManagerToolStripMenuItem
            // 
            this.toolsManagerToolStripMenuItem.Name = "toolsManagerToolStripMenuItem";
<<<<<<< HEAD
            this.toolsManagerToolStripMenuItem.Size = new System.Drawing.Size(184, 36);
=======
            this.toolsManagerToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.toolsManagerToolStripMenuItem.Text = "Tools Manager";
            this.toolsManagerToolStripMenuItem.Click += new System.EventHandler(this.toolsManagerToolStripMenuItem_Click);
            // 
            // testManagerToolStripMenuItem
            // 
            this.testManagerToolStripMenuItem.Name = "testManagerToolStripMenuItem";
<<<<<<< HEAD
            this.testManagerToolStripMenuItem.Size = new System.Drawing.Size(171, 36);
=======
            this.testManagerToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.testManagerToolStripMenuItem.Text = "Test Manager";
            this.testManagerToolStripMenuItem.Click += new System.EventHandler(this.testManagerToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoConnectToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem,
            this.includeDateStampToolStripMenuItem,
            this.showALLCOMAvailableToolStripMenuItem,
            this.enableLiveReadingToolStripMenuItem,
            this.overwriteDataAtCursorToolStripMenuItem,
            this.forceAutoClearToolStripMenuItem,
            this.autoUpdateMenuItem,
            this.updateToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(111, 36);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // autoConnectToolStripMenuItem
            // 
            this.autoConnectToolStripMenuItem.CheckOnClick = true;
            this.autoConnectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMinimizedToolStripMenuItem});
            this.autoConnectToolStripMenuItem.Name = "autoConnectToolStripMenuItem";
            this.autoConnectToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.autoConnectToolStripMenuItem.Text = "Auto Connect";
            this.autoConnectToolStripMenuItem.Visible = false;
            this.autoConnectToolStripMenuItem.Click += new System.EventHandler(this.autoConnectToolStripMenuItem_Click);
            // 
            // startMinimizedToolStripMenuItem
            // 
            this.startMinimizedToolStripMenuItem.CheckOnClick = true;
            this.startMinimizedToolStripMenuItem.Enabled = false;
            this.startMinimizedToolStripMenuItem.Name = "startMinimizedToolStripMenuItem";
            this.startMinimizedToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.startMinimizedToolStripMenuItem.Text = "Start Minimized";
            this.startMinimizedToolStripMenuItem.Click += new System.EventHandler(this.startMinimizedToolStripMenuItem_Click);
            this.startMinimizedToolStripMenuItem.EnabledChanged += new System.EventHandler(this.startMinimizedToolStripMenuItem_EnabledChanged);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // includeDateStampToolStripMenuItem
            // 
            this.includeDateStampToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeTimeToolStripMenuItem,
            this.includeDateToolStripMenuItem});
            this.includeDateStampToolStripMenuItem.Name = "includeDateStampToolStripMenuItem";
            this.includeDateStampToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.includeDateStampToolStripMenuItem.Text = "Time/Date Stamp";
            // 
            // includeTimeToolStripMenuItem
            // 
            this.includeTimeToolStripMenuItem.Name = "includeTimeToolStripMenuItem";
<<<<<<< HEAD
            this.includeTimeToolStripMenuItem.Size = new System.Drawing.Size(252, 38);
=======
            this.includeTimeToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.includeTimeToolStripMenuItem.Text = "Include Time";
            this.includeTimeToolStripMenuItem.Click += new System.EventHandler(this.includeTimeToolStripMenuItem_Click);
            // 
            // includeDateToolStripMenuItem
            // 
            this.includeDateToolStripMenuItem.Name = "includeDateToolStripMenuItem";
<<<<<<< HEAD
            this.includeDateToolStripMenuItem.Size = new System.Drawing.Size(252, 38);
=======
            this.includeDateToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.includeDateToolStripMenuItem.Text = "Include Date";
            this.includeDateToolStripMenuItem.Click += new System.EventHandler(this.includeDateToolStripMenuItem_Click);
            // 
            // showALLCOMAvailableToolStripMenuItem
            // 
            this.showALLCOMAvailableToolStripMenuItem.Checked = true;
            this.showALLCOMAvailableToolStripMenuItem.CheckOnClick = true;
            this.showALLCOMAvailableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showALLCOMAvailableToolStripMenuItem.Name = "showALLCOMAvailableToolStripMenuItem";
            this.showALLCOMAvailableToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.showALLCOMAvailableToolStripMenuItem.Text = "Show ALL COM available";
            this.showALLCOMAvailableToolStripMenuItem.Click += new System.EventHandler(this.showALLCOMAvailableToolStripMenuItem_Click);
            // 
            // enableLiveReadingToolStripMenuItem
            // 
            this.enableLiveReadingToolStripMenuItem.Checked = true;
            this.enableLiveReadingToolStripMenuItem.CheckOnClick = true;
            this.enableLiveReadingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableLiveReadingToolStripMenuItem.Name = "enableLiveReadingToolStripMenuItem";
            this.enableLiveReadingToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.enableLiveReadingToolStripMenuItem.Text = "Enable Live Reading";
            // 
            // overwriteDataAtCursorToolStripMenuItem
            // 
            this.overwriteDataAtCursorToolStripMenuItem.CheckOnClick = true;
            this.overwriteDataAtCursorToolStripMenuItem.Name = "overwriteDataAtCursorToolStripMenuItem";
            this.overwriteDataAtCursorToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.overwriteDataAtCursorToolStripMenuItem.Text = "Overwrite Data at Cursor";
            // 
            // forceAutoClearToolStripMenuItem
            // 
            this.forceAutoClearToolStripMenuItem.Name = "forceAutoClearToolStripMenuItem";
            this.forceAutoClearToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.forceAutoClearToolStripMenuItem.Text = "Force Auto-Clear";
            this.forceAutoClearToolStripMenuItem.Click += new System.EventHandler(this.forceAutoClearToolStripMenuItem_Click);
            // 
            // autoUpdateMenuItem
            // 
            this.autoUpdateMenuItem.Checked = true;
            this.autoUpdateMenuItem.CheckOnClick = true;
            this.autoUpdateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpdateMenuItem.Name = "autoUpdateMenuItem";
            this.autoUpdateMenuItem.Size = new System.Drawing.Size(377, 38);
            this.autoUpdateMenuItem.Text = "Auto Update";
            this.autoUpdateMenuItem.Click += new System.EventHandler(this.autoUpdateMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(377, 38);
            this.updateToolStripMenuItem.Text = "Manual Update";
            this.updateToolStripMenuItem.Visible = false;
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // printToolToolStripMenuItem
            // 
            this.printToolToolStripMenuItem.Name = "printToolToolStripMenuItem";
<<<<<<< HEAD
            this.printToolToolStripMenuItem.Size = new System.Drawing.Size(128, 36);
=======
            this.printToolToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.printToolToolStripMenuItem.Text = "Print Tool";
            this.printToolToolStripMenuItem.Click += new System.EventHandler(this.printToolToolStripMenuItem_Click);
            // 
            // Tester_Type_Label
            // 
            this.Tester_Type_Label.AutoSize = true;
            this.Tester_Type_Label.Location = new System.Drawing.Point(1539, 845);
            this.Tester_Type_Label.Name = "Tester_Type_Label";
            this.Tester_Type_Label.Size = new System.Drawing.Size(126, 25);
            this.Tester_Type_Label.TabIndex = 11;
            this.Tester_Type_Label.Text = "Tester Type";
            this.Tester_Type_Label.Visible = false;
            // 
            // checkBox_millivolt
            // 
            this.checkBox_millivolt.AutoSize = true;
            this.checkBox_millivolt.Location = new System.Drawing.Point(1553, 808);
            this.checkBox_millivolt.Name = "checkBox_millivolt";
            this.checkBox_millivolt.Size = new System.Drawing.Size(231, 29);
            this.checkBox_millivolt.TabIndex = 12;
            this.checkBox_millivolt.Text = "Show Millivolts only";
            this.checkBox_millivolt.UseVisualStyleBackColor = true;
            this.checkBox_millivolt.Visible = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Torque to Spreadsheet is Active";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Torque to Spreadsheet";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(1179, 799);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 71);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select fields to send to spreadsheet";
            this.groupBox1.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Controls.Add(this.checkBox2);
            this.flowLayoutPanel1.Controls.Add(this.checkBox3);
            this.flowLayoutPanel1.Controls.Add(this.checkBox4);
            this.flowLayoutPanel1.Controls.Add(this.checkBox5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(488, 29);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 29);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(158, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(149, 29);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(313, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(149, 29);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(468, 3);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(149, 29);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "checkBox4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(623, 3);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(149, 29);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "checkBox5";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // testerType
            // 
            this.testerType.AutoSize = true;
            this.testerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testerType.Location = new System.Drawing.Point(15, 217);
            this.testerType.Name = "testerType";
            this.testerType.Size = new System.Drawing.Size(0, 44);
            this.testerType.TabIndex = 22;
            // 
            // serialPort2
            // 
            this.serialPort2.PortName = "COM2";
            // 
            // dualChannelTab
            // 
            this.dualChannelTab.Controls.Add(this.dualSeriesListView);
            this.dualChannelTab.Controls.Add(this.dualRunName2ErrorLabel);
            this.dualChannelTab.Controls.Add(this.dualRunName1ErrorLabel);
            this.dualChannelTab.Controls.Add(this.dualMasterGrid);
            this.dualChannelTab.Controls.Add(this.panel1);
            this.dualChannelTab.Controls.Add(this.dualCurrRun_Label2);
            this.dualChannelTab.Controls.Add(this.dualCurrRun_label1);
            this.dualChannelTab.Controls.Add(this.dualCh2RunName_Text);
            this.dualChannelTab.Controls.Add(this.dualCh1RunName_Text);
            this.dualChannelTab.Controls.Add(this.switchTestCalMode_button);
            this.dualChannelTab.Controls.Add(this.currRunDualSaveExcel);
            this.dualChannelTab.Controls.Add(this.addDualRun);
            this.dualChannelTab.Controls.Add(this.dualCertExport_button);
            this.dualChannelTab.Controls.Add(this.button20);
            this.dualChannelTab.Controls.Add(this.clearBothData_button);
            this.dualChannelTab.Controls.Add(this.deleteBothRow_button);
            this.dualChannelTab.Controls.Add(this.groupBox15);
            this.dualChannelTab.Controls.Add(this.defineTest);
            this.dualChannelTab.Controls.Add(this.groupBox14);
            this.dualChannelTab.Controls.Add(this.dataGridView1);
            this.dualChannelTab.Controls.Add(this.saveRun_button);
            this.dualChannelTab.Controls.Add(this.label12);
            this.dualChannelTab.Controls.Add(this.currRunDualQuickExport);
            this.dualChannelTab.Controls.Add(this.serieListBox);
            this.dualChannelTab.Controls.Add(this.button16);
            this.dualChannelTab.Controls.Add(this.save_button);
            this.dualChannelTab.Controls.Add(this.groupBox16);
            this.dualChannelTab.Controls.Add(this.groupBox11);
            this.dualChannelTab.Controls.Add(this.dualChart);
            this.dualChannelTab.Controls.Add(this.clearSecond);
            this.dualChannelTab.Controls.Add(this.deleteSecond);
            this.dualChannelTab.Controls.Add(this.secondChannelGridView);
            this.dualChannelTab.Controls.Add(this.clearFirst);
            this.dualChannelTab.Controls.Add(this.deleteLineFirst);
            this.dualChannelTab.Controls.Add(this.firstChannelGrid);
            this.dualChannelTab.Location = new System.Drawing.Point(8, 38);
            this.dualChannelTab.Name = "dualChannelTab";
<<<<<<< HEAD
            this.dualChannelTab.Size = new System.Drawing.Size(1674, 877);
=======
            this.dualChannelTab.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.dualChannelTab.TabIndex = 5;
            this.dualChannelTab.Text = "Dual Channel";
            this.dualChannelTab.UseVisualStyleBackColor = true;
            // 
            // dualSeriesListView
            // 
            this.dualSeriesListView.AutoArrange = false;
            this.dualSeriesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dualSeriesListView.CheckBoxes = true;
            this.dualSeriesListView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dualSeriesListView.GridLines = true;
            this.dualSeriesListView.HideSelection = false;
            this.dualSeriesListView.Location = new System.Drawing.Point(811, 561);
            this.dualSeriesListView.Name = "dualSeriesListView";
            this.dualSeriesListView.Size = new System.Drawing.Size(154, 240);
            this.dualSeriesListView.TabIndex = 104;
            this.dualSeriesListView.UseCompatibleStateImageBehavior = false;
            this.dualSeriesListView.View = System.Windows.Forms.View.List;
            this.dualSeriesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.dualSeriesListView_ItemChecked);
            // 
            // dualRunName2ErrorLabel
            // 
            this.dualRunName2ErrorLabel.AutoSize = true;
            this.dualRunName2ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.dualRunName2ErrorLabel.Location = new System.Drawing.Point(530, 325);
            this.dualRunName2ErrorLabel.Name = "dualRunName2ErrorLabel";
            this.dualRunName2ErrorLabel.Size = new System.Drawing.Size(0, 25);
            this.dualRunName2ErrorLabel.TabIndex = 103;
            // 
            // dualRunName1ErrorLabel
            // 
            this.dualRunName1ErrorLabel.AutoSize = true;
            this.dualRunName1ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.dualRunName1ErrorLabel.Location = new System.Drawing.Point(227, 325);
            this.dualRunName1ErrorLabel.Name = "dualRunName1ErrorLabel";
            this.dualRunName1ErrorLabel.Size = new System.Drawing.Size(0, 25);
            this.dualRunName1ErrorLabel.TabIndex = 102;
            // 
            // dualMasterGrid
            // 
            this.dualMasterGrid.AllowUserToAddRows = false;
            this.dualMasterGrid.AllowUserToDeleteRows = false;
            this.dualMasterGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dualMasterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dualMasterGrid.Location = new System.Drawing.Point(2012, 257);
            this.dualMasterGrid.Name = "dualMasterGrid";
            this.dualMasterGrid.ReadOnly = true;
            this.dualMasterGrid.Size = new System.Drawing.Size(432, 601);
            this.dualMasterGrid.TabIndex = 75;
            this.dualMasterGrid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.xySwitch_button);
            this.panel1.Location = new System.Drawing.Point(403, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(80, 47);
            this.panel1.TabIndex = 15;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(24, 5);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 29);
            this.label16.TabIndex = 87;
            this.label16.Text = "Axis";
            // 
            // xySwitch_button
            // 
            this.xySwitch_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xySwitch_button.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xySwitch_button.Location = new System.Drawing.Point(1, 23);
            this.xySwitch_button.Name = "xySwitch_button";
            this.xySwitch_button.Size = new System.Drawing.Size(78, 22);
            this.xySwitch_button.TabIndex = 1;
            this.xySwitch_button.Text = "X               Y";
            this.xySwitch_button.UseVisualStyleBackColor = true;
            this.xySwitch_button.Click += new System.EventHandler(this.xySwitch_button_Click);
            // 
            // dualCurrRun_Label2
            // 
            this.dualCurrRun_Label2.AutoSize = true;
            this.dualCurrRun_Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dualCurrRun_Label2.Location = new System.Drawing.Point(530, 346);
            this.dualCurrRun_Label2.MaximumSize = new System.Drawing.Size(190, 14);
            this.dualCurrRun_Label2.Name = "dualCurrRun_Label2";
            this.dualCurrRun_Label2.Size = new System.Drawing.Size(188, 14);
            this.dualCurrRun_Label2.TabIndex = 99;
            this.dualCurrRun_Label2.Text = "Current Run-CH2";
            // 
            // dualCurrRun_label1
            // 
            this.dualCurrRun_label1.AutoSize = true;
            this.dualCurrRun_label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dualCurrRun_label1.Location = new System.Drawing.Point(227, 346);
            this.dualCurrRun_label1.MaximumSize = new System.Drawing.Size(190, 14);
            this.dualCurrRun_label1.Name = "dualCurrRun_label1";
            this.dualCurrRun_label1.Size = new System.Drawing.Size(188, 14);
            this.dualCurrRun_label1.TabIndex = 98;
            this.dualCurrRun_label1.Text = "Current Run-CH1";
            // 
            // dualCh2RunName_Text
            // 
            this.dualCh2RunName_Text.Location = new System.Drawing.Point(730, 343);
            this.dualCh2RunName_Text.Name = "dualCh2RunName_Text";
            this.dualCh2RunName_Text.Size = new System.Drawing.Size(100, 33);
            this.dualCh2RunName_Text.TabIndex = 3;
            this.dualCh2RunName_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dualCh2RunName_Text_KeyDown);
            // 
            // dualCh1RunName_Text
            // 
            this.dualCh1RunName_Text.Location = new System.Drawing.Point(427, 343);
            this.dualCh1RunName_Text.Name = "dualCh1RunName_Text";
            this.dualCh1RunName_Text.Size = new System.Drawing.Size(100, 33);
            this.dualCh1RunName_Text.TabIndex = 2;
            this.dualCh1RunName_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dualCh1RunName_Text_KeyDown);
            // 
            // switchTestCalMode_button
            // 
            this.switchTestCalMode_button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.switchTestCalMode_button.Location = new System.Drawing.Point(1581, 478);
            this.switchTestCalMode_button.Name = "switchTestCalMode_button";
            this.switchTestCalMode_button.Size = new System.Drawing.Size(110, 23);
            this.switchTestCalMode_button.TabIndex = 95;
            this.switchTestCalMode_button.Text = "Test Mode";
            this.switchTestCalMode_button.UseVisualStyleBackColor = true;
            this.switchTestCalMode_button.Visible = false;
            this.switchTestCalMode_button.Click += new System.EventHandler(this.switchTestCalMode_button_Click);
            // 
            // currRunDualSaveExcel
            // 
            this.currRunDualSaveExcel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currRunDualSaveExcel.Location = new System.Drawing.Point(842, 355);
            this.currRunDualSaveExcel.Name = "currRunDualSaveExcel";
            this.currRunDualSaveExcel.Size = new System.Drawing.Size(117, 23);
            this.currRunDualSaveExcel.TabIndex = 5;
            this.currRunDualSaveExcel.Text = "Save As && Open";
            this.currRunDualSaveExcel.UseVisualStyleBackColor = true;
            this.currRunDualSaveExcel.Click += new System.EventHandler(this.currRunDualSaveExcel_Click);
            // 
            // addDualRun
            // 
            this.addDualRun.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDualRun.Location = new System.Drawing.Point(843, 474);
            this.addDualRun.Name = "addDualRun";
            this.addDualRun.Size = new System.Drawing.Size(119, 25);
            this.addDualRun.TabIndex = 7;
            this.addDualRun.Text = "New Run";
            this.addDualRun.UseVisualStyleBackColor = true;
            this.addDualRun.Click += new System.EventHandler(this.addDualRun_Click);
            // 
            // dualCertExport_button
            // 
            this.dualCertExport_button.Enabled = false;
            this.dualCertExport_button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dualCertExport_button.Location = new System.Drawing.Point(1612, 543);
            this.dualCertExport_button.Name = "dualCertExport_button";
            this.dualCertExport_button.Size = new System.Drawing.Size(110, 23);
            this.dualCertExport_button.TabIndex = 93;
            this.dualCertExport_button.Text = "Export to Cert";
            this.dualCertExport_button.UseVisualStyleBackColor = true;
            this.dualCertExport_button.Visible = false;
            // 
            // button20
            // 
            this.button20.Enabled = false;
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(1511, 554);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(75, 23);
            this.button20.TabIndex = 85;
            this.button20.Text = "Capture";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Visible = false;
            // 
            // clearBothData_button
            // 
            this.clearBothData_button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBothData_button.Location = new System.Drawing.Point(844, 534);
            this.clearBothData_button.Name = "clearBothData_button";
            this.clearBothData_button.Size = new System.Drawing.Size(119, 23);
            this.clearBothData_button.TabIndex = 9;
            this.clearBothData_button.Text = "Clear All Data";
            this.clearBothData_button.UseVisualStyleBackColor = true;
            this.clearBothData_button.Click += new System.EventHandler(this.clearBothData_button_Click);
            // 
            // deleteBothRow_button
            // 
            this.deleteBothRow_button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBothRow_button.Location = new System.Drawing.Point(844, 505);
            this.deleteBothRow_button.Name = "deleteBothRow_button";
            this.deleteBothRow_button.Size = new System.Drawing.Size(119, 23);
            this.deleteBothRow_button.TabIndex = 8;
            this.deleteBothRow_button.Text = "Delete Row";
            this.deleteBothRow_button.UseVisualStyleBackColor = true;
            this.deleteBothRow_button.Click += new System.EventHandler(this.deleteBothRow_button_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.unitCH2DualCHTab_lbl);
            this.groupBox15.Controls.Add(this.dataCh2DualChTab_lbl);
            this.groupBox15.Controls.Add(this.secondComConnect);
            this.groupBox15.Controls.Add(this.chan2_menuControl_button);
            this.groupBox15.Controls.Add(this.chan2_zeroControl_button);
            this.groupBox15.Controls.Add(this.chan2_modeControl_button);
            this.groupBox15.Controls.Add(this.chan2_unitControl_button);
            this.groupBox15.Location = new System.Drawing.Point(443, 13);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(519, 307);
            this.groupBox15.TabIndex = 14;
            this.groupBox15.TabStop = false;
            // 
            // unitCH2DualCHTab_lbl
            // 
            this.unitCH2DualCHTab_lbl.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCH2DualCHTab_lbl.Location = new System.Drawing.Point(52, 182);
            this.unitCH2DualCHTab_lbl.Name = "unitCH2DualCHTab_lbl";
            this.unitCH2DualCHTab_lbl.Size = new System.Drawing.Size(392, 56);
            this.unitCH2DualCHTab_lbl.TabIndex = 85;
            this.unitCH2DualCHTab_lbl.Text = "label13";
            this.unitCH2DualCHTab_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataCh2DualChTab_lbl
            // 
            this.dataCh2DualChTab_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataCh2DualChTab_lbl.AutoSize = true;
            this.dataCh2DualChTab_lbl.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCh2DualChTab_lbl.Location = new System.Drawing.Point(49, 37);
            this.dataCh2DualChTab_lbl.Name = "dataCh2DualChTab_lbl";
            this.dataCh2DualChTab_lbl.Size = new System.Drawing.Size(711, 180);
            this.dataCh2DualChTab_lbl.TabIndex = 73;
            this.dataCh2DualChTab_lbl.Text = "0.0000";
            // 
            // secondComConnect
            // 
            this.secondComConnect.AutoSize = true;
            this.secondComConnect.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondComConnect.Location = new System.Drawing.Point(49, 16);
            this.secondComConnect.Name = "secondComConnect";
            this.secondComConnect.Size = new System.Drawing.Size(288, 32);
            this.secondComConnect.TabIndex = 66;
            this.secondComConnect.Text = "No COM Port Connect";
            // 
            // chan2_menuControl_button
            // 
            this.chan2_menuControl_button.BackColor = System.Drawing.Color.Transparent;
            this.chan2_menuControl_button.Enabled = false;
            this.chan2_menuControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan2_menuControl_button.Location = new System.Drawing.Point(175, 278);
            this.chan2_menuControl_button.Name = "chan2_menuControl_button";
            this.chan2_menuControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan2_menuControl_button.TabIndex = 2;
            this.chan2_menuControl_button.Text = "Menu";
            this.chan2_menuControl_button.UseVisualStyleBackColor = false;
            this.chan2_menuControl_button.Click += new System.EventHandler(this.chan2_menuControl_button_Click);
            // 
            // chan2_zeroControl_button
            // 
            this.chan2_zeroControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan2_zeroControl_button.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chan2_zeroControl_button.Location = new System.Drawing.Point(67, 278);
            this.chan2_zeroControl_button.Name = "chan2_zeroControl_button";
            this.chan2_zeroControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan2_zeroControl_button.TabIndex = 1;
            this.chan2_zeroControl_button.Text = "Zero/Clear";
            this.chan2_zeroControl_button.UseVisualStyleBackColor = true;
            this.chan2_zeroControl_button.Click += new System.EventHandler(this.chan2_zeroControl_button_Click);
            // 
            // chan2_modeControl_button
            // 
            this.chan2_modeControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan2_modeControl_button.Location = new System.Drawing.Point(288, 278);
            this.chan2_modeControl_button.Name = "chan2_modeControl_button";
            this.chan2_modeControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan2_modeControl_button.TabIndex = 3;
            this.chan2_modeControl_button.Text = "Mode";
            this.chan2_modeControl_button.UseVisualStyleBackColor = true;
            this.chan2_modeControl_button.Click += new System.EventHandler(this.chan2_modeControl_button_Click);
            // 
            // chan2_unitControl_button
            // 
            this.chan2_unitControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan2_unitControl_button.Location = new System.Drawing.Point(399, 278);
            this.chan2_unitControl_button.Name = "chan2_unitControl_button";
            this.chan2_unitControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan2_unitControl_button.TabIndex = 4;
            this.chan2_unitControl_button.Text = "Unit";
            this.chan2_unitControl_button.UseVisualStyleBackColor = true;
            this.chan2_unitControl_button.Click += new System.EventHandler(this.chan2_unitControl_button_Click);
            // 
            // defineTest
            // 
            this.defineTest.Location = new System.Drawing.Point(1500, 478);
            this.defineTest.Name = "defineTest";
            this.defineTest.Size = new System.Drawing.Size(75, 23);
            this.defineTest.TabIndex = 76;
            this.defineTest.Text = "Define Test";
            this.defineTest.UseVisualStyleBackColor = true;
            this.defineTest.Visible = false;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label14);
            this.groupBox14.Controls.Add(this.comList4);
            this.groupBox14.Controls.Add(this.openCloseSecondPort);
            this.groupBox14.Controls.Add(this.openCloseFirstPort);
            this.groupBox14.Controls.Add(this.refresh_dualTab);
            this.groupBox14.Location = new System.Drawing.Point(8, 326);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(206, 229);
            this.groupBox14.TabIndex = 1;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Select available COM";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 25);
            this.label14.TabIndex = 65;
            this.label14.Text = "Available COM Port";
            // 
            // comList4
            // 
            this.comList4.FormattingEnabled = true;
            this.comList4.HorizontalScrollbar = true;
            this.comList4.ItemHeight = 25;
            this.comList4.Location = new System.Drawing.Point(9, 49);
            this.comList4.Name = "comList4";
<<<<<<< HEAD
            this.comList4.Size = new System.Drawing.Size(191, 29);
=======
            this.comList4.Size = new System.Drawing.Size(191, 60);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.comList4.TabIndex = 1;
            // 
            // openCloseSecondPort
            // 
            this.openCloseSecondPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCloseSecondPort.Location = new System.Drawing.Point(9, 189);
            this.openCloseSecondPort.Name = "openCloseSecondPort";
            this.openCloseSecondPort.Size = new System.Drawing.Size(191, 31);
            this.openCloseSecondPort.TabIndex = 4;
            this.openCloseSecondPort.Text = "Open/Close Channel 2";
            this.openCloseSecondPort.UseVisualStyleBackColor = true;
            this.openCloseSecondPort.Click += new System.EventHandler(this.openCloseSecondPort_Click);
            // 
            // openCloseFirstPort
            // 
            this.openCloseFirstPort.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openCloseFirstPort.Location = new System.Drawing.Point(9, 152);
            this.openCloseFirstPort.Name = "openCloseFirstPort";
            this.openCloseFirstPort.Size = new System.Drawing.Size(191, 31);
            this.openCloseFirstPort.TabIndex = 3;
            this.openCloseFirstPort.Text = "Open/Close Channel 1";
            this.openCloseFirstPort.UseVisualStyleBackColor = true;
            this.openCloseFirstPort.Click += new System.EventHandler(this.openCloseFirstPort_Click);
            // 
            // refresh_dualTab
            // 
            this.refresh_dualTab.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_dualTab.Location = new System.Drawing.Point(9, 115);
            this.refresh_dualTab.Name = "refresh_dualTab";
            this.refresh_dualTab.Size = new System.Drawing.Size(191, 31);
            this.refresh_dualTab.TabIndex = 2;
            this.refresh_dualTab.Text = "Refresh COM List";
            this.refresh_dualTab.UseVisualStyleBackColor = true;
            this.refresh_dualTab.Click += new System.EventHandler(this.refresh_dualTab_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lowLimitCol,
            this.highLimitCol,
            this.theoreticalTarget,
            this.chan1Reading,
            this.chan2Reading});
            this.dataGridView1.Location = new System.Drawing.Point(1492, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(626, 227);
            this.dataGridView1.TabIndex = 88;
            this.dataGridView1.Visible = false;
            // 
            // lowLimitCol
            // 
            this.lowLimitCol.HeaderText = "Low";
            this.lowLimitCol.Name = "lowLimitCol";
            // 
            // highLimitCol
            // 
            this.highLimitCol.HeaderText = "High";
            this.highLimitCol.Name = "highLimitCol";
            // 
            // theoreticalTarget
            // 
            this.theoreticalTarget.HeaderText = "Theoretical Target";
            this.theoreticalTarget.Name = "theoreticalTarget";
            // 
            // chan1Reading
            // 
            this.chan1Reading.HeaderText = "Channel 1";
            this.chan1Reading.Name = "chan1Reading";
            // 
            // chan2Reading
            // 
            this.chan2Reading.HeaderText = "Channel 2";
            this.chan2Reading.Name = "chan2Reading";
            // 
            // saveRun_button
            // 
            this.saveRun_button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRun_button.Location = new System.Drawing.Point(843, 445);
            this.saveRun_button.Name = "saveRun_button";
            this.saveRun_button.Size = new System.Drawing.Size(119, 23);
            this.saveRun_button.TabIndex = 6;
            this.saveRun_button.Text = "Archive Run";
            this.saveRun_button.UseVisualStyleBackColor = true;
            this.saveRun_button.Click += new System.EventHandler(this.saveRun_button_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1526, 610);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(174, 31);
            this.label12.TabIndex = 87;
            this.label12.Text = "List of all Runs:";
            this.label12.Visible = false;
            // 
            // currRunDualQuickExport
            // 
            this.currRunDualQuickExport.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currRunDualQuickExport.Location = new System.Drawing.Point(843, 326);
            this.currRunDualQuickExport.Name = "currRunDualQuickExport";
            this.currRunDualQuickExport.Size = new System.Drawing.Size(117, 23);
            this.currRunDualQuickExport.TabIndex = 4;
            this.currRunDualQuickExport.Text = "Save && Open";
            this.currRunDualQuickExport.UseVisualStyleBackColor = true;
            this.currRunDualQuickExport.Click += new System.EventHandler(this.currRunDualQuickExport_Click);
            // 
            // serieListBox
            // 
            this.serieListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serieListBox.CheckOnClick = true;
            this.serieListBox.FormattingEnabled = true;
            this.serieListBox.Location = new System.Drawing.Point(1526, 629);
            this.serieListBox.Name = "serieListBox";
            this.serieListBox.ScrollAlwaysVisible = true;
<<<<<<< HEAD
            this.serieListBox.Size = new System.Drawing.Size(111, 112);
=======
            this.serieListBox.Size = new System.Drawing.Size(111, 105);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.serieListBox.TabIndex = 83;
            this.serieListBox.Visible = false;
            this.serieListBox.SelectedIndexChanged += new System.EventHandler(this.serieListBox_SelectedIndexChanged);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(1492, 308);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(110, 23);
            this.button16.TabIndex = 85;
            this.button16.Text = "Save Current Run";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Visible = false;
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_button.Location = new System.Drawing.Point(1495, 401);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(110, 52);
            this.save_button.TabIndex = 78;
            this.save_button.Text = "Save and Open Excel";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Visible = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.noCurrDualMasterGrid);
            this.groupBox16.Controls.Add(this.test_save_button);
            this.groupBox16.Controls.Add(this.dualTestName_Text);
            this.groupBox16.Controls.Add(this.label21);
            this.groupBox16.Controls.Add(this.quickDualExport_button);
            this.groupBox16.Controls.Add(this.renameDualRun);
            this.groupBox16.Controls.Add(this.deleteDualRun_Button);
            this.groupBox16.Location = new System.Drawing.Point(968, 13);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(444, 722);
            this.groupBox16.TabIndex = 15;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Recent Runs";
            // 
            // noCurrDualMasterGrid
            // 
            this.noCurrDualMasterGrid.AllowUserToAddRows = false;
            this.noCurrDualMasterGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.noCurrDualMasterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.noCurrDualMasterGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.noCurrDualMasterGrid.Location = new System.Drawing.Point(3, 51);
            this.noCurrDualMasterGrid.Name = "noCurrDualMasterGrid";
            this.noCurrDualMasterGrid.Size = new System.Drawing.Size(438, 621);
            this.noCurrDualMasterGrid.TabIndex = 19;
            // 
            // test_save_button
            // 
            this.test_save_button.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.test_save_button.Location = new System.Drawing.Point(311, 24);
            this.test_save_button.Name = "test_save_button";
            this.test_save_button.Size = new System.Drawing.Size(125, 24);
            this.test_save_button.TabIndex = 18;
            this.test_save_button.Text = "Save As && Open";
            this.test_save_button.UseVisualStyleBackColor = true;
            this.test_save_button.Click += new System.EventHandler(this.test_save_button_Click);
            // 
            // dualTestName_Text
            // 
            this.dualTestName_Text.Location = new System.Drawing.Point(103, 24);
            this.dualTestName_Text.Name = "dualTestName_Text";
            this.dualTestName_Text.Size = new System.Drawing.Size(100, 33);
            this.dualTestName_Text.TabIndex = 16;
            this.dualTestName_Text.TextChanged += new System.EventHandler(this.dualTestName_Text_TextChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(129, 25);
            this.label21.TabIndex = 81;
            this.label21.Text = "Current Test";
            // 
            // quickDualExport_button
            // 
            this.quickDualExport_button.Enabled = false;
            this.quickDualExport_button.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickDualExport_button.Location = new System.Drawing.Point(212, 24);
            this.quickDualExport_button.Name = "quickDualExport_button";
            this.quickDualExport_button.Size = new System.Drawing.Size(93, 24);
            this.quickDualExport_button.TabIndex = 17;
            this.quickDualExport_button.Text = "Save && Open";
            this.quickDualExport_button.UseVisualStyleBackColor = true;
            this.quickDualExport_button.Click += new System.EventHandler(this.quickDualExport_button_Click);
            // 
            // renameDualRun
            // 
            this.renameDualRun.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.renameDualRun.Location = new System.Drawing.Point(91, 678);
            this.renameDualRun.Name = "renameDualRun";
            this.renameDualRun.Size = new System.Drawing.Size(110, 35);
            this.renameDualRun.TabIndex = 20;
            this.renameDualRun.Text = "Rename Run";
            this.renameDualRun.UseVisualStyleBackColor = true;
            this.renameDualRun.Click += new System.EventHandler(this.renameDualRun_Click);
            // 
            // deleteDualRun_Button
            // 
            this.deleteDualRun_Button.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteDualRun_Button.Location = new System.Drawing.Point(243, 678);
            this.deleteDualRun_Button.Name = "deleteDualRun_Button";
            this.deleteDualRun_Button.Size = new System.Drawing.Size(110, 35);
            this.deleteDualRun_Button.TabIndex = 21;
            this.deleteDualRun_Button.Text = "Delete Run";
            this.deleteDualRun_Button.UseVisualStyleBackColor = true;
            this.deleteDualRun_Button.Click += new System.EventHandler(this.deleteDualRun_Button_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.unitCH1DualCHTab_lbl);
            this.groupBox11.Controls.Add(this.chan1_captureControl_button);
            this.groupBox11.Controls.Add(this.chann1_zeroControl_button);
            this.groupBox11.Controls.Add(this.chan1_unitControl_button);
            this.groupBox11.Controls.Add(this.chan1_modeControl_button);
            this.groupBox11.Controls.Add(this.chan1_menuControl_button);
            this.groupBox11.Controls.Add(this.dataCh1DualChanTab_lbl);
            this.groupBox11.Controls.Add(this.firstComConnect);
            this.groupBox11.Location = new System.Drawing.Point(8, 13);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(435, 307);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            // 
            // unitCH1DualCHTab_lbl
            // 
            this.unitCH1DualCHTab_lbl.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitCH1DualCHTab_lbl.Location = new System.Drawing.Point(3, 182);
            this.unitCH1DualCHTab_lbl.Name = "unitCH1DualCHTab_lbl";
            this.unitCH1DualCHTab_lbl.Size = new System.Drawing.Size(392, 56);
            this.unitCH1DualCHTab_lbl.TabIndex = 81;
            this.unitCH1DualCHTab_lbl.Text = "label13";
            this.unitCH1DualCHTab_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chan1_captureControl_button
            // 
            this.chan1_captureControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan1_captureControl_button.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chan1_captureControl_button.Location = new System.Drawing.Point(340, 241);
            this.chan1_captureControl_button.Name = "chan1_captureControl_button";
            this.chan1_captureControl_button.Size = new System.Drawing.Size(95, 42);
            this.chan1_captureControl_button.TabIndex = 5;
            this.chan1_captureControl_button.Text = "Capture";
            this.chan1_captureControl_button.UseVisualStyleBackColor = true;
            this.chan1_captureControl_button.Click += new System.EventHandler(this.chan1_captureControl_button_Click);
            // 
            // chann1_zeroControl_button
            // 
            this.chann1_zeroControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chann1_zeroControl_button.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chann1_zeroControl_button.Location = new System.Drawing.Point(3, 242);
            this.chann1_zeroControl_button.Name = "chann1_zeroControl_button";
            this.chann1_zeroControl_button.Size = new System.Drawing.Size(95, 42);
            this.chann1_zeroControl_button.TabIndex = 1;
            this.chann1_zeroControl_button.Text = "Zero/Clear";
            this.chann1_zeroControl_button.UseVisualStyleBackColor = true;
            this.chann1_zeroControl_button.Click += new System.EventHandler(this.chann1_zeroControl_button_Click);
            // 
            // chan1_unitControl_button
            // 
            this.chan1_unitControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan1_unitControl_button.Location = new System.Drawing.Point(263, 278);
            this.chan1_unitControl_button.Name = "chan1_unitControl_button";
            this.chan1_unitControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan1_unitControl_button.TabIndex = 4;
            this.chan1_unitControl_button.Text = "Unit";
            this.chan1_unitControl_button.UseVisualStyleBackColor = true;
            this.chan1_unitControl_button.Click += new System.EventHandler(this.chan1_unitControl_button_Click);
            // 
            // chan1_modeControl_button
            // 
            this.chan1_modeControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan1_modeControl_button.Location = new System.Drawing.Point(181, 278);
            this.chan1_modeControl_button.Name = "chan1_modeControl_button";
            this.chan1_modeControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan1_modeControl_button.TabIndex = 3;
            this.chan1_modeControl_button.Text = "Mode";
            this.chan1_modeControl_button.UseVisualStyleBackColor = true;
            this.chan1_modeControl_button.Click += new System.EventHandler(this.chan1_modeControl_button_Click);
            // 
            // chan1_menuControl_button
            // 
            this.chan1_menuControl_button.BackColor = System.Drawing.Color.Transparent;
            this.chan1_menuControl_button.Enabled = false;
            this.chan1_menuControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chan1_menuControl_button.Location = new System.Drawing.Point(100, 278);
            this.chan1_menuControl_button.Name = "chan1_menuControl_button";
            this.chan1_menuControl_button.Size = new System.Drawing.Size(75, 23);
            this.chan1_menuControl_button.TabIndex = 2;
            this.chan1_menuControl_button.Text = "Menu";
            this.chan1_menuControl_button.UseVisualStyleBackColor = false;
            this.chan1_menuControl_button.Click += new System.EventHandler(this.chan1_menuControl_button_Click);
            // 
            // dataCh1DualChanTab_lbl
            // 
            this.dataCh1DualChanTab_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dataCh1DualChanTab_lbl.AutoSize = true;
            this.dataCh1DualChanTab_lbl.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataCh1DualChanTab_lbl.Location = new System.Drawing.Point(0, 37);
            this.dataCh1DualChanTab_lbl.Name = "dataCh1DualChanTab_lbl";
            this.dataCh1DualChanTab_lbl.Size = new System.Drawing.Size(711, 180);
            this.dataCh1DualChanTab_lbl.TabIndex = 75;
            this.dataCh1DualChanTab_lbl.Text = "0.0000";
            // 
            // firstComConnect
            // 
            this.firstComConnect.AutoSize = true;
            this.firstComConnect.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstComConnect.Location = new System.Drawing.Point(0, 16);
            this.firstComConnect.Name = "firstComConnect";
            this.firstComConnect.Size = new System.Drawing.Size(288, 32);
            this.firstComConnect.TabIndex = 65;
            this.firstComConnect.Text = "No COM Port Connect";
            // 
            // dualChart
            // 
            chartArea4.Name = "ChartArea1";
            this.dualChart.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.dualChart.Legends.Add(legend4);
            this.dualChart.Location = new System.Drawing.Point(8, 561);
            this.dualChart.Name = "dualChart";
            this.dualChart.Size = new System.Drawing.Size(798, 219);
            this.dualChart.TabIndex = 74;
            this.dualChart.Text = "chart3";
            // 
            // clearSecond
            // 
            this.clearSecond.Location = new System.Drawing.Point(1931, 511);
            this.clearSecond.Name = "clearSecond";
            this.clearSecond.Size = new System.Drawing.Size(75, 23);
            this.clearSecond.TabIndex = 72;
            this.clearSecond.Text = "Clear Data";
            this.clearSecond.UseVisualStyleBackColor = true;
            this.clearSecond.Visible = false;
            this.clearSecond.Click += new System.EventHandler(this.clearSecond_Click);
            // 
            // deleteSecond
            // 
            this.deleteSecond.Location = new System.Drawing.Point(1837, 511);
            this.deleteSecond.Name = "deleteSecond";
            this.deleteSecond.Size = new System.Drawing.Size(75, 23);
            this.deleteSecond.TabIndex = 71;
            this.deleteSecond.Text = "Delete Line";
            this.deleteSecond.UseVisualStyleBackColor = true;
            this.deleteSecond.Visible = false;
            this.deleteSecond.Click += new System.EventHandler(this.deleteSecond_Click);
            // 
            // secondChannelGridView
            // 
            this.secondChannelGridView.AllowUserToResizeRows = false;
            this.secondChannelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.secondChannelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.secondChannelGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.secondChannelGridView.Location = new System.Drawing.Point(533, 367);
            this.secondChannelGridView.MultiSelect = false;
            this.secondChannelGridView.Name = "secondChannelGridView";
            this.secondChannelGridView.RowHeadersVisible = false;
            this.secondChannelGridView.Size = new System.Drawing.Size(297, 190);
            this.secondChannelGridView.TabIndex = 12;
            this.secondChannelGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.secondChannelGridView_CellEndEdit);
            // 
            // clearFirst
            // 
            this.clearFirst.Location = new System.Drawing.Point(1612, 514);
            this.clearFirst.Name = "clearFirst";
            this.clearFirst.Size = new System.Drawing.Size(75, 23);
            this.clearFirst.TabIndex = 69;
            this.clearFirst.Text = "Clear Data";
            this.clearFirst.UseVisualStyleBackColor = true;
            this.clearFirst.Visible = false;
            this.clearFirst.Click += new System.EventHandler(this.clearFirst_Click);
            // 
            // deleteLineFirst
            // 
            this.deleteLineFirst.Location = new System.Drawing.Point(1500, 514);
            this.deleteLineFirst.Name = "deleteLineFirst";
            this.deleteLineFirst.Size = new System.Drawing.Size(75, 23);
            this.deleteLineFirst.TabIndex = 68;
            this.deleteLineFirst.Text = "Delete Line";
            this.deleteLineFirst.UseVisualStyleBackColor = true;
            this.deleteLineFirst.Visible = false;
            this.deleteLineFirst.Click += new System.EventHandler(this.deleteLineFirst_Click);
            // 
            // firstChannelGrid
            // 
            this.firstChannelGrid.AllowUserToDeleteRows = false;
            this.firstChannelGrid.AllowUserToResizeRows = false;
            this.firstChannelGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.firstChannelGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.firstChannelGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.firstChannelGrid.Location = new System.Drawing.Point(230, 367);
            this.firstChannelGrid.MultiSelect = false;
            this.firstChannelGrid.Name = "firstChannelGrid";
            this.firstChannelGrid.Size = new System.Drawing.Size(297, 190);
            this.firstChannelGrid.TabIndex = 11;
            this.firstChannelGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.firstChannelGrid_CellContentClick);
            this.firstChannelGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.firstChannelGrid_CellEndEdit);
            this.firstChannelGrid.SelectionChanged += new System.EventHandler(this.firstChannelGridSelect);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Sample#";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Reading";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Unit";
            this.Column3.Name = "Column3";
            // 
            // big_graph
            // 
            this.big_graph.Controls.Add(this.Label_Data3);
            this.big_graph.Controls.Add(this.chart1);
            this.big_graph.Location = new System.Drawing.Point(8, 38);
            this.big_graph.Name = "big_graph";
<<<<<<< HEAD
            this.big_graph.Size = new System.Drawing.Size(1674, 877);
=======
            this.big_graph.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.big_graph.TabIndex = 3;
            this.big_graph.Text = "Big Reading with Graph";
            this.big_graph.UseVisualStyleBackColor = true;
            // 
            // Label_Data3
            // 
            this.Label_Data3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_Data3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label_Data3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Data3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_Data3.Font = new System.Drawing.Font("OCR A Extended", 170.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Data3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Label_Data3.Location = new System.Drawing.Point(0, 0);
            this.Label_Data3.Name = "Label_Data3";
<<<<<<< HEAD
            this.Label_Data3.Size = new System.Drawing.Size(1674, 424);
=======
            this.Label_Data3.Size = new System.Drawing.Size(1723, 699);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.Label_Data3.TabIndex = 26;
            this.Label_Data3.Text = "0.0000";
            this.Label_Data3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            chartArea5.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
<<<<<<< HEAD
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(0, 424);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1674, 453);
=======
            legend5.Name = "Legend1";
            this.chart1.Legends.Add(legend5);
            this.chart1.Location = new System.Drawing.Point(0, 699);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1723, 453);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.chart1.TabIndex = 25;
            this.chart1.Text = "chart1";
            // 
            // read_graph_col
            // 
            this.read_graph_col.Controls.Add(this.singleSeriesListView);
            this.read_graph_col.Controls.Add(this.button10);
            this.read_graph_col.Controls.Add(this.masterGridView);
            this.read_graph_col.Controls.Add(this.command_text);
            this.read_graph_col.Controls.Add(this.groupBox10);
            this.read_graph_col.Controls.Add(this.test_label);
            this.read_graph_col.Controls.Add(this.singleChart);
            this.read_graph_col.Controls.Add(this.groupBox9);
            this.read_graph_col.Controls.Add(this.groupBox8);
            this.read_graph_col.Controls.Add(this.groupBox7);
            this.read_graph_col.Controls.Add(this.groupBox4);
            this.read_graph_col.Controls.Add(this.label8);
            this.read_graph_col.Controls.Add(this.groupBox3);
            this.read_graph_col.Location = new System.Drawing.Point(8, 38);
            this.read_graph_col.Name = "read_graph_col";
<<<<<<< HEAD
            this.read_graph_col.Size = new System.Drawing.Size(1674, 877);
=======
            this.read_graph_col.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.read_graph_col.TabIndex = 4;
            this.read_graph_col.Text = "Single Channel";
            this.read_graph_col.UseVisualStyleBackColor = true;
            // 
            // singleSeriesListView
            // 
            this.singleSeriesListView.AutoArrange = false;
            this.singleSeriesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.singleSeriesListView.CheckBoxes = true;
            this.singleSeriesListView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleSeriesListView.GridLines = true;
            this.singleSeriesListView.HideSelection = false;
            this.singleSeriesListView.Location = new System.Drawing.Point(808, 521);
            this.singleSeriesListView.Name = "singleSeriesListView";
            this.singleSeriesListView.Size = new System.Drawing.Size(154, 214);
            this.singleSeriesListView.TabIndex = 105;
            this.singleSeriesListView.UseCompatibleStateImageBehavior = false;
            this.singleSeriesListView.View = System.Windows.Forms.View.List;
            this.singleSeriesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.singleSeriesListView_ItemChecked);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(1811, 741);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 58;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // masterGridView
            // 
            this.masterGridView.AllowUserToAddRows = false;
            this.masterGridView.AllowUserToDeleteRows = false;
            this.masterGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.masterGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterGridView.Location = new System.Drawing.Point(1713, 67);
            this.masterGridView.Name = "masterGridView";
            this.masterGridView.ReadOnly = true;
            this.masterGridView.Size = new System.Drawing.Size(411, 601);
            this.masterGridView.TabIndex = 20;
            this.masterGridView.Visible = false;
            // 
            // command_text
            // 
            this.command_text.Location = new System.Drawing.Point(1683, 770);
            this.command_text.Name = "command_text";
            this.command_text.Size = new System.Drawing.Size(100, 33);
            this.command_text.TabIndex = 62;
            this.command_text.Visible = false;
            this.command_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.command_text_KeyDown);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.masterGrid_noCurrent);
            this.groupBox10.Controls.Add(this.masterSave);
            this.groupBox10.Controls.Add(this.masterQuickExport);
            this.groupBox10.Controls.Add(this.rename_col);
            this.groupBox10.Controls.Add(this.delete_column);
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.testName_Text);
            this.groupBox10.Location = new System.Drawing.Point(999, 13);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(444, 722);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Recent Runs";
            // 
            // masterGrid_noCurrent
            // 
            this.masterGrid_noCurrent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.masterGrid_noCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.masterGrid_noCurrent.Location = new System.Drawing.Point(0, 54);
            this.masterGrid_noCurrent.Name = "masterGrid_noCurrent";
            this.masterGrid_noCurrent.Size = new System.Drawing.Size(438, 621);
            this.masterGrid_noCurrent.TabIndex = 4;
            // 
            // masterSave
            // 
            this.masterSave.Font = new System.Drawing.Font("Arial", 7F);
            this.masterSave.Location = new System.Drawing.Point(311, 24);
            this.masterSave.Name = "masterSave";
            this.masterSave.Size = new System.Drawing.Size(125, 24);
            this.masterSave.TabIndex = 3;
            this.masterSave.Text = "Save As && Open";
            this.masterSave.UseVisualStyleBackColor = true;
            this.masterSave.Click += new System.EventHandler(this.masterSave_Click);
            // 
            // masterQuickExport
            // 
            this.masterQuickExport.Enabled = false;
            this.masterQuickExport.Font = new System.Drawing.Font("Arial", 7F);
            this.masterQuickExport.Location = new System.Drawing.Point(212, 24);
            this.masterQuickExport.Name = "masterQuickExport";
            this.masterQuickExport.Size = new System.Drawing.Size(93, 24);
            this.masterQuickExport.TabIndex = 2;
            this.masterQuickExport.Text = "Save && Open";
            this.masterQuickExport.UseVisualStyleBackColor = true;
            this.masterQuickExport.Click += new System.EventHandler(this.masterQuickExport_Click);
            // 
            // rename_col
            // 
            this.rename_col.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rename_col.Location = new System.Drawing.Point(93, 681);
            this.rename_col.Name = "rename_col";
            this.rename_col.Size = new System.Drawing.Size(110, 35);
            this.rename_col.TabIndex = 5;
            this.rename_col.Text = "Rename Run";
            this.rename_col.UseVisualStyleBackColor = true;
            this.rename_col.Click += new System.EventHandler(this.rename_col_Click);
            // 
            // delete_column
            // 
            this.delete_column.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete_column.Location = new System.Drawing.Point(275, 681);
            this.delete_column.Name = "delete_column";
            this.delete_column.Size = new System.Drawing.Size(110, 35);
            this.delete_column.TabIndex = 6;
            this.delete_column.Text = "Delete Run";
            this.delete_column.UseVisualStyleBackColor = true;
            this.delete_column.Click += new System.EventHandler(this.delete_column_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 58;
            this.label4.Text = "Current Test";
            // 
            // testName_Text
            // 
            this.testName_Text.Location = new System.Drawing.Point(103, 24);
            this.testName_Text.Name = "testName_Text";
            this.testName_Text.Size = new System.Drawing.Size(100, 33);
            this.testName_Text.TabIndex = 1;
            this.testName_Text.TextChanged += new System.EventHandler(this.testName_Text_TextChanged);
            // 
            // test_label
            // 
            this.test_label.Location = new System.Drawing.Point(1806, 770);
            this.test_label.Name = "test_label";
            this.test_label.Size = new System.Drawing.Size(100, 33);
            this.test_label.TabIndex = 61;
            this.test_label.Visible = false;
            // 
            // singleChart
            // 
            chartArea6.Name = "ChartArea1";
            this.singleChart.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.singleChart.Legends.Add(legend6);
            this.singleChart.Location = new System.Drawing.Point(8, 516);
            this.singleChart.Name = "singleChart";
            this.singleChart.Size = new System.Drawing.Size(794, 219);
            this.singleChart.TabIndex = 55;
            this.singleChart.Text = "chart2";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.button11);
            this.groupBox9.Controls.Add(this.numericUpDown2);
            this.groupBox9.Controls.Add(this.checkBox7);
            this.groupBox9.Controls.Add(this.button9);
            this.groupBox9.Location = new System.Drawing.Point(2049, 21);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(231, 189);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Spreadsheet Mode Setting";
            this.groupBox9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 31);
            this.label10.TabIndex = 44;
            this.label10.Text = "Readings Per Row";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(18, 118);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(180, 27);
            this.button11.TabIndex = 3;
            this.button11.Text = "Start New Row";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(18, 81);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 33);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox7.Location = new System.Drawing.Point(96, 81);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(173, 29);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Text = "Reading Only";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(18, 151);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(180, 27);
            this.button9.TabIndex = 4;
            this.button9.Text = "Activate Spreadsheet Transfer";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.unitSingleCH_lbl);
            this.groupBox8.Controls.Add(this.enterControl_button);
            this.groupBox8.Controls.Add(this.zeroControl_button);
            this.groupBox8.Controls.Add(this.unitControl_button);
            this.groupBox8.Controls.Add(this.modeControl_button);
            this.groupBox8.Controls.Add(this.menuControl_button);
            this.groupBox8.Controls.Add(this.COMconnect);
            this.groupBox8.Controls.Add(this.DataSMDSingle_lbl);
            this.groupBox8.Location = new System.Drawing.Point(8, 13);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(435, 307);
            this.groupBox8.TabIndex = 54;
            this.groupBox8.TabStop = false;
            // 
            // unitSingleCH_lbl
            // 
            this.unitSingleCH_lbl.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitSingleCH_lbl.Location = new System.Drawing.Point(3, 182);
            this.unitSingleCH_lbl.Name = "unitSingleCH_lbl";
            this.unitSingleCH_lbl.Size = new System.Drawing.Size(392, 56);
            this.unitSingleCH_lbl.TabIndex = 64;
            this.unitSingleCH_lbl.Text = "label13";
            this.unitSingleCH_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // enterControl_button
            // 
            this.enterControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.enterControl_button.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterControl_button.Location = new System.Drawing.Point(340, 241);
            this.enterControl_button.Name = "enterControl_button";
            this.enterControl_button.Size = new System.Drawing.Size(95, 42);
            this.enterControl_button.TabIndex = 5;
            this.enterControl_button.Text = "Capture";
            this.enterControl_button.UseVisualStyleBackColor = true;
            this.enterControl_button.Click += new System.EventHandler(this.enterControl_button_Click);
            // 
            // zeroControl_button
            // 
            this.zeroControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.zeroControl_button.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroControl_button.Location = new System.Drawing.Point(3, 242);
            this.zeroControl_button.Name = "zeroControl_button";
            this.zeroControl_button.Size = new System.Drawing.Size(95, 42);
            this.zeroControl_button.TabIndex = 1;
            this.zeroControl_button.Text = "Zero/Clear";
            this.zeroControl_button.UseVisualStyleBackColor = true;
            this.zeroControl_button.Click += new System.EventHandler(this.zeroControl_button_Click);
            // 
            // unitControl_button
            // 
            this.unitControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.unitControl_button.Location = new System.Drawing.Point(263, 278);
            this.unitControl_button.Name = "unitControl_button";
            this.unitControl_button.Size = new System.Drawing.Size(75, 23);
            this.unitControl_button.TabIndex = 4;
            this.unitControl_button.Text = "Unit";
            this.unitControl_button.UseVisualStyleBackColor = true;
            this.unitControl_button.Click += new System.EventHandler(this.unitControl_button_Click);
            // 
            // modeControl_button
            // 
            this.modeControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.modeControl_button.Location = new System.Drawing.Point(181, 278);
            this.modeControl_button.Name = "modeControl_button";
            this.modeControl_button.Size = new System.Drawing.Size(75, 23);
            this.modeControl_button.TabIndex = 3;
            this.modeControl_button.Text = "Mode";
            this.modeControl_button.UseVisualStyleBackColor = true;
            this.modeControl_button.Click += new System.EventHandler(this.modeControl_button_Click);
            // 
            // menuControl_button
            // 
            this.menuControl_button.BackColor = System.Drawing.Color.Transparent;
            this.menuControl_button.Enabled = false;
            this.menuControl_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.menuControl_button.Location = new System.Drawing.Point(100, 278);
            this.menuControl_button.Name = "menuControl_button";
            this.menuControl_button.Size = new System.Drawing.Size(75, 23);
            this.menuControl_button.TabIndex = 2;
            this.menuControl_button.Text = "Menu";
            this.menuControl_button.UseVisualStyleBackColor = false;
            this.menuControl_button.Click += new System.EventHandler(this.menuControl_button_Click);
            // 
            // COMconnect
            // 
            this.COMconnect.AutoSize = true;
            this.COMconnect.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMconnect.Location = new System.Drawing.Point(0, 16);
            this.COMconnect.Name = "COMconnect";
            this.COMconnect.Size = new System.Drawing.Size(288, 32);
            this.COMconnect.TabIndex = 41;
            this.COMconnect.Text = "No COM Port Connect";
            // 
            // DataSMDSingle_lbl
            // 
            this.DataSMDSingle_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DataSMDSingle_lbl.AutoSize = true;
            this.DataSMDSingle_lbl.BackColor = System.Drawing.Color.Transparent;
            this.DataSMDSingle_lbl.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataSMDSingle_lbl.Location = new System.Drawing.Point(0, 37);
            this.DataSMDSingle_lbl.Name = "DataSMDSingle_lbl";
            this.DataSMDSingle_lbl.Size = new System.Drawing.Size(711, 180);
            this.DataSMDSingle_lbl.TabIndex = 40;
            this.DataSMDSingle_lbl.Text = "0.0000";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.comList3);
            this.groupBox7.Controls.Add(this.refresh2);
            this.groupBox7.Controls.Add(this.chan1ConnectButton);
            this.groupBox7.Location = new System.Drawing.Point(8, 326);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(206, 189);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select available COM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 25);
            this.label9.TabIndex = 48;
            this.label9.Text = "Available COM Port";
            // 
            // comList3
            // 
            this.comList3.FormattingEnabled = true;
            this.comList3.HorizontalScrollbar = true;
            this.comList3.ItemHeight = 25;
            this.comList3.Location = new System.Drawing.Point(9, 49);
            this.comList3.Name = "comList3";
<<<<<<< HEAD
            this.comList3.Size = new System.Drawing.Size(191, 29);
=======
            this.comList3.Size = new System.Drawing.Size(191, 60);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.comList3.TabIndex = 5;
            // 
            // refresh2
            // 
            this.refresh2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh2.Location = new System.Drawing.Point(9, 115);
            this.refresh2.Name = "refresh2";
            this.refresh2.Size = new System.Drawing.Size(191, 31);
            this.refresh2.TabIndex = 6;
            this.refresh2.Text = "Refresh COM List";
            this.refresh2.UseVisualStyleBackColor = true;
            this.refresh2.Click += new System.EventHandler(this.refresh2_Click);
            // 
            // chan1ConnectButton
            // 
            this.chan1ConnectButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chan1ConnectButton.Location = new System.Drawing.Point(9, 152);
            this.chan1ConnectButton.Name = "chan1ConnectButton";
            this.chan1ConnectButton.Size = new System.Drawing.Size(191, 31);
            this.chan1ConnectButton.TabIndex = 7;
            this.chan1ConnectButton.Text = "Open/Close Channel 1";
            this.chan1ConnectButton.UseVisualStyleBackColor = true;
            this.chan1ConnectButton.Click += new System.EventHandler(this.chan1ConnectButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.target);
            this.groupBox4.Controls.Add(this.clear_limit);
            this.groupBox4.Controls.Add(this.draw_limit);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.dsad);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(220, 326);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(223, 189);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Define Target and Limits";
            // 
            // target
            // 
            this.target.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.target.Location = new System.Drawing.Point(55, 35);
            this.target.Name = "target";
            this.target.Size = new System.Drawing.Size(46, 44);
            this.target.TabIndex = 8;
            this.target.TextChanged += new System.EventHandler(this.target_TextChanged);
            this.target.KeyDown += new System.Windows.Forms.KeyEventHandler(this.target_KeyDown);
            // 
            // clear_limit
            // 
            this.clear_limit.Location = new System.Drawing.Point(107, 54);
            this.clear_limit.Name = "clear_limit";
            this.clear_limit.Size = new System.Drawing.Size(105, 23);
            this.clear_limit.TabIndex = 14;
            this.clear_limit.Text = "Clear Limit";
            this.clear_limit.UseVisualStyleBackColor = true;
            this.clear_limit.Click += new System.EventHandler(this.clear_limit_Click);
            // 
            // draw_limit
            // 
            this.draw_limit.Location = new System.Drawing.Point(107, 20);
            this.draw_limit.Name = "draw_limit";
            this.draw_limit.Size = new System.Drawing.Size(105, 23);
            this.draw_limit.TabIndex = 13;
            this.draw_limit.Text = "Draw Limit";
            this.draw_limit.UseVisualStyleBackColor = true;
            this.draw_limit.Click += new System.EventHandler(this.draw_limit_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.low_limit);
            this.groupBox6.Controls.Add(this.low_unit);
            this.groupBox6.Controls.Add(this.low_percent);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Location = new System.Drawing.Point(6, 83);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(105, 100);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Low Limit";
            // 
            // low_limit
            // 
            this.low_limit.Location = new System.Drawing.Point(43, 19);
            this.low_limit.Name = "low_limit";
            this.low_limit.Size = new System.Drawing.Size(52, 33);
            this.low_limit.TabIndex = 11;
            this.low_limit.TextChanged += new System.EventHandler(this.low_limit_TextChanged);
            this.low_limit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.low_limit_KeyDown);
            // 
            // low_unit
            // 
            this.low_unit.AutoSize = true;
            this.low_unit.Location = new System.Drawing.Point(7, 45);
            this.low_unit.Name = "low_unit";
            this.low_unit.Size = new System.Drawing.Size(124, 29);
            this.low_unit.TabIndex = 12;
            this.low_unit.TabStop = true;
            this.low_unit.Text = "LL Value";
            this.low_unit.UseVisualStyleBackColor = true;
            // 
            // low_percent
            // 
            this.low_percent.AutoSize = true;
            this.low_percent.Location = new System.Drawing.Point(7, 61);
            this.low_percent.Name = "low_percent";
            this.low_percent.Size = new System.Drawing.Size(63, 29);
            this.low_percent.TabIndex = 12;
            this.low_percent.TabStop = true;
            this.low_percent.Text = "%";
            this.low_percent.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Low*";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.high_limit);
            this.groupBox5.Controls.Add(this.high_unit);
            this.groupBox5.Controls.Add(this.high_percent);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Location = new System.Drawing.Point(115, 83);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(106, 100);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "High Limit";
            // 
            // high_limit
            // 
            this.high_limit.Location = new System.Drawing.Point(45, 16);
            this.high_limit.Name = "high_limit";
            this.high_limit.Size = new System.Drawing.Size(52, 33);
            this.high_limit.TabIndex = 9;
            this.high_limit.TextChanged += new System.EventHandler(this.high_limit_TextChanged);
            this.high_limit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.high_limit_KeyDown);
            // 
            // high_unit
            // 
            this.high_unit.AutoSize = true;
            this.high_unit.Location = new System.Drawing.Point(9, 42);
            this.high_unit.Name = "high_unit";
            this.high_unit.Size = new System.Drawing.Size(128, 29);
            this.high_unit.TabIndex = 10;
            this.high_unit.TabStop = true;
            this.high_unit.Text = "UL Value";
            this.high_unit.UseVisualStyleBackColor = true;
            // 
            // high_percent
            // 
            this.high_percent.AutoSize = true;
            this.high_percent.Location = new System.Drawing.Point(9, 58);
            this.high_percent.Name = "high_percent";
            this.high_percent.Size = new System.Drawing.Size(63, 29);
            this.high_percent.TabIndex = 10;
            this.high_percent.TabStop = true;
            this.high_percent.Text = "%";
            this.high_percent.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "High*";
            // 
            // dsad
            // 
            this.dsad.AutoSize = true;
            this.dsad.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dsad.Location = new System.Drawing.Point(3, 41);
            this.dsad.Name = "dsad";
            this.dsad.Size = new System.Drawing.Size(87, 27);
            this.dsad.TabIndex = 0;
            this.dsad.Text = "Target*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2075, 372);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 44);
            this.label8.TabIndex = 41;
            this.label8.Text = "No Units";
            this.label8.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.notNumberWarning_lbl);
            this.groupBox3.Controls.Add(this.useLimit_chkbox);
            this.groupBox3.Controls.Add(this.label46);
            this.groupBox3.Controls.Add(this.toolID_SC_comboBox);
            this.groupBox3.Controls.Add(this.average_lbl);
            this.groupBox3.Controls.Add(this.label47);
            this.groupBox3.Controls.Add(this.label43);
            this.groupBox3.Controls.Add(this.label33);
            this.groupBox3.Controls.Add(this.USL_txt);
            this.groupBox3.Controls.Add(this.LSL_txt);
            this.groupBox3.Controls.Add(this.showCMK_chkBox);
            this.groupBox3.Controls.Add(this.CMKVal_lbl);
            this.groupBox3.Controls.Add(this.CMK_lbl);
            this.groupBox3.Controls.Add(this.CMVal_lbl);
            this.groupBox3.Controls.Add(this.CM_lbl);
            this.groupBox3.Controls.Add(this.runNameErrorLabel);
            this.groupBox3.Controls.Add(this.currentRunText);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.saveCurrent_button);
            this.groupBox3.Controls.Add(this.add_serie);
            this.groupBox3.Controls.Add(this.clearCh1CurrRun_btn);
            this.groupBox3.Controls.Add(this.saveCurrRun_1chann_button);
            this.groupBox3.Controls.Add(this.quickExport);
            this.groupBox3.Controls.Add(this.deleteCh1Row_btn);
            this.groupBox3.Controls.Add(this.singleChannel_gridView);
            this.groupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(449, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(544, 502);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Run\'s Readings";
            // 
            // notNumberWarning_lbl
            // 
            this.notNumberWarning_lbl.AutoSize = true;
            this.notNumberWarning_lbl.ForeColor = System.Drawing.Color.Red;
            this.notNumberWarning_lbl.Location = new System.Drawing.Point(399, 159);
            this.notNumberWarning_lbl.Name = "notNumberWarning_lbl";
            this.notNumberWarning_lbl.Size = new System.Drawing.Size(0, 25);
            this.notNumberWarning_lbl.TabIndex = 153;
            // 
            // useLimit_chkbox
            // 
            this.useLimit_chkbox.AutoSize = true;
            this.useLimit_chkbox.Location = new System.Drawing.Point(394, 133);
            this.useLimit_chkbox.Name = "useLimit_chkbox";
            this.useLimit_chkbox.Size = new System.Drawing.Size(231, 29);
            this.useLimit_chkbox.TabIndex = 141;
            this.useLimit_chkbox.Text = "Use Low/High Limit";
            this.useLimit_chkbox.UseVisualStyleBackColor = true;
            this.useLimit_chkbox.CheckedChanged += new System.EventHandler(this.useLimit_chkbox_CheckedChanged);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(392, 67);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(120, 25);
            this.label46.TabIndex = 152;
            this.label46.Text = "Select Tool";
            // 
            // toolID_SC_comboBox
            // 
            this.toolID_SC_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.toolID_SC_comboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolID_SC_comboBox.FormattingEnabled = true;
            this.toolID_SC_comboBox.Location = new System.Drawing.Point(394, 85);
            this.toolID_SC_comboBox.Name = "toolID_SC_comboBox";
            this.toolID_SC_comboBox.Size = new System.Drawing.Size(133, 33);
            this.toolID_SC_comboBox.TabIndex = 139;
            // 
            // average_lbl
            // 
            this.average_lbl.AutoSize = true;
            this.average_lbl.Location = new System.Drawing.Point(437, 358);
            this.average_lbl.Name = "average_lbl";
            this.average_lbl.Size = new System.Drawing.Size(93, 25);
            this.average_lbl.TabIndex = 151;
            this.average_lbl.Text = "Average";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(391, 358);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 25);
            this.label47.TabIndex = 150;
            this.label47.Text = "Ave.";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(392, 229);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(51, 25);
            this.label43.TabIndex = 149;
            this.label43.Text = "LSL";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(391, 189);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(55, 25);
            this.label33.TabIndex = 148;
            this.label33.Text = "USL";
            // 
            // USL_txt
            // 
            this.USL_txt.Location = new System.Drawing.Point(425, 186);
            this.USL_txt.Name = "USL_txt";
            this.USL_txt.Size = new System.Drawing.Size(100, 33);
            this.USL_txt.TabIndex = 142;
            // 
            // LSL_txt
            // 
            this.LSL_txt.Location = new System.Drawing.Point(425, 226);
            this.LSL_txt.Name = "LSL_txt";
            this.LSL_txt.Size = new System.Drawing.Size(100, 33);
            this.LSL_txt.TabIndex = 143;
            // 
            // showCMK_chkBox
            // 
            this.showCMK_chkBox.AutoSize = true;
            this.showCMK_chkBox.Checked = true;
            this.showCMK_chkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCMK_chkBox.Location = new System.Drawing.Point(394, 113);
            this.showCMK_chkBox.Name = "showCMK_chkBox";
            this.showCMK_chkBox.Size = new System.Drawing.Size(236, 29);
            this.showCMK_chkBox.TabIndex = 140;
            this.showCMK_chkBox.Text = "Show CM and CMK";
            this.showCMK_chkBox.UseVisualStyleBackColor = true;
            // 
            // CMKVal_lbl
            // 
            this.CMKVal_lbl.AutoSize = true;
            this.CMKVal_lbl.Location = new System.Drawing.Point(437, 318);
            this.CMKVal_lbl.Name = "CMKVal_lbl";
            this.CMKVal_lbl.Size = new System.Drawing.Size(118, 25);
            this.CMKVal_lbl.TabIndex = 147;
            this.CMKVal_lbl.Text = "CMK value";
            // 
            // CMK_lbl
            // 
            this.CMK_lbl.AutoSize = true;
            this.CMK_lbl.Location = new System.Drawing.Point(391, 318);
            this.CMK_lbl.Name = "CMK_lbl";
            this.CMK_lbl.Size = new System.Drawing.Size(68, 25);
            this.CMK_lbl.TabIndex = 146;
            this.CMK_lbl.Text = "CMK:";
            // 
            // CMVal_lbl
            // 
            this.CMVal_lbl.AutoSize = true;
            this.CMVal_lbl.Location = new System.Drawing.Point(437, 274);
            this.CMVal_lbl.Name = "CMVal_lbl";
            this.CMVal_lbl.Size = new System.Drawing.Size(103, 25);
            this.CMVal_lbl.TabIndex = 145;
            this.CMVal_lbl.Text = "CM value";
            // 
            // CM_lbl
            // 
            this.CM_lbl.AutoSize = true;
            this.CM_lbl.Location = new System.Drawing.Point(391, 274);
            this.CM_lbl.Name = "CM_lbl";
            this.CM_lbl.Size = new System.Drawing.Size(53, 25);
            this.CM_lbl.TabIndex = 144;
            this.CM_lbl.Text = "CM:";
            // 
            // runNameErrorLabel
            // 
            this.runNameErrorLabel.AutoSize = true;
            this.runNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.runNameErrorLabel.Location = new System.Drawing.Point(15, 54);
            this.runNameErrorLabel.Name = "runNameErrorLabel";
            this.runNameErrorLabel.Size = new System.Drawing.Size(0, 25);
            this.runNameErrorLabel.TabIndex = 66;
            // 
            // currentRunText
            // 
            this.currentRunText.Location = new System.Drawing.Point(106, 21);
            this.currentRunText.Name = "currentRunText";
            this.currentRunText.Size = new System.Drawing.Size(100, 33);
            this.currentRunText.TabIndex = 1;
            this.currentRunText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.currentRunText_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 25);
            this.label11.TabIndex = 65;
            this.label11.Text = "Current Run:";
            // 
            // saveCurrent_button
            // 
            this.saveCurrent_button.Location = new System.Drawing.Point(198, 462);
            this.saveCurrent_button.Name = "saveCurrent_button";
            this.saveCurrent_button.Size = new System.Drawing.Size(107, 33);
            this.saveCurrent_button.TabIndex = 7;
            this.saveCurrent_button.Text = "Save Current Run";
            this.saveCurrent_button.UseVisualStyleBackColor = true;
            this.saveCurrent_button.Click += new System.EventHandler(this.saveCurrent_button_Click);
            // 
            // add_serie
            // 
            this.add_serie.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_serie.Location = new System.Drawing.Point(311, 462);
            this.add_serie.Name = "add_serie";
            this.add_serie.Size = new System.Drawing.Size(88, 33);
            this.add_serie.TabIndex = 8;
            this.add_serie.Text = "New Run";
            this.add_serie.UseVisualStyleBackColor = true;
            this.add_serie.Click += new System.EventHandler(this.add_serie_Click);
            // 
            // clearCh1CurrRun_btn
            // 
            this.clearCh1CurrRun_btn.Location = new System.Drawing.Point(104, 462);
            this.clearCh1CurrRun_btn.Name = "clearCh1CurrRun_btn";
            this.clearCh1CurrRun_btn.Size = new System.Drawing.Size(88, 33);
            this.clearCh1CurrRun_btn.TabIndex = 6;
            this.clearCh1CurrRun_btn.Text = "Clear All Data";
            this.clearCh1CurrRun_btn.UseVisualStyleBackColor = true;
            this.clearCh1CurrRun_btn.Click += new System.EventHandler(this.clearRun_SingleTab_Click);
            // 
            // saveCurrRun_1chann_button
            // 
            this.saveCurrRun_1chann_button.Location = new System.Drawing.Point(343, 19);
            this.saveCurrRun_1chann_button.Name = "saveCurrRun_1chann_button";
            this.saveCurrRun_1chann_button.Size = new System.Drawing.Size(125, 24);
            this.saveCurrRun_1chann_button.TabIndex = 3;
            this.saveCurrRun_1chann_button.Text = "Save As && Open";
            this.saveCurrRun_1chann_button.UseVisualStyleBackColor = true;
            this.saveCurrRun_1chann_button.Click += new System.EventHandler(this.saveCurrRun_1chann_button_Click);
            // 
            // quickExport
            // 
            this.quickExport.Location = new System.Drawing.Point(212, 19);
            this.quickExport.Name = "quickExport";
            this.quickExport.Size = new System.Drawing.Size(125, 24);
            this.quickExport.TabIndex = 2;
            this.quickExport.Text = "Save && Open";
            this.quickExport.UseVisualStyleBackColor = true;
            this.quickExport.Click += new System.EventHandler(this.quickExport_Click_1);
            // 
            // deleteCh1Row_btn
            // 
            this.deleteCh1Row_btn.Location = new System.Drawing.Point(11, 462);
            this.deleteCh1Row_btn.Name = "deleteCh1Row_btn";
            this.deleteCh1Row_btn.Size = new System.Drawing.Size(88, 33);
            this.deleteCh1Row_btn.TabIndex = 5;
            this.deleteCh1Row_btn.Text = "Delete Row";
            this.deleteCh1Row_btn.UseVisualStyleBackColor = true;
            this.deleteCh1Row_btn.Click += new System.EventHandler(this.deleteRow_SingleTab_Click);
            // 
            // singleChannel_gridView
            // 
            this.singleChannel_gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.singleChannel_gridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.singleChannel_gridView.Location = new System.Drawing.Point(40, 71);
            this.singleChannel_gridView.Name = "singleChannel_gridView";
            this.singleChannel_gridView.ReadOnly = true;
            this.singleChannel_gridView.Size = new System.Drawing.Size(337, 385);
            this.singleChannel_gridView.TabIndex = 4;
            this.singleChannel_gridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridview1_CellEndEdit);
            this.singleChannel_gridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.singleChannel_gridView_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Sample #";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Reading";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // simple_col
            // 
            this.simple_col.Controls.Add(this.Label_Data1);
            this.simple_col.Controls.Add(this.button2);
            this.simple_col.Controls.Add(this.button3);
            this.simple_col.Controls.Add(this.checkBox6);
            this.simple_col.Controls.Add(this.label5);
            this.simple_col.Controls.Add(this.numericUpDown1);
            this.simple_col.Controls.Add(this.button4);
            this.simple_col.Controls.Add(this.label6);
            this.simple_col.Controls.Add(this.comList2);
            this.simple_col.Controls.Add(this.button5);
            this.simple_col.Controls.Add(this.groupBox2);
            this.simple_col.Location = new System.Drawing.Point(8, 38);
            this.simple_col.Name = "simple_col";
            this.simple_col.Padding = new System.Windows.Forms.Padding(3);
<<<<<<< HEAD
            this.simple_col.Size = new System.Drawing.Size(1674, 877);
=======
            this.simple_col.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.simple_col.TabIndex = 1;
            this.simple_col.Text = "Simple Reading with Option to Save";
            this.simple_col.UseVisualStyleBackColor = true;
            // 
            // Label_Data1
            // 
            this.Label_Data1.AutoSize = true;
            this.Label_Data1.Font = new System.Drawing.Font("OCR A Extended", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Data1.Location = new System.Drawing.Point(20, 30);
            this.Label_Data1.Name = "Label_Data1";
            this.Label_Data1.Size = new System.Drawing.Size(229, 57);
            this.Label_Data1.TabIndex = 27;
            this.Label_Data1.Text = "0.0000";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(25, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 75);
            this.button2.TabIndex = 25;
            this.button2.Text = "Open/Close Serial Link";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(166, 122);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 75);
            this.button3.TabIndex = 26;
            this.button3.Text = "Activate Spreadsheet Transfer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(25, 212);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(269, 35);
            this.checkBox6.TabIndex = 29;
            this.checkBox6.Text = "Send Reading Only";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 25);
            this.label5.TabIndex = 35;
            this.label5.Text = "Available COM Port";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(322, 150);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 33);
            this.numericUpDown1.TabIndex = 30;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(258, 282);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 23);
            this.button4.TabIndex = 34;
            this.button4.Text = "Refresh COM List";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(319, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 31);
            this.label6.TabIndex = 31;
            this.label6.Text = "Readings Per Row";
            // 
            // comList2
            // 
            this.comList2.FormattingEnabled = true;
            this.comList2.ItemHeight = 25;
            this.comList2.Location = new System.Drawing.Point(25, 282);
            this.comList2.Name = "comList2";
<<<<<<< HEAD
            this.comList2.Size = new System.Drawing.Size(214, 54);
=======
            this.comList2.Size = new System.Drawing.Size(214, 46);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.comList2.TabIndex = 33;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(322, 176);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 33);
            this.button5.TabIndex = 32;
            this.button5.Text = "Start New Row";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.export);
            this.groupBox2.Controls.Add(this.clear);
            this.groupBox2.Controls.Add(this.delete);
            this.groupBox2.Controls.Add(this.gridview);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(516, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(402, 389);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Readings";
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(261, 340);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(100, 45);
            this.export.TabIndex = 21;
            this.export.Text = "Excel Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(142, 340);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(100, 45);
            this.clear.TabIndex = 20;
            this.clear.Text = "Clear Data";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(20, 340);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(100, 45);
            this.delete.TabIndex = 19;
            this.delete.Text = "Delete Line";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // gridview
            // 
            this.gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mem_cell,
            this.reading,
            this.unit});
            this.gridview.Location = new System.Drawing.Point(20, 30);
            this.gridview.Name = "gridview";
            this.gridview.Size = new System.Drawing.Size(337, 304);
            this.gridview.TabIndex = 18;
            this.gridview.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridview_CellEndEdit);
            // 
            // mem_cell
            // 
            this.mem_cell.HeaderText = "Memory Location";
            this.mem_cell.Name = "mem_cell";
            // 
            // reading
            // 
            this.reading.HeaderText = "Reading";
            this.reading.Name = "reading";
            // 
            // unit
            // 
            this.unit.HeaderText = "Unit";
            this.unit.Name = "unit";
            // 
            // simple_reading
            // 
            this.simple_reading.Controls.Add(this.commandResult_txt);
            this.simple_reading.Controls.Add(this.command_btn);
            this.simple_reading.Controls.Add(this.command_txt);
            this.simple_reading.Controls.Add(this.groupBox13);
            this.simple_reading.Controls.Add(this.groupBox12);
            this.simple_reading.Controls.Add(this.comListRefresh);
            this.simple_reading.Controls.Add(this.Button_Serial);
            this.simple_reading.Controls.Add(this.label2);
            this.simple_reading.Controls.Add(this.comList);
            this.simple_reading.Location = new System.Drawing.Point(8, 38);
            this.simple_reading.Name = "simple_reading";
            this.simple_reading.Padding = new System.Windows.Forms.Padding(3);
<<<<<<< HEAD
            this.simple_reading.Size = new System.Drawing.Size(1768, 859);
=======
            this.simple_reading.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.simple_reading.TabIndex = 0;
            this.simple_reading.Text = "Torque To Spreadsheet";
            this.simple_reading.UseVisualStyleBackColor = true;
            // 
            // commandResult_txt
            // 
            this.commandResult_txt.Location = new System.Drawing.Point(11, 563);
            this.commandResult_txt.Name = "commandResult_txt";
            this.commandResult_txt.Size = new System.Drawing.Size(100, 33);
            this.commandResult_txt.TabIndex = 58;
            this.commandResult_txt.Visible = false;
            // 
            // command_btn
            // 
            this.command_btn.Location = new System.Drawing.Point(143, 527);
            this.command_btn.Name = "command_btn";
            this.command_btn.Size = new System.Drawing.Size(75, 23);
            this.command_btn.TabIndex = 57;
            this.command_btn.Text = "Command";
            this.command_btn.UseVisualStyleBackColor = true;
            this.command_btn.Visible = false;
            this.command_btn.Click += new System.EventHandler(this.command_btn_Click);
            // 
            // command_txt
            // 
            this.command_txt.Location = new System.Drawing.Point(11, 527);
            this.command_txt.Name = "command_txt";
            this.command_txt.Size = new System.Drawing.Size(100, 33);
            this.command_txt.TabIndex = 56;
            this.command_txt.Visible = false;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.Button_Aquire);
            this.groupBox13.Controls.Add(this.button1);
            this.groupBox13.Controls.Add(this.label1);
            this.groupBox13.Controls.Add(this.RowCountMax);
            this.groupBox13.Controls.Add(this.Reading_Only_Box);
            this.groupBox13.Location = new System.Drawing.Point(187, 355);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(279, 159);
            this.groupBox13.TabIndex = 4;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Spreadsheet Mode";
            // 
            // Button_Aquire
            // 
            this.Button_Aquire.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Aquire.Location = new System.Drawing.Point(118, 25);
            this.Button_Aquire.Name = "Button_Aquire";
            this.Button_Aquire.Size = new System.Drawing.Size(139, 60);
            this.Button_Aquire.TabIndex = 2;
            this.Button_Aquire.Text = "Activate Spreadsheet Transfer";
            this.Button_Aquire.UseVisualStyleBackColor = true;
            this.Button_Aquire.Click += new System.EventHandler(this.Button_Aquire_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(19, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start New Row";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "Readings/row";
            // 
            // RowCountMax
            // 
            this.RowCountMax.Location = new System.Drawing.Point(19, 47);
            this.RowCountMax.Name = "RowCountMax";
            this.RowCountMax.Size = new System.Drawing.Size(57, 33);
            this.RowCountMax.TabIndex = 1;
            this.RowCountMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RowCountMax.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Reading_Only_Box
            // 
            this.Reading_Only_Box.AutoSize = true;
            this.Reading_Only_Box.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reading_Only_Box.Location = new System.Drawing.Point(118, 91);
            this.Reading_Only_Box.Name = "Reading_Only_Box";
            this.Reading_Only_Box.Size = new System.Drawing.Size(269, 35);
            this.Reading_Only_Box.TabIndex = 4;
            this.Reading_Only_Box.Text = "Send Reading Only";
            this.Reading_Only_Box.UseVisualStyleBackColor = true;
            this.Reading_Only_Box.CheckedChanged += new System.EventHandler(this.Reading_Only_Box_CheckedChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox2);
            this.groupBox12.Controls.Add(this.unitTTS_lbl);
            this.groupBox12.Controls.Add(this.COMconnect2);
            this.groupBox12.Controls.Add(this.DataTTS_lbl);
            this.groupBox12.Location = new System.Drawing.Point(8, 13);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(455, 307);
            this.groupBox12.TabIndex = 55;
            this.groupBox12.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(198, 281);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 33);
            this.textBox2.TabIndex = 59;
            this.textBox2.Visible = false;
            // 
            // unitTTS_lbl
            // 
            this.unitTTS_lbl.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitTTS_lbl.Location = new System.Drawing.Point(3, 182);
            this.unitTTS_lbl.Name = "unitTTS_lbl";
            this.unitTTS_lbl.Size = new System.Drawing.Size(392, 56);
            this.unitTTS_lbl.TabIndex = 65;
            this.unitTTS_lbl.Text = "label13";
            this.unitTTS_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // COMconnect2
            // 
            this.COMconnect2.AutoSize = true;
            this.COMconnect2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMconnect2.Location = new System.Drawing.Point(0, 16);
            this.COMconnect2.Name = "COMconnect2";
            this.COMconnect2.Size = new System.Drawing.Size(270, 31);
            this.COMconnect2.TabIndex = 41;
            this.COMconnect2.Text = "No COM Port Connect";
            // 
            // DataTTS_lbl
            // 
            this.DataTTS_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DataTTS_lbl.AutoSize = true;
            this.DataTTS_lbl.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTTS_lbl.Location = new System.Drawing.Point(0, 37);
            this.DataTTS_lbl.Name = "DataTTS_lbl";
            this.DataTTS_lbl.Size = new System.Drawing.Size(711, 180);
            this.DataTTS_lbl.TabIndex = 40;
            this.DataTTS_lbl.Text = "0.0000";
            // 
            // comListRefresh
            // 
            this.comListRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comListRefresh.Location = new System.Drawing.Point(11, 423);
            this.comListRefresh.Name = "comListRefresh";
            this.comListRefresh.Size = new System.Drawing.Size(170, 39);
            this.comListRefresh.TabIndex = 2;
            this.comListRefresh.Text = "Refresh COM List";
            this.comListRefresh.UseVisualStyleBackColor = true;
            this.comListRefresh.Click += new System.EventHandler(this.comListRefresh_Click);
            // 
            // Button_Serial
            // 
            this.Button_Serial.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Serial.Location = new System.Drawing.Point(11, 468);
            this.Button_Serial.Name = "Button_Serial";
            this.Button_Serial.Size = new System.Drawing.Size(170, 39);
            this.Button_Serial.TabIndex = 3;
            this.Button_Serial.Text = "Open/Close Channel 1";
            this.Button_Serial.UseVisualStyleBackColor = true;
            this.Button_Serial.Click += new System.EventHandler(this.Button_Serial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Available COM Port";
            // 
            // comList
            // 
            this.comList.FormattingEnabled = true;
            this.comList.HorizontalScrollbar = true;
            this.comList.ItemHeight = 25;
            this.comList.Location = new System.Drawing.Point(11, 355);
            this.comList.Name = "comList";
<<<<<<< HEAD
            this.comList.Size = new System.Drawing.Size(170, 29);
=======
            this.comList.Size = new System.Drawing.Size(170, 60);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.comList.TabIndex = 1;
            this.comList.SelectedIndexChanged += new System.EventHandler(this.comList_SelectedIndexChanged);
            // 
            // TabPages
            // 
            this.TabPages.Controls.Add(this.simple_reading);
            this.TabPages.Controls.Add(this.simple_col);
            this.TabPages.Controls.Add(this.read_graph_col);
            this.TabPages.Controls.Add(this.big_reading);
            this.TabPages.Controls.Add(this.big_graph);
            this.TabPages.Controls.Add(this.dualChannelTab);
            this.TabPages.Controls.Add(this.calibrationTab);
            this.TabPages.Cursor = System.Windows.Forms.Cursors.Default;
            this.TabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabPages.HotTrack = true;
            this.TabPages.ItemSize = new System.Drawing.Size(100, 30);
            this.TabPages.Location = new System.Drawing.Point(0, 40);
            this.TabPages.Multiline = true;
            this.TabPages.Name = "TabPages";
            this.TabPages.SelectedIndex = 0;
<<<<<<< HEAD
            this.TabPages.Size = new System.Drawing.Size(1784, 905);
=======
            this.TabPages.Size = new System.Drawing.Size(1731, 1190);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.TabPages.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.TabPages.TabIndex = 27;
            // 
            // big_reading
            // 
            this.big_reading.BackColor = System.Drawing.Color.Black;
            this.big_reading.Controls.Add(this.downSize_btn);
            this.big_reading.Controls.Add(this.panel3);
            this.big_reading.Controls.Add(this.upSize_btn);
            this.big_reading.Controls.Add(this.reading_bigReading_lbl);
            this.big_reading.Location = new System.Drawing.Point(8, 38);
            this.big_reading.Name = "big_reading";
<<<<<<< HEAD
            this.big_reading.Size = new System.Drawing.Size(1674, 877);
=======
            this.big_reading.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.big_reading.TabIndex = 2;
            this.big_reading.Text = "Big Reading";
            // 
            // downSize_btn
            // 
            this.downSize_btn.Location = new System.Drawing.Point(3, 88);
            this.downSize_btn.Name = "downSize_btn";
            this.downSize_btn.Size = new System.Drawing.Size(66, 68);
            this.downSize_btn.TabIndex = 1;
            this.downSize_btn.Text = "Size -";
            this.downSize_btn.UseVisualStyleBackColor = true;
            this.downSize_btn.Click += new System.EventHandler(this.downSize_btn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.ch1Connect_btn_bigReading);
            this.panel3.Controls.Add(this.groupBox23);
            this.panel3.Controls.Add(this.groupBox19);
            this.panel3.Controls.Add(this.refreshCOMList_btn_bigReading);
            this.panel3.Controls.Add(this.comList_bigReading);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
<<<<<<< HEAD
            this.panel3.Location = new System.Drawing.Point(0, 442);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1674, 435);
=======
            this.panel3.Location = new System.Drawing.Point(0, 717);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1723, 435);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.panel3.TabIndex = 26;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // ch1Connect_btn_bigReading
            // 
            this.ch1Connect_btn_bigReading.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ch1Connect_btn_bigReading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch1Connect_btn_bigReading.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch1Connect_btn_bigReading.Location = new System.Drawing.Point(566, 176);
            this.ch1Connect_btn_bigReading.Name = "ch1Connect_btn_bigReading";
            this.ch1Connect_btn_bigReading.Size = new System.Drawing.Size(514, 50);
            this.ch1Connect_btn_bigReading.TabIndex = 9;
            this.ch1Connect_btn_bigReading.Text = "Open/Close Channel 1";
            this.ch1Connect_btn_bigReading.UseVisualStyleBackColor = false;
            this.ch1Connect_btn_bigReading.Click += new System.EventHandler(this.ch1Connect_btn_bigReading_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.BackColor = System.Drawing.Color.LightGray;
            this.groupBox23.Controls.Add(this.high_unitComboBox);
            this.groupBox23.Controls.Add(this.low_unitComboBox);
            this.groupBox23.Controls.Add(this.label17);
            this.groupBox23.Controls.Add(this.label23);
            this.groupBox23.Controls.Add(this.low_bigReading_txt);
            this.groupBox23.Controls.Add(this.label42);
            this.groupBox23.Controls.Add(this.high_bigReading_txt);
            this.groupBox23.Location = new System.Drawing.Point(3, 3);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(258, 179);
            this.groupBox23.TabIndex = 2;
            this.groupBox23.TabStop = false;
            // 
            // high_unitComboBox
            // 
            this.high_unitComboBox.FormattingEnabled = true;
            this.high_unitComboBox.Items.AddRange(new object[] {
            "%",
            "Eng. Unit"});
            this.high_unitComboBox.Location = new System.Drawing.Point(157, 121);
            this.high_unitComboBox.Name = "high_unitComboBox";
            this.high_unitComboBox.Size = new System.Drawing.Size(67, 33);
            this.high_unitComboBox.TabIndex = 5;
            // 
            // low_unitComboBox
            // 
            this.low_unitComboBox.FormattingEnabled = true;
            this.low_unitComboBox.Items.AddRange(new object[] {
            "%",
            "Eng. Unit"});
            this.low_unitComboBox.Location = new System.Drawing.Point(157, 57);
            this.low_unitComboBox.Name = "low_unitComboBox";
            this.low_unitComboBox.Size = new System.Drawing.Size(67, 33);
            this.low_unitComboBox.TabIndex = 3;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(100, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 45);
            this.label17.TabIndex = 27;
            this.label17.Text = "Limit";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 25);
            this.label23.TabIndex = 28;
            this.label23.Text = "Low";
            // 
            // low_bigReading_txt
            // 
            this.low_bigReading_txt.Location = new System.Drawing.Point(51, 59);
            this.low_bigReading_txt.Name = "low_bigReading_txt";
            this.low_bigReading_txt.Size = new System.Drawing.Size(100, 33);
            this.low_bigReading_txt.TabIndex = 2;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(8, 129);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 25);
            this.label42.TabIndex = 30;
            this.label42.Text = "High";
            // 
            // high_bigReading_txt
            // 
            this.high_bigReading_txt.Location = new System.Drawing.Point(51, 123);
            this.high_bigReading_txt.Name = "high_bigReading_txt";
            this.high_bigReading_txt.Size = new System.Drawing.Size(100, 33);
            this.high_bigReading_txt.TabIndex = 4;
            // 
            // groupBox19
            // 
            this.groupBox19.BackColor = System.Drawing.Color.LightGray;
            this.groupBox19.Controls.Add(this.target_bigReading_txt);
            this.groupBox19.Controls.Add(this.PassFail_lbl);
            this.groupBox19.Controls.Add(this.label45);
            this.groupBox19.Location = new System.Drawing.Point(267, 3);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(293, 179);
            this.groupBox19.TabIndex = 3;
            this.groupBox19.TabStop = false;
            // 
            // target_bigReading_txt
            // 
            this.target_bigReading_txt.Font = new System.Drawing.Font("Arial", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.target_bigReading_txt.Location = new System.Drawing.Point(28, 52);
            this.target_bigReading_txt.Name = "target_bigReading_txt";
            this.target_bigReading_txt.Size = new System.Drawing.Size(245, 53);
            this.target_bigReading_txt.TabIndex = 6;
            this.target_bigReading_txt.Text = "";
            // 
            // PassFail_lbl
            // 
            this.PassFail_lbl.Font = new System.Drawing.Font("Arial", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassFail_lbl.ForeColor = System.Drawing.Color.Maroon;
            this.PassFail_lbl.Location = new System.Drawing.Point(28, 115);
            this.PassFail_lbl.Name = "PassFail_lbl";
            this.PassFail_lbl.Size = new System.Drawing.Size(245, 58);
            this.PassFail_lbl.TabIndex = 26;
            this.PassFail_lbl.Text = "Pass/Fail";
            this.PassFail_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(111, 9);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(130, 45);
            this.label45.TabIndex = 32;
            this.label45.Text = "Target";
            // 
            // refreshCOMList_btn_bigReading
            // 
            this.refreshCOMList_btn_bigReading.BackColor = System.Drawing.Color.WhiteSmoke;
            this.refreshCOMList_btn_bigReading.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.refreshCOMList_btn_bigReading.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshCOMList_btn_bigReading.Location = new System.Drawing.Point(566, 118);
            this.refreshCOMList_btn_bigReading.Name = "refreshCOMList_btn_bigReading";
            this.refreshCOMList_btn_bigReading.Size = new System.Drawing.Size(514, 52);
            this.refreshCOMList_btn_bigReading.TabIndex = 8;
            this.refreshCOMList_btn_bigReading.Text = "Refresh COM List";
            this.refreshCOMList_btn_bigReading.UseVisualStyleBackColor = false;
            this.refreshCOMList_btn_bigReading.Click += new System.EventHandler(this.refreshCOMList_btn_bigReading_Click);
            // 
            // comList_bigReading
            // 
            this.comList_bigReading.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comList_bigReading.FormattingEnabled = true;
            this.comList_bigReading.ItemHeight = 61;
            this.comList_bigReading.Location = new System.Drawing.Point(566, 12);
            this.comList_bigReading.Name = "comList_bigReading";
<<<<<<< HEAD
            this.comList_bigReading.Size = new System.Drawing.Size(514, 4);
=======
            this.comList_bigReading.Size = new System.Drawing.Size(514, 100);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.comList_bigReading.TabIndex = 7;
            // 
            // upSize_btn
            // 
            this.upSize_btn.Location = new System.Drawing.Point(3, 3);
            this.upSize_btn.Name = "upSize_btn";
            this.upSize_btn.Size = new System.Drawing.Size(66, 68);
            this.upSize_btn.TabIndex = 0;
            this.upSize_btn.Text = "Size +";
            this.upSize_btn.UseVisualStyleBackColor = true;
            this.upSize_btn.Click += new System.EventHandler(this.upSize_btn_Click);
            // 
            // reading_bigReading_lbl
            // 
            this.reading_bigReading_lbl.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reading_bigReading_lbl.Cursor = System.Windows.Forms.Cursors.Default;
            this.reading_bigReading_lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reading_bigReading_lbl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reading_bigReading_lbl.Font = new System.Drawing.Font("OCR A Extended", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reading_bigReading_lbl.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.reading_bigReading_lbl.Location = new System.Drawing.Point(0, 0);
            this.reading_bigReading_lbl.Name = "reading_bigReading_lbl";
            this.reading_bigReading_lbl.Padding = new System.Windows.Forms.Padding(0, 0, 100, 430);
<<<<<<< HEAD
            this.reading_bigReading_lbl.Size = new System.Drawing.Size(1674, 877);
=======
            this.reading_bigReading_lbl.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.reading_bigReading_lbl.TabIndex = 27;
            this.reading_bigReading_lbl.Text = "0.0000";
            this.reading_bigReading_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // calibrationTab
            // 
            this.calibrationTab.Controls.Add(this.groupBox18);
            this.calibrationTab.Controls.Add(this.startTest_btn);
            this.calibrationTab.Controls.Add(this.continue_pauseTest_btn);
            this.calibrationTab.Controls.Add(this.captureBtn_calTab);
            this.calibrationTab.Controls.Add(this.groupBox17);
            this.calibrationTab.Controls.Add(this.stream_btn);
            this.calibrationTab.Controls.Add(this.ch2Reading_groupBox);
            this.calibrationTab.Controls.Add(this.testSetup_groupBox);
            this.calibrationTab.Controls.Add(this.groupBox20);
            this.calibrationTab.Controls.Add(this.groupBox21);
            this.calibrationTab.Controls.Add(this.groupBox22);
            this.calibrationTab.Controls.Add(this.target_groupBox);
            this.calibrationTab.Location = new System.Drawing.Point(8, 38);
            this.calibrationTab.Name = "calibrationTab";
<<<<<<< HEAD
            this.calibrationTab.Size = new System.Drawing.Size(1768, 859);
=======
            this.calibrationTab.Size = new System.Drawing.Size(1723, 1152);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.calibrationTab.TabIndex = 6;
            this.calibrationTab.Text = "Cal Cert";
            this.calibrationTab.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.ch2Target_select);
            this.groupBox18.Controls.Add(this.ch1Target_select);
            this.groupBox18.Location = new System.Drawing.Point(877, 0);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(159, 40);
            this.groupBox18.TabIndex = 34;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "Target Channel";
            // 
            // ch2Target_select
            // 
            this.ch2Target_select.AutoSize = true;
            this.ch2Target_select.Checked = true;
            this.ch2Target_select.Location = new System.Drawing.Point(86, 16);
            this.ch2Target_select.Name = "ch2Target_select";
<<<<<<< HEAD
            this.ch2Target_select.Size = new System.Drawing.Size(138, 29);
=======
            this.ch2Target_select.Size = new System.Drawing.Size(73, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.ch2Target_select.TabIndex = 67;
            this.ch2Target_select.TabStop = true;
            this.ch2Target_select.Text = "Channel 2";
            this.ch2Target_select.UseVisualStyleBackColor = true;
            // 
            // ch1Target_select
            // 
            this.ch1Target_select.AutoSize = true;
            this.ch1Target_select.Location = new System.Drawing.Point(3, 16);
            this.ch1Target_select.Name = "ch1Target_select";
<<<<<<< HEAD
            this.ch1Target_select.Size = new System.Drawing.Size(138, 29);
=======
            this.ch1Target_select.Size = new System.Drawing.Size(73, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.ch1Target_select.TabIndex = 65;
            this.ch1Target_select.Text = "Channel 1";
            this.ch1Target_select.UseVisualStyleBackColor = true;
            // 
            // startTest_btn
            // 
            this.startTest_btn.BackColor = System.Drawing.Color.Green;
            this.startTest_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startTest_btn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTest_btn.Location = new System.Drawing.Point(1444, 167);
            this.startTest_btn.Name = "startTest_btn";
            this.startTest_btn.Size = new System.Drawing.Size(95, 42);
            this.startTest_btn.TabIndex = 33;
            this.startTest_btn.Text = "Start Test";
            this.startTest_btn.UseVisualStyleBackColor = false;
            this.startTest_btn.Click += new System.EventHandler(this.startTest_btn_Click);
            // 
            // continue_pauseTest_btn
            // 
            this.continue_pauseTest_btn.BackColor = System.Drawing.Color.Green;
            this.continue_pauseTest_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.continue_pauseTest_btn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continue_pauseTest_btn.Location = new System.Drawing.Point(909, 150);
            this.continue_pauseTest_btn.Name = "continue_pauseTest_btn";
            this.continue_pauseTest_btn.Size = new System.Drawing.Size(95, 42);
            this.continue_pauseTest_btn.TabIndex = 32;
            this.continue_pauseTest_btn.Text = "Pause Test";
            this.continue_pauseTest_btn.UseVisualStyleBackColor = false;
            this.continue_pauseTest_btn.Click += new System.EventHandler(this.continue_pause_btn_Click);
            // 
            // captureBtn_calTab
            // 
            this.captureBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.captureBtn_calTab.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureBtn_calTab.Location = new System.Drawing.Point(909, 257);
            this.captureBtn_calTab.Name = "captureBtn_calTab";
            this.captureBtn_calTab.Size = new System.Drawing.Size(95, 42);
            this.captureBtn_calTab.TabIndex = 5;
            this.captureBtn_calTab.Text = "Capture";
            this.captureBtn_calTab.UseVisualStyleBackColor = true;
            this.captureBtn_calTab.Click += new System.EventHandler(this.captureBtn_calTab_Click);
            // 
            // groupBox17
            // 
<<<<<<< HEAD
=======
            this.groupBox17.Controls.Add(this.openOldStream_btn);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.groupBox17.Controls.Add(this.ALCCWChart_radio);
            this.groupBox17.Controls.Add(this.AFCCWChart_radio);
            this.groupBox17.Controls.Add(this.ALCWChart_radio);
            this.groupBox17.Controls.Add(this.AFCWChart_radio);
            this.groupBox17.Controls.Add(this.exportChart_btn);
            this.groupBox17.Controls.Add(this.exportAverage_chckbox);
            this.groupBox17.Controls.Add(this.excelExport_calTab_btn);
            this.groupBox17.Controls.Add(this.copyAllStruct_btn);
            this.groupBox17.Controls.Add(this.AFCW_grid);
            this.groupBox17.Controls.Add(this.ALCCWactive_label);
            this.groupBox17.Controls.Add(this.ALCWactive_label);
            this.groupBox17.Controls.Add(this.AFCCWactive_label);
            this.groupBox17.Controls.Add(this.AFCWactive_label);
            this.groupBox17.Controls.Add(this.label26);
            this.groupBox17.Controls.Add(this.lowColor_label);
            this.groupBox17.Controls.Add(this.label25);
            this.groupBox17.Controls.Add(this.highColor_label);
            this.groupBox17.Controls.Add(this.ALCCW_grid);
            this.groupBox17.Controls.Add(this.abandonTest_btn);
            this.groupBox17.Controls.Add(this.AFCCW_grid);
            this.groupBox17.Controls.Add(this.ALCW_grid);
            this.groupBox17.Controls.Add(this.openCert_btn);
            this.groupBox17.Controls.Add(this.saveTestToCert_btn);
            this.groupBox17.Controls.Add(this.restartTest_btn);
            this.groupBox17.Controls.Add(this.deleteLastTestRow_btn);
            this.groupBox17.Controls.Add(this.copyCCW_btn);
            this.groupBox17.Controls.Add(this.copyCW_btn);
            this.groupBox17.Controls.Add(this.label20);
            this.groupBox17.Controls.Add(this.label22);
            this.groupBox17.Controls.Add(this.label19);
            this.groupBox17.Controls.Add(this.label18);
            this.groupBox17.Location = new System.Drawing.Point(281, 313);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(1160, 548);
            this.groupBox17.TabIndex = 29;
            this.groupBox17.TabStop = false;
            // 
<<<<<<< HEAD
=======
            // openOldStream_btn
            // 
            this.openOldStream_btn.Location = new System.Drawing.Point(955, 507);
            this.openOldStream_btn.Name = "openOldStream_btn";
            this.openOldStream_btn.Size = new System.Drawing.Size(115, 35);
            this.openOldStream_btn.TabIndex = 72;
            this.openOldStream_btn.Text = "View Stream";
            this.openOldStream_btn.UseVisualStyleBackColor = true;
            this.openOldStream_btn.Click += new System.EventHandler(this.openOldStream_btn_Click);
            // 
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            // ALCCWChart_radio
            // 
            this.ALCCWChart_radio.AutoSize = true;
            this.ALCCWChart_radio.Location = new System.Drawing.Point(804, 269);
            this.ALCCWChart_radio.Name = "ALCCWChart_radio";
<<<<<<< HEAD
            this.ALCCWChart_radio.Size = new System.Drawing.Size(102, 29);
=======
            this.ALCCWChart_radio.Size = new System.Drawing.Size(55, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.ALCCWChart_radio.TabIndex = 71;
            this.ALCCWChart_radio.TabStop = true;
            this.ALCCWChart_radio.Text = "Graph";
            this.ALCCWChart_radio.UseVisualStyleBackColor = true;
            // 
            // AFCCWChart_radio
            // 
            this.AFCCWChart_radio.AutoSize = true;
            this.AFCCWChart_radio.Location = new System.Drawing.Point(189, 269);
            this.AFCCWChart_radio.Name = "AFCCWChart_radio";
<<<<<<< HEAD
            this.AFCCWChart_radio.Size = new System.Drawing.Size(102, 29);
=======
            this.AFCCWChart_radio.Size = new System.Drawing.Size(55, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.AFCCWChart_radio.TabIndex = 70;
            this.AFCCWChart_radio.TabStop = true;
            this.AFCCWChart_radio.Text = "Graph";
            this.AFCCWChart_radio.UseVisualStyleBackColor = true;
            // 
            // ALCWChart_radio
            // 
            this.ALCWChart_radio.AutoSize = true;
            this.ALCWChart_radio.Location = new System.Drawing.Point(811, 12);
            this.ALCWChart_radio.Name = "ALCWChart_radio";
<<<<<<< HEAD
            this.ALCWChart_radio.Size = new System.Drawing.Size(102, 29);
=======
            this.ALCWChart_radio.Size = new System.Drawing.Size(55, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.ALCWChart_radio.TabIndex = 69;
            this.ALCWChart_radio.TabStop = true;
            this.ALCWChart_radio.Text = "Graph";
            this.ALCWChart_radio.UseVisualStyleBackColor = true;
            // 
            // AFCWChart_radio
            // 
            this.AFCWChart_radio.AutoSize = true;
            this.AFCWChart_radio.Location = new System.Drawing.Point(203, 12);
            this.AFCWChart_radio.Name = "AFCWChart_radio";
<<<<<<< HEAD
            this.AFCWChart_radio.Size = new System.Drawing.Size(102, 29);
=======
            this.AFCWChart_radio.Size = new System.Drawing.Size(55, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.AFCWChart_radio.TabIndex = 68;
            this.AFCWChart_radio.TabStop = true;
            this.AFCWChart_radio.Text = "Graph";
            this.AFCWChart_radio.UseVisualStyleBackColor = true;
            // 
            // exportChart_btn
            // 
<<<<<<< HEAD
            this.exportChart_btn.Location = new System.Drawing.Point(583, 261);
=======
            this.exportChart_btn.Location = new System.Drawing.Point(513, 258);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.exportChart_btn.Name = "exportChart_btn";
            this.exportChart_btn.Size = new System.Drawing.Size(115, 35);
            this.exportChart_btn.TabIndex = 67;
            this.exportChart_btn.Text = "Export Torque Chart";
            this.exportChart_btn.UseVisualStyleBackColor = true;
            this.exportChart_btn.Click += new System.EventHandler(this.ExportChart_btn_Click);
<<<<<<< HEAD
            // 
            // stream_btn
            // 
            this.stream_btn.Location = new System.Drawing.Point(903, 205);
            this.stream_btn.Name = "stream_btn";
            this.stream_btn.Size = new System.Drawing.Size(108, 29);
            this.stream_btn.TabIndex = 66;
            this.stream_btn.Text = "Stream";
            this.stream_btn.UseVisualStyleBackColor = true;
            this.stream_btn.Click += new System.EventHandler(this.stream_btn_Click);
=======
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            // 
            // exportAverage_chckbox
            // 
            this.exportAverage_chckbox.AutoSize = true;
            this.exportAverage_chckbox.Location = new System.Drawing.Point(6, 15);
            this.exportAverage_chckbox.Name = "exportAverage_chckbox";
            this.exportAverage_chckbox.Size = new System.Drawing.Size(315, 29);
            this.exportAverage_chckbox.TabIndex = 62;
            this.exportAverage_chckbox.Text = "Save Average ONLY to Cert";
            this.exportAverage_chckbox.UseVisualStyleBackColor = true;
            // 
            // excelExport_calTab_btn
            // 
            this.excelExport_calTab_btn.Location = new System.Drawing.Point(76, 507);
            this.excelExport_calTab_btn.Name = "excelExport_calTab_btn";
            this.excelExport_calTab_btn.Size = new System.Drawing.Size(115, 35);
            this.excelExport_calTab_btn.TabIndex = 61;
            this.excelExport_calTab_btn.Text = "Save && Open Excel";
            this.excelExport_calTab_btn.UseVisualStyleBackColor = true;
            this.excelExport_calTab_btn.Click += new System.EventHandler(this.excelExport_calTab_btn_Click);
            // 
            // copyAllStruct_btn
            // 
            this.copyAllStruct_btn.Location = new System.Drawing.Point(447, 10);
            this.copyAllStruct_btn.Name = "copyAllStruct_btn";
            this.copyAllStruct_btn.Size = new System.Drawing.Size(94, 23);
            this.copyAllStruct_btn.TabIndex = 60;
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
            this.AFCW_grid.TabIndex = 51;
            // 
            // ALCCWactive_label
            // 
            this.ALCCWactive_label.AutoSize = true;
            this.ALCCWactive_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALCCWactive_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ALCCWactive_label.Location = new System.Drawing.Point(939, 269);
            this.ALCCWactive_label.Name = "ALCCWactive_label";
            this.ALCCWactive_label.Size = new System.Drawing.Size(130, 36);
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
            this.ALCWactive_label.Size = new System.Drawing.Size(130, 36);
            this.ALCWactive_label.TabIndex = 49;
            this.ALCWactive_label.Text = "ACTIVE";
            this.ALCWactive_label.Visible = false;
            // 
            // AFCCWactive_label
            // 
            this.AFCCWactive_label.AutoSize = true;
            this.AFCCWactive_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AFCCWactive_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AFCCWactive_label.Location = new System.Drawing.Point(336, 269);
            this.AFCCWactive_label.Name = "AFCCWactive_label";
            this.AFCCWactive_label.Size = new System.Drawing.Size(130, 36);
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
            this.AFCWactive_label.Size = new System.Drawing.Size(130, 36);
            this.AFCWactive_label.TabIndex = 47;
            this.AFCWactive_label.Text = "ACTIVE";
            this.AFCWactive_label.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(1108, 527);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 25);
            this.label26.TabIndex = 46;
            this.label26.Text = "Low";
            // 
            // lowColor_label
            // 
            this.lowColor_label.Location = new System.Drawing.Point(1071, 527);
            this.lowColor_label.Name = "lowColor_label";
            this.lowColor_label.Size = new System.Drawing.Size(20, 10);
            this.lowColor_label.TabIndex = 45;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1108, 506);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 25);
            this.label25.TabIndex = 44;
            this.label25.Text = "High";
            // 
            // highColor_label
            // 
            this.highColor_label.Location = new System.Drawing.Point(1071, 506);
            this.highColor_label.Name = "highColor_label";
            this.highColor_label.Size = new System.Drawing.Size(20, 10);
            this.highColor_label.TabIndex = 43;
            // 
            // ALCCW_grid
            // 
            this.ALCCW_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ALCCW_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ALCCW_grid.EnableHeadersVisualStyles = false;
            this.ALCCW_grid.Location = new System.Drawing.Point(610, 301);
            this.ALCCW_grid.Name = "ALCCW_grid";
            this.ALCCW_grid.Size = new System.Drawing.Size(537, 200);
            this.ALCCW_grid.TabIndex = 5;
            // 
            // abandonTest_btn
            // 
            this.abandonTest_btn.Location = new System.Drawing.Point(522, 507);
            this.abandonTest_btn.Name = "abandonTest_btn";
            this.abandonTest_btn.Size = new System.Drawing.Size(115, 35);
            this.abandonTest_btn.TabIndex = 42;
            this.abandonTest_btn.Text = "New Test";
            this.abandonTest_btn.UseVisualStyleBackColor = true;
            this.abandonTest_btn.Click += new System.EventHandler(this.abandonTest_btn_Click);
            // 
            // AFCCW_grid
            // 
            this.AFCCW_grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AFCCW_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AFCCW_grid.EnableHeadersVisualStyles = false;
            this.AFCCW_grid.Location = new System.Drawing.Point(0, 301);
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
            // openCert_btn
            // 
            this.openCert_btn.Location = new System.Drawing.Point(818, 507);
            this.openCert_btn.Name = "openCert_btn";
            this.openCert_btn.Size = new System.Drawing.Size(115, 35);
            this.openCert_btn.TabIndex = 37;
            this.openCert_btn.Text = "Open Cert";
            this.openCert_btn.UseVisualStyleBackColor = true;
            this.openCert_btn.Click += new System.EventHandler(this.openCert_btn_Click);
            // 
            // saveTestToCert_btn
            // 
            this.saveTestToCert_btn.Location = new System.Drawing.Point(670, 507);
            this.saveTestToCert_btn.Name = "saveTestToCert_btn";
            this.saveTestToCert_btn.Size = new System.Drawing.Size(115, 35);
            this.saveTestToCert_btn.TabIndex = 36;
            this.saveTestToCert_btn.Text = "Save To Cert";
            this.saveTestToCert_btn.UseVisualStyleBackColor = true;
            this.saveTestToCert_btn.Click += new System.EventHandler(this.saveTestToCert_btn_Click);
            // 
            // restartTest_btn
            // 
            this.restartTest_btn.Location = new System.Drawing.Point(374, 507);
            this.restartTest_btn.Name = "restartTest_btn";
            this.restartTest_btn.Size = new System.Drawing.Size(113, 35);
            this.restartTest_btn.TabIndex = 35;
            this.restartTest_btn.Text = "Clear Readings";
            this.restartTest_btn.UseVisualStyleBackColor = true;
            this.restartTest_btn.Click += new System.EventHandler(this.restartTest_btn_Click);
            // 
            // deleteLastTestRow_btn
            // 
            this.deleteLastTestRow_btn.Location = new System.Drawing.Point(224, 507);
            this.deleteLastTestRow_btn.Name = "deleteLastTestRow_btn";
            this.deleteLastTestRow_btn.Size = new System.Drawing.Size(115, 35);
            this.deleteLastTestRow_btn.TabIndex = 34;
            this.deleteLastTestRow_btn.Text = "Delete Last";
            this.deleteLastTestRow_btn.UseVisualStyleBackColor = true;
            this.deleteLastTestRow_btn.Click += new System.EventHandler(this.deleteLastTestRow_btn_Click);
            // 
            // copyCCW_btn
            // 
            this.copyCCW_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.copyCCW_btn.Location = new System.Drawing.Point(536, 377);
            this.copyCCW_btn.Name = "copyCCW_btn";
            this.copyCCW_btn.Size = new System.Drawing.Size(75, 23);
            this.copyCCW_btn.TabIndex = 1;
            this.copyCCW_btn.Text = "Copy -->";
            this.copyCCW_btn.UseVisualStyleBackColor = true;
            this.copyCCW_btn.Click += new System.EventHandler(this.copyCCW_btn_Click);
            // 
            // copyCW_btn
            // 
            this.copyCW_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.copyCW_btn.Location = new System.Drawing.Point(539, 115);
            this.copyCW_btn.Name = "copyCW_btn";
            this.copyCW_btn.Size = new System.Drawing.Size(75, 23);
            this.copyCW_btn.TabIndex = 0;
            this.copyCW_btn.Text = "Copy -->";
            this.copyCW_btn.UseVisualStyleBackColor = true;
            this.copyCW_btn.Click += new System.EventHandler(this.copyCW_btn_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(865, 273);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(141, 25);
            this.label20.TabIndex = 31;
            this.label20.Text = "As Left-CCW";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(872, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(125, 25);
            this.label22.TabIndex = 29;
            this.label22.Text = "As Left-CW";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(250, 273);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(164, 25);
            this.label19.TabIndex = 25;
            this.label19.Text = "As Found-CCW";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(264, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(148, 25);
            this.label18.TabIndex = 23;
            this.label18.Text = "As Found-CW";
            // 
            // stream_btn
            // 
            this.stream_btn.Location = new System.Drawing.Point(903, 205);
            this.stream_btn.Name = "stream_btn";
            this.stream_btn.Size = new System.Drawing.Size(108, 29);
            this.stream_btn.TabIndex = 66;
            this.stream_btn.Text = "Stream";
            this.stream_btn.UseVisualStyleBackColor = true;
            this.stream_btn.Click += new System.EventHandler(this.stream_btn_Click);
            // 
            // ch2Reading_groupBox
            // 
            this.ch2Reading_groupBox.Controls.Add(this.ch2Trough_chckbox);
            this.ch2Reading_groupBox.Controls.Add(this.label39);
            this.ch2Reading_groupBox.Controls.Add(this.ch2UnitLabel_calTab);
            this.ch2Reading_groupBox.Controls.Add(this.ch2ReadingLabel_calTab);
            this.ch2Reading_groupBox.Controls.Add(this.ch2ConnectLabel_calTab);
            this.ch2Reading_groupBox.Controls.Add(this.ch2MenuControlBtn_calTab);
            this.ch2Reading_groupBox.Controls.Add(this.ch2ZeroBtn_calTab);
            this.ch2Reading_groupBox.Controls.Add(this.ch2ModeControlBtn_calTab);
            this.ch2Reading_groupBox.Controls.Add(this.ch2UnitBtn_calTab);
            this.ch2Reading_groupBox.Location = new System.Drawing.Point(956, 0);
            this.ch2Reading_groupBox.Name = "ch2Reading_groupBox";
            this.ch2Reading_groupBox.Size = new System.Drawing.Size(486, 307);
            this.ch2Reading_groupBox.TabIndex = 25;
            this.ch2Reading_groupBox.TabStop = false;
            // 
            // ch2Trough_chckbox
            // 
            this.ch2Trough_chckbox.AutoSize = true;
            this.ch2Trough_chckbox.Location = new System.Drawing.Point(60, 252);
            this.ch2Trough_chckbox.Name = "ch2Trough_chckbox";
            this.ch2Trough_chckbox.Size = new System.Drawing.Size(173, 29);
            this.ch2Trough_chckbox.TabIndex = 87;
            this.ch2Trough_chckbox.Text = "Trough Mode";
            this.ch2Trough_chckbox.UseVisualStyleBackColor = true;
            this.ch2Trough_chckbox.CheckedChanged += new System.EventHandler(this.ch2Trough_chckbox_CheckedChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(185, 2);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(193, 25);
            this.label39.TabIndex = 86;
            this.label39.Text = "Channel 2 Reading";
            // 
            // ch2UnitLabel_calTab
            // 
            this.ch2UnitLabel_calTab.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch2UnitLabel_calTab.Location = new System.Drawing.Point(3, 182);
            this.ch2UnitLabel_calTab.Name = "ch2UnitLabel_calTab";
            this.ch2UnitLabel_calTab.Size = new System.Drawing.Size(392, 56);
            this.ch2UnitLabel_calTab.TabIndex = 85;
            this.ch2UnitLabel_calTab.Text = "label13";
            this.ch2UnitLabel_calTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ch2ReadingLabel_calTab
            // 
            this.ch2ReadingLabel_calTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ch2ReadingLabel_calTab.AutoSize = true;
            this.ch2ReadingLabel_calTab.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch2ReadingLabel_calTab.ForeColor = System.Drawing.Color.Blue;
            this.ch2ReadingLabel_calTab.Location = new System.Drawing.Point(6, 37);
            this.ch2ReadingLabel_calTab.Name = "ch2ReadingLabel_calTab";
            this.ch2ReadingLabel_calTab.Size = new System.Drawing.Size(711, 180);
            this.ch2ReadingLabel_calTab.TabIndex = 73;
            this.ch2ReadingLabel_calTab.Text = "0.0000";
            // 
            // ch2ConnectLabel_calTab
            // 
            this.ch2ConnectLabel_calTab.AutoSize = true;
            this.ch2ConnectLabel_calTab.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch2ConnectLabel_calTab.Location = new System.Drawing.Point(338, 16);
            this.ch2ConnectLabel_calTab.Name = "ch2ConnectLabel_calTab";
            this.ch2ConnectLabel_calTab.Size = new System.Drawing.Size(288, 32);
            this.ch2ConnectLabel_calTab.TabIndex = 66;
            this.ch2ConnectLabel_calTab.Text = "No COM Port Connect";
            // 
            // ch2MenuControlBtn_calTab
            // 
            this.ch2MenuControlBtn_calTab.BackColor = System.Drawing.Color.Transparent;
            this.ch2MenuControlBtn_calTab.Enabled = false;
            this.ch2MenuControlBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch2MenuControlBtn_calTab.Location = new System.Drawing.Point(175, 276);
            this.ch2MenuControlBtn_calTab.Name = "ch2MenuControlBtn_calTab";
            this.ch2MenuControlBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch2MenuControlBtn_calTab.TabIndex = 2;
            this.ch2MenuControlBtn_calTab.Text = "Menu";
            this.ch2MenuControlBtn_calTab.UseVisualStyleBackColor = false;
            this.ch2MenuControlBtn_calTab.Click += new System.EventHandler(this.ch2MenuControlBtn_calTab_Click);
            // 
            // ch2ZeroBtn_calTab
            // 
            this.ch2ZeroBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch2ZeroBtn_calTab.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch2ZeroBtn_calTab.Location = new System.Drawing.Point(60, 276);
            this.ch2ZeroBtn_calTab.Name = "ch2ZeroBtn_calTab";
            this.ch2ZeroBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch2ZeroBtn_calTab.TabIndex = 1;
            this.ch2ZeroBtn_calTab.Text = "Zero/Clear";
            this.ch2ZeroBtn_calTab.UseVisualStyleBackColor = true;
            this.ch2ZeroBtn_calTab.Click += new System.EventHandler(this.ch2ZeroBtn_calTab_Click);
            // 
            // ch2ModeControlBtn_calTab
            // 
            this.ch2ModeControlBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch2ModeControlBtn_calTab.Location = new System.Drawing.Point(288, 276);
            this.ch2ModeControlBtn_calTab.Name = "ch2ModeControlBtn_calTab";
            this.ch2ModeControlBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch2ModeControlBtn_calTab.TabIndex = 3;
            this.ch2ModeControlBtn_calTab.Text = "Mode";
            this.ch2ModeControlBtn_calTab.UseVisualStyleBackColor = true;
            this.ch2ModeControlBtn_calTab.Click += new System.EventHandler(this.ch2ModeControlBtn_calTab_Click);
            // 
            // ch2UnitBtn_calTab
            // 
            this.ch2UnitBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch2UnitBtn_calTab.Location = new System.Drawing.Point(399, 276);
            this.ch2UnitBtn_calTab.Name = "ch2UnitBtn_calTab";
            this.ch2UnitBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch2UnitBtn_calTab.TabIndex = 4;
            this.ch2UnitBtn_calTab.Text = "Unit";
            this.ch2UnitBtn_calTab.UseVisualStyleBackColor = true;
            this.ch2UnitBtn_calTab.Click += new System.EventHandler(this.ch2UnitBtn_calTab_Click);
            // 
            // testSetup_groupBox
            // 
            this.testSetup_groupBox.Controls.Add(this.textBox1);
            this.testSetup_groupBox.Controls.Add(this.label40);
            this.testSetup_groupBox.Controls.Add(this.label27);
            this.testSetup_groupBox.Controls.Add(this.limitEngPercent_comboBox);
            this.testSetup_groupBox.Controls.Add(this.saveAsTest_btn);
            this.testSetup_groupBox.Controls.Add(this.ch2Unit_txt);
            this.testSetup_groupBox.Controls.Add(this.label24);
            this.testSetup_groupBox.Controls.Add(this.ch1Unit_txt);
            this.testSetup_groupBox.Controls.Add(this.label28);
            this.testSetup_groupBox.Controls.Add(this.sampleNum_txt);
            this.testSetup_groupBox.Controls.Add(this.label30);
            this.testSetup_groupBox.Controls.Add(this.label29);
            this.testSetup_groupBox.Controls.Add(this.label31);
            this.testSetup_groupBox.Controls.Add(this.maxPoint_txt);
            this.testSetup_groupBox.Controls.Add(this.label32);
            this.testSetup_groupBox.Controls.Add(this.testID_lbl);
            this.testSetup_groupBox.Controls.Add(this.testOrder_list);
            this.testSetup_groupBox.Controls.Add(this.resetCurrTestSettings_btn);
            this.testSetup_groupBox.Controls.Add(this.testID_txt);
            this.testSetup_groupBox.Controls.Add(this.saveStartTest_btn);
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
            this.testSetup_groupBox.Controls.Add(this.testSetup_comboBox);
            this.testSetup_groupBox.Controls.Add(this.label38);
            this.testSetup_groupBox.Location = new System.Drawing.Point(0, 0);
            this.testSetup_groupBox.Name = "testSetup_groupBox";
            this.testSetup_groupBox.Size = new System.Drawing.Size(488, 307);
            this.testSetup_groupBox.TabIndex = 23;
            this.testSetup_groupBox.TabStop = false;
            this.testSetup_groupBox.Text = "Test Set up";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(133, 190);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 33);
            this.textBox1.TabIndex = 5;
            this.textBox1.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(12, 193);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(223, 26);
            this.label40.TabIndex = 61;
            this.label40.Text = "Nominal Full Scale*";
            this.label40.Visible = false;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(246, 140);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(184, 26);
            this.label27.TabIndex = 59;
            this.label27.Text = "% or Eng. Unit *";
            // 
            // limitEngPercent_comboBox
            // 
            this.limitEngPercent_comboBox.FormattingEnabled = true;
            this.limitEngPercent_comboBox.Items.AddRange(new object[] {
            "%",
            "Eng. Unit"});
            this.limitEngPercent_comboBox.Location = new System.Drawing.Point(367, 137);
            this.limitEngPercent_comboBox.Name = "limitEngPercent_comboBox";
            this.limitEngPercent_comboBox.Size = new System.Drawing.Size(100, 33);
            this.limitEngPercent_comboBox.TabIndex = 9;
            this.limitEngPercent_comboBox.SelectedIndexChanged += new System.EventHandler(this.limitEngPercent_comboBox_SelectedIndexChanged);
            // 
            // saveAsTest_btn
            // 
            this.saveAsTest_btn.Location = new System.Drawing.Point(314, 276);
            this.saveAsTest_btn.Name = "saveAsTest_btn";
            this.saveAsTest_btn.Size = new System.Drawing.Size(75, 23);
            this.saveAsTest_btn.TabIndex = 17;
            this.saveAsTest_btn.Text = "Save As";
            this.saveAsTest_btn.UseVisualStyleBackColor = true;
            this.saveAsTest_btn.Click += new System.EventHandler(this.saveAsTest_btn_Click);
            // 
            // ch2Unit_txt
            // 
            this.ch2Unit_txt.Location = new System.Drawing.Point(367, 190);
            this.ch2Unit_txt.Name = "ch2Unit_txt";
            this.ch2Unit_txt.Size = new System.Drawing.Size(100, 33);
            this.ch2Unit_txt.TabIndex = 11;
            this.ch2Unit_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ch2Unit_txt_Keydown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(248, 193);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(170, 26);
            this.label24.TabIndex = 55;
            this.label24.Text = "Channel 2 Unit";
            // 
            // ch1Unit_txt
            // 
            this.ch1Unit_txt.Location = new System.Drawing.Point(367, 164);
            this.ch1Unit_txt.Name = "ch1Unit_txt";
            this.ch1Unit_txt.Size = new System.Drawing.Size(100, 33);
            this.ch1Unit_txt.TabIndex = 10;
            this.ch1Unit_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ch1Unit_txt_Keydown);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 240);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(239, 25);
            this.label28.TabIndex = 53;
            this.label28.Text = "(Drag to Change Order)";
            // 
            // sampleNum_txt
            // 
            this.sampleNum_txt.Location = new System.Drawing.Point(367, 59);
            this.sampleNum_txt.Name = "sampleNum_txt";
            this.sampleNum_txt.Size = new System.Drawing.Size(100, 33);
            this.sampleNum_txt.TabIndex = 6;
            this.sampleNum_txt.Text = "1";
            this.sampleNum_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sampleNum_txt_Keydown);
            this.sampleNum_txt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.sampleNum_txt_PreviewKeyDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(246, 62);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(201, 26);
            this.label30.TabIndex = 51;
            this.label30.Text = "# Samples/point *";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(248, 167);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(170, 26);
            this.label29.TabIndex = 50;
            this.label29.Text = "Channel 1 Unit";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(12, 122);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(126, 26);
            this.label31.TabIndex = 49;
            this.label31.Text = "# of Points";
            // 
            // maxPoint_txt
            // 
            this.maxPoint_txt.Location = new System.Drawing.Point(133, 119);
            this.maxPoint_txt.Name = "maxPoint_txt";
            this.maxPoint_txt.Size = new System.Drawing.Size(100, 33);
            this.maxPoint_txt.TabIndex = 3;
            this.maxPoint_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maxPoint_txt_Keydown);
            this.maxPoint_txt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.maxPoint_txt_PreviewKeyDown);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(12, 225);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(114, 26);
            this.label32.TabIndex = 47;
            this.label32.Text = "Test Order";
            // 
            // testID_lbl
            // 
            this.testID_lbl.AutoSize = true;
            this.testID_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testID_lbl.Location = new System.Drawing.Point(12, 62);
            this.testID_lbl.Name = "testID_lbl";
            this.testID_lbl.Size = new System.Drawing.Size(105, 26);
            this.testID_lbl.TabIndex = 46;
            this.testID_lbl.Text = "Test ID *";
            // 
            // testOrder_list
            // 
            this.testOrder_list.AllowDrop = true;
            this.testOrder_list.FormattingEnabled = true;
            this.testOrder_list.ItemHeight = 25;
            this.testOrder_list.Location = new System.Drawing.Point(133, 225);
            this.testOrder_list.Name = "testOrder_list";
<<<<<<< HEAD
            this.testOrder_list.Size = new System.Drawing.Size(100, 29);
=======
            this.testOrder_list.Size = new System.Drawing.Size(100, 18);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.testOrder_list.TabIndex = 45;
            // 
            // resetCurrTestSettings_btn
            // 
            this.resetCurrTestSettings_btn.Location = new System.Drawing.Point(394, 276);
            this.resetCurrTestSettings_btn.Name = "resetCurrTestSettings_btn";
            this.resetCurrTestSettings_btn.Size = new System.Drawing.Size(73, 23);
            this.resetCurrTestSettings_btn.TabIndex = 18;
            this.resetCurrTestSettings_btn.Text = "Reset Fields";
            this.resetCurrTestSettings_btn.UseVisualStyleBackColor = true;
            this.resetCurrTestSettings_btn.Click += new System.EventHandler(this.resetCurrTestSettings_btn_Click);
            // 
            // testID_txt
            // 
            this.testID_txt.Location = new System.Drawing.Point(133, 59);
            this.testID_txt.Name = "testID_txt";
            this.testID_txt.Size = new System.Drawing.Size(100, 33);
            this.testID_txt.TabIndex = 1;
            this.testID_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.testID_txt_Keydown);
            this.testID_txt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.testID_txt_PreviewKeyDown);
            // 
            // saveStartTest_btn
            // 
            this.saveStartTest_btn.Location = new System.Drawing.Point(239, 276);
            this.saveStartTest_btn.Name = "saveStartTest_btn";
            this.saveStartTest_btn.Size = new System.Drawing.Size(71, 23);
            this.saveStartTest_btn.TabIndex = 16;
            this.saveStartTest_btn.Text = "Save/Start Test";
            this.saveStartTest_btn.UseVisualStyleBackColor = true;
            this.saveStartTest_btn.Click += new System.EventHandler(this.saveStartTest_btn_Click);
            // 
            // AL_chkbox
            // 
            this.AL_chkbox.AutoSize = true;
            this.AL_chkbox.Location = new System.Drawing.Point(350, 222);
            this.AL_chkbox.Name = "AL_chkbox";
            this.AL_chkbox.Size = new System.Drawing.Size(113, 29);
            this.AL_chkbox.TabIndex = 13;
            this.AL_chkbox.Text = "As Left";
            this.AL_chkbox.UseVisualStyleBackColor = true;
            this.AL_chkbox.CheckedChanged += new System.EventHandler(this.AL_chkbox_CheckedChanged);
            // 
            // AF_chkbox
            // 
            this.AF_chkbox.AutoSize = true;
            this.AF_chkbox.Location = new System.Drawing.Point(248, 222);
            this.AF_chkbox.Name = "AF_chkbox";
            this.AF_chkbox.Size = new System.Drawing.Size(136, 29);
            this.AF_chkbox.TabIndex = 12;
            this.AF_chkbox.Text = "As Found";
            this.AF_chkbox.UseVisualStyleBackColor = true;
            this.AF_chkbox.CheckedChanged += new System.EventHandler(this.AF_chkbox_CheckedChanged);
            // 
            // highLimit_txt
            // 
            this.highLimit_txt.Location = new System.Drawing.Point(367, 111);
            this.highLimit_txt.Name = "highLimit_txt";
            this.highLimit_txt.Size = new System.Drawing.Size(100, 33);
            this.highLimit_txt.TabIndex = 8;
            this.highLimit_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.highLimit_txt_Keydown);
            this.highLimit_txt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.highLimit_txt_PreviewKeyDown);
            // 
            // lowLimit_txt
            // 
            this.lowLimit_txt.Location = new System.Drawing.Point(367, 85);
            this.lowLimit_txt.Name = "lowLimit_txt";
            this.lowLimit_txt.Size = new System.Drawing.Size(100, 33);
            this.lowLimit_txt.TabIndex = 7;
            this.lowLimit_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lowLimit_txt_Keydown);
            this.lowLimit_txt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lowLimit_txt_PreviewKeyDown);
            // 
            // FS_txt
            // 
            this.FS_txt.Location = new System.Drawing.Point(133, 164);
            this.FS_txt.Name = "FS_txt";
            this.FS_txt.Size = new System.Drawing.Size(100, 33);
            this.FS_txt.TabIndex = 4;
            this.FS_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FS_txt_Keydown);
            this.FS_txt.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FS_txt_PreviewKeyDown);
            // 
            // CCW_chkbox
            // 
            this.CCW_chkbox.AutoSize = true;
            this.CCW_chkbox.Location = new System.Drawing.Point(350, 252);
            this.CCW_chkbox.Name = "CCW_chkbox";
            this.CCW_chkbox.Size = new System.Drawing.Size(223, 29);
            this.CCW_chkbox.TabIndex = 15;
            this.CCW_chkbox.Text = "Counter Clockwise";
            this.CCW_chkbox.UseVisualStyleBackColor = true;
            this.CCW_chkbox.CheckedChanged += new System.EventHandler(this.CCW_chkbox_CheckedChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(248, 114);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(137, 26);
            this.label35.TabIndex = 33;
            this.label35.Text = "High Limit *";
            // 
            // CW_chkbox
            // 
            this.CW_chkbox.AutoSize = true;
            this.CW_chkbox.Location = new System.Drawing.Point(248, 252);
            this.CW_chkbox.Name = "CW_chkbox";
            this.CW_chkbox.Size = new System.Drawing.Size(141, 29);
            this.CW_chkbox.TabIndex = 14;
            this.CW_chkbox.Text = "Clockwise";
            this.CW_chkbox.UseVisualStyleBackColor = true;
            this.CW_chkbox.CheckedChanged += new System.EventHandler(this.CW_chkbox_CheckedChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(246, 88);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(131, 26);
            this.label36.TabIndex = 32;
            this.label36.Text = "Low Limit *";
            // 
            // FSTarget_label
            // 
            this.FSTarget_label.AutoSize = true;
            this.FSTarget_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSTarget_label.Location = new System.Drawing.Point(12, 167);
            this.FSTarget_label.Name = "FSTarget_label";
            this.FSTarget_label.Size = new System.Drawing.Size(202, 26);
            this.FSTarget_label.TabIndex = 31;
            this.FSTarget_label.Text = "Target Full Scale*";
            // 
            // testType_comboBox
            // 
            this.testType_comboBox.FormattingEnabled = true;
            this.testType_comboBox.Items.AddRange(new object[] {
            "Single Channel Test",
            "Dual Channel Test"});
            this.testType_comboBox.Location = new System.Drawing.Point(133, 88);
            this.testType_comboBox.Name = "testType_comboBox";
            this.testType_comboBox.Size = new System.Drawing.Size(100, 33);
            this.testType_comboBox.TabIndex = 2;
            this.testType_comboBox.SelectedIndexChanged += new System.EventHandler(this.testType_comboBox_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(12, 91);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(132, 26);
            this.label37.TabIndex = 12;
            this.label37.Text = "Test Type *";
            // 
            // testSetup_comboBox
            // 
            this.testSetup_comboBox.FormattingEnabled = true;
            this.testSetup_comboBox.Location = new System.Drawing.Point(133, 27);
            this.testSetup_comboBox.Name = "testSetup_comboBox";
            this.testSetup_comboBox.Size = new System.Drawing.Size(334, 33);
            this.testSetup_comboBox.TabIndex = 0;
            this.testSetup_comboBox.SelectedIndexChanged += new System.EventHandler(this.testSetup_comboBox_SelectedIndexChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.Location = new System.Drawing.Point(12, 30);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(148, 26);
            this.label38.TabIndex = 1;
            this.label38.Text = "Select Test *";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.label41);
            this.groupBox20.Controls.Add(this.comList_calibration);
            this.groupBox20.Controls.Add(this.ch2ConnectBtn_calTab);
            this.groupBox20.Controls.Add(this.ch1ConnectBtn_calTab);
            this.groupBox20.Controls.Add(this.comRefreshBtn_calTab);
            this.groupBox20.Location = new System.Drawing.Point(0, 614);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(279, 229);
            this.groupBox20.TabIndex = 27;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Select available COM";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 20);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(204, 25);
            this.label41.TabIndex = 65;
            this.label41.Text = "Available COM Port";
            // 
            // comList_calibration
            // 
            this.comList_calibration.FormattingEnabled = true;
            this.comList_calibration.HorizontalScrollbar = true;
            this.comList_calibration.ItemHeight = 25;
            this.comList_calibration.Location = new System.Drawing.Point(9, 49);
            this.comList_calibration.Name = "comList_calibration";
<<<<<<< HEAD
            this.comList_calibration.Size = new System.Drawing.Size(264, 29);
=======
            this.comList_calibration.Size = new System.Drawing.Size(264, 60);
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
            this.comList_calibration.TabIndex = 1;
            // 
            // ch2ConnectBtn_calTab
            // 
            this.ch2ConnectBtn_calTab.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch2ConnectBtn_calTab.Location = new System.Drawing.Point(9, 189);
            this.ch2ConnectBtn_calTab.Name = "ch2ConnectBtn_calTab";
            this.ch2ConnectBtn_calTab.Size = new System.Drawing.Size(264, 31);
            this.ch2ConnectBtn_calTab.TabIndex = 4;
            this.ch2ConnectBtn_calTab.Text = "Open/Close Channel 2";
            this.ch2ConnectBtn_calTab.UseVisualStyleBackColor = true;
            this.ch2ConnectBtn_calTab.Click += new System.EventHandler(this.ch2ConnectBtn_calTab_Click);
            // 
            // ch1ConnectBtn_calTab
            // 
            this.ch1ConnectBtn_calTab.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch1ConnectBtn_calTab.Location = new System.Drawing.Point(9, 152);
            this.ch1ConnectBtn_calTab.Name = "ch1ConnectBtn_calTab";
            this.ch1ConnectBtn_calTab.Size = new System.Drawing.Size(264, 31);
            this.ch1ConnectBtn_calTab.TabIndex = 3;
            this.ch1ConnectBtn_calTab.Text = "Open/Close Channel 1";
            this.ch1ConnectBtn_calTab.UseVisualStyleBackColor = true;
            this.ch1ConnectBtn_calTab.Click += new System.EventHandler(this.ch1ConnectBtn_calTab_Click);
            // 
            // comRefreshBtn_calTab
            // 
            this.comRefreshBtn_calTab.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comRefreshBtn_calTab.Location = new System.Drawing.Point(9, 115);
            this.comRefreshBtn_calTab.Name = "comRefreshBtn_calTab";
            this.comRefreshBtn_calTab.Size = new System.Drawing.Size(264, 31);
            this.comRefreshBtn_calTab.TabIndex = 2;
            this.comRefreshBtn_calTab.Text = "Refresh COM List";
            this.comRefreshBtn_calTab.UseVisualStyleBackColor = true;
            this.comRefreshBtn_calTab.Click += new System.EventHandler(this.comRefreshBtn_calTab_Click);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.ch1Trough_chckbox);
            this.groupBox21.Controls.Add(this.label34);
            this.groupBox21.Controls.Add(this.ch1MenuControlBtn_calTab);
            this.groupBox21.Controls.Add(this.ch1ZeroBtn_calTab);
            this.groupBox21.Controls.Add(this.ch1ModeControlBtn_calTab);
            this.groupBox21.Controls.Add(this.ch1UnitBtn_calTab);
            this.groupBox21.Controls.Add(this.ch1UnitLabel_calTab);
            this.groupBox21.Controls.Add(this.ch1ReadingLabel_calTab);
            this.groupBox21.Controls.Add(this.ch1ConnectLabel_calTab);
            this.groupBox21.Location = new System.Drawing.Point(488, 0);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(469, 307);
            this.groupBox21.TabIndex = 24;
            this.groupBox21.TabStop = false;
            // 
            // ch1Trough_chckbox
            // 
            this.ch1Trough_chckbox.AutoSize = true;
            this.ch1Trough_chckbox.Location = new System.Drawing.Point(10, 252);
            this.ch1Trough_chckbox.Name = "ch1Trough_chckbox";
            this.ch1Trough_chckbox.Size = new System.Drawing.Size(173, 29);
            this.ch1Trough_chckbox.TabIndex = 31;
            this.ch1Trough_chckbox.Text = "Trough Mode";
            this.ch1Trough_chckbox.UseVisualStyleBackColor = true;
            this.ch1Trough_chckbox.CheckedChanged += new System.EventHandler(this.ch1Trough_chckbox_CheckedChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.White;
            this.label34.Location = new System.Drawing.Point(185, 2);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(193, 25);
            this.label34.TabIndex = 31;
            this.label34.Text = "Channel 1 Reading";
            // 
            // ch1MenuControlBtn_calTab
            // 
            this.ch1MenuControlBtn_calTab.BackColor = System.Drawing.Color.Transparent;
            this.ch1MenuControlBtn_calTab.Enabled = false;
            this.ch1MenuControlBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch1MenuControlBtn_calTab.Location = new System.Drawing.Point(117, 276);
            this.ch1MenuControlBtn_calTab.Name = "ch1MenuControlBtn_calTab";
            this.ch1MenuControlBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch1MenuControlBtn_calTab.TabIndex = 83;
            this.ch1MenuControlBtn_calTab.Text = "Menu";
            this.ch1MenuControlBtn_calTab.UseVisualStyleBackColor = false;
            this.ch1MenuControlBtn_calTab.Click += new System.EventHandler(this.ch1MenuControlBtn_calTab_Click);
            // 
            // ch1ZeroBtn_calTab
            // 
            this.ch1ZeroBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch1ZeroBtn_calTab.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch1ZeroBtn_calTab.Location = new System.Drawing.Point(11, 276);
            this.ch1ZeroBtn_calTab.Name = "ch1ZeroBtn_calTab";
            this.ch1ZeroBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch1ZeroBtn_calTab.TabIndex = 82;
            this.ch1ZeroBtn_calTab.Text = "Zero/Clear";
            this.ch1ZeroBtn_calTab.UseVisualStyleBackColor = true;
            this.ch1ZeroBtn_calTab.Click += new System.EventHandler(this.ch1ZeroBtn_calTab_Click);
            // 
            // ch1ModeControlBtn_calTab
            // 
            this.ch1ModeControlBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch1ModeControlBtn_calTab.Location = new System.Drawing.Point(224, 276);
            this.ch1ModeControlBtn_calTab.Name = "ch1ModeControlBtn_calTab";
            this.ch1ModeControlBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch1ModeControlBtn_calTab.TabIndex = 84;
            this.ch1ModeControlBtn_calTab.Text = "Mode";
            this.ch1ModeControlBtn_calTab.UseVisualStyleBackColor = true;
            this.ch1ModeControlBtn_calTab.Click += new System.EventHandler(this.ch1ModeControlBtn_calTab_Click);
            // 
            // ch1UnitBtn_calTab
            // 
            this.ch1UnitBtn_calTab.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ch1UnitBtn_calTab.Location = new System.Drawing.Point(330, 276);
            this.ch1UnitBtn_calTab.Name = "ch1UnitBtn_calTab";
            this.ch1UnitBtn_calTab.Size = new System.Drawing.Size(75, 23);
            this.ch1UnitBtn_calTab.TabIndex = 85;
            this.ch1UnitBtn_calTab.Text = "Unit";
            this.ch1UnitBtn_calTab.UseVisualStyleBackColor = true;
            this.ch1UnitBtn_calTab.Click += new System.EventHandler(this.ch1UnitBtn_calTab_Click);
            // 
            // ch1UnitLabel_calTab
            // 
            this.ch1UnitLabel_calTab.Font = new System.Drawing.Font("Arial", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch1UnitLabel_calTab.Location = new System.Drawing.Point(3, 182);
            this.ch1UnitLabel_calTab.Name = "ch1UnitLabel_calTab";
            this.ch1UnitLabel_calTab.Size = new System.Drawing.Size(392, 56);
            this.ch1UnitLabel_calTab.TabIndex = 81;
            this.ch1UnitLabel_calTab.Text = "label13";
            this.ch1UnitLabel_calTab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ch1ReadingLabel_calTab
            // 
            this.ch1ReadingLabel_calTab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ch1ReadingLabel_calTab.AutoSize = true;
            this.ch1ReadingLabel_calTab.Font = new System.Drawing.Font("OCR A Extended", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch1ReadingLabel_calTab.ForeColor = System.Drawing.Color.Blue;
            this.ch1ReadingLabel_calTab.Location = new System.Drawing.Point(6, 37);
            this.ch1ReadingLabel_calTab.Name = "ch1ReadingLabel_calTab";
            this.ch1ReadingLabel_calTab.Size = new System.Drawing.Size(711, 180);
            this.ch1ReadingLabel_calTab.TabIndex = 75;
            this.ch1ReadingLabel_calTab.Text = "0.0000";
            // 
            // ch1ConnectLabel_calTab
            // 
            this.ch1ConnectLabel_calTab.AutoSize = true;
            this.ch1ConnectLabel_calTab.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ch1ConnectLabel_calTab.Location = new System.Drawing.Point(6, 16);
            this.ch1ConnectLabel_calTab.Name = "ch1ConnectLabel_calTab";
            this.ch1ConnectLabel_calTab.Size = new System.Drawing.Size(288, 32);
            this.ch1ConnectLabel_calTab.TabIndex = 65;
            this.ch1ConnectLabel_calTab.Text = "No COM Port Connect";
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.comment_txt);
            this.groupBox22.Controls.Add(this.comment_lbl);
            this.groupBox22.Controls.Add(this.toolID_comboBox);
            this.groupBox22.Controls.Add(this.toolOperatorID_txt);
            this.groupBox22.Controls.Add(this.operatorID_lbl);
            this.groupBox22.Controls.Add(this.toolProcedure_txt);
            this.groupBox22.Controls.Add(this.procedure_lbl);
            this.groupBox22.Controls.Add(this.label15);
            this.groupBox22.Controls.Add(this.toolCertLot_txt);
            this.groupBox22.Controls.Add(this.certLot_lbl);
            this.groupBox22.Controls.Add(this.toolManufacture_txt);
            this.groupBox22.Controls.Add(this.manu_lbl);
            this.groupBox22.Controls.Add(this.toolModel_txt);
            this.groupBox22.Controls.Add(this.model_lbl);
            this.groupBox22.Controls.Add(this.humid_txt);
            this.groupBox22.Controls.Add(this.humid_lbl);
            this.groupBox22.Controls.Add(this.temperature_txt);
            this.groupBox22.Controls.Add(this.temperature_lbl);
            this.groupBox22.Controls.Add(this.recall_txt);
            this.groupBox22.Controls.Add(this.recall_lbl);
            this.groupBox22.Controls.Add(this.toolSN_txt);
            this.groupBox22.Controls.Add(this.toolSN_lbl);
            this.groupBox22.Controls.Add(this.toolID_lbl);
            this.groupBox22.Location = new System.Drawing.Point(0, 313);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(279, 302);
            this.groupBox22.TabIndex = 28;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Tools Info";
            // 
            // comment_txt
            // 
            this.comment_txt.Location = new System.Drawing.Point(89, 273);
            this.comment_txt.Name = "comment_txt";
            this.comment_txt.Size = new System.Drawing.Size(184, 33);
            this.comment_txt.TabIndex = 44;
            // 
            // comment_lbl
            // 
            this.comment_lbl.AutoSize = true;
            this.comment_lbl.Location = new System.Drawing.Point(6, 280);
            this.comment_lbl.Name = "comment_lbl";
            this.comment_lbl.Size = new System.Drawing.Size(106, 25);
            this.comment_lbl.TabIndex = 43;
            this.comment_lbl.Text = "Comment";
            // 
            // toolID_comboBox
            // 
            this.toolID_comboBox.FormattingEnabled = true;
            this.toolID_comboBox.Location = new System.Drawing.Point(89, 12);
            this.toolID_comboBox.Name = "toolID_comboBox";
            this.toolID_comboBox.Size = new System.Drawing.Size(184, 33);
            this.toolID_comboBox.TabIndex = 1;
            this.toolID_comboBox.SelectedIndexChanged += new System.EventHandler(this.toolID_comboBox_SelectedIndexChanged_1);
            // 
            // toolOperatorID_txt
            // 
            this.toolOperatorID_txt.Location = new System.Drawing.Point(89, 247);
            this.toolOperatorID_txt.Name = "toolOperatorID_txt";
            this.toolOperatorID_txt.Size = new System.Drawing.Size(184, 33);
            this.toolOperatorID_txt.TabIndex = 41;
            // 
            // operatorID_lbl
            // 
            this.operatorID_lbl.AutoSize = true;
            this.operatorID_lbl.Location = new System.Drawing.Point(6, 254);
            this.operatorID_lbl.Name = "operatorID_lbl";
            this.operatorID_lbl.Size = new System.Drawing.Size(126, 25);
            this.operatorID_lbl.TabIndex = 40;
            this.operatorID_lbl.Text = "Operator ID";
            // 
            // toolProcedure_txt
            // 
            this.toolProcedure_txt.Location = new System.Drawing.Point(89, 221);
            this.toolProcedure_txt.Name = "toolProcedure_txt";
            this.toolProcedure_txt.Size = new System.Drawing.Size(184, 33);
            this.toolProcedure_txt.TabIndex = 39;
            // 
            // procedure_lbl
            // 
            this.procedure_lbl.AutoSize = true;
            this.procedure_lbl.Location = new System.Drawing.Point(6, 228);
            this.procedure_lbl.Name = "procedure_lbl";
            this.procedure_lbl.Size = new System.Drawing.Size(112, 25);
            this.procedure_lbl.TabIndex = 38;
            this.procedure_lbl.Text = "Procedure";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(228, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 25);
            this.label15.TabIndex = 37;
            this.label15.Text = "months";
            // 
            // toolCertLot_txt
            // 
            this.toolCertLot_txt.Location = new System.Drawing.Point(89, 195);
            this.toolCertLot_txt.Name = "toolCertLot_txt";
            this.toolCertLot_txt.Size = new System.Drawing.Size(184, 33);
            this.toolCertLot_txt.TabIndex = 36;
            // 
            // certLot_lbl
            // 
            this.certLot_lbl.AutoSize = true;
            this.certLot_lbl.Location = new System.Drawing.Point(6, 202);
            this.certLot_lbl.Name = "certLot_lbl";
            this.certLot_lbl.Size = new System.Drawing.Size(90, 25);
            this.certLot_lbl.TabIndex = 35;
            this.certLot_lbl.Text = "Cert Lot";
            // 
            // toolManufacture_txt
            // 
            this.toolManufacture_txt.Location = new System.Drawing.Point(89, 169);
            this.toolManufacture_txt.Name = "toolManufacture_txt";
            this.toolManufacture_txt.Size = new System.Drawing.Size(184, 33);
            this.toolManufacture_txt.TabIndex = 34;
            // 
            // manu_lbl
            // 
            this.manu_lbl.AutoSize = true;
            this.manu_lbl.Location = new System.Drawing.Point(6, 176);
            this.manu_lbl.Name = "manu_lbl";
            this.manu_lbl.Size = new System.Drawing.Size(131, 25);
            this.manu_lbl.TabIndex = 33;
            this.manu_lbl.Text = "Manufacture";
            // 
            // toolModel_txt
            // 
            this.toolModel_txt.Location = new System.Drawing.Point(89, 143);
            this.toolModel_txt.Name = "toolModel_txt";
            this.toolModel_txt.Size = new System.Drawing.Size(184, 33);
            this.toolModel_txt.TabIndex = 32;
            // 
            // model_lbl
            // 
            this.model_lbl.AutoSize = true;
            this.model_lbl.Location = new System.Drawing.Point(6, 150);
            this.model_lbl.Name = "model_lbl";
            this.model_lbl.Size = new System.Drawing.Size(72, 25);
            this.model_lbl.TabIndex = 31;
            this.model_lbl.Text = "Model";
            // 
            // humid_txt
            // 
            this.humid_txt.Location = new System.Drawing.Point(89, 117);
            this.humid_txt.Name = "humid_txt";
            this.humid_txt.Size = new System.Drawing.Size(184, 33);
            this.humid_txt.TabIndex = 30;
            // 
            // humid_lbl
            // 
            this.humid_lbl.AutoSize = true;
            this.humid_lbl.Location = new System.Drawing.Point(6, 124);
            this.humid_lbl.Name = "humid_lbl";
            this.humid_lbl.Size = new System.Drawing.Size(96, 25);
            this.humid_lbl.TabIndex = 29;
            this.humid_lbl.Text = "Humidity";
            // 
            // temperature_txt
            // 
            this.temperature_txt.Location = new System.Drawing.Point(89, 91);
            this.temperature_txt.Name = "temperature_txt";
            this.temperature_txt.Size = new System.Drawing.Size(184, 33);
            this.temperature_txt.TabIndex = 28;
            // 
            // temperature_lbl
            // 
            this.temperature_lbl.AutoSize = true;
            this.temperature_lbl.Location = new System.Drawing.Point(6, 98);
            this.temperature_lbl.Name = "temperature_lbl";
            this.temperature_lbl.Size = new System.Drawing.Size(133, 25);
            this.temperature_lbl.TabIndex = 27;
            this.temperature_lbl.Text = "Temperature";
            // 
            // recall_txt
            // 
            this.recall_txt.Location = new System.Drawing.Point(89, 65);
            this.recall_txt.Name = "recall_txt";
            this.recall_txt.Size = new System.Drawing.Size(137, 33);
            this.recall_txt.TabIndex = 26;
            // 
            // recall_lbl
            // 
            this.recall_lbl.AutoSize = true;
            this.recall_lbl.Location = new System.Drawing.Point(6, 72);
            this.recall_lbl.Name = "recall_lbl";
            this.recall_lbl.Size = new System.Drawing.Size(146, 25);
            this.recall_lbl.TabIndex = 25;
            this.recall_lbl.Text = "Recall Interval";
            // 
            // toolSN_txt
            // 
            this.toolSN_txt.Location = new System.Drawing.Point(89, 39);
            this.toolSN_txt.Name = "toolSN_txt";
            this.toolSN_txt.Size = new System.Drawing.Size(184, 33);
            this.toolSN_txt.TabIndex = 24;
            // 
            // toolSN_lbl
            // 
            this.toolSN_lbl.AutoSize = true;
            this.toolSN_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolSN_lbl.Location = new System.Drawing.Point(6, 46);
            this.toolSN_lbl.Name = "toolSN_lbl";
            this.toolSN_lbl.Size = new System.Drawing.Size(69, 26);
            this.toolSN_lbl.TabIndex = 23;
            this.toolSN_lbl.Text = "S/N *";
            // 
            // toolID_lbl
            // 
            this.toolID_lbl.AutoSize = true;
            this.toolID_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolID_lbl.Location = new System.Drawing.Point(6, 20);
            this.toolID_lbl.Name = "toolID_lbl";
            this.toolID_lbl.Size = new System.Drawing.Size(144, 26);
            this.toolID_lbl.TabIndex = 21;
            this.toolID_lbl.Text = "Tool Name *";
            // 
            // target_groupBox
            // 
            this.target_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.target_groupBox.Controls.Add(this.testTarget_lbl);
            this.target_groupBox.Controls.Add(this.label13);
            this.target_groupBox.Location = new System.Drawing.Point(956, 0);
            this.target_groupBox.Name = "target_groupBox";
            this.target_groupBox.Size = new System.Drawing.Size(488, 307);
            this.target_groupBox.TabIndex = 31;
            this.target_groupBox.TabStop = false;
            // 
            // testTarget_lbl
            // 
            this.testTarget_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.testTarget_lbl.Font = new System.Drawing.Font("OCR A Extended", 65.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testTarget_lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.testTarget_lbl.Location = new System.Drawing.Point(0, 108);
            this.testTarget_lbl.Name = "testTarget_lbl";
            this.testTarget_lbl.Size = new System.Drawing.Size(482, 89);
            this.testTarget_lbl.TabIndex = 76;
            this.testTarget_lbl.Text = "0.0000";
            this.testTarget_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(157, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(358, 72);
            this.label13.TabIndex = 0;
            this.label13.Text = "Next Target";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1473, 945);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1731, 1214);
            this.Controls.Add(this.TabPages);
            this.Controls.Add(this.testerType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_millivolt);
            this.Controls.Add(this.Tester_Type_Label);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " Torque To Spreadsheet";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.dualChannelTab.ResumeLayout(false);
            this.dualChannelTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dualMasterGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noCurrDualMasterGrid)).EndInit();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dualChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.secondChannelGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firstChannelGrid)).EndInit();
            this.big_graph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.read_graph_col.ResumeLayout(false);
            this.read_graph_col.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGridView)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.masterGrid_noCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleChart)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleChannel_gridView)).EndInit();
            this.simple_col.ResumeLayout(false);
            this.simple_col.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridview)).EndInit();
            this.simple_reading.ResumeLayout(false);
            this.simple_reading.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowCountMax)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.TabPages.ResumeLayout(false);
            this.big_reading.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.calibrationTab.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AFCW_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCCW_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AFCCW_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ALCW_grid)).EndInit();
            this.ch2Reading_groupBox.ResumeLayout(false);
            this.ch2Reading_groupBox.PerformLayout();
            this.testSetup_groupBox.ResumeLayout(false);
            this.testSetup_groupBox.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.target_groupBox.ResumeLayout(false);
            this.target_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel SpreadSheetModeLabel;
        private System.Windows.Forms.Label Tester_Type_Label;
        private System.Windows.Forms.CheckBox checkBox_millivolt;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimizedToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem includeDateStampToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeDateToolStripMenuItem;
        private System.Windows.Forms.Label testerType;
        private System.IO.Ports.SerialPort serialPort2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TabPage dualChannelTab;
        private System.Windows.Forms.CheckedListBox serieListBox;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button addDualRun;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.Button test_save_button;
        private System.Windows.Forms.Button currRunDualQuickExport;
        private System.Windows.Forms.TextBox dualTestName_Text;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.Button quickDualExport_button;
        private System.Windows.Forms.DataGridView dualMasterGrid;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label dataCh1DualChanTab_lbl;
        private System.Windows.Forms.Label firstComConnect;
        private System.Windows.Forms.Label secondComConnect;
        private System.Windows.Forms.Label dataCh2DualChTab_lbl;
        private System.Windows.Forms.DataVisualization.Charting.Chart dualChart;
        private System.Windows.Forms.Button deleteDualRun_Button;
        private System.Windows.Forms.Button clearSecond;
        private System.Windows.Forms.Button deleteSecond;
        private System.Windows.Forms.DataGridView secondChannelGridView;
        private System.Windows.Forms.Button clearFirst;
        private System.Windows.Forms.Button deleteLineFirst;
        private System.Windows.Forms.DataGridView firstChannelGrid;
        private System.Windows.Forms.Button refresh_dualTab;
        private System.Windows.Forms.Button openCloseFirstPort;
        private System.Windows.Forms.ListBox comList4;
        private System.Windows.Forms.Button openCloseSecondPort;
        private System.Windows.Forms.TabPage big_graph;
        private System.Windows.Forms.Label Label_Data3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TabPage read_graph_col;
        private System.Windows.Forms.DataGridView masterGridView;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button rename_col;
        private System.Windows.Forms.Button delete_column;
        private System.Windows.Forms.DataVisualization.Charting.Chart singleChart;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label COMconnect;
        private System.Windows.Forms.Label DataSMDSingle_lbl;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox comList3;
        private System.Windows.Forms.Button refresh2;
        private System.Windows.Forms.Button chan1ConnectButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox target;
        private System.Windows.Forms.Button clear_limit;
        private System.Windows.Forms.Button draw_limit;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox low_limit;
        private System.Windows.Forms.RadioButton low_unit;
        private System.Windows.Forms.RadioButton low_percent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox high_limit;
        private System.Windows.Forms.RadioButton high_unit;
        private System.Windows.Forms.RadioButton high_percent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label dsad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button masterSave;
        private System.Windows.Forms.Button masterQuickExport;
        private System.Windows.Forms.Button saveCurrent_button;
        private System.Windows.Forms.Button add_serie;
        private System.Windows.Forms.TextBox testName_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button clearCh1CurrRun_btn;
        private System.Windows.Forms.Button saveCurrRun_1chann_button;
        private System.Windows.Forms.Button quickExport;
        private System.Windows.Forms.Button deleteCh1Row_btn;
        private System.Windows.Forms.DataGridView singleChannel_gridView;
        private System.Windows.Forms.TabPage simple_col;
        private System.Windows.Forms.Label Label_Data1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox comList2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.DataGridView gridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn mem_cell;
        private System.Windows.Forms.DataGridViewTextBoxColumn reading;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.TabPage simple_reading;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label COMconnect2;
        private System.Windows.Forms.Label DataTTS_lbl;
        private System.Windows.Forms.Button Button_Serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button comListRefresh;
        private System.Windows.Forms.ListBox comList;
        private System.Windows.Forms.TabControl TabPages;
        private System.Windows.Forms.Button renameDualRun;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button saveRun_button;
        private System.Windows.Forms.Button defineTest;
        private System.Windows.Forms.Button menuControl_button;
        private System.Windows.Forms.Button modeControl_button;
        private System.Windows.Forms.Button unitControl_button;
        private System.Windows.Forms.Button zeroControl_button;
        private System.Windows.Forms.TextBox test_label;
        private System.Windows.Forms.TextBox command_text;
        private Button enterControl_button;
        private Button button10;
        private Button button20;
        private Button chan2_zeroControl_button;
        private Button chan2_unitControl_button;
        private Button chan2_modeControl_button;
        private Button chan2_menuControl_button;
        private Button chan1_captureControl_button;
        private Button chann1_zeroControl_button;
        private Button chan1_unitControl_button;
        private Button chan1_modeControl_button;
        private Button chan1_menuControl_button;
        private ToolStripMenuItem defineQuickExportPathToolStripMenuItem;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn lowLimitCol;
        private DataGridViewTextBoxColumn highLimitCol;
        private DataGridViewTextBoxColumn theoreticalTarget;
        private DataGridViewTextBoxColumn chan1Reading;
        private DataGridViewTextBoxColumn chan2Reading;
        private GroupBox groupBox14;
        private Label label14;
        private GroupBox groupBox15;
        private Button currRunDualSaveExcel;
        private Button dualCertExport_button;
        private Button clearBothData_button;
        private Button deleteBothRow_button;
        private Button switchTestCalMode_button;
        private ToolStripMenuItem showALLCOMAvailableToolStripMenuItem;
        private ToolStripMenuItem streamDataToolStripMenuItem;
        private ToolStripMenuItem enableLiveReadingToolStripMenuItem;
        private TextBox currentRunText;
        private Label unitSingleCH_lbl;
        private Label unitCH2DualCHTab_lbl;
        private Label unitCH1DualCHTab_lbl;
        private Label unitTTS_lbl;
        private Label dualCurrRun_label1;
        private TextBox dualCh2RunName_Text;
        private TextBox dualCh1RunName_Text;
        private Label dualCurrRun_Label2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Label runNameErrorLabel;
        private ToolStripMenuItem newTestToolStripMenuItem;
        private Button xySwitch_button;
        private Panel panel1;
        private Label label16;
        private Label dualRunName2ErrorLabel;
        private Label dualRunName1ErrorLabel;
        private DataGridView masterGrid_noCurrent;
        private DataGridView noCurrDualMasterGrid;
        private ToolStripMenuItem overwriteDataAtCursorToolStripMenuItem;
        private TabPage calibrationTab;
        private GroupBox groupBox17;
        private Label ALCCWactive_label;
        private Label ALCWactive_label;
        private Label AFCCWactive_label;
        private Label AFCWactive_label;
        private Label label26;
        private Label lowColor_label;
        private Label label25;
        private Label highColor_label;
        private DataGridView ALCCW_grid;
        private Button abandonTest_btn;
        private DataGridView AFCCW_grid;
        private DataGridView ALCW_grid;
        private Button openCert_btn;
        private Button saveTestToCert_btn;
        private Button restartTest_btn;
        private Button deleteLastTestRow_btn;
        private Button copyCCW_btn;
        private Button copyCW_btn;
        private Label label20;
        private Label label22;
        private Label label19;
        private Label label18;
        private Button captureBtn_calTab;
        private GroupBox ch2Reading_groupBox;
        private Label ch2UnitLabel_calTab;
        private Label ch2ReadingLabel_calTab;
        private Label ch2ConnectLabel_calTab;
        private Button ch2MenuControlBtn_calTab;
        private Button ch2ZeroBtn_calTab;
        private Button ch2ModeControlBtn_calTab;
        private Button ch2UnitBtn_calTab;
        private GroupBox testSetup_groupBox;
        private TextBox sampleNum_txt;
        private Label label30;
        private Label label29;
        private Label label31;
        private TextBox maxPoint_txt;
        private Label label32;
        private Label testID_lbl;
        private ListBox testOrder_list;
        private Button resetCurrTestSettings_btn;
        private TextBox testID_txt;
        private Button saveStartTest_btn;
        private CheckBox AL_chkbox;
        private CheckBox AF_chkbox;
        private TextBox highLimit_txt;
        private TextBox lowLimit_txt;
        private TextBox FS_txt;
        private CheckBox CCW_chkbox;
        private Label label35;
        private CheckBox CW_chkbox;
        private Label label36;
        private Label FSTarget_label;
        private ComboBox testType_comboBox;
        private Label label37;
        private ComboBox testSetup_comboBox;
        private Label label38;
        private GroupBox groupBox20;
        private Label label41;
        private ListBox comList_calibration;
        private Button ch2ConnectBtn_calTab;
        private Button ch1ConnectBtn_calTab;
        private Button comRefreshBtn_calTab;
        private GroupBox groupBox21;
        private Button ch1MenuControlBtn_calTab;
        private Button ch1ZeroBtn_calTab;
        private Button ch1ModeControlBtn_calTab;
        private Button ch1UnitBtn_calTab;
        private Label ch1UnitLabel_calTab;
        private Label ch1ReadingLabel_calTab;
        private Label ch1ConnectLabel_calTab;
        private GroupBox groupBox22;
        private TextBox toolOperatorID_txt;
        private Label operatorID_lbl;
        private TextBox toolProcedure_txt;
        private Label procedure_lbl;
        private Label label15;
        private TextBox toolCertLot_txt;
        private Label certLot_lbl;
        private TextBox toolManufacture_txt;
        private Label manu_lbl;
        private TextBox toolModel_txt;
        private Label model_lbl;
        private TextBox humid_txt;
        private Label humid_lbl;
        private TextBox temperature_txt;
        private Label temperature_lbl;
        private TextBox recall_txt;
        private Label recall_lbl;
        private TextBox toolSN_txt;
        private Label toolSN_lbl;
        private Label toolID_lbl;
        private DataGridView AFCW_grid;
        private Label label28;
        private TextBox ch1Unit_txt;
        private TextBox ch2Unit_txt;
        private Label label24;
        private Button saveAsTest_btn;
        private ComboBox limitEngPercent_comboBox;
        private Label label27;
        private Button copyAllStruct_btn;
        private Label label39;
        private Label label34;
        private Button excelExport_calTab_btn;
        private TextBox textBox1;
        private Label label40;
        private GroupBox groupBox13;
        private Button Button_Aquire;
        private Button button1;
        private Label label1;
        private NumericUpDown RowCountMax;
        private CheckBox Reading_Only_Box;
        private Button command_btn;
        private TextBox command_txt;
        private TextBox commandResult_txt;
        private CheckBox ch2Trough_chckbox;
        private CheckBox ch1Trough_chckbox;
        private CheckBox exportAverage_chckbox;
        private ListView dualSeriesListView;
        private ListView singleSeriesListView;
        private TextBox textBox2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private ComboBox toolID_comboBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private ToolStripMenuItem toolsManagerToolStripMenuItem;
        private ToolStripMenuItem testManagerToolStripMenuItem;
        private GroupBox target_groupBox;
        private Label testTarget_lbl;
        private Label label13;
        private TabPage big_reading;
        private Panel panel3;
        private Button ch1Connect_btn_bigReading;
        private GroupBox groupBox23;
        private Label label17;
        private Label label23;
        private TextBox low_bigReading_txt;
        private Label label42;
        private TextBox high_bigReading_txt;
        private GroupBox groupBox19;
        private RichTextBox target_bigReading_txt;
        private Label PassFail_lbl;
        private Label label45;
        private Button refreshCOMList_btn_bigReading;
        private ListBox comList_bigReading;
        private Label reading_bigReading_lbl;
        private ComboBox high_unitComboBox;
        private ComboBox low_unitComboBox;
        private Button upSize_btn;
        private Button downSize_btn;
        private Button continue_pauseTest_btn;
        private TextBox comment_txt;
        private Label comment_lbl;
        private ToolStripMenuItem forceAutoClearToolStripMenuItem;
        private ToolStripMenuItem openStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem autoUpdateMenuItem;
        private Button startTest_btn;
        private ToolStripMenuItem printToolToolStripMenuItem;
        private CheckBox useLimit_chkbox;
        private Label label46;
        private ComboBox toolID_SC_comboBox;
        private Label average_lbl;
        private Label label47;
        private Label label43;
        private Label label33;
        private TextBox USL_txt;
        private TextBox LSL_txt;
        private CheckBox showCMK_chkBox;
        private Label CMKVal_lbl;
        private Label CMK_lbl;
        private Label CMVal_lbl;
        private Label CM_lbl;
        private Label notNumberWarning_lbl;
        private RadioButton ch2Target_select;
        private RadioButton ch1Target_select;
        private Button stream_btn;
        private GroupBox groupBox18;
        private Button exportChart_btn;
        private RadioButton ALCCWChart_radio;
        private RadioButton AFCCWChart_radio;
        private RadioButton ALCWChart_radio;
        private RadioButton AFCWChart_radio;
<<<<<<< HEAD
=======
        private Button openOldStream_btn;
>>>>>>> 749b134cbd48190f5284306ade5d08134718bb5e
    }
}

