using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class READINGS_ANGLES
    {
        public double reading1 { get; set; }
        public double reading2 { get; set; }
        public double angle1 { get; set; }
        public double angle2 { get; set; }

        private string getVal(string str)
        {
            if (str != null)
                return str + ",";
            else
                return str;
        }
        public string getString()
        {
            string Str = getVal(reading1.ToString()) + getVal(angle1.ToString()) + getVal(reading2.ToString()) + getVal(angle2.ToString());
            return Str;
        }
    }
}
