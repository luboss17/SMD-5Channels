using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CertTestSequence
    {
        private readonly string newLine = Environment.NewLine;
        private string toolName, timeStamp, dueDate, reCall, temp, humid, equipment, model, manufacture, capacity, accuracy, testID,SN, certLot, procedure, units, operatorID,singleOrDual;

        private const string toolName_header = "Tool name",
            timeStamp_header = "Timestamp",
            dueDate_header = "Due Date",
            recall_header = "Recall",
            temp_header = "Temperature",
            humid_header = "Humidity",
            equipment_header = "Equipment",
            model_header = "Model",
            manufacture_header = "Manufacturer",
            capacity_header = "Capacity",
            accuracy_header = "Accuracy",
            testID_header = "Test ID",
            SN_header = "Output SN",
            certLot_header = "Cert Lot",
            procedure_header = "Procedure",
            units_header = "Units",
            operatorID_header = "Operator ID",
            singleOrDual_header = "Chan 2",
            CertManagerParentLoc= "C:\\Cert Manager";
            
        
        private System.Data.DataTable certTable=new System.Data.DataTable();
        private static readonly string[]dualTest_ColHeaders={"Sample #","Input","Output","N/A1","Target","N/A2","N/A3","Timestamp"},
            singleTest_ColHeaders= {"Sample #","Output","N/A","Low","Target","High","Result","Timestamp"};

        private List<string> targetList=new List<string>(),lowList=new List<string>(),highList=new List<string>(),input=new List<string>(),output=new List<string>();
        private const string inputColName = "Input", outputColName = "Output",targetColName="Target",sampleColName="Sample #",lowColName="Low",highColName="High",resultColName="Result",timeStampColName="Timestamp",sampleNumColName="Sample #";

//Get and Set all headers value
        public string get_toolName()
        {
            return toolName;
        }

        public void set_toolName(string toolName)
        {
            this.toolName = toolName;
        }

        public string get_timeStamp()
        {
            return timeStamp;
        }

        public void set_timeStamp(string timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public string get_dueDate()
        {
            return dueDate;
        }

        public void set_dueDate(string dueDate)
        {
            this.dueDate = dueDate;
        }

        public string get_reCall()
        {
            return reCall;
        }

        public void set_reCall(string reCall)
        {
            this.reCall = reCall;
        }

        public string get_temp()
        {
            return temp;
        }

        public void set_temp(string temp)
        {
            this.temp = temp;
        }

        public string get_humid()
        {
            return humid;
        }

        public void set_humid(string humid)
        {
            this.humid = humid;
        }

        public string get_equipment()
        {
            return equipment;
        }

        public void set_equipment(string equipment)
        {
            this.equipment = equipment;
        }

        public string get_model()
        {
            return model;
        }

        public void set_model(string model)
        {
            this.model = model;
        }

        public string get_manufacture()
        {
            return manufacture;
        }

        public void set_manufacture(string manufacture)
        {
            this.manufacture = manufacture;
        }

        public string get_capacity()
        {
            return capacity;
        }

        public void set_capacity(string capacity)
        {
            this.capacity = capacity;
        }

        public string get_accuracy()
        {
            return accuracy;
        }

        public void set_accuracy(string accuracy)
        {
            this.accuracy = accuracy;
        }

        public string get_testID()
        {
            return testID;
        }

        public void set_testID(string testID)
        {
            this.testID = testID;
        }
        public string get_SN()
        {
            return SN;
        }

        public void set_SN(string SN)
        {
            this.SN = SN;
        }

        public string get_certLot()
        {
            return certLot;
        }

        public void set_certLot(string certLot)
        {
            this.certLot = certLot;
        }

        public string get_procedure()
        {
            return procedure;
        }

        public void set_procedure(string procedure)
        {
            this.procedure = procedure;
        }

        public string get_units()
        {
            return units;
        }

        public void set_units(string units)
        {
            this.units = units;
        }

        public string get_operatorID()
        {
            return operatorID;
        }

        public void set_operatorID(string operatorID)
        {
            this.operatorID = operatorID;
        }

        public List<string> get_target()
        {
            return targetList;
        }

        public void set_target(List<string> targetList)
        {
            this.targetList = targetList;
        }

        public void set_lowLimit(List<string> lowLimitList)
        {
            lowList = lowLimitList;
        }

        public void set_highLimit(List<string> highLimitList)
        {
            highList = highLimitList;
        }

        public List<string> get_input()
        {
            return input;
        }

        public void set_input(List<string> inputList)
        {
            input = inputList;
        }
        public List<string> get_output()
        {
            return output;
        }

        public void set_output(List<string> outputList)
        {
            output = outputList;
        }
//End get and set headers value

        //Constructor that indicates whether this is single or dual channel
        public CertTestSequence(int channels)
        {
            string emptyStr = "";
            //Build structure for certTable
            if (channels == 1)
            {//Single Channel
                certTable = createDataTableStruct(singleTest_ColHeaders).Clone();
                singleOrDual = "N/A";
            }
            else//Dual Channel
            {
                certTable = createDataTableStruct(dualTest_ColHeaders).Clone();
                singleOrDual = "";
            }
            //Set all headers to empty str
            setAllHeaders(emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr, emptyStr);
        }

        //Set values for ALL headers
        public void setAllHeaders(string toolName, string timeStamp, string dueDate, string reCall, string temp, string humid,
            string equipment, string model, string manufacture, string capacity, string accuracy, string testID,
            string SN, string certLot, string procedure, string units, string operatorID)
        {
            set_toolName(toolName);
            set_timeStamp(timeStamp);
            set_dueDate(dueDate);
            set_reCall(reCall);
            set_temp(temp);
            set_humid(humid);
            set_equipment(equipment);
            set_model(model);
            set_manufacture(manufacture);
            set_capacity(capacity);
            set_accuracy(accuracy);
            set_testID(testID);
            set_SN(SN);
            set_certLot(certLot);
            set_procedure(procedure);
            set_units(units);
            set_operatorID(operatorID);
        }

        //Write a string to a file located at fileLoc
        private void writeStrToCSV(string fileLoc, string strToWrite)
        {
            //If file already existed, append to end of file
            if (!File.Exists(fileLoc))
            {
                File.WriteAllText(fileLoc, strToWrite + newLine);
            }
            else
                File.AppendAllText(fileLoc, strToWrite + newLine);
        }
        
        //MAIN METHOD used to write all headers, values and Datas to CSV
        //If write successful, return location, else return empty string
        public string writeToCertCSV()
        {
            string fileLoc = "";
            string datasToWrite = "";

            fileLoc = getCertCSVLoc();//get file name and location of CSV file to write to
            datasToWrite = getAllHeadersValueCSV();//append all headers value
            datasToWrite = appendTableToStr(datasToWrite, certTable);//append certTable Value to datasToWrite
            try
            {
                System.IO.Directory.CreateDirectory(CertManagerParentLoc);//Create C:Cert Manager folder if it didnt exist

                writeStrToCSV(fileLoc, datasToWrite); //Write to end of CSV for Cert Manager
                return fileLoc;
            }
            catch
            {
                return "";
            }
        }

        //if passed in headerValue is not empty then append to new line of returnHeadersValue
        private string appendHeaderValueToStr(string returnHeadersValue, string header, string headerValue)
        {
            if (headerValue != "")
            {
                returnHeadersValue += header + "," + headerValue + newLine;
            }
            return returnHeadersValue;
        }

        //append table Col Names and tables reading to a string
        private string appendTableToStr(string returnHeadersValue, System.Data.DataTable thisTable)
        {
            string colName = "";
            //write Column Name first
            foreach (DataColumn column in thisTable.Columns)
            {
                colName = column.ColumnName;
                if (colName.Contains("N/A"))
                    colName = "N/A";
                returnHeadersValue += colName + ",";
            }
            returnHeadersValue += newLine;

            //write Datas from table to string
            foreach (DataRow row in thisTable.Rows)
            {
                for (int colIndex = 0; colIndex < thisTable.Columns.Count; colIndex++)
                {
                    returnHeadersValue += row[colIndex] + ",";
                }
                returnHeadersValue += newLine;
            }
            return returnHeadersValue;
        }

        //return all Headers Value and parse them in string to write to CSV for Cert Manager
        private string getAllHeadersValueCSV()
        {
            string returnHeadersValue = "";

            returnHeadersValue= appendHeaderValueToStr(returnHeadersValue, toolName_header, toolName);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, timeStamp_header, timeStamp);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, dueDate_header, dueDate);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, recall_header, reCall);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, temp_header, temp);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, humid_header, humid);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, equipment_header, equipment);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, model_header, model);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, manufacture_header, manufacture);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, capacity_header, capacity);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, accuracy_header, accuracy);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, testID_header, testID);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, SN_header, SN);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, certLot_header, certLot);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, procedure_header, procedure);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, units_header, units);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue,singleOrDual_header,singleOrDual);
            returnHeadersValue = appendHeaderValueToStr(returnHeadersValue, operatorID_header, operatorID);
            returnHeadersValue+= "Test Results" + newLine;
            return returnHeadersValue;
        }

        //return Name of CSV for Cert Manager and file Name
        private string getCertCSVLoc()
        {
            string returnLoc = "";
            returnLoc = CertManagerParentLoc+ "\\results-" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
            return returnLoc;
        }


        //create empty datatable with pre defined columns name
        private System.Data.DataTable createDataTableStruct(string[] colsName_arr)
        {
            System.Data.DataTable thisTable=new System.Data.DataTable();
            foreach (string colName in colsName_arr)
            {
                thisTable.Columns.Add(colName);
            }
            return thisTable;
        }

        //write List of string to datatable at Column w passed in colName
        //now currently using this for input,output,target, low and high col for certTable
        private void writeListstringToDataTable(ref System.Data.DataTable thisTable, List<string> listToWrite,string colName)
        {
            int rowCount = 0;
            foreach (string strToWrite in listToWrite)
            {
                try
                {
                    if (rowCount >= thisTable.Rows.Count)
                    {
                        thisTable.Rows.Add();
                        thisTable.Rows[rowCount][sampleColName] = rowCount+1;
                    }
                    thisTable.Rows[rowCount][colName] = strToWrite;
                }
                catch { }
                rowCount++;
            }
        }

        //write Reading to certTable for Single Test
        //Todo: Need to be implemented
        public void set_singlecertTable(List<string> thisOutput)
        {
            writeListstringToDataTable(ref certTable,thisOutput,outputColName);
            writeListstringToDataTable(ref certTable,targetList,targetColName);
            writeListstringToDataTable(ref certTable,lowList,lowColName);
            writeListstringToDataTable(ref certTable,highList,highColName);
        }
        
        //write Reading to certTable for Dual Test
        
        public void set_dualcertTable(List<string> output, List<string> input)
        {
            //Write the readings to certTable
            //ch1 is normally Input, ch2 is Output
            writeListstringToDataTable(ref certTable,input,inputColName);
            writeListstringToDataTable(ref certTable,output,outputColName);
            
            //Write Target to certTable
            writeListstringToDataTable(ref certTable,targetList,targetColName);
        }
    }
}
