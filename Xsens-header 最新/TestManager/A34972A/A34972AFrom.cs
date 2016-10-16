using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace A34972A
{
    public partial class A34972AFrom : Form
    {


        public A34972AFrom()
        {
            InitializeComponent();
            GT_A34972A.m_object.OpenRM();
            GT_A34972A.m_object.OpenSession(GT_A34972A.m_object.Device, GT_A34972A.m_object.resourceManager);

        }

        private void WCmd_Click(object sender, EventArgs e)
        {
            string cmd= CMD.Text;
            GT_A34972A.m_object.WriteCmd(cmd);
        }

        private void RCmd_Click(object sender, EventArgs e)
        {
            textBox1.Text += GT_A34972A.m_object.ReadCmd();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            GT_A34972A.m_object.OpenSession(comboBox1.Text, GT_A34972A.m_object.OpenRM());

        }
    }
}
