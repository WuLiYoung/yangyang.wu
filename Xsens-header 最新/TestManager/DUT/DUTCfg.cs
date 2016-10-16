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

namespace DUT
{
    public partial class DUTCfg : Form
    {
        DUTController dutcontrol = new DUTController();
        public DUTCfg()
        {
            InitializeComponent();
            UpdateCurrentPort();
            UpdateConnectStatue();
            try
            {
                this.DUTSetting1.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT1Config].ToString();
                this.DUTcomboBox1.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT1Com].ToString();
                this.DUTSetting2.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT2Config].ToString();
                this.DUTcomboBox2.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT2Com].ToString();
                this.DUTSetting3.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT3Config].ToString();
                this.DUTcomboBox3.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT3Com].ToString();
                this.DUTSetting4.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT4Config].ToString();
                this.DUTcomboBox4.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT4Com].ToString();
                this.DUTSetting5.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT5Config].ToString();
                this.DUTcomboBox5.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT5Com].ToString();
                this.DUTSetting6.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT6Config].ToString();
                this.DUTcomboBox6.Text = GT_DUT.mConfigInfo[tmMarcos.kDUT6Com].ToString();
            }
            catch (Exception)
            {
            }
        }
        private void UpdateCurrentPort()
        {
            this.DUTcomboBox1.Items.Clear();
            this.DUTcomboBox2.Items.Clear();
            this.DUTcomboBox3.Items.Clear();
            this.DUTcomboBox4.Items.Clear();
            this.DUTcomboBox5.Items.Clear();
            this.DUTcomboBox6.Items.Clear();
            foreach (string vPortName in SerialPort.GetPortNames())
            {
                this.DUTcomboBox1.Items.Add(vPortName);
                this.DUTcomboBox2.Items.Add(vPortName);
                this.DUTcomboBox3.Items.Add(vPortName);
                this.DUTcomboBox4.Items.Add(vPortName);
                this.DUTcomboBox5.Items.Add(vPortName);
                this.DUTcomboBox6.Items.Add(vPortName);
            }
        }
        private void UpdateConnectStatue()
        {
            if (GT_DUT.m_object[0].m_ComPort.IsOpen)
            {
                this.Text = "DUT Connected.";
            }
            else
            {
                this.Text = "DUT Not Connect.";
            }
        }

        private void ReScan_Click(object sender, EventArgs e)
        {
            UpdateCurrentPort();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (this.DUTcomboBox1.Items.Count > 0)
            {
                GT_DUT.mConfigInfo[tmMarcos.kDUT1Com] = this.DUTcomboBox1.Text;
                if (this.DUTSetting1.TextLength > 0)
                    GT_DUT.mConfigInfo[tmMarcos.kDUT1Config] = this.DUTSetting1.Text;
                GT_DUT.mConfigInfo.WriteXml(GT_DUT.mCfgFilePath);

                GT_DUT.mConfigInfo[tmMarcos.kDUT2Com] = this.DUTcomboBox2.Text;
                if (this.DUTSetting2.TextLength > 0)
                    GT_DUT.mConfigInfo[tmMarcos.kDUT2Config] = this.DUTSetting2.Text;
                GT_DUT.mConfigInfo.WriteXml(GT_DUT.mCfgFilePath);

                GT_DUT.mConfigInfo[tmMarcos.kDUT3Com] = this.DUTcomboBox3.Text;
                if (this.DUTSetting3.TextLength > 0)
                    GT_DUT.mConfigInfo[tmMarcos.kDUT3Config] = this.DUTSetting3.Text;
                GT_DUT.mConfigInfo.WriteXml(GT_DUT.mCfgFilePath);

                GT_DUT.mConfigInfo[tmMarcos.kDUT4Com] = this.DUTcomboBox4.Text;
                if (this.DUTSetting4.TextLength > 0)
                    GT_DUT.mConfigInfo[tmMarcos.kDUT4Config] = this.DUTSetting4.Text;
                GT_DUT.mConfigInfo.WriteXml(GT_DUT.mCfgFilePath);

                GT_DUT.mConfigInfo[tmMarcos.kDUT5Com] = this.DUTcomboBox5.Text;
                if (this.DUTSetting5.TextLength > 0)
                    GT_DUT.mConfigInfo[tmMarcos.kDUT5Config] = this.DUTSetting5.Text;
                GT_DUT.mConfigInfo.WriteXml(GT_DUT.mCfgFilePath);

                GT_DUT.mConfigInfo[tmMarcos.kDUT6Com] = this.DUTcomboBox6.Text;
                if (this.DUTSetting6.TextLength > 0)
                    GT_DUT.mConfigInfo[tmMarcos.kDUT6Config] = this.DUTSetting6.Text;
                GT_DUT.mConfigInfo.WriteXml(GT_DUT.mCfgFilePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;
        }

        private void DUTSetting1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Send_Click(object sender, EventArgs e)
        {
            string cmd = textcmd.Text + "\r\n";
            //dutcontrol.SendCmd(cmd);
            GT_DUT.mm_object.SendCmd(cmd);
            textbox.Text += GT_DUT.mm_object.ReadString();
            textbox.Show();
        }

    }
}
