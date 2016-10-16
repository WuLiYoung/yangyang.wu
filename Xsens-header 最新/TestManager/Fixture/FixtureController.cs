using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace Fixture
{
  public class FixtureController:SerialPort
    {
        static object lockobject =new object();
      //  protected string m_Setting;
        protected string m_strSerialWait = "";  //需要等待的字符串
        protected List<byte> m_Buffer = new List<byte>();
        public static bool[] UUT_READY_UP = new bool[] { true, true, true, true, true, true };
        public static bool[] UUT_READ_UP_COPY = new bool[] { true, true, true, true, true, true };
        public static bool[] UUT_READY_DOWN = new bool[] { false, false, false, false, false, false };
        public static bool[] UUT_READY_DOWN_COPY = new bool[] { false, false, false, false, false, false };
        public FixtureController()
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
                if (GT_Fixture.mConfigInfo.ContainsKey(tmMarcos.kFixtureCom))
                    Setting = GT_Fixture.mConfigInfo[tmMarcos.kFixtureConfig].ToString();
                else
                {
                    this.Setting = "115200,N,8,1";
                    GT_Fixture.mConfigInfo[tmMarcos.kFixtureConfig] = Setting;
                }
                if (GT_Fixture.mConfigInfo[tmMarcos.kFixtureCom] != null)
                    PortName = GT_Fixture.mConfigInfo[tmMarcos.kFixtureCom].ToString();         
            }
            catch (Exception)
            {
            }
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnReceive);
            Encoding = System.Text.Encoding.UTF8;
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
            DetectStartString();
        }


      public static bool NeedScanSN()
        {
            if (!Convert.ToBoolean(TestContext.m_dicConfig[tmMarcos.kConfigScanBarcode]))
            {
                return false;
            }
            for (int i = 0; i < 6; i++)
            {
                string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                bool bEnable = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                if (bEnable)
                {
                    TestContext context = GT_Fixture.GetTestContext(i);
                    string sn = context.m_dicContext[tmMarcos.kContextMLBSN] as string;
                    if (sn==null)
                    {
                        return true;
                    }

                    if ( sn.Trim().Length== 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        /// 用于触发面板的StartButton
        public void DetectStartString()
        {
            string str = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());
            if (str.IndexOf("Test Start\r\n") != -1)
            {
                for (int j = 0; j <= 5; j++)
                {
                    UUT_READY_DOWN[j] = true;
                }

                ClearBuffer();
                if (NeedScanSN())
                {
                    System.Windows.Forms.MessageBox.Show("Please scan the SN firstly!");
                    WriteString("fixture_reset\r\n");
                }
                else
                {
                    GT_Fixture.m_TestEngine.StartTest(-1);
                }
              //  DictionaryEx dic = new DictionaryEx();
              //  dic["id"] = 0;
              //  NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnStartTest, dic);
            }

            if (str.IndexOf("Tray out pass\r\n") != -1)
            {
                ClearBuffer();
                ResetDownStatus();
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
            if (m_strSerialWait.Length == 0||!IsOpen) 
                return 1;
            int start = System.Environment.TickCount;
            while (true)
            //while (System.Threading.Thread.CurrentThread.ThreadState == System.Threading.ThreadState.Running)
            {
                int now = System.Environment.TickCount;
                if ((now - start) > iTimeOut)
                    return -1;    //timeout
                //string buf = m_strBuf.ToString();
                string buf = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());

                if (buf.IndexOf(m_strSerialWait) >= 0)
                {
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
            string buf = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());
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

        public void DoConnect()
        {
            try
            {
                if (IsOpen)
                    Close();
                Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open Fixture COM Fail " + e.Message + "(E0005)");
            }
        }

        public void CheckAndConnect()
        {
            try
            {
                if (IsOpen) Close();
                Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open Fixture COM fail " + e.Message + "(E0005)");
            }
        }
        public void FixtureUp(int index)
        {
            UUT_READY_UP[index] = false;
            for (int i = 0; i <= 5; i++)
            {
                if (UUT_READY_UP[i])
                    return;
            }

            WriteString("Tray putout\r\n");
            for (int i = 0; i <= 5; i++)
            {
                UUT_READY_UP[i] = UUT_READ_UP_COPY[i];
            }
            ResetDownStatus();
        }

        public void ResetDownStatus()
        {
            for (int i = 0; i <= 5; i++)
            {
                UUT_READY_DOWN[i] = UUT_READY_DOWN_COPY[i];
            }
        }

        public void FixtureDown(int index)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (UUT_READY_DOWN[i])
                    return;
            }
            UUT_READY_DOWN[index] = true;
            WriteString("Tray putin\r\n");
        }

    }
}
