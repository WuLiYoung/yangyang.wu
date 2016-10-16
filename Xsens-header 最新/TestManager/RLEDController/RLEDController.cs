using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using System.IO;

namespace RLEDController
{
    public class RLEDController:SerialPort
    {
        static object lockobject =new object();
        protected string m_strSerialWait = "";  //需要等待的字符串
        protected List<byte> m_Buffer = new List<byte>();
        protected string m_SN ="";
        public LEDLightData m_lightdata = new LEDLightData();

        public RLEDController()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Init()
        {
            if (IsOpen)
                Close();
            try
            {
                if (GT_RLEDController.mConfigInfo.ContainsKey(tmMarcos.kLED2Config))
                {
                    string config = GT_RLEDController.mConfigInfo[tmMarcos.kLED2Config].ToString();
                    this.Setting = config;
                }
                else
                {
                    this.Setting = "115200,N,8,1";
                    GT_RLEDController.mConfigInfo[tmMarcos.kLED2Config] = this.Setting;
                }
                if (GT_RLEDController.mConfigInfo[tmMarcos.kLED2Com] != null)
                    this.PortName = GT_RLEDController.mConfigInfo[tmMarcos.kLED2Com].ToString();
            }
            catch (Exception)
            {
            }
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnReceive);
            Encoding = System.Text.Encoding.UTF8;
        }

        public void DoConnect()
        {
            try
            {
                if (IsOpen) Close();
                Open();
                if (IsOpen)
                {
                    Get_AlSC_Data();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("ALSC-2 打开失败" + e.Message + "(E0003)");
            }
        }

        private void Get_AlSC_Data()
        {
            SetDetectString("@_@");
            WriteString("Read Left Pulsar Calibration Value\r\n");
            if (WaitForString(1000) == -1)
            {
                NotificationCenter.DefaultCenter().Notification2Log(0, "Pulsar 2 :Read Left Pulsar Calibration Value fail!\r\n");
            }
            else
            {
                if (m_lightdata.ParseValue(m_Buffer) == 0)
                {
                    m_Buffer.Clear();
                }
            }
            SetDetectString("@_@");
            WriteString("Read Right Pulsar Calibration Value\r\n");
            if (WaitForString(1000) == -1)
            {
                NotificationCenter.DefaultCenter().Notification2Log(0, "Pulsar 2 :Read Right Pulsar Calibration value failed!\r\n");
            }
            else
            {
                if (m_lightdata.ParseValue(m_Buffer) == 0)
                {
                    m_Buffer.Clear();
                }
            }
           
            SetDetectString("@_@");
            WriteString("Read Pulsar Calibration Time\r\n");
            if (WaitForString(1000) == -1)
            {
                NotificationCenter.DefaultCenter().Notification2Log(0, "Pulsar 2 :Read Pulsar Calibration Time failed!\r\n");
            }
            else
            {
                if (m_lightdata.ParseValue(m_Buffer) == 0)
                {
                    m_Buffer.Clear();
                }
            }

        }
        /// <summary>
        /// 接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReceive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //lock (lockobject)
            {
                int bytes = this.BytesToRead;
                if (bytes <= 0)
                {
                    return;
                }
                byte[] buf = new byte[bytes];
                this.Read(buf, 0, bytes);
                m_Buffer.AddRange(buf);
            }
        }

        //设置和获取串口参数
        public string Setting
        {
            get
            {
                UInt32 baudRate = Convert.ToUInt32(this.BaudRate);
                string p;
                switch (Parity)
                {
                    case Parity.Mark:
                        p = "M";
                        break;
                    case Parity.None:
                        p = "N";
                        break;
                    case Parity.Odd:
                        p = "O";
                        break;
                    case Parity.Even:
                        p = "E";
                        break;
                    case Parity.Space:
                        p = "S";
                        break;
                    default:
                        p = "N";
                        break;
                }

                return string.Format("{0},{1},{2},{3}", BaudRate, p, DataBits, Convert.ToUInt32(StopBits));
            }
            set
            {
                string[] values = value.Split(',');
                if (values.Length <= 3)
                {
                    throw new Exception("Serial port, invalid com setting!");
                }
                BaudRate = Convert.ToInt32(values[0]);
                DataBits = Convert.ToInt32(values[2]);
                StopBits = (StopBits)Convert.ToInt32(values[3]);
                string p = values[1].ToUpper();

                if (p == "O")
                {
                    Parity = Parity.Odd;
                }
                else if (p == "E")
                {
                    Parity = Parity.Even;
                }
                else if (p == "M")
                {
                    Parity = Parity.Mark;
                }
                else if (p == "S")
                {
                    Parity = Parity.Space;
                }
                else
                {
                    Parity = Parity.None;
                }
            }
        }

        public string PulsarSN
        {
            get
            {
                return m_SN;
            }
            set
            {
                m_SN = value;
            }
        }
        
        /// <summary>
        /// 读取反馈回来的数据
        /// </summary>
        /// <returns></returns>

        //设置需要等待的字符串
        public int SetDetectString(string strDectect)
        {
            m_strSerialWait = strDectect;
            ClearBuffer();
            return 0;
        }

        //写串口，这个实际上是为了保持接口一致写的
        public void WriteString(string str)
        {
            CheckAndConnect();
            if (IsOpen)
            {
                Write(str);
            }
        }

        public string ReadString()
        {
            if (!IsOpen)
                return null;
            return ReadInputBuffer();
        }

        public int WaitForString(int iTimeout)
        {
            return WaitDetect(iTimeout);
        }
        //开始等待设置的字符串出现,默认30s超时
        public int WaitDetect()
        {
            return WaitDetect(30000);
        }

        //开始等待设置的字符串出现
        public int WaitDetect(int iTimeOut)
        {
            //lock (lockobject)
            {
                if (m_strSerialWait.Length == 0) return 1;
                int start = System.Environment.TickCount;
                while (true&&IsOpen)
                //while (System.Threading.Thread.CurrentThread.ThreadState == System.Threading.ThreadState.Running)
                {
                    int now = System.Environment.TickCount;
                    if ((now - start) > iTimeOut)
                    {
                        return -1;    //timeout
                    }
                    //string buf = m_strBuf.ToString();
                    string buf = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());

                    if (buf.IndexOf(m_strSerialWait) >= 0)
                    {
                        break;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
            }
            return 0;
        }

        //设置并等待
        public int WaitString(string strDetect)
        {
            this.SetDetectString(strDetect);
            return WaitDetect();
        }

        public int WaitString(string strDetect, int iTimeOut)
        {
            this.SetDetectString(strDetect);
            return WaitDetect(iTimeOut);
        }

        //清空缓存
        public int ClearBuffer()
        {
            m_Buffer.Clear();
            return 0;
        }

        //获取缓冲区
        public string ReadInputBuffer()
        {
            string buf = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());
            m_Buffer.Clear();
            return buf;
        }

        public bool CheckPulasrSN()
        {
            string str = "Read Pulsar Board SN";
            SetDetectString("@_@");
            WriteString(str);
            WaitForString(200);
            string ret = ReadString();
            if (ret.CompareTo("This command is illegal ,please check it again") == 0)
                return false;
            else
            {
                return true;
            }
        }

        public int Close_LED(string side,int nindex)
        {
            SetDetectString("@_@");
            CheckAndConnect();
            if (!IsOpen)
                return -1;
            if (side == "Left")
            {
                byte[] data = { (byte)'C', (byte)'l', (byte)'o', (byte)'s',(byte)'e', (byte)' ', (byte)'t',
                                 (byte)'h', (byte)'e', (byte)' ', (byte)'L', (byte)'e', (byte)'f',                                                                                     (byte)'t',(byte)' ',(byte)'L',(byte)'E',(byte)'D',
                                 (byte)':', (byte)nindex, (byte)'\r', (byte)'\n' };
                Write(data, 0, 22);
                if (WaitForString(200) != -1)
                {
                    string str = ReadString().ToLower();
                    if (str.IndexOf("close the left led") != -1)
                    {
                        if (str.IndexOf("finish") != -1)
                        {
                            NotificationCenter.DefaultCenter().Notification2Log(0,
                               "Pulsar 2 :Close the LEFT LED:" + nindex.ToString() + "  " + " Success" + "\r\n");
                            return 0;
                        }
                        else
                        {
                            NotificationCenter.DefaultCenter().Notification2Log(0,
                                "Pulsar 2 :Close the LEFT LED:" + nindex.ToString() + "  " + " Faild" + "\r\n");
                            return -1;
                        }
                    }
                }
                else
                {
                    NotificationCenter.DefaultCenter().Notification2Statue(0,
                        "Pulsar 2 :Close the LEFT LED:" + nindex.ToString() + " TimeOut!");
                    return -1;
                }
            }
            else
            {
                //todo add right
            }
            return -1;
        }

        public int Write_LEDData(string side, int nindex, int nvalue)
        {
            CheckAndConnect();
            if (!IsOpen)
            {
                return -1;
            }
            try
            {
                if (side == "Left")
                {
                    byte[] data = { (byte)'O', (byte)'p', (byte)'e', (byte)'n',(byte)' ', (byte)'L', (byte)'e',
                                      (byte)'f', (byte)'t', (byte)' ', (byte)'L', (byte)'E', (byte)'D',
                                      (byte)':', (byte)nindex, (byte)' ', (byte)(nvalue >> 8), (byte)nvalue, 
                                      (byte)'\r', (byte)'\n' };
                    Write(data, 0, 20);
                    if (WaitForString(200) != -1)
                    {
                        string str = ReadString().ToLower();
                        if (str.IndexOf("open left led") != -1)
                        {
                            if (str.IndexOf("finish") != -1)
                            {
                                NotificationCenter.DefaultCenter().Notification2Log(0,
                                   "Pulsar 2 :OPEN LEFT LED:" + nindex.ToString() + "  " + nvalue.ToString() + " Success" + "\r\n");
                                return 0;
                            }
                            else
                            {
                                NotificationCenter.DefaultCenter().Notification2Log(0,
                                    "Pulsar 2 :OPEN LEFT LED:" + nindex.ToString() + "  " + nvalue.ToString() + " Faild" + "\r\n");
                                return -1;
                            }
                        }
                    }
                    else
                    {
                        NotificationCenter.DefaultCenter().Notification2Statue(0,
                        "Pulsar 2 :OPEN LEFT LED:" + nindex.ToString() + " TimeOut!");
                    }
                }
                else
                {
                    byte[] data = { (byte)'O', (byte)'p', (byte)'e', (byte)'n',(byte)' ', (byte)'R', (byte)'i', 
                                      (byte)'g',(byte)'h', (byte)'t', (byte)' ', (byte)'L', (byte)'E', 
                                      (byte)'D', (byte)':', (byte)nindex, (byte)' ', (byte)(nvalue >> 8),
                                      (byte)nvalue, (byte)'\r', (byte)'\n' };
                    Write(data, 0, 21);
                    return 0;
                }
            }
            catch (Exception e)
            {
                NotificationCenter.DefaultCenter().Notification2Statue(0,"ALSC2写入失败" + e.Message);
                return -1;
            }
            return -1;
        }

        /// <summary>
        /// 获取亮度值
        /// </summary>
        /// <param name="side"></param>
        /// <param name="nindex"></param>
        /// <returns></returns>
        public int Get_lightValue(string side, int nindex)
        {
           return  m_lightdata.GetDataByIndex(side, nindex);
        }

        public void Set_lightValue(string side,int nindex,int nvalue)
        {
            m_lightdata.SetDataByIndex(side, nindex, nvalue);
        }
        public int Write_lightCalibData(string side)
        {
            CheckAndConnect();
            List<byte> bytearray=  m_lightdata.BuildArrayData(side);
            SetDetectString("@_@");
            Write(bytearray.ToArray(),0,bytearray.Count());
            if (WaitForString(100) == -1)
            {
                Write(bytearray.ToArray(), 0, bytearray.Count());
            }
            return 0;
        }
        public bool IsNeedCalibration(int ndaygrap)
        {
            TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts2 = new TimeSpan(m_lightdata.m_dt.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if (ts.Days > ndaygrap)
            {
                return true;
            }
            return false;
        }

        public int Write_lightCalibDate()
        {
            CheckAndConnect();
            DateTime dt = DateTime.Now;
            int nvalue =(int) GT_Function.ConvertDateTimeInt(dt);
            string str = nvalue.ToString("x");
            SetDetectString("@_@");
            WriteString("Write Pulsar Calibration Time:" + str + "\r\n");
            if (WaitForString(100) != -1)
            {
                string ret = ReadString();
                if (ret.IndexOf("Write Pulsar Calibration Time:") != -1
                    && ret.IndexOf("Finish") != -1)
                {
                    m_lightdata.m_dt = dt;
                }
                else
                {
                    WriteString("Write Pulsar Calibration Time:" + str + "\r\n");
                }
            }
            else
            {
                WriteString("Write Pulsar Calibration Time:" + str + "\r\n");
            }
            return 0;
        }

        public void CheckAndConnect()
        {
            try
            {
                if (!IsOpen)
                    Open();
            }
            catch (Exception ex)
            {
                NotificationCenter.DefaultCenter().Notification2Statue(0, "ALSC-2打开失败" + ex.Message + "(E0003)");
            }
        }
    }
}
