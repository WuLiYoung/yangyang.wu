using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

using TestStudio.Automation.TestManager.libCommon.Class;

namespace Engine
{
    class TestEngine:TestStudio.Automation.TestManager.libCommon.Class.Engine
    {
        //Thread[] m_TestThread = null;
        //List<Thread> m_TestThread = new List<Thread>();
        Thread[] m_TestThread;  //thread handle;
        List<ScriptEngine> m_ScriptEngine = new List<ScriptEngine>();
        List<TestContext> m_TestContext = new List<TestContext>();
        tmTreeNode m_ItemTree;
        bool m_bStepSync = false;
        AutoResetEvent m_DoEvent;
        //List<ManualResetEvent> m_SyncEvent = new List<ManualResetEvent>();
        ManualResetEvent[] m_SyncEvent;
        //List<ManualResetEvent> m_ThreadEvent = new List<ManualResetEvent>();
        ManualResetEvent[] m_ThreadEvent;
 

        public TestEngine(int module)
        {
            m_ModuleCount = module;
            //m_TestThread.Clear();
            m_TestThread = new Thread[module];
            m_SyncEvent = new ManualResetEvent[module];
            m_ThreadEvent = new ManualResetEvent[module];

            for (int i = 0; i < module; i++)//module=1
            {
                //Create test context
                TestContext tc = new TestContext();
                tc.m_dicContext["uid"] = i;
                m_TestContext.Add(tc);//engine 里存了两个上下文对象，m_TestContext是数组
                m_SyncEvent[i] = new ManualResetEvent(false);
                m_ThreadEvent[i] = new ManualResetEvent(false);
            }

            this.Initial_Script(module);
        }
        
        /// <summary>
        /// Script Engine Initial
        /// </summary>
        /// <param name="module"></param>
        private void Initial_Script(int module)
        {
            for (int i = 0; i < module;i++)
            {
                //Create Script Engine;
                //ScriptEngine sc = new ScriptEngine();
                luaEngine sc = new luaEngine();
                m_ScriptEngine.Add(sc);
                sc.DoString(string.Format("ID={0}", i));

                string cmd = System.IO.Path.Combine(tmEnvironment.AppDir(), @"Script\?.lua");
                cmd = string.Format(@"package.path = package.path..';'..'{0}'",cmd);
                cmd = cmd.Replace("\\", "\\\\");
                Console.WriteLine(cmd);
                sc.DoString(cmd);
                sc.DoFile(System.IO.Path.Combine(tmEnvironment.AppDir(), @"Script\Execute.lua"));
                sc.RegisterFunction("UUT_SYNCH", this, this.GetType().GetMethod("UUT_SYNCH"));
            }
        }


        public override int StartTest(object arg)//调用这里启动测试
        {
            m_testStop = false;
            int index = 0;
            if (arg != null)
                index = (int)arg;

            int start_index=index;
            int stop_index=index;
            if (index<0)
            {
                start_index=0;
                start_index=m_ModuleCount;
            }
            for (int i = start_index; i < stop_index;i++ )
            {
                if (IsTesting(index) == 1)
                {
                    //System.Windows.Forms.MessageBox.Show("Can not Start a new Test while Test is Running!");
                    return 0;
                }
            }
            
            return base.StartTest(arg);
        }

        public int StartTest()
        {
            
            return base.StartTest(null);
        }

        public override int StopTest(object arg)
        {
            if (arg == null)
                return 0;
           int id=(int) arg;

           int start_index = id;
           int stop_index = id+1;
           if (id < 0)
           {
               start_index = 0;
               stop_index = m_ModuleCount;
           }
           for (int index = start_index; index < stop_index; index++)
           {
               try
               {
                   if (m_TestThread[index] != null)
                   {
                       
                       m_ScriptEngine[index].DoString("TestCancel();");
                      
                       //m_TestThread[id].Abort();
                       //让出时间给子线程执行  lxl
                       System.Threading.Thread.Sleep(100);
                       m_testStop = true;
                       //m_SyncEvent[id].Reset();
                   }
#if false
                   DictionaryEx dic = new DictionaryEx();
                   dic["id"] = index;
                   dic["state"] = 2;
                   NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestFinish, dic);
#endif
               }
               catch (ThreadAbortException e)
               {
                   //System.Windows.Forms.MessageBox.Show(e.Message);
               }
               
           }
           return 0;
        }

        public int StopTest()
        {
            return base.StopTest(null);
        }

        public override int PauseTest(object arg)
        {
            return base.PauseTest(arg);
        }
        public override int ResumeTest(object arg)
        {
            return base.ResumeTest(arg);
        }
        public override int IsTesting(int index)
        {
            if (m_TestThread.Count() <= index)
                return 0;
            if (index < 0)
            {
                int newstate = 0;
                for (int nsize = 0;nsize< m_TestThread.Length; nsize++)
                {
                    if (IsTesting(nsize) == 1)
                    {
                        newstate = 1;
                        break;
                    }
                        
                }
                return newstate;
            }
            Thread t = m_TestThread[index] as Thread;
            if (t==null) return 0;

            int state = 0;
            switch (t.ThreadState)
            { 
                case ThreadState.Aborted:
                case ThreadState.Stopped:
                case ThreadState.Unstarted:
                    state = 0;
                    break;
                default:
                    state = 1;
                    break;
            }
            return state;            
        }
        
        public override int RegisterModule(object module)
        {
            return 0;
        }
        public override int RegisterScript(string szpath)
        {
            foreach (ScriptEngine sc in m_ScriptEngine)
            {
                sc.DoFile(szpath);
            }
            return 0;
        }
        public override int RegisterString(string szbuffer)
        {
            foreach (ScriptEngine sc in m_ScriptEngine)
            {
                sc.DoString(szbuffer);
            }
            return 0;
        }
        public override object GetScriptEngine(int index)
        {
            if ((index<0)||(index>=m_ScriptEngine.Count)) return null;
            return m_ScriptEngine[index];
        }
        public override object GetTestContext(int index)
        {
            if ((index < 0) || (index >= m_TestContext.Count)) return null;
            return m_TestContext[index];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public override int LoadProfile(string file)//这里发消息，桌面去加载
        {
            try
            {
                DictionaryEx dic = new DictionaryEx();
                foreach (ScriptEngine se in m_ScriptEngine)
                {
                    se.DoFile(file);
                }
                System.Threading.Thread.Sleep(100);
                m_ItemTree = tmEnvironment.ParseProfile(this);
                if (m_ItemTree != null)
                {
                    dic["items"] = m_ItemTree;
                }
                string Module = tmEnvironment.ParseModule(this);
                if (Module != null)
                {
                    dic["Module"] = Module;
                }
                string Version = tmEnvironment.ParseVersion(this);
                if (Version != null)
                    dic["Version"] = Version;
                NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnLoadProfile, dic);
                return 0;
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Source+e.Message, "Load Profile Failed", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return -1;
        }

        public override int LoadTestCaseFromDb(string file)//这里发消息，桌面去加载
        {
            try
            {
                DictionaryEx dic = new DictionaryEx();
#if false
            m_ItemTree = tmEnvironment.LoadProfile(file);
            dic["items"]=m_ItemTree;

                TestContext.testcaseList.Clear();//清除
                string sqlstr = "SELECT testcase ,testcasedescrip ,Unit,Lowlimit,NominalValue,Highlimit ,RetryTimes ,Visible,TestIndex ,StopOnError ,Timeout,Time,UserName,action FROM HRS_TESTCASE order by id asc";
                SqlDataReader myReader = TestContext.dbhelp.ExecuteReader(sqlstr, CommandType.Text);

                string testcase, descrip, unit, low, high, visible, testindex, stoponerr, usernm, action;
                StringBuilder sb = new StringBuilder();

                sb.Append("local Test_Item_Sub={");

                string temp1, temp2, temp3;

               temp1 = "{name=\"testscription\",lower=\"\",upper=\"\",unit=nil,entry=function,visible=1,sub=nil},";//普通函数  testindex=0

                //temp1 = "{name=\"testscription\",lower=nil,upper=nil,unit=nil,entry=function,visible=1,sub=nil},";//普通函数  testindex=0

                temp2 = "{name=\"testscription\",lower=nil,upper=nil,unit=nil,entry=function,sub=nil,visible=1,parameter={index=1,remark=\"\"}},";//供电 unit=nil
                temp3 = "{name=\"testscription\",lower=nil,upper=nil,unit=\"mV\",entry=function,sub=nil,visible=1,parameter={index=1,Chnnel=\"Dev2/ai0\",rate=4000.0,  minnum=0,  maxmum=2.0,time=0.25}},";//采集
                if (myReader.FieldCount > 3)
                {
                    System.Windows.Forms.MessageBox.Show("connect  sucessful");
                }
                while (myReader.Read())
                {
                    string result;
                    testcase = myReader["testcase"].ToString();
                    descrip = myReader["testcasedescrip"].ToString();
                    unit = myReader["Unit"].ToString();
                    low = myReader["Lowlimit"].ToString();
                    high = myReader["Highlimit"].ToString();
                    visible = myReader["Visible"].ToString();

                    testindex = myReader["TestIndex"].ToString();
                    stoponerr = myReader["StopOnError"].ToString();
                    usernm = myReader["UserName"].ToString();
                    action = myReader["action"].ToString();
                    TestContext.testcaseList.Add(testcase);//添加到 tsetcase中
                    if (descrip.Substring(0, 5) == "Suply")//供电
                    {
                        Regex regex1 = new Regex("testscription", RegexOptions.IgnoreCase);
                        Regex regex2 = new Regex("function", RegexOptions.IgnoreCase);
                        Regex regex3 = new Regex("visible=1", RegexOptions.IgnoreCase);
                        Regex regex4 = new Regex("index=1", RegexOptions.IgnoreCase);
                        string indexexp = "index=";
                        indexexp = indexexp + testindex;

                        result = regex1.Replace(temp2, descrip);//1 次替换
                        result = regex2.Replace(result, action);//2次替换
                        string tempstr;
                        if (visible == "TRUE")
                        {
                            tempstr = "visible=1";
                        }
                        else
                        {
                            tempstr = "visible=0";
                        }

                        result = regex3.Replace(result, tempstr);
                        result = regex4.Replace(result, indexexp);
                    }

                    else if (unit != "")//表示读电压
                    {
                        string lowexp = "lower=";
                        string upperexp = "upper=";

                        string indexexp = "index=";
                        indexexp = indexexp + testindex;

                        lowexp = lowexp + low;
                        upperexp = upperexp + high;
                        Regex regex1 = new Regex("testscription", RegexOptions.IgnoreCase);
                        Regex regex2 = new Regex("function", RegexOptions.IgnoreCase);
                        Regex regex3 = new Regex("visible=1", RegexOptions.IgnoreCase);
                        Regex regex4 = new Regex("lower=nil", RegexOptions.IgnoreCase);
                        Regex regex5 = new Regex("upper=nil", RegexOptions.IgnoreCase);
                        Regex regex6 = new Regex("index=1", RegexOptions.IgnoreCase);

                        result = regex1.Replace(temp3, descrip);//1 次替换
                        result = regex2.Replace(result, action);//2次替换
                        string tempstr;
                        if (visible == "TRUE")
                        {
                            tempstr = "visible=1";
                        }
                        else
                        {
                            tempstr = "visible=0";
                        }

                        result = regex3.Replace(result, tempstr);
                        result = regex4.Replace(result, lowexp);
                        result = regex5.Replace(result, upperexp);
                        result = regex6.Replace(result, indexexp);

                    }
                    else
                    {
                        Regex regex1 = new Regex("testscription", RegexOptions.IgnoreCase);
                        Regex regex2 = new Regex("function", RegexOptions.IgnoreCase);
                        Regex regex3 = new Regex("visible=1", RegexOptions.IgnoreCase);

                        result = regex1.Replace(temp1, descrip);//1 次替换
                        result = regex2.Replace(result, action);//2次替换
                        string tempstr;
                        if (visible == "TRUE")
                        {
                            tempstr = "visible=1";
                        }
                        else
                        {
                            tempstr = "visible=0";
                        }
                        result = regex3.Replace(result, tempstr);
                    }
                    sb.Append(result);

                }

                sb.Remove(sb.ToString().LastIndexOf(','), 1);

                sb.Append("}");

                sb.Append("local Test_Item = {name=\"Initial\",lower=\"\",upper=\"\",entry=nil,parameter=nil,sub=Test_Item_Sub};");
                sb.Append("items = {Test_Item };");
                string luastr = sb.ToString();
                //SqlDbHelper dbhelp = new SqlDbHelper();
                foreach (ScriptEngine se in m_ScriptEngine)
                {
                    se.DoFile(file);
                    se.DoString(luastr);

                }
                m_ItemTree = tmEnvironment.ParseProfile(this);
                dic["items"] = m_ItemTree;
                NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnLoadProfile, dic);
#endif
                return 0;
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Load Profile Failed", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return -1;
        }
        /// <summary>
        /// Test Entry: the entry of thread manager
        /// </summary>
        /// <param name="obj"></param>
        protected override void TestEntry(object obj)
        {
#if false
            try
            {
                m_TestThread.Clear();
                m_ThreadEvent.Clear();

                for (int i = 0; i < m_ModuleCount; i++)
                {
                    //m_ScriptEngine[i].DoString("__initial_test();");
                }

                for (int i = 0; i < m_ModuleCount; i++)
                {

                    //Synch Event
                    m_SyncEvent[i].Reset();

                    string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                    bool b = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                    if (b)
                    {
                        ManualResetEvent te = new ManualResetEvent(false);
                        m_ThreadEvent.Add(te);

                        //Creat env
                        DictionaryEx dic = new DictionaryEx();
                        dic["engine"] = this;
                        dic["id"] = i;
                        dic["event"] = m_ThreadEvent[i];

                        //Create Thread
                        Thread t = new Thread(delegate() { UnitEntry(dic); });
                        t.IsBackground = true;
                        t.Start();
                        m_TestThread.Add(t);
                    }
                }


                //wait all test thread finish
                WaitHandle.WaitAll(m_ThreadEvent.ToArray());

                for (int i = 0; i < m_ModuleCount; i++)
                {
                    //m_ScriptEngine[i].DoString("__finish_test();");
                }
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, e.Source, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
#else
            try
            {
                int index;
                if (obj!=null)
                {
                    System.Diagnostics.Debug.Assert(obj.GetType() == typeof(int), 
                        "Invalid arguments for call engine startTest,arguments should int.");
                    index = (int)obj;
                    System.Diagnostics.Debug.Assert(index < m_ModuleCount, 
                        string.Format("Invalid arguments for call engine startTest,arguments should < {0}", m_ModuleCount));
                }
                else
                {
                    index = -1;
                }

                if (index>0)    //startup one thread,should not lock by step
                {
                    System.Diagnostics.Debug.Assert(m_bStepSync == false, 
                        string.Format("In engine step lock mode,couldn't performance only one task at specaile slot : {0}",index));
                }


                //m_ThreadEvent.Clear();
                int start_uut = 0;
                int stop_uut = 0;
                if (index<0)
                {
                    start_uut = 0;
                    stop_uut = m_ModuleCount;
                }
                else
                {
                    start_uut = index;
                    stop_uut = start_uut + 1;
                }
                // 0,1 or 1,2
                for (int i = start_uut; i < stop_uut; i++)//保证一次启动一个线程 
                {
                    //Synch Event
                    m_SyncEvent[i].Reset();

                    string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                    bool b = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                    if (b)
                    {
                        //ManualResetEvent te = new ManualResetEvent(false);
                        //m_ThreadEvent[i] = te;
                        m_ThreadEvent[i].Reset();

                        //Creat env
                        DictionaryEx dic = new DictionaryEx();
                        dic["engine"] = this;
                        dic["id"] = i;
                        dic["event"] = m_ThreadEvent[i];

                        //Create Thread
                        Thread t = new Thread(delegate() { UnitEntry(dic); });
                        t.IsBackground = true;
                        t.Start();
                        m_TestThread[i] = t;
                    }
                }
                //wait all test thread finish
                WaitHandle.WaitAll(m_ThreadEvent.ToArray());
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, e.Source, 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            finally
            {
            }
#endif
        }
        /// <summary>
        /// unit entry, the entry of test thread.
        /// </summary>
        /// <param name="obj"></param>
        private void UnitEntry(object obj)
        {
            DictionaryEx dic = obj as DictionaryEx;
            TestEngine engine = dic["engine"] as TestEngine;
            int id = (int)dic["id"];
            ManualResetEvent ent = dic["event"] as ManualResetEvent;

            try
            {
                //DoTest(m_ItemTree, obj);
                DoTest_LUA(m_ItemTree,obj);
            }
            catch (System.Exception e)
            {
                DictionaryEx d = new DictionaryEx();
                d["exception"] = e;
                d["id"] = id;
                NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kOnTestError, d);
            }
            finally
            {
                ent.Set();  //notify this thread has finished!
            }            
        }

        void DoTest(tmTreeNode itemTree,object obj)
        {
            DictionaryEx dic = obj as DictionaryEx;
            TestEngine engine = dic["engine"] as TestEngine;
            int id = (int)dic["id"];

            ScriptEngine se = engine.GetScriptEngine(id) as ScriptEngine;

            foreach (tmTreeNode c in itemTree.ChildNodes())
            {

                if (c.ChildNodes().Count > 0)   //key item
                {
                    DoTest(c, obj);
                    continue;
                }

                TestItem t = c.RepresentObject() as TestItem;
                m_SyncEvent[id].Set();
                UUT_SYNCH(0);
                Thread.Sleep(1000);
                object[] value = Execute_Item(se, t);
            }
        }

        void DoTest_LUA(tmTreeNode itemTree, object obj)
        {
            DictionaryEx dic = obj as DictionaryEx;
            TestEngine engine = dic["engine"] as TestEngine;
            int id = (int)dic["id"];

            ScriptEngine se = engine.GetScriptEngine(id) as ScriptEngine;

            se.DoString("return main()");   //goto main...
        }

        object[] Execute_Item(ScriptEngine se,TestItem item)
        {
            string buffer = "return __Execute_Item(" + item.ToString() + ")";
            return se.DoString(buffer);
        }

        public int  UUT_SYNCH(int id)
        {
            if (!m_bStepSync) return 0; //no need synch
            m_SyncEvent[id].Set();
            WaitHandle.WaitAll(m_SyncEvent.ToArray());
            foreach (ManualResetEvent e in m_SyncEvent)
            {
                e.Reset();
            }
            return 0;
        }
    }
}
