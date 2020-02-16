using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{

    public partial class StreamingForm : Form
    {
        public int readingColIndex = 1;
        private const int maxReadTimeOut = 100;
        private int channelToCompare = 0,channelCount=1;
        List<double> targets = new List<double>();
        public DataTable returnResultTable = new DataTable();
        Chart streamChartCh1 = new Chart(),streamChartCh2=new Chart();
        public bool isSave = false,endOfStream=false;
        bool waitForCh1Sync = false, waitForCh2Sync = false;
        bool singleChStream = false, dualChStream = false, CalCertStream = false;
        List<int> freqList = new List<int> { 7, 62, 125, 250, 500, 1000, 1500, 2000 };
        public StreamingForm(SerialPort ch1Port,SerialPort ch2Port, List<double> targets, int channelToCompare,int channelCount)
        {
            InitializeComponent();
            bindFrequencyBox();
            streamingPort1 = ch1Port;
            streamingPort2 = ch2Port;
            changeTo250kbaud(ref streamingPort1);
            changeTo250kbaud(ref streamingPort2);
            CalCertStream = true;
            this.targets = targets;
            this.channelCount = channelCount;
            this.channelToCompare = channelToCompare;
            initStreamTable(ref streamTableCh1);
            initStreamTable(ref streamTableCh2);
            initStreamChart(ref streamChartCh1, ref streamTableCh1,chart1LocX,chartLocY,chartSizeX,chartSizeY);
            initStreamChart(ref streamChartCh2, ref streamTableCh2, chart2LocX, chartLocY, chartSizeX, chartSizeY);
            initPort();
            bindStreamGrid();

            bindResultGrid();
            InitTimer();
            isStream = false;
            autoStartStream(channelCount);//auto start streaming
        }
        public StreamingForm(SerialPort ch1Port,int channelCount)
        {
            InitializeComponent();
            bindFrequencyBox();
            streamingPort1 = ch1Port;
            changeTo250kbaud(ref streamingPort1);
            singleChStream = true;
            this.channelCount = channelCount;

            initStreamTable(ref streamTableCh1);
            initStreamChart(ref streamChartCh1, ref streamTableCh1, chart1LocX, chartLocY, chartSizeX, chartSizeY);
            initPort();
            bindStreamGrid();
            
            InitTimer();
            isStream = false;
        }
        public StreamingForm(SerialPort ch1Port, SerialPort ch2Port,int channelCount)
        {
            InitializeComponent();
            bindFrequencyBox();
            streamingPort1 = ch1Port;
            streamingPort2 = ch2Port;
            changeTo250kbaud(ref streamingPort1);
            changeTo250kbaud(ref streamingPort2);
            dualChStream = true;
            this.channelCount = channelCount;

            initStreamTable(ref streamTableCh1);
            initStreamTable(ref streamTableCh2);
            initStreamChart(ref streamChartCh1, ref streamTableCh1, chart1LocX, chartLocY, chartSizeX, chartSizeY);
            initStreamChart(ref streamChartCh2, ref streamTableCh2, chart2LocX, chartLocY, chartSizeX, chartSizeY);
            initPort();
            bindStreamGrid();

            InitTimer();
            isStream = false;
        }
        private void bindFrequencyBox()
        {
            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = freqList;

            frequency_comboBox.DataSource = bindingSource1.DataSource;
            frequency_comboBox.SelectedIndex = 4;//default freq=500 samples/sec
        }
        private void StreamingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isStream = false;
            streamGridCh1.DataSource = null;
            streamGridCh2.DataSource = null;
            streamTimer.Stop();
            streamTimer.Dispose();
        }
        DataTable resultTable = new DataTable();
        private const string angle1ColName = "Angle1";
        private const string angle2ColName = "Angle2";
        private const string targetColName = "Target";

        /// <summary>
        /// Start init timer2 to display live reading
        /// </summary>
        public Timer streamTimer=new Timer();
        int tickInterval = 250;
        private void InitTimer()
        {
            streamTimer = new System.Windows.Forms.Timer();
            streamTimer.Tick += new EventHandler(streamTimer_Tick);
            streamTimer.Interval = tickInterval;
            streamTimer.Start();
        }
        //Trigger when timer tick
        //Update live reading, update stream grid
        //Todo: write stream 2 to separate spreadsheet
        private void streamTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (isStream == true)
                {
                    showStreamData(ref runningByteStreamCh1, masterStreamCh1,streamReadingsListCh1,ref streamTableCh1);
                    showStreamData(ref runningByteStreamCh2, masterStreamCh2, streamReadingsListCh2,ref streamTableCh2);
                }
            }
            catch { }
        }
        private void showStreamData(ref int runningByteStream,List<byte> masterStream,List<READINGS_ANGLES>streamReadingsList,ref DataTable streamTable )
        {
            if ((runningByteStream == 0) && (masterStream.Count >= 2) && (masterStream.Count >= ((masterStream[1] & 0xFF) + offsetPacketLength)))
                    {
                        runningByteStream = getPosAfterHeaderPacket(masterStream);
                    }
                    if (runningByteStream < masterStream.Count - 1)
                    {
                        runningByteStream = decodeMasterStream(masterStream, runningByteStream,streamReadingsList);
                        bindStreamGrid();
                        writeToStreamTable(streamReadingsList,ref streamTable);
                    }
                    if (endOfStream==true)
                    {
                        importResult();
                        endOfStream = false;
                    }
        }
        private void streamGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(streamGridCh1.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 13, e.RowBounds.Location.Y + 4);
            }
        }
        private void initPort()
        {
            streamingPort1.DataReceived += streamingPort1_DataReceived;
            streamingPort2.DataReceived += streamingPort2_DataReceived;
        }
        
        private void streamingPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if ((isStream == true)&&(waitForCh1Sync==false)&&(waitForCh2Sync==false))
            {
                int bytes;
                byte[] Bytebuffer;
                try
                {
                    bytes = streamingPort1.BytesToRead;
                }
                catch (OverflowException)
                {
                    bytes = 0;
                }
                Bytebuffer = new byte[bytes];

                Task T = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        streamingPort1.Read(Bytebuffer, 0, bytes);
                        checkForStreamHeader(Bytebuffer, streamingPort1,ref tempMasterCh1,ref masterStreamCh1);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
                    }
                });
                T.Wait();
            }
        }
        private void streamingPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if ((isStream == true) && (waitForCh1Sync == false) && (waitForCh2Sync == false))
            {
                int bytes;
                byte[] Bytebuffer;
                try
                {
                    bytes = streamingPort2.BytesToRead;
                }
                catch (OverflowException)
                {
                    bytes = 0;
                }
                Bytebuffer = new byte[bytes];

                Task T = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        streamingPort2.Read(Bytebuffer, 0, bytes);
                        checkForStreamHeader(Bytebuffer, streamingPort2,ref tempMasterCh2,ref masterStreamCh2);
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.Message);
                    }
                });
                T.Wait();
            }
        }
        /// <summary>
        /// /////////////////////////Start Streaming////////////////////////////
        /// </summary>
        bool isStream = false;
        List<byte> masterStreamCh1 = new List<byte>(), masterStreamCh2=new List<byte>(), tempMasterCh1 = new List<byte>(), tempMasterCh2=new List<byte>();
        private List<READINGS_ANGLES> streamReadingsListCh1 = new List<READINGS_ANGLES>(), streamReadingsListCh2 = new List<READINGS_ANGLES>();
        const string startSingleStreamCommand = "?*M;";
        string startSyncDualStreamCommand;//begin on sync comand, need to append rate to the end of command
        const string startDualStreamCommand = "?*D;";
        string[] acknowledge = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" };
        int invalidCount = 0;
        int runningByteStreamCh1 = 0,runningByteStreamCh2=0;
        const int offsetPacketLength = 3;//for header, reading length and rcs8 byte length
        int baud9600 = 9600;
        int baud250k = 250000;
        SerialPort streamingPort1 = new SerialPort(),streamingPort2=new SerialPort();
        SerialPort streamPort = new SerialPort();
        public DataTable streamTableCh1 = new DataTable(),streamTableCh2=new DataTable();
        private void changeMode(SerialPort thisPort, int mode)
        {
            string queryCommand = "";
            string newMode = "Mode";
            if (thisPort.IsOpen)
            {
                if (mode > 3)
                    mode = 1;
                queryCommand = "!M" + (mode) + ";";
                sendCommandNoResponse(queryCommand, thisPort);
            }
        }
        const int trackMode = 1,peakMode=2;
        private void autoStartStream(int channelCount)
        {
            if (channelCount==1)
            {
                changeMode(streamingPort1, peakMode);
                prepareToStartStream();
                startSingleStream(streamingPort1);
            }
            else if (channelCount==2)
            {
                //epareToStartStream();
                //For now, Dual Stream only deal w 2 Single Digital TD Stream
                //startDualStream(streamingPort1);
                changeMode(streamingPort1, trackMode);
                changeMode(streamingPort2, trackMode);
                startDualStream();
            }
        }
        private void writeToMasterStream(byte[] byteArr, SerialPort thisPort, ref List<byte> tempMaster,ref List<byte> masterStream)
        {
            int ackLoc = 0;
            if (isStream == true)
                tempMaster.AddRange(byteArr);
            int byteIndex = 0, cutIndex = 0;
            int offsetPacketLength = 3;//for header, reading length and rcs8 byte length
            try
            {
                while (byteIndex < tempMaster.Count)
                {
                    if ((tempMaster[byteIndex] >= 160) && (tempMaster[byteIndex] <= 176) && ((tempMaster.Count - byteIndex) > 1))
                    {
                        //A0 to AF, check if a whole packet, if it is, cut that whole packet and append to masterStream
                        int readingLength_byte = tempMaster[byteIndex + 1] & 0xFF;
                        try
                        {
                            if ((readingLength_byte + byteIndex + offsetPacketLength) < tempMaster.Count)
                            {
                                //send acknowledge that whole packet received
                                byte headerByte = tempMaster[byteIndex];
                                if ((headerByte >= 160) && (headerByte <= 175) && (headerByte != 0))
                                {
                                    ackLoc = headerByte % 160;
                                    sendCommandNoResponse(Encoding.ASCII.GetBytes(acknowledge[ackLoc])[0], thisPort);
                                }
                                byte[] arrToAdd = tempMaster.GetRange(byteIndex, readingLength_byte + offsetPacketLength).ToArray();
                                
                                masterStream.AddRange(arrToAdd);
                                //if arrToAdd 1st byte is 176 -> end of stream -> save to cal cert
                                if ((arrToAdd.Length > 1) && (arrToAdd[0] == 176))
                                {
                                    endOfStream = true;
                                }

                                byteIndex += readingLength_byte + offsetPacketLength;
                                cutIndex = byteIndex;
                            }
                            else
                                byteIndex = tempMaster.Count;//to break out of while loop
                        }
                        catch (Exception e)
                        {
                            Debug.Print(e.Message);
                        }
                    }
                    else
                        byteIndex++;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            //cut off packet from tempmaster
            if (cutIndex > 0)
            {
                tempMaster.RemoveRange(0, cutIndex);
            }
        }
        //Check if byteArr has header from Streaming, if it does, send back ack
        //changed 4/16/19
        private void checkForStreamHeader(byte[] byteArr, SerialPort thisPort,ref List<byte> tempMaster,ref List<byte> masterStream)
        {
            writeToMasterStream(byteArr,thisPort,ref tempMaster, ref masterStream);
        }

        //pass in masterStream, return where to start from 2nd packet (skip the header packet)
        private int getPosAfterHeaderPacket(List<byte> masterStream)
        {
            if (masterStream.Count <= 0)
                return 0;
            int returnPos = 0;
            int readingLength_byte = masterStream[1] & 0xFF;

            byte[] headerPacket = masterStream.GetRange(0, readingLength_byte + offsetPacketLength).ToArray();

            returnPos = readingLength_byte + offsetPacketLength;//pos start at 2nd packet

            return returnPos;
        }

        //decode masterStream starting from a position
        //return the last successful byte position that got decoded
        private int decodeMasterStream(List<byte> thisMasterStream, int startPos, List<READINGS_ANGLES> streamReadingsList)
        {

            int readingLength_byte = thisMasterStream[1] & 0xFF;
            int lastAddedByteIndex = 0;

            byte[] headerPacket = thisMasterStream.GetRange(0, readingLength_byte + offsetPacketLength).ToArray();

            while (startPos < thisMasterStream.Count)
            {
                byte runningByte = thisMasterStream[startPos];
                if ((runningByte >= 160) && (runningByte <= 176) && ((thisMasterStream.Count - startPos) > 1))
                {
                    try
                    {
                        readingLength_byte = thisMasterStream[startPos + 1] & 0xFF;

                        if ((readingLength_byte + startPos + offsetPacketLength) <= thisMasterStream.Count)
                        {
                            byte[] OneWholePacket = thisMasterStream.GetRange(startPos, readingLength_byte + offsetPacketLength).ToArray();

                            PACKET packet = new PACKET(OneWholePacket);

                            if (packet.checkRCS8() == true)
                            {
                                //last packet, no ack, return last byteIndex in this masterstream
                                if (runningByte == 176)
                                {
                                    return (thisMasterStream.Count - 1);
                                }
                                else
                                {
                                    streamReadingsList.AddRange(packet.decodePacket(headerPacket));
                                }
                            }
                            else
                                invalidCount++;
                            startPos += readingLength_byte + offsetPacketLength;
                            lastAddedByteIndex = startPos;
                        }
                        else
                            startPos++;
                    }
                    catch { }
                }
                else
                {
                    startPos++;
                }
            }
            //if (invalidCount > 0)
            //    MessageBox.Show(invalidCount.ToString());
            return lastAddedByteIndex;

        }
        private void bindStreamGrid()
        {
            var sourceList = new BindingList<READINGS_ANGLES>(streamReadingsListCh1);
            var source = new BindingSource(sourceList, null);

            streamGridCh1.DataSource = streamTableCh1;
            if (((CalCertStream==true) || (dualChStream==true)) && (singleChStream==false))
                streamGridCh2.DataSource = streamTableCh2;

        }
        private void bindResultGrid()
        {
            targetGrid.DataSource = returnResultTable;
        }
        private void writeListToGridView(List<READINGS_ANGLES> readingList, DataGridView thisGrid)
        {
            thisGrid.Invoke((Action)(() => thisGrid.Rows.Clear()));
            thisGrid.Invoke((Action)(() => thisGrid.Refresh()));

            for (int rowIndex = 0; rowIndex < readingList.Count; rowIndex++)
            {
                //Todo: get Unit and change to new string[2]
                string[] strToadd = new string[1];
                strToadd[0] = readingList[rowIndex].reading1.ToString();
            }

        }
        
        private void startSingleStream(SerialPort thisPort)
        {
            sendCommandNoResponse(startSingleStreamCommand, thisPort);
        }
        private void startDualStream(SerialPort thisPort)
        {
            sendCommandNoResponse(startDualStreamCommand, thisPort);
        }
        //send command to serial port without reading anything back
        private void sendCommandNoResponse(string command, SerialPort thisPort)
        {
            if (thisPort.IsOpen)
            {
                try
                {
                    thisPort.Write(command);
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
            }
        }
        public void doneStreaming()
        {
            stopStream(streamingPort1);
            stopStream(streamingPort2);
            int startingPos = getPosAfterHeaderPacket(masterStreamCh1);
            streamReadingsListCh1 = new List<READINGS_ANGLES>();
            decodeMasterStream(masterStreamCh1, startingPos,streamReadingsListCh1);
            streamTableCh1.Clear();
            streamTableCh2.Clear();
            writeToStreamTable(streamReadingsListCh1,ref streamTableCh1);
            writeToStreamTable(streamReadingsListCh2, ref streamTableCh2);
            streamGridCh1.Refresh();
            streamGridCh2.Refresh();
        }
        private void prepareToStartStream()
        {
            invalidCount = 0;
            runningByteStreamCh1 = 0;
            runningByteStreamCh2=0;
            streamReadingsListCh1 = new List<READINGS_ANGLES>();
            streamReadingsListCh2 = new List<READINGS_ANGLES>();

            masterStreamCh1 = new List<byte>();
            masterStreamCh2 = new List<byte>();
            
            tempMasterCh1 = new List<byte>();
            tempMasterCh2=new List<byte>();
            isStream = true;

            streamTableCh1.Clear();
            streamTableCh2.Clear();
            
            if (streamingPort1.IsOpen == true)
                streamingPort1.DiscardInBuffer();
            if (streamingPort2.IsOpen == true)
                streamingPort2.DiscardInBuffer();
            bindChart();
        }

        private void stopStream(SerialPort thisPort)
        {
            byte stopStreamByte = 0x20;
            sendCommandNoResponse(stopStreamByte, thisPort);
        }

        private const string ch1StreamSerie = "Channel1", ch2StreamSerie = "Channel2", angle1StreamSerie = "Angle1", angle2StreamSerie = "Angle2";

        private void stropStream_btn_Click(object sender, EventArgs e)
        {
            stopStream(streamingPort1);
            stopStream(streamingPort2);
        }
        //set port to 250k
        //ping, if no response, set port to 9600, ping
        //send b4 to change to 250k
        //set port to 250k
        private void changeTo250kbaud(ref SerialPort serialPort)
        {
            string baud25kcommand = "b4";
            sendCommandAndReadPort(baud25kcommand, serialPort);
            serialPort.BaudRate = baud250k;
        }
        private void changeTo9600baud(ref SerialPort serialPort)
        {
            string baud9kcommand = "b0";
            sendCommandAndReadPort(baud9kcommand, serialPort);
            serialPort.BaudRate = baud9600;
        }

        private void initStreamTable(ref DataTable streamTable)
        {
            streamTable = new DataTable("StreamTable");

            DataColumn dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int32);
            dtColumn.ColumnName = "Index";
            dtColumn.Unique = true;
            streamTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = ch1StreamSerie;
            dtColumn.Unique = false;
            streamTable.Columns.Add(dtColumn);

            /*dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = ch2StreamSerie;
            dtColumn.Unique = false;
            streamTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = angle1StreamSerie;
            dtColumn.Unique = false;
            streamTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(double);
            dtColumn.ColumnName = angle2StreamSerie;
            dtColumn.Unique = false;
            streamTable.Columns.Add(dtColumn);*/
        }

        private void writeToStreamTable(List<READINGS_ANGLES> listToWrite,ref DataTable streamTable)
        {
            int lineStart = streamTable.Rows.Count - 1;
            if (lineStart < 0)
                lineStart = 0;
            for (int lineIndex = lineStart; lineIndex < listToWrite.Count; lineIndex++)
            {
                try
                {
                    DataRow dtRow = streamTable.NewRow();
                    dtRow[0] = streamTable.Rows.Count + 1;
                    dtRow[1] = listToWrite[lineIndex].reading1;
                    /*dtRow[2] = listToWrite[lineIndex].reading2;
                    dtRow[3] = listToWrite[lineIndex].angle1;
                    dtRow[4] = listToWrite[lineIndex].angle2;*/
                    streamTable.Rows.Add(dtRow);
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }
            }
            bindChart();
        }
        private void initChartSerie(ref Chart chart, string name)
        {
            try
            {
                foreach (Series serie in chart.Series)
                {
                    if (serie.Name == name)
                        return;
                }
                chart.Series.Add(name);
            }
            catch { }
        }

        private void startSingleStream_btn_Click(object sender, EventArgs e)
        {
            if (isStream == true)
            {
                stopStream(streamingPort1);
            }
            int channelCount = 1;
            autoStartStream(channelCount);
        }

        private void startDualStream_btn_Click(object sender, EventArgs e)
        {
            prepareToStartStream();
            startDualStream(streamingPort1);
        }

        private void stopStream_btn_Click(object sender, EventArgs e)
        {
            stopStream(streamingPort1);
            stopStream(streamingPort2);
        }

        private void doneStream_btn_Click(object sender, EventArgs e)
        {
            doneStreaming();
            isStream = false;
            bindStreamGrid();
        }

        //Assign look for the chart
        private Chart setChart(Chart chart, string serie, int chartype)
        {
            //set graph type to Line chart or Point
            if (chartype == 1)//Use FastLine
            {
                chart.Series[serie].ChartType = SeriesChartType.FastLine;
                chart.Series[serie]["LineTension"] = "0.2";
            }
            else//set graph type to FastPoint
            {
                chart.Series[serie].ChartType = SeriesChartType.FastPoint;
            }
            //only show area with X > 0
            chart.ChartAreas[chartAreaName].AxisX.IsMarginVisible = true;
            //set width of graph line for actual reading
            chart.Series[serie].BorderWidth = 3;
            //show X and Y value when hover near tip
            chart.Series[serie].ToolTip = "X=#VALX, Y=#VALY";
            //disable vertical grid line
            chart.ChartAreas[chartAreaName].AxisX.MajorGrid.LineWidth = 0;
            return chart;
        }

        private void to25kbaud_btn_Click(object sender, EventArgs e)
        {
            changeTo250kbaud(ref streamingPort1);
            changeTo250kbaud(ref streamingPort2);
        }

        private void to9600baudrate_btn_Click(object sender, EventArgs e)
        {
            changeTo9600baud(ref streamingPort1);
            changeTo9600baud(ref streamingPort2);
        }
        //extract results from streaming datatable that match with target
        private DataTable getMatchingResultFromTarget(List<double> targets, DataTable table, int channelToCompare)
        {
            DataTable returnTable = streamTableCh1.Clone();
            double currReading = 0, prevReading = 0;
            int targetIndex = 0;
            bool okToImportRow = false;//decide whether the row readings match with target
            if (targets.Count > 0)
            {
                for (int rowCount = 0; rowCount < table.Rows.Count; rowCount++)
                {
                    DataRow tableRow = table.Rows[rowCount];
                    currReading = (double)tableRow[channelToCompare];

                    //determine if row readings match w/ targets based on CW or CCW
                    if (targets[targetIndex]>=0)
                    {//Clockwise
                        if ((currReading >= targets[targetIndex]) && (prevReading < targets[targetIndex]))
                            okToImportRow = true;
                        else
                            okToImportRow = false;
                    }
                    else//counter clockwise
                    {
                        if ((currReading < targets[targetIndex]) && (prevReading >= targets[targetIndex]))
                            okToImportRow = true;
                        else
                            okToImportRow = false;
                    }

                    //Import to returnTable Row if match w target
                    if ( okToImportRow==true)
                    {
                        returnTable.ImportRow(tableRow);
                        targetIndex++;
                    }
                    //break out of loop if all matching targets found
                    if (targetIndex >= targets.Count)
                    {
                        break;
                    }
                }
            }
            return returnTable;
        }
        private void importResult()
        {
            returnResultTable = streamTableCh1.Clone();
            returnResultTable = getMatchingResultFromTarget(targets, streamTableCh1, channelToCompare);
            bindResultGrid();
        }
        private DataTable reduceTableCount(DataTable oriTable,int newRowCount)
        {
            int rowCountToSkip = oriTable.Rows.Count / newRowCount;
            DataTable returnTable = oriTable.Clone();
            for (int rowCount=0;rowCount<oriTable.Rows.Count;rowCount++)
            {
                if ((((rowCount+1)%rowCountToSkip)==0)&&(returnTable.Rows.Count<newRowCount))
                {
                    returnTable.ImportRow(oriTable.Rows[rowCount]);
                }
            }
            return returnTable;
        }
        private void saveResult_btn_Click(object sender, EventArgs e)
        {
            if (singleChStream == true)
            {
                Form_PointSaveCount savePointsCountForm = new Form_PointSaveCount(streamTableCh1.Rows.Count);
                savePointsCountForm.ShowDialog();
                if (savePointsCountForm.returnPointsToSave<streamTableCh1.Rows.Count)
                {
                    streamTableCh1 = reduceTableCount(streamTableCh1, savePointsCountForm.returnPointsToSave).Copy();
                }
            }
            isSave = true;
            
            closeForm();
        }


        private void bindChartXYwithTableHeader(ref DataTable tableToBind, int xTableIndex, int yTableIndex, ref Chart chart, string serieName)
        {
            chart.Series[serieName].XValueMember = tableToBind.Columns[xTableIndex].ColumnName;
            chart.Series[serieName].YValueMembers = tableToBind.Columns[yTableIndex].ColumnName;
            chart.DataSource = tableToBind;
        }

        private void retakeStreaming_btn_Click(object sender, EventArgs e)
        {
            if (isStream==true)
            {
                stopStream(streamingPort1);
            }
            autoStartStream(channelCount);
        }
        private void closeForm()
        {
            if (streamingPort1.IsOpen)
                changeTo9600baud(ref streamingPort1);
            if (streamingPort2.IsOpen)
                changeTo9600baud(ref streamingPort2);
            if ((isSave == false) && (masterStreamCh1.Count > 0))
            {
                var closeForm = MessageBox.Show("Stream Data is not saved. Discard Stream Data? ", "Exit", MessageBoxButtons.YesNo);
                if (closeForm == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
            closeForm();
        }
        private void bindChart()
        {
            streamChartCh1.DataBind();
            streamChartCh2.DataBind();
        }
        string chartAreaName = "StreamChartArea";
        const int chart1LocX=541,chartLocY=40;
        const int chartSizeX = 732, chartSizeY = 555;
        const int chart2LocX = 1273;
        private void initStreamChart(ref Chart chart, ref DataTable tableToBind,int chartLocX, int chartLocY, int chartSizeX, int chartSizeY)
        {
            chart = new Chart();
            chart.Location=new Point(chartLocX, chartLocY);
            chart.Size = new Size(chartSizeX, chartSizeY);
            chart.ChartAreas.Add(chartAreaName);
            Controls.Add(chart);

            initChartSerie(ref chart, ch1StreamSerie);
            chart = setChart(chart, ch1StreamSerie, 1);
            /*initChartSerie(ref chart, angle1StreamSerie);
            chart = setChart(chart, angle1StreamSerie, 1);
            initChartSerie(ref chart, ch2StreamSerie);
            chart = setChart(chart, ch2StreamSerie, 1);
            initChartSerie(ref chart, angle2StreamSerie);
            chart = setChart(chart, angle2StreamSerie, 1);
            */
            bindChartXYwithTableHeader(ref tableToBind, 0, 1, ref chart, ch1StreamSerie);
            /*bindChartXYwithTableHeader(ref tableToBind, 0, 2, ref chart, ch2StreamSerie);
            bindChartXYwithTableHeader(ref tableToBind, 0, 3, ref chart, angle1StreamSerie);
            bindChartXYwithTableHeader(ref tableToBind, 0, 4, ref chart, angle2StreamSerie);
            */
            chart.ChartAreas[chartAreaName].AxisY.RoundAxisValues();
            chart.DataBind();
        }
        //send Byte of command, without reading anything back
        private void sendCommandNoResponse(byte command, SerialPort thisPort)
        {
            byte[] bytestosend = new byte[1] { command };
            if (thisPort.IsOpen)
            {
                try
                {
                    thisPort.Write(bytestosend, 0, 1);
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
            }
        }
        //Param: Command to write to Serial Port and which serial port to write to
        //Return feed back from tester
        private string sendCommandAndReadPort(string command, SerialPort port)
        {

            string returnvalue = "";
            if (port.IsOpen)
            {
                try
                {
                    port.ReadTimeout = maxReadTimeOut;
                    port.Write(command);
                    double waittimeout = maxReadTimeOut + DateTime.Now.TimeOfDay.TotalMilliseconds;
                    while ((DateTime.Now.TimeOfDay.TotalMilliseconds < waittimeout))
                    {
                        if (port.BytesToRead > 0)
                        {
                            returnvalue = port.ReadTo(";");
                        }
                    }

                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
            }
            return returnvalue;
        }
        //Dual Stream
        private int getCorrectedRate(int oriRate)
        {
            int correctedRate = oriRate;
            if ((307200 % oriRate) != 0)
                correctedRate = 307200 / Convert.ToInt16(307200 / oriRate);
            return correctedRate;
        }
        private int getFreqRate()
        {
            int freqSelect = (int)frequency_comboBox.SelectedItem;
            /*int returnRate = 240;
            returnRate = getCorrectedRate(freqSelect);*/
            return freqSelect;
        }
        private void startDualStream()
        {
            startSyncDualStreamCommand = "?*Y";
            int streamRate = getFreqRate();
            startSyncDualStreamCommand += streamRate + ";";
            waitForCh1Sync = true;
            waitForCh2Sync = true;
            //send sync stream command to ch1 and ch2 
            sendCommandNoResponse(startSyncDualStreamCommand, streamingPort1);
            waitForCh1Sync = false;
            sendCommandNoResponse(startSyncDualStreamCommand, streamingPort2);
            waitForCh2Sync = false;

            runningByteStreamCh1 = 0;
            runningByteStreamCh2 = 0;
            streamReadingsListCh1 = new List<READINGS_ANGLES>();
            streamReadingsListCh2 = new List<READINGS_ANGLES>();

            masterStreamCh1 = new List<byte>();
            masterStreamCh2 = new List<byte>();
            /*
            tempMasterCh1 = new List<byte>();
            tempMasterCh2 = new List<byte>();*/
            isStream = true;

            streamTableCh1.Clear();
            streamTableCh2.Clear();

            if (streamingPort1.IsOpen == true)
                streamingPort1.DiscardInBuffer();
            if (streamingPort2.IsOpen == true)
                streamingPort2.DiscardInBuffer();
            bindChart();
        }
        private void DualStream_btn_Click(object sender, EventArgs e)
        {
            if (streamingPort1.IsOpen)
                changeMode(streamingPort1, trackMode);
            if (streamingPort2.IsOpen)
                changeMode(streamingPort2, trackMode);
            startDualStream();
        }
        /// <summary>
        /// ///////////////////End Streaming///////////////////////////////////
        /// </summary>
        /// 
    }
    
    public static class Extension
    {
        public static DataTable tableAddCol(this DataTable thisTable, string colName, int index)
        {
            thisTable.Columns.Add(colName, typeof(float));
            thisTable.Columns[colName].SetOrdinal(index);//set location of column 
            return thisTable;
        }
    }
}
