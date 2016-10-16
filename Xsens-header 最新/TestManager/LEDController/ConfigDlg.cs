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

namespace LEDController
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
                this.tbConfig.Text = GT_LEDController.mConfigInfo[tmMarcos.kLEDConfig].ToString();
                this.ComboxComlist.Text = GT_LEDController.mConfigInfo[tmMarcos.kLEDCom].ToString();
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

        public void UpdateByLightData(LEDLightData data)
        {
            //Todo: add 
            this.lbcalibtime.Text = data.m_dt.ToString("yyyy-MM-dd HH:mm:ss");
            listboxlightdata.Items.Clear();
            int nindex = 0;
            foreach (int nvalue in data.m_listvalue) 
            {
                listboxlightdata.Items.Add(string.Format("------LED{0}:{1}",nindex,nvalue));
                nindex++;
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
                GT_LEDController.mConfigInfo[tmMarcos.kLEDCom] = this.ComboxComlist.Text;
                if(this.tbConfig.TextLength > 0)
                    GT_LEDController.mConfigInfo[tmMarcos.kLEDConfig] = this.tbConfig.Text;
                GT_LEDController.mConfigInfo.WriteXml(GT_LEDController.mCfgFilePath);

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            return;           
        }


        private void btnCalibLeft_Click(object sender, EventArgs e)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = 0;
            dic["profile"] = tmEnvironment.AppDir() + @"profile\Glass_Alsar_Calibration_Left.lua";
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kLoadLeftPulsarProfile, dic);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCalibRight_Click(object sender, EventArgs e)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = 0;
            dic["profile"] = tmEnvironment.AppDir() + @"profile\Glass_Alsar_Calibration_Right.lua";
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kLoadRightPulsarProfile, dic);
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private int nvalue = 25000;
        private void button1_Click(object sender, EventArgs e)
        {
            ScriptEngine pscript = GT_LEDController.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
            if (pscript != null)
            {
                nvalue += 100;
                int nindex = comboBox1.SelectedIndex >= 0 ? comboBox1.SelectedIndex : 0;
                string str = string.Format("llc.Write_LEDValue(\"Left\",{0},{1});",nindex, nvalue);
                pscript.DoString(str);
                label5.Text = string.Format("{0}", nvalue);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScriptEngine pscript = GT_LEDController.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
            if (pscript != null)
            {
                nvalue -= 100;
                int nindex = comboBox1.SelectedIndex >= 0 ? comboBox1.SelectedIndex : 0;
                string str = string.Format("llc.Write_LEDValue(\"Left\",{0},{1});",nindex, nvalue);
                pscript.DoString(str);
                label5.Text = string.Format("{0}",nvalue);
            }
        }

        private void bnOff_Click(object sender, EventArgs e)
        {
            ScriptEngine pscript = GT_LEDController.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
            if (pscript != null)
            {
                int nindex = comboBox1.SelectedIndex >=0?comboBox1.SelectedIndex:0;
                string str = string.Format("llc.Close_LED(\"Left\",{0});",nindex);
                pscript.DoString(str);
            }
        }

        private void bnSave_Click(object sender, EventArgs e)
        {

        }

        private void bnCycle_Click(object sender, EventArgs e)
        {
            ScriptEngine pscript = GT_LEDController.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
            if (pscript != null)
            {
                string str = string.Format("llc.CycleTest(\"Left\");");
                pscript.DoString(str);
            }
        }

        private void bnOn_Click(object sender, EventArgs e)
        {
            ScriptEngine pscript = GT_LEDController.m_TestEngine.GetScriptEngine(0) as ScriptEngine;
            if (pscript != null)
            {
                nvalue = 25000;
                int nindex = comboBox1.SelectedIndex >= 0 ? comboBox1.SelectedIndex : 0;
                nvalue = GT_LEDController.m_object.Get_lightValue("Left",nindex);
                string str = string.Format("llc.Write_LEDValue(\"Left\",{0},{1});", nindex, nvalue);
                pscript.DoString(str);
                label5.Text = string.Format("{0}", nvalue);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateConnectStatue()
        {
            if (GT_LEDController.m_object.IsOpen)
            {
                this.Text = "Pulsar 1 Connected.";
            }
            else
            {
                this.Text = "Pulsar 1 Not Connect.";
            }
        }
    }
}
