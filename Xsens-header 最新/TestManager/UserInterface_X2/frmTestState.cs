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
            //this.AutoHidePortion = this.Width;
            //设置不检查跨线程处理，但是两个窗口之间是不同的线程吗？
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmTestState_SizeChanged(object sender, EventArgs e)
        {
            return;
        }
        private void frmTestState_Load(object sender, EventArgs e)
        {
            InitUIByUser();
            UpdateStationName();
            timerCalibtime.Start();
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kTestFlowMessage,OnUiNotification);
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
            return 0;
        }

        public void UpdateStationName()
        {
            if (TestContext.m_dicConfig[tmMarcos.kConfigStationName] != null)
            {
                lbStationname.Text = "机台号:" + 
                    (TestContext.m_dicConfig[tmMarcos.kConfigStationName] as string);
            }
        }

        //export function
        public void ShowTestStart(int index)
        {
            Label[] lblTitle = { lblStatus0 };
            lblTitle[index].Text = string.Format("TESTING");
            lblTitle[index].BackColor = Color.Blue;

            testTime.Start();
            m_tsStart = DateTime.Now.Ticks;
            textBoxStatue.Text = "";
        }

        public void ShowTestFinish(int index,int result)
        {
            Label[] lblTitle = { lblStatus0 };
            string strResult;
            Color color;
            if (result==0)
            {
                strResult = "FAIL";
                color = Color.Red;
                tmGlobalobj.Failcount++;
#if false       
                if (index == 0)
                {
                    string errcode="";
                    if (TestContext.m_dicConfig[tmMarcos.kUUT0Errcode] != null)
                    {
                        errcode = TestContext.m_dicConfig[tmMarcos.kUUT0Errcode].ToString();
                        errcode.Remove(errcode.LastIndexOf(errcode), 1);  
                    }
                    lblStatus0.Text = string.Format("{1} {2}", index, strResult, errcode);
                    lblStatus0.BackColor = color;

                    UpdatePassFailRate();
                    testTime.Stop();
                    if (checkboxloop.Checked==true)
                    {
                        m_blooprun = true;
                    }
                    return;
                }
#endif    
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
            lblStatus0.Text = string.Format("{1}", index, strResult);
            lblStatus0.BackColor = color;

            txtPass.Text = tmGlobalobj.PassCount.ToString();
            txtFail.Text = tmGlobalobj.Failcount.ToString();
            UpdatePassFailRate();
            testTime.Stop();

            if (checkboxloop.Checked == true)
            {
                m_blooprun = true;
            }
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
            textBoxlooptime.Text = "";
        }

        private void testTime_Tick(object sender, EventArgs e)
        {
            updateTestTime();
        }

        private void updateTestTime()
        {
            TimeSpan ts1 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts2 = new TimeSpan(m_tsStart);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            lbtesttime.Text = string.Format("{0:f2}S",ts.TotalSeconds);
            
        }
        //15976963791
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
                    GT_UserInterface.m_TestEngine.StartTest(0);
                }
            }
        }

        private void btnUnitStart_Click(object sender, EventArgs e)
        {
            GT_UserInterface.m_TestEngine.StartTest(0);
            //如果通过start按的话就恢复
            m_timeneed2loop = 0;
            UpdateLoopTime();
        }

        private void bnUnitStop_Click(object sender, EventArgs e)
        {
            checkboxloop.Checked = false;//Stop的话就取消loop吧。
            GT_UserInterface.m_TestEngine.StopTest(0);
        }

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
            if (TestContext.m_dicConfig[tmMarcos.kDueTimeALSC1] != null
                && TestContext.m_dicConfig[tmMarcos.kDueTimeALSC2] != null)
            {
                try
                {
                    double alsc1 = (double)TestContext.m_dicConfig[tmMarcos.kDueTimeALSC1];
                    double alsc2 = (double)TestContext.m_dicConfig[tmMarcos.kDueTimeALSC2];
                    double minvalue = System.Math.Min(alsc1, alsc2) + (7 * 24 * 60 * 60);
                    DateTime dt = DateTime.Now;
                    double nnow = GT_Function.ConvertDateTimeInt(dt);
                    double nelapse = minvalue - nnow;
                    if (nelapse < 0)
                    {
                        lbDueTime.Text = "Please Calib.the ALSC!";
                    }
                    else
                    {
                        lbDueTime.Text = string.Format("{0:D2}H:{1:D2}M:{2:D2}S", 
                            (int)nelapse/3600, (int)(nelapse-((int)nelapse/3600)*3600)/ 60, (int)nelapse % 60);
                    }
                }
                catch (Exception ex)
                {
                    lbDueTime.Text = "Get Calib. Time Fail!";
                }
            }
            else
            {
                lbDueTime.Text = "Get Calib. Time Fail!";
            }
        }
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

        private void textBoxlooptime_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    m_looptime = Convert.ToInt32(textBoxlooptime.Text);
                    m_timeneed2loop = m_looptime;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("输入的数据不正常,请输入数字!");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            m_timeneed2loop = 0;
            UpdateLoopTime();
        }
    }
}
