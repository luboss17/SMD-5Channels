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
    public partial class Form_Delete : Form
    {
        public string deleteColumn = "";
        public Form_Delete()
        {
            InitializeComponent();
            
        }
        
        private void runNameList_Init(DataTable table)
        {
            delete_button.Enabled = false;
            runNameList.Items.Clear();
            int count = 0;
            foreach (DataColumn column in table.Columns)
            {
                if ((count > 0) && (count<(table.Columns.Count-1)))
                    runNameList.Items.Add(column.ColumnName);
                count++;
            }
        }
        private void Form_Delete_Load(object sender, EventArgs e)
        {
            runNameList_Init(Form1.singleTable);
        }

        private void runNameList_SelectedIndexChanged(object sender, EventArgs e)
        {
            const int minIndex = 0;
            if (runNameList.SelectedIndex >= minIndex)
                delete_button.Enabled = true;
            else
            {
                delete_button.Enabled = false;
            }
        }
        private void submit()
        {
            deleteColumn = runNameList.SelectedItem.ToString();
            Close();
        }
        private void delete_button_Click(object sender, EventArgs e)
        {
            submit();
        }
        private void cancel()
        {
            deleteColumn = "";
            Close();
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            cancel();
        }
    }
}
