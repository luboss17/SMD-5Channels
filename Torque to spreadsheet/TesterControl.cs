using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class TesterControl
    {
        private int currMode;
        private int currAC;
        private string currUnitClass;
        private string currFreq;
        private int currPeakBlank;
        private bool currSignLock;
        private int currUnitCode;
        private const string forward = "!*F;", reverse = "!*R;", stop = "!*S;";

        public TesterControl()
        {
            currMode = -1;
            currAC = -1;
            currUnitClass = "Torque";
            currFreq = "Not Set";
            currPeakBlank = 0;
            currSignLock = false;
        }
        /// <summary>
        /// Pass in write_command(?M) and write_command(?C);
        /// </summary>
        /// <param modeMsg="write_command("?M",serialport)"></param>
        /// <param capMsg="write_command("?C",serialport)"></param>
        /// <param unitMsg="write_command("?U",serialport)"></param>
        public void getModeAndUnitClass(string modeMsg, string capMsg, string unitMsg)
        {
            setInfo(modeMsg);//get AutoClear, Filter Frequency,Peak Blanking, Sign Lock
            setCap(capMsg);
            setUnit(unitMsg);
        }

        public string getcurrUnitClass()
        {
            return currUnitClass;
        }

        private int getcurrUnitCode()
        {
            return currUnitCode;
        }
        public int getcurrMode()

        {
            return currMode;
        }
        public string getcurrFreq()
        {
            return currFreq;
        }

        public int getcurrPeakBlank()
        {
            return currPeakBlank;
        }

        public bool getcurrSignLock()
        {
            return currSignLock;
        }

        public int getcurrAC()
        {
            return currAC;
        }
        /// <summary>
        /// Call this after cycle mode to get the currMode updated
        /// </summary>
        /// <param name="message, passed in from writing write_command("?M",port)"></param>
        public void updateCurrMode(string message)
        {
            if (message != "")
            {
                char modeChr = message[0];
                Int32.TryParse(modeChr.ToString(), out currMode);
            }
        }
        /// <summary>
        /// return query command to cycle to next Mode(Cal Track Peak 1stPeak)
        /// </summary>
        /// <returns></returns>
        public string cycleMode()
        {
            string queryCommand = "";
            if (currMode >= 3)
                currMode = 1;
            else
                currMode++;
            queryCommand = "!M" + (currMode) + ";";
            return queryCommand;
        }
        /// <summary>
        /// return the command to cycle to next Unit of tester
        /// </summary>
        /// <param name="currUnit"></param>
        /// <returns></returns>
        public string cycleUnit(int currUnit)
        {
            int maxUnitNumber = 0;
            string queryCommand = "";
            switch (currUnitClass)
            {
                case "Torque":
                    maxUnitNumber = 7;
                    break;
                case "Force":
                    maxUnitNumber = 4;
                    break;
                case "Pressure":
                    maxUnitNumber = 3;
                    break;
            }

            if (currUnit >= maxUnitNumber)
                currUnit = 0;
            else
            {
                currUnit++;
            }
            currUnitCode = currUnit;//Updated currUnitCode
            queryCommand = "!U" + currUnit + ";";
            return queryCommand;
        }

        public string getStrUnit()
        {
            if (currUnitClass == "Torque")
            {
                switch (currUnitCode)
                {
                    case 0:
                        return "INOZ";
                    case 1:
                        return "INLB";
                    case 2:
                        return "FTLB";
                    case 3:
                        return "Nm";
                    case 4:
                        return "cNm";
                    case 5:
                        return "gfcm";
                    case 6:
                        return "Kgfcm";
                    case 7:
                        return "Kgfm";
                    default:
                        return "";
                }
            }
            if (currUnitClass == "Force")
            {
                switch (currUnitCode)
                {
                    case 0:
                        return "OZ";
                    case 1:
                        return "LB";
                    case 2:
                        return "N";
                    case 3:
                        return "gf";
                    case 4:
                        return "Kgf";
                    default:
                        return "";
                }
            }
            if (currUnitClass == "Pressure")
            {
                switch (currUnitCode)
                {
                    case 0:
                        return "bar";
                    case 1:
                        return "psi";
                    case 2:
                        return "kpsi";
                    case 3:
                        return "kPa";
                    default:
                        return "";
                }
            }
            return "";
        }
        /// <summary>
        /// return the current mode in String
        /// </summary>
        /// <returns></returns>
        public string getStringMode()
        {
            switch (currMode)
            {
                /*case 0:
                    return "Cal/Memory"; Only QC consistently has 0, so exclude it for now*/
                case 1:
                    return "Track";
                case 2:
                    return "Peak";
                case 3:
                    return "First Peak";
                default:
                    return "";
            }
        }
        public string getForwardCommand()
        {
            return forward;
        }
        public string getReverseCommand()
        {
            return reverse;
        }
        public string getStopCommand()
        {
            return stop;
        }
        private void setUnit(string message)
        {
            if (message.Length > 0)
            {
                currUnitCode = Int32.Parse(message[0].ToString());
            }
        }
        //set values for currMode and currAC
        private void setInfo(string message)
        {
            currMode = setMode(message);
            currAC = setAC(message);
            currPeakBlank = setPeakBlank(message);
            currSignLock = setSignLock(message);
            currFreq = setFreq(message);
        }
        //set Filter Frequency
        private string setFreq(string message)
        {
            string freq = "";
            char char_freq = message[3];
            string str_HexValue = convertCharToHexStr(char_freq);
            switch (str_HexValue[0])
            {
                case '3':
                    freq = "125 Hz";
                    break;
                case '4':
                    freq = "250 Hz";
                    break;
                case '5':
                    freq = "500 Hz";
                    break;
                case '6':
                    freq = "1000 Hz";
                    break;
                case '7':
                    freq = "1500 Hz";
                    break;
                case '8':
                    freq = "2000 Hz";
                    break;
                default:
                    freq = "Not found";
                    break;
            }
            return freq;
        }

        //set Peak Planking
        private int setPeakBlank(string message)
        {
            int peakBlank = 0;
            char char_peakBlank = message[2];
            try
            {
                peakBlank = char_peakBlank - ' ';
            }
            catch
            {
                MessageBox.Show("Unable to get or set Peak Blanking");
            }
            return peakBlank;
        }

        private string convertCharToHexStr(char charToConvert)
        {
            string signLockValue = "";
            byte[] SLbytes = BitConverter.GetBytes(charToConvert);
            signLockValue = BitConverter.ToString(SLbytes, 0, 1);
            return signLockValue;
        }
        //set Sign Lock
        private bool setSignLock(string message)
        {
            bool signLock = false;
            char char_SL = message[3];
            string str_HexValue = convertCharToHexStr(char_SL);
            if (str_HexValue[str_HexValue.Length - 1] == '8')
                signLock = true;

            return signLock;
        }
        string ADflag_binary = "";
        //set values for currUnitClass
        private void setCap(string message)
        {
            int unitClassChar_pos = 5;//the char possition that determine Unit Class from message passed in should be 5, change this if there is any change in Mserial
            message = message.Trim();
            char ADflag = message[unitClassChar_pos];

            ADflag_binary = Convert.ToString(ADflag, 2).PadLeft(8, '0');//convert the char to binary and parse to string (fill the left with 0 if the binary is shorter than 8)
            ADflag_binary = ADflag_binary.Substring(4, 2);
            switch (ADflag_binary)
            {
                case "00":
                    currUnitClass = "Torque";
                    break;
                case "01":
                    currUnitClass = "Force";
                    break;
                case "10":
                    currUnitClass = "Pressure";
                    break;
                default:
                    currUnitClass = "";
                    break;
            }
        }
        //Pass in message return from sending ?M;, return the current mode of the tester
        private int setMode(string message)
        {
            int mode = -1;
            if (message != "")
            {
                char modeChr = message[0];
                Int32.TryParse(modeChr.ToString(), out mode);
            }
            return mode;
        }

        //set value for AC
        private int setAC(string message)
        {
            int AC = -1;
            char ACchar = message[1];
            Int32.TryParse(ACchar.ToString(), out AC);
            return AC;
        }


    }
}
