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

namespace lightSensor
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
                this.tbConfig.Text = GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Config].ToString();
                this.ComboxComlist.Text = GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Com].ToString();
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
                GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Com] = this.ComboxComlist.Text;
                if(this.tbConfig.TextLength > 0)
                    GT_lightSensor.mConfigInfo[tmMarcos.kSensor1Config] = this.tbConfig.Text;
                GT_lightSensor.mConfigInfo.WriteXml(GT_lightSensor.mCfgFilePath);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }

        protected void bnGetValue_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
            else
                timer1.Start();
            GetLightvalue();
        }

        private void GetLightvalue()
        {
            if (GT_lightSensor.m_object.IsOpen)
            {
                GT_lightSensor.m_object.SetDetectString("@_@");
                GT_lightSensor.m_object.Write("READ SENSOR VALUE\r\n");
                if (GT_lightSensor.m_object.WaitForString(1000) != -1)
                {
                    lbsensorvalue.Text = Convert.ToString(GT_lightSensor.m_object.GetLightValue());
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetLightvalue();
        }

        private void UpdateConnectStatue()
        {
            if (GT_lightSensor.m_object.IsOpen)
            {
                this.Text = "Sensor 1 Connected.";
            }
            else
            {
                this.Text = "Sensor 1 Not Connect.";
            }
        }
    }
}
