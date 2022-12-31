using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    
    public partial class Form_MenuControl : Form
    {
        private SerialPort port=new SerialPort();
        private List<SerialPort> ports=new List<SerialPort>();
        private string formName="Menu Remote Control ";
        private string[] peakPlanking = new string[49];
        private TesterControl thisTesterControl=new TesterControl();
        private List<TesterControl> allTesterControlList=new List<TesterControl>();
        private string currMode;
        private string currStrMode;
        private int currAC;
        private string currUnitClass;
        private string currUnit;
        private string currFreq;
        private int currPeakBlank;
        private bool currSignLock;
        private const string zeroAC = "Off";
        public Form_MenuControl(SerialPort thisPort,ref TesterControl Control,string channel)
        {
            InitializeComponent();
            port = thisPort;
            thisTesterControl = Control;
            formName += channel;
            this.Text = formName;
        }
        public Form_MenuControl(List<SerialPort> ports,List<TesterControl> AllTesterControls)
        {
            InitializeComponent();
            this.ports = ports;
            port = ports[0];
            allTesterControlList = AllTesterControls;
            thisTesterControl = allTesterControlList[0];
            this.Text = formName;
        }
        private void Form_MenuControl_Load(object sender, EventArgs e)
        {
            loadInitalForm();
        }
        //Clear all comboBox selected index
        private void resetField()
        {
            autoClear_comboBox.SelectedIndex = -1;
            peakBlanking_comboBox.SelectedIndex = -1;
            Filter_comboBox.SelectedIndex = -1;
            signLock_comboBox.SelectedIndex = -1;
            unit_comboBox.SelectedIndex = -1;
            mode_comboBox.SelectedIndex = -1;
        }
        private void loadInitalForm()
        {
            //Set all currValues
            getInitialValues();
            updateOriLabel();

            //Load all values for peakPlanking_comboBox
            for (int index = 0; index < peakPlanking.Length; index++)
            {
                peakPlanking[index] = (index + 2).ToString();
            }
            peakBlanking_comboBox.DataSource = peakPlanking;
            peakBlanking_comboBox.SelectedIndex = -1;
            //end loading peakPlanking_comboBox
            
            //Load Value for unit_comboBox
            if (currMode == "Torque")
            {
                unit_comboBox.Items.AddRange(new string[] {"INOZ","INLB","FTLB","Nm","cNm","gfcm","Kgfcm","Kgfm"});
            }
            if (currMode == "Force")
            {
                unit_comboBox.Items.AddRange(new string[] {"OZ","LB","N","gf","Kgf"});
            }
            if (currMode == "Pressure")
            {
                unit_comboBox.Items.AddRange(new string[] {"bar","psi","kpsi","kPa"});
            }
            //End loading unit_comboBox
        }

        //load initial values for AC, filter,peak blanking, SignLock
        private void getInitialValues()
        {
            currAC = thisTesterControl.getcurrAC();
            currFreq = thisTesterControl.getcurrFreq();
            currPeakBlank = thisTesterControl.getcurrPeakBlank();
            currSignLock = thisTesterControl.getcurrSignLock();
            currMode = thisTesterControl.getcurrUnitClass();
            currStrMode = thisTesterControl.getStringMode();
            currUnit = thisTesterControl.getStrUnit();
        }
        //Update the text for all *_ori_label
        private void updateOriLabel()
        {
            if (currAC == 0)
                AC_ori_label.Text = zeroAC;
            else
                AC_ori_label.Text = currAC + " s";
            freq_ori_label.Text = currFreq;
            peak_ori_label.Text = currPeakBlank + "%";
            if (currSignLock == true)
                signLock_ori_label.Text = "On";
            else
            {
                signLock_ori_label.Text = "Off";
            }
            mode_ori_label.Text = currStrMode;
            unit_ori_label.Text = currUnit;
        }
        //pass in string that represent hex vale, return char that represent that hex
        private char StrHextoChar(string str_hex)
        {
            int int_hex = 0;
            int_hex = int.Parse(str_hex, NumberStyles.AllowHexSpecifier);
            char chr_freq_SL = (char)int_hex;
            return chr_freq_SL;
        }
        //Call this for each comboBox to check if user doesn't select than set it to default value
        private void checkEmptyComboBox(ref ComboBox combo_box, string currValue)
        {
            try
            {
                if (combo_box.SelectedIndex < 0)
                    combo_box.SelectedIndex = combo_box.Items.IndexOf(currValue);
            }
            catch { }
        }

        //Return a command to write to port and set all the values for "!M..." command
        private string setModeCommand()
        {
            //Get Mode
            checkEmptyComboBox(ref mode_comboBox,currStrMode);
            int mode = mode_comboBox.SelectedIndex+1;

            int AC;
            string modeCommand = "!M";
            char peakChar;
            bool signLock;
            int freq_SL = 0;
            //get AutoClear char
            if (currAC!=0)
                checkEmptyComboBox(ref autoClear_comboBox,currAC.ToString());
            else
            {
                checkEmptyComboBox(ref autoClear_comboBox, zeroAC);
            }
            AC = autoClear_comboBox.SelectedIndex;
            
            //Get peak Blanking char
            checkEmptyComboBox(ref peakBlanking_comboBox,currPeakBlank.ToString());
            peakChar = Convert.ToChar((peakBlanking_comboBox.SelectedIndex + 2));
            peakChar += ' ';
            
            //Get Filter Freq and SignLock char
            checkEmptyComboBox(ref Filter_comboBox,currFreq);
            
            switch (Filter_comboBox.SelectedIndex)
            {
                case 0:
                    freq_SL = 30;
                    break;
                case 1:
                    freq_SL = 40;
                    break;
                case 2:
                    freq_SL = 50;
                    break;
                case 3:
                    freq_SL = 60;
                    break;
                case 4:
                    freq_SL = 70;
                    break;
                case 5:
                    freq_SL = 80;
                    break;
            }
            if (currSignLock==true)
                checkEmptyComboBox(ref signLock_comboBox,"On");
            else
                checkEmptyComboBox(ref signLock_comboBox, "Off");
            if (signLock_comboBox.SelectedIndex == 1)
                signLock = true;
            else
            {
                signLock = false;
            }
            if (signLock == true)
                freq_SL += 8;
            //Convert from string hex to char
            char chr_freq_SL = StrHextoChar(freq_SL.ToString());
            modeCommand = modeCommand + mode + AC + peakChar + chr_freq_SL+";";
            return modeCommand;
        }
        //Return a command to write to port and set the value for "!U..." command
        private string setUnitCommand()
        {
            checkEmptyComboBox(ref unit_comboBox, currUnit);
            string query = "!U" + unit_comboBox.SelectedIndex+";";
            return query;
        }
        
        private void submit_button_Click(object sender, EventArgs e)
        {
            if (ports.Count > 0)
            {
                foreach (SerialPort port in ports)
                {
                    Form1.write_command(setModeCommand(), port);
                    Form1.write_command(setUnitCommand(), port);
                }
            }
            else
            {
                Form1.write_command(setModeCommand(), port);
                Form1.write_command(setUnitCommand(), port);
            }
            thisTesterControl.getModeAndUnitClass(Form1.write_command("?M;",port),Form1.write_command("?C;",port),Form1.write_command("?U;",port));//update all the info for Passed in TesterControl

            getInitialValues();
            updateOriLabel();
        }
        private void cancel()
        {
            Close();
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            cancel();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            resetField();
        }

        private void Filter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
