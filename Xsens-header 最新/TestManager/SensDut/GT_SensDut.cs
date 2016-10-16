using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.IO.Ports;
namespace SensDut
{
    public class GT_SensDut : IModule
    {
  
        static public Engine m_TestEngine;
        static public KbootPacketDecoder m_object;
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");
        public static IMUData[] UranusDataArray = new IMUData[6] { new IMUData(), new IMUData(), new IMUData(), new IMUData(), new IMUData(), new IMUData() };
        public static SerialPort[] spSerialPortArray = new SerialPort[6] { new SerialPort(), new SerialPort(), new SerialPort(), new SerialPort(), new SerialPort(), new SerialPort() };       
      

        public GT_SensDut()
        {
         
          //  m_object = new TcpCon(portname,port);

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
                l["SenDut"] = m_object;
                se.DoString("SenDut= require \"SensDut\"");
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
            instr.DropDownItems.Add("SensDut Config", null, new EventHandler(OnMCUConfig));

           
         //   ConnectCom();
            return 0;
        }

        private static void ConnectCom()
        {
           // m_object.Connect_tcp(portname,port);
        }

        protected void OnMCUConfig(object sender, EventArgs args)
        {
            MainForm m_tcpdlg = new MainForm();
            m_tcpdlg.Show();
            if (m_tcpdlg.DialogResult == DialogResult.OK)
            {
          //  ConnectCom();
            }
        }
    }
}

   