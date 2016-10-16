using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LuaInterface;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using tcpServer;

namespace DataPusher
{
    public class GT_DataPusher : IModule
    {
        static public Engine m_TestEngine;
        static public TcpServer m_object;

        public GT_DataPusher()
        {
            m_object = new TcpServer();
        }

        public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            m_TestEngine = dic["engine"] as Engine;

            int slot = (int)dic["slot"];
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnUiLoadFinish, OnUiLoadFinish);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnUiUnLoad,OnUiUnLoad);
            return 0;
        }
        public int RegisterModule(object sender, object arg)
        {
            for (int i = 0; i < m_TestEngine.GetEngineCore(null); i++)
            {
                ScriptEngine se = m_TestEngine.GetScriptEngine(i) as ScriptEngine;
                Lua lua = se.GetScriptHandle() as Lua;
                lua["DataPusher"] = m_object;
                se.DoString(" dp= require \"DataPushers\"");
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
            m_object.Close();
            return 0;
        }

        int OnUiLoadFinish(Notification nf)
        {
            DictionaryEx dic = nf.context as DictionaryEx;
            ToolStripMenuItem instr = dic["instr"] as ToolStripMenuItem;
            instr.DropDownItems.Add("DataPusher Debug", null, new EventHandler(OnConfig));

            if (!m_object.IsOpen)
            {
                m_object.Close();
                m_object.Port = 10086;
                m_object.Open();

            }
            return 0;
        }

        int OnUiUnLoad(Notification nf)
        {
            if (m_object != null)
            {
                m_object.Close();
            }
            return 0;
        }

        protected void OnConfig(object sender, EventArgs args)
        {
            ServerFrom configDlg = new ServerFrom();
            configDlg.ShowDialog();
            if (configDlg.DialogResult == DialogResult.OK)
            {

            }
        }
    }
}
