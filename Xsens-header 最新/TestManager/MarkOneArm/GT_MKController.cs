using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;
using System.IO;
using System.Windows.Forms;

namespace MKoneController
{
    class GT_MKController : IModule
    {
        static public Engine m_TestEngine;
        public static MKoneFCT[] m_object = new MKoneFCT[6] { new MKoneFCT(), new MKoneFCT(), new MKoneFCT(), new MKoneFCT(), new MKoneFCT(), new MKoneFCT() };
        public static DictionaryEx mConfigInfo = TestContext.m_dicConfig;
        public static string mCfgFilePath = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");

        public GT_MKController()
        {
            //Init();
 
 /*           for (int i = 0; i < 6;i++ )
            {
                //should iniital serial port in here.
                //you should read configuration file and initia the comport
                m_object[i].Open("", "115200,n,8,1");
            }
*/
        }

        public void Init() {
            try
            {
                m_object[0].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kArm1Config))
                    m_object[0].m_ComPort.Setting = mConfigInfo[tmMarcos.kArm1Config].ToString();
                else
                    mConfigInfo[tmMarcos.kArm1Config] = "115200,N,8,1";
                if (mConfigInfo[tmMarcos.kArm1Com] != null)
                    m_object[0].m_ComPort.PortName = mConfigInfo[tmMarcos.kArm1Com].ToString();
                m_object[0].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM1 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[1].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kArm2Config))
                    m_object[1].m_ComPort.Setting = mConfigInfo[tmMarcos.kArm2Config].ToString();
                else
                    mConfigInfo[tmMarcos.kArm2Config] = "115200,N,8,1";
                if (mConfigInfo[tmMarcos.kArm2Com] != null)
                    m_object[1].m_ComPort.PortName = mConfigInfo[tmMarcos.kArm2Com].ToString();
                m_object[1].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM2 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[2].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kArm3Config))
                    m_object[2].m_ComPort.Setting = mConfigInfo[tmMarcos.kArm3Config].ToString();
                else
                    mConfigInfo[tmMarcos.kArm3Config] = "115200,N,8,1";
                if (mConfigInfo[tmMarcos.kArm3Com] != null)
                    m_object[2].m_ComPort.PortName = mConfigInfo[tmMarcos.kArm3Com].ToString();
                m_object[2].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM3 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[3].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kArm4Config))
                    m_object[3].m_ComPort.Setting = mConfigInfo[tmMarcos.kArm4Config].ToString();
                else
                    mConfigInfo[tmMarcos.kArm4Config] = "115200,N,8,1";
                if (mConfigInfo[tmMarcos.kArm4Com] != null)
                    m_object[3].m_ComPort.PortName = mConfigInfo[tmMarcos.kArm4Com].ToString();
                m_object[3].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM4 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[4].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kArm5Config))
                    m_object[4].m_ComPort.Setting = mConfigInfo[tmMarcos.kArm5Config].ToString();
                else
                    mConfigInfo[tmMarcos.kArm5Config] = "115200,N,8,1";
                if (mConfigInfo[tmMarcos.kArm5Com] != null)
                    m_object[4].m_ComPort.PortName = mConfigInfo[tmMarcos.kArm5Com].ToString();
                m_object[4].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM5 Fail " + e.Message + "(E0005)");
            }

            try
            {
                m_object[5].CloseSerial();
                if (mConfigInfo.ContainsKey(tmMarcos.kArm6Config))
                    m_object[5].m_ComPort.Setting = mConfigInfo[tmMarcos.kArm6Config].ToString();
                else
                    mConfigInfo[tmMarcos.kArm6Config] = "115200,N,8,1";
                if (mConfigInfo[tmMarcos.kArm6Com] != null)
                    m_object[5].m_ComPort.PortName = mConfigInfo[tmMarcos.kArm6Com].ToString();
                  m_object[5].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM6 Fail " + e.Message + "(E0005)");
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
                l["ArmBoard"] = m_object[i];
                se.DoString("armboard= require \"armboard\"");
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
            instr.DropDownItems.Add("ARM Config", null, new EventHandler(OnConfig));
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
                System.Windows.Forms.MessageBox.Show("Open ARMCOM1 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[1].CloseSerial();
                m_object[1].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM2 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[2].CloseSerial();
                m_object[2].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM3 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[3].CloseSerial();
                m_object[3].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM4 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[4].CloseSerial();
                m_object[4].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM5 Fail " + e.Message + "(E0005)");
            }
            try
            {
                m_object[5].CloseSerial();
                m_object[5].m_ComPort.Open();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Open ARMCOM6 Fail " + e.Message + "(E0005)");
            }
        }

        protected void OnConfig(object sender, EventArgs args)
        {

            ArmControllerCfg configdlg = new ArmControllerCfg();
          //  configdlg.UpdateByLightData(m_object.m_lightdata);
            configdlg.ShowDialog();
            if (configdlg.DialogResult == DialogResult.OK)
            {
                Init();
             //   ConnectCom();
            }
             
        }


    }
}
