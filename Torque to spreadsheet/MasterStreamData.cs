using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class MasterStreamData
    {
        public DataTable AFCW_streamTable = new DataTable(),
            ALCW_streamTable = new DataTable(),
            AFCCW_streamTable = new DataTable(),
            ALCCW_streamTable = new DataTable();
        private const string ch1StreamSerie = "Channel1", 
            ch2StreamSerie = "Channel2", 
            angle1StreamSerie = "Angle1", 
            angle2StreamSerie = "Angle2";

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

            dtColumn = new DataColumn();
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
            streamTable.Columns.Add(dtColumn);
        }
        public MasterStreamData()
        {
            initStreamTable(ref AFCW_streamTable);
            initStreamTable(ref AFCCW_streamTable);
            initStreamTable(ref ALCW_streamTable);
            initStreamTable(ref ALCCW_streamTable);
        }
        public void writeToStreamTable(char quadrantIndex,DataTable tableToWrite)
        {
            switch (quadrantIndex)
            {
                case '1':
                    AFCW_streamTable = tableToWrite.Copy();
                    break;
                case '2':
                    AFCCW_streamTable = tableToWrite.Copy();
                    break;
                case '3':
                    ALCW_streamTable = tableToWrite.Copy();
                    break;
                case '4':
                    ALCCW_streamTable = tableToWrite.Copy();
                    break;

            }
        }
        public DataTable getQuadrantStreamTable(char quadrantIndex)
        {
            DataTable returnTable = new DataTable();
            switch (quadrantIndex)
            {
                case '1':
                    returnTable= AFCW_streamTable.Copy();
                    break;
                case '2':
                    returnTable = AFCCW_streamTable.Copy();
                    break;
                case '3':
                    returnTable = ALCW_streamTable.Copy();
                    break;
                case '4':
                    returnTable = ALCCW_streamTable.Copy();
                    break;

            }
            return returnTable;
        }
    }
}
