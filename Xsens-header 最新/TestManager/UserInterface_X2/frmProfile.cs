using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestStudio.Automation.TestManager.libCommon.Class;


namespace UserInterface
{
    public partial class frmProfile : Form
    {

        string mProfilePath = tmEnvironment.AppDir() + "Profile\\";
        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            try
            {
                int index = 0;
                foreach (string p in System.IO.Directory.GetFiles(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Profile"), "*.lua", System.IO.SearchOption.TopDirectoryOnly))
                {
                    ListViewItem t = new ListViewItem(string.Format("{0:00}", index++));
                    t.SubItems.Add(p);
                    lvProfile.Items.Add(t);

                }
                foreach (string p in System.IO.Directory.GetFiles(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Profile"), "*.prf", System.IO.SearchOption.TopDirectoryOnly))
                {
                    ListViewItem t = new ListViewItem(string.Format("{0:00}", index++));
                    t.SubItems.Add(p);
                    lvProfile.Items.Add(t);

                }
                lvProfile.Columns[0].Width = (int)(lvProfile.Width * 0.1);
                lvProfile.Columns[1].Width = (int)(lvProfile.Width * 0.9);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
            }            
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (lvProfile.SelectedItems.Count < 1)
                return;
            ListViewItem.ListViewSubItem lvsItem = lvProfile.SelectedItems[0].SubItems[1];
            string fullPath = lvsItem.Text;
            MainForm.m_dicConfig["profile_path"] = fullPath;
            MainForm.SaveConfig();
            GT_UserInterface.m_TestEngine.LoadProfile(fullPath);//这个是加载lua测试脚本
            this.Close();
            return;
        }

        private void lvProfile_DoubleClick(object sender, EventArgs e)
        {
            this.btOK.PerformClick();
        }

        private void lvProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvProfile.SelectedItems.Count>0)
            {
                txtProfilePath.Text = lvProfile.SelectedItems[0].SubItems[1].Text;
            }
        }
    }
}
