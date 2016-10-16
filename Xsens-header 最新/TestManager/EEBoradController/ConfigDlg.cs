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

namespace EEBroadController
{
    public partial class ConfigDlg : Form
    {
        public ConfigDlg()
        {
            InitializeComponent();
            UpdateCurrentPort();
            UpdateConnectStatue();
            try
            {
                this.tbConfig.Text = GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureConfig].ToString();
                this.ComboxComlist.Text = GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureCom].ToString();
            }
            catch (Exception)
            {
            }

        }

        private void UpdateCurrentPort()
        {
            this.ComboxComlist.Items.Clear();
            foreach (string vPortName in SerialPort.GetPortNames())
            {
                this.ComboxComlist.Items.Add(vPortName);
            }  
        }

        public string comname
        {
            get
            {
                return this.ComboxComlist.Text;
            }
            set
            {
                this.ComboxComlist.Text = value;
            }
        }

        public string config
        {
            get
            {
                return this.tbConfig.Text;
            }
            set
            {
                this.tbConfig.Text = value; 
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateCurrentPort();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (this.ComboxComlist.Items.Count > 0)
            {
                GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureCom] = comname;
                if (config.Length > 0)
                    GT_EEBroadController.mConfigInfo[tmMarcos.kFixtureConfig] = config;
                GT_EEBroadController.mConfigInfo.WriteXml(GT_EEBroadController.mCfgFilePath);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            return;           
        }

        

        private void bnreset_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("fixture_reset\r\n");
            System.Threading.Thread.Sleep(50);
            GT_EEBroadController.m_object.ReadString();
        }

        private void UpdateConnectStatue()
        {
            if (GT_EEBroadController.m_object.IsOpen)
            {
                this.Text = "Ctrl Broad Connected.";
            }
            else
            {
                this.Text = "Ctrl Broad Not Connect.";
            }
        }

     
        private void bnFixtureIn_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT81=0\r\n");
            GT_EEBroadController.m_object.WriteString("SBIT80=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "top_fixtuer_in\r\n";
        }

        private void btFixtureOut_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT80=0\r\n");
            GT_EEBroadController.m_object.WriteString("SBIT81=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "top_fixtuer_out\r\n";
        }

        private void buT_FixUp_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT82=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "top_fixtuer_up\r\n";
        }

        private void btT_FixDown_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT82=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "top_fixtuer_down\r\n";
        }

        private void btB_FixUp_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT83=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "bottom_fixtuer_up\r\n";
        }

        private void btB_FixDown_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT83=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "bottom_fixtuer_down\r\n";
        }

        private void btTransUp_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT84=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "translation_up\r\n";
        }

        private void btTransDown_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT84=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "translation_down\r\n";
        }

        private void btUUT0IN_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT85=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut1_modol_in\r\n";
        }

        private void btUUT0OUT_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT85=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut1_modol_out\r\n";
        }

        private void btUUT1IN_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT86=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut2_modol_in\r\n";
        }

        private void btUUT1OUT_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT86=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut2_modol_out\r\n";
        }

        private void btUUT2IN_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT87=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut3_modol_in\r\n";
        }

        private void btUUT2OUT_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT87=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut3_modol_out\r\n";
        }

        private void btUUT3IN_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT88=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut4_modol_in\r\n";
        }

        private void btUUT3OUT_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT88=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut4_modol_out\r\n";
        }

        private void btUUT4IN_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT89=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut5_modol_in\r\n";
        }

        private void btUUT4OUT_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT89=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut5_modol_out\r\n";
        }

        private void btUUT5IN_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT90=1\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut6_modol_in\r\n";
        }

        private void btUUT5OUT_Click(object sender, EventArgs e)
        {
            GT_EEBroadController.m_object.WriteString("SBIT90=0\r\n");
            System.Threading.Thread.Sleep(50);
            tbEEStatue.Text += GT_EEBroadController.m_object.ReadString() + "uut6_modol_out\r\n";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            tbEEStatue.Text = "";
        }

        public void bnwork_Click(object sender, EventArgs e)
        {
      /*      bnFixtureIn_Click(sender,e );
            
                System.Threading.Thread.Sleep(2000);
                btT_FixDown_Click(sender, e);
                System.Threading.Thread.Sleep(1000);
                
                     btUUT0IN_Click(sender, e);
                     btUUT1IN_Click(sender, e);
                     btUUT2IN_Click(sender, e);
                     btUUT3IN_Click(sender, e);
                     btUUT4IN_Click(sender, e);
                     btUUT5IN_Click(sender, e);
                    
                        System.Threading.Thread.Sleep(3000);
                        btTransDown_Click(sender, e);
                        System.Threading.Thread.Sleep(1000);
                        
                            btB_FixUp_Click(sender, e);
                            //System.Threading.Thread.Sleep(5000);
                          
                                tbEEStatue.Text +="所有气缸到位";
            */
            GT_EEBroadController.m_object.WriteString("fixture_work\r\n");
        }

        public bool WandRandC(string str,string str1)
        {
            string ret = "";
            int start = System.Environment.TickCount;
            while (ret == str1)
            {
                int now= System.Environment.TickCount;
                if (now - start >= 2000) return false;
                else
                {
                    GT_EEBroadController.m_object.WriteString(str);
                    System.Threading.Thread.Sleep(50);
                    ret = GT_EEBroadController.m_object.ReadString();
                }
            }
            return true;
        }
        public void ActionFail()
        {
            System.Windows.Forms.MessageBox.Show("气缸没有运行到位，请检查");
            GT_EEBroadController.m_object.WriteString("fixture_reset\r\n");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Send_Click(object sender, EventArgs e)
        {
           string str = (string)this.comboBox1.Text + "\r\n";
           GT_EEBroadController.m_object.WriteString(str);
           tbEEStatue.Text += this.comboBox1.SelectedText + str;
           this.comboBox1.ResetText();
           System.Threading.Thread.Sleep(50);
           tbEEStatue.Text += GT_EEBroadController.m_object.ReadString();
        }

        private void ComboxComlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
