using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace EEBroadController
{
    public class EEBroadController:SerialPort
    {
        static object lockobject =new object();
        protected string m_strSerialWait = "";  //需要等待的字符串
        protected List<byte> m_Buffer = new List<byte>();
        public int m_UUTID  = 0;
        public int dut = 0;
        public Engine m_TestEngine;

        public static bool[] UUT_READY_UP = new bool[] { true, true, true, true, true, true };
        public static bool[] UUT_READ_UP_COPY = new bool[] { true, true, true, true, true, true };
        public static bool[] UUT_READY_DOWN = new bool[] { false, false, false, false, false, false };
        public static bool[] UUT_READY_DOWN_COPY = new bool[] { false, false, false, false, false, false };

        public EEBroadController()
        {

        }
        /// <summary>
        /// 通过UUTID来初始化这个值，用于区分不同的UUT
        /// </summary>
        /// <param name="nuutid"></param>
        public EEBroadController(int nuutid)
        {
            m_UUTID = nuutid;
        }

        public void SetDut(int index)
        {
            dut = index;
        }

        public int GetDut()
        {
            return dut;
        }

      

        public static string MakeConfigString(string str,int nid)
        {
            if (nid == 0||nid == -1)
            {
                return str;
            }
            return str + string.Format("{0}", nid);
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
                if (GT_EEBroadController.mConfigInfo.ContainsKey(MakeConfigString(tmMarcos.kFixtureConfig, m_UUTID)))
                    this.Setting = GT_EEBroadController.mConfigInfo[MakeConfigString(tmMarcos.kFixtureConfig, m_UUTID)].ToString();
                else
                {
                    this.Setting = "115200,N,8,1";
                    GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureConfig] = Setting;
                }
                if (GT_EEBroadController.mConfigInfo[MakeConfigString(tmMarcos.kFixtureCom, m_UUTID)] != null)
                    PortName = GT_EEBroadController.mConfigInfo[
                        MakeConfigString(tmMarcos.kFixtureCom, m_UUTID)].ToString();
            }
            catch (Exception)
            {
            }
            this.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.OnReceive);
            Encoding = System.Text.Encoding.UTF8;
        }

        public void SaveConfig(string com,string config)
        {
            GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureCom] = com;
            if (config.Length > 0)
                GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureConfig] = config;
            GT_EEBroadController.mConfigInfo.WriteXml(GT_EEBroadController.mCfgFilePath);
        }

        /// <summary>
        /// 用于触发面板的StartButton
        /// </summary>
        /// 
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
                    TestContext context = GT_EEBroadController.GetTestContext(i);
                    string sn = context.m_dicContext[tmMarcos.kContextMLBSN] as string;
                    if (sn == null)
                    {
                        return true;
                    }

                    if (sn.Trim().Length == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void DetectStartString()
        {
            ConfigDlg configdlg = new ConfigDlg();
            string str = System.Text.Encoding.UTF8.GetString(m_Buffer.ToArray());
            if (str.IndexOf("START") != -1)
            {
                //if (str.IndexOf("START_A") != -1)
                //{
                //    SetDut(0);
                //}
                //else if (str.IndexOf("START_B") != -1)
                //{
                //    SetDut(1);
                //}
                SetDut(0);
                ClearBuffer();
                DictionaryEx dic = new DictionaryEx();
                dic["id"] = -1;
                if (GT_EEBroadController.m_TestEngine.IsTesting(-1) == 0)
                {
                    if (NeedScanSN())
                    {
                        System.Windows.Forms.MessageBox.Show("Please scan the SN firstly!");
                        WriteString("fixture_reset\r\n");
                    }
                    else
                    {
                        //configdlg.bnwork_Click(null, null);
                        NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnStartTest, dic);   
                    }
                }
            }

            else if (str.ToUpper().IndexOf("RESET") != -1)
            {
                ClearBuffer();
                ScriptEngine se = GT_EEBroadController.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
                se.DoString("Perfrom_C28StopTest()");
                System.Threading.Thread.Sleep(500);  
                GT_EEBroadController.m_TestEngine.StopTest(-1);
            }
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
                System.Windows.Forms.MessageBox.Show("打开Ctrl Broad 失败 " + e.Message + "(E0004)");
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
                if (GT_EEBroadController.m_TestEngine.m_testStop)
                {
                    return -1;
                }
                int now = System.Environment.TickCount;
                if ((now - start) > iTimeOut)
                    return -1;    //timeout
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
            if (IsOpen)
            {
                //m_Buffer.Clear();
                System.Threading.Thread.Sleep(50);
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

        public void CheckAndConnect()
        {
            try
            {
                if (!IsOpen)
                {
                    Open();
                }
            }
            catch (Exception ex)
            {
                NotificationCenter.DefaultCenter().Notification2Statue(0, "Ctrl broad打开失败" + ex.Message + "(E0004)");
            }
        }
        public int SafeWrite(string str)
        {
            if (GT_EEBroadController.m_TestEngine.IsTesting(-1) == 0)
            {
                WriteString(str);
                return 0;
            }
            return -1;
        }

        public void FixtureUp(int index)
        {
            UUT_READY_UP[index] = false;
            for (int i = 0; i <= 5; i++)
            {
                if (UUT_READY_UP[i])
                    return;
            }
            //Lex: Write the reset string here.
            //     To more safe you need to check if 
            
            WriteString("fixture_reset\r\n");
            for (int i = 0; i <= 5; i++)
            {
                UUT_READY_UP[i] = UUT_READ_UP_COPY[i];
            }
        }

        public void UpdateCopy(int nindex, bool bvalue)
        {
            UUT_READY_UP[nindex] = bvalue;
            UUT_READ_UP_COPY[nindex] = bvalue;
        }
    }
}
