using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.IO.Ports;
namespace TcpCon
{
    
    class GT_TCP : IModule
    {
       static private string portname = "169.254.01.01";
        //static private string portname = "127.0.0.02";
        static private int port = 5000;
        public static SerialPort[] spSerialPortArray = new SerialPort[6] { new SerialPort(), new SerialPort(), new SerialPort(), new SerialPort(), new SerialPort(), new SerialPort() };
        static public Engine m_TestEngine;
        static public TcpCon m_object;
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");
        public struct List_cmd
        {
            public string AxisKind;// 电机轴
            public int AxisNum;// 轴编号
            public int ActNum;//运动功能码
            public int ActLoc;//位置
            public int ActSpeed;//速度

        }
        public struct List_rec
        {
            public string AxisKind;//电机轴
            public int AxisNum;//轴编号
            public string ActCon;//动作状态
        }

        public GT_TCP()
        {
         
            m_object = new TcpCon(portname,port);

        }

          public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            m_TestEngine = dic["engine"] as Engine;
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnUiLoadFinish, OnUiLoadFinish);
           
           
            return 0;
        }

        public int RegisterModule(object sender, object arg)
        {
            for (int i = 0; i < m_TestEngine.GetEngineCore(null); i++)
            {
                ScriptEngine se = m_TestEngine.GetScriptEngine(i) as ScriptEngine;
                Lua l = se.GetScriptHandle() as Lua;
                //l["TcpCon"] = m_object;
                //se.DoString("Tcp= require \"TcpCon\"");
                l["TCP"] = m_object;
                se.DoString("tcp= require \"Tcp\"");
            }
            return 0;
        }

        public int Initial(object sender, object arg)
        {
            return 0;
        }

        public int SelfTest(object sender, object arg)
        {
            return 0;
        }

        public int UnLoad(object sender, object arg)
        {
            //if (m_object.IsOpen)
            //    m_object.Close();
            return 0;
        }

        int OnUiLoadFinish(Notification nf)
        {
            DictionaryEx dic = nf.context as DictionaryEx;
            ToolStripMenuItem instr = dic["instr"] as ToolStripMenuItem;
            instr.DropDownItems.Add("Tcp Config", null, new EventHandler(OnMCUConfig));

           
         //   ConnectCom();
            return 0;
        }

        private static void ConnectCom()
        {
            m_object.Connect_tcp(portname, port);
        }

        protected void OnMCUConfig(object sender, EventArgs args)
        {
            TCPDlg m_tcpdlg = new TCPDlg();
            m_tcpdlg.Show();
            if (m_tcpdlg.DialogResult == DialogResult.OK)
            {
            ConnectCom();
            }
        }
    }
}
