using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form_PointSaveCount : Form
    {
        private int maxPoints=0;
        public int returnPointsToSave=0;
        public Form_PointSaveCount(int maxPoints)
        {
            InitializeComponent();
            this.maxPoints = maxPoints;
            returnPointsToSave = maxPoints;
            pointCount_txt.Enabled = false;
        }

        private void saveCloseBtn_Click(object sender, EventArgs e)
        {
            bool okToClose = true;
            if (saveALL_radioBtn.Checked==true)
            {
                returnPointsToSave = maxPoints;
            }
            else if (savePoint_radioBtn.Checked==true)
            {
                int userVal;
                if (int.TryParse(pointCount_txt.Text, out userVal))
                {
                    if (userVal > maxPoints)
                        userVal = maxPoints;
                    returnPointsToSave = userVal;
                }
                else
                { 
                    MessageBox.Show("Invalid Number was Input");
                    okToClose = false;
                }
            }
            if (okToClose == true)
                this.Close();
        }

        private void saveALL_radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            pointCount_txt.Enabled = false;
            returnPointsToSave = maxPoints;
        }

        private void savePoint_radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            pointCount_txt.Enabled = true;
            
        }
    }
}
