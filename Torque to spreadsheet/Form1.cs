using Docs.Excel;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string currentDualSerie = "Reading";
        private string currRunName1 = "Reading-CH1";
        private string currRunName2 = "Reading-CH2";
        public bool newdata = false;
        public bool aquire = false;
        public bool formActive = true;
        public int rowCount = 1;
        public string tester_Type = "";
        public BindingList<bool> dataColumns = new BindingList<bool>();
        public ArrayList checkboxes = new ArrayList();
        public static string serialData = "";
        public bool beep = true;
        public int casenum = -99;
        public static DataTable singleTable = new DataTable(), noCurrentTable = new DataTable();
        public static DataTable dualTable = new DataTable(), noCurrentDualTable = new DataTable();
        private DataTable currToolTable = new DataTable();//Contain info of currTool
        public float low = 0;
        public float high = 0;
        public float target_value = 0;
        public bool isHighLow = false;
        public bool isSerial = false;
        private string currColumn = "Reading";
        private BindingSource tableBinding = new BindingSource(), secondtableBinding = new BindingSource(), noCurrentTableBinding = new BindingSource(), dualTableBinding = new BindingSource(), noCurrentDualTableBinding = new BindingSource(), serieBinding = new BindingSource();
        private const int maxRuns = 10;//Limit how many runs the users can take
        private string secondChannelReading = "";
        private DataTable secondChannelTable = new DataTable();
        private string secondUnit, firstUnit;//decoded unit for live channel
        private float secondReading, firstReading;//decoded reading for live channel
        private bool readSuccess = false;//true if successfully read from second channel
        private string firstChannelFullCap = "";
        private bool pauseLiveReading1 = false;
        private BindingList<string> FSList = new BindingList<string>();
        private float FSReading;
        private string FSUnit;
        private const string noComConnectMessage = "No Transducer is connected";
        public static List<string> arr_dualSeries = new List<string>();
        public static List<string> arr_singleSeries = new List<string>();
        private const string tail_Channel1 = "-CH1", tail_Channel2 = "-CH2";//used to affix or remove to connecting Com to Channel1 or 2
        public static TesterControl chann1Control = new TesterControl();
        public static TesterControl chann2Control = new TesterControl();
        public static TesterControl commonChanControl = new TesterControl();
        private const int TTS = 0, smdSingle = 2, smdDual = 5;//use to set registry value for defaultTab
        private const string userRoot = "HKEY_CURRENT_USER";
        private const string CertManagerParentLoc = "C:\\Cert Manager\\Cert Manager.xls";

        //Keys for Registry
        private const string defaultSaveLoc_keyName = userRoot + "\\" + "SaveLocations";
        private const string defaultTab_keyName = userRoot + "\\" + "DefaultTabs";
        private const string defaultBigReadingFontSize_keyName = userRoot + "\\" + "BigReadingSize";
        private const string defaultAutoUpdate_keyName = userRoot + "\\" + "AutoUpdateYesNo";
        //Values for Registry
        private const string saveLoc_valueName = "saveLocation";
        private const string defaultTab_valueName = "defaultTab";
        private const string defaultBigReadingFontSize_valueName = "bigReadingFontSize";
        private const string defaultAutoUpdate_valueName = "Yes";

        private const int noTriggerGridColCount = 5, TriggerGridColCount = 6;


        private string saveLocation = "";
        private bool isMasterSave = false;
        private string colName = "";
        private const string dataLoggerPath = @"C:\datalog\win232.exe";
        private const string dataLoggerTextPath = @"data.txt";
        private static string lastPathName = @"C:\";
        private bool pauseLiveReading2 = false;
        private const int lineChart = 0;
        private const int pointChart = 1;
        private const string err_uniqueRunName = "This Name is already existed";
        private const string channel1 = "Channel 1";
        private const string channel2 = "Channel 2";
        private int xAxis = 2;
        private int yAxis = 1;
        private const int maxReadTimeOut = 100;
        private const string TTSTabName = "simple_reading", SMDSingleTabName = "read_graph_col", SMDDualTabName = "dualChannelTab", calTabName = "calibrationTab";
        private int tickInterval = 200;//start at 200, change to 2000 if no respond from tester-indicate cable is disconnected
        private const int colThreshold = 6;//when gridview columns count is greater than this number, change from fill to AllCell
        private int CH1Timercounter = 0;
        private int CH2Timercounter = 0;

        private const string autoUpdate_yesStr = "Yes", autoUpdate_noStr = "No";

        public Form1()
        {
            InitializeComponent();
            activateJetCellLicense();
            firstChannelGrid.Scroll += new ScrollEventHandler(makeSecondGridScroll);
            secondChannelGridView.Scroll += new ScrollEventHandler(makeFirstGridScroll);
        }
        //Open Virtual Keyboard, for tablet
        public static void openVirtualKeyboard(object sender, EventArgs e)
        {
            try
            {
                //Process.Start("TabTip.exe");
            }
            catch
            {
            }
        }
        private void activateJetCellLicense()
        {
            const string jetCellLicense = "S3415N-781234-21BL6E-11AC00";
            ExcelWorkbook.SetLicenseCode(jetCellLicense);
        }
        private void unifyScroll(ref DataGridView masterGrid, ref DataGridView slaveGrid)
        {
            try
            {
                if (masterGrid.FirstDisplayedScrollingRowIndex <= slaveGrid.RowCount)
                    slaveGrid.FirstDisplayedScrollingRowIndex =
                        masterGrid.FirstDisplayedScrollingRowIndex;
                else
                    slaveGrid.FirstDisplayedScrollingRowIndex = slaveGrid.RowCount - 1;
            }
            catch (Exception ex)
            {
                //Do nothing
            }
        }
        private void makeSecondGridScroll(object sender, ScrollEventArgs e)
        {
            unifyScroll(ref firstChannelGrid, ref secondChannelGridView);
        }

        private void makeFirstGridScroll(object sender, ScrollEventArgs e)
        {
            unifyScroll(ref secondChannelGridView, ref firstChannelGrid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadALLCalibrationTabSetting();
            target_groupBox.Size = new Size(486, 307);
            singleChannel_gridView.RowsAdded += Gridview1_RowsAdded;
            firstChannelGrid.RowsAdded += FirstChannelGrid_RowsAdded;
            noCurrentTableBinding.ResetBindings(false);

            //noCurrentDualTableBinding.ResetBindings(false);

            controlTabVisibility();//select visibility of each tab
            InitTimer();//init timer2 to lively display reading
            loadSettings();

            bindTable();
            comListRefresh_Click(this, e);//refresh comlist
            loadPorts();//load ports into tool strip
            TabPages.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);
            try
            {
                TabPages.SelectedIndex = Int32.Parse(getRegistryValue(defaultTab_keyName, defaultTab_valueName));
            }
            catch
            {
                TabPages.SelectedIndex = 0;
            }

            changeWinSize(TabPages.SelectedTab.Name);//set default Win Size

            singleTable.Columns.Add("Point", typeof(int));//default first column of table for our Single Channel is always Point
            createNewSerie_SingleChannel(currColumn);//Add new currColumn="Reading" to Single Channel dataTable when App loads
            PreventGridSort(ref masterGridView);//prevent masterGridView from being sortable by Users
            initSecondChannelTable();//initiate Second Channel table to store data from Second Channel only (not both Channels)
            initDualTable();//initiate dualTable to store BOTH channel 1 and 2 Readings

            //Show Series on checked list for single Channel
            arr_singleSeries = getListOfSeriesName(singleChart);
            AddSerieToCheckList(ref singleSeriesListView, arr_singleSeries);
            updateListViewColor(ref singleSeriesListView, singleChart);//update color for seriesListView

            //Show Series on checked list for dual Channel
            AddSerieToCheckList(ref dualSeriesListView, arr_dualSeries);
            //update color for seriesListView
            updateListViewColor(ref dualSeriesListView, dualChart);

            Taylor_settings();//Misc. Settings from Taylor's old Code.
            PreventGridSort(ref gridview);
            PreventGridSort(ref singleChannel_gridView);
            PreventGridSort(ref masterGridView);
            updateDualCurrentRunAndChanLabel();
            updateCurrentRunAndSingleChanLabel(currColumn);//Update Label for CurrentRunText
            setDefaultRegistries();

            //Auto update if it is turned on-Added 8/9/2017
            if (getRegistryValue(defaultAutoUpdate_keyName, defaultAutoUpdate_valueName) == autoUpdate_yesStr)
            {
                autoUpdateMenuItem.Checked = true;
                InstallUpdateSyncWithInfo(false);//try to check for update, but no need to show message if no update found
            }
            else
            {
                autoUpdateMenuItem.Checked = false;
            }
            startTest_btn.Location = new Point(909, 150);
            menuStrip1.Focus();
            //Runbgw();
        }

        //update the Pass Fail indication on Big Reading Tab
        private void updateBigReadingPassFail(float ch1Reading)
        {
            string returnPassFailStr = "";
            float target = 0, lowLimit, highLimit, highLimitCriteria = 0, lowLimitCriteria = 0;
            int lowSign = -1, highSign = 1;
            bool istargetConvert, ishighConvert, islowConvert;
            //Parse in target, low, high
            try
            {
                target = Single.Parse(target_bigReading_txt.Text);
                istargetConvert = true;
            }
            catch
            {
                istargetConvert = false;
            }
            try
            {
                lowLimitCriteria = Single.Parse(low_bigReading_txt.Text);
                islowConvert = true;
            }
            catch
            {
                islowConvert = false;
            }
            try
            {
                highLimitCriteria = Single.Parse(high_bigReading_txt.Text);
                ishighConvert = true;
            }
            catch
            {
                ishighConvert = false;
            }

            if (istargetConvert == true)
            {
                if (islowConvert == true)
                {
                    if (ishighConvert == false)
                    {//from low to target
                        lowLimit = calculatelowHighLimit(target, lowLimitCriteria, lowSign, low_unitComboBox.SelectedIndex);
                        highLimit = target;
                    }
                    else//from low to high
                    {
                        lowLimit = calculatelowHighLimit(target, lowLimitCriteria, lowSign, low_unitComboBox.SelectedIndex);
                        highLimit = calculatelowHighLimit(target, highLimitCriteria, highSign, high_unitComboBox.SelectedIndex);
                    }
                }
                else//fail to convert Low
                {
                    if (ishighConvert == true)
                    {//target to high
                        lowLimit = target;
                        highLimit = calculatelowHighLimit(target, highLimitCriteria, highSign, high_unitComboBox.SelectedIndex);
                    }
                    else//Need to be equal target
                    {
                        lowLimit = target;
                        highLimit = target;
                    }
                }

                //check whether reading is within lowLimit and highLimit
                returnPassFailStr = checkIfReadingWithinLimit(ch1Reading, lowLimit, highLimit);
            }
            PassFail_lbl.Text = returnPassFailStr;
        }
        //calculate low or high limit (low is -1 high is +1 for posOrneg) for bigReading tab
        //isPercent: 0 is percent, 1 is eng unit
        private float calculatelowHighLimit(float target, float limitOffset, int posOrneg, int isPercent)
        {
            float returnVal;
            if (isPercent == 0)//calculate by %
            {
                returnVal = target + (target * limitOffset / 100) * posOrneg;
            }
            else//calculate by Eng Unit
            {
                returnVal = limitOffset;
            }
            return returnVal;
        }
        private const string passStr = "Pass", failStr = "Fail";
        //Return Pass or Fail
        private string checkIfReadingWithinLimit(float readingFL, float lowFL, float highFL)
        {
            if ((readingFL >= lowFL) && (readingFL <= highFL))
                return passStr;
            else
            {
                return failStr;
            }
        }
        private void FirstChannelGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            firstChannelGrid.FirstDisplayedScrollingRowIndex = firstChannelGrid.RowCount - 1;
        }

        private void Gridview1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            singleChannel_gridView.FirstDisplayedScrollingRowIndex = singleChannel_gridView.RowCount - 1;
        }


        //Set all default values for our Regitries
        private void setDefaultRegistries()
        {
            //Set Default Save Loc to Program Directory if it hasn't been set before
            if (getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName) == "")
                setRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));//Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

            setRegistryValue(defaultTab_keyName, defaultTab_valueName, TTS.ToString());

            //Set autoUpdate to Yes if not set yet
            if (getRegistryValue(defaultAutoUpdate_keyName, defaultAutoUpdate_valueName) == "")
                setRegistryValue(defaultAutoUpdate_keyName, defaultAutoUpdate_valueName, autoUpdate_yesStr);
        }

        //Get value for specified Registry
        private string getRegistryValue(string keyName, string valueName)
        {
            string registryValue = (string)Registry.GetValue(keyName, valueName, "");
            return registryValue;
        }

        //Set value to Registry
        private void setRegistryValue(string keyName, string valueName, string value)
        {
            Registry.SetValue(keyName, valueName, value);
        }

        private System.Drawing.Color readingColor = Color.Blue;
        private void loadSettings()
        {
            //PreventGridSort(ref noCurrDualMasterGrid);
            noCurrDualMasterGrid.AutoGenerateColumns = true;
            //seriesListView.ItemCheck += new ItemCheckEventHandler(SeriesListView_ItemCheck);

            //enableSoundsToolStripMenuItem.Checked = Properties.Settings.Default.Enable_sounds_setting;
            autoConnectToolStripMenuItem.Checked = Properties.Settings.Default.Auto_Connect;
            showALLCOMAvailableToolStripMenuItem.Checked = false;//Show COM List with FullScale or just COM
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked = Properties.Settings.Default.ON_Top_Setting;
            includeDateToolStripMenuItem.Checked = Properties.Settings.Default.DateStamp_Setting;
            includeTimeToolStripMenuItem.Checked = Properties.Settings.Default.TimeStamp_Setting;
            RowCountMax.Value = Properties.Settings.Default.rowcountmax;
            Reading_Only_Box.Checked = Properties.Settings.Default.readings_only;
            singleChannel_gridView.ReadOnly = false;
            singleChannel_gridView.EditMode = DataGridViewEditMode.EditOnEnter;
            gridview.ReadOnly = false;
            gridview.EditMode = DataGridViewEditMode.EditOnEnter;
            firstChannelGrid.ReadOnly = false;
            firstChannelGrid.EditMode = DataGridViewEditMode.EditOnEnter;
            masterGridView.ReadOnly = true;
            //masterGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            high_percent.Checked = true;
            low_percent.Checked = true;
            draw_limit.Enabled = false;

            //change color of Reading Color and Unit Color
            DataTTS_lbl.ForeColor = readingColor;
            Label_Data1.ForeColor = readingColor;
            DataSMDSingle_lbl.ForeColor = readingColor;
            dataCh1DualChanTab_lbl.ForeColor = readingColor;
            dataCh2DualChTab_lbl.ForeColor = readingColor;

            unitTTS_lbl.ForeColor = readingColor;
            unitSingleCH_lbl.ForeColor = readingColor;
            unitCH1DualCHTab_lbl.ForeColor = readingColor;
            unitCH2DualCHTab_lbl.ForeColor = readingColor;
            updateFirstChannelLive(0, "");
            updateSecondChannelLive(0, "");

            updatexyAxisButtonText();

            if (autoConnectToolStripMenuItem.Checked)
            {
                startMinimizedToolStripMenuItem.Enabled = true;
                startMinimizedToolStripMenuItem.Checked = Properties.Settings.Default.Start_Minimized;
            }
            label28.Text = "(Drag to\nchange Order)";
            low_unitComboBox.SelectedIndex = 0;
            high_unitComboBox.SelectedIndex = 0;

            //set size for bigReading
            string tempRegistry = getRegistryValue(defaultBigReadingFontSize_keyName, defaultBigReadingFontSize_valueName);
            if (tempRegistry != "")
            {
                try
                {
                    float bigReadingFontSize = Single.Parse(tempRegistry);
                    reading_bigReading_lbl.Font = ChangeFontSize(reading_bigReading_lbl.Font, bigReadingFontSize);
                }
                catch { }
            }
            return;
        }

        //this method control which tabs is visible and which one isn't
        /*
        simple_reading
        simple_col
        read_graph_col
        big_reading
        big_graph 
        dualChannelTab*/
        private void controlTabVisibility()
        {

            HideTabPage(simple_col);
            //HideTabPage(big_reading);
            HideTabPage(big_graph);

            //HideTabPage(simple_reading);
            //HideTabPage(read_graph_col);
            //HideTabPage(dualChannelTab);
            //HideTabPage(calibrationTab);
        }

        //getSerialList is called when User refresh comList, to get serial Number of connected tester
        private void getSerialList()
        {
            string fullscale = "";
            FSList.Clear();
            foreach (string com in testerList)
            {
                if (serialPort1.PortName != com)
                    serialPort1.PortName = com;
                try
                {
                    if (serialPort1.IsOpen == false)
                        serialPort1.Open();
                    fullscale = write_command("?F;", serialPort1);
                    commonChanControl = new TesterControl();
                    commonChanControl.setModeAndUnitClass(write_command("?M;", serialPort1), write_command("?C;", serialPort1), write_command("?U;", serialPort1));
                    serialPort1.Close();
                    serialPort1.PortName = "COM101";
                }
                catch
                {
                    serialPort1.Close();
                    fullscale = "";
                }
                resetFSReading();
                if (fullscale != "")
                {
                    decodeMessage(fullscale, commonChanControl.getcurrUnitClass(), 0);
                }
                if ((FSReading != 0) && (FSUnit != ""))
                    FSList.Add(com + ": " + FSReading + " " + FSUnit);
            }
            bindcomList(FSList);//bind FullScale to all the ComList
        }
        //bind list of all FSList box with FSList
        private void bindcomList(BindingList<string> comListToBind)
        {
            comList.DataSource = comListToBind;
            comList_bigReading.DataSource = comListToBind;
            comList2.DataSource = comListToBind;
            comList3.DataSource = comListToBind;
            comList4.DataSource = comListToBind;
        }
        //Prevent passed in gridview from being sortable by user
        private void PreventGridSort(ref DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        ///////////////////Taylors Code for changing GUI behaviors////////////////////////////////////
        private void Taylor_settings()
        {
            try
            {
                serialPort1.PortName = toolStripDropDownButton1.DropDownItems[0].Text; //sets port name to first item in list as default
                serialPort2.PortName = serialPort1.PortName;
            }
            catch
            {
                toolStripStatusLabel2.Text = " Status: Warning! No Serial Ports detected!"; //displays when no serial ports are present
            }
            foreach (ToolStripItem s in toolStripDropDownButton1.DropDownItems)
            {
                if (s.Text == Properties.Settings.Default.Com_Port_setting) //search list of avaliable ports for the previously saved port
                {
                    try
                    {
                        serialPort1.PortName = s.Text; //set port name to previously saved port, if found
                    }
                    catch
                    {
                        //do nothing
                    }
                }
            }

            toolStripStatusLabel1.Text = "Port: " + serialPort1.PortName; //set port label to current port

            if (autoConnectToolStripMenuItem.Checked)
            {
                opencloseFirstCOM(ref comList);
            }
            if (Properties.Settings.Default.Spreadsheet_mode)
            {
                spreadSheetActivate();
            }

            if (Properties.Settings.Default.Start_Minimized && Properties.Settings.Default.Spreadsheet_mode) //if start minimized and spreadsheet mode are active, minimize at startup
            {

                this.WindowState = FormWindowState.Minimized;
                // notifyIcon.Visible = true;

            }
        }
        /// <summary>
        /// load available ports into toolstripdropdown
        /// </summary>
        private void loadPorts()
        {
            toolStripDropDownButton1.DropDownItems.Clear();
            foreach (string port in System.IO.Ports.SerialPort.GetPortNames())
            {
                toolStripDropDownButton1.DropDownItems.Add(port);   //add each avaliable port to the dropdown list             
            }
        }

        private void autoConnectToolStripMenuItem_Click(object sender, EventArgs e) //if the auto connect option is clicked in the menu strip
        {
            Properties.Settings.Default.Auto_Connect = autoConnectToolStripMenuItem.Checked; //set the persistent setting to the item's checked state
            startMinimizedToolStripMenuItem.Enabled = autoConnectToolStripMenuItem.Checked; //enable the start minimized option if auto connect is checked

        }

        private void startMinimizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Start_Minimized = startMinimizedToolStripMenuItem.Checked; //save the start minimized option if it is clicked
        }

        private void startMinimizedToolStripMenuItem_EnabledChanged(object sender, EventArgs e)
        {

            if (startMinimizedToolStripMenuItem.Enabled == false) //if the option was just disabled, reset things
            {
                startMinimizedToolStripMenuItem.Checked = false; //reset the checked state for this session
                Properties.Settings.Default.Start_Minimized = false; //reset the checked state setting 
            }
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
            Properties.Settings.Default.ON_Top_Setting = alwaysOnTopToolStripMenuItem.Checked;
        }
        private void enableSoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Enable_sounds_setting = enableSoundsToolStripMenuItem.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
            notifyIcon.Dispose();
        }

        //Call this method to write datatable values to Console for debugging purpose
        public void DebugTable(DataTable table)
        {
            Debug.WriteLine("--- DebugTable(" + table.TableName + ") ---");
            int rowsCount = table.Rows.Count;
            int columnsCount = table.Columns.Count;

            // Header
            for (int i = 0; i < table.Columns.Count; i++)
            {
                string s = table.Columns[i].ToString();
                Debug.Write(String.Format("{0,-20} | ", s));
            }
            Debug.Write(Environment.NewLine);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Debug.Write("---------------------|-");
            }
            Debug.Write(Environment.NewLine);

            // Data
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow row = table.Rows[i];
                for (int j = 0; j < columnsCount; j++)
                {
                    string s = row[j].ToString();
                    if (s.Length > 20) s = s.Substring(0, 17) + "...";
                    Debug.Write(String.Format("{0,-20} | ", s));
                }
                Debug.Write(Environment.NewLine);
            }
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Debug.Write("---------------------|-");
            }
            Debug.Write(Environment.NewLine);
        }


        //////////////////////End of Taylors Code for changing GUI behaviors////////////////////////
        //add a serie to checklist
        private void bindSecondChannelTable()
        {
            secondtableBinding.DataSource = secondChannelTable;
            secondChannelGridView.DataSource = secondtableBinding;
        }

        //Update back color of listview with series color
        private void updateListViewColor(ref ListView listView, Chart thisChart)
        {
            thisChart.ApplyPaletteColors();
            foreach (ListViewItem listItem in listView.Items)
            {
                try
                {
                    listItem.ForeColor = thisChart.Series[listItem.Text].Color;
                }
                catch
                {
                    //Do nothing    
                }
            }
        }
        //rename an item in listView Control
        private void renameSerieInListView(string oldName, string newName, ref ListView listView)
        {
            try
            {
                listView.Items[oldName].Text = newName;
                listView.Items[oldName].Name = newName;
            }
            catch { }
        }
        private void AddSerieToCheckList(ref ListView listView, List<string> updatedItemList)
        {
            //Add New Serie from arr_dualSeries to checkbox
            foreach (string newItem in updatedItemList)
            {
                //Check to see if newitem is already existed in listview
                bool okToAdd = true;
                foreach (ListViewItem listItem in listView.Items)
                {
                    if (listItem.Text == newItem)
                    {
                        okToAdd = false;
                    }
                }
                //If not exist, add to listview
                if (okToAdd)
                {
                    var item = new ListViewItem();
                    item.Checked = true;
                    item.Name = newItem;
                    item.Text = newItem;

                    listView.Items.Add(item);
                }
            }
        }

        //update the text for xyAxis_button
        private void updatexyAxisButtonText()
        {
            if (xAxis == 1)
                xySwitch_button.Text = "X     \u27F7     Y";
            else
                xySwitch_button.Text = "Y     \u27F7     X";
        }
        //remove a serie from checkbox
        private void removeSerieFrCheckList(string toDelete, ref ListView checkedList)
        {
            try
            {
                int indexToDelete = -1;
                foreach (ListViewItem itemList in checkedList.Items)
                {
                    if (itemList.Text == toDelete)
                        indexToDelete = itemList.Index;
                }

                if (indexToDelete >= 0)
                    checkedList.Items.RemoveAt(indexToDelete);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to delete selected Serie from Graph Checked List because of error: " + exception);
            }
        }
        private void initSecondChannelTable()
        {
            secondChannelTable = new DataTable();
            secondChannelTable.Columns.Add("Reading", typeof(float));
            secondChannelTable.Columns.Add("Unit", typeof(string));
            //bind second channel gridview to second table
            bindSecondChannelTable();
        }

        //bind mastergridview to Datatable table, and nocurrentTable to mastergrid_nocurrent
        private void bindTable()
        {
            //for debug purpose only. masterGridView is not visible to User.
            tableBinding.DataSource = singleTable;
            masterGridView.DataSource = tableBinding;

            //bind noCurrentTable to masterGrid_noCurrent. This grid is visible to user
            noCurrentTableBinding.DataSource = noCurrentTable;
            masterGrid_noCurrent.DataSource = noCurrentTableBinding;

        }

        //Control Visibility of tab page
        private void HideTabPage(TabPage tp)
        {
            if (TabPages.TabPages.Contains(tp))
                TabPages.TabPages.Remove(tp);
        }


        private void ShowTabPage(TabPage tp)
        {
            ShowTabPage(tp, TabPages.TabPages.Count);
        }

        private void ShowTabPage(TabPage tp, int index)
        {
            if (TabPages.TabPages.Contains(tp)) return;
            InsertTabPage(tp, index);
        }

        private void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > TabPages.TabCount)
                throw new ArgumentException("Index out of Range.");
            TabPages.TabPages.Add(tabpage);
            if (index < TabPages.TabCount - 1)
                do
                {
                    SwapTabPages(tabpage, (TabPages.TabPages[TabPages.TabPages.IndexOf(tabpage) - 1]));
                }
                while (TabPages.TabPages.IndexOf(tabpage) != index);
            TabPages.SelectedTab = tabpage;
        }
        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            if (TabPages.TabPages.Contains(tp1) == false || TabPages.TabPages.Contains(tp2) == false)
                throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");

            int Index1 = TabPages.TabPages.IndexOf(tp1);
            int Index2 = TabPages.TabPages.IndexOf(tp2);
            TabPages.TabPages[Index1] = tp2;
            TabPages.TabPages[Index2] = tp1;

        }
        //Ping passed in serialPort, limit UI access to Tester
        private void pingTester(SerialPort thisport)
        {
            if (thisport.IsOpen)
                write_command("Z", thisport);
        }
        //Unping passed in serialPort, restore UI access to Tester
        private void unpingTester(SerialPort thisPort)
        {
            if (thisPort.IsOpen)
                write_command("z", thisPort);
        }


        //change the size of window when different tab is selected
        //simple_reading
        //simple_col
        //read_graph_col
        //big_reading
        //big_graph
        private void changeWinSize(string currTab)
        {
            switch (currTab)
            {
                case TTSTabName:
                    this.Size = new Size(623, 800);
                    this.Text = "Torque To Spreadsheet";
                    unpingTester(serialPort1);//restore UI to Tester
                    break;
                case "simple_col":
                    this.Size = new Size(967, 576);
                    break;
                case SMDSingleTabName:
                    this.Size = new Size(1475, 943);
                    this.Text = "SMD Single";
                    pingTester(serialPort1);//Lock UI from Tester
                    break;
                case "big_reading":
                    this.Size = new Size(1305, 954);
                    break;
                case "big_graph":
                    this.Size = new Size(1305, 1100);
                    break;
                case SMDDualTabName:
                    this.Size = new Size(1475, 943);
                    this.Text = "SMD  Dual";
                    pingTester(serialPort1);//Lock UI from Tester
                    pingTester(serialPort2);//Lock UI from Tester
                    break;
                case calTabName:
                    this.Size = new Size(1475, 943);
                    this.Text = "Calibration";
                    pingTester(serialPort1);//Lock UI from Tester
                    pingTester(serialPort2);//Lock UI from Tester
                    break;
                default:
                    this.Size = new Size(792 + 130, 338);
                    break;

            }
        }
        //Pass in GridView, return Current Row of the Grid
        private int getCurrentRowOfGrid(ref DataGridView thisGrid)
        {
            int thisRow = -1;
            if (overwriteDataAtCursorToolStripMenuItem.Checked == false)
                thisRow = thisGrid.RowCount - 1;
            else
                thisRow = thisGrid.CurrentRow.Index;

            //Check if this is the last Row of Data in 1stChannel Grid or not
            //If it is, 2nd channel grid also capture on last Line of data
            if (thisRow == thisGrid.RowCount - 2) //-2 because we want to get the row right before New Row
                is1stChanRow_LastRow = true;
            else
            {
                is1stChanRow_LastRow = false;
            }
            return thisRow;
        }
        //get the Focused Row on 1st Channel Gridview, passed in currTab to detetermine which 1st Channel Grid to use
        private int getFocusedRowFirstChannel(string currTab)
        {
            int returnIndex = -1;
            try
            {
                switch (currTab)
                {
                    case "read_graph_col":
                        returnIndex = getCurrentRowOfGrid(ref singleChannel_gridView);
                        break;
                    case "dualChannelTab":
                        returnIndex = getCurrentRowOfGrid(ref firstChannelGrid);
                        break;
                    default:
                        returnIndex = 0;
                        break;
                }
            }
            catch (Exception exception)
            {
                returnIndex = 0;//Return Index 0 of first Channel if firstChannel GridView doesn't have focus
            }
            return returnIndex;
        }

        //event handler for selecting different tab
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            string currTab = current.Name;
            changeWinSize(currTab);
            menuStrip1.Focus();
        }

        //if background worker hasnt been opened then open and run it
        private void Runbgw()
        {
            
            if (backgroundWorker1.IsBusy == false)
                backgroundWorker1.RunWorkerAsync(); //run background worker
                
        }

        //if passed in ComtoDisconnect contain -Channel1 or -Channel2(depends on channelNumber passed in), then remove that part
        //This method is called after a Comlist is closed
        private BindingList<string> removeChannelfromComList(int channelNumber, BindingList<string> list, int index)
        {
            string channel = "DMSOMDJNFSDSNDKJW";//Bogus string, just for the heck of it
            if (channelNumber == 1)
                channel = tail_Channel1;
            else if (channelNumber == 2)
                channel = tail_Channel2;
            list[index] = list[index].Replace(channel, "");

            return list;
        }

        private void updateDisconnectCOMList(string Com, int channel)
        {
            for (int index = 0; index < comList.Items.Count; index++)
            {
                if (extractCOM(FSList[index]) == Com)
                {
                    FSList = removeChannelfromComList(channel, FSList, index);
                    bindcomList(FSList);
                }
            }
        }
        //Open or close 1st Com
        private void opencloseFirstCOM(ref ListBox list)
        {
            string displaySNandFS = "";
            string firstChannelSerialNum = "";
            bool readCapSuccess;
            pauseLiveReading1 = true;
            try
            {
                if (list.Items.Count > 0)
                {
                    string currentPort = extractCOM(list.SelectedItem.ToString());
                    bool portcheck = currentPort.Equals(serialPort1.PortName);
                    toolStripStatusLabel1.Text = "Port: " + currentPort;

                    //if serial port is not open, OR current selected port is same as the SerialPort1
                    if ((serialPort1.IsOpen == false) || (portcheck == false))
                    {
                        //if selecting port is not same as port 2 or port 2 is not opened, Open port 1
                        if ((!(currentPort == serialPort2.PortName)) || (!serialPort2.IsOpen))
                        {
                            openport(currentPort);
                            changeWinSize(TabPages.SelectedTab.Name);//Call this to ping or unping tester

                            //request Com serial number from SerialPort1
                            firstChannelSerialNum = write_command("?S;", serialPort1);
                            //request Com Full Scale
                            firstChannelFullCap = write_command("?F;", serialPort1);

                            resetFSReading();

                            //Initiate chann1Control

                            chann1Control = new TesterControl();
                            string modeMsg = "", CapMsg = "", UnitMsg = "";
                            modeMsg = write_command("?M;", serialPort1);
                            CapMsg = write_command("?C;", serialPort1);
                            UnitMsg = write_command("?U;", serialPort1);
                            chann1Control.setModeAndUnitClass(modeMsg, CapMsg, UnitMsg);
                            //set the currUnitMode and currUnitClass

                            decodeMessage(firstChannelFullCap, chann1Control.getcurrUnitClass(), 0);
                            //decode query got back from asking for Full Scale, then pass to FSReading and FSUnit-indicated by passing in 0 value

                            if (FSReading == 0) //if FSReading is 0, that means fail to read FS of tester
                                readCapSuccess = false;
                            else
                                readCapSuccess = true;

                            displaySNandFS = serialPort1.PortName + ":";
                            if (readCapSuccess)
                            {
                                displaySNandFS += " " + FSReading + " " + FSUnit;

                            }
                            displaySNandFS += " connected";
                            //end appending

                            //update on display to show Com, SN and FS of tester that are connecting
                            showComConnect_FirstChan(displaySNandFS);
                            FSList[list.SelectedIndex] += tail_Channel1;
                            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
                        }
                        else
                            MessageBox.Show(
                                "Channel 2 is currently connecting to this COM.\nPlease free the selecting COM first");
                    }
                    else
                    {
                        closeport(currentPort);
                        serialPort1.PortName = "COM101"; //assign bogus COM name after closing port.
                        showComConnect_FirstChan(noComConnectMessage);
                    }
                }
            }
            catch
            {
                if (serialPort1.IsOpen)
                    showComConnect_FirstChan(serialPort1.PortName + " is connected");
                else
                {
                    showComConnect_FirstChan(noComConnectMessage);
                }
                pauseLiveReading1 = false;
            }
            pauseLiveReading1 = false;
        }
        //Open or close 2nd Com for Dual channel
        private void opencloseSecondCom(string currentPort, ListBox list)
        {
            bool readCapSuccess;
            string secondChannelSerialNum = "";
            string secondChannelFS = "";
            string displaySNandFS = "";
            bool portcheck = currentPort.Equals(serialPort2.PortName);
            toolStripStatusLabel1.Text = "Port: " + currentPort;
            if ((serialPort2.IsOpen == false) || (portcheck == false))
            {//if serial port is not open, OR current selected port is not is different from the SerialPort2
                if ((serialPort1.PortName == currentPort) && (serialPort1.IsOpen == false))
                {
                    serialPort1.PortName = "COM101";
                }
                if (currentPort != serialPort1.PortName)
                {
                    openSecondport(currentPort);
                    secondChannelSerialNum = write_command("?S;", serialPort2);
                    secondChannelFS = write_command("?F;", serialPort2);

                    resetFSReading();
                    //Initiate chann2Control
                    chann2Control = new TesterControl();
                    string modeMsg = "", CapMsg = "", UnitMsg = "";
                    modeMsg = write_command("?M;", serialPort2);
                    CapMsg = write_command("?C;", serialPort2);
                    UnitMsg = write_command("?U;", serialPort2);

                    chann2Control.setModeAndUnitClass(modeMsg, CapMsg, UnitMsg);//set the currUnitMode and currUnitClass

                    decodeMessage(secondChannelFS, chann2Control.getcurrUnitClass(), 0);//decode query got back from asking for Full Scale, then pass to FSReading and FSUnit-indicated by passing in 0 value for 2nd param

                    if (FSReading == 0)//if FSReading is 0, that means fail to read FS of tester
                        readCapSuccess = false;
                    else
                        readCapSuccess = true;

                    /*if (secondChannelSerialNum.Length > 0)
                    {
                        displaySNandFS = serialPort2.PortName + ": S/N " + secondChannelSerialNum;
                    }
                    else*/
                    displaySNandFS = serialPort2.PortName + ":";
                    if (readCapSuccess)
                        displaySNandFS += " " + FSReading + " " + FSUnit;
                    displaySNandFS += " connected";
                    showComConnect_SecondChan(displaySNandFS);
                    FSList[list.SelectedIndex] += tail_Channel2;
                }
                else
                    MessageBox.Show("Channel 1 is currently connecting to this COM.\nPlease free the selecting COM first");
            }
            else
            {
                closeSecondport(currentPort);
                serialPort2.PortName = "COM102";//assign bogus COM name after closing port.
                showComConnect_SecondChan(noComConnectMessage);
            }
        }
        //Display the serial Number that connect to Channel1.
        private void showComConnect_FirstChan(string message)
        {
            COMconnect.Text = message;
            COMconnect2.Text = message;
            firstComConnect.Text = message;
            ch1ConnectLabel_calTab.Text = message;
        }
        //Display the serial Number that connect to Channel2.
        private void showComConnect_SecondChan(string message)
        {
            secondComConnect.Text = message;
            ch2ConnectLabel_calTab.Text = message;
        }
        private string extractCOM(string comAndSN)
        {
            string com = "";
            com = comAndSN.Substring(0, comAndSN.IndexOf(":"));
            return com;
        }

        private void resetFSReading()
        {
            FSReading = 0;
            FSUnit = "";
        }

        private void Button_Serial_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList);
            channel1MenuButtonUpdate();
        }

        private void spreadSheetActivate()
        {
            if (aquire)
            {
                aquire = false;
                Button_Aquire.Text = "Activate Spreadsheet Transfer";
                button3.Text = "Activate Spreadsheet Transfer";
                button9.Text = "Activate Spreadsheet Transfer";
                SpreadSheetModeLabel.Text = "Deactivated";
                Properties.Settings.Default.Spreadsheet_mode = false;
            }
            else
            {
                aquire = true;
                Button_Aquire.Text = "Stop Spreadsheet Transfer";
                button3.Text = "Stop Spreadsheet Transfer";
                button9.Text = "Stop Spreadsheet Transfer";
                SpreadSheetModeLabel.Text = "Activated";
                Properties.Settings.Default.Spreadsheet_mode = true;
            }
        }

        private void Button_Aquire_Click(object sender, EventArgs e) //user clicks the activate spreadsheet transfer button
        {
            spreadSheetActivate();
        }

        private bool checkrowValid(string[] row)                
        {
            float f;
            bool datavalid = true;
            if (float.TryParse(row[0], out f) == false)
            {
                datavalid = false;
            }
            else
            {
                if ((row.Length > 2) && (float.TryParse(row[1], out f) == false))
                    datavalid = false;
            }
            return datavalid;
        }

        private bool is1stChanRow_LastRow = false;

        //Add row to singleChannel_gridview without update chart
        //Added 8/27/17
        private void addRowWithoutUpdateChart(string[] row)
        {
            //check if row passed in contains good reading (not mix string with float)
            if (checkrowValid(row) == false)
                return;

            //if data length is 3, replace row[0] with sample#
            if (row.Length > 2)
                row[0] = singleChannel_gridView.RowCount.ToString();

            //parse data to dataToAdd to add to gridview
            string[] dataToAdd = new string[3];
            if (row.Length > 2)//row has 3 or more datas
            {
                dataToAdd = new string[] { row[0], row[1], row[2] };
            }
            else if (row.Length > 1)//row has 2 datas
            {
                float tempFl;

                if (float.TryParse(row[0], out tempFl) == true)
                {
                    //if both row[0] and [1] are float, use only row[1]
                    if (float.TryParse(row[1], out tempFl) == true)
                        dataToAdd = new string[] { gridview.RowCount.ToString(), row[1], "" };
                    else //else if only row[0] a is float then use row[0] as reading and row[1] as unit
                        dataToAdd = new string[] { gridview.RowCount.ToString(), row[0], row[1] };
                }
            }
            else//row only has 1 data
            {
                dataToAdd = new string[] { singleChannel_gridView.RowCount.ToString(), row[0], "" };
            }
            //}
            //assign rowIndex to add to gridview
            int rowIndex = getFocusedRowFirstChannel(TabPages.SelectedTab.Name);

            //Check if this is the last Row of Data in 1stChannel Grid or not
            //If it is, 2nd channel grid also capture on last Line of data
            if (rowIndex == singleChannel_gridView.RowCount - 2) //-2 because we want to get the row right before New Row
                is1stChanRow_LastRow = true;
            else
            {
                is1stChanRow_LastRow = false;
            }
            //add row to each first channel gridview
            try
            {
                //addRowToGridAtIndex(ref gridview, dataToAdd, rowIndex);
                addRowToGridAtIndex(ref singleChannel_gridView, dataToAdd, rowIndex);
                addRowToGridAtIndex(ref firstChannelGrid, dataToAdd, rowIndex);

                removeRowFrGridAtIndex(ref singleChannel_gridView, rowIndex + 1);
                //removeRowFrGridAtIndex(ref gridview, rowIndex+1);
                removeRowFrGridAtIndex(ref firstChannelGrid, rowIndex + 1);

                //updateSampleNuminGrid(ref gridview,rowIndex);
                updateSampleNuminGrid(ref singleChannel_gridView, rowIndex);
                updateSampleNuminGrid(ref firstChannelGrid, rowIndex);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        //Add new row to gridview
        //Changed 8/27/17
        public void addrow(string[] row)
        {
            addRowWithoutUpdateChart(row);
            //updateTableandChart(ref chart1, singleChannel_gridView);
            updateTableandChart(ref singleChart, singleChannel_gridView);
        }

        //remove row at index from passed in gridview
        private void removeRowFrGridAtIndex(ref DataGridView thisGrid, int rowIndex)
        {
            if (rowIndex >= 0)
            {
                try
                {
                    thisGrid.Rows.RemoveAt(rowIndex);
                }
                catch { }
            }
        }
        //add string[] data to gridview at specific index
        private void addRowToGridAtIndex(ref DataGridView thisGrid, string[] data, int rowIndex)
        {
            try
            {
                if ((thisGrid.Rows[rowIndex].IsNewRow == true) || (rowIndex < 0))
                    thisGrid.Rows.Add(data);
                else
                {
                    thisGrid.Rows.Insert(rowIndex, data);
                }

            }
            catch (Exception ex)
            {
                //Do nothing, if data parse in are invalid then just dont post it. 
            }
        }

        //Send parsed in data to Keyboard output
        private void sendDataToKeyboardOutPut(string[] data)
        {
            for (int i = 0; i < data.Length; i++) //for each string in data
            {
                if (data[i][0] == '-' || data[i][0] == '+' || data[i][0] == '=') //if the first char in any cell is a negative, plus, or equals sign, excel freaks out
                {
                    data[i] = " " + data[i]; //this adds a space before the data value if the first char is a neg or plus sign, to prevent excel from thinking its a formula
                }
            }
            string[] stampformats = new string[] { "d", "T", "G" };
            int stamp = Convert.ToInt16(includeDateToolStripMenuItem.Checked) * 1 + Convert.ToInt16(includeTimeToolStripMenuItem.Checked) * 2;

            DateTime dt = DateTime.Now;

            if (Reading_Only_Box.Checked) //if we only want units, we may still want timestamp
            {
                if (stamp > 0) //if we want timestamp, add it and the units to a re-initialized data array
                {
                    data = new string[] { dt.ToString(stampformats[stamp - 1]), checkarrayLength(data) };//checkarrayLength(data) return only the reading number
                }
                else
                {
                    data = new string[] { checkarrayLength(data) }; //or just add the data
                }
            }
            else if (Reading_Only_Box.Checked == false && stamp > 0) //keep all the current data and add a time stamp
            {
                string[] data_temp = data; //store data in a new array

                data = new string[data.Length + 1]; //re-initialize data one larger

                data[0] = (dt.ToString(stampformats[stamp - 1])); //insert time stamp as the first value

                for (int i = 0; i < data_temp.Length; i++)
                {
                    data[i + 1] = data_temp[i]; //put old data back into data
                }

            }
            foreach (string s in data) //escape all characters that need it
            {
                string temp;
                temp = s.Replace("+", "{+}");
                temp = temp.Replace("%", "{%}");
                temp = temp.Replace("~", "{~}");
                temp = temp.Replace("(", "{(}");
                temp = temp.Replace(")", "{)}");
                temp = temp.Replace("^", "{^}");//sendkeys can't do these characters without this

                SendKeys.Send(temp); //Send the data

                if (s != data[data.Length - 1]) //if it is not the last item to send
                { SendKeys.Send("{TAB}"); } //then send a tab to move over one cell

            }
            if (rowCount < RowCountMax.Value)  //after the last item is sent (above) check if we are doing
            {                               //multiple items per row, and send a tab if we are not at
                SendKeys.Send("{TAB}");     //the last item
                rowCount++;

            }
            else
            {
                SendKeys.Send("{ENTER}");   //or send an <Enter> if we are at the last item
                rowCount = 1;

            }
        }
        //displays data and sends it as keyboard input
        private void process_data(string serialData)
        {
            string[] data;
            newdata = false;
            try
            {
                data = huy_parseData(serialData); //parse the serial data


                //Add new row to gridview
                int dataLen = data.Length;
                string[] tempData = new string[dataLen];
                data.CopyTo(tempData, 0);
                addrow(tempData);

                testerType.Text = tester_Type;
                if (tester_Type == "Millivolt Tester" && checkBox_millivolt.Checked)
                {
                    string[] data2 = new string[2] { data[2], data[3] };
                    data = data2;
                }

                //If Transfer to spreadsheet active and this form is inactive
                if (aquire && formActive == false)
                {
                    sendDataToKeyboardOutPut(data);
                }
            }
            catch (System.Exception excep) { }

            //if (serialPort1.IsOpen)
            //    Runbgw(); //run the backgroundworker again if the serial port hasn't been closed

        }

        private void toolStripDropDownButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStripStatusLabel1.Text = "Port: " + e.ClickedItem.Text;
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.PortName = e.ClickedItem.Text;
                try
                {
                    serialPort1.Open();
                }
                catch { toolStripStatusLabel2.Text = " Status: Error Opening Port!"; }

            }
            else
            { serialPort1.PortName = e.ClickedItem.Text; }

            Properties.Settings.Default.Com_Port_setting = serialPort1.PortName; //save port name to user settings
        }

        private void toolStripDropDownButton1_MouseHover(object sender, EventArgs e)
        {
            loadPorts();
            toolStripDropDownButton1.ShowDropDown();

        }

        private void toolStripStatusLabel1_MouseHover(object sender, EventArgs e)
        {
            loadPorts();
            toolStripDropDownButton1.ShowDropDown();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 AboutMe = new AboutBox1();
            AboutMe.ShowDialog(this);
            AboutMe.Dispose();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            formActive = true;

        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            formActive = false;


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (RowCountMax.Value == 0)
            {
                RowCountMax.Value = 1;
            }
            Properties.Settings.Default.rowcountmax = RowCountMax.Value;
            rowCount = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rowCount = 1; //reset row counter
        }

        //replace Taylor's parsedata function
        private string[] huy_parseData(string data)
        {
            string[] dataArray;
            data = data.Trim();
            data = Regex.Replace(data, @"\s+", " ");//replace all double or more white space with single white space

            data = data.Replace(",", "");//delete all ","
            data = data.Replace("- ", "-");//Some readings are passed in as "- ###", delete the space in between the sign and number
            dataArray = data.Split(null);

            return dataArray;
        }

        private bool ch1CMCMKReCalculate = true;//determine if ch1 value was changed/recorded
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            /* Uncomment this to go back to get back to older way of capturing readings
            if (isRefresh == false)
            {
                try
                {
                    if (serialPort1.BytesToRead > 0)
                    {
                        pauseLiveReading1 = true;
                        serialData = serialPort1.ReadLine();
                        textBox2.Text = serialData;
                        listBox1.Items.Add(serialData + "************");
                        if (serialData.Contains(";")==false)//if last character of inbuffer is not ';' that means it is from user pressing enter. Set isChan1Enter true
                        {
                            isChan1Enter = true;
                        }
                        else
                            isChan1Enter = false;
                        isSerial = false;
                        
                        pauseLiveReading1 = false;
                    }
                }
                catch
                {
                    beep = true; //we will only beep again if we have timed out recently, to prevent beeping repeatedly during a large dump
                    try
                    {
                        serialPort1.ReadExisting(); //clear the port if we don't get a whole line, so we don't send it later 
                    }
                    catch { }
                    pauseLiveReading1 = false;

                }
            }*/

            //backgroundworker only do work if live reading is turn off
            if (enableLiveReadingToolStripMenuItem.Checked == false)
            {
                try
                {
                    if (serialPort1.BytesToRead > 0)
                    {
                        serialData = serialPort1.ReadLine();

                        isSerial = false;
                    }
                }
                catch
                {
                    beep = true; //we will only beep again if we have timed out recently, to prevent beeping repeatedly during a large dump
                    try
                    {
                        //serialPort1.ReadExisting(); //clear the port if we don't get a whole line, so we don't send it later 
                    }
                    catch { }

                }
            }
        }

        CMCMKCal ch1CM_CMK = new CMCMKCal();
        float LSL, USL;
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            if ((serialData.Length > 0) && (enableLiveReadingToolStripMenuItem.Checked == false))// && (isRefresh == false))
            {
                //if (isChan1Enter == true)
                captureReadingsUsedByBGW(serialData);
                serialData = "";
                
            }
            //Todo:this cause CPU use 100%, see if manual capture still work without it  when live reading is off
            //Runbgw();
        }

        //Return List<float> that contains all datas from passed in Datatable, given colName
        //Huy added 3/16/18
        private List<float> getDataColfromDataGrid(DataGridView thisGrid, int colIndex)
        {
            List<float> returnFloatList = new List<float>();
            foreach (DataGridViewRow gridRow in thisGrid.Rows)
            {
                if (!gridRow.IsNewRow)
                    returnFloatList.Add(Single.Parse(gridRow.Cells[colIndex].Value.ToString()));
            }
            return returnFloatList;
        }
        //Passed in serialData that tester output (ex: 100 inlb), write to appropriate grid
        private void captureReadingsUsedByBGW(string serialData)
        {
            if ((TabPages.SelectedTab.Name == calTabName) && (pauseTest == false))//If on calibration Tab and test is not paused
            {
                if (testSetup_groupBox.Enabled == false) //only record Data if not in test setup mode
                {
                    processData_calTab(serialData);
                }
            }
            else//if on other Tab
            {
                process_data(serialData); //this will call add_row(), which then call updateTableandChart()

                if (serialPort2.IsOpen) //if this is dual channel, trigger the 2nd Com to request Data
                {
                    readFromSecondChannel();
                }
            }

        }
        //Write to first Channel Gridview
        private void writeToFirstChanGrid()
        {
            string[] data = new string[2] { firstReading.ToString(), firstUnit };
            addrow(data);
        }

        //Write to Second Channel Grid in DualChannel Tab, using secondReading and secondUnit
        private void writeToSecondChanGrid()
        {
            rowIndex = getFocusedRowFirstChannel(TabPages.SelectedTab.Name) - 1;
            // -1 because After 1st Channel take reading, the cursor already moved to a +1, needs to offset that new reading location in channel2
            //If the data was written to last Line of 1st Channel, then no need to subtract 1, because cursor doesn't move down after written in 1st channel grid
            if (is1stChanRow_LastRow)
                rowIndex += 1;

            if (rowIndex < 0)
                rowIndex = 0;

            //Write to either gridview if Overwrite is on, or write to secondTable if new Row
            //if ((overwriteDataAtCursorToolStripMenuItem.Checked) && (TabPages.SelectedTab.Name== "dualChannelTab") && (rowIndex>=0) && (!secondChannelGridView.Rows[rowIndex].IsNewRow)&&(firstChannelGrid.RowCount-secondChannelGridView.RowCount<2))
            if ((overwriteDataAtCursorToolStripMenuItem.Checked) &&
                (TabPages.SelectedTab.Name == "dualChannelTab"))
            {
                //Overwrite Mode is ON, and user is on Dual Channel Tab
                if ((rowIndex < secondChannelGridView.RowCount) &&
                    (secondChannelGridView.Rows[rowIndex].IsNewRow))
                {
                    //if it is New Row then add to bottom of secondUnit
                    addToSecondTable(secondUnit, secondReading);
                    //assign the secondUnit and secondReading to secondtable     
                    bindSecondChannelTable();
                }
                else if (rowIndex < secondChannelGridView.RowCount)
                {
                    secondChannelGridView.Rows[rowIndex].Cells[0].Value = secondReading;
                    secondChannelGridView.Rows[rowIndex].Cells[1].Value = secondUnit;
                    updateDualTableAndChart();
                }
            }
            else
            {
                addToSecondTable(secondUnit, secondReading);
                //assign the secondUnit and secondReading to secondtable     
                bindSecondChannelTable();
            }

            updateDualTableAndChart();
            bindDualTable();
        }
        private int rowIndex = 0;
        //Read from Channel2 and update dualTable and chart
        private void readFromSecondChannel()
        {
            readSuccess = false;
            pauseLiveReading2 = true;//set to true to prevent overlap with getting in live reading from channel2
            try
            {
                secondChannelReading = write_command("E", serialPort2); //read in second channel reading

                decodeSecondChannel(secondChannelReading);
                //decode reading received from second channel, assign to secondUnit and secondReading variable

                if (readSuccess == true)
                {
                    writeToSecondChanGrid();
                }
                decodeSecondChannel(secondChannelReading);
            }
            catch
            {
                pauseLiveReading2 = false;//resume live reading from channel2
            }
            pauseLiveReading2 = false;//resume live reading from channel2
        }

        //update Live Channel Reading for first Channel
        private void updateFirstChannelLive(float ReadingFloat, string unit)
        {
            string reading = "";
            if (ReadingFloat == 0)
                reading = ReadingFloat.ToString("0.000");
            else
            {
                reading = ReadingFloat.ToString();
            }

            //update reading
            DataTTS_lbl.Text = reading;
            Label_Data1.Text = reading;
            reading_bigReading_lbl.Text = reading;
            Label_Data3.Text = reading;
            DataSMDSingle_lbl.Text = reading;
            dataCh1DualChanTab_lbl.Text = reading;
            ch1ReadingLabel_calTab.Text = reading;
            //update unit
            unitTTS_lbl.Text = unit;
            unitSingleCH_lbl.Text = unit;
            unitCH1DualCHTab_lbl.Text = unit;
            ch1UnitLabel_calTab.Text = unit;
        }

        //update Live Channel Reading for second Channel
        private void updateSecondChannelLive(float ReadingFloat, string unit)
        {
            string reading = "";
            if (ReadingFloat == 0)
                reading = ReadingFloat.ToString("0.000");
            else
            {
                reading = ReadingFloat.ToString();
            }

            dataCh2DualChTab_lbl.Text = reading;
            unitCH2DualCHTab_lbl.Text = unit;
            ch2ReadingLabel_calTab.Text = reading;
            ch2UnitLabel_calTab.Text = unit;
        }


        /// <summary>
        /// Start init timer2 to display live reading
        /// </summary>
        private static System.Windows.Forms.Timer timer2;//timer2 is used to display reading on channel 2 live
        //init timer2, used for live reading of channel 2
        private void InitTimer()
        {
            timer2 = new System.Windows.Forms.Timer();
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = tickInterval;
            timer2.Start();
        }

        //Trigger when timer tick
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (enableLiveReadingToolStripMenuItem.Checked)
            {
                updateChannelsReadings();
            }

            try
            {
                displayCMCMK();
            }
            catch { }
        }

        //Handle show or not show CM CMK Huy added 3/16/18
        //changed 7/31/18
        private void displayCMCMK()
        {
            //Calculate CM and CMK Huy added 3/16/18
            if (ch1CMCMKReCalculate == true)
            {
                try
                {
                    int readingColIndex = 1;
                    List<float> ch1ReadingList = getDataColfromDataGrid(singleChannel_gridView, readingColIndex);
                    if ((showCMK_chkBox.Checked == true) && (LSL_txt.Text != "") && (USL_txt.Text.ToString() != ""))
                    {
                        LSL = Single.Parse(LSL_txt.Text.ToString());

                        USL = Single.Parse(USL_txt.Text.ToString());

                        //ch1CM_CMK.calculate_CMK(LSL, USL, ch1ReadingList);
                        CMVal_lbl.Text = ch1CM_CMK.calculate_CM(LSL, USL, ch1ReadingList).ToString();
                        CMKVal_lbl.Text = ch1CM_CMK.calculate_CMK(LSL, USL, ch1ReadingList).ToString();
                    }
                    average_lbl.Text = ch1CM_CMK.calculate_average(ch1ReadingList).ToString();
                    notNumberWarning_lbl.Text = "";
                }
                catch (FormatException)
                {
                    notNumberWarning_lbl.Text = "Input needs to be number";
                    clearCMCMKAve();
                }
                catch (Exception ex)
                {
                    clearCMCMKAve();
                }
                ch1CMCMKReCalculate = false;
            }
        }
        private void clearCMCMKAve()
        {
            CMVal_lbl.Text = "";
            CMKVal_lbl.Text = "";
            average_lbl.Text = "";
        }
        //timerCounter is used to stop disconnected Cable from hanging the UI
        //return timerCounter as 5 if no respond from tester (which timer 2 would have to count down till 0 till it can check for tester again)
        //reset timerCounter as 0 if there is respond from tester 
        private int changeTimerCounter(string testerRespond)
        {
            int timerCounter;
            if (testerRespond.Length == 0)
                timerCounter = 5;
            else
                timerCounter = 0;
            return timerCounter;
        }

        private string lastReading = "";
        private float autoClearCountDown = -5, autoClearInterval = -5;
        //Check if is time to autoclear-in case reading is the same, if reading is not the same then reset autoClearTick
        private void checkIfAutoClear(string lastReading, string thisReading)
        {
            if ((autoClearInterval > 0) && (forceAutoClearToolStripMenuItem.Checked == true))
            {
                if (thisReading == lastReading)
                {
                    if (autoClearCountDown <= 0)//Time to capture
                    {
                        if (TabPages.SelectedTab.Name == calTabName)
                        {//capture for caltab
                            if (pauseTest == false)
                                captureReadingsCalTab();
                        }
                        else//caltupre for all other tabs
                        {
                            captureReadingsFromBothChannel();
                            if (aquire && formActive == false && firstReading != 0)
                            {
                                string[] data = new string[2] { firstReading.ToString(), firstUnit };
                                sendDataToKeyboardOutPut(data);
                            }
                        }
                    }
                    else//count down autoClearCountDown
                        autoClearCountDown = autoClearCountDown - (tickInterval / 1000.00f);
                }
                else
                {//reset auto Clear Countdown if reading changed
                    autoClearCountDown = autoClearInterval;
                }
                this.lastReading = thisReading;
            }
        }

        //call decodemessage for livechannel reading
        //call decodemessage for livechannel reading
        //private void updateChannelsReadings()
        private void updateChannelsReadings()
        {
            string ch1Message = "";
            string ch2Message = "";

            try
            {
                CH1Timercounter--;
                CH2Timercounter--;
                if ((serialPort1.IsOpen) && (CH1Timercounter <= 0))
                {
                    float ReadingToDisplay = 0;

                    //save Reading from tester1 to ch1Message
                    ch1Message = write_command("D", serialPort1);

                    CH1Timercounter = changeTimerCounter(ch1Message);//change ch1Timercounter to indicate whether tester is connected physically or not
                    decodeMessage(ch1Message, chann1Control.getcurrUnitClass(), 1);

                    //when trough mode is selected
                    if (ch1Trough_chckbox.Checked == false)
                    {
                        ReadingToDisplay = firstReading;
                    }
                    else
                    {
                        ch1TroughPoint = getTroughPoint(secondReading, firstReading, ref ch1TroughList);
                        ReadingToDisplay = ch1TroughPoint;
                    }
                    updateFirstChannelLive(ReadingToDisplay, firstUnit);
                    updateBigReadingPassFail(ReadingToDisplay);

                    if (ReadingToDisplay != 0)
                        checkIfAutoClear(lastReading, ch1Message);//if user set forceAutoClear and reading has been the same for autoClearInteval time then capture data
                }
                if ((serialPort2.IsOpen) && (CH2Timercounter <= 0) && (pauseLiveReading2 == false))
                {
                    float ReadingToDisplay;
                    ch2Message = write_command("D", serialPort2);
                    CH2Timercounter = changeTimerCounter(ch2Message);//change ch2Timercounter to indicate whether tester is connected physically or not
                    //decode message passed in
                    decodeSecondChannel(ch2Message);


                    //when trough mode is selected
                    if (ch2Trough_chckbox.Checked == false)
                    {
                        ReadingToDisplay = secondReading;
                    }
                    else
                    {
                        ch2TroughPoint = getTroughPoint(firstReading, secondReading, ref ch2TroughList);
                        ReadingToDisplay = ch2TroughPoint;
                    }

                    updateSecondChannelLive(ReadingToDisplay, secondUnit);
                }

                //Happens when readings from pressing Enter and software send command at same time. This also indicates tester just got pressed Enter
                if (ch1Message.Length > 15)
                {
                    string serialData = reFormatserialData(ch1Message);//Cut all the extra stuff that comes after second white space
                    captureReadingsUsedByBGW(serialData);
                }
                else
                {
                    captureReadingsIfEnterPress(ch1Message, ch2Message);
                }
            }
            catch { }
        }
        private bool pauseTest = false;
        //get the lowest point from the passed in float list
        private float getLowestPointFrListFloat(List<float> floatList)
        {
            float returnFloat = Single.MaxValue;
            foreach (float singlePoint in floatList)
            {
                if (singlePoint < returnFloat)
                    returnFloat = singlePoint;
            }
            return returnFloat;
        }

        //Return the trough reading
        private float getTroughPoint(float otherChReading, float thisChLiveReading, ref List<float> thisTroughList)
        {
            float returnTroughPoint;
            if (otherChReading == 0)//if the other Chan Reading went back to 0, restart the trough list
            {
                thisTroughList.Clear();
                returnTroughPoint = thisChLiveReading;
            }
            else
            {
                thisTroughList.Add(thisChLiveReading);
                returnTroughPoint = getLowestPointFrListFloat(thisTroughList);
            }
            return returnTroughPoint;
        }
        private float ch1TroughPoint = -1, ch2TroughPoint = -1;//Contain the final trough reading, -1 indicate hasnt been assigned yet
        private List<float> ch1TroughList = new List<float>(), ch2TroughList = new List<float>(); //Contain list of all readings when the opposite channel escape 0 threshold

        //Reformat serialData, cut off all extra stuff 
        private string reFormatserialData(string serialData)
        {
            serialData = serialData.Trim();
            int cutIndex = serialData.IndexOf('\r');
            serialData = serialData.Substring(0, cutIndex);

            serialData = Regex.Replace(serialData, @"\s+", " ");//replace all double or more white space with single white space
                                                                /*int secondSpaceIndex = 0;
                                                                try
                                                                {
                                                                    secondSpaceIndex=serialData.IndexOf(' ', serialData.IndexOf(' ') + 1);
                                                                    serialData = serialData.Substring(0, secondSpaceIndex);
                                                                }
                                                                catch { }*/
                                                                //int cutIndex= serialData.IndexOf("\r\n");


            return serialData;
        }
        //Passed in ch1message and ch2message got from Sending Command D to Tester
        //If start with E then capture the reading
        private void captureReadingsIfEnterPress(string ch1Message, string ch2Message)
        {
            bool ch1Enter = (ch1Message != "") && (ch1Message[0] == 'E');
            bool ch2Enter = (ch2Message != "") && (ch2Message[0] == 'E');

            //If User press Enter on caltab , then call captureReadingsCalTab, which is same as pressing Capture_btn on calTab
            if ((ch1Enter || ch2Enter) && (TabPages.SelectedTab.Name == calTabName) && (pauseTest == false))
            {
                captureReadingsCalTab();
            }
            else// if not on caltab
            {
                //if user pressed Enter from tester, write to gridview and clear ch1 reading
                if (ch1Enter == true)
                {
                    writeToFirstChanGrid();
                    write_command("C;", serialPort1); //Clear tester
                }
                //if ch1 pressed Enter while ch2 is connected, or ch2 tester is pressed Enter
                //Then write to second gridview and clear ch2 reading
                if (((ch1Enter == true) && (serialPort2.IsOpen)) || (ch2Enter == true))
                {
                    writeToSecondChanGrid();
                    write_command("C;", serialPort2); //Clear Tester
                }
            }
        }
        //decode unit
        private string getUnit(char unitCode, string unitClass)
        {
            if (unitClass == "Torque")
            {
                switch (unitCode)
                {
                    case '0':
                        return "INOZ";
                    case '1':
                        return "INLB";
                    case '2':
                        return "FTLB";
                    case '3':
                        return "Nm";
                    case '4':
                        return "cNm";
                    case '5':
                        return "gfcm";
                    case '6':
                        return "Kgfcm";
                    case '7':
                        return "Kgfm";
                    default:
                        return "";
                }
            }
            if (unitClass == "Force")
            {
                switch (unitCode)
                {
                    case '0':
                        return "OZ";
                    case '1':
                        return "LB";
                    case '2':
                        return "N";
                    case '3':
                        return "gf";
                    case '4':
                        return "Kgf";
                    default:
                        return "";
                }
            }
            if (unitClass == "Pressure")
            {
                switch (unitCode)
                {
                    case '0':
                        return "bar";
                    case '1':
                        return "psi";
                    case '2':
                        return "kpsi";
                    case '3':
                        return "kPa";
                    default:
                        return "";
                }
            }
            return "";
        }
        //decode sign, return - or nothing for possitive
        private string getSign(char signCode)
        {
            if (signCode == '-')
                return "-";
            else
                return "";
        }
        private void addToSecondTable(string unit, float reading)
        {
            secondChannelTable.Rows.Add(reading, unit);

        }


        /// <summary>
        /// decode Message for live channel, pass in the message from Tester, then assign to either first or second reading and unit
        /// </summary>
        /// <param Raw Reading="thismessage"></param>
        /// <param channel "0 for FullScale", "1" or "2"="channel"></param>
        private void decodeMessage(string thismessage, string unitClass, int channel)
        {
            try
            {
                if (channel == 1)
                {
                    firstReading = 0;
                    firstUnit = "";
                }

                thismessage = thismessage.TrimEnd(' ');
                //thismessage = thismessage.TrimStart(' ');
                thismessage = thismessage.Replace(",", "");//delete , for reading that has too many digits
                if (thismessage[thismessage.Length - 1] == ';')//remove ; at the end of message
                    thismessage.Remove(thismessage.Length - 1, 1);
                string unit = "";
                string reading_str = "";
                float reading;
                unit = getUnit(thismessage[1], unitClass);
                try
                {
                    reading_str = (thismessage.Substring(2)).Replace(" ", "");
                    reading_str = reading_str.Replace("\r", "");
                    reading_str = reading_str.Replace("\n", "");
                    reading = Single.Parse(reading_str);
                }
                catch (Exception ex)
                {
                    reading = 0;
                }

                if (channel == 0)
                {
                    FSReading = reading;
                    FSUnit = unit;
                }
                if (channel == 1)
                {
                    firstReading = reading;
                    firstUnit = unit;
                }
                else if (channel == 2)
                {
                    secondReading = reading;
                    secondUnit = unit;
                }
            }
            catch { }
        }

        //pass in reading from channel 2, decode it, then add to secondChannelTable
        private void decodeSecondChannel(string message)
        {
            secondUnit = "";
            secondReading = 0;
            //message=<peak flag><unit><sign><reading>

            try
            {
                secondUnit = getUnit(message[1], chann2Control.getcurrUnitClass());
                secondReading = Convert.ToSingle(getSign(message[2]) + message.Substring(3));
                readSuccess = true;
            }
            catch
            {
                readSuccess = false;
                if (pauseLiveReading2)//if this is live reading then we do not display the error message
                {
                    MessageBox.Show("Unable to read reading from " + serialPort2.PortName);
                    pauseLiveReading2 = false;
                }
            }
        }

        private void includeTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            includeTimeToolStripMenuItem.Checked = (includeTimeToolStripMenuItem.Checked == false);//toggle time stamp            
            Properties.Settings.Default.TimeStamp_Setting = includeTimeToolStripMenuItem.Checked;
        }

        private void includeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            includeDateToolStripMenuItem.Checked = (includeDateToolStripMenuItem.Checked == false);//toggle date stamp            
            Properties.Settings.Default.DateStamp_Setting = includeDateToolStripMenuItem.Checked;
        }

        private void Reading_Only_Box_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.readings_only = Reading_Only_Box.Checked;
            checkBox6.Checked = Reading_Only_Box.Checked;
            checkBox7.Checked = Reading_Only_Box.Checked;
        }

        //My variables
        SerialPort port = new SerialPort();
        public string[] ports = SerialPort.GetPortNames();
        string currPort = "";//store current COM number
        string received_message = "";
        static int serialLen = 7;

        // code
        private void Closebgw()
        {
            if (backgroundWorker1.IsBusy == true)
            {
                backgroundWorker1.CancelAsync(); //stop background worker
            }
        }
        //open second port
        private void openSecondport(string port1)
        {
            closeSecondport(serialPort2.PortName);
            serialPort2.PortName = port1;
            try
            {
                serialPort2.Open();

            }
            catch
            { MessageBox.Show("Can't open port"); }

        }
        //open port, assign port name to serialPort1, change status label to open or give error openning, call Runbgw to run background worker
        private void openport(string port1)
        {
            closeport(serialPort1.PortName);

            serialPort1.PortName = port1;
            try
            {
                serialPort1.Open();
                toolStripStatusLabel2.Text = " Status: Opened";
                //Runbgw(); //run background worker
            }
            catch
            { toolStripStatusLabel2.Text = " Status: Error Opening Port!"; }

        }
        //close second port, assign passed in port2 name to serialport2
        private void closeSecondport(string port2)
        {
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
                updateDisconnectCOMList(serialPort2.PortName, 2);//remove -Channel1 from comList for currentPort
            }
            serialPort2.PortName = port2;
        }

        //close port from channel 1, change status label to close
        private void closeport(string port1)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                toolStripStatusLabel2.Text = " Status: Closed";
                updateDisconnectCOMList(serialPort1.PortName, 1);//remove -Channel1 from comList for currentPort
            }

            serialPort1.PortName = port1;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (enableLiveReadingToolStripMenuItem.Checked == false)
                Runbgw();
        }
        
        //Initialize the port, prameter: portnum
        private void port_init(string portnum)
        {
            port.PortName = portnum;
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Handshake = Handshake.None;
            port.ReadTimeout = maxReadTimeOut;
            port.WriteTimeout = 100;
            //port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        //send any command to tester to check existence of tester connecting to each COM   
        private void testCOM()
        {
            try
            {
                if (port.IsOpen == false)
                    port.Open();
                port.Write("?S;");
                if (port.IsOpen == true)
                    port.Close();
            }
            catch
            {
                //delete the com that cant be opened from ports array
                ports = ports.Where(String => String != port.PortName).ToArray();
            }
        }
        private bool isRefresh = false;
        //COM list refresh button is pressed, clear comList, put all COM list into ports[]. 
        public void comListRefresh_Click(object sender, EventArgs e)
        {
            refreshComList();
        }
        private List<string> testerList = new List<string>();
        private void refreshComList()
        {
            isRefresh = true;
            BindingList<string> rawComList = new BindingList<string>();
            ports = SerialPort.GetPortNames();
            testerList.Clear();

            //Close serialPort1 and 2
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.PortName = "COM101";
                showComConnect_FirstChan(noComConnectMessage);
            }
            if (serialPort2.IsOpen)
            {
                serialPort2.Close();
                serialPort2.PortName = "COM102";
                showComConnect_SecondChan(noComConnectMessage);
            }

            foreach (string portName in SerialPort.GetPortNames())
            {
                bool portcheck = currPort.Equals(portName);//portcheck is true if the currPort is same as PortName
                Closebgw();
                if (portcheck == false) //current port selecting is different from openning port
                {//close old port, init new port
                    try
                    {
                        port.Close();
                        currPort = portName;
                        port_init(currPort);//assign currPort to port(used by other method as the current port)
                    }
                    catch { }
                }
                testCOM();//attempt to request tester capacity, if can't then remove from list of COM
            }

            foreach (string s in ports)
            {
                testerList.Add(s);
                rawComList.Add(s + ":");
                isSerial = true;
                //openport(s);

            }
            isRefresh = false;
            if (showALLCOMAvailableToolStripMenuItem.Checked == true)//if user wants to display only detected Tester
                bindcomList(rawComList);//if user wants to display all available COM
            else
                getSerialList();
        }
        //prameter: array string, return only the reading from the tester
        private string checkarrayLength(string[] array)
        {
            string returnStr = "";
            if (array.Length > 2)
                returnStr = array[1];
            else
                returnStr = array[0];
            return returnStr;
        }
        //When user selects different COM from comList box, close old COM, open new COM
        private void autoConnectHandle(string currentPort)
        {
            DataTTS_lbl.Text = "NO DATA";
            Label_Data1.Text = DataTTS_lbl.Text;
            reading_bigReading_lbl.Text = DataTTS_lbl.Text;
            Label_Data3.Text = DataTTS_lbl.Text;
            DataSMDSingle_lbl.Text = DataTTS_lbl.Text;
            toolStripStatusLabel1.Text = "Port: " + currentPort;

            opencloseFirstCOM(ref comList);

            Properties.Settings.Default.Com_Port_setting = serialPort1.PortName; //save port name to user settings
        }
        //When user selects different COM from comList box, close old COM, open new COM
        private void comList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (autoConnectToolStripMenuItem.Checked)
                {
                    autoConnectHandle(extractCOM(comList.SelectedItem.ToString()));
                }
            }
            catch { }
        }

        private void updateSampleNuminGrid(ref DataGridView grid, int rowIndex)
        {
            while ((rowIndex < grid.RowCount - 1) && (rowIndex >= 0))
            {
                grid.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
                rowIndex++;
            }
        }
        //pass in and delete line index from gridview
        private void deleteRow(int index)
        {
            if (!singleChannel_gridView.Rows[index].IsNewRow)
            {
                //gridview.Rows.RemoveAt(index);
                singleChannel_gridView.Rows.RemoveAt(index);
                firstChannelGrid.Rows.RemoveAt(index);
            }
            updateSampleNuminGrid(ref singleChannel_gridView, index);
            updateSampleNuminGrid(ref firstChannelGrid, index);

            //updateTableandChart(ref chart1,singleChannel_gridView);
            updateTableandChart(ref singleChart, singleChannel_gridView);
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (gridview.RowCount > 0)
                deleteRow(gridview.CurrentCell.RowIndex);

        }
        private void clearGrid(ref DataGridView grid)
        {
            if (grid.RowCount > 1)
            {
                grid.Rows.Clear();
            }
            askToClearData = true;
            //updateTableandChart(ref chart1,singleChannel_gridView);
            updateTableandChart(ref singleChart, singleChannel_gridView);
        }

        //Clear all readings in gridview
        private void clear_Click(object sender, EventArgs e)
        {
            clearGrid(ref gridview);
        }

        //write to specific cell into excel workbook
        //Prameter: cell number, what to write to that cell, excel work book
        private ExcelWorkbook writecel(string cell, string data, ExcelWorkbook wbook)
        {
            if (data.Any(char.IsDigit))//this indicates data is number,write to excel as float
            {
                float dataToWrite;
                dataToWrite = Convert.ToSingle(data);
                wbook.Worksheets[0].Cells[cell].Value = dataToWrite;
            }
            else
            {//data is string, write to excel as string
                string dataToWrite = data;
                wbook.Worksheets[0].Cells[cell].Value = dataToWrite;
            }


            return wbook;
        }

        //populate Excel file with the reading. 
        //pass in list of possitive points in string format
        //pass in list of negative points in string format
        //This method dictates the template of Excelworkbook
        private ExcelWorkbook populateExcel()
        {
            ExcelWorkbook wbook = new ExcelWorkbook();
            wbook.Worksheets.Add("Sheet1");
            //Write headers to Excel worksheet
            wbook = writecel("A1", "Memory Location", wbook);
            wbook = writecel("B1", "Reading", wbook);
            wbook = writecel("C1", "Unit", wbook);
            int excelRow = 1;

            for (int rowindex = 0; rowindex < (singleChannel_gridView.RowCount - 1); rowindex++)
            {
                if (!singleChannel_gridView.Rows[rowindex].IsNewRow)
                {
                    excelRow = rowindex + 2;
                    wbook = writecel(String.Concat("A", excelRow.ToString()), singleChannel_gridView.Rows[rowindex].Cells[0].Value.ToString(), wbook);//write memory location to A column
                    wbook = writecel(String.Concat("B", excelRow.ToString()), singleChannel_gridView.Rows[rowindex].Cells[1].Value.ToString(), wbook);//write reading to B column
                    wbook = writecel(String.Concat("C", excelRow.ToString()), singleChannel_gridView.Rows[rowindex].Cells[2].Value.ToString(), wbook);//write unit to C column
                }
            }

            return wbook;
        }

        //this functions return a list of negative or possitive elements from gridview
        private string[] getpoint(Boolean sign)
        {
            int index = 0;
            //check how many possitive or negative, use index to initiate string[] result
            for (int count = 0; count < (gridview.RowCount - 1); count++)
            {
                string value = gridview.Rows[count].Cells[1].Value.ToString();
                if (((sign == true) && (!value.Contains("-"))) || ((sign == false) && (value.Contains("-"))))//look for sign=true and possitive num, or sign=false and negative num
                {
                    index++;
                }
            }
            string[] result = new string[index];

            index = 0;//reset index for later use
            for (int count = 0; count < (gridview.RowCount - 1); count++)
            {
                if (!gridview.Rows[count].IsNewRow)
                {

                    string value = gridview.Rows[count].Cells[1].Value.ToString();
                    if (((sign == true) && (!value.Contains("-"))) || ((sign == false) && (value.Contains("-"))))
                    {
                        result[index] = value.ToString();
                        index++;
                    }
                }
            }

            return result;
        }

        //return the unit of tester (ex: inlbs, inoz, etc.)
        private string getExcelUnit()
        {
            string value = "";

            if (!gridview.Rows[0].IsNewRow)
                value = gridview.Rows[0].Cells[2].Value.ToString();
            return value;
        }

        private void export_Click(object sender, EventArgs e)
        {
            string[] possitive = getpoint(true);//populate all possitive point into positive
            string[] negative = getpoint(false);//populate all negative point into negative
            string filename = "result-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Torque_To_Spreadsheet_Export";//set path of export file to MyDocuments\Torque_To_Spreadsheet_Export folder

            string fullpath = Path.Combine(getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName), filename);//location folder AND filename

            /*
            //if the folder for path hasn't been created, create it
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }*/

            ExcelWorkbook wbook = populateExcel();
            wbook.WriteXLS(@fullpath);
            var openfile = MessageBox.Show("File successfully saved into " + fullpath + "\n\nOpen folder? ", "Open File Location", MessageBoxButtons.YesNo);
            if (openfile == DialogResult.Yes)
            {
                string argument = @"/select, " + fullpath;
                System.Diagnostics.Process.Start("explorer.exe", argument);
            }
        }

        //Name changed from initChart 8/27/17
        //Catch error, changed 8/28/18
        private void initChartSerie(ref Chart chart, string name)
        {
            try
            {
                chart.Series.Add(name);
            }
            catch { }
        }

        private void clearTableColumn(ref DataTable thisTable, int colIndex)
        {
            try
            {
                for (int i = 0; i < thisTable.Rows.Count; i++)
                {
                    thisTable.Rows[i][colIndex] = DBNull.Value;
                }
            }
            catch { }
        }
        //Assign look for the chart
        private Chart setChart(Chart chart, string serie, int chartype)
        {
            //set graph type to Line chart or Point
            if (chartype == 1)//Use FastLine
                chart.Series[serie].ChartType = SeriesChartType.FastLine;
            else//set graph type to FastPoint
            {
                chart.Series[serie].ChartType = SeriesChartType.FastPoint;
            }
            //only show area with X > 0
            chart.ChartAreas[0].AxisX.IsMarginVisible = true;
            //set width of graph line for actual reading
            chart.Series[serie].BorderWidth = 3;
            //show X and Y value when hover near tip
            chart.Series[serie].ToolTip = "X=#VALX, Y=#VALY";
            //disable vertical grid line
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            return chart;
        }
        //Clear all bottom empty row of a datatable
        private void clearEmptyRow(ref DataTable thisTable)
        {
            for (int rowIndex = (thisTable.Rows.Count - 1); rowIndex >= 0; rowIndex--)
            {
                bool isrowEmpty = true;
                for (int colIndex = 1; colIndex < thisTable.Columns.Count; colIndex++)
                {
                    if (!(thisTable.Rows[rowIndex].IsNull(colIndex)))
                        isrowEmpty = false;
                }
                if (isrowEmpty == true)
                    thisTable.Rows.RemoveAt(rowIndex);
            }
        }

        //Copy girdview from first Channel reading to last Column of table
        private void updateTable_SingleChannel(DataGridView thisGrid)
        {
            //clear all value from last collumn of table
            clearTableColumn(ref singleTable, singleTable.Columns.Count - 1);

            //copy all values from current gridview into table[currColumn]
            for (int i = 0; i < thisGrid.Rows.Count; i++)
            {
                if (!thisGrid.Rows[i].IsNewRow)
                {
                    //if i>= max table row, add an empty row
                    if (i >= singleTable.Rows.Count)
                    {
                        singleTable.Rows.Add();
                        singleTable.Columns[0].ReadOnly = false;
                        singleTable.Rows[i].SetField(0, i + 1);
                        //singleTable.Rows[i][0] = i+1;
                    }
                    try
                    {
                        singleTable.Columns[currColumn].ReadOnly = false;
                        float tempReading = Convert.ToSingle(thisGrid.Rows[i].Cells[1].Value.ToString());
                        singleTable.Columns[currColumn].ReadOnly = false;
                        singleTable.Rows[i].SetField(currColumn, tempReading);
                        //singleTable.Rows[i][currColumn] = tempReading;
                    }
                    catch
                    {
                        singleTable.Rows[i][currColumn] = null;
                    }
                }
            }

            masterGridView.Refresh();
        }

        //bind chart x and y value to Data Table 
        //Added 8/27/17
        private void bindChartXYwithTableHeader(ref DataTable tableToBind, int xTableIndex, int yTableIndex, ref Chart chart, string currSerie)
        {
            chart.Series[currSerie].XValueMember = tableToBind.Columns[xTableIndex].ColumnName;
            chart.Series[currSerie].YValueMembers = tableToBind.Columns[yTableIndex].ColumnName;
            chart.DataSource = tableToBind;
            chart.DataBind();
        }

        //Changed 8/27/17
        private void updateChart(ref Chart chart)
        {

            //update actual reading
            int pointColIndex = singleTable.Columns.IndexOf("Point");
            bindChartXYwithTableHeader(ref singleTable, 0, singleTable.Columns.Count - 1, ref chart, currColumn);

            chart = setChart(chart, currColumn, 1);//assign what the chart look like


            int maxRowCount = singleTable.Rows.Count;

            //Determine max and min to draw on chart
            float max = Single.MinValue;
            float min = Single.MaxValue;
            foreach (DataRow dataRow in singleTable.Rows)
            {
                for (int colIndex = 1; colIndex < singleTable.Columns.Count; colIndex++)
                {
                    if (dataRow[colIndex] != DBNull.Value)
                    {
                        max = Math.Max(Single.Parse(dataRow[colIndex].ToString()), max);
                        min = Math.Min(Single.Parse(dataRow[colIndex].ToString()), min);
                    }
                }
            }

            //If draw limit is on, draw it and compare max min with limit
            if (isHighLow)
            {
                chart = drawChartLimit(chart, 0, maxRowCount, low, high, target_value);
                max = Math.Max(high, max);
                min = Math.Min(low, min);
            }

            //In case max and min didnt change, assign max=9, min =1
            if (max == Single.MinValue)
                max = 9;
            if (min == Single.MaxValue)
                min = 1;

            //Give max and min 1 buffer
            max += 1;
            min -= 1;
            int maxInt = (int)Math.Ceiling(max);
            int minInt = (int)Math.Floor(min);
            //Draw graph again with new Y Axis limit
            try
            {
                chart.ChartAreas[0].AxisY.Maximum = maxInt;
                chart.ChartAreas[0].AxisY.Minimum = minInt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //draw Limit for chart
        //Only call this if chart has Series high low and target already existed
        private Chart drawChartLimit(Chart chart, float X_commonMin, float X_commonMax, float Y_low, float Y_high, float Y_target)
        {
            chart.Series["high"].Points.Clear();
            chart.Series["low"].Points.Clear();
            chart.Series["target"].Points.Clear();

            //update low and high
            chart.Series["low"].Points.AddXY(X_commonMin, Y_low);
            chart.Series["low"].Points.AddXY(X_commonMax, Y_low);
            chart.Series["low"].Color = Color.Red;
            chart.Series["low"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart.Series["low"].BorderWidth = 2;

            chart.Series["high"].Points.AddXY(X_commonMin, Y_high);
            chart.Series["high"].Points.AddXY(X_commonMax, Y_high);
            chart.Series["high"].Color = Color.Red;
            chart.Series["high"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart.Series["high"].BorderWidth = 2;

            chart.Series["target"].Points.AddXY(X_commonMin, Y_target);
            chart.Series["target"].Points.AddXY(X_commonMax, Y_target);
            chart.Series["target"].Color = Color.Green;
            chart.Series["target"].BorderDashStyle = ChartDashStyle.DashDot;
            chart.Series["target"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            chart.Series["target"].BorderWidth = 3;
            return chart;
        }
        //Changed 8/27/17
        private void updateTableandChart(ref Chart chart, DataGridView thisGrid)
        {
            updateTable_SingleChannel(thisGrid);
            updateChart(ref chart);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Button_Aquire_Click(this, e);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            Reading_Only_Box.Checked = checkBox6.Checked;
            checkBox7.Checked = checkBox6.Checked;
            Properties.Settings.Default.readings_only = Reading_Only_Box.Checked;
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            RowCountMax.Value = numericUpDown1.Value;
            numericUpDown2.Value = numericUpDown1.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1_Click(this, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            refreshComList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList_bigReading);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            refreshComList();
        }

        //When channel1 is open or close, call this function to enable or disable Menu Control button
        private void channel1MenuButtonUpdate()
        {
            if (serialPort1.IsOpen)
            {
                modeControl_button.Text = chann1Control.getStringMode();
                chan1_modeControl_button.Text = chann1Control.getStringMode();
                ch1ModeControlBtn_calTab.Text = chann1Control.getStringMode();

                menuControl_button.Enabled = true;
                chan1_menuControl_button.Enabled = true;
                ch1MenuControlBtn_calTab.Enabled = true;
            }
            else
            {
                modeControl_button.Text = "Mode";
                chan1_modeControl_button.Text = "Mode";
                ch1ModeControlBtn_calTab.Text = "Mode";

                menuControl_button.Enabled = false;
                chan1_menuControl_button.Enabled = false;
                ch1MenuControlBtn_calTab.Enabled = false;
            }

        }

        private void chan1ConnectButton_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList3);
            channel1MenuButtonUpdate();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button_Aquire_Click(this, e);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            checkBox6.Checked = checkBox7.Checked;
            Reading_Only_Box.Checked = checkBox7.Checked;
            Properties.Settings.Default.readings_only = Reading_Only_Box.Checked;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button1_Click(this, e);
        }

        private void deleteRow_SingleTab_Click(object sender, EventArgs e)
        {
            if (singleChannel_gridView.RowCount > 0)
                try
                {
                    deleteRow(singleChannel_gridView.CurrentCell.RowIndex);

                }
                catch { }
            ch1CMCMKReCalculate = true;
        }
        //changed 10/2/18
        private void clearRun_SingleTab_Click(object sender, EventArgs e)
        {
            clearGrid(ref singleChannel_gridView);
            USL_txt.Text = "";
            LSL_txt.Text = "";
            ch1CMCMKReCalculate = true;
            clear_limit_Click(this, e);
        }

        private float[,] dataToExcel(DataGridView thisGrid)
        {
            float[,] reading = new float[thisGrid.RowCount, 5];
            int rowIndex = 0;
            string data = "";
            while (!thisGrid.Rows[rowIndex].IsNewRow)
            {
                //reading[rowIndex, 2] =
                reading[rowIndex, 0] = rowIndex + 1;
                data = thisGrid.Rows[rowIndex].Cells[1].Value.ToString();
                reading[rowIndex, 1] = Convert.ToSingle(data);
                reading[rowIndex, 2] = Convert.ToSingle(high);
                reading[rowIndex, 3] = Convert.ToSingle(low);
                reading[rowIndex, 4] = Convert.ToSingle(target_value);
                rowIndex++;
            }

            return reading;
        }
        //Return just the folder location of a Full Path File Name
        private static string extractPathFromExcelPathName(string pathName)
        {
            int index = pathName.Length - 1;
            if (pathName.Contains(".xls"))
            {
                while ((pathName[index] != '\\') && (index > 0))
                {
                    pathName = pathName.Substring(0, index);
                    index--;
                }
            }
            return pathName;
        }
        //Show save dialog box and return path name
        private static string getSavePathName(string defaultName)
        {

            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.InitialDirectory = lastPathName;
            saveDlg.Filter = "Excel|*.xls";
            saveDlg.FileName = defaultName;
            saveDlg.ShowDialog();
            string path = "";
            path = saveDlg.FileName;
            if (path != "")
                lastPathName = extractPathFromExcelPathName(path);
            return path;
        }
        //added 9/12/19
        //save 1 quadrant from Cal Cert to Excel
        private void saveExcelCalQuadrant(string path, string quadName)
        {
            throw new NotImplementedException();
        }
        //changed 7/31/18
        private void saveExcel(string path, DataTable thisTable, int chartType)
        {
            string currTab = TabPages.SelectedTab.Name;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //Write the name of current Tab to first excel slot, used to open up this Test later
            xlWorkSheet.Cells[1, 1] = currTab;

            //parse the data from gridview into 2 dimentions float data
            float[,] datas = dataToExcel(singleChannel_gridView);

            int rowCount = singleChannel_gridView.RowCount;
            int colCount = 5;
            string range_data, range_high, range_low, range_target;
            try
            {
                string begin_reading, begin_high, begin_low, begin_target;
                int startRow, startCol;
                startCol = 1;
                startRow = getStartRowExcelData(TabPages.SelectedTab.Name);

                // Get an Excel Range of the same dimensions
                begin_reading = "B" + startRow;
                begin_high = "C" + startRow;
                begin_low = "D" + startRow;
                begin_target = "E" + startRow;

                //Note that since we use singleChannel_gridView, it has extra new row so subtract 1
                range_data = "B" + (singleChannel_gridView.RowCount - 1 + startRow - 1);
                range_high = "C" + (singleChannel_gridView.RowCount - 1 + startRow - 1);
                range_low = "D" + (singleChannel_gridView.RowCount - 1 + startRow - 1);
                range_target = "E" + (singleChannel_gridView.RowCount - 1 + startRow - 1);


                //init Chart setting
                Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(200, 80, 500, 250);
                Excel.Chart chartPage = myChart.Chart;

                //For now use Line Chart for all Chart
                /*if (chartType == lineChart)
                    chartPage.ChartType = Excel.XlChartType.xlXYScatterLines;
                else
                    chartPage.ChartType = Excel.XlChartType.xlXYScatter;*/
                chartPage.ChartType = Excel.XlChartType.xlXYScatterLines;

                chartPage.HasTitle = true;
                chartPage.ChartTitle.Text = "File saved at " + path;
                chartPage.ChartTitle.Font.Size = 12;
                chartPage.HasLegend = true;

                Excel.SeriesCollection oSeries = (Excel.SeriesCollection)myChart.Chart.SeriesCollection(misValue);

                //if user defines target, low, high; then draw on Excel
                if (isHighLow)
                {
                    Excel.Series low = oSeries.NewSeries();
                    Excel.Series high = oSeries.NewSeries();
                    Excel.Series target = oSeries.NewSeries();

                    //assign color for series in excel
                    target.Border.Color = Color.Green;
                    low.Border.Color = Color.Red;
                    high.Border.Color = Color.Red;
                    target.Border.LineStyle = Excel.XlLineStyle.xlDashDot;

                    low.Name = "Low Tolerance";
                    high.Name = "High Tolerance";
                    target.Name = "Target";
                    if (isMasterSave)
                    {
                        //if this save is for MasterGrid, change the range of high low target
                        begin_high = getColLetter(thisTable.Columns.Count - 1) + (startRow + 1);
                        begin_low = getColLetter(thisTable.Columns.Count) + (startRow + 1);
                        begin_target = getColLetter(thisTable.Columns.Count + 1) + (startRow + 1);

                        range_high = getColLetter(thisTable.Columns.Count - 1) + (thisTable.Rows.Count + startRow);
                        range_low = getColLetter(thisTable.Columns.Count) + (thisTable.Rows.Count + startRow);
                        range_target = getColLetter(thisTable.Columns.Count + 1) + (thisTable.Rows.Count + startRow);

                    }

                    Excel.Range high_range = xlWorkSheet.get_Range(begin_high, range_high);
                    Excel.Range low_range = xlWorkSheet.get_Range(begin_low, range_low);
                    Excel.Range target_range = xlWorkSheet.get_Range(begin_target, range_target);

                    //Bind value of high low target Series to apporpriate range on Excel worksheet
                    low.Values = low_range;
                    high.Values = high_range;
                    target.Values = target_range;
                }

                //write readings on Excel
                if (isMasterSave == false)
                {//Write gridview readings to excel

                    const int startCMCMKRow = 2, startCMCMKCol = 1;
                    xlWorkSheet = writeCMCMKtoExcel(xlWorkSheet, startCMCMKRow, startCMCMKCol);

                    // Find the last real row
                    int excelLastRow = xlWorkSheet.Cells.Find("*", System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value, System.Reflection.Missing.Value, Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                    //Write tool info to last row
                    if (toolID_SC_comboBox.SelectedIndex >= 0)
                        xlWorkSheet = writeToolsInfoToSCExcel(xlWorkSheet, excelLastRow + 1);

                    Excel.Range datarange = (Excel.Range)xlWorkSheet.Cells[startRow, startCol];
                    datarange = datarange.get_Resize(rowCount - 1, colCount);
                    datarange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, datas);
                    string colName = thisTable.Columns[1].ColumnName;
                    //Assign series Reading to Chart
                    Excel.Series reading = oSeries.NewSeries();
                    reading.Name = colName;
                    reading.Border.Color = Color.Blue;

                    Excel.Range reading_range = xlWorkSheet.get_Range(begin_reading, range_data);

                    reading.Values = reading_range;
                    //add heading for Excel file 
                    xlWorkSheet.Cells[startRow - 1, startCol] = "Point";
                    xlWorkSheet.Cells[startRow - 1, startCol + 1] = colName;
                    xlWorkSheet.Cells[startRow - 1, startCol + 2] = "High";
                    xlWorkSheet.Cells[startRow - 1, startCol + 3] = "Low";
                    xlWorkSheet.Cells[startRow - 1, startCol + 4] = "Target";
                }
                else //write master readings to Excel instead
                {
                    ///////////////Write from table to Excel
                    int rowIndex = 2, colIndex = 0;

                    //Write tool info to last row
                    if (toolID_SC_comboBox.SelectedIndex >= 0)
                        xlWorkSheet = writeToolsInfoToSCExcel(xlWorkSheet, rowIndex);
                    rowIndex = startRow;

                    //This loop assign the header name of each column in table into Excel
                    foreach (DataColumn dc in thisTable.Columns)
                    {
                        colIndex++;
                        xlWorkSheet.Cells[rowIndex, colIndex] = dc.ColumnName;
                    }

                    //This loop write the actual datas from table and high low target into Excel
                    foreach (DataRow dr in thisTable.Rows)
                    {
                        rowIndex++;
                        colIndex = 0;

                        foreach (DataColumn dc in thisTable.Columns)
                        {
                            colIndex++;
                            xlWorkSheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                        }
                        //Write high,low, target to column in Excel
                        xlWorkSheet.Cells[rowIndex, colIndex + 1] = high;
                        xlWorkSheet.Cells[rowIndex, colIndex + 2] = low;
                        xlWorkSheet.Cells[rowIndex, colIndex + 3] = target_value;
                    }
                    xlWorkSheet.Cells[startRow, colIndex + 1] = "High Limit";
                    xlWorkSheet.Cells[startRow, colIndex + 2] = "Low Limit";
                    xlWorkSheet.Cells[startRow, colIndex + 3] = "Target";
                    ////////////////End writing datas//////////////////////////////

                    //Do graph for multiple series
                    List<Excel.Series> colList = new List<Excel.Series>();
                    colIndex = 0;
                    Excel.Range YRange, XRange;
                    int colListIndex = 0;
                    while (colIndex < (thisTable.Columns.Count - 1))
                    {
                        colList.Add(oSeries.NewSeries());
                        colName = thisTable.Columns[colIndex + 1].ColumnName;//if single channel, colName=table[col] name
                        if ((thisTable.Columns[0].ColumnName != "Point"))//if dual table, colName=serieName
                            colName = getSerieNamefrXorY(colName, dualChart);

                        colList[colListIndex].Name = colName;//assign colName to colList[serie]

                        string YcolLetter = getColLetter(colIndex);
                        string XcolLetter;
                        //Assign the right column letter to XcolLetter
                        if (thisTable.Columns[0].ColumnName == "Point")
                            //Passed in table is table for 1 channel, XcolLetter is always A
                            XcolLetter = "A";
                        else//Passeed in table is dualTable for 2 channel, then XcolLetter is the even numbertable
                        {
                            XcolLetter = getColLetter(colIndex - 1);
                        }
                        /////End Assigning///
                        //Assign X and Y Range for colList[serie]
                        YRange = xlWorkSheet.get_Range(YcolLetter + (startRow + 1) + ":" + YcolLetter + (thisTable.Rows.Count + startRow));
                        XRange = xlWorkSheet.get_Range(XcolLetter + (startRow + 1) + ":" + XcolLetter + (thisTable.Rows.Count + startRow));
                        colList[colListIndex].Values = YRange;
                        colList[colListIndex].XValues = XRange;

                        //if single channel, coIndex+1, if dual channel, colIndex+2
                        if (thisTable.Columns[0].ColumnName == "Point")
                            colIndex += 1;
                        else
                            colIndex += 2;

                        colListIndex++;
                    }
                    isMasterSave = false;

                }

                ///////////End updating graph

                //Save and release Excel object
                xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //Auto open the excel that was saved
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                MessageBox.Show("Unable to save readings to Excel file.\n\nThere may be no reading recorded, or the Excel file is currently opened");
            }
        }

        //Write tool info into SC Xcel
        private Excel.Worksheet writeToolsInfoToSCExcel(Excel.Worksheet wsheet, int startRow)
        {
            string labelCol = "A";//write the header of tools to Column A 
            string valueCol = "B";//write value of tools header to Column B
            int rowIndex = startRow;

            foreach (DataRow thisRow in toolsDataTable.Rows)
            {
                //if thisRow is the same toolID user select
                if (toolID_SC_comboBox.Text == thisRow[pack.toolID_colName].ToString())
                {
                    DataTable selectedToolTable = toolsDataTable.Clone();
                    selectedToolTable.ImportRow(thisRow);

                    //Write Tools Info to wsheet
                    wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, toolID_lbl.Text, wsheet);
                    wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, thisRow[pack.toolID_colName].ToString(), wsheet);
                    rowIndex++;

                    wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, toolSN_lbl.Text, wsheet);
                    wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, thisRow[pack.SN_colName].ToString(), wsheet);
                    rowIndex++;

                    wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, model_lbl.Text, wsheet);
                    wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, thisRow[pack.model_colName].ToString(), wsheet);
                    rowIndex++;

                    wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, manu_lbl.Text, wsheet);
                    wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, thisRow[pack.manufacturer_colName].ToString(), wsheet);
                    rowIndex++;

                    wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, certLot_lbl.Text, wsheet);
                    wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, thisRow[pack.lotID_colName].ToString(), wsheet);
                    rowIndex++;

                }
            }
            return wsheet;
        }

        //check if 1st channel tab, and showCMCMK checked, then write value to excel
        //Passed in rowIndex and colIndex of where CM CMK will be written
        //Will be written as 
        //      col1 col2
        //row1  CM:  CM_val
        //row2  CMK: CM_val
        //changed 7/31/18
        private Excel.Worksheet writeCMCMKtoExcel(Excel.Worksheet wSheet, int rowIndex, int colIndex)
        {
            int readingColIndex = 1;
            List<float> ch1ReadingList = getDataColfromDataGrid(singleChannel_gridView, readingColIndex);

            if (TabPages.SelectedTab.Name == SMDSingleTabName)
            {
                if (showCMK_chkBox.Checked == true)
                {
                    wSheet.Cells[rowIndex, colIndex] = "CM:";
                    wSheet.Cells[rowIndex + 1, colIndex] = "CMK:";
                    wSheet.Cells[rowIndex + 2, colIndex] = "Average";
                    try
                    {
                        LSL = Single.Parse(LSL_txt.Text.ToString());
                        USL = Single.Parse(USL_txt.Text.ToString());

                        //write CM,CMK, ave val
                        try
                        {
                            double CM_val = ch1CM_CMK.calculate_CM(LSL, USL, ch1ReadingList);
                            wSheet.Cells[rowIndex, colIndex + 1] = Math.Round(CM_val, 2);
                        }
                        catch { }
                        try
                        {
                            double CMK_val = ch1CM_CMK.calculate_CMK(LSL, USL, ch1ReadingList);
                            wSheet.Cells[rowIndex + 1, colIndex + 1] = Math.Round(CMK_val, 2);
                        }
                        catch { }
                    }
                    catch { }
                    try
                    {
                        double average = ch1CM_CMK.calculate_average(ch1ReadingList);
                        wSheet.Cells[rowIndex + 2, colIndex + 1] = Math.Round(average, 2);
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        double average = ch1CM_CMK.calculate_average(ch1ReadingList);
                        wSheet.Cells[rowIndex, colIndex] = "Average";
                        wSheet.Cells[rowIndex, colIndex + 1] = Math.Round(average, 2);
                    }
                    catch { }
                }
            }
            return wSheet;
        }

        //return the row number that excel start to write the Readings (not counting header)
        //Changed 7/31/18
        private int getStartRowExcelData(string tabName)
        {
            const int toolRowCount = 5;
            int returnRow = 3;//1st row is tab name, 2nd row is column header

            switch (tabName)
            {
                case SMDSingleTabName://if smd single, check if CM and CMK value is checked
                    //if it's checked, add 2 more rows for CM and CMK
                    if (showCMK_chkBox.Checked == true)
                        returnRow += 3;
                    else
                        returnRow += 1;//for average row
                    //if Tool is selected, add 5 more rows for tools info
                    if (toolID_SC_comboBox.SelectedIndex >= 0)
                    {
                        returnRow += toolRowCount;
                    }
                    break;
                default:
                    break;
            }

            return returnRow;
        }
        //passed in colName from table, find out if that colName is X or Y of a serie from passed in chart
        private string getSerieNamefrXorY(string thisColName, Chart thisChart)
        {
            foreach (var serie in thisChart.Series)
            {
                if ((serie.XValueMember == thisColName) || (serie.YValueMembers == thisColName))
                    return serie.Name;
            }
            return "";
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private string getColLetter(int colNum)
        {
            string returnVal = "";
            switch (colNum)
            {
                case -1:
                    returnVal = "A";
                    break;
                case 0:
                    returnVal = "B";
                    break;
                case 1:
                    returnVal = "C";
                    break;
                case 2:
                    returnVal = "D";
                    break;
                case 3:
                    returnVal = "E";
                    break;
                case 4:
                    returnVal = "F";
                    break;
                case 5:
                    returnVal = "G";
                    break;
                case 6:
                    returnVal = "H";
                    break;
                case 7:
                    returnVal = "I";
                    break;
                case 8:
                    returnVal = "J";
                    break;
                case 9:
                    returnVal = "K";
                    break;
                case 10:
                    returnVal = "L";
                    break;
                case 11:
                    returnVal = "M";
                    break;
                case 12:
                    returnVal = "N";
                    break;
                case 13:
                    returnVal = "O";
                    break;
                case 14:
                    returnVal = "P";
                    break;
                case 15:
                    returnVal = "Q";
                    break;
                case 16:
                    returnVal = "R";
                    break;
                case 17:
                    returnVal = "S";
                    break;
                case 18:
                    returnVal = "T";
                    break;
                case 19:
                    returnVal = "U";
                    break;
                case 20:
                    returnVal = "V";
                    break;
                case 21:
                    returnVal = "W";
                    break;
                case 22:
                    returnVal = "X";
                    break;
                case 23:
                    returnVal = "Y";
                    break;
                case 24:
                    returnVal = "Z";
                    break;
                default:
                    returnVal = "";
                    break;

            }
            return returnVal;
        }
        private void saveCurrRun_1chann_button_Click(object sender, EventArgs e)
        {
            string path = getSavePathName(currColumn);
            if ((path != "") && (path.Contains(".xls")))
                saveExcel(path, singleTable, lineChart);
        }

        private void refresh2_Click(object sender, EventArgs e)
        {
            refreshComList();
        }
        private const string quickExportError = "Please go into File-Define Quick Export Path to state the default Saved Location for this function";
        private void quickExport_Click_1(object sender, EventArgs e)
        {
            string fileName = currColumn + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
            string path = Path.Combine(getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName), fileName);
            quickExportToExcel(path, singleTable, lineChart);
        }

        //quick export Datatable into Excel
        //Changed 1/3/18
        private void quickExportToExcel(string path, DataTable thisTable, int chartType)
        {
            try
            {
                try
                {
                    saveExcel(path, thisTable, chartType);
                }
                catch
                {
                    MessageBox.Show("Unable to save file. Please make sure the program has access to save to " + path);
                }

            }
            catch (NullReferenceException nullError)
            {
                MessageBox.Show(quickExportError, "Define Quick Export Path");
            }
            catch (Exception error)
            {
                MessageBox.Show("Unable to Export to Excel due to error: \n" + error.Message);
            }
        }
        private LowHighTarget setHighLowTarget()
        {
            LowHighTarget returnLowHighTarget = new LowHighTarget();
            float lowLimit, highLimit, target_float;
            target_float = Convert.ToSingle(target.Text);
            target_value = target_float;
            highLimit = Convert.ToSingle(high_limit.Text);
            lowLimit = Convert.ToSingle(low_limit.Text);
            if (high_percent.Checked == true)//when high_percent is checked
            {
                returnLowHighTarget.high = target_float + target_float * highLimit / 100;
            }
            else//when high_unit is checked
            {
                returnLowHighTarget.high = highLimit;
            }

            if (low_percent.Checked == true)//when low_percent is checked
            {
                returnLowHighTarget.low = target_float - target_float * lowLimit / 100;
            }
            else//when low_unit is checked
            {
                returnLowHighTarget.low = lowLimit;
            }

            return returnLowHighTarget;
        }
        private void drawLimit_singleChannel()
        {
            if (isHighLow == false)
            {
                //initChartSerie(ref chart1, "target");
                //initChartSerie(ref chart1, "low");
                //initChartSerie(ref chart1, "high");
                initChartSerie(ref singleChart, "target");
                initChartSerie(ref singleChart, "low");
                initChartSerie(ref singleChart, "high");
            }

            isHighLow = true;

            LowHighTarget lowhightarget = setHighLowTarget();
            high = lowhightarget.high;
            low = lowhightarget.low;

            //updateTableandChart(ref chart1, singleChannel_gridView);
            updateTableandChart(ref singleChart, singleChannel_gridView);
        }

        private void draw_limit_Click(object sender, EventArgs e)
        {
            drawLimit_singleChannel();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            RowCountMax.Value = numericUpDown2.Value;
            numericUpDown1.Value = numericUpDown2.Value;
        }
        private void removeSerie(ref Chart chart, string serieName)
        {
            Series serie = chart.Series[serieName];
            chart.Series.Remove(serie);
        }
        //changed 9/22/17
        private void clear_limit_Click(object sender, EventArgs e)
        {
            high = 0;
            target_value = 0;
            low = 0;
            if (isHighLow == true)
            {
                //removeSerie(ref chart1, "target");
                removeSerie(ref singleChart, "target");
                //removeSerie(ref chart1, "low");
                //removeSerie(ref chart1, "high");
                removeSerie(ref singleChart, "low");
                removeSerie(ref singleChart, "high");
            }
            isHighLow = false;
        }

        //only enable Draw Limit button when all fields target, high, low are filled out
        private void updateInterface()
        {
            draw_limit.Enabled = !string.IsNullOrWhiteSpace(this.target.Text) && !string.IsNullOrWhiteSpace(this.low_limit.Text) && !string.IsNullOrWhiteSpace(this.high_limit.Text);
        }

        private void target_TextChanged(object sender, EventArgs e)
        {
            updateInterface();
        }
        private void target_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (draw_limit.Enabled == true))
                drawLimit_singleChannel();
        }

        private void high_limit_TextChanged(object sender, EventArgs e)
        {
            updateInterface();
        }
        private void high_limit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (draw_limit.Enabled == true))
                drawLimit_singleChannel();
        }

        private void low_limit_TextChanged(object sender, EventArgs e)
        {
            updateInterface();
        }
        private void low_limit_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) && (draw_limit.Enabled == true))
                drawLimit_singleChannel();
        }
        //Param: Command to write to Serial Port and which serial port to write to
        //Return feed back from tester
        public static string write_command(string command, SerialPort port)
        {
            string returnvalue = "";
            string err;
            if (port.IsOpen)
            {
                try
                {
                    port.ReadTimeout = maxReadTimeOut;
                    port.Write(command);
                    returnvalue = port.ReadTo(";");

                }
                catch (Exception e)
                {

                }
            }
            return returnvalue;
        }

        //Read each line separately instead of everything, this is used primarily for requesting reading from timer
        public string write_commandForTimer(string command, SerialPort port)
        {
            string returnvalue = "";
            if (port.IsOpen)
            {
                try
                {
                    port.ReadTimeout = maxReadTimeOut;
                    port.Write(command);
                    returnvalue = port.ReadTo(";");
                    if (returnvalue.EndsWith(";"))
                        returnvalue = returnvalue.Substring(0, returnvalue.Length - 1);
                }
                catch { }
            }
            return returnvalue;
        }
        //This procedure need to be called everytime new Test/Serie is added
        private void createNewSerie_SingleChannel(string serieName)
        {
            try
            {
                //initChartSerie(ref chart1, serieName);
                initChartSerie(ref singleChart, serieName);
                DataColumn column = new DataColumn(serieName);
                column.AllowDBNull = true;

                singleTable.Columns.Add(column);
                currColumn = serieName;
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
            }
        }
        bool askToClearData = true;
        private void add_serie_Click(object sender, EventArgs e)
        {
            //Save current run and show on nocurrentGrid
            copyTable(ref singleTable, ref noCurrentTable);
            bindTable();

            //Add New Run
            if (masterGridView.ColumnCount >= (maxRuns + 1))
            {
                MessageBox.Show("Please limit your Runs to " + maxRuns + " Runs");
            }
            else
            {
                FormAddRun frm = new FormAddRun();
                frm.ShowDialog();

                if (FormAddRun.newRunName.Length > 0)
                {
                    createNewSerie_SingleChannel(FormAddRun.newRunName);
                    askToClearData = false;
                    clearGrid(ref singleChannel_gridView);
                    updateCurrentRunAndSingleChanLabel(currColumn);
                }
            }
            PreventGridSort(ref masterGridView);
            PreventGridSort(ref masterGrid_noCurrent);
            updateCurrentRunAndSingleChanLabel(currColumn);//Update Label for CurrentRunText

            //Show Series on checked list for single Channel
            arr_singleSeries = getListOfSeriesName(singleChart);
            AddSerieToCheckList(ref singleSeriesListView, arr_singleSeries);
            updateListViewColor(ref singleSeriesListView, singleChart);//update color for seriesListView

            changeGridAutoColumnSize(ref masterGrid_noCurrent, colThreshold);
        }

        //delete serie from a chart
        //Added 8/27/17
        private void deleteSerie(ref Chart chart, string serieName)
        {
            Series serie = chart.Series[serieName];
            chart.Series.Remove(serie);
        }

        //Changed 8/27/17
        private void delete_column_Click(object sender, EventArgs e)
        {
            Form_Delete frm = new Form_Delete();
            frm.ShowDialog();

            string deleteColumn = Form_Delete.deleteColumn;
            if (deleteColumn.Length > 0)
            {
                try
                {
                    //deleteSerie(ref chart1, deleteColumn);
                    deleteSerie(ref singleChart, deleteColumn);

                    singleTable.Columns.Remove(deleteColumn);
                    noCurrentTable.Columns.Remove(deleteColumn);
                    masterGridView.Refresh();

                    //updateTableandChart(ref chart1,singleChannel_gridView);
                    updateTableandChart(ref singleChart, singleChannel_gridView);

                    //}
                    removeSerieFrCheckList(deleteColumn, ref singleSeriesListView);
                    //update color for seriesListView
                    updateListViewColor(ref singleSeriesListView, singleChart);
                }
                catch (System.Exception excep) { MessageBox.Show(excep.Message); }
            }
            bindTable();
            PreventGridSort(ref masterGridView);
            updateCurrentRunAndSingleChanLabel(currColumn);//Update Label for CurrentRunText
            changeGridAutoColumnSize(ref masterGrid_noCurrent, colThreshold);
        }

        //return true if passed in colname can be used
        public static Boolean checkColumnNameCanBeUsed(string colName, DataTable thisTable)
        {
            if (colName == "") //|| (thisTable.Columns.Count<=0))
                return false;
            for (int i = 0; i < thisTable.Columns.Count; i++)
            {
                if (thisTable.Columns[i].ColumnName == colName)
                    return false;
            }
            return true;
        }

        //return true if passed in serieName can be used for passed in dualChart
        public static Boolean checkSerieNameCanBeUsed(string serieName, List<string> serieList)
        {
            if (serieName == "")
                return false;
            bool nameCheck = true;
            foreach (var ListSerie in serieList)
            {
                if (ListSerie == serieName)
                    nameCheck = false;
            }
            return nameCheck;
        }

        private void changeCh1ChartName(string oldColName, string newName)
        {
            //change the chart y serie to current col_nameText
            //chart1.Series[oldColName].Name = newName;
            //chart1.Series[newName].YValueMembers = newName;

            singleChart.Series[oldColName].Name = newName;
            singleChart.Series[newName].YValueMembers = newName;

            currColumn = singleTable.Columns[singleTable.Columns.Count - 1].ColumnName;

            //updateTableandChart(ref chart1, singleChannel_gridView);
            updateTableandChart(ref singleChart, singleChannel_gridView);
        }
        //change column name of passed in grid and the index of the column, this also changes the "table" structure(used for mastergridview)
        private void ChangeColName(string oldColName, string newName, int colIndex, ref DataTable thisTable)
        {
            if (colIndex > -1)
            {
                //change table header to the text in col_nameText
                thisTable.Columns[colIndex].ColumnName = newName;

                //change nocurrenttable w new Column name too
                if (checkColumnNameCanBeUsed(oldColName, noCurrentTable) == false)
                {
                    noCurrentTable.Columns[colIndex].ColumnName = newName;
                }
            }

        }

        //change name of column for mastergrid and table
        private void rename_col_Click(object sender, EventArgs e)
        {
            var frm = new FormRename();
            frm.ShowDialog();
            if ((frm.newName.Length > 0) && (frm.oldName.Length > 0))
            {
                ChangeColName(frm.oldName, frm.newName, frm.columnIndex, ref singleTable);
                changeCh1ChartName(frm.oldName, frm.newName);
                updateCurrentRunAndSingleChanLabel(currColumn);
            }
            bindTable();
            masterGrid_noCurrent.Refresh();
            updateCurrentRunAndSingleChanLabel(currColumn);//Update Label for CurrentRunText

            //Show Series on checked list for single Channel
            arr_singleSeries = getListOfSeriesName(singleChart);
            //removeSerieFrCheckList(frm.oldName,ref singleSeriesListView);//Remove the old one
            //AddSerieToCheckList(ref singleSeriesListView, arr_singleSeries);
            renameSerieInListView(frm.oldName, frm.newName, ref singleSeriesListView);
            updateListViewColor(ref singleSeriesListView, singleChart);//update color for seriesListView
        }

        private void masterQuickExport_Click(object sender, EventArgs e)
        {
            clearEmptyRow(ref noCurrentTable);
            string fileName = testName_Text.Text;
            testName_Text.Clear();
            //if user doesn't enter test name, default to TTS_export-date
            if (fileName.Length == 0)
                fileName = "TTS_export-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
            if (noCurrentTable.Rows.Count > 0)
            {
                isMasterSave = true;
                string path = Path.Combine(getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName), fileName + ".xls");
                quickExportToExcel(path, noCurrentTable, lineChart);
            }
        }

        private void masterSave_Click(object sender, EventArgs e)
        {
            clearEmptyRow(ref noCurrentTable);
            if (noCurrentTable.Rows.Count > 0)
            {
                isMasterSave = true;
                string path = getSavePathName(testName_Text.Text);
                if ((path != "") && (path.Contains(".xls")))
                    saveExcel(path, noCurrentTable, lineChart);
            }
        }
        private void openCloseSecondPort_Click(object sender, EventArgs e)
        {
            openCloseSecondChannel(ref comList4);
        }

        //This method open or close second COM, call whenever Open/Close Second Com button is clicked
        private void openCloseSecondChannel(ref ListBox thisList)
        {
            string currentPort = extractCOM(thisList.SelectedItem.ToString());
            opencloseSecondCom(currentPort, thisList);
            changeWinSize(TabPages.SelectedTab.Name);//Call this to ping or unping tester
            channel2MenuButtonUpdate();

        }
        //Change Menu button and Mode appearance for Second Channel
        private void channel2MenuButtonUpdate()
        {
            if (serialPort2.IsOpen)
            {
                chan2_modeControl_button.Text = chann2Control.getStringMode();
                chan2_menuControl_button.Enabled = true;

                ch2ModeControlBtn_calTab.Text = chann2Control.getStringMode();
                ch2MenuControlBtn_calTab.Enabled = true;
            }
            else
            {
                chan2_modeControl_button.Text = "Mode";
                chan2_menuControl_button.Enabled = false;

                ch2ModeControlBtn_calTab.Text = "Mode";
                ch2MenuControlBtn_calTab.Enabled = false;
            }
        }
        private void refresh_dualTab_Click(object sender, EventArgs e)
        {
            refreshComList();
        }

        private void updateDualTableAndChart()
        {
            updateDualChanTable();
            updateDualChart(ref dualChart);
        }
        private void deleteLineFirst_Click(object sender, EventArgs e)
        {
            if (firstChannelGrid.RowCount > 0)
                deleteRow(firstChannelGrid.CurrentCell.RowIndex);
            updateDualTableAndChart();
        }

        private void updateCurrentRunAndSingleChanLabel(string name)
        {
            currentRunText.Text = name;
        }

        private void testName_Text_TextChanged(object sender, EventArgs e)
        {
            if (testName_Text.Text.Length > 0)
                masterQuickExport.Enabled = true;
            else
            {
                masterQuickExport.Enabled = false;
            }
        }

        //copy datatable from frTable to toTable
        private void copyTable(ref DataTable frTable, ref DataTable toTable)
        {
            toTable = frTable.Copy();
        }

        private void saveCurrent_button_Click(object sender, EventArgs e)
        {
            clearEmptyRow(ref singleTable);
            copyTable(ref singleTable, ref noCurrentTable);
            bindTable();

            changeGridAutoColumnSize(ref masterGrid_noCurrent, colThreshold);
        }

        private void addDualRun_Click(object sender, EventArgs e)
        {
            //Show Form to ask for Serie Name, CHan1 and Chan2 names
            FormAddDualRun frm = new FormAddDualRun();
            frm.ShowDialog();
            if (frm.allNamesValid == true)
            {
                //Save the Last Run to noCurrDualTable
                saveToNoCurrDualTable();

                //Update currentDualSeries, currRunName1 and 2
                currentDualSerie = frm.newRunName;
                currRunName1 = frm.chan1Name;
                currRunName2 = frm.chan2Name;

                if (xAxis == 1)
                {//if Channel1 is x, add channel1, then add channel2 to dualTable
                    tableAddCol(ref dualTable, currRunName1, 0);
                    tableAddCol(ref dualTable, currRunName2, 1);
                }
                else//if Channel2 is x, add channel2, then add channel1 to dualTable
                {
                    tableAddCol(ref dualTable, currRunName2, 0);
                    tableAddCol(ref dualTable, currRunName1, 1);
                }

                //clear Current reading for both channels
                clearGrid(ref firstChannelGrid);

                //Delete all empty row in secondchannelTable
                initSecondChannelTable();

                //Add New Series to Graph
                initChartSerie(ref dualChart, currentDualSerie);
                //Assign X and Y for currentDualSerie
                updateDualChartSerieXY(currentDualSerie, ref dualChart, dualTable, 0, 1);
                //Save list of Series from dualChart into ar_dualSeries
                arr_dualSeries = getListOfSeriesName(dualChart);
                //Update the listView with passed in array of List String
                AddSerieToCheckList(ref dualSeriesListView, arr_dualSeries);
                //update color for seriesListView
                updateListViewColor(ref dualSeriesListView, dualChart);

                PreventGridSort(ref noCurrDualMasterGrid);
            }
            Enable_Disable_xyButton();
            updateDualCurrentRunAndChanLabel();
        }

        private void clearSecond_Click(object sender, EventArgs e)
        {
            secondChannelTable.Rows.Clear();
            updateDualTableAndChart();
        }

        //remove a row from secondChannelTable
        private void removeSecondTableRow(int index)
        {
            if (index < secondChannelTable.Rows.Count)
            {
                secondChannelTable.Rows.RemoveAt(index);
            }
        }

        //delete button for second channel gridview 
        private void deleteSecond_Click(object sender, EventArgs e)
        {
            if (secondChannelGridView.Rows.Count > 0)
                removeSecondTableRow(secondChannelGridView.CurrentCell.RowIndex);
            updateDualTableAndChart();
        }

        private void clearFirst_Click(object sender, EventArgs e)
        {
            clearGrid(ref firstChannelGrid);
            updateDualTableAndChart();
        }

        //delete both the Serie from passed in chart and the tableColumn that are associated with that serie from passed in table
        private void deleteSerie_and_Table(ref Chart thisChart, ref DataTable thisTable, string serieToDelete)
        {
            string tableChan1Name, tableChan2Name;
            try
            {
                tableChan1Name = thisChart.Series[serieToDelete].YValueMembers;
                tableChan2Name = thisChart.Series[serieToDelete].XValueMember;

                //remove 2 Column that associated with serie
                thisTable.Columns.Remove(tableChan1Name);
                thisTable.Columns.Remove(tableChan2Name);

                //remove serie
                removeSerie(ref thisChart, serieToDelete);
            }
            catch
            {
                MessageBox.Show("Unable to delete Serie " + serieToDelete);
            }
        }

        private void deleteDualRun_Button_Click(object sender, EventArgs e)
        {
            Form_DualDelete frm = new Form_DualDelete();
            frm.ShowDialog();
            string SerieToDelete = "";
            SerieToDelete = frm.deleteSerie;
            if (SerieToDelete != "")
            {
                deleteSerie_and_Table(ref dualChart, ref dualTable, SerieToDelete);
                saveToNoCurrDualTable();//update noCurrDualTable
                arr_dualSeries = getListOfSeriesName(dualChart);
                removeSerieFrCheckList(SerieToDelete, ref dualSeriesListView);
                //update color for seriesListView
                updateListViewColor(ref dualSeriesListView, dualChart);
            }
            Enable_Disable_xyButton();
            updateDualCurrentRunAndChanLabel();
            changeGridAutoColumnSize(ref noCurrDualMasterGrid, colThreshold);
        }

        private void openCloseFirstPort_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList4);
            channel1MenuButtonUpdate();
        }

        //Control the visibilities of the passed in Chart's series, based on passed in listBox selection
        private void ShowHideChartSeries(ListView listBox, ref Chart thisChart)
        {
            string itemTxt = "";
            for (int index = 0; index < listBox.Items.Count; index++)
            {
                itemTxt = listBox.Items[index].Text;
                if (listBox.Items[index].Checked == true)
                    thisChart.Series[itemTxt].Enabled = true;
                else
                {
                    thisChart.Series[itemTxt].Enabled = false;
                }
            }
        }
        private void serieListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ShowHideChartSeries(seriesListView,ref dualChart);
        }
        private void singleSeriesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ShowHideChartSeries(singleSeriesListView, ref singleChart);
        }
        private void dualSeriesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            ShowHideChartSeries(dualSeriesListView, ref dualChart);
        }
        //pass in oldSt and newSt, if newSt is empty then return oldSt
        private string checkEmptyName(string oldSt, string newSt)
        {
            if (newSt != "")
                return newSt;
            else
            {
                return oldSt;
            }
        }

        private void test_save_button_Click(object sender, EventArgs e)
        {
            clearEmptyRow(ref dualTable);
            if (dualTable.Rows.Count > 0)
            {
                isMasterSave = true;
                string path = getSavePathName(dualTestName_Text.Text);
                if ((path != "") && (path.Contains(".xls")))
                    saveExcel(path, dualTable, pointChart);
            }
        }

        private void quickDualExport_button_Click(object sender, EventArgs e)
        {
            clearEmptyRow(ref dualTable);
            string fileName = dualTestName_Text.Text;
            dualTestName_Text.Clear();
            if (fileName == "")
                fileName = "TTS_export-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            if (dualTable.Rows.Count > 0)
            {
                isMasterSave = true;
                string path = Path.Combine(getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName), fileName + ".xls");
                saveExcel(path, dualTable, pointChart);
            }
        }

        private void defineTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Zero The Tester
        public static void zeroControl(SerialPort port)
        {
            if (port.IsOpen)
                write_command("!MZ;", port);
        }
        private void zeroControl_button_Click(object sender, EventArgs e)
        {
            zeroControl(serialPort1);
        }
        //call this method to cycle Unit of the tester
        private void unitControl(SerialPort thisPort, ref TesterControl thisTesterControl)
        {
            if (thisPort.IsOpen)
            {
                int currUnitCode = -1;
                string queryMsg = "";
                string message = write_command("?U;", thisPort);
                try
                {
                    if (message.Length > 0)
                    {
                        currUnitCode = Int32.Parse(message[0].ToString());
                    }
                    if (currUnitCode >= 0) //Able to get current Unit
                    {
                        queryMsg = thisTesterControl.cycleUnit(currUnitCode);
                        write_command(queryMsg, thisPort);
                    }
                }
                catch
                {
                    MessageBox.Show("Unable to change Unit");
                }
            }
        }
        private void unitControl_button_Click(object sender, EventArgs e)
        {
            unitControl(serialPort1, ref chann1Control);
        }

        private void command_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                test_label.Text = write_command(command_text.Text, serialPort1);
        }

        //Call to change savestart button appearance
        private void changeSaveStartTestBtn()
        {
            //if all fields are filled, enabled the save start test
            if (canTestBeSaved() == true)
            {
                saveStartTest_btn.Text = "Save";
                saveStartTest_btn.Enabled = true;
                startTest_btn.Text = "Save Test";
            }
        }

        //Check to see whether input Key is Tab or Enter in Test Fields, then change the quadrants
        private void changeQuadrantsWhenFieldsChange(Keys inputKey, Keys keyToCompare)
        {
            changeSaveStartTestBtn();
            if (inputKey == keyToCompare)
            {
                FSLowHighchanged();
            }
        }
        
        //Handle event BEFORE Key has been pressed
        private void lowLimit_txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Tab);
        }
        private void highLimit_txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Tab);
        }
        private void FS_txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Tab);
        }
        private void maxPoint_txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Tab);
        }

        private void testID_txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Tab);
        }

        private void sampleNum_txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Tab);
        }


        //Handle event AFTER Key has been pressed
        private void lowLimit_txt_Keydown(object sender, KeyEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);
        }
        private void highLimit_txt_Keydown(object sender, KeyEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);
        }
        private void FS_txt_Keydown(object sender, KeyEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);
        }
        private void maxPoint_txt_Keydown(object sender, KeyEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);
        }

        private void testID_txt_Keydown(object sender, KeyEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);
        }

        private void sampleNum_txt_Keydown(object sender, KeyEventArgs e)
        {
            changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);
        }

        private void ch1Unit_txt_Keydown(object sender, KeyEventArgs e)
        {
            //changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter); No need to rewrite Quadrants
        }

        private void ch2Unit_txt_Keydown(object sender, KeyEventArgs e)
        {
            //changeQuadrantsWhenFieldsChange(e.KeyCode, Keys.Enter);No need to rewrite Quadrants
        }

        private void limitEngPercent_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeQuadrantsWhenFieldsChange(Keys.Tab, Keys.Tab);
        }
        //Cycle Mode for tester
        private string modeControl(SerialPort thisPort, ref TesterControl thisTesterControl)
        {
            string newMode = "Mode";
            if (thisPort.IsOpen)
            {
                string queryCommand = "";
                queryCommand = thisTesterControl.cycleMode();
                write_command(queryCommand, thisPort);
                thisTesterControl.updateCurrMode(write_command("?M;", thisPort));
                newMode = thisTesterControl.getStringMode();
            }
            return newMode;
        }
        private void modeControl_button_Click(object sender, EventArgs e)
        {
            modeControl_button.Text = modeControl(serialPort1, ref chann1Control);
        }
        //Capture by remote Control, pass in the serialPort and testerControl and channel number. 
        //If channel 1 then also add to first channel gridview, not support for channel=2 yet
        private void readFromFirstChannel(SerialPort thisPort, TesterControl testerControl, int channel)
        {
            pauseLiveReading1 = true;
            string ChannMessage = "";
            try
            {
                ChannMessage = write_command("E", thisPort);
                decodeMessage(ChannMessage, testerControl.getcurrUnitClass(), channel);
                writeToFirstChanGrid();
            }
            catch
            {
                pauseLiveReading1 = false;
            }
            pauseLiveReading1 = false;
        }
        private void enterControl_button_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                readFromFirstChannel(serialPort1, chann1Control, 1);

        }

        /// <summary>
        /// This method is called when Menu button is clicked for TesterControl.
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="TesterControl"></param>
        private void menuControl(SerialPort thisPort, ref TesterControl thisTesterControl, string channel)
        {
            if (thisPort.IsOpen)
            {
                Form_MenuControl frm = new Form_MenuControl(thisPort, ref thisTesterControl, channel);
                frm.ShowDialog();

            }
        }
        private void menuControl_button_Click(object sender, EventArgs e)
        {
            menuControl(serialPort1, ref chann1Control, channel1);
        }
        //copy 1 gridview to another.
        private void copyGridView(DataGridView fromGrid, ref DataGridView toGrid)
        {
            //Make both grids have the same amount of rows
            while (toGrid.RowCount != fromGrid.RowCount)
            {
                if (toGrid.RowCount < fromGrid.RowCount)
                    toGrid.Rows.Add();
                else
                {
                    toGrid.Rows.RemoveAt(0);
                }
            }

            //Copy the actual data to toGrid
            for (int rowIndex = 0; rowIndex < fromGrid.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < fromGrid.ColumnCount; colIndex++)
                    toGrid.Rows[rowIndex].Cells[colIndex].Value = fromGrid.Rows[rowIndex].Cells[colIndex].Value;
            }

        }

        //When 1 of the firstChannel Grid change, change all grid for first channel
        //changed 3/27/18
        private void copyAllFirstChannelGridView(DataGridView thisGrid)
        {
            copyGridView(thisGrid, ref gridview);
            /*
            
            copyGridView(thisGrid, ref singleChannel_gridView);
            copyGridView(thisGrid, ref firstChannelGrid);
            */
        }
        ///////////////////////Handle User changing value from our gridview        
        private void gridview1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //updateTableandChart(ref chart1,singleChannel_gridView);
            updateTableandChart(ref singleChart, singleChannel_gridView);
            copyAllFirstChannelGridView(singleChannel_gridView);
            updateSampleNuminGrid(ref singleChannel_gridView, singleChannel_gridView.RowCount - 2);
            updateSampleNuminGrid(ref firstChannelGrid, firstChannelGrid.RowCount - 2);

        }
        private void gridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //updateTableandChart(ref chart1, gridview);
            updateTableandChart(ref singleChart, gridview);
            copyAllFirstChannelGridView(gridview);
        }
        private void firstChannelGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int beforeRowCount = singleChannel_gridView.RowCount;
            //updateTableandChart(ref chart1, firstChannelGrid);
            //updateTableandChart(ref singleChart, firstChannelGrid);
            updateDualTableAndChart();
            copyAllFirstChannelGridView(firstChannelGrid);

            int afterRowCount = firstChannelGrid.RowCount;

            if ((serialPort2.IsOpen) && (afterRowCount > beforeRowCount))
                readFromSecondChannel();

            updateSampleNuminGrid(ref singleChannel_gridView, singleChannel_gridView.RowCount - 2);
            updateSampleNuminGrid(ref firstChannelGrid, firstChannelGrid.RowCount - 2);
        }

        private void secondChannelGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            updateDualTableAndChart();
            if (firstChannelGrid.CurrentRow.Index >= 0)
                FocusGridViewRow(ref secondChannelGridView, firstChannelGrid.CurrentRow.Index);
        }
        //Focus on a row of gridview
        private void FocusGridViewRow(ref DataGridView thisGrid, int rowIndex)
        {
            try
            {
                thisGrid.CurrentCell.Selected = false;
                thisGrid.Rows[rowIndex].Selected = true;
            }
            catch { }
        }
        private void firstChannelGridSelect(object sender, EventArgs e)
        {
            try
            {
                FocusGridViewRow(ref secondChannelGridView, firstChannelGrid.CurrentRow.Index);
            }
            catch { }
        }
        ////////////////////End Handling User changing value from gridview

        private string convertCharToHexStr(char charToConvert)
        {
            string signLockValue = "";
            byte[] SLbytes = BitConverter.GetBytes(charToConvert);
            signLockValue = BitConverter.ToString(SLbytes, 0, 1);
            return signLockValue;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            test_label.Text = convertCharToHexStr('8');
        }
        //if max column is greater than passed in val, change from fill to All Cell
        private void changeGridAutoColumnSize(ref DataGridView thisGrid, int thiscolThreshold)
        {
            if (thisGrid.ColumnCount > thiscolThreshold)
                thisGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            else
                thisGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void saveToNoCurrDualTable()
        {
            clearEmptyRow(ref dualTable);
            copyTable(ref dualTable, ref noCurrentDualTable);
            bindDualTable();
            changeGridAutoColumnSize(ref noCurrDualMasterGrid, colThreshold);
        }
        //save noCurrentDual Run to grid to display
        private void saveRun_button_Click(object sender, EventArgs e)
        {
            saveToNoCurrDualTable();
        }

        private void chann1_zeroControl_button_Click(object sender, EventArgs e)
        {
            zeroControl(serialPort1);
        }

        private void chan2_zeroControl_button_Click(object sender, EventArgs e)
        {
            zeroControl(serialPort2);
        }

        private void chan1_unitControl_button_Click(object sender, EventArgs e)
        {
            unitControl(serialPort1, ref chann1Control);
        }

        private void chan2_unitControl_button_Click(object sender, EventArgs e)
        {
            unitControl(serialPort2, ref chann2Control);
        }

        private void chan1_modeControl_button_Click(object sender, EventArgs e)
        {
            chan1_modeControl_button.Text = modeControl(serialPort1, ref chann1Control);
        }

        private void chan2_modeControl_button_Click(object sender, EventArgs e)
        {
            chan2_modeControl_button.Text = modeControl(serialPort2, ref chann2Control);
        }

        private void chan1_menuControl_button_Click(object sender, EventArgs e)
        {
            menuControl(serialPort1, ref chann1Control, channel1);
        }

        private void chan2_menuControl_button_Click(object sender, EventArgs e)
        {
            menuControl(serialPort2, ref chann2Control, channel2);
        }

        private void captureReadingsFromBothChannel()
        {
            if (serialPort1.IsOpen)
            {
                readFromFirstChannel(serialPort1, chann1Control, 1);
            }
            if (serialPort2.IsOpen)
                readFromSecondChannel();
        }
        private void chan1_captureControl_button_Click(object sender, EventArgs e)
        {
            captureReadingsFromBothChannel();
        }

        private string showFolderBrowserDialog()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            string path = "";
            path = fbd.SelectedPath;
            return path;
        }
        private void defineQuickExportPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string defaultPath = "";
            defaultPath = showFolderBrowserDialog();
            if (defaultPath != "")
            {
                setRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName, defaultPath);
            }

            test_label.Text = getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName);

        }

        private void switchTestCalMode_button_Click(object sender, EventArgs e)
        {
            if (switchTestCalMode_button.Text == "Test Mode")
            {
                switchTestCalMode_button.Text = "Cal Mode";
                groupBox16.Enabled = false;
                currRunDualSaveExcel.Enabled = false;
                dualCertExport_button.Enabled = true;

            }
            else
            {
                switchTestCalMode_button.Text = "Test Mode";
                groupBox16.Enabled = true;
                currRunDualSaveExcel.Enabled = true;
                dualCertExport_button.Enabled = false;
            }
        }

        private void showALLCOMAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comListRefresh_Click(this, e);
        }

        //Stream data only has 2 locations, make it 3 to add to gridview 
        private void processStreamLine(string line)
        {
            string[] data = huy_parseData(line);
            if (data.Length <= 2)
                Array.Resize(ref data, 3);

            addrow(data);
        }
        private void readStreamFile()
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(dataLoggerTextPath);
            while ((line = file.ReadLine()) != null)
            {
                processStreamLine(line);//Pass in each line for text and write to data gridview if data is valid
                counter++;
            }

            file.Close();
        }

        private void streamDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool wasChan1Open = false;
            bool wasChan2Open = false;

            //close channel 1 and 2 to release the port for datalogger
            if (serialPort1.IsOpen)
                wasChan1Open = true;
            if (serialPort2.IsOpen)
                wasChan2Open = true;

            closeport(serialPort1.PortName);
            closeSecondport(serialPort2.PortName);

            //run Datalogger
            try
            {
                //Run C:\datalog\win232.exe
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = new ProcessStartInfo(dataLoggerPath);
                p.Start();
                p.WaitForExit();

                //Process data that was written in data.txt
                try
                {
                    var isImport = MessageBox.Show("Do you want to import streaming data? (Import last session's streaming if none was recorded this time)", "Import Streaming?", MessageBoxButtons.YesNo);
                    if (isImport == DialogResult.Yes)
                        readStreamFile();
                }
                catch
                {
                    MessageBox.Show("Unable to Import Data from streaming", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Unable to Open DataLogger Program. Please make sure DataLogger is properly installed.", "Error");
            }
            //Todo: Reconnect Chan1 and chan2 if wasChan1Open and wasChan2Open is true
        }

        private void dualTestName_Text_TextChanged(object sender, EventArgs e)
        {
            if (dualTestName_Text.Text.Length > 0)
                quickDualExport_button.Enabled = true;
            else
            {
                quickDualExport_button.Enabled = false;
            }
        }

        private void currentRunText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                if (currentRunText.Text != currColumn)
                {
                    if (checkColumnNameCanBeUsed(currentRunText.Text, singleTable) == false)
                        runNameErrorLabel.Text = err_uniqueRunName;
                    else
                    {
                        ChangeColName(currColumn, currentRunText.Text, singleTable.Columns.IndexOf(currColumn), ref singleTable);
                        changeCh1ChartName(currColumn, currentRunText.Text);
                        runNameErrorLabel.Text = "";
                        this.ActiveControl = null;//move focus out of the currentRunText
                    }
                }
                else
                {
                    runNameErrorLabel.Text = "";
                    this.ActiveControl = null;//move focus out of the currentRunText
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                currentRunText.Text = currColumn;
                runNameErrorLabel.Text = "";
                this.ActiveControl = null;//move focus out of the currentRunText
            }
        }
        //update Ch1 ColName after pressing Enter on currentRunText
        private void dualCh1RunName_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                if (dualCh1RunName_Text.Text != currRunName1)
                {
                    if (checkColumnNameCanBeUsed(dualCh1RunName_Text.Text, dualTable) == false)
                        dualRunName1ErrorLabel.Text = err_uniqueRunName;
                    else
                    {
                        ChangeColName(currRunName1, dualCh1RunName_Text.Text, dualTable.Columns.IndexOf(currRunName1), ref dualTable);
                        currRunName1 = dualCh1RunName_Text.Text;//update currRunName1
                        dualRunName1ErrorLabel.Text = "";
                        this.ActiveControl = null;//move focus out of the dualRunName1Err...
                    }
                }
                else
                {
                    dualRunName1ErrorLabel.Text = "";
                    this.ActiveControl = null;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dualCh1RunName_Text.Text = currRunName1;
                dualRunName1ErrorLabel.Text = "";
                this.ActiveControl = null;//move focus out of the currentRunText
            }
        }

        //update Ch1 ColName after pressing Enter on currentRunText
        private void dualCh2RunName_Text_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                if (dualCh2RunName_Text.Text != currRunName2)
                {
                    if (checkColumnNameCanBeUsed(dualCh2RunName_Text.Text, dualTable) == false)
                        dualRunName2ErrorLabel.Text = err_uniqueRunName;
                    else
                    {
                        ChangeColName(currRunName2, dualCh2RunName_Text.Text, dualTable.Columns.IndexOf(currRunName2), ref dualTable);
                        currRunName2 = dualCh2RunName_Text.Text;//update currRunName2
                        dualRunName2ErrorLabel.Text = "";
                        this.ActiveControl = null;//move focus out of the dualRunName1Err...
                    }
                }
                else
                {
                    dualRunName2ErrorLabel.Text = "";
                    this.ActiveControl = null;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                dualCh2RunName_Text.Text = currRunName2;
                dualRunName2ErrorLabel.Text = "";
                this.ActiveControl = null;//move focus out of the currentRunText
            }
        }

        private void deleteBothRow_button_Click(object sender, EventArgs e)
        {
            if (firstChannelGrid.RowCount > 0)
            {
                try
                {
                    removeSecondTableRow(firstChannelGrid.CurrentCell.RowIndex);
                    deleteRow(firstChannelGrid.CurrentCell.RowIndex);
                }
                catch { }
            }
            updateDualTableAndChart();
        }

        private void clearBothData_button_Click(object sender, EventArgs e)
        {
            clearGrid(ref firstChannelGrid);
            secondChannelTable.Rows.Clear();
            updateDualTableAndChart();
        }

        //Start New Test
        private void newTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Todo: Instead of Restarting the APP, clear all the values instead
            try
            {
                var dialogResult = MessageBox.Show("Restarting App will clear all your existing Data. Continue?",
                    "Restart Application", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    setRegistryValue(defaultTab_keyName, defaultTab_valueName, TabPages.SelectedIndex.ToString());//Set current defaultTab registry
                    closeport(serialPort1.PortName);
                    closeSecondport(serialPort2.PortName);
                    Process.Start(Application.ExecutablePath);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch
            { }
        }

        private void switchTableHeaders(ref DataTable thisTable, int header1Index, int header2Index)
        {
            string header2Temp = thisTable.Columns[header2Index].ColumnName;
            string header1Temp = thisTable.Columns[header1Index].ColumnName;
            thisTable.Columns[header2Index].ColumnName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            thisTable.Columns[header1Index].ColumnName = header2Temp;
            thisTable.Columns[header2Index].ColumnName = header1Temp;
        }
        private void xySwitch_button_Click(object sender, EventArgs e)
        {
            int temp;
            temp = xAxis;
            xAxis = yAxis;
            yAxis = temp;
            switchTableHeaders(ref dualTable, 0, 1);
            updateDualTableAndChart();
            updatexyAxisButtonText();
        }
        //copy and return data table that only has Columns index that are passed in
        private DataTable copyColumnsFromTable(DataTable fromTable, int frColIndex, int toColIndex)
        {
            DataTable returnTable = new DataTable();
            //in case passed in frColindex is smaller than toColindex, switch them
            if (frColIndex > toColIndex)
            {
                int temp = frColIndex;
                frColIndex = toColIndex;
                toColIndex = frColIndex;
            }
            returnTable = fromTable.Copy();
            for (int index = 0; index < fromTable.Columns.Count; index++)
            {
                if ((index < frColIndex) || (index > toColIndex))
                    returnTable.Columns.Remove(fromTable.Columns[index].ColumnName);
            }
            return returnTable;
        }

        private void currRunDualQuickExport_Click(object sender, EventArgs e)
        {
            string fileName = currentDualSerie + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
            string path = Path.Combine(getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName), fileName);
            DataTable tempTable = (copyColumnsFromTable(dualTable, 0, 1)).Copy();
            if (tempTable.Rows.Count > 0)
            {
                isMasterSave = true;
                quickExportToExcel(path, tempTable, pointChart);
            }
        }

        private void currRunDualSaveExcel_Click(object sender, EventArgs e)
        {
            string path = getSavePathName(currentDualSerie);
            DataTable tempTable = (copyColumnsFromTable(dualTable, 0, 1)).Copy();
            if ((path != "") && (tempTable.Rows.Count > 0))
            {
                isMasterSave = true;
                saveExcel(path, tempTable, pointChart);
            }
        }


        //Change name for newSerie and the columns in dualtable that are associated w that serie
        //also update arr_dualSerie
        private void reNameDualSerieandChan(string oldSerie, string newSerie, string newChan1Name, string newChan2Name)
        {
            string oldChan1Name = "", oldChan2Name = "";
            oldChan1Name = dualChart.Series[oldSerie].YValueMembers;
            oldChan2Name = dualChart.Series[oldSerie].XValueMember;

            //Make sure newName is not empty
            newSerie = checkEmptyName(oldSerie, newSerie);
            newChan1Name = checkEmptyName(oldChan1Name, newChan1Name);
            newChan2Name = checkEmptyName(oldChan2Name, newChan2Name);

            //change currentDualSerie name if that is the serie being changed
            if (currentDualSerie == oldSerie)
                currentDualSerie = newSerie;

            //change new names for dualChart
            dualChart.Series[oldSerie].Name = newSerie;
            dualChart.Series[newSerie].XValueMember = newChan2Name;
            dualChart.Series[newSerie].YValueMembers = newChan1Name;

            //update currRunName1 and currRunName2 if we are changing the current Run
            if (oldChan1Name == currRunName1)
                currRunName1 = newChan1Name;
            if (oldChan2Name == currRunName2)
                currRunName2 = newChan2Name;

            //change new names for dualTable and noCurrDualTable
            dualTable.Columns[oldChan2Name].ColumnName = newChan2Name;
            dualTable.Columns[oldChan1Name].ColumnName = newChan1Name;

            //If nocurrentTable has the Column name then change it
            if (noCurrentTable.Columns.Contains(oldChan2Name))
                noCurrentDualTable.Columns[oldChan2Name].ColumnName = newChan2Name;
            if (noCurrentTable.Columns.Contains(oldChan1Name))
                noCurrentDualTable.Columns[oldChan1Name].ColumnName = newChan1Name;

            //update arr_dualSeries and Checkedlist
            arr_dualSeries = getListOfSeriesName(dualChart);

            //Rename the serie in dualSeriesListView
            renameSerieInListView(oldSerie, newSerie, ref dualSeriesListView);
            //update color for seriesListView
            updateListViewColor(ref dualSeriesListView, dualChart);
        }
        //copy Data from datatable column and return List<string>
        public List<string> copydataTableColToList(System.Data.DataTable thisTable, int colIndex)
        {
            List<string> returnStr = new List<string>();

            foreach (DataRow dr in thisTable.Rows)
            {
                returnStr.Add(dr[colIndex].ToString());
            }

            return returnStr;
        }

        private void renameDualRun_Click(object sender, EventArgs e)
        {
            Form_DualRename frm = new Form_DualRename();
            frm.ShowDialog();
            if ((frm.oldRunName != "") && ((frm.newRunName != "") || (frm.chan1Name != "") || (frm.chan2Name != "")))
            {
                reNameDualSerieandChan(frm.oldRunName, frm.newRunName, frm.chan1Name, frm.chan2Name);
                saveToNoCurrDualTable();//update noCurrDualTable
            }
            updateDualCurrentRunAndChanLabel();
        }

        ////////////////////////Dual Table codes//////////////////////////
        //add new Column Header to Datatable, pass in colname and location of where to add the column 
        private void tableAddCol(ref DataTable thisTable, string colName, int index)
        {
            if (checkColumnNameCanBeUsed(colName, dualTable) == true)
            {
                thisTable.Columns.Add(colName, typeof(float));
                thisTable.Columns[colName].SetOrdinal(index);//set location of column 
            }
        }

        private void bindDualTable()
        {
            dualTableBinding.DataSource = dualTable;
            dualMasterGrid.DataSource = dualTableBinding;

            //bind noCurrentDualTable to noCurrentDualMasterGrid
            noCurrentDualTableBinding.DataSource = noCurrentDualTable;
            noCurrDualMasterGrid.DataSource = null;
            noCurrDualMasterGrid.DataSource = noCurrentDualTable;
        }

        //initiate Datatable dualTable with Reading-Chan1 and Reading-Chan2
        //Also call to bind to dualMasterGrid
        private void initDualTable()
        {
            tableAddCol(ref dualTable, currRunName1, 0);
            tableAddCol(ref dualTable, currRunName2, 0);
            initChartSerie(ref dualChart, currentDualSerie);//Add thisSerie to dualChart
            updateDualChartSerieXY("Reading", ref dualChart, dualTable, 0, 1);
            arr_dualSeries = getListOfSeriesName(dualChart);//copy dualChart Series Collection Names into arr_dualSeries, this is used to check whether newly added Serie Name already existed
            bindDualTable();
        }
        //copy the readings from current grid passed in and write it to datatable at colIndex Column
        private void copyCurrentColToDualTable(ref DataTable thisTable, int colIndex, DataGridView grid, int gridIndex)
        {
            for (int row = 0; row < grid.RowCount; row++)
            {
                if (!grid.Rows[row].IsNewRow)
                {
                    if (row >= thisTable.Rows.Count)
                        thisTable.Rows.Add();
                    try
                    {
                        thisTable.Rows[row][colIndex] =
                            Convert.ToSingle(grid.Rows[row].Cells[gridIndex].Value.ToString());
                    }
                    catch
                    {
                        thisTable.Rows[row][colIndex] = DBNull.Value;
                    }
                }
            }

        }
        //Copy current first and second ChannelGrid reading to dualTable
        private void updateDualChanTable()
        {
            int dualColIndex_CH1, dualColIndex_CH2;
            clearTableColumn(ref dualTable, 0);//clear the first column of dualTable
            clearTableColumn(ref dualTable, 1);//clear the second column of dualTable
            if (xAxis == 1)
            {
                dualColIndex_CH1 = 0;
                dualColIndex_CH2 = 1;
            }
            else
            {
                dualColIndex_CH1 = 1;
                dualColIndex_CH2 = 0;
            }

            copyCurrentColToDualTable(ref dualTable, dualColIndex_CH1, firstChannelGrid, 1);//copy firstChannelGrid Reading to dualtable
            copyCurrentColToDualTable(ref dualTable, dualColIndex_CH2, secondChannelGridView, 0);//copy secondChannelGrid Reading to dualtable

        }
        //return List<string> of all Series Name from passed in chart 
        private List<string> getListOfSeriesName(Chart thisChart)
        {
            List<string> thisList = new List<string>();
            foreach (Series serie in thisChart.Series)
            {
                thisList.Add(serie.Name);
            }
            return thisList;
        }
        //Assign X and Y name for passed in serie
        //Changed 8/29/17
        private void updateDualChartSerieXY(string thisSerie, ref Chart chart, DataTable table, int xTableIndex, int yTableIndex)
        {
            chart.Series[thisSerie].XValueMember = table.Columns[xTableIndex].ColumnName;
            chart.Series[thisSerie].YValueMembers = table.Columns[yTableIndex].ColumnName;
            chart.DataSource = table;
            chart.DataBind();
        }

        //Changed 8/29/17
        private void updateDualChart(ref Chart chart)
        {
            updateDualChartSerieXY(currentDualSerie, ref dualChart, dualTable, 0, 1);

            chart = setChart(chart, currentDualSerie, 2);
            arr_dualSeries = getListOfSeriesName(chart);

            // This block draw chart only from min Y to max Y. Disable it now because I don't think dualChart needs it
            float max = Single.MinValue;
            float min = Single.MaxValue;
            foreach (DataRow tableRow in dualTable.Rows)
            {
                for (int colIndex = 0; colIndex < dualTable.Columns.Count; colIndex++)
                {
                    if ((colIndex % 2 == 0) && (tableRow[colIndex] != DBNull.Value))
                    {
                        max = Math.Max(Single.Parse(tableRow[colIndex].ToString()), max);
                        min = Math.Min(Single.Parse(tableRow[colIndex].ToString()), min);
                    }
                }
            }
            //In case max and min didnt change, assign max=0, min =1(which will be offset by 1 right after)
            if (max == Single.MinValue)
                max = 1;
            if (min == Single.MaxValue)
                min = 1;
            max += 1;
            min -= 1;
            int maxInt = (int)Math.Ceiling(max);
            int minInt = (int)Math.Floor(min);
            try
            {
                chart.ChartAreas[0].AxisX.Maximum = maxInt;
                chart.ChartAreas[0].AxisX.Minimum = minInt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Display the current Run Name and and current DUAL Channel name
        private void updateDualCurrentRunAndChanLabel()
        {
            const string labelStr = "Current Run: ";
            dualCurrRun_label1.Text = labelStr + currentDualSerie;
            dualCurrRun_Label2.Text = labelStr + currentDualSerie;

            dualCh1RunName_Text.Text = currRunName1;
            dualCh2RunName_Text.Text = currRunName2;
        }

        //Check if there are more than 1 Dual Series, then disable XY Axis switch button
        private void Enable_Disable_xyButton()
        {
            if (arr_dualSeries.Count > 1)
            {
                xySwitch_button.FlatStyle = FlatStyle.Standard;
                xySwitch_button.Enabled = false;
            }
            else
            {
                xySwitch_button.FlatStyle = FlatStyle.Flat;
                xySwitch_button.Enabled = true;
            }
        }
        //Read file from passed in fileLoc and return List<string>
        private List<string> readFile_returnListStr(string fileLoc)
        {
            int counter = 0;
            string line;
            List<string> returnListStr = new List<string>();

            // Read the file and add to returnList
            try
            {
                StreamReader file =
                    new System.IO.StreamReader(fileLoc);
                while ((line = file.ReadLine()) != null)
                {
                    returnListStr.Add(line);
                    counter++;
                }

                file.Close();
            }
            catch (Exception ex)
            { }
            return returnListStr;
        }

        //////////////////////////////////START Coding for Calibration/////////////////////////////////////////////////////////////////////
        ///Some button click Method may be randomly put somewhere else////////////////////////////////////////////////////////////////////
        //Return a BindingList<string> that has order of Test Sequence
        private int testType = 0;//1 for Single Channel Test, 2 for Dual Channel Test
        private Color highColor = Color.Red, lowColor = Color.Yellow, passColor = SystemColors.HighlightText;
        private string pointNum_colName, chan1Readings_colName, chan2Readings_colName, target_colName, low_colName, high_colName;//Represent column name of the test Sequence GridView
        private const string AFCW = "As Found-CW", AFCCW = "As Found-CCW", ALCW = "As Left-CW", ALCCW = "As Left-CCW";
        private int dragIndex = -1, dropIndex = -1;
        private readonly string testsequenceCSVLoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\TestSequences.csv";
        private List<TestSetup> testSetups = new List<TestSetup>();
        private BindingList<string> testList = new BindingList<string>();

        private void comRefreshBtn_calTab_Click(object sender, EventArgs e)
        {
            refreshComList();
        }

        private void ch1ConnectBtn_calTab_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList_calibration);
            channel1MenuButtonUpdate();
        }

        private void ch2ConnectBtn_calTab_Click(object sender, EventArgs e)
        {
            openCloseSecondChannel(ref comList_calibration);
        }

        private void ch1ZeroBtn_calTab_Click(object sender, EventArgs e)
        {
            zeroControl(serialPort1);
        }

        private void ch2ZeroBtn_calTab_Click(object sender, EventArgs e)
        {
            zeroControl(serialPort2);
        }

        private void ch1MenuControlBtn_calTab_Click(object sender, EventArgs e)
        {
            menuControl(serialPort1, ref chann1Control, channel1);
        }

        private void ch2MenuControlBtn_calTab_Click(object sender, EventArgs e)
        {
            menuControl(serialPort2, ref chann2Control, channel2);
        }

        private void ch1ModeControlBtn_calTab_Click(object sender, EventArgs e)
        {
            ch1ModeControlBtn_calTab.Text = modeControl(serialPort1, ref chann1Control);
        }

        private void ch2ModeControlBtn_calTab_Click(object sender, EventArgs e)
        {
            ch2ModeControlBtn_calTab.Text = modeControl(serialPort2, ref chann2Control);
        }

        private void ch1UnitBtn_calTab_Click(object sender, EventArgs e)
        {
            unitControl(serialPort1, ref chann1Control);
        }

        private void ch2UnitBtn_calTab_Click(object sender, EventArgs e)
        {
            unitControl(serialPort2, ref chann2Control);
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private int currNumberOfTests = 0;
        private int currTestIndex = -1;
        TestSetup currTestSetup = new TestSetup();
        private void testSetup_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testSetup_comboBox.SelectedIndex > 0) //User select 1 of the saved Test
            {
                currTestIndex = testSetup_comboBox.SelectedIndex - 1;
                initCurrTestSetup(currTestIndex);

                saveStartTest_btn.Enabled = true;
                saveStartTest_btn.Text = "Start";
                startTest_btn.Text = "Start Test";
            }
            else if (testSetup_comboBox.SelectedIndex == 0) //New Test is selected
            {
                newTestReset();

                saveStartTest_btn.Enabled = false;
                saveStartTest_btn.Text = "Save";
                startTest_btn.Text = "Save Test";
            }

        }

        //return true if all neccessary fields are filled for Test Setup
        private bool canTestBeSaved()
        {
            try//check if the numbers in test Fields are valid
            {
                int intTemp;
                if (currTestIndex < 0)//if new test, maxPoint need to be entered
                    Int32.TryParse(maxPoint_txt.Text, out intTemp);
                Int32.TryParse(sampleNum_txt.Text, out intTemp);

                float floatTemp;
                Single.TryParse(FS_txt.Text, out floatTemp);
                Single.TryParse(lowLimit_txt.Text, out floatTemp);
                Single.TryParse(highLimit_txt.Text, out floatTemp);
            }
            catch
            {
                return false;
            }

            if (testID_txt.Text == "")// || (ch1Unit_txt.Text == ""))
            {
                return false;
            }
            /*
            if ((testType_comboBox.SelectedIndex == 1) && (ch2Unit_txt.Text == ""))
                //If Dual Channel test, ch2Unit need to be filled also
            {
                return false;
            }
            */
            return true;
        }
        //reset all Fields in Test Setting, 
        private void newTestReset()
        {
            newTestLoad = true;//prevent checkbox trigger write to grid
            testID_txt.Text = "";
            testType_comboBox.SelectedIndex = -1;
            maxPoint_txt.Text = "";
            sampleNum_txt.Text = "1";
            FS_txt.Text = "";
            lowLimit_txt.Text = "";
            highLimit_txt.Text = "";
            ch1Unit_txt.Text = "";
            ch2Unit_txt.Text = "";
            testID_txt.Enabled = true;
            maxPoint_txt.Enabled = true;
            limitEngPercent_comboBox.SelectedIndex = 0;
            AF_chkbox.Checked = true;
            CW_chkbox.Checked = true;
            AL_chkbox.Checked = true;
            CCW_chkbox.Checked = true;
            newTestLoad = false;//restore checkbox trigger writetogrid
            currTestSetup = new TestSetup();
            currTestSetup.defaultTest = notDefaultTest;

            AFCW_grid.Rows.Clear();
            AFCCW_grid.Rows.Clear();
            ALCW_grid.Rows.Clear();
            ALCCW_grid.Rows.Clear();
        }
        //Assign TestSetup from TestSetups Collection at passed in index
        //Also set the value of the test on screen
        //changed 4/20/20
        private TestSetup initCurrTestSetup(int index)
        {
            TestSetup thisTestSetup = new TestSetup();
            thisTestSetup = testSetups[index];

            //Show test Values on Screen
            testID_txt.Text = thisTestSetup.testID;
            FS_txt.Text = thisTestSetup.FullScale;
            lowLimit_txt.Text = thisTestSetup.low;
            highLimit_txt.Text = thisTestSetup.high;
            if (ch1UnitLabel_calTab.Text!="")
                ch1Unit_txt.Text = ch1UnitLabel_calTab.Text;
            if (ch2UnitLabel_calTab.Text != "")
                ch2Unit_txt.Text = ch2UnitLabel_calTab.Text;
            maxPoint_txt.Text = thisTestSetup.pointAmount;
            sampleNum_txt.Text = thisTestSetup.sampleNum;

            if (thisTestSetup.percent_unit.Contains("Eng. Unit"))
            {
                limitEngPercent_comboBox.SelectedIndex = 1;
            }
            else //if anything other than Unit, default it to %
            {
                limitEngPercent_comboBox.SelectedIndex = 0;
            }

            try
            {
                testType_comboBox.SelectedIndex = Int32.Parse(thisTestSetup.testType) - 1;
            }
            catch
            {
                testType_comboBox.SelectedIndex = 0;
            }

            //Assign currTestSetup so updateTestOrderChecked can use currTestSetup to write to testGrid
            currTestSetup = testSetups[currTestIndex];
            updateTestOrderChecked(thisTestSetup.testOrder);
            checkDefaultTestSelected(currTestSetup);//check if default test then not allow to change certain field

            return thisTestSetup;
        }

        //Check if it is default test then not allow to change testID and maxpoint
        private void checkDefaultTestSelected(TestSetup thisTest)
        {
            if (thisTest.defaultTest == isDefaultTest && thisTest.testID.EndsWith("**"))//if is defaultTest and testID has ** at the end, then it is default test
            {
                testID_txt.Enabled = false;
                maxPoint_txt.Enabled = false;
            }
            else
            {
                testID_txt.Enabled = true;
                maxPoint_txt.Enabled = true;
            }
        }
        //Repopulate all the test Grid after a new test is selected
        private void updateTestGrid(DataTable thisTable, BindingList<string> listOrder)
        {
            //Reset all Test gridview
            AFCW_grid.Rows.Clear();
            AFCCW_grid.Rows.Clear();
            ALCW_grid.Rows.Clear();
            ALCCW_grid.Rows.Clear();

            string pointCol = currTestSetup.get_pointTableHeader();
            string targetCol = currTestSetup.get_targetTableHeader();
            string lowCol = currTestSetup.get_lowTableHeader();
            string highCol = currTestSetup.get_highTableHeader();
            /*
            table Column Name: Point#,Target,Low,High,Order
            grid Col Name: Point,ch1Reading,ch2Reading,Target,Low,High
            */
            foreach (DataRow row in thisTable.Rows)
            {
                switch (row.Field<string>(4))//row 4 is "Order" Column
                {
                    case "1"://Write to AFCW grid
                        if (listOrder.Contains(AFCW))
                            writeRowToTestGrid(ref AFCW_grid, row[pointCol].ToString(), row[lowCol].ToString(), row[targetCol].ToString(), row[highCol].ToString());
                        break;
                    case "2"://Write to AFCCW grid
                        if (listOrder.Contains(AFCCW))
                            writeRowToTestGrid(ref AFCCW_grid, row[pointCol].ToString(), row[lowCol].ToString(), row[targetCol].ToString(), row[highCol].ToString());
                        break;
                    case "3"://Write to ALCW grid
                        if (listOrder.Contains(ALCW))
                            writeRowToTestGrid(ref ALCW_grid, row[pointCol].ToString(), row[lowCol].ToString(), row[targetCol].ToString(), row[highCol].ToString());
                        break;
                    case "4"://Write to ALCCW grid
                        if (listOrder.Contains(ALCCW))
                            writeRowToTestGrid(ref ALCCW_grid, row[pointCol].ToString(), row[lowCol].ToString(), row[targetCol].ToString(), row[highCol].ToString());
                        break;
                }
            }
        }

        //Write passed in Data to test Grid
        private void writeRowToTestGrid(ref DataGridView thisGrid, string point, string low, string target, string high)
        {
            try
            {
                thisGrid.Rows.Add(point, "", "", low, target, high);
            }
            catch
            {

            }
        }

        //Pass in testOrderStr, change state of orderTest Checked and write to testGrid
        private void updateTestOrderChecked(string testOrderStr)
        {
            newTestLoad = true;
            AF_chkbox.Checked = false;
            AL_chkbox.Checked = false;
            CW_chkbox.Checked = false;
            CCW_chkbox.Checked = false;

            //Populate order Test 
            BindingList<string> thisTestOrder = new BindingList<string>();
            foreach (char chr in testOrderStr)
            {
                switch (chr)
                {
                    case '1'://AFCW
                        AF_chkbox.Checked = true;
                        CW_chkbox.Checked = true;
                        break;
                    case '2'://AFCCW
                        AF_chkbox.Checked = true;
                        CCW_chkbox.Checked = true;
                        break;
                    case '3'://ALCW
                        AL_chkbox.Checked = true;
                        CW_chkbox.Checked = true;
                        break;
                    case '4'://ALCCW
                        AL_chkbox.Checked = true;
                        CCW_chkbox.Checked = true;
                        break;
                }
            }
            testOrder_list.DataSource = testList;
            showOnGrid();//After All checkboxs are gone through, write to testGrid
            newTestLoad = false;//set newtestload=false so testGrid will update everytime a check box is changed
        }

        //read from TestSetup CSV and assign all the testSetup into testSetups
        private void readFromTestSetUpCSV()
        {
            //Read TestSequences.csv file into fileIn
            List<string> fileIn = new List<string>();
            if (File.Exists(testsequenceCSVLoc))
            {
                fileIn = readFile_returnListStr(testsequenceCSVLoc);
            }
            else
            {
                try
                {
                    //Todo: Assign default list of Tests to TestSequences.csv if the file is not found
                    string allTestStr = "7\n\nTest ID,3 points**\nDefault,yes\nPoint Amount,3\nFull Scale,100\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,\nCh2-Unit,\nTest Order,1324\nTestType,1\nTestTable\n#,Target,Low,High,Order\n1,18,20,22,1\n2,54,60,66,1\n3,90,100,110,1\n1,-18,-20,-22,2\n2,-54,-60,-66,2\n3,-90,-100,-110,2\n1,18,20,22,3\n2,54,60,66,3\n3,90,100,110,3\n1,-18,-20,-22,4\n2,-54,-60,-66,4\n3,-90,-100,-110,4\n,,,,\n,,,,\n,,,,\n,,,,\n,,,,\n\nTest ID,5 points**\nDefault,yes\nPoint Amount,5\nFull Scale,20\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,\nCh2-Unit,\nTest Order,3412\nTestType,2\nTestTable\n#,Target,Low,High,Order\n1,3.6,4,4.4,1\n2,7.2,8,8.8,1\n3,10.8,12,13.2,1\n4,14.4,16,17.6,1\n5,18,20,22,1\n1,-3.6,-4,-4.4,2\n2,-7.2,-8,-8.8,2\n3,-10.8,-12,-13.2,2\n4,-14.4,-16,-17.6,2\n5,-18,-20,-22,2\n1,3.6,4,4.4,3\n2,7.2,8,8.8,3\n3,10.8,12,13.2,3\n4,14.4,16,17.6,3\n5,18,20,22,3\n1,-3.6,-4,-4.4,4\n2,-7.2,-8,-8.8,4\n3,-10.8,-12,-13.2,4\n4,-14.4,-16,-17.6,4\n5,-18,-20,-22,4\n\nTest ID,5 points and 10%**\nDefault,yes\nPoint Amount,6\nFull Scale,100\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,INLB\nCh2-Unit,INOZ\nTest Order,1234\nTestType,1\nTestTable\n#,Target,Low,High,Order\n1,9,10,11,1\n2,18,20,22,1\n3,36,40,44,1\n4,54,60,66,1\n5,72,80,88,1\n6,90,100,110,1\n1,-9,-10,-11,2\n2,-18,-20,-22,2\n3,-36,-40,-44,2\n4,-54,-60,-66,2\n5,-72,-80,-88,2\n6,-90,-100,-110,2\n1,9,10,11,3\n2,18,20,22,3\n3,36,40,44,3\n4,54,60,66,3\n5,72,80,88,3\n6,90,100,110,3\n1,-9,-10,-11,4\n2,-18,-20,-22,4\n3,-36,-40,-44,4\n4,-54,-60,-66,4\n5,-72,-80,-88,4\n6,-90,-100,-110,4\n\nTest ID,5 points 5% and 10%**\nDefault,yes\nPoint Amount,7\nFull Scale,100\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,INLB\nCh2-Unit,INOZ\nTest Order,1324\nTestType,1\nTestTable\n#,Target,Low,High,Order\n1,4.95,5,5.05,1\n1,-4.95,-5,-5.05,2\n1,4.95,5,5.05,3\n1,-4.95,-5,-5.05,4\n2,9.9,10,10.1,1\n2,-9.9,-10,-10.1,2\n2,9.9,10,10.1,3\n2,-9.9,-10,-10.1,4\n3,19.8,20,20.2,1\n3,-19.8,-20,-20.2,2\n3,19.8,20,20.2,3\n3,-19.8,-20,-20.2,4\n4,39.6,40,40.4,1\n4,-39.6,-40,-40.4,2\n4,39.6,40,40.4,3\n4,-39.6,-40,-40.4,4\n5,59.4,60,60.6,1\n5,-59.4,-60,-60.6,2\n5,59.4,60,60.6,3\n5,-59.4,-60,-60.6,4\n6,79.2,80,80.8,1\n6,-79.2,-80,-80.8,2\n6,79.2,80,80.8,3\n6,-79.2,-80,-80.8,4\n7,99,100,101,1\n7,-99,-100,-101,2\n7,99,100,101,3\n7,-99,-100,-101,4\n\nTest ID,10 points**\nDefault,yes\nPoint Amount,10\nFull Scale,100\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,INLB\nCh2-Unit,INOZ\nTest Order,1234\nTestType,1\nTestTable\n#,Target,Low,High,Order\n1,9,10,11,1\n2,18,20,22,1\n3,27,30,33,1\n4,36,40,44,1\n5,45,50,55,1\n6,54,60,66,1\n7,63,70,77,1\n8,72,80,88,1\n9,81,90,99,1\n10,90,100,110,1\n1,-9,-10,-11,2\n2,-18,-20,-22,2\n3,-27,-30,-33,2\n4,-36,-40,-44,2\n5,-45,-50,-55,2\n6,-54,-60,-66,2\n7,-63,-70,-77,2\n8,-72,-80,-88,2\n9,-81,-90,-99,2\n10,-90,-100,-110,2\n1,9,10,11,3\n2,18,20,22,3\n3,27,30,33,3\n4,36,40,44,3\n5,45,50,55,3\n6,54,60,66,3\n7,63,70,77,3\n8,72,80,88,3\n9,81,90,99,3\n10,90,100,110,3\n1,-9,-10,-11,4\n2,-18,-20,-22,4\n3,-27,-30,-33,4\n4,-36,-40,-44,4\n5,-45,-50,-55,4\n6,-54,-60,-66,4\n7,-63,-70,-77,4\n8,-72,-80,-88,4\n9,-81,-90,-99,4\n10,-90,-100,-110,4\n\nTest ID,10 points and 5%**\nDefault,yes\nPoint Amount,11\nFull Scale,100\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,INLB\nCh2-Unit,INOZ\nTest Order,1324\nTestType,1\nTestTable\n#,Target,Low,High,Order\n1,4.5,5,5.5,1\n2,9,10,11,1\n3,18,20,22,1\n4,27,30,33,1\n5,36,40,44,1\n6,45,50,55,1\n7,54,60,66,1\n8,63,70,77,1\n9,72,80,88,1\n10,81,90,99,1\n11,90,100,110,1\n1,-4.5,-5,-5.5,2\n2,-9,-10,-11,2\n3,-18,-20,-22,2\n4,-27,-30,-33,2\n5,-36,-40,-44,2\n6,-45,-50,-55,2\n7,-54,-60,-66,2\n8,-63,-70,-77,2\n9,-72,-80,-88,2\n10,-81,-90,-99,2\n11,-90,-100,-110,2\n1,4.5,5,5.5,3\n2,9,10,11,3\n3,18,20,22,3\n4,27,30,33,3\n5,36,40,44,3\n6,45,50,55,3\n7,54,60,66,3\n8,63,70,77,3\n9,72,80,88,3\n10,81,90,99,3\n11,90,100,110,3\n1,-4.5,-5,-5.5,4\n2,-9,-10,-11,4\n3,-18,-20,-22,4\n4,-27,-30,-33,4\n5,-36,-40,-44,4\n6,-45,-50,-55,4\n7,-54,-60,-66,4\n8,-63,-70,-77,4\n9,-72,-80,-88,4\n10,-81,-90,-99,4\n11,-90,-100,-110,4\n\nTest ID,20 points**\nDefault,yes\nPoint Amount,20\nFull Scale,100\nLow,10\nHigh,10\n% or Unit,\nCh1-Unit,INLB\nCh2-Unit,INOZ\nTest Order,1234\nTestType,1\nTestTable\n#,Target,Low,High,Order\n1,4.5,5,5.5,1\n2,9,10,11,1\n3,13.5,15,16.5,1\n4,18,20,22,1\n5,22.5,25,27.5,1\n6,27,30,33,1\n7,31.5,35,38.5,1\n8,36,40,44,1\n9,40.5,45,49.5,1\n10,45,50,55,1\n11,49.5,55,60.5,1\n12,54,60,66,1\n13,58.5,65,71.5,1\n14,63,70,77,1\n15,67.5,75,82.5,1\n16,72,80,88,1\n17,76.5,85,93.5,1\n18,81,90,99,1\n19,85.5,95,104.5,1\n20,90,100,110,1\n1,-4.5,-5,-5.5,2\n2,-9,-10,-11,2\n3,-13.5,-15,-16.5,2\n4,-18,-20,-22,2\n5,-22.5,-25,-27.5,2\n6,-27,-30,-33,2\n7,-31.5,-35,-38.5,2\n8,-36,-40,-44,2\n9,-40.5,-45,-49.5,2\n10,-45,-50,-55,2\n11,-49.5,-55,-60.5,2\n12,-54,-60,-66,2\n13,-58.5,-65,-71.5,2\n14,-63,-70,-77,2\n15,-67.5,-75,-82.5,2\n16,-72,-80,-88,2\n17,-76.5,-85,-93.5,2\n18,-81,-90,-99,2\n19,-85.5,-95,-104.5,2\n20,-90,-100,-110,2\n1,4.5,5,5.5,3\n2,9,10,11,3\n3,13.5,15,16.5,3\n4,18,20,22,3\n5,22.5,25,27.5,3\n6,27,30,33,3\n7,31.5,35,38.5,3\n8,36,40,44,3\n9,40.5,45,49.5,3\n10,45,50,55,3\n11,49.5,55,60.5,3\n12,54,60,66,3\n13,58.5,65,71.5,3\n14,63,70,77,3\n15,67.5,75,82.5,3\n16,72,80,88,3\n17,76.5,85,93.5,3\n18,81,90,99,3\n19,85.5,95,104.5,3\n20,90,100,110,3\n1,-4.5,-5,-5.5,4\n2,-9,-10,-11,4\n3,-13.5,-15,-16.5,4\n4,-18,-20,-22,4\n5,-22.5,-25,-27.5,4\n6,-27,-30,-33,4\n7,-31.5,-35,-38.5,4\n8,-36,-40,-44,4\n9,-40.5,-45,-49.5,4\n10,-45,-50,-55,4\n11,-49.5,-55,-60.5,4\n12,-54,-60,-66,4\n13,-58.5,-65,-71.5,4\n14,-63,-70,-77,4\n15,-67.5,-75,-82.5,4\n16,-72,-80,-88,4\n17,-76.5,-85,-93.5,4\n18,-81,-90,-99,4\n19,-85.5,-95,-104.5,4\n20,-90,-100,-110,4\n";
                    File.WriteAllText(testsequenceCSVLoc, allTestStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to load Test Sequences file due to error: \n" + ex.Message);
                }
            }

            try
            {
                Int32.TryParse(fileIn[0], out currNumberOfTests); //get current Number of Test Setup from the file
            }
            catch
            {
                MessageBox.Show("Test Setup File can't be found. Please restart the application and Run as Administrator if this is your first time running the application.");
            }
            testSetups = load_testSetups(currNumberOfTests, fileIn);//Initiate List of testSetup

        }

        //Call after already loaded to testSetups
        //Return a string that can be copied to TestSequences.csv if that file is not found.
        //Use for development purpose only
        private string getCSVStrfromTestSetups()
        {
            string returnStr = testSetups.Count + "\\n\\n";
            foreach (TestSetup test in testSetups)
            {
                returnStr += test.GetCsvStr() + "\\n";
            }
            return returnStr;
        }
        //added 1/29/20
        //Call when Calibration Tab first bring up 
        private void loadALLCalibrationTabSetting()
        {
            if (TabPages.TabPages.Contains(calibrationTab))//if this version has calibration Tab, then apply these settings
            {
                calTabMiscSetting(); //Load all misc for calTab appearance
                readFromTestSetUpCSV(); //Read from TestSequences.csv and assign all saved Setups into testSetups
                refreshTestIDComboBox(); //Assign testID to drop down list
                lowLimit_txt.Leave += LowLimit_txt_Leave;
                highLimit_txt.Leave += HighLimit_txt_Leave;
                sampleNum_txt.Leave += SampleNum_txt_Leave;
                FS_txt.Leave += FS_txt_Leave;
                maxPoint_txt.Leave += MaxPoint_txt_Leave;
                //Set all extra event handlers for Caltab
                calTab_eventHandlerCollections();

                //Run tool server
                runToolServer();//Run Tools Server
                try
                {
                    logon();//Logon to Tools Server as Guest_tool
                    updateAndBindToolsList();//update and show toolsID List
                }
                catch
                {
                }

            }
        }
        //added 1/29/20
        private void MaxPoint_txt_Leave(object sender, EventArgs e)
        {
            FSLowHighchanged();
        }
        //added 1/29/20
        private void FS_txt_Leave(object sender, EventArgs e)
        {
            FSLowHighchanged();
        }
        //added 1/29/20
        private void SampleNum_txt_Leave(object sender, EventArgs e)
        {
            FSLowHighchanged();
        }
        //added 1/29/20
        private void HighLimit_txt_Leave(object sender, EventArgs e)
        {
            FSLowHighchanged();
        }

        private void LowLimit_txt_Leave(object sender, EventArgs e)
        {
            FSLowHighchanged();
        }

        //Assign testID to drop down list
        private void refreshTestIDComboBox()
        {
            testSetup_comboBox.Items.Clear();
            testSetup_comboBox.Items.Add("New Test");
            //Update list of testName and add to testSetup_combobox
            testNameStr_arr = get_listOfTestName(testSetups);
            testSetup_comboBox.Items.AddRange(testNameStr_arr);

            if (currTestIndex >= 0)
            {
                try
                {
                    //If currtestIndex+1 is higher than last item in comboBox, then set currTestIndex to second last index
                    if (currTestIndex >= testSetup_comboBox.Items.Count - 1)
                        currTestIndex = (testSetup_comboBox.Items.Count - 1) - 1;//-1 to offset +1 later

                    //set the selected index
                    testSetup_comboBox.SelectedIndex = currTestIndex + 1;
                }
                catch { }
            }
        }

        //return collection of testSetups based on how many setUpCount there are and the file read in from TestSequences.csv
        private List<TestSetup> load_testSetups(int setUpCount, List<string> strList)
        {
            List<TestSetup> thisTestSetups = new List<TestSetup>();
            TestSetup currTestSetup = new TestSetup();
            int testIndex = -1;
            bool startTestTable = false;
            //Go through each line and add to header or testTable
            foreach (string strLine in strList)
            {
                if (strLine == "TestTable")
                    //skip to next line and start recording testTable
                    startTestTable = true;
                else
                {
                    if (strLine.StartsWith("Test ID,"))//Set up a new TestSetup
                    {
                        if (testIndex >= 0)
                            thisTestSetups.Add(currTestSetup);
                        currTestSetup = new TestSetup();
                        testIndex += 1;
                        startTestTable = false;
                    }

                    if (testIndex >= 0)
                    {
                        if (startTestTable == false)
                        {//Record headers value
                            if (strLine.Contains(","))
                            {
                                int valueIndexStart = strLine.IndexOf(",") + 1;

                                //check if line start with right header and write to that header value
                                currTestSetup = assignTestHeaderValue(currTestSetup,
                                    strLine.Substring(0, valueIndexStart - 1),
                                    strLine.Substring(valueIndexStart, strLine.Length - valueIndexStart));
                            }
                        }
                        else//Record to testTable
                        {
                            if (!strLine.StartsWith("#"))//Ignore the header Table
                            {
                                DataRow row = currTestSetup.testTable.NewRow();
                                row = returnFloatListfrStr(strLine, row);
                                currTestSetup.testTable.Rows.Add(row);
                            }
                        }
                    }
                }

            }

            //Add the last currTestSetup that didn't get added
            thisTestSetups.Add(currTestSetup);

            return thisTestSetups;
        }

        //Pass in string consist of float number, separated by ','
        //parse the float array into DataRow thisrow and return it 
        private DataRow returnFloatListfrStr(string strOfFloat, DataRow thisrow)
        {
            int startIndex = 0;
            float number = 0;
            int colIndex = 0;
            for (int endIndex = 0; endIndex <= strOfFloat.Length; endIndex++)
            {
                if ((endIndex == strOfFloat.Length) || (strOfFloat[endIndex] == ','))
                {
                    try
                    {
                        string strToConvert = strOfFloat.Substring(startIndex, endIndex - startIndex);
                        //column is empty
                        if (strToConvert == "")
                        {
                            colIndex++;
                            startIndex = endIndex + 1;
                        }
                        else
                        {
                            number = Single.Parse(strToConvert);
                            thisrow[colIndex] = number;
                            colIndex++;
                        }


                    }
                    catch (Exception e)
                    {
                        number = 0;
                    }
                    startIndex = endIndex + 1;
                }
            }
            return thisrow;
        }

        //check which header the passed in headerName is and assign its value in TestSetup appropriately
        private TestSetup assignTestHeaderValue(TestSetup thisTestSetup, string headerName, string headerValue)
        {
            if (headerName == thisTestSetup.get_testIDHeader())
                thisTestSetup.testID = headerValue;
            if (headerName == thisTestSetup.get_pointAmount_header())
                thisTestSetup.pointAmount = headerValue;
            if (headerName == thisTestSetup.get_testFSHeader())
                thisTestSetup.FullScale = headerValue;
            if (headerName == thisTestSetup.get_testlowHeader())
                thisTestSetup.low = headerValue;
            if (headerName == thisTestSetup.get_testhighHeader())
                thisTestSetup.high = headerValue;
            if (headerName == thisTestSetup.get_percentOrUnitHeader())
                thisTestSetup.percent_unit = headerValue;
            if (headerName == thisTestSetup.get_ch1UnitHeader())
                thisTestSetup.ch1Unit = headerValue;
            if (headerName == thisTestSetup.get_ch2UnitHeader())
                thisTestSetup.ch2Unit = headerValue;
            if (headerName == thisTestSetup.get_testOrderHeader())
                thisTestSetup.testOrder = headerValue;
            if (headerName == thisTestSetup.get_testTypeHeader())
                thisTestSetup.testType = headerValue;
            if (headerName == thisTestSetup.get_defaultTestHeader())
                thisTestSetup.defaultTest = headerValue;
            if (headerName == thisTestSetup.get_sampleNumHeader())
                thisTestSetup.sampleNum = headerValue;
            return thisTestSetup;
        }
        //Erase all Values in testSetup
        private void calTabTestSetUp_Reset()
        {
            testID_txt.Text = "";
            maxPoint_txt.Text = "";
            sampleNum_txt.Text = "1";
            FS_txt.Text = "";
            lowLimit_txt.Text = "";
            highLimit_txt.Text = "";
            ch1Unit_txt.Text = "";
            ch2Unit_txt.Text = "";
            limitEngPercent_comboBox.SelectedIndex = 0;
            AF_chkbox.Checked = true;
            AL_chkbox.Checked = true;
            CW_chkbox.Checked = true;
            CCW_chkbox.Checked = true;

            initTestGridView(ref AFCW_grid,noTriggerGridColCount);
            initTestGridView(ref AFCCW_grid, noTriggerGridColCount);
            initTestGridView(ref ALCW_grid, noTriggerGridColCount);
            initTestGridView(ref ALCCW_grid, noTriggerGridColCount);

        }

        //set all Appearance Setting for all objects in this Form
        private void calTabMiscSetting()
        {
            testType_comboBox.SelectedIndex = -1;
            calTabTestSetUp_Reset();//Reset all fields in testSetup and grids
            highColor_label.BackColor = highColor;
            lowColor_label.BackColor = lowColor;

            //Show List of comPort
            comList_calibration.DataSource = FSList;

            //Append testList to testOrder_list
            testOrder_list.DataSource = testList;

            setGridColName(AFCW_grid);//Set column Name for Test Sequence GridView

            showActiveTestGrid('0');//0 would make all 4 grids greyed out, but still can be editted

            //Set auto complete for testSetup_comboBox
            testSetup_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            testSetup_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            //Set auto complete for toolID_comboBox
            toolID_comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            toolID_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void TestSetup_groupBox_EnabledChanged(object sender, EventArgs e)
        {
            if (testSetup_groupBox.Enabled == true)
            {
                copyAllStruct_btn.Visible = true;
                startTest_btn.Visible = true;
            }
            else
            {
                copyAllStruct_btn.Visible = false;
                startTest_btn.Visible = false;
            }
        }

        private void Ch1UnitLabel_calTab_TextChanged(object sender, EventArgs e)
        {
            ch1Unit_txt.Text = ch1UnitLabel_calTab.Text;
        }
        private void Ch2UnitLabel_calTab_TextChanged(object sender, EventArgs e)
        {
            ch2Unit_txt.Text = ch2UnitLabel_calTab.Text;
        }

        private void showOnGrid()
        {
            if (currTestSetup.testTable.Rows.Count > 0)
            {
                updateTestGrid(currTestSetup.testTable, testList);
            }
        }

        //Set all extra event handlers for all objects in calibration Tab
        private void calTab_eventHandlerCollections()
        {
            //Add Event Handler for listbox drag and drop
            this.testOrder_list.MouseDown += this.testOrder_list_MouseDown;
            this.testOrder_list.DragOver += this.testOrder_list_DragOver;
            this.testOrder_list.DragDrop += this.testOrder_list_DragDrop;

            //When New Row is added to Test Data, recheck pass fail color
            AFCW_grid.CellValueChanged += AFCW_grid_CellValueChanged;
            AFCCW_grid.CellValueChanged += AFCCW_grid_CellValueChanged;
            ALCW_grid.CellValueChanged += ALCW_grid_CellValueChanged;
            ALCCW_grid.CellValueChanged += ALCCW_grid_CellValueChanged;

            //Sync ch1 and 2 Unit with Unit Textbox from Test Setup
            ch1UnitLabel_calTab.TextChanged += Ch1UnitLabel_calTab_TextChanged;
            ch2UnitLabel_calTab.TextChanged += Ch2UnitLabel_calTab_TextChanged;

            //change what happen when go from test setup mode to run mode and vice versa
            testSetup_groupBox.EnabledChanged += TestSetup_groupBox_EnabledChanged;

        }

        //Call when user manually change target for a gridtest row
        //Update low and high for that row
        private void rewriteLowHigh_gridRow(ref DataGridView thisGrid, int rowIndex)
        {
            float high_fl, low_fl;
            float target_fl;
            try
            {

                target_fl = Single.Parse((thisGrid.Rows[rowIndex].Cells[targetGridCol].Value).ToString());

                if (limitEngPercent_comboBox.SelectedIndex == 0) //calculate low and high by %
                {
                    low_fl = (100 - Single.Parse(lowLimit_txt.Text)) / 100 * target_fl;
                    high_fl = (100 + Single.Parse(highLimit_txt.Text)) / 100 * target_fl;
                }
                else //calculate by Eng Unit
                {
                    low_fl = target_fl - Single.Parse(lowLimit_txt.Text);
                    high_fl = target_fl + Single.Parse(highLimit_txt.Text);
                }

                //Write low and high to gridview for this row
                thisGrid.Rows[rowIndex].Cells[lowGridCol].Value = low_fl;
                thisGrid.Rows[rowIndex].Cells[highGridCol].Value = high_fl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //update testTable when 1 of the testGrid got changed while in testSetup Mode
        //quadrant=1,2,3,4
        private DataTable updateTestTablewhenGridChanged(DataGridView frGrid, DataTable thistestTable, int quadrant)
        {
            thistestTable.AcceptChanges();
            foreach (DataRow tableRow in thistestTable.Rows)
            {

                //if order of this row is same as quadrant, delete it
                if (tableRow[currTestSetup.get_orderTableHeader()].ToString() == quadrant.ToString())
                    tableRow.Delete();

            }
            thistestTable.AcceptChanges();
            //Add each gridrow into testTable
            foreach (DataGridViewRow gridRow in frGrid.Rows)
            {
                //Add gridrow to testTable
                if (!gridRow.IsNewRow)
                {
                    DataRow tableRow = thistestTable.NewRow();

                    //assign values from grid to tableRow
                    tableRow[currTestSetup.get_pointTableHeader()] = gridRow.Cells[pointGridCol].Value;
                    tableRow[currTestSetup.get_targetTableHeader()] = gridRow.Cells[targetGridCol].Value;
                    tableRow[currTestSetup.get_lowTableHeader()] = gridRow.Cells[lowGridCol].Value;
                    tableRow[currTestSetup.get_highTableHeader()] = gridRow.Cells[highGridCol].Value;
                    tableRow[currTestSetup.get_orderTableHeader()] = quadrant;

                    thistestTable.Rows.Add(tableRow);
                }
            }

            return thistestTable;
        }
        //Changed 3/25/20
        private void cellValueChanged(ref DataGridView grid, DataGridViewCellEventArgs e, int Sign)
        {
            if (e.ColumnIndex == targetGridCol)
            {
                rewriteLowHigh_gridRow(ref grid, e.RowIndex);
            }

            //If still in testSetup mode, save the changed made from grid to currTestSetUp testTable
            if (testSetup_groupBox.Enabled == true)
            {
                currTestSetup.testTable = updateTestTablewhenGridChanged(grid, currTestSetup.testTable, 2);//Write testable the update testTable after a grid is changed
                //updateTestGrid(currTestSetup.testTable, testList);
            }
            else//If not in testsetup mode, update and show the active test Grid
            {
                currTestGridNum = lookForActiveTestGrid();
                showActiveTestGrid(currTestGridNum);
            }
            if (testSetup_groupBox.Enabled == false)
                reevaluatePassFailData(ref grid, Sign);

            //update Active Target if it is single channel test
            if (currTestSetup.testType == "1")
            {
                char activeTestGridChr = lookForActiveTestGrid();
                float activeTarget;
                activeTarget = getActiveTargetfrTestGridChr(activeTestGridChr);
                if (activeTarget!=0)
                    testTarget_lbl.Text = activeTarget.ToString();
            }
        }
        private void AFCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cellValueChanged(ref AFCW_grid, e, 1);

        }

        private void AFCCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cellValueChanged(ref AFCCW_grid, e, -1);

        }
        private void ALCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cellValueChanged(ref ALCW_grid, e, 1);
        }
        private void ALCCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cellValueChanged(ref ALCCW_grid, e, -1);
        }
        //Handle drag drop for testOrder_list
        private void testOrder_list_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.testOrder_list.SelectedItem == null) return;
            dragIndex = testOrder_list.SelectedIndex;
            this.testOrder_list.DoDragDrop(this.testOrder_list.SelectedItem, DragDropEffects.Move);
        }

        private void testOrder_list_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void resetCurrTestSettings_btn_Click(object sender, EventArgs e)
        {
            if (testSetup_comboBox.SelectedIndex == 0) //Reset New Test
            {
                newTestReset();
            }
            else
            {
                initCurrTestSetup(currTestIndex);
                FSLowHighchanged();//Repopulate testGrid
            }
        }

        private void AF_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            set_testOrderList();
        }


        private void AL_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            set_testOrderList();
        }

        private void CW_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            set_testOrderList();
        }

        private void CCW_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            set_testOrderList();
        }

        private void testType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testType_comboBox.SelectedIndex == 0)//Single Channel test
            {
                ch2Unit_txt.Enabled = false;
                ch1Trough_chckbox.Checked = false;
                ch2Trough_chckbox.Checked = false;
                ch1Trough_chckbox.Enabled = false;
                ch2Trough_chckbox.Enabled = false;

                ch2Reading_groupBox.Visible = false;
                target_groupBox.Visible = true;
            }
            else if (testType_comboBox.SelectedIndex == 1)
            {
                ch2Unit_txt.Enabled = true;
                ch1Trough_chckbox.Enabled = true;
                ch2Trough_chckbox.Enabled = true;

                ch2Reading_groupBox.Visible = true;
                target_groupBox.Visible = false;
            }

            changeSaveStartTestBtn();
        }

        //return BindingList string that contains the actual string of test order to show to user
        private BindingList<string> testOrdersCreate(BindingList<string> ori_List)
        {
            BindingList<string> testList = new BindingList<string>();
            string checkedOrder = "";
            if (AF_chkbox.Checked)
            {
                if (CW_chkbox.Checked)
                    testList.Add(AFCW);
                if (CCW_chkbox.Checked)
                    testList.Add(AFCCW);
            }
            if (AL_chkbox.Checked)
            {
                if (CW_chkbox.Checked)
                    testList.Add(ALCW);
                if (CCW_chkbox.Checked)
                    testList.Add(ALCCW);
            }
            testList = compareOrderBindingList(ori_List, testList);
            return testList;
        }

        //compare oriList and newList, returnList has oriList order and all of newList Elements
        private BindingList<string> compareOrderBindingList(BindingList<string> oriList, BindingList<string> newList)
        {
            if (oriList.Count == 0)
                return newList;
            else
            {
                BindingList<string> returnList = new BindingList<string>(), newList_copy = new BindingList<string>();
                //copy newlist to newlist_copy
                foreach (string item in newList)
                    newList_copy.Add(item);
                //copy newList into returnList with oriList order
                foreach (string oriItem in oriList)
                {
                    foreach (string newItem in newList_copy)
                    {
                        if (oriItem == newItem)
                        {
                            returnList.Add(newItem);
                            try
                            {
                                newList.Remove(newItem);
                            }
                            catch
                            {
                            }
                        }
                    }
                }


                //Add remaining newList Item to returnList
                foreach (string item in newList)
                {
                    returnList.Add(item);
                }

                return returnList;
            }
        }

        private bool newTestLoad = false;
        //Assign testOrder_list
        private void set_testOrderList()
        {
            //Create Current List generated from user selections
            testList = testOrdersCreate(testList);
            testOrder_list.DataSource = testList;
            currTestSetup.testOrder = createTestOrderStr(testList);

            if ((currTestSetup.testTable.Rows.Count > 0) && (newTestLoad == false))
            {
                updateTestGrid(currTestSetup.testTable, testList);
            }
        }

        //Get back to set up Test Mode for Cal Tab
        //changed 3/25/20
        private void abandonCurrentTest()
        {
            if (testSetup_groupBox.Enabled == true)
                return;

            bool certSaveSucceed = true, excelSaveSucceed = true;
            newTestConfirm_form frm = new newTestConfirm_form();
            frm.ShowDialog();

            if (frm.excelExport == true)
            {//Export Excel
                calTab_excelExport(false,false);
            }
            if (frm.certExport == true)
            {
                //Export current reading to Cert, return true or false if saved succeed
                certSaveSucceed = saveTestReadingsToCert();
            }

            //Only abandon this test if saved to cert and excel success (in case user select those 2 options)
            if ((certSaveSucceed == true) && (excelSaveSucceed == true) && (frm.clearData == true))
            {
                testSetup_groupBox.Enabled = true;
                showActiveTestGrid('0'); //0 to deactivate all testgrid
                initCurrTestSetup(currTestIndex);
            }
            testTarget_lbl.Text = "";
            testTarget_lbl.ForeColor = Color.Black;
        }
        private void abandonTest_btn_Click(object sender, EventArgs e)
        {
            abandonCurrentTest();
        }

        private void copyCW_btn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Any Data(if any) from As Left Clockwise will be replaced with As Found Data. Proceed?", "Caution!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                copyGridView(AFCW_grid, ref ALCW_grid);
        }

        private void copyCCW_btn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Any Data(if any) from As Left CounterClockwise will be replaced with As Found Data. Proceed?", "Caution!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                copyGridView(AFCCW_grid, ref ALCCW_grid);
        }

        private void copyAllStruct_btn_Click(object sender, EventArgs e)
        {
            if (AFCW_grid.Rows.Count > 1)//If AFCW is not empty
            {
                //Clear first before copying
                AFCCW_grid.Rows.Clear();
                ALCW_grid.Rows.Clear();
                ALCCW_grid.Rows.Clear();
            }
            currTestSetup.testTable = updateTestUsing1QuadRant(currTestSetup.testTable, 1); //1 represent AFCW quadrant

            //repopulate testGrid to show to user
            updateTestGrid(currTestSetup.testTable, testList);
        }

        //Update passedin testable using datas from just 1 quadrant
        //return updated testtable
        private DataTable updateTestUsing1QuadRant(DataTable thisTestTable, int Ori_quadrant)
        {
            //DataTable midTable = thisTestTable.Clone();
            DataTable returnTable = thisTestTable.Clone();

            //Delete all rows that do not have same quadrant as Ori_quadrant
            thisTestTable.AcceptChanges();
            foreach (DataRow dataRow in thisTestTable.Rows)
            {
                if (dataRow[currTestSetup.get_orderTableHeader()].ToString() != Ori_quadrant.ToString())
                {
                    dataRow.Delete();
                    /*
                    DataRow newRow = midTable.NewRow();
                    newRow = dataRow;
                    midTable.Rows.Add(newRow);*/
                }
            }
            thisTestTable.AcceptChanges();

            //loop through each quadrantIndex, 
            //if same as midTable quadrant, copy. If not, copyorflip
            for (int quadrantIndex = 1; quadrantIndex <= 4; quadrantIndex++)
            {
                int copyOrFlip = Math.Abs(quadrantIndex - Ori_quadrant) % 2;//0=copy, 1=flip
                try
                {
                    foreach (DataRow dataRow in thisTestTable.Rows)
                    {
                        DataRow newRow = returnTable.NewRow();
                        if (copyOrFlip == 0)
                        {
                            newRow[currTestSetup.get_pointTableHeader()] = dataRow[currTestSetup.get_pointTableHeader()];
                            newRow[currTestSetup.get_targetTableHeader()] =
                                dataRow[currTestSetup.get_targetTableHeader()];
                            newRow[currTestSetup.get_lowTableHeader()] = dataRow[currTestSetup.get_lowTableHeader()];
                            newRow[currTestSetup.get_highTableHeader()] = dataRow[currTestSetup.get_highTableHeader()];
                            newRow[currTestSetup.get_orderTableHeader()] = quadrantIndex;
                        }
                        else if (copyOrFlip == 1)
                        {
                            try
                            {
                                newRow[currTestSetup.get_pointTableHeader()] =
                                    dataRow[currTestSetup.get_pointTableHeader()];
                                newRow[currTestSetup.get_targetTableHeader()] =
                                    Single.Parse(dataRow[currTestSetup.get_targetTableHeader()].ToString()) * -1;
                                newRow[currTestSetup.get_lowTableHeader()] =
                                    Single.Parse(dataRow[currTestSetup.get_lowTableHeader()].ToString()) * -1;
                                newRow[currTestSetup.get_highTableHeader()] =
                                    Single.Parse(dataRow[currTestSetup.get_highTableHeader()].ToString()) * -1;
                                newRow[currTestSetup.get_orderTableHeader()] = quadrantIndex;
                            }
                            catch
                            {
                                newRow = dataRow;
                            }
                        }
                        returnTable.Rows.Add(newRow);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return returnTable;
        }
        //Return test order from passed in List-should be testList
        private string createTestOrderStr(BindingList<string> thisList)
        {
            string testOrder = "";
            foreach (string item in thisList)
            {
                switch (item)
                {
                    case AFCW:
                        testOrder += "1";
                        break;
                    case AFCCW:
                        testOrder += "2";
                        break;
                    case ALCW:
                        testOrder += "3";
                        break;
                    case ALCCW:
                        testOrder += "4";
                        break;
                }
            }
            return testOrder;
        }
        //Assign list colName from gridView(any 1 of the 4 AFCW_grid etc. would do)
        private void setGridColName(DataGridView thisGrid)
        {
            pointNum_colName = thisGrid.Columns[0].Name;
            chan1Readings_colName = thisGrid.Columns[1].Name;
            chan2Readings_colName = thisGrid.Columns[2].Name;
            low_colName = thisGrid.Columns[3].Name;
            target_colName = thisGrid.Columns[4].Name;
            high_colName = thisGrid.Columns[5].Name;
        }

        private void testOrder_list_DragDrop(object sender, DragEventArgs e)
        {
            Point point = testOrder_list.PointToClient(new Point(e.X, e.Y));
            int index = this.testOrder_list.IndexFromPoint(point);
            if (index < 0) index = this.testOrder_list.Items.Count - 1;

            dropIndex = index;
            string tempStr = testOrder_list.Items[dragIndex].ToString();
            testList.RemoveAt(dragIndex);
            testList.Insert(dropIndex, tempStr);
            testOrder_list.SelectedIndex = dropIndex;//focus on the dropped index
        }

        private void restartTest_btn_Click(object sender, EventArgs e)
        {
            var dialogresult = MessageBox.Show("All existing readings for this test will be deleted. Proceed?", "Delete all readings?",
                MessageBoxButtons.OKCancel);
            if ((dialogresult == DialogResult.OK) && (testSetup_groupBox.Enabled == false))
            {
                showOnGrid(); //Repopulate testGrid
                showActiveTestGrid(currTestSetup.testOrder[0]); //Set first quadrant in testList as active

                //update Active Target if it is single channel test
                if (currTestSetup.testType == "1")
                {
                    float activeTarget;
                    activeTarget = getActiveTargetfrTestGridChr(currTestSetup.testOrder[0]);
                    testTarget_lbl.Text = activeTarget.ToString();
                }
            }
        }

        //Delete last test Reading
        private void deleteLastTestRow(ref DataGridView testGrid)
        {
            for (int rowIndex = testGrid.RowCount - 1; rowIndex >= 0; rowIndex--)
            {
                //if not new row and ch1Reading or ch2Reading is not empty then delete readings, update currTestGrid and return
                if ((!testGrid.Rows[rowIndex].IsNewRow) &&
                    ((testGrid.Rows[rowIndex].Cells[ch1ReadingGridCol].Value != "") ||
                    (testGrid.Rows[rowIndex].Cells[ch2ReadingGridCol].Value != "")))
                {
                    testGrid.Rows[rowIndex].Cells[ch1ReadingGridCol].Value = "";
                    testGrid.Rows[rowIndex].Cells[ch2ReadingGridCol].Value = "";
                    return;
                }
            }
        }
        //return array of string that has all test Name
        public static string[] get_listOfTestName(List<TestSetup> testSetups)
        {
            //Assign list of testName from testSetups into testNameStr
            string[] testNameStr = new string[testSetups.Count];
            for (int index = 0; index < testSetups.Count; index++)
            {
                testNameStr[index] = testSetups[index].testID;
            }
            return testNameStr;
        }

        private string[] testNameStr_arr;
        private const string isDefaultTest = "yes";
        private const string notDefaultTest = "no";
        private void saveAsTest_btn_Click(object sender, EventArgs e)
        {
            testNameStr_arr = get_listOfTestName(testSetups);
            //Ask for new Name for this test, assign to newTestName
            getSaveAsTestSetupNameForm frm = new getSaveAsTestSetupNameForm(testNameStr_arr);
            frm.ShowDialog();

            string newTestName = frm.testName;

            //If newTestName is not empty, the save the test
            if (newTestName != "")
            {
                testID_txt.Text = newTestName;
                try
                {
                    testSetups.Add(saveThisTest(currTestSetup.defaultTest)); //Save the New Test to end of Test List

                    refreshTestIDComboBox(); //Refresh test id list
                    testSetup_comboBox.SelectedIndex = testSetups.Count;//Select the newly saved Test
                    saveAllTestsToCSV();//Write to CSV file
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save New Test due to error:\n\n" + ex.Message);
                }
            }
        }

        private DataGridView testGridFromChar(char testGridChr)
        {
            switch (testGridChr)
            {
                case '1':
                    return AFCW_grid;
                case '2':
                    return AFCCW_grid;
                case '3':
                    return ALCW_grid;
                case '4':
                    return ALCCW_grid;
                default:
                    return AFCW_grid;
            }
        }

        //Save all current test readings to Cert CSV
        private bool saveTestReadingsToCert()
        {
            bool saveSucceed;
            bool readyToSave = true;
            string errorMsg = "Unable to Save to Cert. Following fields can not be empty:\n";

            //Check to see if any empty field is empty
            if (toolID_comboBox.Text == "")
            {
                readyToSave = false;
                errorMsg += "Tool ID\n";
            }
            if (toolSN_txt.Text == "")
            {
                readyToSave = false;
                errorMsg += "Tool SN\n";
            }
            try
            {
                if ((currToolTable.Rows[0][pack.scanOperator_colName].ToString() == "1") && (toolOperatorID_txt.Text == ""))
                {
                    readyToSave = false;
                    errorMsg += "Operator ID\n";
                }
            }
            catch
            {
                //Do nothing, since error occurs when user not using the setup Tool but just manually type in instead
            }
            if (readyToSave == false)
            {

                MessageBox.Show(errorMsg);
                return false;
            }



            int singleOrDual = 1;
            string timeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string duedate = "", equipment = "", accuracy = "", testID = "", unit = "", capacity = "";
            List<string> targetList = new List<string>();
            List<string> lowList = new List<string>();
            List<string> highList = new List<string>();
            List<string> ch1ReadingList = new List<string>();
            List<string> ch2ReadingList = new List<string>();
            singleOrDual = Int32.Parse(currTestSetup.testType);
            CertTestSequence currCert = new CertTestSequence(singleOrDual);
            capacity = FS_txt.Text + " " + ch1Unit_txt.Text;

            //Some header values are different for Single and Dual Channel Test
            if (currTestSetup.testType == "1")//Single Channel test
            {
                unit = ch1Unit_txt.Text;
            }
            else
            {
                unit = ch1Unit_txt.Text + " vs " + ch2Unit_txt.Text;
            }

            //Init all headers for currCert
            currCert.setAllHeaders(toolID_comboBox.Text, timeStamp, duedate, recall_txt.Text + " Months", temperature_txt.Text, humid_txt.Text, equipment, toolModel_txt.Text, toolManufacture_txt.Text, capacity, accuracy, testID, toolSN_txt.Text, toolCertLot_txt.Text, toolProcedure_txt.Text, unit, toolOperatorID_txt.Text);

            //Loop through each grid quadrant, if not empty, write as 1 block to CSV for CM
            DataGridView[] tempGrids_arr = new DataGridView[] { AFCW_grid, AFCCW_grid, ALCW_grid, ALCCW_grid };
            try
            {
                foreach (DataGridView thisGrid in tempGrids_arr)
                {
                    if (!thisGrid.Rows[0].IsNewRow)
                    {
                        targetList = appendListStrFromGridTestColumn(thisGrid, targetGridCol);
                        lowList = appendListStrFromGridTestColumn(thisGrid, lowGridCol);
                        highList = appendListStrFromGridTestColumn(thisGrid, highGridCol);
                        ch1ReadingList = appendListStrFromGridTestColumn(thisGrid, ch1ReadingGridCol);

                        //Set target,low,high and readings into currCert
                        currCert.set_target(targetList);
                        currCert.set_lowLimit(lowList);
                        currCert.set_highLimit(highList);
                        if (singleOrDual == 1) //write to testTable for Single Channel
                        {
                            currCert.set_singlecertTable(ch1ReadingList);
                        }
                        else if (singleOrDual == 2) //write to testTable for Dual Channel
                        {
                            ch2ReadingList = appendListStrFromGridTestColumn(thisGrid, ch2ReadingGridCol);
                            currCert.set_dualcertTable(ch1ReadingList, ch2ReadingList);
                        }

                        //Write datas in currCert to CSV
                        string path = currCert.writeToCertCSV();
                        //If write to Cert CSV successful, return location of the file saved

                    }
                }
                MessageBox.Show("Test Successfully saved to Cert Manager");
                saveSucceed = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save due to error:\n" + ex.Message);
                saveSucceed = false;
            }
            return saveSucceed;
        }
        private void saveTestToCert_btn_Click(object sender, EventArgs e)
        {
            if (isReadyToSaveCert() == false)
            {
                MessageBox.Show("Please complete the test before saving To Cert");
            }
            else if (testSetup_groupBox.Enabled == false)
            {
                var dialogResult = MessageBox.Show("Export Data to Cert would also clear all Tools Info fields. Continue?",
                    "Confirm Export Data", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool certSavedSuccess = saveTestReadingsToCert();
                    if (certSavedSuccess == true)
                        clearAllToolsInfo();
                }
            }
            else
            {
                MessageBox.Show("Can't save to Cert while still selecting a Test");
            }
        }

        private void clearAllToolsInfo()
        {
            toolID_comboBox.Text = "";
            toolSN_txt.Text = "";
            recall_txt.Text = "";
            temperature_txt.Text = "";
            humid_txt.Text = "";
            toolModel_txt.Text = "";
            toolManufacture_txt.Text = "";
            toolCertLot_txt.Text = "";
            toolProcedure_txt.Text = "";
            toolOperatorID_txt.Text = "";
        }
        private List<string> appendListStrFromGridTestColumn(DataGridView thisGrid, int gridColIndex)
        {
            List<string> returnListStr = new List<string>();
            try
            {
                if (exportAverage_chckbox.Checked == false) //not export average
                    returnListStr.AddRange(copygridTableToListStr(thisGrid, gridColIndex));
                else //Export average for sample points
                {
                    string currPointNum = thisGrid.Rows[0].Cells[pointGridCol].Value.ToString();//Assign the first Point Number of this grid to currPointNum
                    List<float> totalPerPoint = new List<float>();
                    foreach (DataGridViewRow gridRow in thisGrid.Rows)
                    {
                        if ((gridRow.IsNewRow) || (gridRow.Cells[pointGridCol].Value.ToString() != currPointNum))
                        //If moved on to next Point, add average of totalPerPoint into returnListStr, update currPointNum
                        {
                            float avg = totalPerPoint.Sum() / totalPerPoint.Count;
                            returnListStr.Add(avg.ToString());
                            totalPerPoint.Clear();

                            if (!gridRow.IsNewRow)
                                currPointNum = gridRow.Cells[pointGridCol].Value.ToString();//update currPointNum

                        }

                        //Add gridRow[gridColIndex] into total
                        try
                        {
                            float thisRowFloat = Single.Parse(gridRow.Cells[gridColIndex].Value.ToString());
                            totalPerPoint.Add(thisRowFloat);
                        }
                        catch
                        {
                        } //Do nothing
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save " + thisGrid.Name + " due to error:\n" + ex.Message);
            }

            return returnListStr;
        }

        //Copy data from column in gridview into List<string> and return it
        private List<string> copygridTableToListStr(DataGridView testGrid, int gridColIndex)
        {
            List<string> returnStrList = new List<string>();
            foreach (DataGridViewRow gridRow in testGrid.Rows)
            {
                if (!gridRow.IsNewRow)
                    returnStrList.Add(gridRow.Cells[gridColIndex].Value.ToString());
            }
            return returnStrList;
        }

        private void openCert_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(CertManagerParentLoc);
            }
            catch
            {
                MessageBox.Show(
                    "Unable to Open Cert Manager.\nPlease make sure Cert Manager is properly installed at location: " +
                    CertManagerParentLoc);
            }
        }
        //update the index of testSetups, using in passed in testIndex list
        private void updateTestSetupManager(List<int> testIndex)
        {
            List<TestSetup> tempTestSetups = new List<TestSetup>();
            int count = 0;
            foreach (var index in testIndex)
            {
                tempTestSetups.Add(testSetups[index]);
            }

            testSetups = tempTestSetups;
        }

        private List<string> returnDefaultTestListName()
        {
            List<string> returnStrList = new List<string>();
            foreach (TestSetup thisTestSetup in testSetups)
            {
                if (thisTestSetup.defaultTest == isDefaultTest)
                    returnStrList.Add(thisTestSetup.testID);
            }
            return returnStrList;
        }
        private void testSequenceManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TestSequenceManager frm = new Form_TestSequenceManager(testSetups);
            frm.ShowDialog();
            testSetups = frm.returnTestSetups();
            /*
            List<int> newTestSetupIndex = frm.return_IndexList;
            //Todo: replace this line with testSetups=frm.testSetups after done with TestManagers
            updateTestSetupManager(newTestSetupIndex);

            saveAllTestsToCSV();
            refreshTestIDComboBox();*/
        }

        //Capture Readings from 1 or both Channels on Caltab
        private void captureReadingsCalTab()
        {
            if (testSetup_groupBox.Enabled == true)//if still in testSetup mode then dont capture
                return;

            //Pause live reading
            pauseLiveReading2 = true;
            pauseLiveReading1 = true;

            string ch1Reading = "", ch2Reading = "";
            string[] reading_arr = new string[] { "" };
            try
            {
                //Get reading from ch1 if open
                if (serialPort1.IsOpen)
                {
                    if ((ch1Trough_chckbox.Checked == false) || (ch1TroughList.Count == 0))
                    {//if trough mode is NOT on, or if it was on but the other channel has not escaped threshold 0 yet
                        string message = write_command("E", serialPort1);
                        decodeMessage(message, chann1Control.getcurrUnitClass(), 1); //Write to firstreading
                        ch1Reading = firstReading.ToString();
                    }
                    else
                    {
                        ch1Reading = ch1TroughPoint.ToString();
                    }
                }

                if (currTestSetup.testType == "1") //single channel test, pass in ch1reading only to reading_arr
                {
                    reading_arr = new string[] { ch1Reading };
                }
                else if (currTestSetup.testType == "2") //DualChannel test, pass in ch1 and ch2reading to reading_arr
                {
                    if (serialPort2.IsOpen)
                    {
                        if ((ch2Trough_chckbox.Checked == false) || (ch2TroughList.Count == 0))
                        {//if trough mode is NOT on, or if it was on but the other channel has not escaped threshold 0 yet
                            string message = write_command("E", serialPort2);
                            decodeMessage(message, chann2Control.getcurrUnitClass(), 2); //Write to secondreading
                            ch2Reading = secondReading.ToString();
                        }
                        else
                        {
                            ch2Reading = ch2TroughPoint.ToString();
                        }
                    }
                    reading_arr = new string[] { ch1Reading, ch2Reading };
                }

                //Use reading_arr to write to testGrid
                writeReadingsToTest(reading_arr, currTestSetup.testOrder);
            }
            catch
            {
                //Resume live reading
                pauseLiveReading1 = false;
                pauseLiveReading2 = false;
            }
            //Resume live reading
            pauseLiveReading1 = false;
            pauseLiveReading2 = false;
        }
        private void captureBtn_calTab_Click(object sender, EventArgs e)
        {
            if (pauseTest == false)
                captureReadingsCalTab();
        }

        //write a value to Excel.Worksheet-this uses C# built in Excel Interlope
        //Changed 3/25/20
        private Excel.Worksheet writeCellToExcelWorkBook(string cellID, string cellValue, Excel.Worksheet wsheet)
        {
            int rowIndex = Int32.Parse(cellID.Substring(1));
            string colID = cellID.Substring(0, 1);
            if (cellValue.StartsWith("0"))
            {
                wsheet.Cells[rowIndex, colID].NumberFormat = "@";
                string dataToWrite = cellValue;
                wsheet.Cells[rowIndex, colID] = dataToWrite;
            }
            else
            {
                try//Write as float
                {
                    float dataToWrite;
                    dataToWrite = Convert.ToSingle(cellValue);
                    wsheet.Cells[rowIndex, colID] = dataToWrite;
                }
                catch//write as string
                {
                    string dataToWrite = cellValue;
                    wsheet.Cells[rowIndex, colID] = dataToWrite;
                }
            }

            return wsheet;
        }

        //Write all tools headers and values into Excel Worksheet-using Excel Interlope
        //Change 8/31/19
        private Excel.Worksheet writeAllToolsInfoExcelWorkbook(Excel.Worksheet wsheet, int rowIndex)
        {

            string labelCol = "A";//write the header of tools to Column A 
            string valueCol = "B";//write value of tools header to Column B

            //Write Cal Cert Name into Excel
            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, calTabName, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, toolID_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolID_comboBox.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, testID_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, testID_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, toolSN_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolSN_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, recall_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, recall_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, temperature_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, temperature_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, humid_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, humid_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, model_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolModel_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, manu_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolManufacture_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, certLot_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolCertLot_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, procedure_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolProcedure_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, operatorID_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, toolOperatorID_txt.Text, wsheet);
            rowIndex++;

            wsheet = writeCellToExcelWorkBook(labelCol + rowIndex, comment_lbl.Text, wsheet);
            wsheet = writeCellToExcelWorkBook(valueCol + rowIndex, comment_txt.Text, wsheet);
            rowIndex++;


            nextAvaiExcelRow = rowIndex;//update next avai row to write in excel
            return wsheet;
        }

        //Convert from int Number to char for excel column ID
        //Only suppport up to 25 now (equal to 26 alphabet letter)
        private char convertNumToColCharExcel(int cellNum)
        {
            char returnVal;
            switch (cellNum)
            {
                case 0:
                    returnVal = 'A';
                    break;
                case 1:
                    returnVal = 'B';
                    break;
                case 2:
                    returnVal = 'C';
                    break;
                case 3:
                    returnVal = 'D';
                    break;
                case 4:
                    returnVal = 'E';
                    break;
                case 5:
                    returnVal = 'F';
                    break;
                case 6:
                    returnVal = 'G';
                    break;
                case 7:
                    returnVal = 'H';
                    break;
                case 8:
                    returnVal = 'I';
                    break;
                case 9:
                    returnVal = 'J';
                    break;
                case 10:
                    returnVal = 'K';
                    break;
                case 11:
                    returnVal = 'L';
                    break;
                case 12:
                    returnVal = 'M';
                    break;
                case 13:
                    returnVal = 'N';
                    break;
                case 14:
                    returnVal = 'O';
                    break;
                case 15:
                    returnVal = 'P';
                    break;
                case 16:
                    returnVal = 'Q';
                    break;
                case 17:
                    returnVal = 'R';
                    break;
                case 18:
                    returnVal = 'S';
                    break;
                case 19:
                    returnVal = 'T';
                    break;
                case 20:
                    returnVal = 'U';
                    break;
                case 21:
                    returnVal = 'V';
                    break;
                case 22:
                    returnVal = 'W';
                    break;
                case 23:
                    returnVal = 'X';
                    break;
                case 24:
                    returnVal = 'Y';
                    break;
                case 25:
                    returnVal = 'Z';
                    break;
                default:
                    returnVal = ' ';
                    break;

            }
            return returnVal;
        }

        //Put all readings from passed in Gridview into 2 dimensions array float
        //changed 04/20/20
        private float[,] convertGridDatatoFloats(DataGridView thisGrid,int startRow, int rowCount, int colCount)
        {
            float[,] returnFloats = new float[rowCount, colCount];
            for (int rowIndex = startRow; rowIndex < thisGrid.RowCount - 1; rowIndex++)
            {
                if (!thisGrid.Rows[rowIndex].IsNewRow)
                {
                    for (int colIndex = 0; colIndex < thisGrid.ColumnCount; colIndex++)
                    {
                        try
                        {
                            float reading = Single.Parse(thisGrid.Rows[rowIndex].Cells[colIndex].Value.ToString());
                            returnFloats[rowIndex-startRow, colIndex] = reading;
                        }
                        catch
                        {
                            //do nothing
                        }
                    }
                }
            }

            return returnFloats;
        }
        //Like convertGridDatatoFloats, but convert from 10 to 100 points
        //changed 04/20/20
        private float[,] convertGridDatatoFloatsTorqueChart(DataGridView oldGrid,int startRow, int rowCount, int colCount)
        {
            DataGridView torqueChartGrid = convertToTorqueChartGrid(oldGrid);
            return convertGridDatatoFloats(torqueChartGrid, startRow,rowCount, colCount);
        }
        //Copy struct and value of datagridRow to a returned row
        private DataGridViewRow CopyGridRow(DataGridViewRow oriRow)
        {
            DataGridViewRow newRow = oriRow.Clone() as DataGridViewRow;
            for (int colIndex=0; colIndex<oriRow.Cells.Count;colIndex++)
            {
                newRow.Cells[colIndex].Value = oriRow.Cells[colIndex].Value;
            }
            return newRow;
        }

        //Added 4/20/20
        //convert datagridview test set up into a torque chat with 10 times the amount of points
        //Pass in old grid, the increment amount for each point for both ch1 and ch2 delta
        private DataGridView convertToTorqueChartGrid(DataGridView oldGrid)
        {
            float ch1Delta=0, ch2Delta=0;
            const int decimalPlace = 4;
            //create newGrid with same struct
            DataGridView newGrid = new DataGridView();
            for (int j = 0; j < oldGrid.Columns.Count; j++)
            {
                newGrid.Columns.Add(oldGrid.Columns[j].Clone() as DataGridViewColumn);
            }
            //copy the first line from oldgrid to newGrid
            newGrid.Rows.Add(CopyGridRow(oldGrid.Rows[0]));
            //populate each row in new grid
            float ch1startBlockVal = 0,ch2startBlockVal = 0,targetStartBlockVal=0,lowStartBlockVal=0,highStartBlockVal=0;
            int newGridRowCount = 0;
            int oldGridRowCount = 0;
            const int pointCount = 10;
            //for each old row, expand to 9 smaller ones
            foreach (DataGridViewRow oldRow in oldGrid.Rows)
            {
                if ((!oldRow.IsNewRow)&&(oldGridRowCount!=0))
                {
                    //find delta for each block
                    if ((oldGridRowCount<oldGrid.Rows.Count-1))
                    {
                        ch1Delta = getTorqueChartDelta(convertGridCellToFloat(oldGrid.Rows[oldGridRowCount-1].Cells[ch1ReadingGridCol]), 
                            convertGridCellToFloat(oldRow.Cells[ch1ReadingGridCol]), pointCount);
                        ch2Delta = getTorqueChartDelta(convertGridCellToFloat(oldGrid.Rows[oldGridRowCount - 1].Cells[ch2ReadingGridCol]),
                            convertGridCellToFloat(oldRow.Cells[ch2ReadingGridCol]), pointCount);

                        //ch2Delta = getTorqueChartDelta(convertGridCellToFloat(oldRow.Cells[ch2ReadingGridCol]),
                        //    convertGridCellToFloat(oldGrid.Rows[oldGridRowCount+1].Cells[ch2ReadingGridCol]), pointCount);
                    }
                    
                    ch1startBlockVal = getbeginBlockVal(convertGridCellToFloat(oldRow.Cells[ch1ReadingGridCol]), ch1Delta);
                    ch2startBlockVal = getbeginBlockVal(convertGridCellToFloat(oldRow.Cells[ch2ReadingGridCol]), ch2Delta);

                    for (int rowCount = 1; rowCount <= 10; rowCount++)
                    {
                        newGridRowCount++;
                        DataGridViewRow newRow = (DataGridViewRow)oldRow.Clone();
                        newRow.Cells[0].Value = newGridRowCount+1;
                        //first row of this block, just add ch1startBlockVal and ch2startBlockVal
                        if (rowCount == 1)
                        {
                            newRow.Cells[ch1ReadingGridCol].Value = convertToFloatwithDecimal(ch1startBlockVal,decimalPlace);
                            newRow.Cells[ch2ReadingGridCol].Value = convertToFloatwithDecimal(ch2startBlockVal,decimalPlace);
                            newRow.Cells[targetGridCol].Value = convertToFloatwithDecimal(targetStartBlockVal,decimalPlace);
                            newRow.Cells[lowGridCol].Value = convertToFloatwithDecimal(lowStartBlockVal,decimalPlace);
                            newRow.Cells[highGridCol].Value = convertToFloatwithDecimal(highStartBlockVal,decimalPlace);
                        }
                        else//For the rest of the row, add delta to calculate value
                        {
                            DataGridViewRow prevRow = newGrid.Rows[newGrid.Rows.Count - 2];
                            newRow = populateNextTorqueChartRow(prevRow, newRow, ch1Delta, ch2Delta); 
                        }

                        newGrid.Rows.Add(newRow);
                    }
                }
                oldGridRowCount++;
            }
            //remove target, high low column
            newGrid = removeColumn(newGrid, highGridCol);
            newGrid = removeColumn(newGrid, targetGridCol);
            newGrid = removeColumn(newGrid, lowGridCol);
            
            return newGrid;
        }
        //remove column from datagridview
        private DataGridView removeColumn(DataGridView grid, int colIndex)
        {
            grid.Columns.RemoveAt(colIndex);
            return grid;
        }
        private DataGridViewRow populateNextTorqueChartRow(DataGridViewRow prevRow, DataGridViewRow nextRow, float ch1Delta, float ch2Delta)
        {
            const int decimalPlace = 4;
            float nextRowCh1 = 0, nextRowCh2 = 0;
            float prevRowCh1 = convertGridCellToFloat(prevRow.Cells[ch1ReadingGridCol]);
            float prevRowCh2 = convertGridCellToFloat(prevRow.Cells[ch2ReadingGridCol]);
            
            if (prevRowCh1 != 0)
            {
                nextRowCh1 = prevRowCh1 + ch1Delta;
                nextRow.Cells[ch1ReadingGridCol].Value = convertToFloatwithDecimal(nextRowCh1,decimalPlace);
            }
            if (prevRowCh2!=0)
            {
                nextRowCh2 = prevRowCh2 + ch2Delta;
                nextRow.Cells[ch2ReadingGridCol].Value = convertToFloatwithDecimal(nextRowCh2,decimalPlace);
            }
            return nextRow;
        }
        private float convertGridCellToFloat(DataGridViewCell cell)
        {
            float retVal = 0;
            if (cell.Value!=null)
            {
                try
                {
                    retVal = Single.Parse(cell.Value.ToString());
                }
                catch { retVal = 0; }
            }
            return retVal;
        }
        //get difference between each row for certain Column in Torque Chart
        private float getTorqueChartDelta (float value1, float value2,int pointCount)
        {
            float returnDelta = 0;
            if (pointCount>0)
                returnDelta = (value2 - value1) / 10;
            return returnDelta;
        }
        
        private float getDelta(DataGridView grid, int colIndex)
        {
            float retDelta = 0;
            if ((grid.Rows[0].Cells[colIndex].Value.ToString() != "") &&
                    (grid.Rows[1].Cells[colIndex].Value.ToString() != ""))
            {
                try
                {
                    float row0 = 0, row1 = 0;
                    row0 = convertGridCellToFloat(grid.Rows[0].Cells[colIndex]);
                    row1 = convertGridCellToFloat(grid.Rows[1].Cells[colIndex]);
                    retDelta = (row1 - row0) / 10;
                }
                catch { retDelta = 0; }
            }
            return retDelta;
        }
        //get the value to start for each block in Torque Chart
        private float getbeginBlockVal(float endVal, float delta)
        {
            float retVal = 0;
            if ((endVal!=0)&&(delta!=0))
                retVal=endVal - (9 * delta);
            return retVal;
        }


        //Write passed in Datagridview into worksheet
        //Changed 4/20/20
        private Excel.Worksheet writeSingleGridToExcel(ref DataGridView thisGrid, string quadrantName, Excel.Worksheet wsheet, int startCol, int startRow, bool isTorqueChart)
        {
            int colNum = startCol;
            int colRange = thisGrid.ColumnCount;
            int rowNum = startRow;
            int rowRange = thisGrid.RowCount - 1;
            //Write column headers
            //Write quadrant Name
            string cellID = "";
            cellID = convertNumToColCharExcel(colNum).ToString() + rowNum;
            wsheet = writeCellToExcelWorkBook(cellID, quadrantName, wsheet);

            //Write the header of each column
            rowNum++;
            int maxColCountForTorqueChart=2;//max column count that will be written from gridview to excel
            if (currTestSetup.testType=="1")
                maxColCountForTorqueChart = 2;
            else if (currTestSetup.testType == "2")
                maxColCountForTorqueChart = 3;
            const int repeatTimeToWriteTorqueChartCol = 3;//how many times we break up the readings to write to different columns
            if (isTorqueChart == true)
            {
                for (int timeWriteCount = 0; timeWriteCount < repeatTimeToWriteTorqueChartCol; timeWriteCount++)
                {
                    for (int colIndex = 0; colIndex < maxColCountForTorqueChart; colIndex++)
                    {
                        cellID = convertNumToColCharExcel(colNum).ToString() + rowNum;
                        string headerTxt = thisGrid.Columns[colIndex].HeaderText;
                        //Instead of write Channel 1 Readings, only write Channel 1
                        if (headerTxt.Contains(" Readings"))
                        {
                            int indexWhereToCutOffReadingsHeaderTxt = 9;
                            headerTxt=headerTxt.Remove(indexWhereToCutOffReadingsHeaderTxt);
                        }
                        wsheet = writeCellToExcelWorkBook(cellID, headerTxt, wsheet);
                        colNum ++;
                    }
                    colNum+=(4-maxColCountForTorqueChart);
                }
            }
            else
            {
                foreach (DataGridViewColumn gridCol in thisGrid.Columns)
                {
                    cellID = convertNumToColCharExcel(colNum).ToString() + rowNum;
                    wsheet = writeCellToExcelWorkBook(cellID, gridCol.HeaderText, wsheet);
                    colNum++;
                }
            }
            colNum = startCol;//reset colNum to A
            rowNum++;//go to next row

            //Write actual readings into Excel
            float[,] floatArr;

            int startRowToCopyGrid = 0;//start on this row to start copy Gridview to floatArr
            if (isTorqueChart==true)
            {
                colRange = maxColCountForTorqueChart;
                int rowCount = (thisGrid.Rows.Count - 1);
                rowRange = 9*rowCount+1;
                
                //write floatArr to 3 column
                rowRange = (rowRange / 3);

                //Convert thisGrid to torquechartGrid(91 points)
                DataGridView torqueChartGrid = convertToTorqueChartGrid(thisGrid);

                for (int colCount = 0; colCount < repeatTimeToWriteTorqueChartCol; colCount++)
                {
                    int colIndex = colNum + colCount * 4;
                    //Copy values from gridview to floatArr
                    if (colCount == repeatTimeToWriteTorqueChartCol - 1)//last repeated time to write torque chart column
                    {
                        //set rowRange=remaining row from grid
                        rowRange = torqueChartGrid.RowCount - startRowToCopyGrid-1;
                    }
                    floatArr= convertGridDatatoFloats(torqueChartGrid, startRowToCopyGrid, rowRange, maxColCountForTorqueChart);
                    startRowToCopyGrid += rowRange;

                    Excel.Range datarange = (Excel.Range)wsheet.Cells[rowNum, convertNumToColCharExcel(colIndex).ToString()];//Set initial cell of datarange
                    datarange = datarange.get_Resize(rowRange, colRange);//Set the size of datarange
                    datarange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, floatArr);
                }
                rowNum += (9 * rowCount + 1)/3+1;
            }
            else
            {
                floatArr = convertGridDatatoFloats(thisGrid,startRowToCopyGrid, rowRange, colRange);

                Excel.Range datarange = (Excel.Range)wsheet.Cells[rowNum, convertNumToColCharExcel(colNum).ToString()];//Set initial cell of datarange
                datarange = datarange.get_Resize(rowRange, colRange);//Set the size of datarange
                datarange.set_Value(Excel.XlRangeValueDataType.xlRangeValueDefault, floatArr);
                rowNum += rowRange;
            }
            
            nextAvaiExcelRow = rowNum;//update nextAvaiExcelRow
            return wsheet;
        }

        //Go through each char in testOrder and write corresponding testGrid to Excel worksheet
        //Changed 9/18/19

        private Excel.Worksheet writeAllTestGridsToExcelWsheet(Excel.Worksheet wsheet, string testOrder, bool isTorqueChart)
        {
            foreach (char chrTestOrder in testOrder)
            {
                int startCol = 0;
                int startRow = nextAvaiExcelRow + 1;
                switch (chrTestOrder)
                {
                    case '1':
                        wsheet = writeSingleGridToExcel(ref AFCW_grid, AFCW, wsheet, startCol, startRow,isTorqueChart);
                        break;
                    case '2':
                        wsheet = writeSingleGridToExcel(ref AFCCW_grid, AFCCW, wsheet, startCol, startRow,isTorqueChart);
                        break;
                    case '3':
                        wsheet = writeSingleGridToExcel(ref ALCW_grid, ALCW, wsheet, startCol, startRow,isTorqueChart);
                        break;
                    case '4':
                        wsheet = writeSingleGridToExcel(ref ALCCW_grid, ALCCW, wsheet, startCol, startRow,isTorqueChart);
                        break;
                }
            }
            return wsheet;
        }

        //Changed 4/20/20
        //Draw graph to CalCert excel export
        private int nextAvaiExcelRow;
        private Excel.Worksheet drawGraphToExcel(Excel.Worksheet xlDataSheet,Excel.Worksheet xlChartSheet, int startRow, int endRow, int col, string chartTitle, bool isTorqueChart)
        {
            object misValue = System.Reflection.Missing.Value;
            //init Chart setting
            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlChartSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(200, 80, 500, 250);
            Excel.Chart chartPage = myChart.Chart;

            //set line chart
            chartPage.ChartType = Excel.XlChartType.xlXYScatterLines;

            chartPage.HasTitle = true;
            chartPage.ChartTitle.Text = chartTitle;
            chartPage.ChartTitle.Font.Size = 12;
            chartPage.HasLegend = true;

            //Set values for target,reading,low high
            Excel.SeriesCollection oSeries = (Excel.SeriesCollection)myChart.Chart.SeriesCollection(misValue);
            Excel.Series reading = oSeries.NewSeries();
            reading.Name = colName;
            reading.Border.Color = Color.Blue;
            Excel.Range YRange;
            if (isTorqueChart == false)
            {
                string beginReading, endReading;
                beginReading = getColLetter(0) + (startRow + 1);
                endReading = getColLetter(0) + endRow;
                YRange = xlDataSheet.get_Range(beginReading, endReading);
            }
            else
            {
                string YRange_Str,XRange_Str;
                Excel.Range XRange;
                int YstartCol_int = 0,XstartCol_int=0;
                if (currTestSetup.testType == "1")
                    YstartCol_int = 0;
                else if (currTestSetup.testType=="2")
                    YstartCol_int = 1;
                XstartCol_int = YstartCol_int - 1;

                YRange_Str = getRangeStrForTorqueChart(YstartCol_int,startRow,endRow);
                YRange = xlDataSheet.get_Range(YRange_Str);

                XRange_Str= getRangeStrForTorqueChart(XstartCol_int, startRow, endRow);
                XRange = xlDataSheet.get_Range(XRange_Str);
                reading.XValues = XRange;
            }
            reading.Values = YRange;

            return xlChartSheet;

        }
        //Added 4/20/20
        //get range in string for torque chart export
        private string getRangeStrForTorqueChart(int startCol_int, int startRow_int,int endRow_int)
        {
            string range_Str;
            string beginRange1, beginRange2, beginRange3, endRange1, endRange2, endRange3;//set range for chart data
            beginRange1 = getColLetter(startCol_int) + (startRow_int + 1);
            endRange1 = getColLetter(startCol_int) + endRow_int;
            beginRange2 = getColLetter(startCol_int + 4) + (startRow_int + 1);
            endRange2 = getColLetter(startCol_int + 4) + endRow_int;
            beginRange3 = getColLetter(startCol_int + 8) + (startRow_int + 1);
            endRange3 = getColLetter(startCol_int + 8) + (endRow_int + 1);
            range_Str = beginRange1 + ":" + endRange1 + "," + beginRange2 + ":" + endRange2 + "," + beginRange3 + ":" + endRange3;
            return range_Str;
        }
        
        //convert char of grid sequence to name of grid
        //Changed 4/20/20
        private string getGridNameToGraph(char sequenceChr)
        {
            string gridNameToGraph = "";
            if (AFCWChart_radio.Checked == true)
                gridNameToGraph = AFCW;
            if (ALCWChart_radio.Checked == true)
                gridNameToGraph = ALCW;
            if (AFCCWChart_radio.Checked == true)
                gridNameToGraph = AFCCW;
            if (ALCCWChart_radio.Checked == true)
                gridNameToGraph = ALCCW;
            return gridNameToGraph;
        }
        //Changed 4/20/20
        //Write Tools info and testGridView Readings into Excel file
        private void saveTestResultExcel(string excelPath, string testOrder, bool isGraph,bool isTorqueChart)
        {
            //Init Excel to write
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlChartSheet = new Excel.Worksheet();
            Excel.Worksheet xlDataSheet=new Excel.Worksheet();
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            int runningWsheetCount = 0;
            int toolExcelRow = nextAvaiExcelRow;//since we are writing tool info first for each wsheet, save this row and reassign it to nextAvaiExcelRow for next wsheet quadrant
            while (runningWsheetCount<testOrder.Length)
            {
                string gridName="";
                switch (testOrder[runningWsheetCount])
                {
                    case '1':
                        gridName = AFCW;
                        break;
                    case '2':
                        gridName = AFCCW;
                        break;
                    case '3':
                        gridName = ALCW;
                        break;
                    case '4':
                        gridName = ALCCW;
                        break;
                }
                //Init DataSheet and ChartSheet
                if (isTorqueChart)
                {
                    xlChartSheet = new Excel.Worksheet();
                    xlChartSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                    xlChartSheet.Name = gridName + " Chart";
                    xlDataSheet = new Excel.Worksheet();
                    xlDataSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                    xlDataSheet.Name = gridName + " Data";
                }
                else
                {
                    xlDataSheet = new Excel.Worksheet();
                    if (runningWsheetCount < 1)
                        xlDataSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    else
                        xlDataSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add();
                    xlDataSheet.Name = gridName + " Data";
                }
                //Write Tool Info
                xlDataSheet = writeAllToolsInfoExcelWorkbook(xlDataSheet, toolExcelRow);
                
                //Write Test Grid
                int startTestGridRow = nextAvaiExcelRow;
                xlDataSheet = writeAllTestGridsToExcelWsheet(xlDataSheet, testOrder[runningWsheetCount].ToString(),isTorqueChart);
                
                //Write Stream
                //Todo: Implement

                //Draw Graph
                string gridNameToGraph = getGridNameToGraph(testOrder[runningWsheetCount]);
                if ((gridNameToGraph != "") && (isGraph == true) && (isTorqueChart==false))
                    xlDataSheet = drawGraphToExcel(xlDataSheet,xlDataSheet, startTestGridRow + 1, nextAvaiExcelRow - 1, 0, gridNameToGraph,isTorqueChart);
                else if (isTorqueChart==true)
                {
                    xlChartSheet = drawGraphToExcel(xlDataSheet, xlChartSheet, startTestGridRow + 2, nextAvaiExcelRow - 2, 0, gridName, isTorqueChart);
                }

                runningWsheetCount++;
            }

            //Save and release Excel object
            xlWorkBook.SaveAs(excelPath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlDataSheet);
            releaseObject(xlChartSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

        }

        //Handle exporting excel datas in cal Tab
        private void calTab_excelExport(bool isGraph,bool isTorqueChart)
        {
            string fileName = currentDualSerie + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
            string path = Path.Combine(getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName), fileName);
            if (getRegistryValue(defaultSaveLoc_keyName, saveLoc_valueName) == "")
            {
                MessageBox.Show(quickExportError, "Define Quick Export (File --> Define Quick Export)");
            }
            else
            {
                nextAvaiExcelRow = 1;
                try
                {
                    saveTestResultExcel(path, currTestSetup.testOrder, isGraph, isTorqueChart);
                    var dialogResult =
                        MessageBox.Show(
                            "Excel exported successfully at location: " + path +
                            "\n\nDo you want to open the Excel file?", "Open File?", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fail to Export to Excel due to error: \n" + ex.Message);
                }
                nextAvaiExcelRow = 1;
            }
        }

        private void ch1Trough_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            if ((ch1Trough_chckbox.Checked == true) && (ch2Trough_chckbox.Checked == true))
                ch2Trough_chckbox.Checked = false;
            if (ch1Trough_chckbox.Checked == true)
            {
                string trackModeCommand = "!M1;";
                write_command(trackModeCommand, serialPort1);//Set track mode for chan1 if Trough Mode
                ch1ModeControlBtn_calTab.Text = modeControl(serialPort1, ref chann1Control);//update text on Mode button
            }
        }

        private void ch2Trough_chckbox_CheckedChanged(object sender, EventArgs e)
        {
            if ((ch1Trough_chckbox.Checked == true) && (ch2Trough_chckbox.Checked == true))
                ch1Trough_chckbox.Checked = false;

            if (ch2Trough_chckbox.Checked == true)
            {
                string trackModeCommand = "!M1;";
                write_command(trackModeCommand, serialPort2);//Set track mode for chan2 if Trough Mode
                ch2ModeControlBtn_calTab.Text = modeControl(serialPort2, ref chann2Control);//update text on Mode button
            }
        }


        private void excelExport_calTab_btn_Click(object sender, EventArgs e)
        {
            if (testSetup_groupBox.Enabled == false)
            {
                bool isGraph = true, isTorqueChart=false;
                calTab_excelExport(isGraph,isTorqueChart);
            }
        }

        private void command_btn_Click(object sender, EventArgs e)
        {
            string command = command_txt.Text;
            commandResult_txt.Text = write_command(command, serialPort1);
        }

        private void deleteLastTestRow_btn_Click(object sender, EventArgs e)
        {
            char lastTestGridChr = '0';
            lastTestGridChr = lookForActiveTestGrid();
            DataGridView lastGrid = testGridFromChar(lastTestGridChr);
            //if not a new row and ch1reading and ch2reading on first Row are both empty
            //then lastTestGrid is the 1 before this currTestGrid
            if ((!lastGrid.Rows[0].IsNewRow) && (lastGrid.Rows[0].Cells[ch1ReadingGridCol].Value == "") &&
                        (lastGrid.Rows[0].Cells[ch2ReadingGridCol].Value == ""))
            {
                //If this is the first grid in testOrder then there is no grid before it
                if (lastTestGridChr == currTestSetup.testOrder[0])
                    return;
                else//lastTestGrid is previous character from testOrder
                {
                    lastTestGridChr = currTestSetup.testOrder[currTestSetup.testOrder.IndexOf(lastTestGridChr) - 1];
                }
            }

            //update lastGrid and delete last row of lastGrid
            lastGrid = testGridFromChar(lastTestGridChr);
            deleteLastTestRow(ref lastGrid);

            //update currTestGridNum
            currTestGridNum = lookForActiveTestGrid();

            //Change the color of the line that got deleted
            int plusOrMinus = 1;
            if ((lastTestGridChr == '1') || (lastTestGridChr == '3'))
                plusOrMinus = 1;
            else
            {
                plusOrMinus = -1;
            }

            //if it is single channel, update active Target
            if (currTestSetup.testType == "1")
            {
                char activeTestGridChr = lookForActiveTestGrid();
                float activeTarget;
                activeTarget = getActiveTargetfrTestGridChr(activeTestGridChr);
                testTarget_lbl.Text = activeTarget.ToString();
            }

            //Reevaluate color
            reevaluatePassFailData(ref lastGrid, plusOrMinus);
        }


        //Assign color code for each Data Row of passed in gridview
        //changed 6/9/19
        private void reevaluatePassFailData(ref DataGridView thisGrid, int posOrneg)
        {
            try
            {
                testType = testType_comboBox.SelectedIndex + 1;

                float target = 0, low = 0, high = 0, reading = 0;
                int gridRowIndex = 0;

                foreach (DataGridViewRow gridRow in thisGrid.Rows)
                {
                    bool floatValid = true;
                    try
                    {
                        target = Single.Parse(gridRow.Cells[target_colName].Value.ToString()) * posOrneg;
                        low = Single.Parse(gridRow.Cells[low_colName].Value.ToString()) * posOrneg;
                        high = Single.Parse(gridRow.Cells[high_colName].Value.ToString()) * posOrneg;
                        if ((testType == 1) || ((testType == 2) && (ch1Target_select.Checked)))
                            reading = Single.Parse(gridRow.Cells[chan1Readings_colName].Value.ToString()) * posOrneg;
                        else if ((testType == 2) && (ch2Target_select.Checked))
                            reading = Single.Parse(gridRow.Cells[chan2Readings_colName].Value.ToString()) * posOrneg;
                    }
                    catch { floatValid = false; }
                    if (floatValid == false)
                    {
                        reading = 0;
                        target = 0;
                        low = 0;
                        high = 0;
                    }
                    changeGridColor(ref thisGrid, gridRowIndex, reading, target, low, high);

                    gridRowIndex++;
                }
            }
            catch (NullReferenceException e)
            {
                //Do nothing
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Change color of testGrid Row based on whether passed in reading is within limit
        private void changeGridColor(ref DataGridView thisGrid, int rowIndex, float reading, float target, float low, float high)
        {
            int passFail = 0; //0=pass,-1=low,1=high
            if ((reading == target) ||
                            ((reading >= low) &&
                             (reading <= high)))
            {
                passFail = 0;
            }
            else if (reading < low) //When ch1Reading is low
            {
                passFail = -1;
            }
            else //when Ch1Reading is high
            {
                passFail = 1;
            }

            //Assign color code for Reading if it is too high or low
            if (passFail == 0)
            {
                thisGrid.Rows[rowIndex].Cells[chan1Readings_colName].Style.BackColor = passColor;
                thisGrid.Rows[rowIndex].Cells[chan2Readings_colName].Style.BackColor = passColor;
            }
            if (passFail == -1)
            {
                thisGrid.Rows[rowIndex].Cells[chan1Readings_colName].Style.BackColor = lowColor;
                thisGrid.Rows[rowIndex].Cells[chan2Readings_colName].Style.BackColor = lowColor;
            }
            if (passFail == 1)
            {
                thisGrid.Rows[rowIndex].Cells[chan1Readings_colName].Style.BackColor = highColor;
                thisGrid.Rows[rowIndex].Cells[chan2Readings_colName].Style.BackColor = highColor;
            }
        }

        //Return testOrder in term of Number, determined by passed in TestList
        private string getTestOrderStr(BindingList<string> testList)
        {
            string orderStr = "";
            foreach (string item in testList)
            {
                switch (item)
                {
                    case AFCW:
                        orderStr += "1";
                        break;
                    case AFCCW:
                        orderStr += "2";
                        break;
                    case ALCW:
                        orderStr += "3";
                        break;
                    case ALCCW:
                        orderStr += "4";
                        break;
                }
            }
            return orderStr;
        }

        private const int pointGridCol = 0,
            ch1ReadingGridCol = 1,
            ch2ReadingGridCol = 2,
            lowGridCol = 3,
            targetGridCol = 4,
            highGridCol = 5;

        //init TestGridview, set what it looks like and clear all datas
        //changed 3/25/20
        private void initTestGridView(ref DataGridView thisGrid, int colCount)
        {
            if (thisGrid.ColumnCount == 0)
            {
                thisGrid.Columns.Add("pointNum", "#");
                thisGrid.Columns.Add("ch1Reading", "Channel 1 Readings");
                thisGrid.Columns.Add("ch2Reading", "Channel 2 Readings");
                thisGrid.Columns.Add("low", "Low");
                thisGrid.Columns.Add("target", "Target");
                thisGrid.Columns.Add("high", "High");
                if (colCount>5)
                thisGrid.Columns.Add("trigger","Trigger Value");
            }
            PreventGridSort(ref thisGrid);
            thisGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            thisGrid.Columns[0].Width = 25;
            int colWidth = (thisGrid.Width - thisGrid.Columns[0].Width - 37) / colCount;
            for (int col = 1; col <= colCount; col++)
            {
                thisGrid.Columns[col].Width = colWidth;
            }
            thisGrid.RowHeadersWidth = thisGrid.Width - (colWidth * colCount) - 25;
            //Clear all Rows
            thisGrid.Rows.Clear();
        }

        //return Datatable that has current testTable in GridView
        private DataTable saveTestTable()
        {
            DataTable thisTable = new DataTable();

            //Create tempGridView that represent each empty test Grid to save to testTable from testSetup
            DataGridView[] tempGrids_arr = new DataGridView[] { AFCW_grid, AFCCW_grid, ALCW_grid, ALCCW_grid };
            for (int gridIndex = 0; gridIndex < tempGrids_arr.Length; gridIndex++)
            {
                //if 1 grid is not empty, use that to fill in empty ones
                if (!tempGrids_arr[gridIndex].Rows[0].IsNewRow)
                {
                    //check each grid, if empty then fill in
                    for (int secondGridIndex = 0; secondGridIndex < tempGrids_arr.Length; secondGridIndex++)
                    {
                        if (tempGrids_arr[secondGridIndex].Rows[0].IsNewRow)//if secondgrid is empty, fill it
                        {
                            DataGridView tempGrid = new DataGridView();
                            tempGrid = tempGrids_arr[gridIndex];
                            tempGrids_arr[secondGridIndex] = fillTestGrid(tempGrid, gridIndex,
                                secondGridIndex);
                        }
                    }
                }
            }

            //Write to testTable
            thisTable = converttestGridsToTable(tempGrids_arr);
            return thisTable;
        }

        //Return Datatable with testTable structure and Datas copied from grid_arr
        private DataTable converttestGridsToTable(DataGridView[] grid_arr)
        {
            DataTable returnTable = currTestSetup.testTable.Clone();

            for (int gridIndex = 0; gridIndex < grid_arr.Length; gridIndex++)//loop through each Grid in grid_arr
            {
                //Loop through each gridRow in this Grid, copy data to tableRow and add tableRow to returnTable
                foreach (DataGridViewRow gridRow in grid_arr[gridIndex].Rows)
                {
                    if (!gridRow.IsNewRow)
                    {
                        DataRow tableRow = returnTable.NewRow();
                        tableRow[currTestSetup.get_pointTableHeader()] = gridRow.Cells[pointGridCol].Value;
                        tableRow[currTestSetup.get_targetTableHeader()] = gridRow.Cells[targetGridCol].Value;
                        tableRow[currTestSetup.get_lowTableHeader()] = gridRow.Cells[lowGridCol].Value;
                        tableRow[currTestSetup.get_highTableHeader()] = gridRow.Cells[highGridCol].Value;
                        tableRow[currTestSetup.get_orderTableHeader()] = gridIndex + 1;

                        returnTable.Rows.Add(tableRow);
                    }
                }
            }

            return returnTable;
        }
        //Copy oriGrid with it's oriGridIndex to another grid with it's copiedGridIndex
        private DataGridView fillTestGrid(DataGridView oriGrid, int oriGridIndex, int returnGridIndex)
        {
            //initiate returnGrid
            DataGridView returnGrid = new DataGridView();

            initTestGridView(ref returnGrid,oriGrid.ColumnCount);

            int copyOrFlip = Math.Abs(oriGridIndex - returnGridIndex) % 2;//0=copy, 1=flip
            if (copyOrFlip == 0) //Copy exactly
            {
                returnGrid = oriGrid;
            }
            else if (copyOrFlip == 1)//Flip and switch low high
            {
                foreach (DataGridViewRow gridRow in oriGrid.Rows)
                {
                    if (!gridRow.IsNewRow)
                    {
                        try
                        {
                            //flip sign for target,low,high
                            float point = Int32.Parse(gridRow.Cells[pointGridCol].Value.ToString()),
                                target = Single.Parse(gridRow.Cells[targetGridCol].Value.ToString()) * -1,
                                high = Single.Parse(gridRow.Cells[highGridCol].Value.ToString()) * -1,
                                low = Single.Parse(gridRow.Cells[lowGridCol].Value.ToString()) * -1;

                            returnGrid.Rows.Add(point, "", "", target, low, high);
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

            return returnGrid;
        }

        //Return a testSetup with All current Setting on the screen
        private TestSetup saveThisTest(string isDefaultTest)
        {
            TestSetup returnSetup = new TestSetup();
            returnSetup.testID = testID_txt.Text;
            returnSetup.testType = (testType_comboBox.SelectedIndex + 1).ToString();

            returnSetup.percent_unit = limitEngPercent_comboBox.SelectedItem.ToString();
            returnSetup.FullScale = FS_txt.Text;
            returnSetup.low = lowLimit_txt.Text;
            returnSetup.high = highLimit_txt.Text;
            returnSetup.ch1Unit = ch1Unit_txt.Text;
            returnSetup.ch2Unit = ch2Unit_txt.Text;
            returnSetup.pointAmount = maxPoint_txt.Text;
            returnSetup.defaultTest = isDefaultTest;
            returnSetup.sampleNum = sampleNum_txt.Text;
            returnSetup.testOrder = getTestOrderStr(testList);
            returnSetup.testTable = saveTestTable();

            return returnSetup;
        }

        //return true if none of the strings in arr are empty
        private bool checkNoStrEmpty(string[] arrStrings)
        {
            foreach (string str in arrStrings)
            {
                if (str == "")
                {
                    return false;
                }
            }
            return true;
        }

        //Update the text when mode is changed for both channel
        private void updateModeText()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    chann1Control.updateCurrMode(write_command("?M;", serialPort1));
                    string newMode = chann1Control.getStringMode();
                    ch1ModeControlBtn_calTab.Text = newMode;
                    chan1_modeControl_button.Text = newMode;
                    modeControl_button.Text = newMode;
                }

                if (serialPort2.IsOpen)
                {
                    chann2Control.updateCurrMode(write_command("?M;", serialPort2));
                    string newMode = chann2Control.getStringMode();
                    ch2ModeControlBtn_calTab.Text = newMode;
                    chan2_modeControl_button.Text = newMode;
                }
            }
            catch { }
        }

        //change Mode of passed in Channel Tester
        private void changeMode(SerialPort passedinChannel, int modeIndex)
        {
            string modeCommand = "";
            if (passedinChannel.IsOpen)
            {
                try
                {
                    switch (modeIndex)
                    {
                        case 0://Track
                            modeCommand = "!M1;";
                            write_command(modeCommand, passedinChannel);//Set track mode for chan1 if Trough Mode
                            updateModeText();
                            break;
                        case 1://Peak
                            modeCommand = "!M2;";
                            write_command(modeCommand, passedinChannel);//Set track mode for chan1 if Trough Mode
                            updateModeText();
                            break;
                        case 2://1st Peak
                            modeCommand = "!M3;";
                            write_command(modeCommand, passedinChannel);//Set track mode for chan1 if Trough Mode
                            updateModeText();
                            break;
                        case 3://Trough
                            if (passedinChannel.PortName == serialPort1.PortName)
                            {
                                ch1Trough_chckbox.Checked = true;
                            }
                            else if (passedinChannel.PortName == serialPort2.PortName)
                            {
                                ch2Trough_chckbox.Checked = true;
                            }
                            break;
                    }
                }
                catch { }
            }
        }
        //changed 3/8/19 to fix test setup order when switching between tool
        private void toolID_comboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //if testSetup_groupbox is not enable, that means test is running
            //ask first before clear and the current test
            if (testSetup_groupBox.Enabled == false)
            {
                var result = MessageBox.Show("Select new tool will clear current test. Proceed?", "Warning", MessageBoxButtons.YesNo);
                //if Answer is no, do not change 
                if (result == DialogResult.No)
                    return;
            }
            //exit test run mode, go back to test setup mode
            abandonCurrentTest();

            int i = 1;
            i++;
            foreach (DataRow thisRow in toolsDataTable.Rows)
            {
                //if thisRow is the same toolID user select
                if (toolID_comboBox.Text == thisRow[pack.toolID_colName].ToString())
                {
                    //Update currToolTable
                    currToolTable = toolsDataTable.Clone();
                    currToolTable.ImportRow(thisRow);

                    //Show value of selected Tool to the fields
                    toolSN_txt.Text = thisRow[pack.SN_colName].ToString();
                    toolModel_txt.Text = thisRow[pack.model_colName].ToString();
                    toolManufacture_txt.Text = thisRow[pack.manufacturer_colName].ToString();
                    toolCertLot_txt.Text = thisRow[pack.lotID_colName].ToString();
                    toolProcedure_txt.Text = thisRow[pack.procedure_colName].ToString();

                    //change Mode for connected Testers
                    if (thisRow[pack.scanOperator_colName].ToString() == "1")
                    {
                        operatorID_lbl.Font = new Font(operatorID_lbl.Font, FontStyle.Bold);
                        if (!operatorID_lbl.Text.EndsWith("*"))
                            operatorID_lbl.Text += "*";
                    }
                    else
                    {
                        operatorID_lbl.Font = new Font(operatorID_lbl.Font, FontStyle.Regular);
                        if (operatorID_lbl.Text.EndsWith("*"))
                            operatorID_lbl.Text = operatorID_lbl.Text.Substring(0, operatorID_lbl.Text.Length - 1);
                    }
                    try
                    {
                        //testSetup_comboBox.SelectedIndex = 0;
                        testSetup_comboBox.SelectedItem = thisRow[pack.testID_colName].ToString();
                    }
                    catch
                    {
                        //testSetup_comboBox.SelectedIndex = 0;
                    }

                    //change mode of tester if tool setup is defined
                    //imode=channel2
                    //mode=channel1
                    int chan1ModeIndex = -1;
                    int chan2ModeIndex = -1;
                    try
                    {
                        chan1ModeIndex = Int32.Parse(thisRow[pack.mode_colName].ToString());
                    }
                    catch { }
                    try
                    {
                        chan2ModeIndex = Int32.Parse(thisRow[pack.imode_colName].ToString());
                    }
                    catch { }

                    if (chan1ModeIndex >= 0)
                    {
                        changeMode(serialPort1, chan1ModeIndex);
                    }
                    if (chan2ModeIndex >= 0)
                    {
                        changeMode(serialPort2, chan2ModeIndex);
                    }

                }
            }
        }

        //This method is called when user change either fullscale, low or high of currtestSetup, rewrite to test grid
        //changed 1/29/20
        private void FSLowHighchanged()
        {
            changeSaveStartTestBtn();
            bool proceed = false;
            if (testSetup_comboBox.SelectedIndex > 0) //Not new test, maxPoint text can be empty
            {
                string[] arrStr = new string[] { sampleNum_txt.Text, FS_txt.Text, lowLimit_txt.Text, highLimit_txt.Text };
                if (checkNoStrEmpty(arrStr) == true)
                    proceed = true;
            }
            else if (testSetup_comboBox.SelectedIndex == 0) //new test, maxPoint text CAN NOT be empty
            {
                string[] arrStr = new string[] { maxPoint_txt.Text, sampleNum_txt.Text, FS_txt.Text, lowLimit_txt.Text, highLimit_txt.Text };
                if (checkNoStrEmpty(arrStr) == true)
                    proceed = true;
            }

            //If the fields required are not filled, Don't proceed
            if (proceed == false)
                return;

            //Proceed with filling out the testGrid if all required fields are filled
            try
            {
                float newFS = Single.Parse(FS_txt.Text),
                    newLow = Single.Parse(lowLimit_txt.Text),
                    newHigh = Single.Parse(highLimit_txt.Text);
                int sampleNum = Int32.Parse(sampleNum_txt.Text);

                //default to % if not selected
                if (limitEngPercent_comboBox.SelectedIndex < 0)
                    limitEngPercent_comboBox.SelectedIndex = 0;
                int limitPercentEng = limitEngPercent_comboBox.SelectedIndex;//0 is percent, 1 is eng.unit
                int maxPoint = 0;

                try//if max point is determined by user, use it as maxpoint
                {
                    maxPoint = Int32.Parse(maxPoint_txt.Text);
                }
                catch
                {
                    //find testGrid with largest row count, use it as maxpoint
                    maxPoint = Math.Max(maxPoint, AFCW_grid.RowCount - 1);
                    maxPoint = Math.Max(maxPoint, AFCCW_grid.RowCount - 1);
                    maxPoint = Math.Max(maxPoint, ALCW_grid.RowCount - 1);
                    maxPoint = Math.Max(maxPoint, ALCCW_grid.RowCount - 1);
                }

                //Assign new Value to currTestSetup.testTable
                currTestSetup.testTable = updateTestTable(currTestSetup.testTable, maxPoint, newFS, newLow, newHigh, limitPercentEng, sampleNum, currTestSetup.defaultTest);

                //Display to Grid
                updateTestGrid(currTestSetup.testTable, testList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to read in user Input, please make sure value input is Float format");
            }
        }

        private int[] pointsBracket_arr = new int[] { 1, 2, 3, 5, 6, 7, 10, 11, 20 };
        private void testManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TestSequenceManager frm = new Form_TestSequenceManager(testSetups);
            frm.ShowDialog();

            if (frm.isTestSetupSaved)
            {
                testSetups = frm.testSetups;
                //Save all test to CSV
                saveAllTestsToCSV();
                refreshTestIDComboBox();
            }
        }

        private DataTable updateTestTable(DataTable thisTable, int maxRow, float FS, float low, float high, int limitPercentEng, int sampleNum, string defaultOrNotTest)
        {
            thisTable.Clear();
            int extraRow = 0;
            if (defaultOrNotTest == isDefaultTest)//1 of the default test, use bracket formula to fill out testGrid
            {
                for (int formulaIndex = pointsBracket_arr.Length - 1; formulaIndex >= 0; formulaIndex--)
                {
                    int formulaBracket = pointsBracket_arr[formulaIndex];
                    if (maxRow >= formulaBracket)
                    {
                        extraRow = maxRow - formulaBracket;
                        TestFormula currFormula = new TestFormula(formulaBracket);
                        //targetList in currFormula contains the target %
                        //call another updatetesttable that use targetList,FS and limit to update testtable
                        thisTable = updateTestTable(thisTable, currFormula.get_targetList(), extraRow, FS, low, high,
                            limitPercentEng, sampleNum);
                        break;
                    }
                }
            }
            else if (defaultOrNotTest == notDefaultTest)//Not default test, just divide evently FS with maxpoint
            {
                extraRow = 0;
                List<float> targetList = new List<float>();
                for (int index = 1; index <= maxRow; index++)
                {
                    float target = (float)100 / maxRow * index;
                    targetList.Add(target);
                }
                thisTable = updateTestTable(thisTable, targetList, extraRow, FS, low, high, limitPercentEng, sampleNum);
            }
            return thisTable;
        }
        //convert passed in float into certain Decimal Float
        private float convertToFloatwithDecimal(float oriFL, int decimalPlace)
        {
            float returnFl;
            returnFl = (float)Math.Round((double)oriFL, decimalPlace);
            return returnFl;
        }

        private void comList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshCOMList_btn_bigReading_Click(object sender, EventArgs e)
        {
            refreshComList();
        }

        private void upSize_btn_Click(object sender, EventArgs e)
        {
            float bigReadingFontSize = reading_bigReading_lbl.Font.Size + 2;
            reading_bigReading_lbl.Font = ChangeFontSize(reading_bigReading_lbl.Font, bigReadingFontSize);
            setRegistryValue(defaultBigReadingFontSize_keyName, defaultBigReadingFontSize_valueName, bigReadingFontSize.ToString());
        }

        //change font size of an object
        private Font ChangeFontSize(Font font, float fontSize)
        {
            if (font != null)
            {
                float currentSize = font.Size;
                if (currentSize != fontSize)
                {
                    font = new Font(font.Name, fontSize,
                        font.Style, font.Unit,
                        font.GdiCharSet, font.GdiVerticalFont);
                }
            }
            return font;
        }

        private void downSize_btn_Click(object sender, EventArgs e)
        {
            float bigReadingFontSize = reading_bigReading_lbl.Font.Size - 2;
            reading_bigReading_lbl.Font = ChangeFontSize(reading_bigReading_lbl.Font, bigReadingFontSize);
            setRegistryValue(defaultBigReadingFontSize_keyName, defaultBigReadingFontSize_valueName, bigReadingFontSize.ToString());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //pause or continue test. Also change the text on continue_pauseTest_btn
        private void changePauseContinueTestState()
        {
            if (pauseTest == false)
            {//switch to Pause Test
                pauseTest = true;
                continue_pauseTest_btn.Text = "Continue Test";
                continue_pauseTest_btn.BackColor = Color.Red;
            }
            else
            {//switch to Running Test
                pauseTest = false;
                continue_pauseTest_btn.Text = "Pause Test";
                continue_pauseTest_btn.BackColor = Color.Green;
            }
        }
        private void continue_pause_btn_Click(object sender, EventArgs e)
        {
            changePauseContinueTestState();
        }

        private void forceAutoClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (forceAutoClearToolStripMenuItem.Checked == true)
            {
                autoClearInterval = -5;
                autoClearCountDown = -5;
                forceAutoClearToolStripMenuItem.Checked = false;
            }
            else
            {
                Form_setForceAutoClear acForm = new Form_setForceAutoClear();
                acForm.ShowDialog();

                if (acForm.ac_interval > 0)
                {
                    autoClearInterval = acForm.ac_interval;
                    forceAutoClearToolStripMenuItem.Checked = true;
                }
                else
                {
                    autoClearCountDown = -5;
                    autoClearInterval = -5;
                    forceAutoClearToolStripMenuItem.Checked = false;
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool showNoupdate = true;
            InstallUpdateSyncWithInfo(showNoupdate);
        }
        //Auto update code
        //changed 10/6/17
        private void InstallUpdateSyncWithInfo(bool showNoUpdate)
        {
            try
            {
                if (ApplicationDeployment.IsNetworkDeployed)
                {

                    bool updateAvai = ApplicationDeployment.CurrentDeployment.CheckForUpdate();

                    if (updateAvai)
                    {
                        try
                        {
                            ApplicationDeployment.CurrentDeployment.Update();

                            //Save and restart application
                            CurrentDeployment_UpdateCompleted();
                        }
                        catch (DeploymentDownloadException dde)
                        {
                            MessageBox.Show("Cannot install the latest version of the application. Either the deployment server is unavailable, or your network connection is down. \n\nPlease check your network connection, or try again later. Error: " + dde.Message);
                        }
                        catch (TrustNotGrantedException tnge)
                        {
                            MessageBox.Show("The application cannot be updated. The system did not grant the application the appropriate level of trust. Please contact your system administrator or help desk for further troubleshooting. Error: " + tnge.Message);
                        }
                        catch { MessageBox.Show("Unable to update"); }
                    }
                    else if (showNoUpdate)
                    {
                        MessageBox.Show("No update available");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to check for update due to error:\n" + e.Message);
            }
        }

        //set autoUpdate on or off
        private void autoUpdateMenuItem_Click(object sender, EventArgs e)
        {
            if (autoUpdateMenuItem.Checked == true)
                setRegistryValue(defaultAutoUpdate_keyName, defaultAutoUpdate_valueName, autoUpdate_yesStr);
            else
                setRegistryValue(defaultAutoUpdate_keyName, defaultAutoUpdate_valueName, autoUpdate_noStr);
        }

        //After application updates, save and restart
        private void CurrentDeployment_UpdateCompleted()
        {
            try
            {
                var dialogResult = MessageBox.Show("Application will now restart to update. Continue?",
                    "Restart Application", MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    setRegistryValue(defaultTab_keyName, defaultTab_valueName, TabPages.SelectedIndex.ToString());//Set current defaultTab registry
                    closeport(serialPort1.PortName);
                    closeSecondport(serialPort2.PortName);
                    Application.Restart();
                }
            }
            catch
            { }
        }

        private void startTest_btn_Click(object sender, EventArgs e)
        {
            if (saveStartTest_btn.Text == "Save")
            {
                saveTest_calCert();
            }
            else if (saveStartTest_btn.Text == "Start")
            {//Implement start test
                startTest_calCert();
            }
        }

        private void ch1Connect_btn_bigReading_Click(object sender, EventArgs e)
        {
            opencloseFirstCOM(ref comList_bigReading);
            channel1MenuButtonUpdate();
        }

        //update testTable using targetList(%), Fullscale and limit
        private DataTable updateTestTable(DataTable returnTable, List<float> targetList, int extraRow, float FS, float low, float high, int limitPercentEng, int sampleNum)
        {
            int pointNum = 0;
            int decimalPlace = 4;//Max decimal places to show for each number
            foreach (float targetPercent in targetList)
            {
                float target_fl, low_fl, high_fl;
                target_fl = convertToFloatwithDecimal(FS * targetPercent / 100, decimalPlace);

                if (limitPercentEng == 0) //calculate low and high by %
                {
                    low_fl = convertToFloatwithDecimal((100 - low) / 100 * target_fl, decimalPlace);
                    high_fl = convertToFloatwithDecimal((100 + high) / 100 * target_fl, decimalPlace);
                }
                else //calculate by Eng Unit
                {
                    low_fl = convertToFloatwithDecimal(target_fl - low, decimalPlace);
                    high_fl = convertToFloatwithDecimal(target_fl + high, decimalPlace);
                }

                //add to returnTestTable=testTable
                pointNum++;
                for (int sample = 1; sample <= sampleNum; sample++)
                {
                    returnTable.Rows.Add(pointNum, low_fl, target_fl, high_fl, 1);
                    returnTable.Rows.Add(pointNum, low_fl * -1, target_fl * -1, high_fl * -1, 2);
                    returnTable.Rows.Add(pointNum, low_fl, target_fl, high_fl, 3);
                    returnTable.Rows.Add(pointNum, low_fl * -1, target_fl * -1, high_fl * -1, 4);
                }
            }

            //add empty row for extra row that are more than bracket formula
            for (int extraRowIndex = 0; extraRowIndex < extraRow; extraRowIndex++)
            {
                pointNum++;
                for (int sample = 1; sample <= sampleNum; sample++)
                {
                    returnTable.Rows.Add(pointNum, "", "", "", 1);
                    returnTable.Rows.Add(pointNum, "", "", "", 2);
                    returnTable.Rows.Add(pointNum, "", "", "", 3);
                    returnTable.Rows.Add(pointNum, "", "", "", 4);
                }
            }
            return returnTable;
        }

        //Save all test setups to CSV file
        //This method is called whenever a test setup is saved
        private void saveAllTestsToCSV()
        {
            List<string> strToWriteTestCSV = new List<string>();

            //Add total count of testSetup
            strToWriteTestCSV.Add(testSetups.Count.ToString());
            strToWriteTestCSV.Add("");

            //Write each test Datas to strToWriteTestCSV
            foreach (TestSetup thisTestSetup in testSetups)
            {
                strToWriteTestCSV.AddRange(thisTestSetup.GetCsvStrList());
                strToWriteTestCSV.Add("");//Add empty line between each test
            }

            //Write to CSV the contents of all saved Test Sequences
            try
            {
                System.IO.File.WriteAllLines(testsequenceCSVLoc, strToWriteTestCSV);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to write to " + testsequenceCSVLoc + " due to error\n" + ex.Message);
            }
        }



        private void saveStartTest_btn_Click(object sender, EventArgs e)
        {
            if (saveStartTest_btn.Text == "Save")
            {
                saveTest_calCert();
            }
            else if (saveStartTest_btn.Text == "Start")
            {//Implement start test
                startTest_calCert();
            }
        }

        //Save Test in Calcert
        private void saveTest_calCert()
        {
            if (testSetup_comboBox.SelectedIndex > 0) //Not a New Test, Save to currTestID in TestSetups
            {
                try
                {

                    testSetups[currTestIndex] = saveThisTest(testSetups[currTestIndex].defaultTest); //pass in TestSetup into TestSetups[currTestIndex]
                    currTestSetup = testSetups[currTestIndex]; //update the currTestSetup
                    refreshTestIDComboBox();
                    initCurrTestSetup(currTestIndex);

                    MessageBox.Show("Test successfully saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save due to error:\n\n" + ex.Message);
                }
            }
            else if (testSetup_comboBox.SelectedIndex == 0) //New Test, Save to a new TestSetup in TestSetups
            {
                try
                {
                    testSetups.Add(saveThisTest(notDefaultTest)); //Save the New Test to end of Test List
                    refreshTestIDComboBox(); //Refresh test id list
                    testSetup_comboBox.SelectedIndex = testSetups.Count;

                    //Select the last test(new test just got saved)
                    MessageBox.Show("Test successfully saved");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save New Test due to error:\n\n" + ex.Message);
                }
            }

            //Save all test to CSV
            saveAllTestsToCSV();
        }

        //Start test in Cal Cert Tab
        private void startTest_calCert()
        {
            try
            {
                //Still save first before running the test
                testSetups[currTestIndex] = saveThisTest(testSetups[currTestIndex].defaultTest); //pass in TestSetup into TestSetups[currTestIndex]
                currTestSetup = testSetups[currTestIndex]; //update the currTestSetup

                //Disable all testSetup Field
                testSetup_groupBox.Enabled = false;

                //Disable the copy button for cw and ccw if it is not valid
                if (currTestSetup.testOrder.Contains("1") && (currTestSetup.testOrder.Contains("3")))
                    copyCW_btn.Enabled = true;
                else
                {
                    copyCW_btn.Enabled = false;
                }
                if (currTestSetup.testOrder.Contains("2") && (currTestSetup.testOrder.Contains("4")))
                    copyCCW_btn.Enabled = true;
                else
                {
                    copyCCW_btn.Enabled = false;
                }

                //Activate the first testGrid in testOrder
                showActiveTestGrid(currTestSetup.testOrder[0]);

                //if it is single channel,display active Target
                if (currTestSetup.testType == "1")
                {
                    float activeTarget;
                    activeTarget = getActiveTargetfrTestGridChr(currTestSetup.testOrder[0]);
                    testTarget_lbl.Text = activeTarget.ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to start test due to error: \n\n" + ex.Message);
            }
        }
        //Attempt to write reading to end of passed in testGrid using colName
        //Return true or false of success write
        private bool writeToTestGrid(ref DataGridView thisGrid, string[] readings)
        {
            bool success = false;
            int rowIndex = 0;
            foreach (DataGridViewRow row in thisGrid.Rows)
            {
                if ((!row.IsNewRow) && (row.Cells[ch1ReadingGridCol].Value.ToString() == "") && (row.Cells[ch2ReadingGridCol].Value.ToString() == ""))//if not a new row and both ch1 and ch2 column for that row is empty, write next reading to it
                {
                    row.Cells[ch1ReadingGridCol].Value = readings[0];
                    if (readings.Length > 1) //DualTest
                        row.Cells[ch2ReadingGridCol].Value = readings[1];
                    success = true;
                    thisGrid.MultiSelect = false;
                    try
                    {
                        thisGrid.Focus();
                        thisGrid.CurrentCell = thisGrid.Rows[row.Index + 1].Cells[pointGridCol];
                    }
                    catch
                    {
                        thisGrid.Focus();
                        thisGrid.CurrentCell = thisGrid.Rows[row.Index].Cells[pointGridCol];
                    }

                    //if the last row of this grid is written and this Tool has pauseToolSetup, then pause test
                    int firstRow = 0;
                    try
                    {
                        if (((thisGrid.Rows[thisGrid.Rows.Count - 2].Cells[ch1ReadingGridCol].Value.ToString() != "") || (thisGrid.Rows[thisGrid.Rows.Count - 2].Cells[ch2ReadingGridCol].Value.ToString() != "")) &&
                            (getBoolValofTableCell(currToolTable, firstRow, pack.setupPause_colName)))
                            changePauseContinueTestState();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        changePauseContinueTestState();
                    }
                    break;//break out of loop after write
                }
                rowIndex++;
            }

            //if succesfully write to testGrid, update the next active Target
            if (success)
            {
                char activeTestGridChr = lookForActiveTestGrid();
                float activeTarget;
                activeTarget = getActiveTargetfrTestGridChr(activeTestGridChr);
                if (activeTarget!=0)
                    testTarget_lbl.Text = activeTarget.ToString();
            }

            return success;
        }
        //if passed in cell index is 0 or 1, return false or true
        private bool getBoolValofTableCell(DataTable thisTable, int rowIndex, string colIndex)
        {
            bool returnVal = false;
            if (thisTable.Rows[rowIndex][colIndex].ToString() == "1")
            {
                returnVal = true;
            }
            return returnVal;
        }
        //return the next available Target of passed in target DataGridView
        //changed 3/25/20
        private float getActiveTargetfrTestGridName(ref DataGridView activeTestGrid)
        {
            float returnTarget = 0;
            try
            {
                foreach (DataGridViewRow gridRow in activeTestGrid.Rows)
                {
                    if ((!gridRow.IsNewRow) && (gridRow.Cells[ch1ReadingGridCol].Value.ToString() == "") &&
                                    (gridRow.Cells[ch2ReadingGridCol].Value.ToString() == ""))
                    {
                        returnTarget = Single.Parse(gridRow.Cells[targetGridCol].Value.ToString());
                        break;
                    }
                }
            }
            catch
            {
                returnTarget = 0;
            }
            
            if (returnTarget == 0)
            {
                if (calculatePassFail() == true)
                {
                    showPassLbl();
                }
                else
                {
                    showFailLbl();
                }
            }
            return returnTarget;
        }
        //Added 3/25/20
        private void showPassLbl()
        {
            testTarget_lbl.Text = "PASS";
            testTarget_lbl.ForeColor = Color.Green;
        }
        //Added 3/25/20
        private void showFailLbl()
        {
            testTarget_lbl.Text = "FAIL";
            testTarget_lbl.ForeColor = Color.Red;
        }
        //return the next available Target of passed in testGrid Number in char format
        //this method calls getActiveTargetfrTestGridName to actually look for Target
        private float getActiveTargetfrTestGridChr(char activeGridNum)
        {
            float returnTarget;

            switch (activeGridNum)
            {
                case '1':
                    returnTarget = getActiveTargetfrTestGridName(ref AFCW_grid);
                    break;
                case '2':
                    returnTarget = getActiveTargetfrTestGridName(ref AFCCW_grid);
                    break;
                case '3':
                    returnTarget = getActiveTargetfrTestGridName(ref ALCW_grid);
                    break;
                case '4':
                    returnTarget = getActiveTargetfrTestGridName(ref ALCCW_grid);
                    break;
                default:
                    returnTarget = 0;
                    break;
            }

            return returnTarget;
        }

        private void firstChannelGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //return the char that indicates the active testGrid Number (1=AFCW, 2=AFCCW, etc.)
        private char lookForActiveTestGrid()
        {
            try
            {
                foreach (char gridIndexChr in currTestSetup.testOrder)
                {
                    switch (gridIndexChr)
                    {
                        case '1':
                            foreach (DataGridViewRow row in AFCW_grid.Rows)
                            {
                                if ((!row.IsNewRow) && (row.Cells[ch1ReadingGridCol].Value.ToString() == "") &&
                                    (row.Cells[ch2ReadingGridCol].Value.ToString() == ""))
                                    return gridIndexChr;
                            }
                            break;
                        case '2':
                            foreach (DataGridViewRow row in AFCCW_grid.Rows)
                            {
                                if ((!row.IsNewRow) && (row.Cells[ch1ReadingGridCol].Value.ToString() == "") &&
                                    (row.Cells[ch2ReadingGridCol].Value.ToString() == ""))
                                    return gridIndexChr;
                            }
                            break;
                        case '3':
                            foreach (DataGridViewRow row in ALCW_grid.Rows)
                            {
                                if ((!row.IsNewRow) && (row.Cells[ch1ReadingGridCol].Value.ToString() == "") &&
                                    (row.Cells[ch2ReadingGridCol].Value.ToString() == ""))
                                    return gridIndexChr;
                            }
                            break;
                        case '4':
                            foreach (DataGridViewRow row in ALCCW_grid.Rows)
                            {
                                if ((!row.IsNewRow) && (row.Cells[ch1ReadingGridCol].Value.ToString() == "") &&
                                    (row.Cells[ch2ReadingGridCol].Value.ToString() == ""))
                                    return gridIndexChr;
                            }
                            break;
                    }
                }
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("Null Reference Error Occured");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return currTestSetup.testOrder[currTestSetup.testOrder.Length - 1];//return the last quadrant in testOrder
        }

        //Passed in the number of current active testGrid (in char format) to show to user the current active Grid
        private void showActiveTestGrid(char activeGridNum)
        {
            switch (activeGridNum)
            {
                case '1':
                    AFCW_grid.Focus();

                    AFCW_grid.DefaultCellStyle.BackColor = SystemColors.HighlightText;
                    AFCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    /*
                    AFCW_grid.ReadOnly = false;
                    AFCCW_grid.ReadOnly = true;
                    ALCW_grid.ReadOnly = true;
                    ALCCW_grid.ReadOnly = true;
                    */
                    AFCWactive_label.Visible = true;
                    AFCCWactive_label.Visible = false;
                    ALCWactive_label.Visible = false;
                    ALCCWactive_label.Visible = false;

                    AFCW_grid.BorderStyle = BorderStyle.FixedSingle;
                    AFCCW_grid.BorderStyle = BorderStyle.None;
                    ALCW_grid.BorderStyle = BorderStyle.None;
                    ALCCW_grid.BorderStyle = BorderStyle.None;
                    break;
                case '2':
                    AFCCW_grid.Focus();
                    //AFCCW_grid.CurrentCell = AFCCW_grid.Rows[0].Cells[ch1ReadingGridCol];

                    AFCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    AFCCW_grid.DefaultCellStyle.BackColor = SystemColors.HighlightText;
                    ALCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    /*
                    AFCW_grid.ReadOnly = true;
                    AFCCW_grid.ReadOnly = false;
                    ALCW_grid.ReadOnly = true;
                    ALCCW_grid.ReadOnly = true;
                    */
                    AFCWactive_label.Visible = false;
                    AFCCWactive_label.Visible = true;
                    ALCWactive_label.Visible = false;
                    ALCCWactive_label.Visible = false;

                    AFCW_grid.BorderStyle = BorderStyle.None;
                    AFCCW_grid.BorderStyle = BorderStyle.FixedSingle;
                    ALCW_grid.BorderStyle = BorderStyle.None;
                    ALCCW_grid.BorderStyle = BorderStyle.None;
                    break;
                case '3':
                    ALCW_grid.Focus();
                    //ALCW_grid.CurrentCell = ALCW_grid.Rows[0].Cells[ch1ReadingGridCol];

                    AFCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    AFCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCW_grid.DefaultCellStyle.BackColor = SystemColors.HighlightText;
                    ALCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    /*
                    AFCW_grid.ReadOnly = true;
                    AFCCW_grid.ReadOnly = true;
                    ALCW_grid.ReadOnly = false;
                    ALCCW_grid.ReadOnly = true;
                    */
                    AFCWactive_label.Visible = false;
                    AFCCWactive_label.Visible = false;
                    ALCWactive_label.Visible = true;
                    ALCCWactive_label.Visible = false;

                    AFCW_grid.BorderStyle = BorderStyle.None;
                    AFCCW_grid.BorderStyle = BorderStyle.None;
                    ALCW_grid.BorderStyle = BorderStyle.FixedSingle;
                    ALCCW_grid.BorderStyle = BorderStyle.None;
                    break;
                case '4':
                    ALCCW_grid.Focus();
                    //ALCCW_grid.CurrentCell = ALCCW_grid.Rows[0].Cells[ch1ReadingGridCol];

                    AFCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    AFCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCCW_grid.DefaultCellStyle.BackColor = SystemColors.HighlightText;
                    /*
                    AFCW_grid.ReadOnly = true;
                    AFCCW_grid.ReadOnly = true;
                    ALCW_grid.ReadOnly = true;
                    ALCCW_grid.ReadOnly = false;
                    */
                    AFCWactive_label.Visible = false;
                    AFCCWactive_label.Visible = false;
                    ALCWactive_label.Visible = false;
                    ALCCWactive_label.Visible = true;

                    AFCW_grid.BorderStyle = BorderStyle.None;
                    AFCCW_grid.BorderStyle = BorderStyle.None;
                    ALCW_grid.BorderStyle = BorderStyle.None;
                    ALCCW_grid.BorderStyle = BorderStyle.FixedSingle;
                    break;
                default://No testGrid is Active
                    AFCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    AFCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    ALCCW_grid.DefaultCellStyle.BackColor = DefaultBackColor;
                    /*
                    AFCW_grid.ReadOnly = false;
                    AFCCW_grid.ReadOnly = false;
                    ALCW_grid.ReadOnly = false;
                    ALCCW_grid.ReadOnly = false;
                    */
                    AFCWactive_label.Visible = false;
                    AFCCWactive_label.Visible = false;
                    ALCWactive_label.Visible = false;
                    ALCCWactive_label.Visible = false;

                    AFCW_grid.BorderStyle = BorderStyle.None;
                    AFCCW_grid.BorderStyle = BorderStyle.None;
                    ALCW_grid.BorderStyle = BorderStyle.None;
                    ALCCW_grid.BorderStyle = BorderStyle.None;
                    break;

            }
        }
        //changed 07/31/18
        private void showHideCMK(bool isShown)
        {
            CM_lbl.Visible = isShown;
            CMVal_lbl.Visible = isShown;
            CMK_lbl.Visible = isShown;
            CMKVal_lbl.Visible = isShown;
        }
        //changed 07/31/18
        private void showCMK_chkBox_CheckedChanged(object sender, EventArgs e)
        {
            //show or hide CM and CMK value
            showHideCMK(showCMK_chkBox.Checked);
            if (showCMK_chkBox.Checked == false)
            {
                USL_txt.Text = "";
                LSL_txt.Text = "";
            }
        }

        private void USL_txt_TextChanged(object sender, EventArgs e)
        {
            ch1CMCMKReCalculate = true;
        }

        private void LSL_txt_TextChanged(object sender, EventArgs e)
        {
            ch1CMCMKReCalculate = true;
        }

        //Added 7/18/18
        private void forward_btn_Click(object sender, EventArgs e)
        {
            string forwardCommand = chann1Control.getForwardCommand();
            write_command(forwardCommand, serialPort1);
        }
        //Added 7/18/18
        private void reverse_btn_Click(object sender, EventArgs e)
        {
            string reverseCommand = chann1Control.getForwardCommand();
            write_command(reverseCommand, serialPort1);
        }
        //Added 7/18/18
        private void stop_btn_Click(object sender, EventArgs e)
        {
            string stopCommand = chann1Control.getStopCommand();
            write_command(stopCommand, serialPort1);
        }

        //set flag that ch1valuechanged= true
        private void singleChannel_gridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ch1CMCMKReCalculate = true;
        }

        private char currTestGridNum = '0';// value should be 1,2,3 or 4 = AFCW,AFCCW,etc.
        //Pass in array string that has ch1Reading and(or not) ch2Reading,testOrder String to write to Test Grid
        private void writeReadingsToTest(string[] readings, string testOrder)
        {
            //if curTestGridNum is not in testOrder, set it as the first char in testOrder
            if (!testOrder.Contains(currTestGridNum))
                currTestGridNum = testOrder[0];

            bool writeSucceed = false;
            currTestGridNum = lookForActiveTestGrid();//Assign the current grid Index to currAvaiGridChr

            //write the reading to active grid
            switch (currTestGridNum)
            {
                case '1':
                    writeSucceed = writeToTestGrid(ref AFCW_grid, readings);
                    break;
                case '2':
                    writeSucceed = writeToTestGrid(ref AFCCW_grid, readings);
                    break;
                case '3':
                    writeSucceed = writeToTestGrid(ref ALCW_grid, readings);
                    break;
                case '4':
                    writeSucceed = writeToTestGrid(ref ALCCW_grid, readings);
                    break;
            }

            //if write success, update and show the new active grid to user
            if (writeSucceed == true)
            {
                currTestGridNum = lookForActiveTestGrid(); //update currtestgridnum to reflect Current TestGrid
                showActiveTestGrid(currTestGridNum); //show Curr Active Grid after writing
            }

        }

        //passed in array of readings(max is 2 readings, 1 for chan1 and 1 for chan2)
        //Todo: still need to implement
        private void showReadingsToUser(string[] readings, string[] unit)
        {
            switch (TabPages.SelectedTab.Name)
            {
                case TTSTabName:
                    DataTTS_lbl.Text = readings[0];
                    unitTTS_lbl.Text = unit[0];
                    break;
                case SMDSingleTabName:
                    DataSMDSingle_lbl.Text = readings[0];
                    unitSingleCH_lbl.Text = unit[0];
                    break;
                case SMDDualTabName:
                    dataCh1DualChanTab_lbl.Text = readings[0];
                    unitCH1DualCHTab_lbl.Text = unit[0];
                    dataCh2DualChTab_lbl.Text = readings[1];
                    unitCH2DualCHTab_lbl.Text = readings[1];
                    break;
                case calTabName:
                    break;
            }
        }
        //Call by backgroundworker, process the passed in serialData and write to active gridview
        //Handle when user press Enter from channel tester
        private void processData_calTab(string Ch1TesterResponse)
        {

            string ch1Reading = "";//contain 1st Channel reading to write to testGrid
            string[] reading_arr = new string[] { "" };

            if ((ch1Trough_chckbox.Checked == false) || (ch1TroughList.Count == 0))
            {//if trough mode is NOT on, or if it was on but the other channel has not escaped threshold 0 yet
                string[] data = huy_parseData(Ch1TesterResponse);
                if (checkrowValid(data) == true)
                {
                    if (data.Length >= 3)
                        ch1Reading = data[1];
                    else
                    {
                        ch1Reading = data[0];

                    }
                }
            }
            else
            {
                ch1Reading = ch1TroughPoint.ToString();
            }

            if (currTestSetup.testType == "1")//single channel test
                reading_arr = new string[] { ch1Reading };
            else if (currTestSetup.testType == "2")
            {//Dual Channel Test
                //capture ch2
                string ch2Reading = "";
                if (serialPort2.IsOpen)
                {
                    if ((ch2Trough_chckbox.Checked == false) || (ch2TroughList.Count == 0))
                    {//if trough mode is NOT on, or if it was on but the other channel has not escaped threshold 0 yet
                        string message = write_command("E", serialPort2);
                        decodeMessage(message, chann2Control.getcurrUnitClass(), 2); //Write to secondreading
                        ch2Reading = secondReading.ToString();
                    }
                    else
                    {
                        ch2Reading = ch2TroughPoint.ToString();
                    }
                }
                reading_arr = new string[] { ch1Reading, ch2Reading };
            }

            //write array of reading into testGrid
            writeReadingsToTest(reading_arr, currTestSetup.testOrder);

        }
        ////added 10/2/18
        private void useLimit_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (useLimit_chkbox.Checked)
            {
                USL_txt.Enabled = false;
                LSL_txt.Enabled = false;
                try
                {
                    LowHighTarget lowhightarget = setHighLowTarget();
                    LSL_txt.Text = lowhightarget.low.ToString();
                    USL_txt.Text = lowhightarget.high.ToString();
                }
                catch
                {
                    LSL_txt.Text = "0";
                    USL_txt.Text = "0";
                }
            }
            else
            {
                USL_txt.Enabled = true;
                LSL_txt.Enabled = true;
            }
        }

        /////**********************************Start Connect and Handle Tools Database****************************************
        //Variables for Tools Database Connect
        private TcpClient clientSocket = new TcpClient();
        private static Client pack;
        private const string IP = "";
        private List<double> getCurrGridTargets(DataGridView grid)
        {
            List<double> returnTargets = new List<double>();
            string targetCol = currTestSetup.get_targetTableHeader();
            foreach (DataGridViewRow gridRow in grid.Rows)
            {
                if (!gridRow.IsNewRow)
                    returnTargets.Add(Convert.ToDouble(gridRow.Cells[targetCol].Value));
            }

            return returnTargets;
        }
        private void writeStreamToCurrentCalTest(DataTable streamResultTable)
        {
            string[] reading_arr = new string[] { };
            foreach (DataRow dtRow in streamResultTable.Rows)
            {
                if (currTestSetup.testType == "1")
                {
                    reading_arr = new string[] { dtRow[1].ToString() };
                }
                else if (currTestSetup.testType == "2")
                {
                    reading_arr = new string[] { dtRow[1].ToString(), dtRow[2].ToString() };
                }
                writeReadingsToTest(reading_arr, currTestSetup.testOrder);
            }
        }
        private void stream_btn_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            List<double> Targets = new List<double> { };
            char currGridNum = lookForActiveTestGrid();
            switch (currGridNum)
            {
                case '1':
                    Targets = getCurrGridTargets(AFCW_grid);
                    break;
                case '2':
                    Targets = getCurrGridTargets(AFCCW_grid);
                    break;
                case '3':
                    Targets = getCurrGridTargets(ALCW_grid);
                    break;
                case '4':
                    Targets = getCurrGridTargets(ALCCW_grid);
                    break;
            }
            int channelCount = 1;
            if (currTestSetup.testType == "1")
                channelCount = 1;
            else if (currTestSetup.testType == "2")
                channelCount = 2;
            else if ((serialPort1.IsOpen == true) && (serialPort2.IsOpen == true))
                channelCount = 2;

            int target_Channel = 1;
            if ((ch1Target_select.Checked) || (channelCount == 1))
                target_Channel = 1;
            else if (ch2Target_select.Checked)
                target_Channel = 2;
            
            Form_Streaming streamingForm = new Form_Streaming(serialPort1,serialPort2, Targets, target_Channel, channelCount);
            streamingForm.ShowDialog();

            //Write to current Test
            if (streamingForm.isSave == true)
                writeStreamToCurrentCalTest(streamingForm.returnResultTable);

            streamingForm.Dispose();

            timer2.Start();
        }

        private void singleCHStream_btn_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            int channelCount = 1;
            Form_Streaming streamingForm = new Form_Streaming(serialPort1,channelCount);
            streamingForm.ShowDialog();

            //Write to current Test
            if (streamingForm.isSave == true)
            {
                populateGridwithDataColumn(ref singleChannel_gridView, streamingForm.streamTableCh1,streamingForm.readingColIndex);
                updateTableandChart(ref singleChart, singleChannel_gridView);
                if (streamingForm.savePeak==true)
                {
                    double peakVal = streamingForm.peakVal;
                    if (peakVal != 0)
                    {
                        peakVal_lbl.Visible = true;
                        peakLabel_lbl.Visible = true;
                        peakVal_lbl.Text = peakVal.ToString();
                    }
                }
                else
                {
                    peakVal_lbl.Visible = false;
                    peakLabel_lbl.Visible = false;
                }
            }
            streamingForm.Dispose();
            timer2.Start();

        }

        private void ExportChart_btn_Click(object sender, EventArgs e)
        {
            if (testSetup_groupBox.Enabled == false)
            {
                calTab_excelExport(true,true);
            }
        }

        private const int portNum = 58008;
        private const int major = 1;
        private const int minor = 0;
        //Added 3/25/20
        private void checkAverage_radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (calculatePassFail() == true)
            {
                showPassLbl();
            }
            else
            {
                showFailLbl();
            }
        }
        //Added 3/25/20
        private void checkAllReading_radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (calculatePassFail() == true)
            {
                showPassLbl();
            }
            else
            {
                showFailLbl();
            }
        }

        private void maxPoint_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private BindingList<string> toolsIDListSearch = new BindingList<string>();
        private void toolsManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form_ToolsManager toolForm = new Form_ToolsManager(pack, testSetups);
            toolForm.ShowDialog();
            pack = toolForm.pack;
            updateAndBindToolsList();

            //Save testSetups in case testSetups were changed in Tool
            testSetups = toolForm.testSetups;
            //Save all test to CSV
            saveAllTestsToCSV();
            refreshTestIDComboBox();
        }

        //Run Tool server from command line
        private void runToolServer()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("cmd.exe", "/c cd C:\\Cert Manager & tools server");
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }
        //when user select logon, call this method to log on as userInputText or by Guest-if userInputText is empty
        private void logon()
        {
            connectServer();
            if (clientSocket.Connected)//if socket is connected with server, log on
            {
                pack.sendCommand("conn");
                pack.sendCommand("user");
                //userInputText.Clear();
            }
        }

        //establish connection with Server. Do not confused this with logon, client still need to logon as Guest or clientName later to query from server
        //changed 4/22/19
        private void connectServer()
        {
            //Connect to server
            if (clientSocket.Connected)
                clientSocket.Close();
            clientSocket = new System.Net.Sockets.TcpClient();
            try
            {
                tryToConnectToolDatabase();

            }
            catch (Exception e)
            {
                Thread.Sleep(3000);
                try
                {
                    tryToConnectToolDatabase();
                }
                catch
                {
                    MessageBox.Show("Fail to connect to Tools Database, please check to see if Tools server is installed");
                }
            }
        }
        //added 4/22/19
        private void tryToConnectToolDatabase()
        {
            clientSocket.Connect(IP, portNum);
            if (clientSocket.Connected)//true if found server, false if server is not running
            {
                //serverMsgTxt.Text += "\nServer is connected";
                pack = new Client(clientSocket.GetStream(), major, minor);
            }
        }

        private const string toolsObject = "tools";
        private const string resultsObject = "results";
        private const string samplesObject = "samples";
        private DataTable toolsDataTable = new DataTable();
        private BindingList<string> toolsIdList = new BindingList<string>();
        //Update all tools and their info into toolsDataTable
        private DataTable getAllTools(Client thisPack)
        {
            DataTable returnTable = new DataTable();
            thisPack.serverstream = clientSocket.GetStream();
            //pack.conditions = condTable.Copy(); //No need for condition since we are getting all the tools
            thisPack.obj = toolsObject;
            thisPack.sendCommand("find");
            int sleepCap = 0;
            do
            {
                sleepCap++;
                returnTable = thisPack.resultTable.Copy();
            } while (thisPack.resultUpdate == false && sleepCap < 100);
            thisPack.resultUpdate = false;
            return returnTable;
        }

        //Return List<string> that contains all datas from passed in Datatable, given colName
        private List<string> getDataColfromDataTable(DataTable thisTable, string colName)
        {
            List<string> returnToolsList = new List<string>();
            try
            {
                returnToolsList = thisTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>(colName)).ToList();
                //Assign whole column of data into returnToolsList
            }
            catch { MessageBox.Show("Unable to get list of Tools"); }
            return returnToolsList;
        }


        //update the list of all Tools ID
        private BindingList<string> updateToolIDList(DataTable toolsDataTable)
        {
            BindingList<string> returnTooList = new BindingList<string>(getDataColfromDataTable(toolsDataTable, pack.toolID_colName));
            return returnTooList;
        }

        //return Table of Tools that has valid toolID only
        private DataTable extractToolsDataTable(DataTable toolsAndModelTable)
        {
            DataTable returnTable = new DataTable();
            returnTable = toolsAndModelTable.Clone();
            foreach (DataRow tableRow in toolsAndModelTable.Rows)
            {
                //if toolID is null, copy to Model table
                if (tableRow[pack.toolID_colName].ToString() != "")
                {
                    returnTable.ImportRow(tableRow);
                }
            }
            return returnTable;
        }


        //update the toolsDatatable, then bind toolsIDList to toolID column of toolsDatatable
        //Changed 8/14/18 to bind toolID in SC
        private void updateAndBindToolsList()
        {
            DataTable toolsModelTable = getAllTools(pack).Copy();//Update toolsDatatable with all of Tools and Models Info
            toolsDataTable = extractToolsDataTable(toolsModelTable).Copy();//Get only tools Data into toolsDataTable
            toolsIdList = updateToolIDList(toolsDataTable);//update tools_id list.
            toolID_comboBox.Items.Clear();
            toolID_comboBox.Items.AddRange(toolsIdList.ToArray());//Bind toolID_comboBox to toolsIDList

            toolID_SC_comboBox.Items.Clear();
            toolID_SC_comboBox.Items.AddRange(toolsIdList.ToArray());

        }

        //get the row that contains header for opening SC Excel
        private int getHeaderRowIndex_SC(ExcelWorkbook wbook)
        {
            int returnHeaderRowIndex = 1;
            int colIndex = 0;
            for (int rowIndex = returnHeaderRowIndex; rowIndex < wbook.Worksheets[0].Rows.Count; rowIndex++)
            {
                string headerName = wbook.Worksheets[0].Cells[rowIndex, colIndex].Value.ToString();
                switch (headerName)
                {
                    case "Point":
                        returnHeaderRowIndex = rowIndex;
                        break;
                }
            }
            //if cant find the row with header row, just return default start row=1
            return returnHeaderRowIndex;
        }

        //Auto Select Tool in SC when open Excel file
        private void getToolIDWhenOpenExcelSC(ExcelWorkbook wbook, int lastRow)
        {
            //find and select Tool Name
            for (int rowIndexCSV = 0; rowIndexCSV < lastRow; rowIndexCSV++)
            {
                const int headerColIndex = 0;
                string headerName = wbook.Worksheets[0].Cells[rowIndexCSV, headerColIndex].Value.ToString();
                switch (headerName)
                {
                    case "Tool Name *":
                        string toolID = wbook.Worksheets[0].Cells[rowIndexCSV, headerColIndex + 1].Value.ToString();
                        int toolIndex = -1;
                        toolIndex = toolID_SC_comboBox.FindStringExact(toolID);
                        toolID_SC_comboBox.SelectedIndex = toolIndex;
                        break;

                }
            }
        }

        //get Headers and Data for SC Table when open old Excel SC
        private DataTable getHeaderAndDataFromExcel_SC(ExcelWorkbook wbook, int headerRowIndexExcel, int startReadingRowIndexExcel, int startColIndexExcel)
        {
            DataTable returnTable = new DataTable();
            //Create header for datatable
            for (int colIndexCSV = startColIndexExcel; colIndexCSV < wbook.Worksheets[0].Columns.Count; colIndexCSV++)
            {
                string headerName = wbook.Worksheets[0].Cells[headerRowIndexExcel, colIndexCSV].Value.ToString();
                string tempText = wbook.Worksheets[0].Cells[headerRowIndexExcel + 1, colIndexCSV].Value.ToString();
                switch (headerName)
                {
                    case "High":
                        if ((tempText != "") && (tempText != "0"))
                        {
                            high_limit.Text = tempText;
                            high_unit.Select();
                        }
                        break;
                    case "Low":
                        if ((tempText != "") && (tempText != "0"))
                        {
                            low_limit.Text = tempText;
                            low_unit.Select();
                        }
                        break;
                    case "Target":
                        if ((tempText != "") && (tempText != "0"))
                            target.Text = tempText;
                        break;

                    default://Write to datatable to return
                        returnTable.Columns.Add(wbook.Worksheets[0].Cells[headerRowIndexExcel, colIndexCSV].Value.ToString());
                        break;
                }
            }

            //Put values into tables
            for (int colIndexCSV = startColIndexExcel; colIndexCSV < wbook.Worksheets[0].Columns.Count; colIndexCSV++)
            {
                for (int rowIndexCSV = startReadingRowIndexExcel; rowIndexCSV < wbook.Worksheets[0].Rows.Count; rowIndexCSV++)
                {
                    float value;
                    try
                    {
                        value = Single.Parse(wbook.Worksheets[0].Cells[rowIndexCSV, colIndexCSV].Value.ToString());
                        if ((rowIndexCSV - startReadingRowIndexExcel) > (returnTable.Rows.Count - 1))
                            returnTable.Rows.Add();
                        returnTable.Rows[rowIndexCSV - startReadingRowIndexExcel][colIndexCSV - startColIndexExcel] = value;
                    }
                    catch
                    {
                        try
                        {
                            returnTable.Rows[rowIndexCSV - startReadingRowIndexExcel][colIndexCSV - startColIndexExcel] = null;
                        }
                        catch { }
                    }
                }
            }

            return returnTable;
        }
        /// ***********************************End Connect and Handle Tools Database******************************************

        //Start handle opening old Test

        //parse readings from wbook into Data Table and return it
        //Used by SC and DC tab
        //Todo: Handle open old excel with CM CMK
        //Changed 7/31/18
        //working
        private DataTable getTableFromExcel(ExcelWorkbook wbook)
        {
            string xcellTabName = wbook.Worksheets[0].Cells[0, 0].Value.ToString();
            int headerRowIndexExcel = 1;
            if (xcellTabName == SMDSingleTabName)
                headerRowIndexExcel = getHeaderRowIndex_SC(wbook);
            else if (xcellTabName == SMDDualTabName)
                headerRowIndexExcel = 1;

            int startReadingRowIndexExcel = headerRowIndexExcel + 1;
            int startColIndexExcel = 0;

            //select tool ID that was associated with the test
            getToolIDWhenOpenExcelSC(wbook, headerRowIndexExcel);

            DataTable returnTable = new DataTable();
            returnTable = getHeaderAndDataFromExcel_SC(wbook, headerRowIndexExcel, startReadingRowIndexExcel, startColIndexExcel).Copy();

            return returnTable;
        }

        //Add value of table column into 1st channel gridview
        private void populateGridwithDataColumn(ref DataGridView thisGrid, DataTable table, int colIndex)
        {
            thisGrid.Rows.Clear();
            thisGrid.Refresh();
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                string[] strToadd = new string[1];
                strToadd[0] = table.Rows[rowIndex][colIndex].ToString();
                addRowWithoutUpdateChart(strToadd);
            }
        }
        private void deleteAllSeriesFrChart(ref Chart chart)
        {
            //Assign list of current Serie Name into serieNames
            string[] serieNames = new string[chart.Series.Count];
            for (int serieIndex = 0; serieIndex < chart.Series.Count; serieIndex++)
            {
                serieNames[serieIndex] = chart.Series[serieIndex].Name;
            }
            foreach (string serieName in serieNames)
            {
                try
                {
                    deleteSerie(ref chart, serieName);
                }
                catch { }
            }
        }

        //openTest for Single Channel
        private void openTest_SC(ExcelWorkbook wbook)
        {
            DataTable tempTable = getTableFromExcel(wbook).Copy();
            copyTable(ref tempTable, ref singleTable);
            copyTable(ref tempTable, ref noCurrentTable);

            //Delete all the series from old singleChart
            deleteAllSeriesFrChart(ref singleChart);

            //draw each serie from singleTable into chart
            //by assign currcolname to each table header
            //then call updatechart
            for (int tableColIndex = 1; tableColIndex < singleTable.Columns.Count; tableColIndex++)
            {
                currColumn = singleTable.Columns[tableColIndex].ColumnName;
                //updateChart(singleChart)
                int pointColIndex = -1;
                pointColIndex = singleTable.Columns.IndexOf("Point");
                if (pointColIndex >= 0)
                {
                    //init each serie 
                    string currSerieName = singleTable.Columns[tableColIndex].ColumnName;
                    initChartSerie(ref singleChart, currSerieName);

                    //bind reading from this table column to currSerie of the chart
                    bindChartXYwithTableHeader(ref singleTable, pointColIndex, tableColIndex, ref singleChart, currSerieName);
                    singleChart = setChart(singleChart, currSerieName, 1);
                }
            }

            //Show Series on checked list for single Channel
            arr_singleSeries = getListOfSeriesName(singleChart);
            singleSeriesListView.Items.Clear();
            AddSerieToCheckList(ref singleSeriesListView, arr_singleSeries);
            updateListViewColor(ref singleSeriesListView, singleChart);//update color for seriesListView

            //Assign header of last column in single table to currColumn
            currColumn = singleTable.Columns[singleTable.Columns.Count - 1].ColumnName;
            //Write last column of single table to singleChannel_gridview
            populateGridwithDataColumn(ref singleChannel_gridView, singleTable, singleTable.Columns.Count - 1);

            bindTable();
        }

        //Main method used to open old test for DC
        private void openTest_DC(ExcelWorkbook wbook)
        {
            DataTable tempTable = getTableFromExcel(wbook).Copy();
            copyTable(ref tempTable, ref noCurrentDualTable);
            copyTable(ref tempTable, ref dualTable);
            bindDualTable();//bind dualtable to gridview
            //Delete all series in dualchart
            deleteAllSeriesFrChart(ref dualChart);
            string tempCurrDualSerie = "";
            //init series for dualchart
            for (int colIndex = 0; colIndex < dualTable.Columns.Count; colIndex++)
            {
                if ((colIndex % 2) == 0)
                {
                    string serieName = "Run" + ((colIndex / 2) + 1);
                    if (tempCurrDualSerie == "")
                        tempCurrDualSerie = serieName;
                    initChartSerie(ref dualChart, serieName);

                    //Assign x and y for each serie
                    updateDualChartSerieXY(serieName, ref dualChart, dualTable, colIndex, colIndex + 1);
                    dualChart = setChart(dualChart, serieName, 2);
                }
            }
            currentDualSerie = tempCurrDualSerie;
            //Save list of Series from dualChart into ar_dualSeries
            arr_dualSeries = getListOfSeriesName(dualChart);
            dualSeriesListView.Items.Clear();
            //Update the listView with passed in array of List String
            AddSerieToCheckList(ref dualSeriesListView, arr_dualSeries);
            //update color for seriesListView
            updateListViewColor(ref dualSeriesListView, dualChart);

            //Write to firstChanGrid
            populateGridwithDataColumn(ref firstChannelGrid, dualTable, 0);
            //Write to secondChannelgrid
            secondChannelTable.Rows.Clear();
            //copy 2nd row of dualtable into secondchanneltable (most current channel 2 reading)
            copyTableByColIndex(dualTable, 1, ref secondChannelTable, 0);
            bindSecondChannelTable();
        }

        //Main method used to open old test for Cal Cert
        private void openTest_CalCert(ExcelWorkbook wbook)
        {
            //[row,col]

            string toolIDLabel = "";
            string tempTestIDLabel = "";

            toolIDLabel = wbook.Worksheets[0].Cells[1, 0].Value.ToString();
            tempTestIDLabel = wbook.Worksheets[0].Cells[2, 0].Value.ToString();
            if ((toolIDLabel == toolID_lbl.Text) && (tempTestIDLabel == testID_lbl.Text))
            {
                //Start reading tool ID and test ID                                                 
                string toolID = wbook.Worksheets[0].Cells[1, 1].Value.ToString();
                string testID = wbook.Worksheets[0].Cells[2, 1].Value.ToString();

                //select tool
                toolID_comboBox.SelectedIndex = toolID_comboBox.FindStringExact(toolID);
                testSetup_comboBox.SelectedIndex = testSetup_comboBox.FindStringExact(testID);

                //start Test
                startTest_calCert();

                //Populate all test Grid Data

                for (int rowIndex = 0; rowIndex < wbook.Worksheets[0].Rows.Count; rowIndex++)
                {
                    try
                    {
                        string cellValue = "";

                        cellValue = wbook.Worksheets[0].Cells[rowIndex, 0].Value.ToString();

                        switch (cellValue)
                        {
                            case AFCW:
                                populateTestGridwithDataFromExcel(wbook.Worksheets[0], rowIndex + 2, ref AFCW_grid);
                                break;
                            case AFCCW:
                                populateTestGridwithDataFromExcel(wbook.Worksheets[0], rowIndex + 2, ref AFCCW_grid);
                                break;
                            case ALCW:
                                populateTestGridwithDataFromExcel(wbook.Worksheets[0], rowIndex + 2, ref ALCW_grid);
                                break;
                            case ALCCW:
                                populateTestGridwithDataFromExcel(wbook.Worksheets[0], rowIndex + 2, ref ALCCW_grid);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        //Do nothing, since it is just empty line in excel that throw this    
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Unable to recognize this Test file for Cal Cert");
            }
        }

        //Populate test grid with excel data, only deal w 1 quadrant at a time
        //changed 05/01/18 to not write 0 point from old test
        private void populateTestGridwithDataFromExcel(ExcelWorksheet wsheet, int startRow, ref DataGridView testGrid)
        {
            try
            {
                const int pointColIndex = 0, ch1ColIndex = 1, ch2ColIndex = 2;
                int rowIndex = startRow;
                int point;
                float ch1Reading, ch2Reading;
                while (wsheet.Cells[rowIndex, pointColIndex].Value.ToString() != "")
                {
                    point = Int32.Parse(wsheet.Cells[rowIndex, pointColIndex].Value.ToString());
                    ch1Reading = Single.Parse(wsheet.Cells[rowIndex, ch1ColIndex].Value.ToString());
                    ch2Reading = Single.Parse(wsheet.Cells[rowIndex, ch2ColIndex].Value.ToString());
                    if (ch1Reading != 0)
                        testGrid[ch1ColIndex, point - 1].Value = ch1Reading;
                    if (ch2Reading != 0)
                        testGrid[ch2ColIndex, point - 1].Value = ch2Reading;

                    rowIndex++;
                }
            }
            catch { /*do nothing and just move on to next quadrant*/}
        }
        //Copy readings from column of frTable to toTable at column index
        private void copyTableByColIndex(DataTable frTable, int frColIndex, ref DataTable toTable, int toColIndex)
        {
            int rowIndex = 0;
            foreach (DataRow tableRow in frTable.Rows)
            {
                string readingCell = tableRow[frColIndex].ToString();
                if (rowIndex >= toTable.Rows.Count)
                {
                    toTable.Rows.Add();
                }
                toTable.Rows[rowIndex][toColIndex] = readingCell;
                rowIndex++;
            }
        }

        //Open old Test for SC, DC and SMD-Tools, pass in path of excel file
        //Changed 3/29/18
        private void openOldTestExcel(string path)
        {
            ExcelWorkbook wbook = ExcelWorkbook.ReadXLS(path);

            string xcellTabName = wbook.Worksheets[0].Cells[0, 0].Value.ToString();
            //See first cell if it has SMD Tab header
            try
            {
                switch (xcellTabName)
                {
                    case SMDSingleTabName:
                        if (xcellTabName == TabPages.SelectedTab.Name)
                            openTest_SC(wbook);
                        else
                            MessageBox.Show("Single Channel Tab needed to be selected to open this Excel.");
                        break;
                    case SMDDualTabName:
                        if (xcellTabName == TabPages.SelectedTab.Name)
                            openTest_DC(wbook);
                        else
                            MessageBox.Show("Dual Channel Tab needed to be selected to open this Excel.");
                        break;
                    case calTabName:
                        if (xcellTabName == TabPages.SelectedTab.Name)
                            openTest_CalCert(wbook);
                        else
                            MessageBox.Show("Cal Cert Tab needed to be selected to open this Excel.");
                        break;
                    default:
                        MessageBox.Show("Unable to recognize the Saved Test file.");
                        break;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to load file due to error:\n" + e.Message, "Error");
            }
        }

        //show dialog box to get Excel path to open
        private string getOpenPathName(string defaultName)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.InitialDirectory = lastPathName;
            openDlg.Filter = "Excel|*.xls";
            openDlg.FileName = defaultName;
            openDlg.ShowDialog();
            string path = "";
            path = openDlg.FileName;
            if (path != "")
                lastPathName = extractPathFromExcelPathName(path);
            return path;
        }
        private void openStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = getOpenPathName("");
            if ((path != "") && (path.Contains(".xls")))
            {
                openOldTestExcel(path);
                updateTableandChart(ref singleChart, singleChannel_gridView);
            }
        }

        //check each grid in Calcert, if not empty then see if test is complete
        private bool checkGridIsDone(DataGridView thisGrid)
        {
            bool isComplete = true;
            //if grid is empty, this grid is complete
            if (thisGrid.Rows.Count == 1)
                isComplete = true;
            else
            {

                foreach (DataGridViewRow thisRow in thisGrid.Rows)
                {
                    try
                    {
                        if (thisRow.IsNewRow)
                            break;
                        //Chan1 needs to be filled
                        if (thisRow.Cells[1].Value.ToString() == "")
                        {
                            isComplete = false;
                            break;
                        }

                        //Chan2 only needs to be filled if Dual Channel Test
                        if ((testType_comboBox.SelectedIndex == 1) && (thisRow.Cells[2].Value.ToString() == ""))
                        {
                            isComplete = false;
                            break;
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        MessageBox.Show("Null Exception");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            return isComplete;
        }

        //Check if current Test in Calcert is complete before allow Save to Cert
        private bool isReadyToSaveCert()
        {
            bool isReadyToSave = true;
            //Check each gridview
            if (checkGridIsDone(AFCW_grid) == false)
                isReadyToSave = false;
            else if (checkGridIsDone(AFCCW_grid) == false)
                isReadyToSave = false;
            else if (checkGridIsDone(ALCW_grid) == false)
                isReadyToSave = false;
            else if (checkGridIsDone(ALCCW_grid) == false)
                isReadyToSave = false;
            return isReadyToSave;
        }
        private string parseToolInfoToStr(string toolID)
        {
            string toolInfoStr = "";
            string newline = Environment.NewLine;
            foreach (DataRow thisRow in toolsDataTable.Rows)
            {
                //if thisRow is the same toolID user select
                if (toolID == thisRow[pack.toolID_colName].ToString())
                {
                    toolInfoStr += "Tool ID: " + thisRow[pack.toolID_colName].ToString() + newline;
                    toolInfoStr += "Serial: " + thisRow[pack.SN_colName].ToString() + newline;
                    if (TabPages.SelectedTab.Name == calTabName)
                    {
                        if (toolOperatorID_txt.Text != "")
                            toolInfoStr += "Operator: " + toolOperatorID_txt.Text + newline;

                        DateTime today = DateTime.Now;
                        toolInfoStr += $"Cal Date: {today.ToString("MM-dd-yyyy")}{newline}";
                        if (recall_txt.Text != "")
                        {
                            int duration = 0;
                            try
                            {
                                duration = Int16.Parse(recall_txt.Text);
                            }
                            catch (Exception e)
                            {
                                Debug.Write(e.Message);
                            }
                            DateTime dueDate = today.AddMonths(duration);
                            toolInfoStr += "Due Date: " + dueDate.ToString("MM-dd-yyyy") + newline;
                        }
                    }
                }
            }
            return toolInfoStr;
        }
        private void printToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toolInfos = "";
            if (TabPages.SelectedTab.Name == SMDSingleTabName)
                toolInfos = parseToolInfoToStr(toolID_SC_comboBox.Text);
            else if (TabPages.SelectedTab.Name == calTabName)
                toolInfos = parseToolInfoToStr(toolID_comboBox.Text);
            if (toolInfos != "")
            {
                try
                {
                    PrintDymo printTool = new PrintDymo(toolInfos);
                    printTool.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to detect any Dymo printer. Please make sure Dymo Label Printer is connected, and Dymo Driver is properly installed.");
                }
            }
            else
            {
                MessageBox.Show("Invalid Tool is selected");
            }

        }
        //Added 3/25/20

        private const string pointGridName = "pointNum",
            ch1ReadingGridName = "ch1Reading",
            ch2ReadingGridName = "ch2Reading",
            lowGridName = "low",
            targetGridName = "target",
            highGridName = "high";
        //Check if test is done, if done, return Pass/Fail
        //Added 3/25/20
        private bool calculatePassFail()
        {
            bool isPass = false;
            if (checkAllReading_radioBtn.Checked == true)
            {
                isPass = checkPassFailBasedOnAllReadingPass();

            }
            else if (checkAverage_radioBtn.Checked == true)
            {
                isPass = checkPassFailBasedOnAverage();
            }
            return isPass;
        }
        //check if average readings in GridView pass or not
        //Added 3/25/20
        private bool checkPassFailBasedOnAverage()
        {
            float readingTotal = 0, lowTotal = 0, highTotal = 0, readingAverage = 0, lowAverage = 0, highAverage = 0;
            int count = 0;
            List<DataGridView> gridList = new List<DataGridView> { AFCW_grid, ALCW_grid, AFCCW_grid, ALCCW_grid };
            foreach (DataGridView grid in gridList)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        try
                        {
                            float reading =Math.Abs(Single.Parse(row.Cells[ch1ReadingGridName].Value.ToString())),
                                lowtarget = Math.Abs(Single.Parse(row.Cells[lowGridName].Value.ToString())),
                                hightarget = Math.Abs(Single.Parse(row.Cells[highGridName].Value.ToString()));
                            count++;
                            readingTotal += reading;
                            lowTotal += lowtarget;
                            highTotal += hightarget;
                        }
                        catch { }
                    }
                }
            }
            if (count > 0)
            {
                readingAverage = readingTotal / count;
                lowAverage = lowTotal / count;
                highAverage = highTotal / count;
            }
            if ((lowAverage <= readingAverage) && (readingAverage <= highAverage))
                return true;
            else
                return false;

        }

        //Check if all readings in GridViews pass or not
        //Added 3/25/20
        private bool checkPassFailBasedOnAllReadingPass()
        {
            bool isPassed = true;
            List<DataGridView> gridList = new List<DataGridView> { AFCW_grid, ALCW_grid, AFCCW_grid, ALCCW_grid };
            foreach (DataGridView grid in gridList)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        try
                        {
                            float reading = Single.Parse(row.Cells[ch1ReadingGridName].Value.ToString()),
                                lowtarget = Single.Parse(row.Cells[lowGridName].Value.ToString()),
                                hightarget = Single.Parse(row.Cells[highGridName].Value.ToString());

                            if ((reading < lowtarget) || (reading > hightarget))
                            {
                                isPassed = false;
                                return isPassed;
                            }
                        }
                        catch { }
                    }
                }
            }
            return isPassed;
        }
    }

}
