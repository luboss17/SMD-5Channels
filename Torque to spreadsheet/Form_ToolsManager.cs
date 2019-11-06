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
    public partial class Form_ToolsManager : Form
    {
        public Client pack;
        private DataTable toolsTable;
        private DataTable modelsTable;
        DataTable toolsModelsTable;
        BindingList<string> bindingListToShow = new BindingList<string>();
        public List<TestSetup> testSetups;
        DataTable toolCondTable;
        private const string toolText = "Tool", modelText = "Model";
        private string[] toolSearchSubject_showUser = new string[] { "Tool ID", "Serial Number", "Model", "Equipment", "Manufacture", "Lot ID", "Test ID" };
        private string[] toolSearchSubject_matchTable;
        string[] testIDStr_arr;//contains list of testID
        public Form_ToolsManager(Client passedinPack, List<TestSetup> testSetups)
        {
            //Todo: return pack and testSetups back to Form1 after done w this form
            InitializeComponent();
            pack = passedinPack;
            this.testSetups = testSetups;
            getToolsModelTable(pack);
            toolCondTable = toolsTable.Clone();//default toolcondtable to Tools table first
            if (toolCondTable.Rows.Count == 0)
                toolCondTable.Rows.Add();

            //assign list of testID
            getTestIDList();
            toolsModel_comboBox.SelectedIndex = 0;
            //Show the search subject to user
            searchSubject_comboBox.DataSource = toolSearchSubject_showUser;

            //Assign colName of tool field(follow same order as toolSearchSubject_showUser)
            toolSearchSubject_matchTable = new string[] { pack.toolID_colName, pack.SN_colName, pack.model_colName, pack.equipment_colName, pack.manufacturer_colName, pack.lotID_colName, pack.testID_colName };


            TestSequenceManager_form();
            showHideTest_btn.Text = "Show Test";
            testSetupGroupBox.Visible = false;
            testPointGroupBox.Visible = false;
        }

        //Assign testIDStr_arr to testID_comboBox
        private void getTestIDList()
        {
            testIDStr_arr = Form1.get_listOfTestName(testSetups);
            testID_comboBox.Items.Clear();
            testID_comboBox.Items.Add("New");
            testID_comboBox.Items.AddRange(testIDStr_arr);
        }

        //Fill in toolsTable and modelsTable
        //changed 10/6/17
        private void getToolsModelTable(Client pack)
        {
            pack.obj = "tools";
            pack.conditions = new DataTable();
            pack.sendCommand("find");

            //If result table has more than 1 row from find command then copy resultable to toolsModelsTable
            //if not, just clone tools table structure from Client
            if (pack.resultTable.Rows.Count > 0)
                toolsModelsTable = pack.resultTable.Copy();
            else
                toolsModelsTable = pack.tools.Clone(); //default to tools Table for now, since we are not supporting model table yet
            

            //Clone the structure of toolsTable and modelTable
            toolsTable = toolsModelsTable.Clone();
            modelsTable = toolsModelsTable.Clone();

            updateToolsModelTable(toolsModelsTable);//separate tools and models to 2 tables

        }
        //update toolsTable and modelsTable
        private void updateToolsModelTable(DataTable toolsAndModelTable)
        {
            foreach (DataRow tableRow in toolsAndModelTable.Rows)
            {
                //if toolID is null, copy to Model table
                if (tableRow[pack.toolID_colName].ToString() == "")
                {
                    modelsTable.ImportRow(tableRow);
                }
                else
                    toolsTable.ImportRow(tableRow);

            }
        }
        //Return BindingList<string> that contains list of toolID
        private BindingList<string> getToolsList(DataTable thisTable, string colName)
        {
            BindingList<string> returnToolsList = new BindingList<string>();
            try
            {
                //Assign whole column of data into returnToolsList
                returnToolsList = new BindingList<string>(thisTable.Rows.OfType<DataRow>().Select(dr => dr.Field<string>(colName)).ToList());

            }
            catch { MessageBox.Show("Unable to get list of Tools"); }

            return returnToolsList;
        }

        private void toolDelete_btn_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete selecting Tool?", "Delete Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                pack.toolIDToDelete = searchResult_listBox.SelectedItem.ToString();
                pack.obj = "tool";
                pack.sendCommand("delete");

                getToolsModelTable(pack);

                bindListTocomboBox();
            }
        }

        //bind bindingListToShow to toolsModel_combobox
        private void bindListTocomboBox()
        {
            int lastSelectIndex = searchResult_listBox.SelectedIndex;
            toolID_txt.Enabled = false;
            if (toolsModel_comboBox.Text == toolText)
            {
                bindingListToShow = getToolsList(toolsTable, pack.toolID_colName);
            }
            else if (toolsModel_comboBox.Text == modelText)
            {
                bindingListToShow = getToolsList(modelsTable, pack.model_colName);
            }
            searchResult_listBox.DataSource = bindingListToShow;
            try
            {
                searchResult_listBox.SelectedIndex = lastSelectIndex;
            }
            catch { }
        }
        private void toolsModel_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchField_txt.Text = "";
            bindListTocomboBox();
        }

        //Convert passedinInt to true(int=1) or false (any other value)
        private Boolean convertIntToBool(string passedInInt)
        {
            bool returnBool = false;
            if (passedInInt == "1")
                returnBool = true;

            return returnBool;
        }

        //convert false to 0, true to 1
        private int convertBoolToInt(Boolean boolValue)
        {
            int returnInt = 0;
            if (boolValue == true)
                returnInt = 1;
            return returnInt;
        }

        //passed in value from mode_column in ToolTable, return the index that mode_comboBox need to select
        //0: Track
        //1: Peak
        //2: 1st Peak
        //3: Trough
        private int getModeIndexfromTable(string indexStr)
        {
            int modeIndex = -1;
            switch (indexStr)
            {
                case "0":
                    modeIndex = 0;
                    break;
                case "1":
                    modeIndex = 1;
                    break;
                case "2":
                    modeIndex = 2;
                    break;
                case "3":
                    modeIndex = 3;
                    break;
            }
            return modeIndex;
        }
        string currTestID = "";
        //load the tool that match the value from passed in table and colName.
        //use offset in case there are more than 1 values in table column that match the IDtoCompare
        private void loadToolorModel(DataTable thisTable, string colName, string IDtoCompare, int offset)
        {
            currTestID = "";
            foreach (DataRow tableRow in thisTable.Rows)
            {
                if (tableRow[colName].ToString() == IDtoCompare)
                {
                    if (offset <= 0)
                    {
                        toolID_txt.Text = tableRow[pack.toolID_colName].ToString();
                        model_txt.Text = tableRow[pack.model_colName].ToString();
                        equipment_txt.Text = tableRow[pack.equipment_colName].ToString();
                        manufacture_txt.Text = tableRow[pack.manufacturer_colName].ToString();
                        SN_txt.Text = tableRow[pack.SN_colName].ToString();
                        lotID_txt.Text = tableRow[pack.lotID_colName].ToString();
                        ch1Mode_comboBox.SelectedIndex = getModeIndexfromTable(tableRow[pack.mode_colName].ToString());
                        ch2Mode_comboBox.SelectedIndex = getModeIndexfromTable(tableRow[pack.imode_colName].ToString());
                        scanOperator_chk.Checked = convertIntToBool(tableRow[pack.scanOperator_colName].ToString());
                        scan1_chk.Checked = convertIntToBool(tableRow[pack.scan1_colName].ToString());
                        scan2_chk.Checked = convertIntToBool(tableRow[pack.scan2_colName].ToString());
                        pauseTool_chk.Checked = convertIntToBool(tableRow[pack.setupPause_colName].ToString());

                        //Assign the name of test associated with this tool or model
                        currTestID = tableRow[pack.testID_colName].ToString();

                        //import this toolRow into toolCondTable
                        toolCondTable = thisTable.Clone();
                        toolCondTable.ImportRow(tableRow);

                        break;
                    }
                    else
                        offset--;
                }
            }
        }
        //find the index of passed in testID and select that test
        private void loadTest(string testID)
        {
            int testIndex = Array.IndexOf(testIDStr_arr, testID);
            testID_comboBox.SelectedIndex = testIndex + 1;
        }

        //offset the index of the same selected text that occured before the selected index in searchResult_listbox
        private int offsetSameSearchName()
        {
            int offsetReturn = 0;
            int selectedIndex = searchResult_listBox.SelectedIndex;
            string selectedItem = searchResult_listBox.SelectedItem.ToString();
            for (int runningIndex = selectedIndex - 1; runningIndex >= 0; runningIndex--)
            {
                if (searchResult_listBox.Items[runningIndex].ToString() == selectedItem)
                {
                    offsetReturn++;
                }
            }

            return offsetReturn;
        }

        bool isChangeMade = false;//Determine whether a change has been made. If yes, make sure ask to save first
        private void tools_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string colName = "";
            if ((isChangeMade == false) && (searchResult_listBox.SelectedIndex >= 0))
            {
                if (toolsModel_comboBox.Text == toolText)
                {
                    colName = toolSearchSubject_matchTable[searchSubject_comboBox.SelectedIndex];
                    int offset = offsetSameSearchName();
                    loadToolorModel(toolsTable, colName, searchResult_listBox.SelectedItem.ToString(), offset);

                }//Right now model is not supported, so it won't ever go into this else
                else if (toolsModel_comboBox.Text == modelText)
                {
                    colName = pack.model_colName;
                    int offset = offsetSameSearchName();
                    loadToolorModel(modelsTable, colName, searchResult_listBox.SelectedItem.ToString(), offset);
                }

                //Todo: Load the test
                loadTest(currTestID);

            }
            else
            {
                //Todo: Implement case when the last Tool has not been saved yet. Should ask to save first before proceed

            }
        }

        //when user select new test, clear all fields
        private void newTestReset()
        {
            testType_comboBox.SelectedIndex = 0;
            maxPoint_txt.Text = "";
            FS_txt.Text = "";
            sampleNum_txt.Text = "1";
            lowLimit_txt.Text = "";
            highLimit_txt.Text = "";
            limitEngPercent_comboBox.SelectedIndex = 0;
        }
        //Trigger when new Tool/Model button is pressed
        //Clear all the tool field and test field
        private void newToolReset()
        {
            toolID_txt.Text = "";
            model_txt.Text = "";
            equipment_txt.Text = "";
            manufacture_txt.Text = "";
            SN_txt.Text = "";
            lotID_txt.Text = "";
            scanOperator_chk.Checked = false;
            scan1_chk.Checked = false;
            scan2_chk.Checked = false;
            pauseTool_chk.Checked = false;
            newTestReset();
        }
        //Load test 
        private void initCurrTestSetup(int testIndex)
        {
            TestSetup thisTestSetup = testSetups[testIndex];

            try
            {
                testType_comboBox.SelectedIndex = Int32.Parse(thisTestSetup.testType) - 1;
            }
            catch
            {
                testType_comboBox.SelectedIndex = 0;
            }
            FS_txt.Text = thisTestSetup.FullScale;
            lowLimit_txt.Text = thisTestSetup.low;
            highLimit_txt.Text = thisTestSetup.high;
            maxPoint_txt.Text = thisTestSetup.pointAmount;

        }

        private void testID_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testID_comboBox.SelectedIndex > 0) //User select 1 of the saved Test
            {
                int testIndex = testID_comboBox.SelectedIndex - 1;
                initCurrTestSetup(testIndex);

            }
            else if (testID_comboBox.SelectedIndex == 0) //New Test is selected
            {
                newTestReset();
            }
        }

        /// <summary>
        /// Update or insert new tool, passed in toolID and modelID(if toolID is empty, meaning save as new model) and command("update" or "insert")
        /// </summary>
        /// <param name="toolID">if null that means save as model</param>
        /// <param name="modelID"></param>
        /// <param name="command">either "insert" or "update"</param>
        private void updateOrInsertTool(string toolID, string modelID, string command)
        {
            try
            {
                //Save all the fields into toolCondTable
                toolCondTable.Rows[0][pack.toolID_colName] = toolID;
                toolCondTable.Rows[0][pack.model_colName] = modelID;
                toolCondTable.Rows[0][pack.equipment_colName] = equipment_txt.Text;
                toolCondTable.Rows[0][pack.manufacturer_colName] = manufacture_txt.Text;
                toolCondTable.Rows[0][pack.SN_colName] = SN_txt.Text;
                toolCondTable.Rows[0][pack.lotID_colName] = lotID_txt.Text;
                toolCondTable.Rows[0][pack.scanOperator_colName] = convertBoolToInt(scanOperator_chk.Checked);
                toolCondTable.Rows[0][pack.scan1_colName] = convertBoolToInt(scan1_chk.Checked);
                toolCondTable.Rows[0][pack.scan2_colName] = convertBoolToInt(scan2_chk.Checked);
                toolCondTable.Rows[0][pack.setupPause_colName] = convertBoolToInt(pauseTool_chk.Checked);
                toolCondTable.Rows[0][pack.testID_colName] = testID_comboBox.Text;
                toolCondTable.Rows[0][pack.mode_colName] = ch1Mode_comboBox.SelectedIndex;
                toolCondTable.Rows[0][pack.imode_colName] = ch2Mode_comboBox.SelectedIndex;
                pack.obj = "tool";
                pack.conditions = toolCondTable.Copy();
                pack.sendCommand(command);

                //Todo: update ToolList again, call getToolModelTable
                getToolsModelTable(pack);

                bindListTocomboBox();
                //assign list of testID
                getTestIDList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save this Tool due to error: " + e.Message, "Error");
            }
        }

        private void saveTool_btn_Click(object sender, EventArgs e)
        {
            if (toolsModel_comboBox.Text == toolText)
            {
                if (searchResult_listBox.SelectedIndex >= 0)
                {
                    if (toolID_txt.Text != "")
                        updateOrInsertTool(toolID_txt.Text, model_txt.Text, "update");
                }
                else//Save as new
                {
                    string toolID = toolID_txt.Text;
                    string model = model_txt.Text;
                    updateOrInsertTool(toolID, model, "insert");
                }
            }
        }

        private void saveAsTool_btn_Click(object sender, EventArgs e)
        {
            newTool_frm newToolForm = new newTool_frm(getToolsList(toolsTable, pack.toolID_colName), getToolsList(modelsTable, pack.model_colName));
            newToolForm.ShowDialog();
            string toolID = "", modelID = "";
            if (newToolForm.nameArr[1] != "")
            {//if name is not empty, save the current test under new toolID/model
                if (newToolForm.nameArr[0] == newTool_frm.toolText)//Save Tool
                {
                    toolID = newToolForm.nameArr[1];
                    modelID = model_txt.Text;
                }
                else if (newToolForm.nameArr[0] == newTool_frm.modelText)//Save Model
                {
                    modelID = newToolForm.nameArr[1];
                }
                updateOrInsertTool(toolID, modelID, "insert");
            }
        }

        private void newTool_btn_Click(object sender, EventArgs e)
        {
            newToolReset();
            searchResult_listBox.SelectedIndex = -1;
            if (toolsModel_comboBox.Text == toolText)
                toolID_txt.Enabled = true;
        }

        private void testManager_btn_Click(object sender, EventArgs e)
        {
            string prev_testID;
            if (testID_comboBox.SelectedIndex >= 0)
                prev_testID = testID_comboBox.SelectedItem.ToString();
            else
                prev_testID = testID_comboBox.Items[0].ToString();
            TestSequenceManager_form frm = new TestSequenceManager_form(testSetups);
            frm.ShowDialog();

            if (frm.isTestSetupSaved)
                testSetups = frm.testSetups;

            //reassign list of testID
            getTestIDList();

            //attempt to reselect the testID
            try
            {
                foreach (var testID_comboItem in testID_comboBox.Items)
                {
                    if (testID_comboItem.ToString() == prev_testID)
                        testID_comboBox.SelectedItem = testID_comboItem;
                }
            }
            catch
            {
                testID_comboBox.SelectedIndex = 0;
            }
        }

        private void searchSubject_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateToolSearchResult();
        }

        //update result when search field is changed
        private void updateToolSearchResult()
        {
            searchResult_listBox.SelectedIndex = -1;
            BindingList<string> oriList = new BindingList<string>();
            BindingList<string> listToShow = new BindingList<string>();
            /*Uncomment this part because temporarily not support model
            //Assign list of tool or model to oriList
            if (toolsModel_comboBox.Text == toolText)
            {
                oriList = getToolsList(toolsTable, pack.toolID_colName);
            }
            else if (toolsModel_comboBox.Text == modelText)
            {
                oriList = getToolsList(modelsTable, pack.model_colName);
            }
            */

            //assign original list of tool based on the search subject
            oriList = getToolsList(toolsTable, toolSearchSubject_matchTable[searchSubject_comboBox.SelectedIndex]);

            if (searchField_txt.Text != "")
            {
                //Search for the tool or model that match the search text only, then add to listToshow
                foreach (string itemFound in oriList)
                {
                    if (itemFound.Contains(searchField_txt.Text))
                        listToShow.Add(itemFound);
                }
            }
            else//if search is empty, show all the tool from oriList
            {
                listToShow = oriList;
            }

            //bind listToShow to tools_listbox
            searchResult_listBox.DataSource = listToShow;
        }


        private void ch1Mode_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if both ch1mode and ch2mode is trough. Change the other to track
            if ((ch1Mode_comboBox.SelectedIndex == 3) && (ch2Mode_comboBox.SelectedIndex == 3))
            {
                ch2Mode_comboBox.SelectedIndex = 0;         
            }
        }

        private void ch2Mode_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if both ch1mode and ch2mode is trough. Show notification
            if ((ch1Mode_comboBox.SelectedIndex == 3) && (ch2Mode_comboBox.SelectedIndex == 3))
            {
                ch1Mode_comboBox.SelectedIndex = 0;
            }
        }

        private void testType_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testType_comboBox.SelectedIndex==1)
            {//dual channel
                ch2Mode_comboBox.Visible = true;
                label9.Visible = true;
            }
            else
            {
                ch2Mode_comboBox.Visible = false;
                label9.Visible = false;
            }
        }

        

        private void toolSearch_txt_TextChanged(object sender, EventArgs e)
        {
            updateToolSearchResult();
        }

        private void saveTest_btn_Click(object sender, EventArgs e)
        {
            try
            {
                int currTestIndex = testSetups_listBox.SelectedIndex;
                testSetups[currTestIndex] = saveThisTest(testSetups[currTestIndex].defaultTest); //pass in TestSetup into TestSetups[currTestIndex]
                currTestSetup = testSetups[currTestIndex]; //update the currTestSetup

                MessageBox.Show("Test successfully saved");
                isTestSetupSaved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save due to error:\n\n" + ex.Message);
            }
        }

        //Added 8/9/19 to merge Test Manager
        /******************START ADDING TEST MANAGER CODE************************************/
        private void showHideTest_btn_Click(object sender, EventArgs e)
        {
            if ((testSetupGroupBox.Visible == true) && (testPointGroupBox.Visible == true))
            {
                showHideTest_btn.Text = "Show Test";
                testSetupGroupBox.Visible = false;
                testPointGroupBox.Visible = false;
            }
            else
            {
                showHideTest_btn.Text = "Hide Test";
                testSetupGroupBox.Visible = true;
                testPointGroupBox.Visible = true;
            }
        }

        private List<string> default_testList = new List<string>();
        private BindingList<string> testList_toShow = new BindingList<string>();
        public List<int> return_IndexList = new List<int>();

        public void TestSequenceManager_form()
        {
            initTestGridView(ref AFCW_grid);
            initTestGridView(ref AFCCW_grid);
            initTestGridView(ref ALCW_grid);
            initTestGridView(ref ALCCW_grid);

            saveClose_btn.Text = "Save && Close";

            //create default_testList, these testID can't be deleted
            default_testList = getDefaultTestList(testSetups);

            //Add Event Handler for listbox drag and drop
            this.testOrder_list.MouseDown += this.testOrder_list_MouseDown;
            this.testOrder_list.DragOver += this.testOrder_list_DragOver;
            this.testOrder_list.DragDrop += this.testOrder_list_DragDrop;

            //Add Event Handler when user change grid Data
            AFCW_grid.CellValueChanged += AFCW_grid_CellValueChanged;
            AFCCW_grid.CellValueChanged += AFCCW_grid_CellValueChanged;
            ALCW_grid.CellValueChanged += ALCW_grid_CellValueChanged;
            ALCCW_grid.CellValueChanged += ALCCW_grid_CellValueChanged;
            update_testSetups_listbox();
        }
        //create and return list of all testID that are default Test-Can not be deleted
        private List<string> getDefaultTestList(List<TestSetup> testSetups)
        {
            List<string> defaultTestID = new List<string>();
            foreach (TestSetup test in testSetups)
            {
                if (test.testID.Contains("**") && test.defaultTest == "yes")
                {
                    defaultTestID.Add(test.testID);
                }
            }
            return defaultTestID;
        }
        private void ALCCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateTestTableWhenUserChangeGrid(ref ALCCW_grid, e.ColumnIndex, e.RowIndex);
        }

        private void ALCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateTestTableWhenUserChangeGrid(ref ALCW_grid, e.ColumnIndex, e.RowIndex);
        }

        private void AFCCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateTestTableWhenUserChangeGrid(ref AFCCW_grid, e.ColumnIndex, e.RowIndex);
        }

        private void AFCW_grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateTestTableWhenUserChangeGrid(ref AFCW_grid, e.ColumnIndex, e.RowIndex);
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
        private int dragIndex = -1, dropIndex = -1;
        private void testOrder_list_DragDrop(object sender, DragEventArgs e)
        {
            Point point = testOrder_list.PointToClient(new Point(e.X, e.Y));
            int index = this.testOrder_list.IndexFromPoint(point);
            if (index < 0) index = this.testOrder_list.Items.Count - 1;

            dropIndex = index;
            string tempStr = testOrder_list.Items[dragIndex].ToString();
            testOrder_list.Items.RemoveAt(dragIndex);
            testOrder_list.Items.Insert(dropIndex, tempStr);
            testOrder_list.SelectedIndex = dropIndex;//focus on the dropped index
        }

        private void switchtestSetup_Index(List<TestSetup> testSetups, int index1, int index2)
        {
            var item1 = testSetups[index1];
            var item2 = testSetups[index2];
            testSetups[index1] = item2;
            testSetups[index2] = item1;
        }
        //assign list testID to testList_toShow and show on testSetups_listbox
        private void update_testSetups_listbox()
        {
            testList_toShow = gettestListFromTestsSetup(testSetups);
            testSetups_listBox.DataSource = testList_toShow;
        }
        //return list of testID from passed in List<TestSetup> testSetups
        private BindingList<string> gettestListFromTestsSetup(List<TestSetup> testSetups)
        {
            BindingList<string> testList = new BindingList<string>();
            foreach (TestSetup thisTest in testSetups)
            {
                testList.Add(thisTest.testID);
            }
            return testList;
        }
        //init TestGridview, set what it looks like and clear all datas
        private void initTestGridView(ref DataGridView thisGrid)
        {
            if (thisGrid.ColumnCount == 0)
            {
                thisGrid.Columns.Add("pointNum", "#");
                thisGrid.Columns.Add("ch1Reading", "Channel 1 Readings");
                thisGrid.Columns.Add("ch2Reading", "Channel 2 Readings");
                thisGrid.Columns.Add("low", "Low");
                thisGrid.Columns.Add("target", "Target");
                thisGrid.Columns.Add("high", "High");
            }
            PreventGridSort(ref thisGrid);
            thisGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            thisGrid.Columns[0].Width = 25;
            int colWidth = (thisGrid.Width - thisGrid.Columns[0].Width - 37) / 5;
            thisGrid.Columns[1].Width = colWidth;
            thisGrid.Columns[2].Width = colWidth;
            thisGrid.Columns[3].Width = colWidth;
            thisGrid.Columns[4].Width = colWidth;
            thisGrid.Columns[5].Width = colWidth;

            //Clear all Rows
            thisGrid.Rows.Clear();
        }
        //Prevent passed in gridview from being sortable by user
        private void PreventGridSort(ref DataGridView grid)
        {
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void switchItemfrList(ref List<string> list, int pos1, int pos2)
        {
            var tempItem = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = tempItem;
        }

        private void switchItemfrList(ref List<int> list, int pos1, int pos2)
        {
            var tempItem = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = tempItem;
        }

        private void down_btn_Click(object sender, EventArgs e)
        {
            int selectingIndex = testSetups_listBox.SelectedIndex;
            if (selectingIndex < testSetups_listBox.Items.Count - 1)
            {
                switchtestSetup_Index(testSetups, selectingIndex, selectingIndex + 1);
                update_testSetups_listbox();
                testSetups_listBox.SelectedIndex = selectingIndex + 1;
            }
        }

        private void up_btn_Click(object sender, EventArgs e)
        {
            int selectingIndex = testSetups_listBox.SelectedIndex;

            if (selectingIndex > 0)
            {
                switchtestSetup_Index(testSetups, selectingIndex, selectingIndex - 1);
                update_testSetups_listbox();
                testSetups_listBox.SelectedIndex = selectingIndex - 1;
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            int selectingIndex = testSetups_listBox.SelectedIndex;
            if (default_testList.Contains(testSetups_listBox.SelectedItem.ToString()))
            //User can't delete if it belongs to 1 of the default test
            {
                MessageBox.Show("Selecting Test is a default test, it can not be deleted");
            }
            else//Delete the selecting test if it is not default test
            {
                testSetups.RemoveAt(selectingIndex);
                update_testSetups_listbox();
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {

            testSetups_listBox.DataSource = null;
            testSetups_listBox.DataSource = testList_toShow;
        }
        TestSetup currTestSetup;
        private void loadTestSetup(int selectedIndex)
        {
            //Assign TestSetup from TestSetups Collection at passed in index
            //Also set the value of the test on screen
            TestSetup thisTestSetup = new TestSetup();
            thisTestSetup = testSetups[selectedIndex];

            //Show test Values on Screen
            testID_txt.Text = thisTestSetup.testID;
            FS_txt.Text = thisTestSetup.FullScale;
            lowLimit_txt.Text = thisTestSetup.low;
            highLimit_txt.Text = thisTestSetup.high;
            maxPoint_txt.Text = thisTestSetup.pointAmount;
            sampleNum_txt.Text = thisTestSetup.sampleNum;
            if (thisTestSetup.percent_unit == "Eng. Unit")
            {
                limitEngPercent_comboBox.SelectedIndex = 1;
            }
            else//if anything other than Unit, default it to %
                limitEngPercent_comboBox.SelectedIndex = 0;

            try
            {
                testType_comboBox.SelectedIndex = Int32.Parse(thisTestSetup.testType) - 1;
            }
            catch
            {
                testType_comboBox.SelectedIndex = 0;
            }

            //Assign currTestSetup so updateTestOrderChecked can use currTestSetup to write to testGrid
            currTestSetup = testSetups[selectedIndex];
            updateTestOrderChecked(thisTestSetup.testOrder);
            checkDefaultTestSelected(currTestSetup.defaultTest);//check if default test then not allow to change certain field

            /*Todo: Implement this later when user want to create new test
            else if (testSetup_comboBox.SelectedIndex == 0) //New Test is selected
            {
                newTestReset();

                saveStartTest_btn.Enabled = false;
                saveStartTest_btn.Text = "Save";
            }*/
        }

        private const string isDefaultTest = "yes";
        private const string notDefaultTest = "no";
        //Check if it is default test then not allow to change testID and maxpoint
        private void checkDefaultTestSelected(string defaultOrNotTest)
        {
            if (defaultOrNotTest == isDefaultTest)
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

        bool okToUpdateTestOrders = true;//if this is set to false, changing checkbox for testOrder will not repopulate testGrid

        //Pass in testOrderStr, change state of orderTest Checked and write to testGrid
        private void updateTestOrderChecked(string testOrderStr)
        {
            //Prevent changing checkbox will repopulate grid
            okToUpdateTestOrders = false;

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

            //Restore changing checkbox will populate testGrid
            okToUpdateTestOrders = true;

            showOnGrid();//After All checkboxs are gone through, write to testGrid

        }
        //Go through the list of checkbox, create List<str> of returnTestList
        private List<string> convertTestList_CheckToListStr()
        {
            List<string> returnTestList = new List<string>();
            if (AF_chkbox.Checked)
            {
                if (CW_chkbox.Checked)
                    returnTestList.Add(AFCW);
                if (CCW_chkbox.Checked)
                    returnTestList.Add(AFCCW);
            }
            if (AL_chkbox.Checked)
            {
                if (CW_chkbox.Checked)
                    returnTestList.Add(ALCW);
                if (CCW_chkbox.Checked)
                    returnTestList.Add(ALCCW);
            }
            return returnTestList;
        }
        //return BindingList string that contains the actual string of test order to show to user
        private List<string> testOrdersCreate(List<string> ori_List)
        {
            List<string> testList = new List<string>();
            testList = convertTestList_CheckToListStr();
            testList = compareOrderBindingList(ori_List, testList);
            return testList;
        }
        //compare oriList and newList, returnList has oriList order and all of newList Elements
        private List<string> compareOrderBindingList(List<string> oriList, List<string> newList)
        {
            if (oriList.Count == 0)
                return newList;
            else
            {
                List<string> returnList = new List<string>(), newList_copy = new List<string>();
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
        private void showOnGrid()
        {
            if (currTestSetup.testTable.Rows.Count > 0)
            {
                //Write the current test Order to testList
                List<string> testList = new List<string>();
                testList = testOrdersCreate(testList);

                //Show testOrder to User
                testOrder_list.Items.Clear();
                testOrder_list.Items.AddRange(testList.ToArray());

                updateTestGrid(currTestSetup.testTable, testList);
            }
        }
        //Return test order from passed in List-should be testList
        private string createTestOrderStr(List<string> thisList)
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
        private const string AFCW = "As Found-CW", AFCCW = "As Found-CCW", ALCW = "As Left-CW", ALCCW = "As Left-CCW";

        private void AF_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTestOrderWhenChecked();
        }


        private void AL_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTestOrderWhenChecked();
        }


        private void CW_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTestOrderWhenChecked();
        }

        private void CCW_chkbox_CheckedChanged(object sender, EventArgs e)
        {
            updateTestOrderWhenChecked();
        }

        //if oktoupdateTestorders:
        //create new List<string>testList based on new check
        //use testList to update testGrid
        private void updateTestOrderWhenChecked()
        {
            if (okToUpdateTestOrders)
            {
                List<string> testList = new List<string>();
                testList = testOrdersCreate(testList);

                //Show testOrder to User
                testOrder_list.Items.Clear();
                testOrder_list.Items.AddRange(testList.ToArray());

                updateTestGrid(currTestSetup.testTable, testList);
            }
        }
        private void resetCurrTestSettings_btn_Click(object sender, EventArgs e)
        {

        }
        
        //Return a testSetup with All current Setting on the screen
        private TestSetup saveThisTest(string isDefaultTest)
        {
            TestSetup returnSetup = new TestSetup();
            returnSetup.testID = testID_txt.Text;
            returnSetup.testType = (testType_comboBox.SelectedIndex + 1).ToString();
            returnSetup.FullScale = FS_txt.Text;
            returnSetup.low = lowLimit_txt.Text;
            returnSetup.high = highLimit_txt.Text;
            returnSetup.pointAmount = maxPoint_txt.Text;
            returnSetup.defaultTest = isDefaultTest;
            returnSetup.sampleNum = sampleNum_txt.Text;
            returnSetup.percent_unit = limitEngPercent_comboBox.SelectedItem.ToString();
            List<string> testList = convertTestList_CheckToListStr();
            returnSetup.testOrder = getTestOrderStr(testList);
            returnSetup.testTable = saveTestTable();

            return returnSetup;
        }
        //Return testOrder in term of Number, determined by passed in TestList
        private string getTestOrderStr(List<string> testList)
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
        private const int pointGridCol = 0,
            ch1ReadingGridCol = 1,
            ch2ReadingGridCol = 2,
            lowGridCol = 3,
            targetGridCol = 4,
            highGridCol = 5;

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
            List<string> testList = testOrdersCreate(new List<string>());
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
        private void newTest_btn_Click(object sender, EventArgs e)
        {
            getSaveAsTestSetupNameForm saveAsFrm = new getSaveAsTestSetupNameForm(testList_toShow.ToArray());
            saveAsFrm.ShowDialog();

            string returntestID = saveAsFrm.testName;
            try
            {
                if (returntestID != "")
                {
                    //Create temptest with only testID value, then add it to testSetups
                    TestSetup tempTest = new TestSetup();
                    tempTest.testID = returntestID;
                    tempTest.defaultTest = notDefaultTest;
                    currTestSetup = tempTest;
                    testSetups.Add(currTestSetup);

                    //refresh testSetups_listbox
                    update_testSetups_listbox();

                    AF_chkbox.Checked = false;
                    AL_chkbox.Checked = false;
                    CW_chkbox.Checked = false;
                    CCW_chkbox.Checked = false;

                    testSetups_listBox.SelectedIndex = testSetups_listBox.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save New Test due to error: \n" + ex.Message);
            }
        }


        private void saveAsTest_btn_Click(object sender, EventArgs e)
        {
            //if new testID is not null and not already in testList_toShow
            getSaveAsTestSetupNameForm saveAsFrm = new getSaveAsTestSetupNameForm(testList_toShow.ToArray());
            saveAsFrm.ShowDialog();

            string returntestID = saveAsFrm.testName;
            try
            {
                if (returntestID != "")
                {
                    testID_txt.Text = returntestID;
                    //add new test setup
                    testSetups.Add(saveThisTest(currTestSetup.defaultTest));
                    update_testSetups_listbox();
                }

                testSetups_listBox.SelectedIndex = testSetups.Count - 1;
                isTestSetupSaved = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Save New Test due to error: \n" + ex.Message);
            }
        }

        //Copy oriGrid with it's oriGridIndex to another grid with it's copiedGridIndex
        private DataGridView fillTestGrid(DataGridView oriGrid, int oriGridIndex, int returnGridIndex)
        {
            //initiate returnGrid
            DataGridView returnGrid = new DataGridView();
            initTestGridView(ref returnGrid);

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
        //Repopulate all the test Grid after a new test is selected
        private void updateTestGrid(DataTable thisTable, List<string> listOrder)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void testSetups_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTestSetup(testSetups_listBox.SelectedIndex);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public bool isTestSetupSaved = false;
        private void saveClose_btn_Click(object sender, EventArgs e)
        {
            isTestSetupSaved = true;
            this.Close();
        }

        private void updateTestTableWhenUserChangeGrid(ref DataGridView thisGrid, int colIndex, int rowIndex)
        {
            //if column is target call rewriteLowHigh_gridRow to rewrite low high for that row
            if (colIndex == targetGridCol)
            {
                rewriteLowHigh_gridRow(ref AFCW_grid, rowIndex);
            }

            //Save the changed made from grid to currTestSetUp testTable
            currTestSetup.testTable = updateTestTablewhenGridChanged(AFCW_grid, currTestSetup.testTable, 1);//Write testable the update testTable after a grid is changed

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

        private void maxPoint_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FSLowHighchanged();
            }
        }

        private void sampleNum_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FSLowHighchanged();
            }
        }
        private void FS_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FSLowHighchanged();
            }
        }
        private void lowLimit_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FSLowHighchanged();
            }
        }
        private void highLimit_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FSLowHighchanged();
            }
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
        //This method is called when user change either fullscale, low or high of currtestSetup, rewrite to test grid
        private void FSLowHighchanged()
        {
            bool proceed = false;

            // Check if all required fields to calculate testGrids are filled out
            string[] arrStr = new string[] { sampleNum_txt.Text, FS_txt.Text, lowLimit_txt.Text, highLimit_txt.Text };
            if (checkNoStrEmpty(arrStr) == true)
                proceed = true;

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


                //Write the current test Order to testList
                List<string> testList = new List<string>();
                testList = testOrdersCreate(testList);
                //Display to testGrid
                updateTestGrid(currTestSetup.testTable, testList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to read in user Input, please make sure value input is Float format");
            }
        }
        private int[] pointsBracket_arr = new int[] { 1, 2, 3, 5, 6, 7, 10, 11, 20 };
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

        //convert passed in float into certain Decimal Float
        private float convertToFloatwithDecimal(float oriFL, int decimalPlace)
        {
            float returnFl;
            returnFl = (float)Math.Round((double)oriFL, decimalPlace);
            return returnFl;
        }
    }
}
