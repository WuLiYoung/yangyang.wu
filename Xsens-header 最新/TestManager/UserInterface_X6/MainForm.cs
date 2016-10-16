using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
//using Fixture;
using WeifenLuo.WinFormsUI.Docking;
namespace UserInterface
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;
        private frmLog m_frmLog = new frmLog();
        public static DictionaryEx m_dicConfig = TestContext.m_dicConfig;//这个相当于一个指针的赋值。
      //  public Fixture.FixtureController fix;
        TestUnit UUT0;
        List<TestUnit>    m_UUTs = new List<TestUnit>();

        public frmTestState m_frmState = new frmTestState();
        static string strConfigFile = Path.Combine(tmEnvironment.AppDir(), @"Config\config.xml");

        
        public MainForm()
        {
            InitializeComponent();
            LoadConfig(strConfigFile);
        }

        public MainForm(object arg)
        {
            InitializeComponent();
            LoadConfig(strConfigFile);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)//打开文件
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)//save as
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //工具栏选择

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }
        //状态栏

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        //以上为窗口操作
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dockPanel.ShowDocumentIcon = true;
            DictionaryEx dic = new DictionaryEx();
            //如果没有配置的话就默认用当前的吧。
            if (TestContext.m_dicConfig[tmMarcos.kConfigStationName] == null)
            {
                string hostname = Dns.GetHostName();
                TestContext.m_dicConfig[tmMarcos.kConfigStationName] = hostname;
            }
            dic["instr"]=instrumentsToolStripMenuItem;//保存菜单项
            dic["dock"] = dockPanel;
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnUiLoadFinish,dic);

            UUT0 = new TestUnit(0);
            UUT0.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.Document);//显示两个测试单元
            m_UUTs.Add(UUT0);//为了多个UUT而做的

            //config the statue wnd
            m_frmLog.Show(dockPanel, WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide);//显示日志窗体
            m_frmLog.Hide();

            m_frmState.TopLevel = false;
            m_frmState.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(m_frmState);//管理状态窗体

            m_frmState.Size = panel1.Size;
            m_frmState.Visible = true;

           
            InitUiByUser();

            //Load Profile
            LoadDefaultProfile();
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnChangeUser, OnUserChange);
        }

        private static void LoadDefaultProfile()
        {
            string strprofile = m_dicConfig["profile_path"] as string;
            if (strprofile.Length == 0||Directory.Exists(strprofile))
            {
                strprofile = tmEnvironment.AppDir() + @"profile\Glass_Alsar_test.lua";
                m_dicConfig["profile_path"] = strprofile;
                m_dicConfig.WriteXml(strConfigFile);//save it.
            } 
            GT_UserInterface.m_TestEngine.LoadProfile(strprofile);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void debugLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_frmLog.Show();
        }

        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)//调出菜单事件config对话框
        {
            try
            {
                frmConfig config = new frmConfig();
                object obj = Properties.Resources.ResourceManager.GetObject("settings");
                ConfigDlg.frmGeneralSetting gnl = new ConfigDlg.frmGeneralSetting();//ConfigDlgs  是命名空间
                (gnl as IConfig).SetConfig(m_dicConfig);//设置界面的配置    是把主界面的配置的指针放进去，下一步在里边处理
                config.AddPanel("General", gnl, obj);
                obj = Properties.Resources.ResourceManager.GetObject("About");
                config.AddPanel("About", new ConfigDlg.frmAbout(), obj);
                if (config.ShowDialog(this) == DialogResult.OK)
                {
                    (gnl as IConfig).GetConfig();//这个是读出来吧
                    Directory.CreateDirectory(Path.GetDirectoryName(strConfigFile));
                    m_dicConfig.WriteXml(strConfigFile);
                    m_frmState.UpdateStationName();
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)//菜单事件 ，打开about dialog
        {
            ConfigDlg.frmAbout about = new ConfigDlg.frmAbout();
            about.ShowOkButton();
            about.ShowDialog(this);
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loadProfileToolStripMenuItem_Click(object sender, EventArgs e)//菜单事件 ，打开profile dialog
        {
            frmProfile prf = new frmProfile();
            prf.ShowDialog(this);
        }


        void LoadConfig(string file)
        {
            string[] key = { 
                                     tmMarcos.kConfigLogDir,
                                     tmMarcos.kConfigStationName,
                                     tmMarcos.kConfigLineName,
                                     "profile_path",
                                     tmMarcos.kConfigTestFlowPath,
                                   };
            string[] val = { 
                                     "C:\\work",//默认路径为C:\\work
                                     "Unknown Station",
                                     "Unknown Line",
                                     Path.Combine(tmEnvironment.AppDir(),"Profile\\Glass_Alsar_test.lua"),
                                     Path.Combine(tmEnvironment.AppDir(),"CVS"),
                                     };

            string[] UUTkey = {
                                     tmMarcos.kUUTEnable0,
                                     tmMarcos.kUUTEnable1,
                                     tmMarcos.kUUTEnable2,
                                     tmMarcos.kUUTEnable3,
                                     tmMarcos.kUUTEnable4,
                                     tmMarcos.kUUTEnable5,
                               
                               };
            bool[] UUTval = {
                                     true,
                                     true,
                                     true,
                                     true,
                                     true,
                                     true,                          
                          };
            try
            {
                if (!File.Exists(file)) // using default
                {
                    for (int i=0;i<key.Length;i++)
                    {
                        m_dicConfig[key[i]] = val[i];
                    }
                    for (int i = 0; i < UUTkey.Length; i++)
                    {
                        m_dicConfig[UUTkey[i]] = UUTval[i];
                    }
                }
                else
                {
                    m_dicConfig.ReadXmlFile(file);
                    for (int i = 0; i < UUTkey.Length; i++)
                    {
                        m_dicConfig[UUTkey[i]] = UUTval[i];
                    }
                    for (int i = 0; i < key.Length; i++)
                    {
                        if (!m_dicConfig.ContainsKey(key[i]))
                        {
                            m_dicConfig[key[i]] = val[i];
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                for (int i = 0; i < key.Length; i++)
                {
                    m_dicConfig[key[i]] = val[i];
                }
                for (int i = 0; i < UUTkey.Length; i++)
                {
                    m_dicConfig[UUTkey[i]] = UUTval[i];
                }
            }
            finally
            {
            }
            
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    //UUT0.StartTest();
                    if (frmTestState.NeedScanSN())
                    {
                        MessageBox.Show("Please scan the SN firstly!");
                    //    fix.WriteString("Tray putout\r\n");
                    }
                    else
                    {
                        GT_UserInterface.m_TestEngine.StartTest(-1);
                    }
            	    break;
                case Keys.F6:
                   // UUT0.StoptTest();
                    
                    for (int i = 0; i < 6;i++ )
                    {
                        GT_UserInterface.m_TestEngine.StopTest(i);
                    }
                    break;
                default:
                    break;
            }
        }


        public static void SaveConfig()
        {           
            m_dicConfig.WriteXml(strConfigFile);
            return;
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configurationToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            optionsToolStripMenuItem_Click(sender,e);
        }

        private void deviceInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComDeviceInfo pdeviceinfo = new ComDeviceInfo();
            pdeviceinfo.Show();
        }

        private void backToTestModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDefaultProfile();
        }

        public int OnUserChange(Notification nf)
        {
            InitUiByUser();
            return 0;
        }

        public void InitUiByUser()
        {
#if true
            if (TestContext.m_dicGlobal.ContainsKey(tmMarcos.kIsAdminLogin))
            {
                if ((int)TestContext.m_dicGlobal[tmMarcos.kIsAdminLogin] == 1)
                {
                    fileMenu.Enabled = true;
                    viewMenu.Enabled = true;
                    toolsMenu.Enabled = true;
                    instrumentsToolStripMenuItem.Enabled = true;
                    return;
                }
            }
            fileMenu.Enabled = false;
            viewMenu.Enabled = false;
            toolsMenu.Enabled = false;
            instrumentsToolStripMenuItem.Enabled = false;
#endif
        }
    }
}
