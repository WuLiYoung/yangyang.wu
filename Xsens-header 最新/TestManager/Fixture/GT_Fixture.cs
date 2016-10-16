using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.Windows.Forms;

namespace Fixture
{
    class GT_Fixture: IModule
    {
        static public Engine m_TestEngine;
        public static FixtureController  m_object;
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");

        public GT_Fixture()
        {
            m_object = new FixtureController();
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
                l["FIXTURE"] = m_object;
                se.DoString("fixture= require \"Fixture\"");
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
            instr.DropDownItems.Add("Fixture Config", null, new EventHandler(OnMCUConfig));

            m_object.Init();
            return 0;
        }

        private static void ConnectCom()
        {
             m_object.DoConnect();
        }

        protected void OnMCUConfig(object sender, EventArgs args)
        {
         
            Fixture configdlg = new Fixture();
          //  configdlg.UpdateByLightData(m_object.m_lightdata);
            configdlg.ShowDialog();
            if (configdlg.DialogResult == DialogResult.OK)
            {
                m_object.Init();
                ConnectCom();
            }
            
        }
        public static TestContext GetTestContext(int nid)
        {
            return m_TestEngine.GetTestContext(nid) as TestContext;
        }
    }
}
