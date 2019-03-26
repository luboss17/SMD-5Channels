using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{

    class CMCMKCal
    {
        private double USL, LSL;

        //added 7/31/18 to calculate average
        public double calculate_average(List<float> samplesList)
        {
            double average = 0;
            if (samplesList.Count > 0)
                average = samplesList.Average();
            return average;
        }
        //return a double type standard dev from List of readings
        //changed 7/31/18
        public double calculate_stand_deviation(List<float> samplesList)
        {
            double average = calculate_average(samplesList);
            double sd = 0;
            double tempSum = 0;
            foreach (float sample in samplesList)
            {
                tempSum += (average - sample) * (average - sample);
            }
            sd = Math.Sqrt(tempSum / (samplesList.Count - 1));
            return sd;
        }

        //calculate and return CM value, double type
        public double calculate_CM(float LSL, float USL, List<float> samplesList)
        {
            double CM;
            CM = (USL - LSL) / (6 * calculate_stand_deviation(samplesList));
            return CM;
        }

        //calculate CMK value
        public double calculate_CMK(float LSL, float USL, List<float> sampleList)
        {
            double val1, val2;
            double min;
            double sd = 3 * calculate_stand_deviation(sampleList);
            val1 = ((USL - sampleList.Average()) / sd);
            val2 = ((sampleList.Average() - LSL) / sd);
            min = Math.Min(val1, val2);
            return min;
        }

    }
}
