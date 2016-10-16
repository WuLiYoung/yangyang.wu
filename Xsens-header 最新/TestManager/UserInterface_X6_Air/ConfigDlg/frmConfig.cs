using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;

namespace UserInterface
{
    public partial class frmConfig : Form,IConfig
    {
        DictionaryEx dicConfig;
        public frmConfig()
        {
            InitializeComponent();
        }

        public DictionaryEx GetConfig()
        {
            return dicConfig;
        }

        public void SetConfig(DictionaryEx dic)
        {
            dicConfig = dic;
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            lvIndex.Items[0].Selected = true;
        }

        public void AddPanel(string name,Form panel,object img)
        {
            if (img.GetType()==typeof(Icon))
            {
                imageList1.Images.Add(img as Icon);
            }
            else if (img.GetType()==typeof(Image))
            {
                imageList1.Images.Add(img as Image);
            }
            else
            {
                imageList1.Images.Add(img as Image);
            }

            panel.FormBorderStyle = FormBorderStyle.None;
            panel.TopLevel = false;
            panel.Size = panel1.Size;
            panel1.Controls.Add(panel);
            lvIndex.Items.Add(name, imageList1.Images.Count-1);
        }

        private void lvIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView list = sender as ListView;

            ListView.SelectedIndexCollection indexs = list.SelectedIndices;
            if (indexs.Count == 0) return;
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Visible = (i == indexs[0]);
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {

        }
    }
}
