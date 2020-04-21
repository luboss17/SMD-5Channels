using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form_TestSequence_DEMO : Form
    {
        public string[] arr_testPointList=new string[] {"Custom","3 points: 20%, 60%, 100%", "5 equal points" , "5 points and 10%" , "5 points, 10% and 5%", "10 equal points", "10 points and 5%", "20 equal points"};
        private string[] arr_mode=new string[] {"Track","Peak","First Peak"};
        private string[] arr_freq=new string[] {"7 Hz", "125 Hz", "250 Hz","500 Hz","1000 Hz", "1500 Hz", "2000 Hz"};
        private string[] arr_unit = new string[] { "INOZ", "INLB", "FTLB", "Nm", "cNm", "gfcm", "Kgfcm", "Kgfm", "BAR", "PSI", "kPSI", "kpa" };
        private string[] arr_percentOrUnit = new string[] {"%", "Unit","Manual Enter"};
        private BindingSource testBindingSource=new BindingSource(), unitBindingSource=new BindingSource(),modeBindingSource=new BindingSource(),freqBindingSource=new BindingSource(),highLowBindingSource=new BindingSource();
        private int rowIndexFromMouseDown;
        private DataGridViewRow rw;
        public bool isTestSave = false;
        public Form_TestSequence_DEMO()
        {
            InitializeComponent();
        }

        private void Form_TestSequence_Load(object sender, EventArgs e)
        {
            InitFormSetting();
        }

        private void InitFormSetting()
        {
            bindTestPointList();
            bindUnitList();
            bindModeList();
            bindFreqList();
            bindHighLowUnit();
            initTestType_comboBox();
            enableAddPoint();
            disableItems();
            initPointGrid();
        }
/////////////////////////////Start Methods for setting initial behaivor when Form_testSequence first load
        private void initPointGrid()
        {
            pointGrid.Columns.Add("point","Point #");
            pointGrid.Columns.Add("sample", "Samples per Point");
            pointGrid.Columns.Add("target", "Target");
            pointGrid.Columns.Add("low", "Low Limit");
            pointGrid.Columns.Add("high", "High Limit");
            
            //Add Delete column with button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            pointGrid.Columns.Add(btn);
            btn.HeaderText = "Delete Row";
            btn.Text = "Delete";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
        }
////////////////////////////Handle Drag Drop for pointGrid
        private void pointGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (pointGrid.SelectedRows.Count == 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rw = pointGrid.SelectedRows[0];
                    rowIndexFromMouseDown = pointGrid.SelectedRows[0].Index;
                    pointGrid.DoDragDrop(rw, DragDropEffects.Move);
                }
            }
        }
        private void pointGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (pointGrid.SelectedRows.Count > 0)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void reorderFirstColumn(ref DataGridView grid)
        {
            for (int index = 0; index < grid.RowCount - 1; index++)
            {
                grid.Rows[index].Cells[0].Value = index+1;
            }
        }
        private void pointGrid_DragDrop(object sender, DragEventArgs e)
        {

            int rowIndexOfItemUnderMouseToDrop;
            Point clientPoint = pointGrid.PointToClient(new Point(e.X, e.Y));
            rowIndexOfItemUnderMouseToDrop = pointGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if ((e.Effect == DragDropEffects.Move)&&(rowIndexOfItemUnderMouseToDrop>=0)&&(!pointGrid.Rows[rowIndexOfItemUnderMouseToDrop].IsNewRow))
            {
                pointGrid.Rows.RemoveAt(rowIndexFromMouseDown);
                pointGrid.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rw);
                //temporary disable this
                //reorderFirstColumn(ref pointGrid);
            }
        }
///End Handling Drag Drop for PointList
        private void disableItems()
        {
            saveTest_button.Enabled = false;
            channel2Settings_groupBox.Enabled = false;
        }
        private void initTestType_comboBox()
        {
            testType_comboBox.Items.Add("Single Channel Test");
            testType_comboBox.Items.Add("Dual Channel Test");
        }
        
        private void bindTestPointList()
        {
            testBindingSource.DataSource = arr_testPointList;
            testPoints_comboBox.DataSource = testBindingSource;
        }

        private void bindModeList()
        {
            modeBindingSource.DataSource = arr_mode;

            chan2Mode_comboBox.DataSource = modeBindingSource;
            chan1Mode_comboBox.DataSource = modeBindingSource;
        }

        private void bindFreqList()
        {
            freqBindingSource.DataSource = arr_freq;
            chan1Frequency_comboxBox.DataSource = freqBindingSource;
        }
        private void bindUnitList()
        {
            unitBindingSource.DataSource = arr_unit;

            chan2Unit_comboBox.DataSource = unitBindingSource;
            chan1Unit_comboBox.DataSource = unitBindingSource;
            
        }

        private void bindHighLowUnit()
        {
            highLowBindingSource.DataSource = arr_percentOrUnit;
            lowLimitUnit_comboBox.DataSource = highLowBindingSource;
            highLimitUnit_comboBox.DataSource = highLowBindingSource;
        }
        private void copyChan1Setting()
        {
            chan2Capacity_Text.Text = chan1Capacity_Text.Text;
            chan2Unit_comboBox.SelectedIndex = chan1Unit_comboBox.SelectedIndex;
            chan2Mode_comboBox.SelectedIndex = chan1Mode_comboBox.SelectedIndex;
        }
        private void testType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testType_comboBox.SelectedIndex == 1)
                channel2Settings_groupBox.Enabled = true;
            else
            {
                channel2Settings_groupBox.Enabled = false;
            }
        }

        private void copyChan1Settings_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            copyChan1Setting();
            chan2Capacity_Text.Enabled = false;
            chan2Unit_comboBox.Enabled = false;
            chan2Mode_comboBox.Enabled = false;
        }

        private void customPoint_Text_TextChanged(object sender, EventArgs e)
        {
            enableAddPoint();
        }

        private void FS_text_TextChanged(object sender, EventArgs e)
        {
            enableAddPoint();
        }

        private void lowLimit_Text_TextChanged(object sender, EventArgs e)
        {
            enableAddPoint();
        }

        private void lowLimitUnit_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableAddPoint();
            int itemsCount = arr_percentOrUnit.Length-1;
            if (lowLimitUnit_comboBox.SelectedIndex == itemsCount)
                lowLimit_Text.Enabled = false;
            else
            {
                lowLimit_Text.Enabled = true;
            }
        }

        private void highLimit_Text_TextChanged(object sender, EventArgs e)
        {
            enableAddPoint();
        }

        private void highLimitUnit_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableAddPoint();
            int itemsCount = arr_percentOrUnit.Length-1;
            if (highLimitUnit_comboBox.SelectedIndex == itemsCount)
                highLimit_Text.Enabled = false;
            else
            {
                highLimit_Text.Enabled = true;
            }
        }

        private void samples_text_TextChanged(object sender, EventArgs e)
        {
            enableAddPoint();
        }
        private void testPoints_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testPoints_comboBox.SelectedIndex == 0)
            {
                customPoint_Text.Enabled = true;
                FSTarget_label.Text = "Target *";
            }
            else
            {
                customPoint_Text.Enabled = false;
                FSTarget_label.Text = "Full Scale *";
            }
            enableAddPoint();
        }
////////////////////////////End Methods setting Form behaviors
        private void enableAddPoint()
        {
            if ((FS_text.Text != "") && (lowLimit_Text.Text != "") && (lowLimitUnit_comboBox.SelectedIndex >= 0) &&
                (highLimit_Text.Text != "") && (highLimitUnit_comboBox.SelectedIndex >= 0) && (samples_text.Text != ""))
            {
                if (testPoints_comboBox.SelectedIndex == 0)
                {
                    if (customPoint_Text.Text != "")
                        addPoint_button.Enabled = true;
                    else
                    {
                        addPoint_button.Enabled = false;
                    }
                }
                else
                {
                    addPoint_button.Enabled = true;
                }
            }
        }
        private void pointGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == (pointGrid.ColumnCount-1)) && (e.RowIndex<pointGrid.RowCount-1))
            {
                pointGrid.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isTestSave = false;
            Close();
        }

        private void chan1Capacity_Text_TextChanged(object sender, EventArgs e)
        {
            if (copyChan1Settings_checkBox.Checked)
                copyChan1Setting();
        }

        private void chan1Unit_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (copyChan1Settings_checkBox.Checked)
                copyChan1Setting();
        }

        public int testType = 0;//Single or Dual Channel Test

        public string toolName = "",
            SN = "",
            calDate = "",
            model = "",
            asset = "",
            dueDate = "",
            manufacture = "",
            capacity = "",
            unit = "",
            mode = "",
            frequency = "",
            chan1Capacity = "",
            chan2Capacity = "",
            chan1Unit = "",
            chan2Unit = "";
        System.Data.DataTable testSequenceTable=new DataTable();

        //Todo: Create variables to Save actually Test Sequence (how many points and such)
        private void setHeadersValue()
        {
            /* these values will be moved to Run Screen
            toolName = toolName_text.Text;
            SN = serial_text.Text;
            calDate = calDate_text.Text;
            model = model_text.Text;
            testType = testType_comboBox.SelectedIndex + 1;
            asset = asset_text.Text;
            dueDate = dueDate_text.Text;
            manufacture = manufacture_text.Text;
            */

            //get channels capacity and units
            chan1Capacity = chan1Capacity_Text.Text;
            chan1Unit = chan1Unit_comboBox.Items[chan1Unit_comboBox.SelectedIndex].ToString();
            if (testType == 1)//Single Channel Test
            {
                capacity = chan1Capacity + " " + chan1Unit;
            }
            else if (testType == 2) //Dual Channel Test
            {
                chan2Capacity = chan2Capacity_Text.Text;
                chan2Unit = chan2Unit_comboBox.Items[chan2Unit_comboBox.SelectedIndex].ToString();
                capacity = chan1Capacity + " " + chan1Unit +" at " + chan2Capacity + " " +chan2Unit;
            }
            
            //Todo: This may not belong here since it saves to Table, not set headers
            savepointGridToTable(ref testSequenceTable);//Save the test sequence to testSequenceTable
        }
        
        //save pointGrid to passed in Datatable
        //Can only save pointGrid because this method ignore last column of Gridview (Last column is delete button)
        private void savepointGridToTable(ref DataTable thisTable)
        {
            thisTable = new DataTable();
            //Create empty column for thisTable
            for (int i = 0; i < pointGrid.Columns.Count; i++)
            {
                thisTable.Columns.Add(pointGrid.Columns[i].Name);
            }

            //Copy datas from each row into thisTable
            foreach (DataGridViewRow gridRow in pointGrid.Rows)
            {
                DataRow tableRow = thisTable.NewRow();
                for (int j = 0; j < pointGrid.Columns.Count; j++)
                {
                    tableRow[pointGrid.Columns[j].Name] = gridRow.Cells[j].Value;
                }

                thisTable.Rows.Add(tableRow);
            }
        }

        private void saveTest_button_Click(object sender, EventArgs e)
        {
            isTestSave = true;
            setHeadersValue();//Set Detail of the test headers 

            this.Close();
        }

        private void chan1Mode_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (copyChan1Settings_checkBox.Checked)
                copyChan1Setting();
        }

        private void clearTestSetUp()
        {
            testPoints_comboBox.SelectedIndex = -1;
            customPoint_Text.Text = "";
            FS_text.Text = "";
            lowLimit_Text.Text = "";
            lowLimitUnit_comboBox.SelectedIndex = 0;
            highLimit_Text.Text = "";
            highLimitUnit_comboBox.SelectedIndex = 0;
            samples_text.Text = "1";
        }
        private void clearFields_button_Click(object sender, EventArgs e)
        {
            clearTestSetUp();
        }
        private void addPoint_button_Click(object sender, EventArgs e)
        {
            //Add points to PointGrid
            pointGrid.Rows.Add(1, 3, 20, 18, 22);
            pointGrid.Rows.Add(2, 3, 40, 38, 42);
            pointGrid.Rows.Add(3, 3, 60, 58, 62);
            pointGrid.Rows.Add(4, 3, 80, 78, 82);
            pointGrid.Rows.Add(5, 3, 100, 98, 102);
        }
    }
}
