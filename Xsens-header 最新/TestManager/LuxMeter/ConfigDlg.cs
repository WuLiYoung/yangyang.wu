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

namespace LuxMeter
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
                if (GT_LuxMeter.mConfigInfo[tmMarcos.kLuxMeterConfig] != null)
                    this.tbConfig.Text = GT_LuxMeter.mConfigInfo[tmMarcos.kLuxMeterConfig].ToString();
                if (GT_LuxMeter.mConfigInfo[tmMarcos.kLuxMeterCom] != null)
                    this.ComboxComlist.Text = GT_LuxMeter.mConfigInfo[tmMarcos.kLuxMeterCom].ToString();
            }
            catch (Exception )
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
                GT_LuxMeter.mConfigInfo[tmMarcos.kLuxMeterCom] = this.ComboxComlist.Text;
                if(this.tbConfig.TextLength > 0)
                    GT_LuxMeter.mConfigInfo[tmMarcos.kLuxMeterConfig] = this.tbConfig.Text;
                GT_LuxMeter.mConfigInfo.WriteXml(GT_LuxMeter.mCfgFilePath);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }

        private void UpdateConnectStatue()
        {
            if (GT_LuxMeter.m_object.IsOpen)
            {
                this.Text = "Lux Meter Connected.";
            }
            else
            {
                this.Text = "Lux Meter Not Connect.";
            }
        }
    }
}
