using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Interface;
using TestStudio.Automation.TestManager.libCommon.Class;

namespace UserInterface.ConfigDlg
{
    public partial class frmGeneralSetting : Form,IConfig
    {
        DictionaryEx dicConfig;
        public frmGeneralSetting()
        {
            InitializeComponent();
        }

        private void frmGeneralSetting_Load(object sender, EventArgs e)
        {

        }

        private void btBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.SelectedPath = txtDatapath.Text;
            if (dlg.ShowDialog(this)==DialogResult.OK)
            {
                txtDatapath.Text = dlg.SelectedPath;
            }
        }

        private void frmGeneralSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult ret = this.DialogResult;
        }

        public DictionaryEx GetConfig()
        {
            dicConfig[tmMarcos.kConfigLogDir] = txtDatapath.Text;
            dicConfig[tmMarcos.kConfigScanBarcode] = cbScanBarCode.Checked==true?1:0;
            dicConfig[tmMarcos.kConfigStationName] = textBoxStationName.Text;
            return dicConfig;
        }

        public void SetConfig(DictionaryEx dic)
        {
            dicConfig = dic;
            txtDatapath.Text = dic[tmMarcos.kConfigLogDir] as string;
            try
            {
                if (dic.ContainsKey(tmMarcos.kConfigStationName))
                {
                    textBoxStationName.Text = dic[tmMarcos.kConfigStationName] as string;
                }
                if(dic.ContainsKey(tmMarcos.kConfigScanBarcode))
                {
                    cbScanBarCode.Checked = (bool)((int)dic[tmMarcos.kConfigScanBarcode]==0?false:true);
                }
               
            }
            catch (Exception )
            {
                cbScanBarCode.Checked = true;
            }
        }
    }
}
