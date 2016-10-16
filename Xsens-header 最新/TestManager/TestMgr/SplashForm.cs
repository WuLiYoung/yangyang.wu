using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using TestStudio.Automation.TestManager.libCommon.Class;

namespace TestMgr
{
    public partial class SplashForm : Form
    {
        int t_start;
        TestManager m_TestManager = new TestManager();
        public SplashForm()
        {
            InitializeComponent();
        }

        int OnNotification(Notification nf)
        {
            object o = nf.context;
            string str = o as string;
            if (null!=str)
            {
                UpdateUI(lblLog, str);
            }
            return 0;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            //LoadTm(@"C:\Ryan\Code\TestManager\TestMgr\TestManager.tm",new DictionaryEx());
            t_start = System.Environment.TickCount;
            timerSplash.Enabled = true;
            NotificationCenter.DefaultCenter().AddObserver("LoadTM", OnNotification, null);
        }


        delegate void delegateUpdateUI(object sender, object arg);
        void UpdateUI(object sender,object arg)
        {
            if (InvokeRequired)
            {
                Invoke(new delegateUpdateUI(UpdateUI), new object[] {sender, arg});
                return;
            }
            if (sender == lblTimer)
            {
                lblTimer.Text = arg as string;
            }

            if (sender == lblLog)
            {
                lblLog.Text += arg as string+"\r\n";
            }

            Application.DoEvents();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            int now = Environment.TickCount;
            string txt = string.Format("{0:f3}", (float)(now - t_start) / 1000.0);
            UpdateUI(lblTimer,txt);
            Application.DoEvents();
        }

        private void LoadModule(DictionaryEx dic)
        {
        }

        private void SplashForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lblLog_Click(object sender, EventArgs e)
        {

        }
    }
}
