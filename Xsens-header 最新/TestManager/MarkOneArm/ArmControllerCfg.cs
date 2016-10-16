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

namespace MKoneController
{
    public partial class ArmControllerCfg : Form
    {
        public ArmControllerCfg()
        {
            InitializeComponent();
            UpdateCurrentPort();
            UpdateConnectStatue();
            try
            {
                this.ArmSetting1.Text = GT_MKController.mConfigInfo[tmMarcos.kArm1Config].ToString();
                this.ArmComboBox1.Text = GT_MKController.mConfigInfo[tmMarcos.kArm1Com].ToString();
                this.ArmSetting2.Text = GT_MKController.mConfigInfo[tmMarcos.kArm2Config].ToString();
                this.ArmComboBox2.Text = GT_MKController.mConfigInfo[tmMarcos.kArm2Com].ToString();
                this.ArmSetting3.Text = GT_MKController.mConfigInfo[tmMarcos.kArm3Config].ToString();
                this.ArmComboBox3.Text = GT_MKController.mConfigInfo[tmMarcos.kArm3Com].ToString();
                this.ArmSetting4.Text = GT_MKController.mConfigInfo[tmMarcos.kArm4Config].ToString();
                this.ArmComboBox4.Text = GT_MKController.mConfigInfo[tmMarcos.kArm4Com].ToString();
                this.ArmSetting5.Text = GT_MKController.mConfigInfo[tmMarcos.kArm5Config].ToString();
                this.ArmComboBox5.Text = GT_MKController.mConfigInfo[tmMarcos.kArm5Com].ToString();
                this.ArmSetting6.Text = GT_MKController.mConfigInfo[tmMarcos.kArm6Config].ToString();
                this.ArmComboBox6.Text = GT_MKController.mConfigInfo[tmMarcos.kArm6Com].ToString();
            }
            catch (Exception)
            {
            }
        }
        private void UpdateCurrentPort()
        {
            this.ArmComboBox1.Items.Clear();
            this.ArmComboBox2.Items.Clear();
            this.ArmComboBox3.Items.Clear();
            this.ArmComboBox4.Items.Clear();
            this.ArmComboBox5.Items.Clear();
            this.ArmComboBox6.Items.Clear();
            foreach (string vPortName in SerialPort.GetPortNames())
            {
                this.ArmComboBox1.Items.Add(vPortName);
                this.ArmComboBox2.Items.Add(vPortName);
                this.ArmComboBox3.Items.Add(vPortName);
                this.ArmComboBox4.Items.Add(vPortName);
                this.ArmComboBox5.Items.Add(vPortName);
                this.ArmComboBox6.Items.Add(vPortName);               
            }
        }
        private void UpdateConnectStatue()
        {
            if (GT_MKController.m_object[0].m_ComPort.IsOpen)
            {
                this.Text = "Arm Connected.";
            }
            else
            {
                this.Text = "Arm Not Connect.";
            }
        }

        private void Rescan_Click(object sender, EventArgs e)
        {
            UpdateCurrentPort();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (this.ArmComboBox1.Items.Count > 0)
            {
                GT_MKController.mConfigInfo[tmMarcos.kArm1Com] = this.ArmComboBox1.Text;
                if (this.ArmSetting1.TextLength > 0)
                    GT_MKController.mConfigInfo[tmMarcos.kArm1Config] = this.ArmSetting1.Text;
                GT_MKController.mConfigInfo.WriteXml(GT_MKController.mCfgFilePath);

                GT_MKController.mConfigInfo[tmMarcos.kArm2Com] = this.ArmComboBox2.Text;
                if (this.ArmSetting2.TextLength > 0)
                    GT_MKController.mConfigInfo[tmMarcos.kArm2Config] = this.ArmSetting2.Text;
                GT_MKController.mConfigInfo.WriteXml(GT_MKController.mCfgFilePath);
              
                GT_MKController.mConfigInfo[tmMarcos.kArm3Com] = this.ArmComboBox3.Text;
                if (this.ArmSetting3.TextLength > 0)
                    GT_MKController.mConfigInfo[tmMarcos.kArm3Config] = this.ArmSetting3.Text;
                GT_MKController.mConfigInfo.WriteXml(GT_MKController.mCfgFilePath);

                GT_MKController.mConfigInfo[tmMarcos.kArm4Com] = this.ArmComboBox4.Text;
                if (this.ArmSetting4.TextLength > 0)
                    GT_MKController.mConfigInfo[tmMarcos.kArm4Config] = this.ArmSetting4.Text;
                GT_MKController.mConfigInfo.WriteXml(GT_MKController.mCfgFilePath);

                GT_MKController.mConfigInfo[tmMarcos.kArm5Com] = this.ArmComboBox5.Text;
                if (this.ArmSetting5.TextLength > 0)
                    GT_MKController.mConfigInfo[tmMarcos.kArm5Config] = this.ArmSetting5.Text;
                GT_MKController.mConfigInfo.WriteXml(GT_MKController.mCfgFilePath);

                GT_MKController.mConfigInfo[tmMarcos.kArm6Com] = this.ArmComboBox6.Text;
                if (this.ArmSetting6.TextLength > 0)
                    GT_MKController.mConfigInfo[tmMarcos.kArm6Config] = this.ArmSetting6.Text;
                GT_MKController.mConfigInfo.WriteXml(GT_MKController.mCfgFilePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }
       
    }
}
