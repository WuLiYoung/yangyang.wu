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
    public partial class frmSN : Form
    {
        string m_SN=""; 
        public frmSN()
        {
            InitializeComponent();
        }

        public frmSN(string sn):this()
        {
            m_SN = sn;

            TextBox[] txtUUT = {txtUUT1,txtUUT2,txtUUT3,txtUUT4,txtUUT5,txtUUT6};
            bool bFirst = true;
            for (int i = 0; i < 6; i++)
            {
                txtUUT[i].Text = "";
                string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                bool bEnable = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                txtUUT[i].Enabled = bEnable;
                if (bEnable && bFirst)
                {
                    txtUUT[i].Text = sn;
                    SendKeys.Send("{tab}");
                    bFirst = false;
                }
            }
            
        }

        private bool IsLastBox(int tag)
        {
            TextBox[] txtUUT = { txtUUT1, txtUUT2, txtUUT3, txtUUT4, txtUUT5, txtUUT6 };
            for (int i = tag+1; i < 6;i++ )
            {
                if (txtUUT[i].Enabled)
                {
                    return false;
                }
                
            }
            return true;
        }

        public string GetSN(int index)
        {
            TextBox[] txtUUT = { txtUUT1, txtUUT2, txtUUT3, txtUUT4, txtUUT5, txtUUT6 };
            if (index>=6 || index<0)
            {
                return null;
            }
            return txtUUT[index].Text;
        }

        private void txtUUT_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtUUT_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (IsLastBox(Convert.ToInt32(txtbox.Tag)))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    SendKeys.Send("{tab}");
                }                
            }
        }

        private void txtUUT1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtUUT1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void frmSN_Load(object sender, EventArgs e)
        {
            if (m_SN.Trim().Length>0)
            {
                txtUUT2.Focus();
            }
            else
            {
                txtUUT1.Focus();
            }
        }
    }
}
