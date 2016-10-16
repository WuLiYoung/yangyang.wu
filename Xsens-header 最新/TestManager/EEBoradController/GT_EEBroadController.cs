using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.Windows.Forms;


namespace EEBroadController
{
    public class GT_EEBroadController : IModule
    {
        static public Engine m_TestEngine;
        public static EEBroadController  m_object; //应该实例多个UUT
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");

        public GT_EEBroadController()
        {
            m_object = new EEBroadController();
        }

        public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            m_TestEngine = dic["engine"] as Engine;
            m_object.m_TestEngine = m_TestEngine;
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnUiLoadFinish, OnUiLoadFinish);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnUUTEnableChange, OnUUTEnableChange);
            return 0;
        }
        
        public int RegisterModule(object sender, object arg)
        {
            for (int i = 0; i < m_TestEngine.GetEngineCore(null); i++)
            {
                ScriptEngine se = m_TestEngine.GetScriptEngine(i) as ScriptEngine;
                Lua l = se.GetScriptHandle() as Lua;
                l["EEBroad"] = m_object;
                se.DoString("fixture= require \"EEBroadController\"");
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
            if (m_object.IsOpen)
                m_object.Close();
            return 0;
        }

        int OnUiLoadFinish(Notification nf)
        {
            DictionaryEx dic = nf.context as DictionaryEx;
            ToolStripMenuItem instr = dic["instr"] as ToolStripMenuItem;
            instr.DropDownItems.Add("CTRL Config", null, new EventHandler(OnConfig));
            //这个时候配置已经读取了
            m_object.Init();
            ConnectCom();
            return 0;
        }

        public int OnUUTEnableChange(Notification nf)
        {
            DictionaryEx dic = nf.context as DictionaryEx;
            int id = (int)dic["id"];
            bool bvalue = (bool)dic["value"];
            //m_object.UpdateFixtureUpCopy(id,bvalue);
            return 0;
        }

        private static void ConnectCom()
        {
            m_object.DoConnect();
        }

        protected void OnConfig(object sender, EventArgs args)
        {
            ConfigDlg configdlg = new ConfigDlg();
            configdlg.comname = mConfigInfo[tmMarcos.kFixtureCom] as string;
            configdlg.config = mConfigInfo[tmMarcos.kFixtureConfig] as string;
            configdlg.ShowDialog();
            if (configdlg.DialogResult == DialogResult.OK)
            {
                m_object.SaveConfig(configdlg.comname, configdlg.config);
                m_object.Init();
                ConnectCom();
            }
        }

        public void DoCommand(string command)
        {
            m_object.WriteString(command);
        }

        public static TestContext GetTestContext(int nid)
        {
            return m_TestEngine.GetTestContext(nid) as TestContext;
        }
    }
}
