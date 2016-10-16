using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class NotifyWindow : Form
    {
        private int nDelay = 3000;
        private string notifystr = "";
        public NotifyWindow()
        {
            InitializeComponent();
        }

        public void SetNotifyString(string str,int ndelay)
        {
            notifystr = str;
            label1.Text = notifystr;
            ndelay = 3000;
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
