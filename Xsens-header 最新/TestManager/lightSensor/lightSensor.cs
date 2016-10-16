using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace lightSensor
{
    public class lightSensor:SerialPort
    {
        static object lockobject =new object();
        protected string m_strSerialWait = "";  //需要等待的字符串
        protected List<byte> m_Buffer = new List<byte>();
        int m_nlastlightvalue = 0;

        public lightSensor()
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
                if (GT_lightSensor.mConfigInfo.ContainsKey(tmMarcos.kSensor1Config))
                    this.Setting = GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Config].ToString();
                else
                {
                    this.Setting = "115200,N,8,1";
                    GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Config] = Setting;
                }
                if (GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Com] != null)
                    PortName = GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Com].ToString();
            }
            catch (Exception)
            {
            }
            Encoding = System.Text.Encoding.UTF8;
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnReceive);
        }

        /// <summary>
        /// 接受事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReceive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int bytes = this.BytesToRead;
            if (bytes <= 0)
            {
                return;
            }
            byte[] buf = new byte[bytes];
            this.Read(buf, 0, bytes);
            m_Buffer.AddRange(buf);
            ParseLightValue(m_Buffer);   
        }


        public int  ParseLightValue(List<byte> data)
        {
            try
            {
                string str = System.Text.Encoding.UTF8.GetString(data.ToArray()).ToLower();
                if (str.IndexOf("read sensor value ch0:") != -1)
                {
                    int nindex = str.IndexOf(':');
                    if (nindex + 1 + 5 < str.Length)
                    {
                        string valuestr = str.Substring(nindex + 1, 5);
                        if (valuestr != null)
                        {
                            m_nlastlightvalue = Convert.ToInt32(valuestr);
                            return m_nlastlightvalue;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return 0;
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
        
        //设置需要等待的字符串
        public int SetDetectString(string strDectect)
        {
            m_strSerialWait = strDectect;
            ClearBuffer();
            return 0;
        }


        //开始等待设置的字符串出现,默认30s超时
        public int WaitDetect()
        {
            return WaitDetect(30000);
        }

        //开始等待设置的字符串出现
        public int WaitDetect(int iTimeOut)
        {
            if (m_strSerialWait.Length == 0) return 1;
            int start = System.Environment.TickCount;
            while (true&IsOpen)
            //while (System.Threading.Thread.CurrentThread.ThreadState == System.Threading.ThreadState.Running)
            {
                int now = System.Environment.TickCount;
                if ((now - start) > iTimeOut)
                    return -1;    //timeout
                string buf = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());

                if (buf.IndexOf(m_strSerialWait) >= 0)
                {
                    //Console.WriteLine("------->Read need time {0}\n",now-start);
                    break;
                }
                System.Windows.Forms.Application.DoEvents();
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
            string buf = System.Text.Encoding.ASCII.GetString(m_Buffer.ToArray());
            m_Buffer.Clear();
            return buf;
        }

        //写串口，这个实际上是为了保持接口一致写的
        public void WriteString(string str)
        {
            CheckAndConnect();
            if(IsOpen)
                Write(str);
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

        public int GetLightValue()
        {
            return m_nlastlightvalue;
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
                NotificationCenter.DefaultCenter().Notification2Statue(0, "Sensor 1 打开失败" + ex.Message + "(E0006)");
            }
        }

        public void DoConnect()
        {
            try
            {
                if (IsOpen) Close();
                Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("打开Sensor 1 失败 " + e.Message + "(E0006)");
            }
        }
    }
}
