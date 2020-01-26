using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace WindowsFormsApplication1
{
    class PACKET
    {
        private byte[] packet;
        string streamFormat = "";
        int TDcount = 0;
        bool is1stAngle = false;
        bool is2ndAngle = false;
        public PACKET(byte[] packet)
        {
            this.packet = packet;
        }

        private void setStreamFormat(byte[] header)
        {
            if (header[0] == 160)
            {
                streamFormat = System.Text.Encoding.Default.GetString(header.Skip(2).Take(packet[1] & 0xFF).ToArray());
            }
        }

        //set how many TD and Angles in this stream, return totalbyte in each decoding
        private int setTDandAngleCount()
        {
            int singleReadingByteLen = 3;
            int dualReadingByteLen = 6;
            int angleByteLen = 2;
            int totalEachReadingLen = 0;
            foreach (char letter in streamFormat)
            {
                switch (letter)
                {
                    case 'T':
                        totalEachReadingLen += singleReadingByteLen;
                        TDcount++;
                        break;
                    case 'A':
                        totalEachReadingLen += angleByteLen;
                        if (TDcount == 1)
                            is1stAngle = true;
                        else if (TDcount == 2)
                            is2ndAngle = true;
                        break;
                    case 'P':
                        totalEachReadingLen += singleReadingByteLen;
                        TDcount++;
                        break;
                }
            }
            return totalEachReadingLen;
        }
        //decode each packet and return list of all readings in that packet
        //todo: handle angle and other type of streaming
        public List<READINGS_ANGLES> decodePacket(byte[] header)
        {
            setStreamFormat(header);
            List<READINGS_ANGLES> readings = new List<READINGS_ANGLES>();
            READINGS_ANGLES reading;
            if ((packet[0] >= 160) && (packet[0] <= 175))
            {
                int pos = 2;

                int totalEachReadingLen = 3;//this value=how many bytes existed for each reading(including angle). For now, set it to 3
                totalEachReadingLen = setTDandAngleCount();//set TD count and if there is angle

                while (pos < packet.Length - totalEachReadingLen)
                {
                    reading = decodeReading(packet.Skip(pos).Take(totalEachReadingLen).ToArray());
                    readings.Add(reading);
                    pos += totalEachReadingLen;
                }
            }
            return readings;
        }

        //pass in 3 bytes to decode reading
        private double decodeSingleReading(byte[] buffer)
        {
            double value;
            int mantissa, exp, sign;
            mantissa = buffer[0] | (buffer[1] << 8) | ((buffer[2] & 0x0F) << 16);
            exp = ((buffer[2] >> 4) & 7) - 5;
            sign = buffer[2] & 0x0F;
            value = mantissa * (Math.Pow(10, exp));
            if ((buffer[2] & 0x80) != 0)
                value = -value;

            return value;
        }
        //pass in 2 bytes to decode angle
        private short decodeAngle(byte[] buffer)
        {
            Int16 angle;
            angle = (Int16)(buffer[0] | (buffer[1] << 8));

            return angle;
        }
        //calculate reading for 1 line of reading
        private READINGS_ANGLES decodeReading(byte[] buffer)
        {
            READINGS_ANGLES returnValues = new READINGS_ANGLES();
            int bytePos = 0;
            if (TDcount >= 1)
            {
                returnValues.reading1 = decodeSingleReading(buffer.Skip(bytePos).Take(3).ToArray());
                bytePos += 3;
            }
            if (is1stAngle == true)
            {
                returnValues.angle1 = decodeAngle(buffer.Skip(bytePos).Take(2).ToArray());
                bytePos += 2;
            }
            if (TDcount == 2)
            {
                returnValues.reading2 = decodeSingleReading(buffer.Skip(bytePos).Take(3).ToArray());
                bytePos += 3;
            }
            if (is2ndAngle == true)
            {
                returnValues.angle2 = decodeAngle(buffer.Skip(bytePos).Take(2).ToArray());
                bytePos += 2;
            }

            return returnValues;
        }

        public bool checkRCS8()
        {
            int rcs8 = 1;
            bool packetValid;
            byte runningByte;
            int negrcs8;
            for (int byteIndex = 0; byteIndex <= packet.Count() - 2; byteIndex++)
            {
                runningByte = packet[byteIndex];
                rcs8 = ((rcs8 << 1) + runningByte);

                if ((rcs8 & 0xFF00) != 0)
                    rcs8 = ~rcs8;

                rcs8 &= 0xFF;
            }
            packetValid = (rcs8 == packet.Last());
            if (packetValid == false)
                negrcs8 = 3;
            return (packetValid);
        }
    }
}
