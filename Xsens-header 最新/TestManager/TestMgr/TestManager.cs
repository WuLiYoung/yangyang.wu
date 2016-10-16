using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Xml;


using TestStudio.Automation.TestManager.libCommon.Interface;
using TestStudio.Automation.TestManager.libCommon.Class;

namespace TestMgr
{
    public class TestManager
    {
        bool m_bSelfTest = true;
        string strRoot = tmEnvironment.AppDir();
        DictionaryEx m_dicContext = new DictionaryEx();

        int module = 6;
        int slot = 6; //这里决定一次测试的UUT数量lxl
        public void App_Load()
        {
            DictionaryEx dic = new DictionaryEx();
            m_dicContext["slot"] = slot;
            m_dicContext["module"] = module;
            string[] f = ListTm();
            if (f.Length == 0)
            {
                MessageBox.Show("Couldn't find TM module file!", "Load TM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (f.Length == 1)
            {
                if (!LoadTmFile(f[0], dic))
                {
                    MessageBox.Show("Load failed", "Load TM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {

                }
            }
            else
            {

            }
            LoadTM(dic);
            //timerSplash.Enabled = false;
        }

        string[] ListTm()
        {
            string p = System.AppDomain.CurrentDomain.BaseDirectory;
            string[] f = Directory.GetFiles(p, "*.tm");
            return f;
        }

        bool LoadTmFile(string filepath, DictionaryEx dic)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            try
            {
                XmlNodeList nodeList = doc.GetElementsByTagName("Module");
                if (0 == nodeList.Count) throw new Exception("no Module");
                XmlElement module = nodeList.Item(0) as XmlElement;
                string name = module.GetAttribute("name");
                if (name == null)
                {
                    name = "Unkown Module";
                }
                dic["name"] = name;

                XmlElement element;
                //ui
                nodeList = module.GetElementsByTagName("ui");
                if (0 == nodeList.Count) throw new Exception("no specical user interface path");
                element = nodeList.Item(0) as XmlElement;
                dic["ui"] = element.InnerText;

                //engine
                nodeList = module.GetElementsByTagName("engine");
                if (nodeList == null) throw new Exception("no specical test engine path");
                element = nodeList.Item(0) as XmlElement;
                string txt = element.InnerText;
                dic["engine"] = element.InnerText;

                //instruments
                nodeList = module.GetElementsByTagName("instruments");
                if (nodeList.Count != 0)
                {
                    element = nodeList.Item(0) as XmlElement;
                    nodeList = element.GetElementsByTagName("instrument");
                    List<string> arr = new List<string>();
                    foreach (XmlNode node in nodeList)
                    {
                        arr.Add(node.InnerText);
                    }
                    dic["instruments"] = arr.ToArray();
                }
            }
            catch (System.Exception e)
            {
                return false;
            }
            return true;
        }

        public bool LoadTM(Dictionary<string,object> dic)
        {
            string p;
            try
            {
                //Engine
                p = dic["engine"] as string;
                if (null==p)
                {
                    throw new Exception("No Specical test engine module!");
                }

                if (!Path.IsPathRooted(p))
                {
                    p = Path.Combine(strRoot, p);
                }

                NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Loading " + Path.GetFileName(p));
                LoadEngine(p);
                NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Load " + Path.GetFileName(p) + "successful");

                //Instruments;                
                if (dic.ContainsKey("instruments"))
                {
                    string[] instr = dic["instruments"] as string[];
                    foreach (string i in instr)
                    {
                        if (!Path.IsPathRooted(i))
                        {
                            p = Path.Combine(strRoot, i);
                        }

                        NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Loading " + Path.GetFileName(p));
                        IModule m = LoadInstrument(i);
                        NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Load " + Path.GetFileName(p) + "successful");
                        m.Load(this, m_dicContext);
                        m.Initial(this, m_dicContext);
                        m.RegisterModule(this, m_dicContext);
                    }
                }

                //UI
                p = dic["ui"] as string;
                if (null != p)
                {
                    if (!Path.IsPathRooted(p))
                    {
                        p = Path.Combine(strRoot, p);
                    }
                    load_ui(p);
                }

                NotificationCenter.DefaultCenter().PostNotification("LoadTM", "Load ui successful");
                Application.DoEvents();
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message+"\r\n"+e.StackTrace,e.Source);
                return false;
            }
            return true;
        }

        IModule load_ui(string filepath)
        {
            IModule ui = LoadInstrument(filepath);
            ui.Load(this, m_dicContext);
            ui.Initial(this, m_dicContext);
            ui.RegisterModule(this, m_dicContext);
            return ui;
        }
    
        public int LoadEngine(string path)
        {
            IModule engine = LoadInstrument(path);
            engine.Load(this, m_dicContext);
            engine.Initial(this, m_dicContext);
            if (m_bSelfTest)
            {
                engine.SelfTest(this, m_dicContext);
            }
            return 0;
        }

        public IModule LoadInstrument(string filepath)
        {
            Assembly asm = Assembly.LoadFrom(filepath);
            if (null == asm) return null;
            IModule module = null;


            //Create Module
            PrincipalClass classname = Attribute.GetCustomAttribute(asm, typeof(PrincipalClass)) as PrincipalClass;
            if (null != classname)
            {
                module = asm.CreateInstance(classname.ClassName) as IModule;
                return module;
            }
            else
            {
                //No special, then list all the class type.
                foreach (Type t in asm.GetTypes())
                {
                    if (t.GetInterface("IModule") != null)
                    {
                        module = asm.CreateInstance(t.FullName) as IModule;
                        return module;
                    }
                }
            }
            return null;
        }
    }
}
