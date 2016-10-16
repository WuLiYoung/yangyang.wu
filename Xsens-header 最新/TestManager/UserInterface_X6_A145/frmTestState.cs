using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

using TestStudio.Automation.TestManager.libCommon.Class;


using WeifenLuo.WinFormsUI.Docking;
namespace UserInterface
{
    public partial class frmTestState : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private long m_tsStart = DateTime.Now.Ticks;
        private int m_looptime   = 0;
        private int m_timeneed2loop = 0;
        bool m_blooprun = false;
      
        public frmTestState()
        {
            InitializeComponent();
            this.AutoHidePortion = this.Width;
            //设置不检查跨线程处理
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmTestState_SizeChanged(object sender, EventArgs e)
        {
            return;
        }
        private void frmTestState_Load(object sender, EventArgs e)
        {
            ClearUUTSN();
            UpdateUUT_IDLE_Display();
            UpdateUUTCheckByEnableStatue();
            InitUIByUser();
            UpdateStationName();
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kTestFlowMessage,OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnGetSN, OnUiNotification);
        }

        public int OnUiNotification(Notification nf)
        {
            string name = nf.name;
            DictionaryEx dic = nf.context as DictionaryEx;
            int id = (int)dic["id"];
            if(name == tmMarcos.kTestFlowMessage)
            {
                string msg = dic["msg"] as string;
                if (msg != null)
                {
                    textBoxStatue.Text = msg;
                }
            }
            else if(name == tmMarcos.kOnGetSN)
            {
                string sn = dic[tmMarcos.kContextMLBSN] as string;
                this.SetUUTSN(id,sn);
            }
            return 0;
        }

        public void UpdateStationName()
        {
            if (TestContext.m_dicConfig[tmMarcos.kConfigStationName] != null)
            {
                lbStationname.Text = "Station:" + 
                    (TestContext.m_dicConfig[tmMarcos.kConfigStationName] as string);
            }
        }

        //export function
        public void OnNotifyShowTestStart(int index)
        {
            Label[] lblTitle = { lblStatus0, lblStatus1, lblStatus2, lblStatus3, lblStatus4, lblStatus5 };
            lblTitle[index].Text = string.Format("TESTING")+"\n"+GetUUTSN(index);
            lblTitle[index].BackColor = Color.Blue;

            StartTimeTick(index);
            m_tsStart = DateTime.Now.Ticks;
            textBoxStatue.Text = "";
            btnUnitStart.Enabled = false;
            bnUnitStop.Enabled = true;
        }

        public void OnNotifyShowTestFinish(int index,int result)
        {
            Label[] lblTitle = { lblStatus0,lblStatus1,lblStatus2,lblStatus3,lblStatus4,lblStatus5 };
            string strResult;
            Color color;
            if (result==0)
            {
                strResult = "FAIL";
                color = Color.Red;
                tmGlobalobj.Failcount++;    
            }
            else if (result==1)
            {
                strResult = "PASS";
                color = Color.Green;
                tmGlobalobj.PassCount++;
            }
            else if (result == 2)
            {
                strResult = "STOPPED";
                color = Color.Yellow;
                checkboxloop.Checked = false; //cancel the loop when is stop.
            }
            else
            {
                strResult = "ERROR";
                color = Color.Yellow;
            }
            lblTitle[index].Text = string.Format("{1}", index, strResult) + "\n" + GetUUTSN(index);
            lblTitle[index].BackColor = color;

            txtPass.Text = tmGlobalobj.PassCount.ToString();
            txtFail.Text = tmGlobalobj.Failcount.ToString();
            UpdatePassFailRate();
            StopTimeTick(index);

            if (checkboxloop.Checked == true)
            {
                m_blooprun = true;
            }
            //Clear it at the end.
            ClearUUTSN(index);
            btnUnitStart.Enabled = true;
        }

        private void UpdatePassFailRate()
        {
            txtPass.Text = tmGlobalobj.PassCount.ToString();
            txtFail.Text = tmGlobalobj.Failcount.ToString();
            int ntotal = tmGlobalobj.PassCount + tmGlobalobj.Failcount;
            if (ntotal != 0)
            {
                textBoxPassRate.Text = (tmGlobalobj.PassCount * 100 / ntotal).ToString() + "%";
                textBoxFailRate.Text = (tmGlobalobj.Failcount * 100 / ntotal).ToString() + "%";
            }
        }

        private void bnReset_Click(object sender, EventArgs e)
        {
            tmGlobalobj.PassCount = 0;
            tmGlobalobj.Failcount = 0;
            txtFail.Text = "0";
            txtPass.Text = "0";
        }

        private void checkboxloop_CheckedChanged(object sender, EventArgs e)
        {
            string str = string.Format("{0}{1}", tmMarcos.kLoopModeBase, 0);            
            TestContext.m_dicConfig[str] = checkboxloop.Checked==true?1:0;
            m_looptime = 0;
            m_timeneed2loop = 0;
        }
        /// <summary>
        /// TestTime.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void StartTimeTick(int index)
        {
            Timer[] timelist = { testTime, timer2, timer3, timer4, timer5, timer6 };
            timelist[index].Start();
        }

        private void StopTimeTick(int index)
        {
            Timer[] timelist = {testTime,timer2,timer3,timer4,timer5,timer6};
            timelist[index].Stop();
        }

        private void testTime_Tick(object sender, EventArgs e)
        {
            updateTestTime(0);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            updateTestTime(1);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            updateTestTime(2);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            updateTestTime(3);
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            updateTestTime(4);
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            updateTestTime(5);
        }

        private void updateTestTime(int index)
        {
            TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts2 = new TimeSpan(m_tsStart);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            Label[] lbtimelist = { lbtesttime, lbtesttime1, lbtesttime2, lbtesttime3, lbtesttime4, lbtesttime5 };
            lbtimelist[index].Text = string.Format("{0:f2}S", ts.TotalSeconds);
            
        }
        private void timerLoopTest_Tick(object sender, EventArgs e)
        {
            if (m_blooprun)
            {
                m_blooprun = false;
                if (m_looptime > 0)
                    m_timeneed2loop--;
                else //free loop run
                {
                    m_timeneed2loop++;
                }
                UpdateLoopTime();
                if (m_timeneed2loop >= 0)
                {
                    StartTest();
                }
            }
        }

        private void btnUnitStart_Click(object sender, EventArgs e)
        {
            StartTest();
        }

        private void bnUnitStop_Click(object sender, EventArgs e)
        {
            checkboxloop.Checked = false;//Stop的话就取消loop吧。
            StopTest();
            bnUnitStop.Enabled = false;
            btnUnitStart.Enabled = true;
        }


        public void StartTest()
        {
            if (!CheckNeedShowBarCodeScan())
            {
                if (cSN1.Checked)
                    GT_UserInterface.m_TestEngine.StartTest(0);
                if (cSN2.Checked)
                    GT_UserInterface.m_TestEngine.StartTest(1);
                if (cSN3.Checked)
                    GT_UserInterface.m_TestEngine.StartTest(2);
                if (cSN4.Checked)
                    GT_UserInterface.m_TestEngine.StartTest(3);
                if (cSN5.Checked)
                    GT_UserInterface.m_TestEngine.StartTest(4);
                if (cSN6.Checked)
                    GT_UserInterface.m_TestEngine.StartTest(5);

                m_timeneed2loop = 0;
                UpdateLoopTime();
            }
            else
            {
                UpdateUUT_IDLE_Display();
                MessageBox.Show("Please scan the SN firstly!");
#if false
                DictionaryEx dic = new DictionaryEx();
                dic["id"] = -1;
                NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnShowBarCodeScan, dic);
#endif                
            }
        }

        public void StopTest()
        {
#if false
            if (cSN1.Checked)
                GT_UserInterface.m_TestEngine.StopTest(0);
            if (cSN2.Checked)
                GT_UserInterface.m_TestEngine.StopTest(1);
            if (cSN3.Checked)
                GT_UserInterface.m_TestEngine.StopTest(2);
            if (cSN4.Checked)
                GT_UserInterface.m_TestEngine.StopTest(3);
            if (cSN5.Checked)
                GT_UserInterface.m_TestEngine.StopTest(4);
            if (cSN6.Checked)
                GT_UserInterface.m_TestEngine.StopTest(5);
#else
            GT_UserInterface.m_TestEngine.StopTest(-1);
#endif 
        }


        /// <summary>
        /// User Manger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void linkLabelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
#if true //no need to do this so far.
            LoginForm logfrm = new LoginForm();
            logfrm.ShowDialog();
            InitUIByUser();
#endif
        }

        private void timerCalibtime_Tick(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Functions for Loop Test.
        /// </summary>
        private void UpdateLoopTime()
        {
            lblooptime.Text = string.Format("Current Loop：{0}", m_timeneed2loop);
        }
        public bool IsLoopCheck()
        {
            return checkboxloop.Checked;
        }

        private void UpdateUserName()
        {
            if (TestContext.m_dicGlobal.ContainsKey(tmMarcos.kIsAdminLogin))
            {
                if ((int)TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] == 0)
                {
                    TestContext.m_dicConfig[tmMarcos.kCusTomer] = "Operator";
                }
                else
                {
                    TestContext.m_dicConfig[tmMarcos.kCusTomer] = "admin";
                }
            }
            else
            {
                TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] = 0;
                TestContext.m_dicConfig[tmMarcos.kCusTomer] = "Operator";
            }
            if (TestContext.m_dicConfig.ContainsKey(tmMarcos.kCusTomer))
            {
                linkLabelUser.Text ="User:"+TestContext.m_dicConfig[tmMarcos.kCusTomer] as string;
            }
        }

        public void InitUIByUser()
        {
            UpdateUserName();
        }

        public void ResetTestInfo()
        {
            txtPass.Text = "0";
            txtFail.Text = "0";
            textBoxFailRate.Text = "0.0%";
            textBoxPassRate.Text = "0.0%";
        }

        public void ResetTestInfo_Click(object sender, EventArgs e)
        {
            txtPass.Text = "0";
            txtFail.Text = "0";
            textBoxFailRate.Text = "0.0%";
            textBoxPassRate.Text = "0.0%";
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            m_timeneed2loop = 0;
            UpdateLoopTime();
        }
        /// <summary>
        /// UUTSN functions.
        /// </summary>
        public void ClearUUTSN(int nindex = -1)
        {
            if (nindex < 0)
            {
                for (int nsize = 0; nsize < 6; nsize++)
                {
                    string strindex = "SN" + (nsize + 1).ToString();
                    TestContext.m_dicConfig[strindex] = "";
                }
            }
            else
            {
                string strindex = "SN" + (nindex + 1).ToString();
                TestContext.m_dicConfig[strindex] = "";
            }
        }

        public void UpdateUUT_IDLE_Display()
        {
            Label[] lblTitle = { lblStatus0, lblStatus1, lblStatus2, lblStatus3, lblStatus4, lblStatus5 };
            for (int index = 0; index < 6;index++ )
            {
                lblTitle[index].Text = string.Format("IDLE");
                lblTitle[index].BackColor = Color.Cyan;
            }
        }

        public void SetUUTSN(int index, string name)
        {
            Label[] lblTitle = { lblStatus0, lblStatus1, lblStatus2, lblStatus3, lblStatus4, lblStatus5 };
            string strindex = "SN" + (index + 1).ToString();
            TestContext.m_dicConfig[strindex] = name;

            lblTitle[index].Text = string.Format("UUT{0}",index+1)+"\n"+name;
        }

        public string GetUUTSN(int index)
        {
            string strindex = "SN" + (index + 1).ToString();
            string str =  TestContext.m_dicConfig[strindex] as string;
            return str;
        }

        public bool CheckNeedShowBarCodeScan()
        {
            if ((int)TestContext.m_dicConfig[tmMarcos.kConfigScanBarcode] == 0)
                return false;
            bool bret = false;
            CheckBox[] cblist = {cSN1,cSN2,cSN3,cSN4,cSN5,cSN6};
            for (int nsize = 0; nsize < 6; nsize++)
            {
                //检查有内容但是没有条码
                if(cblist[nsize].Checked&&GetUUTSN(nsize).Length==0)
                {
                    bret = true;
                    break;
                }
            }
            return bret;
        }

        /// <summary>
        /// Update the config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void UpdateUUTCheckByEnableStatue()
        {
            CheckBox[] chlist = { cSN1,cSN2,cSN3,cSN4,cSN5,cSN6};
            for (int nsize = 0; nsize < 6; nsize++)
            {
                string str = string.Format("{0}{1}", tmMarcos.kUUTEnable, nsize);
                if (TestContext.m_dicConfig[str] != null)
                {
                    chlist[nsize].Checked = (bool)TestContext.m_dicConfig[str];
                    //also tell the UUTEnable
                    NotifyUUTEnableChange(nsize, chlist[nsize].Checked);
                }
            }
        }

        private void NotifyUUTEnableChange(int id,bool bvalue)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["value"] = bvalue;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnUUTEnableChange, dic);
        }

        private void cSN1_CheckedChanged(object sender, EventArgs e)
        {
            TestContext.m_dicConfig[tmMarcos.kUUTEnable0] = cSN1.Checked;
            MainForm.SaveConfig();//use this method.
            NotifyUUTEnableChange(0,cSN1.Checked);
        }

        private void cSN2_CheckedChanged(object sender, EventArgs e)
        {
            TestContext.m_dicConfig[tmMarcos.kUUTEnable1] = cSN2.Checked;
            MainForm.SaveConfig();
            NotifyUUTEnableChange(1, cSN2.Checked);
        }

        private void cSN3_CheckedChanged(object sender, EventArgs e)
        {
            TestContext.m_dicConfig[tmMarcos.kUUTEnable2] = cSN3.Checked;
            MainForm.SaveConfig();
            NotifyUUTEnableChange(2, cSN3.Checked);
        }

        private void cSN4_CheckedChanged(object sender, EventArgs e)
        {
            TestContext.m_dicConfig[tmMarcos.kUUTEnable3] = cSN4.Checked;
            MainForm.SaveConfig();
            NotifyUUTEnableChange(3, cSN4.Checked);
        }

        private void cSN5_CheckedChanged(object sender, EventArgs e)
        {
            TestContext.m_dicConfig[tmMarcos.kUUTEnable4] = cSN5.Checked;
            MainForm.SaveConfig();
            NotifyUUTEnableChange(4, cSN5.Checked);
        }

        private void cSN6_CheckedChanged(object sender, EventArgs e)
        {
            TestContext.m_dicConfig[tmMarcos.kUUTEnable5] = cSN6.Checked;
            MainForm.SaveConfig();
            NotifyUUTEnableChange(5, cSN6.Checked);
        }

        public void SetSN(string sn, int index)
        {
            SetUUTSN(index,sn);
        }
    }
}
