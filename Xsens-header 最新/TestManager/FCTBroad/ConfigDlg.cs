using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace C28Instrument
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
                this.tbConfig.Text = GT_C28Instrument.mConfigInfo[fctMarcro.kFCTCom].ToString();
                this.ComboxComlist.Text = GT_C28Instrument.mConfigInfo[fctMarcro.kFCTConfig].ToString();
                //Lex add delegate to update the UI.
                GT_C28Instrument.m_object.notifier+=new C28Instrument.Notify(OnRecevieData);
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


        private void UpdateConnectStatue()
        {
            if (GT_C28Instrument.m_object.IsOpen)
            {
                this.Text = "C28 Instrument Connected.";
            }
            else
            {
                this.Text = "C28 Instrument Not Connect.";
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
                GT_C28Instrument.mConfigInfo[fctMarcro.kFCTCom] = comname;
                if (config.Length > 0)
                    GT_C28Instrument.mConfigInfo[fctMarcro.kFCTConfig] = config;
                GT_C28Instrument.mConfigInfo.WriteXml(GT_C28Instrument.mCfgFilePath);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            this.Close();
            return;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string str = "help\r\n";
            //GT_C28Instrument.m_object.
            GT_C28Instrument.m_object.WriteString(str);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string str = "reset\r\n";
            GT_C28Instrument.m_object.WriteString(str);
        }

        private void buttonver_Click(object sender, EventArgs e)
        {
            string str = "version\r\n";
            GT_C28Instrument.m_object.WriteString(str);
        }

        private void buttonsend_Click(object sender, EventArgs e)
        {
            string str = CMD.Text+"\r\n";
      //      Console.WriteLine(str);
            GT_C28Instrument.m_object.WriteString(str);

        }

        public void OnRecevieData(string str)
        {
            tbEEStatue.AppendText(str);
        }

        private void tbEEStatue_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboxComlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
