using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    internal class READING_UNIT
    {
        public string Reading { get; }
        public string Unit { get; }
        public float Reading_float { get; }
        public READING_UNIT() { }
        public READING_UNIT(float Reading_float,string Unit)
        {
            this.Reading = formatReading(Reading_float);
            this.Unit = Unit;
        }
        public READING_UNIT(string Reading, string Unit)
        {
            this.Reading = Reading;
            this.Unit= Unit;
        }
        private string formatReading(float ReadingFloat)
        {
            string reading = "";
            if (ReadingFloat == 0)
                reading = ReadingFloat.ToString("0.000");
            else
            {
                reading = ReadingFloat.ToString();
            }
            return reading;
        }
    }
}
