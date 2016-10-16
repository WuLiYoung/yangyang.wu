using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Class;


namespace TestMgr
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text.ToLower().CompareTo("admin") == 0
                && textBoxPWD.Text.ToLower().CompareTo("admin") == 0)
            {
                TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] = 1;
                TestContext.m_dicConfig[tmMarcos.kCusTomer] = "admin";
            }
            else
            {
                MessageBox.Show("登录失败!");
            }
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
