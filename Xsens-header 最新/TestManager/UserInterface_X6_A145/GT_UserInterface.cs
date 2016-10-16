using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Interface;
using TestStudio.Automation.TestManager.libCommon.Class;

using LuaInterface;

namespace UserInterface
{
    class GT_UserInterface:IModule
    {        
        public static Engine m_TestEngine;
        static UserInterface m_UI=new UserInterface();
        public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            m_TestEngine= dic["engine"] as Engine;
            NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Loading user interface...");
            MainForm frm = new MainForm(arg);
            frm.Show();
            NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Load user interface successful...");
            return 0;
        }
        public int RegisterModule(object sender, object arg)
        {
            for (int i = 0; i < m_TestEngine.GetEngineCore(null);i++)
            {
                ScriptEngine se = m_TestEngine.GetScriptEngine(i) as ScriptEngine;
                Lua l = se.GetScriptHandle() as Lua;
                l["UI"] = m_UI;
                l.DoString("ui = require \"ui\"");
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

        public static TestContext GetTestContext(int nid)
        {
            return m_TestEngine.GetTestContext(nid) as TestContext;
        }
    }
}
