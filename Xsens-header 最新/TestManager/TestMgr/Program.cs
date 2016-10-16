using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;

using TestStudio.Automation.TestManager.libCommon.Class;

namespace TestMgr
{
    static class Program
    {
        static DictionaryEx dicAppConfig = new DictionaryEx();
        static TestManager m_TestManager = new TestManager();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashForm splash = new SplashForm();
            splash.Show();
            Application.DoEvents();            
            m_TestManager.App_Load();
            Application.DoEvents();
            FormCollection f = Application.OpenForms;
            if (f.Count>0)
            {
                MenuStrip m = f[0].MainMenuStrip;
            }
            splash.Close();
            Application.Run();
        }

        static void LoadConfig()
        {
            dicAppConfig["module"] = 1;
            dicAppConfig["thread"] = 1;
        }
    }
}
