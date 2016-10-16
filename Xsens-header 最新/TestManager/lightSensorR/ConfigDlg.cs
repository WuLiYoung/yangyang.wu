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

namespace lightSensorR
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
                this.tbConfig.Text = GT_lightSensorR.mConfigInfo[tmMarcos.kSensor2Config].ToString();
                this.ComboxComlist.Text = GT_lightSensorR.mConfigInfo[tmMarcos.kSensor2Com].ToString();
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
                GT_lightSensorR.mConfigInfo[tmMarcos.kSensor2Com] = this.ComboxComlist.Text;
                if(this.tbConfig.TextLength > 0)
                    GT_lightSensorR.mConfigInfo[tmMarcos.kSensor2Config] = this.tbConfig.Text;
                GT_lightSensorR.mConfigInfo.WriteXml(GT_lightSensorR.mCfgFilePath);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }

        private void bnGetValue_Click(object sender, EventArgs e)
        {
            GetLightvalue();
        }

        private void GetLightvalue()
        {
            if (GT_lightSensorR.m_object.IsOpen)
            {
                GT_lightSensorR.m_object.SetDetectString("@_@");
                GT_lightSensorR.m_object.Write("READ SENSOR VALUE\r\n");
                if (GT_lightSensorR.m_object.WaitForString(1000) != -1)
                {
                    lbsensorvalue.Text = Convert.ToString(GT_lightSensorR.m_object.GetLightValue());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void UpdateConnectStatue()
        {
            if (GT_lightSensorR.m_object.IsOpen)
            {
                this.Text = "Sensor 2 Connected.";
            }
            else
            {
                this.Text = "Sensor 2 Not Connect.";
            }
        }
    }
}
