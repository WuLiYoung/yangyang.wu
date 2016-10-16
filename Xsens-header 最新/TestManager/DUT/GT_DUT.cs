using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.Windows.Forms;

namespace DUT
{
    class GT_DUT:IModule
    {
        static public Engine m_TestEngine;
        public static DUTController mm_object;
        public static DUTController[] m_object = new DUTController[6] { new DUTController(), new DUTController(), new DUTController(), new DUTController(), new DUTController(), new DUTController() };
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");
        public GT_DUT()
        {
            Init();
            mm_object = new DUTController();
 /*           for (int i = 0; i < 6;i++ )
            {
                //should iniital serial port in here.
                //you should read configuration file and initia the comport
                m_object[i].Open("", "38400,n,8,1");
            }
*/
        }

        public void Init() {
            try
            {
                m_object[0].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kDUT1Config))
                    m_object[0].m_ComPort.Setting = mConfigInfo[tmMarcos.kDUT1Config].ToString();
                else
                    mConfigInfo[tmMarcos.kDUT1Config] = "38400,N,8,1";
                if (mConfigInfo[tmMarcos.kDUT1Com] != null)
                    m_object[0].m_ComPort.PortName = mConfigInfo[tmMarcos.kDUT1Com].ToString();
                m_object[0].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM1 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[1].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kDUT2Config))
                    m_object[1].m_ComPort.Setting = mConfigInfo[tmMarcos.kDUT2Config].ToString();
                else
                    mConfigInfo[tmMarcos.kDUT2Config] = "38400,N,8,1";
                if (mConfigInfo[tmMarcos.kDUT2Com] != null)
                    m_object[1].m_ComPort.PortName = mConfigInfo[tmMarcos.kDUT2Com].ToString();
                m_object[1].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM2 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[2].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kDUT3Config))
                    m_object[2].m_ComPort.Setting = mConfigInfo[tmMarcos.kDUT3Config].ToString();
                else
                    mConfigInfo[tmMarcos.kDUT3Config] = "38400,N,8,1";
                if (mConfigInfo[tmMarcos.kDUT3Com] != null)
                    m_object[2].m_ComPort.PortName = mConfigInfo[tmMarcos.kDUT3Com].ToString();
                m_object[2].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM3 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[3].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kDUT4Config))
                    m_object[3].m_ComPort.Setting = mConfigInfo[tmMarcos.kDUT4Config].ToString();
                else
                    mConfigInfo[tmMarcos.kDUT4Config] = "38400,N,8,1";
                if (mConfigInfo[tmMarcos.kDUT4Com] != null)
                    m_object[3].m_ComPort.PortName = mConfigInfo[tmMarcos.kDUT4Com].ToString();
                m_object[3].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM4 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[4].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kDUT5Config))
                    m_object[4].m_ComPort.Setting = mConfigInfo[tmMarcos.kDUT5Config].ToString();
                else
                    mConfigInfo[tmMarcos.kDUT5Config] = "38400,N,8,1";
                if (mConfigInfo[tmMarcos.kDUT5Com] != null)
                    m_object[4].m_ComPort.PortName = mConfigInfo[tmMarcos.kDUT5Com].ToString();
                m_object[4].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM5 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[5].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kDUT6Config))
                    m_object[5].m_ComPort.Setting = mConfigInfo[tmMarcos.kDUT6Config].ToString();
                else
                    mConfigInfo[tmMarcos.kDUT6Config] = "38400,N,8,1";
                if (mConfigInfo[tmMarcos.kDUT6Com] != null)
                    m_object[5].m_ComPort.PortName = mConfigInfo[tmMarcos.kDUT6Com].ToString();
                  m_object[5].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM6 Fail " + e.Message + "(E0005)");
            }
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
                l["DUT"] = m_object[i];
                se.DoString("dut= require \"dut\"");
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
            // if (m_object.IsOpen)
            //    m_object.Close();
            return 0;
        }

        int OnUiLoadFinish(Notification nf)
        {
            DictionaryEx dic = nf.context as DictionaryEx;
            ToolStripMenuItem instr = dic["instr"] as ToolStripMenuItem;
            instr.DropDownItems.Add("DUT Config", null, new EventHandler(OnConfig));
         //   Init();
            return 0;
        }

        private static void ConnectCom()
        {
            try
            {
                m_object[0].CloseSerial();
                m_object[0].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM1 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[1].CloseSerial();
                m_object[1].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM2 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[2].CloseSerial();
                m_object[2].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM3 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[3].CloseSerial();
                m_object[3].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM4 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[4].CloseSerial();
                m_object[4].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM5 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[5].CloseSerial();
                m_object[5].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open DUTCOM6 Fail " + e.Message + "(E0005)");
            }
        }

        protected void OnConfig(object sender, EventArgs args)
        {

            DUTCfg configdlg = new DUTCfg();
          //  configdlg.UpdateByLightData(m_object.m_lightdata);
            configdlg.ShowDialog();
            if (configdlg.DialogResult == DialogResult.OK)
            {
                //Init();
                ConnectCom();
            }
             
        }


    }
}
