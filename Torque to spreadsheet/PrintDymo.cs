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
    public partial class PrintDymo : Form
    {
        private string PrtName;
        private string ObjName;
        private DymoAddInClass DymoAddIn = new DymoAddInClass();
        private DymoLabelsClass DymoLabels = new DymoLabelsClass();
        bool readyToPrint = true;
        public PrintDymo(string strToPrint)
        {
            InitializeComponent();
            StrToPrint_txtBox.Text = strToPrint;

            ObjName = SetupLabelObject();
            PrtName = SetupLabelWriterSelection(true);

        }

        private string SetupLabelObject()
        {
            // clear edit control
            //ObjectDataEdit.Clear();
            string ObjName = "";
            // get the objects on the label
            string ObjNames = DymoLabels.GetObjectNames(true);
            List<string> ObjectNameCmb = new List<string>();
            // parse the result
            if (ObjNames != null)
            {
                int i = ObjNames.IndexOf('|');
                while (i >= 0)
                {
                    ObjectNameCmb.Add(ObjNames.Substring(0, i));
                    ObjNames = ObjNames.Remove(0, i + 1);
                    i = ObjNames.IndexOf('|');
                }
                if (ObjNames.Length > 0)
                    ObjectNameCmb.Add(ObjNames);
            }
            if (ObjectNameCmb.Count > 0)
                ObjName = ObjectNameCmb[0];
            else
            {
                MessageBox.Show("Dymo Printer is not installed. Please visit Dymo website to download Dymo Label Software!");
                readyToPrint = false;
            }
            return ObjName;
        }

        private string SetupLabelWriterSelection(bool InitCmb)
        {
            string PrinterName = "";
            // get the objects on the label
            if (InitCmb)
            {
                List<string> LabelWriterCmb = new List<string>();

                string PrtNames = DymoAddIn.GetDymoPrinters();

                if (PrtNames != null)
                {
                    // parse the result
                    int i = PrtNames.IndexOf('|');
                    while (i >= 0)
                    {
                        LabelWriterCmb.Add(PrtNames.Substring(0, i));
                        PrtNames = PrtNames.Remove(0, i + 1);
                        i = PrtNames.IndexOf('|');
                    }
                    if (PrtNames.Length > 0)
                        LabelWriterCmb.Add(PrtNames);

                    PrtNames = DymoAddIn.GetCurrentPrinterName();
                    if (LabelWriterCmb.Count > 0)
                        PrinterName = LabelWriterCmb[0];
                }

            }
            if (DymoAddIn.IsPrinterOnline(PrinterName)==false)
            {
                MessageBox.Show("No Dymo Label Printer is detected.");
                readyToPrint = false;
            }
            return PrinterName;
        }

        public void printLabel(string strToPrint)
        {
            if ((PrtName != "") && (ObjName != ""))
            {
                DymoLabels.SetField(ObjName, strToPrint);
                // ATTENTION: This call is very important if you're making mutiple calls to the Print() or Print2() function!
                // It's a good idea to always wrap StartPrintJob() and EndPrintJob() around a call to Print() or Print2() function.
                DymoAddIn.StartPrintJob();

                // print two copies
                DymoAddIn.Print2(1, false, DymoAddIn.GetCurrentPaperTray());

                // ATTENTION: Every StartPrintJob() must have a matching EndPrintJob()
                DymoAddIn.EndPrintJob();
            }
        }
        public void releaseDymo()
        {
            // clean up DYMO COM objects
            DymoAddIn = null;
            DymoLabels = null;
        }
        private void print_btn_Click(object sender, EventArgs e)
        {
            printLabel(StrToPrint_txtBox.Text);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            releaseDymo();
            this.Close();
        }

        private void refreshPrinter_btn_Click(object sender, EventArgs e)
        {
            readyToPrint = true;
            ObjName = SetupLabelObject();
            PrtName = SetupLabelWriterSelection(true);

            if (readyToPrint==true)
            {
                MessageBox.Show("Dymo Printer found. Ready to print");
            }
        }
    }
}
