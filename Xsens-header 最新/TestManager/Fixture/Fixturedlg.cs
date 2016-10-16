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

namespace Fixture
{
    public partial class Fixture : Form
    {
        public Fixture()
        {
            InitializeComponent();
            UpdateCurrentPort();
            UpdateConnectStatue();
            try
            {
                this.tbConfig.Text = GT_Fixture.mConfigInfo[tmMarcos.kFixtureConfig].ToString();
                this.ComboxComlist.Text = GT_Fixture.mConfigInfo[tmMarcos.kFixtureCom].ToString();
            }
            catch (Exception)
            {
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
        private void UpdateCurrentPort()
        {
            this.ComboxComlist.Items.Clear();
            foreach (string vPortName in SerialPort.GetPortNames())
            {
                this.ComboxComlist.Items.Add(vPortName);
            }
        }
        private void UpdateConnectStatue()
        {
            if (GT_Fixture.m_object.IsOpen)
            {
                this.Text = "Fixture Connected.";
            }
            else
            {
                this.Text = "Fixture Not Connect.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateCurrentPort();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.ComboxComlist.Items.Count > 0)
            {
                GT_Fixture.mConfigInfo[tmMarcos.kFixtureCom] = this.ComboxComlist.Text;
                if (this.tbConfig.TextLength > 0)
                    GT_Fixture.mConfigInfo[tmMarcos.kFixtureConfig] = this.tbConfig.Text;
                GT_Fixture.mConfigInfo.WriteXml(GT_Fixture.mCfgFilePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }

        private void FixtureUp_Click(object sender, EventArgs e)
        {
            GT_Fixture.m_object.WriteString("Tray putout\r\n");
        }

        private void FixtureDown_Click(object sender, EventArgs e)
        {
            GT_Fixture.m_object.WriteString("Tray putin\r\n");
        }

        private void Normal_Click(object sender, EventArgs e)
        {
            GT_Fixture.m_object.WriteString("rgb-g_on\r\n");
        }

        private void Fault_Click(object sender, EventArgs e)
        {
            GT_Fixture.m_object.WriteString("rgb-r_on\r\n");
        }

        private void Service_Click(object sender, EventArgs e)
        {
            GT_Fixture.m_object.WriteString("rgb-y_on\r\n");
        }
    }
}
