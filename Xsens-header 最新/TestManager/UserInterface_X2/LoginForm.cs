using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Class;

namespace UserInterface
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
                TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] = 0;
                TestContext.m_dicConfig[tmMarcos.kCusTomer] = "Operator";
                MessageBox.Show("登录失败!");
            }
            Close();
            NotifyUserChange();
        }

        private static void NotifyUserChange()
        {
            DictionaryEx dic2 = new DictionaryEx();
            dic2["id"] = 0;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnChangeUser, dic2);
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (TestContext.m_dicGlobal.ContainsKey(tmMarcos.kIsAdminLogin))
            {
                if ((int)TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] == 0)
                {
                    TestContext.m_dicConfig[tmMarcos.kCusTomer] = "Operator";
                }
            }
            else
            {
                TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] = 0;
                TestContext.m_dicConfig[tmMarcos.kCusTomer] = "Operator";
            }
            Close();
            NotifyUserChange();        
        }

        private void buttonexitlogin_Click(object sender, EventArgs e)
        {
            TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] = 0;
            TestContext.m_dicConfig[tmMarcos.kCusTomer] = "Operator";
            NotifyUserChange();        
        }
    }
}
