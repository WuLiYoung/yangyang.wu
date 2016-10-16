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

namespace Scanner
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
                config = GT_Scanner.mConfigInfo[tmMarcos.kScannerConfig].ToString();
                comname= GT_Scanner.mConfigInfo[tmMarcos.kScannerCom].ToString();
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
                GT_Scanner.mConfigInfo[tmMarcos.kScannerCom] = this.ComboxComlist.Text;
                if(this.tbConfig.TextLength > 0)
                    GT_Scanner.mConfigInfo[tmMarcos.kScannerConfig] = this.tbConfig.Text;
                GT_Scanner.mConfigInfo.WriteXml(GT_Scanner.mCfgFilePath);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }

        private void bncapture_Click(object sender, EventArgs e)
        {
            ScriptEngine pscript = GT_Scanner.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
            if (pscript != null)
            {
                string str = string.Format("scanner.GetQRCode()");
                pscript.DoString(str);
            }
        }

        private void UpdateConnectStatue()
        {
            if (GT_Scanner.m_object.IsOpen)
            {
                this.Text = "Scanner Connected.";
            }
            else
            {
                this.Text = "Scanner Not Connect.";
            }
        }
    }
}
