using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using LuaInterface;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace DataLogger
{
    public class GT_DataLogger:IModule
    {
        public static Engine m_TestEngine;

        List<DataLogger> m_DataLogger=new List<DataLogger>();

        public GT_DataLogger()
        {

        }

        public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            m_TestEngine = dic["engine"] as Engine;

            int slot = (int)dic["slot"];
            for (int i = 0; i < slot;i++ )
            {
                DataLogger d = new DataLogger(i);
                m_DataLogger.Add(d);
            }

            return 0;
        }
        public int RegisterModule(object sender, object arg)
        {
            for (int i = 0; i < m_TestEngine.GetEngineCore(null); i++)
            {
                ScriptEngine se = m_TestEngine.GetScriptEngine(i) as ScriptEngine;
                Lua lua = se.GetScriptHandle() as Lua;
                lua["DataLogger"] = m_DataLogger[i];
                se.DoString("dl = require \"Logger\"");
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
