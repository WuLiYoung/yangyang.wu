using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.Windows.Forms;

namespace A34972A
{
    public class GT_A34972A: IModule
    {
        static public Engine m_TestEngine;
        public static A34972A m_object; //应该实例多个UUT
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");

        public  GT_A34972A()
        {
            m_object=new A34972A();
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
                l["A34972A"] = m_object;
                se.DoString("A34972= require \"A34972As\"");
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
            instr.DropDownItems.Add("34972A Debug", null, new EventHandler(OnConfig));
            //这个时候配置已经读取了
            m_object.OpenRM();
            m_object.OpenSession(m_object.Device,m_object.resourceManager);
            return 0;
        }
        protected void OnConfig(object sender, EventArgs args)
        {
            A34972AFrom configDlg = new A34972AFrom();
            configDlg.ShowDialog();
            if (configDlg.DialogResult == DialogResult.OK)
            {
                
            }
        }
    }
}
