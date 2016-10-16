using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStudio.Automation.TestManager.libCommon.Class;

namespace RLEDController
{
    public class LEDLightData
    {
        public List<int> m_listvalue = new List<int>();
        public List<int> m_listvalueR = new List<int>();
        public DateTime m_dt = new DateTime();

        private static bool FindValueStart(byte s)
        {
            if (s == (byte)':')
            {
                return true;
            }
            return false;
        }

        public int  ParseTime(string str)
        {
            string findstr = "read pulsar calibration time:";
            if (str.IndexOf(findstr) != -1)
            {
                int nstart = str.IndexOf(findstr);
                if (nstart + findstr.Length + 8 < str.Length)
                {
                    string value = str.Substring(nstart + findstr.Length, 8);
                    try
                    {
                        UInt32 num = UInt32.Parse(value, System.Globalization.NumberStyles.HexNumber);
                        m_dt = GT_Function.ConvertIntDateTime((double)num);
                        GT_RLEDController.mConfigInfo[tmMarcos.kDueTimeALSC2] = (double)num;
                        return 0;
                    }
                    catch (Exception e)
                    {
                        //throw e;
                        //如果第一次没有写这个数据的话直接写一个0
                        m_dt = GT_Function.ConvertIntDateTime((double)0);
                        GT_RLEDController.mConfigInfo[tmMarcos.kDueTimeALSC2] = (double)0;
                        return 0;
                    }
                }
            }
            return -1;
        }

        public int ParseValue(List<byte> srcdata)
        {
            int ret = -1;
            string strsrc = System.Text.Encoding.UTF8.GetString(srcdata.ToArray());
            string str = strsrc.ToLower();
            if (ParseTime(str) == 0)
                return 0;

            if ((str.IndexOf("read left pulsar calibration value:") == -1
                && str.IndexOf("read right pulsar calibration value:") == -1)
                || str.IndexOf("fail") != -1)
                return ret;

            if (str.IndexOf("read right pulsar calibration value:") != -1)
            {
                ParseRightCalibData(srcdata);
                ret = 0;
            }
            else if (str.IndexOf("read left pulsar calibration value:") != -1)
            {
                ParseLeftCalibData(srcdata);
                ret = 0;
            }
            return ret;
        }

        private void ParseLeftCalibData(List<byte> srcdata)
        {
            m_listvalue.Clear();
            int nstart = srcdata.FindIndex(FindValueStart);
            if (nstart != -1 && srcdata.Count > nstart + 34)
            {
                for (int n = nstart + 1; n < nstart + 1 + 34; n += 2)
                {
                    int intvalue = ((int)srcdata[n] << 8) | (srcdata[n + 1]);
                    m_listvalue.Add(intvalue);
                }
            }
        }

        private void ParseRightCalibData(List<byte> srcdata)
        {
            m_listvalueR.Clear();
            int nstart = srcdata.FindIndex(FindValueStart);
            if (nstart != -1 && srcdata.Count > nstart + 34)
            {
                for (int n = nstart + 1; n < nstart + 1 + 34; n += 2)
                {
                    int intvalue = ((int)srcdata[n] << 8) | (srcdata[n + 1]);
                    m_listvalueR.Add(intvalue);
                }
            }
        }

        public List<byte> BuildArrayData(string side)
        {
            List<byte> retdata = new List<byte>();
            string str = "";
            if (side == "Left")
            {
                str = "Write Left Pulsar Calibration Value:";
            }
            else
            {
                str = "Write Right Pulsar Calibration Value:";
            }
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
            retdata.AddRange(byteArray);
            for (int i = 0; i < 17; i++)
            {
                int nvalue = GetDataByIndex(side, i);
                retdata.Add((byte)(nvalue >> 8));
                retdata.Add((byte)nvalue);
            }
            return retdata;
        }

        public int GetDataByIndex(string side, int nLEDIndex)
        {
            if (side == "Left")
            {
                if (nLEDIndex >= 0 && nLEDIndex < m_listvalue.Count)
                {
                    return m_listvalue[nLEDIndex];
                }
            }
            else
            {
                if (nLEDIndex >= 0 && nLEDIndex < m_listvalueR.Count)
                {
                    return m_listvalueR[nLEDIndex];
                }
            }
            return 0;
        }
        public void SetDataByIndex(string side, int nLEDIndex, int nvalue)
        {
            if (side == "Left")
            {
                if (nLEDIndex >= 0 && nLEDIndex < m_listvalue.Count)
                {
                    m_listvalue[nLEDIndex] = nvalue;
                }
                else
                {
                    m_listvalue.Add(nvalue);
                }
            }
            else
            {
                if (nLEDIndex >= 0 && nLEDIndex < m_listvalueR.Count)
                {
                    m_listvalueR[nLEDIndex] = nvalue;
                }
                else
                {
                    m_listvalueR.Add(nvalue);
                }
            }
        }
    }
}
