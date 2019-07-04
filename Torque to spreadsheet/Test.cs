using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dymo;

namespace WindowsFormsApplication1
{
    public partial class Test : Form
    {
        public DymoAddInClass DymoAddIn=new DymoAddInClass();
        public DymoLabelsClass DymoLabels= new DymoLabelsClass();
        public Test(string strToPrint)
        {
            InitializeComponent();
            ObjectDataEdit.Text = strToPrint;
        }

        private void Test_Load(object sender, EventArgs e)
        {

            // show the file name
            FileNameEdit.Text = DymoAddIn.FileName;

            // populate label objects
            SetupLabelObject();

            // obtain the currently selected printer
            SetupLabelWriterSelection(true);
        }
        private void SetupLabelObject()
        {
            // clear edit control
            //ObjectDataEdit.Clear();

            // clear all items first
            ObjectNameCmb.Items.Clear();

            // get the objects on the label
            string ObjNames = DymoLabels.GetObjectNames(true);

            // parse the result
            if (ObjNames != null)
            {
                int i = ObjNames.IndexOf('|');
                while (i >= 0)
                {
                    ObjectNameCmb.Items.Add(ObjNames.Substring(0, i));
                    ObjNames = ObjNames.Remove(0, i + 1);
                    i = ObjNames.IndexOf('|');
                }
                if (ObjNames.Length > 0)
                    ObjectNameCmb.Items.Add(ObjNames);

                ObjectNameCmb.SelectedIndex = 0;
            }
        }
        private void SetupLabelWriterSelection(bool InitCmb)
        {
            // get the objects on the label
            if (InitCmb)
            {
                // clear all items first
                LabelWriterCmb.Items.Clear();

                string PrtNames = DymoAddIn.GetDymoPrinters();

                if (PrtNames != null)
                {
                    // parse the result
                    int i = PrtNames.IndexOf('|');
                    while (i >= 0)
                    {
                        LabelWriterCmb.Items.Add(PrtNames.Substring(0, i));
                        PrtNames = PrtNames.Remove(0, i + 1);
                        i = PrtNames.IndexOf('|');
                    }
                    if (PrtNames.Length > 0)
                        LabelWriterCmb.Items.Add(PrtNames);

                    PrtNames = DymoAddIn.GetCurrentPrinterName();
                    if (PrtNames != null)
                        LabelWriterCmb.SelectedIndex = LabelWriterCmb.Items.IndexOf(PrtNames);
                    else
                        LabelWriterCmb.SelectedIndex = 0;
                }
            }

            // check if selected/current printer is a twin turbo printer
            TrayCmb.Enabled = DymoAddIn.IsTwinTurboPrinter(LabelWriterCmb.Text);
            if (TrayCmb.Enabled)
            {
                // show the current tray selection if the printer
                // is a twin turbo
                switch (DymoAddIn.GetCurrentPaperTray())
                {
                    case 0: // left tray
                        TrayCmb.SelectedIndex = 0;
                        break;

                    case 1: // right tray
                        TrayCmb.SelectedIndex = 1;
                        break;

                    case 2: // auto switch
                        TrayCmb.SelectedIndex = 2;
                        break;

                    default: // tray selection not set, so default to auto switch
                        TrayCmb.SelectedIndex = 2;
                        break;
                }
            }
        }

        private void PrintLabelBtn_Click(object sender, EventArgs e)
        {
            DymoLabels.SetField(ObjectNameCmb.Text, ObjectDataEdit.Text);
            // ATTENTION: This call is very important if you're making mutiple calls to the Print() or Print2() function!
            // It's a good idea to always wrap StartPrintJob() and EndPrintJob() around a call to Print() or Print2() function.
            DymoAddIn.StartPrintJob();

            // print two copies
            DymoAddIn.Print2(1, false, TrayCmb.SelectedIndex);

            // ATTENTION: Every StartPrintJob() must have a matching EndPrintJob()
            DymoAddIn.EndPrintJob();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ObjectDataEdit_Leave(object sender, System.EventArgs e)
        {
            DymoLabels.SetField(ObjectNameCmb.Text, ObjectDataEdit.Text);
        } 
    }
}
