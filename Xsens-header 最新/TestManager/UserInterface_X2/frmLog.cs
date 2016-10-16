using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using TestStudio.Automation.TestManager.libCommon.Class;

namespace UserInterface
{
    public partial class frmLog : DockContent
    {
        public frmLog()
        {
            InitializeComponent();
            this.DockAreas = DockAreas.DockLeft|DockAreas.DockRight|DockAreas.DockTop|DockAreas.DockBottom|DockAreas.Float;
            this.HideOnClose = true;
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kDegbugMessage, OnLogNotification);
        }


        delegate int delegateNotification(Notification nf);
        int OnLogNotification(Notification nf)
        {
            if (this.InvokeRequired)
            {
                return (int)Invoke(new delegateNotification(OnLogNotification),new object[]{nf});
            }
            DictionaryEx dic = nf.context as DictionaryEx;
            string msg = dic["msg"] as string;
            int id = (int)dic["id"];
            msg = "["+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"]:"+msg;
            txtLog.AppendText(msg);
            return 0;
        }
        
    }
}
