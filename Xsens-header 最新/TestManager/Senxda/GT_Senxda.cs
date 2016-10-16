using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.Windows.Forms;
using XDA;
namespace Senxda 
{
       
        class GT_Senxda :  IModule
        {
        //public XsDevice _measuringDevice = null;
        //public MyMtCallback _myMtCallback = null;
        //public ConnectedMtData _connectedData = new ConnectedMtData();
        static public Engine m_TestEngine;
        public static MyXda  m_object;
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");
        public GT_Senxda()
        {
            m_object = new MyXda();
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
                l["Senxda"] = m_object;
                se.DoString("senxda= require \"Senxda\"");
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
         
            return 0;
        }

        int OnUiLoadFinish(Notification nf)
        {
            DictionaryEx dic = nf.context as DictionaryEx;
            ToolStripMenuItem instr = dic["instr"] as ToolStripMenuItem;
            instr.DropDownItems.Add("Sensor Config", null, new EventHandler(OnConfig));
            //这个时候配置已经读取了
            //m_object.Init();
            //ConnectCom();
            return 0;
        }

        private static void ConnectCom()
        {
          //  m_object.DoConnect();
        }

        protected void OnConfig(object sender, EventArgs args)
        {
            Form1 configdlg = new Form1();
            configdlg.Show();
            if (configdlg.DialogResult == DialogResult.OK)
            {
              
            }
        }
    }
}

