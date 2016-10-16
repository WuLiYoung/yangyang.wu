using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace Engine
{
    class GT_Engine:IModule
    {
        TestEngine m_TestEngine;
        public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            int module = (int)dic["module"];//  module=1 ,slot=2
            int thread = (int)dic["slot"];
            if (dic.ContainsKey("module"))
            {
                module = (int)dic["module"];
            }

            if (dic.ContainsKey("thread"))
            {
                thread = (int)dic["thread"];
            }
            
            m_TestEngine = new TestEngine(thread);
            dic["engine"]=m_TestEngine; //St
            return 0;
        }
        public int RegisterModule(object sender, object arg)
        {
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
    }
}
