using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DataLogger;

//定义状态，1 无产品，2有产品尚未测试，3 正在测试，4  测试完毕，尚未取出

using TestStudio.Automation.TestManager.libCommon.Class;

namespace UserInterface
{
    public partial class TestUnit : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        int m_UUTID = -1;
        TestContext tc;
       DictionaryEx m_dicTestResult = new DictionaryEx();
       StringBuilder keystrArry = new StringBuilder();

       string uut0errcode;
       string uut1errcode;

       TimeSpan StartItemTest;
       TimeSpan EndItemTest;


       DataLogger.DataLogger testflow = new DataLogger.DataLogger();

        public TestUnit()
        {
            InitializeComponent();
            UpdateNeedScanCode();
        }

        private void UpdateNeedScanCode()
        {
            try
            {
                int nvalue = 1;
                if (TestContext.m_dicConfig.ContainsKey(tmMarcos.kConfigScanBarcode))
                {
                    nvalue = (int)TestContext.m_dicConfig[tmMarcos.kConfigScanBarcode];
                }
                else
                {
                    TestContext.m_dicConfig[tmMarcos.kConfigScanBarcode] = 1;
                }
                checkBoxNeedCode.Checked= nvalue==1?true:false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TestUnit(string title):this()//根据不同的窗体，标志不同的按钮
        {
            //InitializeComponent();
        }

        public TestUnit(int index)
            : this()//根据不同的窗体，标志不同的按钮
        {
            m_UUTID = index;
            tc = GT_UserInterface.m_TestEngine.GetTestContext(m_UUTID) as TestContext;//获取测试上下文数据
#if false   //Show UUTX title
            this.Text=string.Format("UUT{0}",index+1);
#endif            
        }

        private void TestUnit_Load(object sender, EventArgs e)
        {
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnLoadProfile,OnLoadProfile);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestStart, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestStop, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestPause, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestResume, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestItemStart, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestItemFinish, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestError, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestFinish, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnTestItemFinishEx, OnUiNotification);
            //add by lxl
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnGetSN, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnCtrlLamp, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnUpdateArMinMax,OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kLoadLeftPulsarProfile, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kLoadRightPulsarProfile, OnUiNotification);
            NotificationCenter.DefaultCenter().AddObserver(tmMarcos.kOnChangeUser, OnUiNotification);
        }
        
        int OnLoadProfile(Notification nf)
        {
            try
            {
                DictionaryEx dic = nf.context as DictionaryEx;
                tmTreeNode ItemTree = dic["items"] as tmTreeNode;
                lvTestItem.ShowGroups = false;
            
                List<tmTreeNode> Root = ItemTree.ChildNodes();
                int index = 0;
                int casenum=0;
                lvTestItem.Items.Clear();
                foreach (tmTreeNode t in Root)
                {
                    TestItem aItem = t.RepresentObject() as TestItem;
                    if (t.ChildNodes().Count > 0) //Group
                    {
                        //Create Group;
                        ListViewGroup group = lvTestItem.Groups.Add(aItem["name"] as string, aItem["name"] as string);
                        List<tmTreeNode> child = t.ChildNodes();
                        foreach (tmTreeNode c in child)
                        {
                            TestItem subitem = c.RepresentObject() as TestItem;
                            string testcase;
                            if (TestContext.testcaseList.Count>0)
                                testcase=TestContext.testcaseList[casenum++];

                            if (subitem.ContainsKey("visible"))
                            {
                                int v = Convert.ToInt32(subitem["visible"]);
                                if (v == 0) continue;   //no need show
                            }

                            ListViewItem lvItem = new ListViewItem(index++.ToString());
                            List<string> arrSub = new List<string>();
                            
                            //后边再处理lxl
                            arrSub.Add(subitem["name"] as string);

                            if (subitem.ContainsKey("lower"))
                            {
                                arrSub.Add(subitem["lower"] as string);
                            }
                            else
                            {
                                arrSub.Add("");
                            }

                            if (subitem.ContainsKey("upper"))
                            {
                                arrSub.Add(subitem["upper"] as string);
                            }
                            else
                            {
                                arrSub.Add("");
                            }

                            //arrSub.Add("");//time
                            arrSub.Add("");//UUT1
                            arrSub.Add("");//UUT2
                            arrSub.Add("");//UUT3
                            arrSub.Add("");//UUT4
                            arrSub.Add("");//UUT5
                            arrSub.Add("");//UUT6

                            if (subitem.ContainsKey("unit"))
                            {
                                arrSub.Add(subitem["unit"] as string);
                            }
                            else
                            {
                                arrSub.Add("");
                            }
                            if (subitem.ContainsKey("remark"))
                            {
                                arrSub.Add(subitem["remark"] as string);
                            }
                            else
                            {
                                arrSub.Add("");
                            }
                            lvItem.SubItems.AddRange(arrSub.ToArray());
                            lvItem.Group = group;

                            lvTestItem.Items.Add(lvItem);
                        }
                    }
                }
                //lxl 根据具体的脚本加载不同的
                string module = dic["Module"] as string;
                if (module != null)
                {
                }
                string version = dic["Version"] as string;
                if (version != null)
                {
                    lbscriptver.Text = version;
                }
                progressBar.Minimum = 0;
                progressBar.Maximum = lvTestItem.Items.Count;
                progressBar.Step = 1;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message, exp.Source);
            }
            return 0;
        }

        void Initial_Test()
        {
            foreach (ListViewItem it in lvTestItem.Items)
            {
                for (int i = 4; i < 10;i++ )
                {
                    it.SubItems[i].ForeColor = Color.Black;
                    it.SubItems[i].Text = "";
                }
            }
            progressBar.Value = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        int OnUiNotification(Notification nf)
        {
            string name = nf.name;
            DictionaryEx dic = nf.context as DictionaryEx;
            int id = (int)dic["id"];
            //if (id != m_UUTID) return 0;    //no this unit
            if ( name==tmMarcos.kOnTestStart)
            {
                this.OnTestStart(this, nf.context);
            }
            else if (name == tmMarcos.kOnTestStop)
            {
                this.OnTestStop(this, nf.context);
            }
            else if (name == tmMarcos.kOnTestPause)
            {
                this.OnTestPause(this, nf.context);
            }
            else if (name == tmMarcos.kOnTestResume)
            {
                this.OnTestResume(this, nf.context);
            }
            else if (name == tmMarcos.kOnTestItemStart)
            {
                this.OnItemStart(this, nf.context);
            }
            else if (name == tmMarcos.kOnTestItemFinish)
            {
                this.OnItemFinish(this, nf.context);
            }
            else if (name == tmMarcos.kOnTestFinish)
            {
                this.OnTestFinish(this, nf.context);
            }
            else if (name==tmMarcos.kOnTestError)
            {
                this.OnTestError(this, nf.context);
            }
            else if(name==tmMarcos.kDegbugMessage)
            {
            }
            else if (name == tmMarcos.kOnTestItemFinishEx)
            {
                this.OnItemFinishEx(this,nf.context);
            }
            else if (name == tmMarcos.kOnGetSN)
            {
                this.OnGetSN(this, nf.context);
            }
            return 0;
        }

        //UI update callback   userInterface中发消息，引起此操作
        int OnTestStart(object sender, object arg)//这里是显示测试状态的操作
        {
            if (this.InvokeRequired)
            {
                //前面建一个委托，后面是参数数组。
                return (int)Invoke(new delegateUiMessage(OnTestStart), new object[] { sender, arg });
            }
            DictionaryEx dic = arg as DictionaryEx;
            int id = (int)dic["id"];
            Initial_Test();
            try
            {
                TestContext context = GT_UserInterface.GetTestContext(id);
                context.m_dicContext[tmMarcos.kContextStartTime] = System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
                //tc.m_dicContext[tmMarcos.kContextStartTime] = System.DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss");
                //??
                TestContext.m_dicConfig[tmMarcos.kStarttime] = System.DateTime.Now.ToString("yyyy/MM/dd_HH:mm:ss");
                m_dicTestResult[tmMarcos.kTimeStamp] = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (TestContext.m_dicConfig[tmMarcos.kProjectType] != null)
                    m_dicTestResult[tmMarcos.kProjectType] = TestContext.m_dicConfig[tmMarcos.kProjectType].ToString();
                if (TestContext.m_dicConfig[tmMarcos.kStationType] != null)
                    m_dicTestResult[tmMarcos.kStationType] = TestContext.m_dicConfig[tmMarcos.kStationType].ToString();
                if (TestContext.m_dicConfig[tmMarcos.kDutType] != null)
                    m_dicTestResult[tmMarcos.kDutType] = TestContext.m_dicConfig[tmMarcos.kDutType].ToString();
                if (TestContext.m_dicConfig[tmMarcos.kStatinNum] != null)
                    m_dicTestResult[tmMarcos.kStatinNum] = TestContext.m_dicConfig[tmMarcos.kStatinNum].ToString();
                if (TestContext.m_dicConfig[tmMarcos.kAppVerSion] != null)
                    m_dicTestResult[tmMarcos.kAppVerSion] = TestContext.m_dicConfig[tmMarcos.kAppVerSion].ToString();

                if (TestContext.m_dicConfig[tmMarcos.kAppBuilderTime] != null)
                     m_dicTestResult[tmMarcos.kAppBuilderTime] = TestContext.m_dicConfig[tmMarcos.kAppBuilderTime].ToString();
                if (TestContext.m_dicConfig[tmMarcos.kWorkOrder] != null)
                    m_dicTestResult[tmMarcos.kWorkOrder] = TestContext.m_dicConfig[tmMarcos.kWorkOrder].ToString();
                if (TestContext.m_dicConfig[tmMarcos.kCusTomer] != null)
                    m_dicTestResult[tmMarcos.kCusTomer] = TestContext.m_dicConfig[tmMarcos.kCusTomer].ToString();

                StringBuilder Testflowpath = new StringBuilder();
                if (TestContext.m_dicConfig[tmMarcos.kConfigTestFlowPath] != null)
                    Testflowpath.Append(TestContext.m_dicConfig[tmMarcos.kConfigTestFlowPath].ToString());
                Testflowpath.Append("\\");
                if (TestContext.m_dicConfig[tmMarcos.kStationType] != null)
                    Testflowpath.Append(TestContext.m_dicConfig[tmMarcos.kStationType].ToString());
                Testflowpath.Append("_");
                if (tc.m_dicContext[tmMarcos.kContextMLBSN] != null)
                {
                    Testflowpath.Append(tc.m_dicContext[tmMarcos.kContextMLBSN].ToString());
                    Testflowpath.Append("_");
                }

                Testflowpath.Append(m_UUTID.ToString());
                Testflowpath.Append("_");
                Testflowpath.Append(System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                Testflowpath.Append("_flow.txt");
                testflow.SetFilepath(Testflowpath.ToString());//更新文件名
                testflow.push_testflowlog("Test start");
            }
            catch (Exception)
            {
            }
            if (this.MdiParent != null)
            {
                (this.MdiParent as MainForm).m_frmState.OnNotifyShowTestStart(id);
            }
            return 0;
        }

        int OnTestStop(object sender, object arg)
        {
            if (this.InvokeRequired)
            {
                delegateUiMessage uidel = new delegateUiMessage(OnTestStop);
                if (uidel != null && sender != null && arg != null)
                    return (int)Invoke(uidel, new object[] { sender, arg });
            }
            DictionaryEx dic = arg as DictionaryEx;
            int id = (int)dic["id"];
            int state = (int)dic["state"];
            (this.MdiParent as MainForm).m_frmState.OnNotifyShowTestFinish(id, state);
            return 0;
        }
        int OnTestPause(object sender, object arg)
        {
            return 0;
        }
        int OnTestResume(object sender, object arg)
        {
            return 0;
        }

        int OnItemStart(object sender, object arg)
        {
            if (this.InvokeRequired)
            {
                return (int)Invoke(new delegateUiMessage(OnItemStart), new object[] { sender, arg });
            }
            DictionaryEx dic = arg as DictionaryEx;
            int id = (int)dic["id"];
            int index = (int)dic["index"];

            ListViewItem.ListViewSubItemCollection sub = lvTestItem.Items[index].SubItems;
            lvTestItem.Items[index].SubItems[4+id].Text = "Testing...";
#if true
            string message;
            message = index.ToString();
            message = message + ":[";
            message = message + lvTestItem.Items[index].SubItems[2].Text;
            message = message + "]";
           
            message = message + "start test!";
            testflow.push_testflowlog(message);

            message = "start time:";
            message = message + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss:fff");
            testflow.push_testflowlog(message);
#endif
            StartItemTest = new TimeSpan(System.DateTime.Now.Ticks);
            if(progressBar.Value < progressBar.Maximum)
                progressBar.Value++;
            return 0;
        }
        int OnItemFinish(object sender, object arg)
        {
            if (this.InvokeRequired)
            {
                return (int)Invoke(new delegateUiMessage(OnItemFinish), new object[] { sender, arg });
            }
            DictionaryEx dic = arg as DictionaryEx;

            int id = (int)dic["id"];
            int index = (int)dic["index"];
            int state = (int)dic["state"];
            string val = dic["value"] as string;
            string remark = dic["remark"] as string;

            if (remark != null)
            {
                UpdateLampStatue(remark,state,val);
            }

            lvTestItem.EnsureVisible(index);
            ListViewItem.ListViewSubItemCollection sub = lvTestItem.Items[index].SubItems;
            lvTestItem.Items[index].UseItemStyleForSubItems = false;

            EndItemTest = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts = StartItemTest.Subtract(EndItemTest).Duration();
            //double totaltime = ts.Seconds;
            double totaltime = ts.Milliseconds;
            string testtime = totaltime.ToString();


            //添加测试时间 lxl
#if false
            lvTestItem.Items[index].SubItems[4].Text =testtime;
#endif
            string message;
            message = index.ToString(); 
#if true
            message = message + ":[";
            message = message + lvTestItem.Items[index].SubItems[1].Text;
            message = message + "]";
            message = message + "end test!";
            testflow.push_testflowlog(message);

            message = "end time:";
            message = message + System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            testflow.push_testflowlog(message);

            message = "LOW:";
            message = message + lvTestItem.Items[index].SubItems[3].Text;
            message = message + ",HIGH:";
            message = message + lvTestItem.Items[index].SubItems[4].Text;

            testflow.push_testflowlog(message);

            message = "VALUE:";
            message = message +val;
            testflow.push_testflowlog(message);

           // id = 0;fail
            if (state==0)
            {
                string messres;
                messres = "Test Result:FAIL";  
                testflow.push_testflowlog(messres);
                lvTestItem.Items[index].SubItems[4+ id].Text = val;
                lvTestItem.Items[index].SubItems[4 + id].ForeColor = Color.Red;
                if(id==0)
                {
                    string tempcode;
                    tempcode = lvTestItem.Items[index].SubItems[1].Text; //直接从控件里取
                    uut0errcode += tempcode;
                    uut0errcode += ",";
                }
                else if(id==1)
                {
                    string tempcode;
                    tempcode = lvTestItem.Items[index].SubItems[1].Text; 
                    uut1errcode += tempcode;
                    uut1errcode +=",";
                }
            }
            else if (state==1)
            {
                string messres;
                messres = "Test Result:PASS";
                testflow.push_testflowlog(messres);
                lvTestItem.Items[index].SubItems[4 + id].Text = val;
                lvTestItem.Items[index].SubItems[4 + id].ForeColor = Color.Green;

            }
            else if(state==2)
            {
                lvTestItem.Items[index].SubItems[4 + id].Text = "Skipped";
                lvTestItem.Items[index].SubItems[4 +id].ForeColor = Color.Cyan;
            }

            //添加代码保存值
            string TestScrip;
            TestScrip = lvTestItem.Items[index].SubItems[2].Text;
            if (index == 0)
            {
                keystrArry.Append(TestScrip);
            }
            else
            {
                keystrArry.Append(",");
                keystrArry.Append(TestScrip);//保存所有的测试项

            }
            StringBuilder mybuilder = new StringBuilder();
            if (index == 0)//第0项只保存一个值，其余保存的是一个逗号分隔的字符串
            {
                mybuilder.Append("'");
                mybuilder.Append(val);
                mybuilder.Append("'");

                testflow.push_testflowlog("");
                testflow.push_testflowlog("");
            }
            else
            {
                string mesgtime;
                mesgtime = "use time:";
                mesgtime = mesgtime + testtime;
                testflow.push_testflowlog(mesgtime);
                testflow.push_testflowlog("");
                testflow.push_testflowlog("");
                mybuilder.Append("'");
                mybuilder.Append(lvTestItem.Items[index].SubItems[3].Text);
                mybuilder.Append("'");
                mybuilder.Append(",");
                mybuilder.Append("'");
                mybuilder.Append(val);
                mybuilder.Append("'");
                mybuilder.Append(",");

                mybuilder.Append("'");
                mybuilder.Append(lvTestItem.Items[index].SubItems[4].Text);//upper
                mybuilder.Append("'");

                mybuilder.Append(",");
                mybuilder.Append("'");

                mybuilder.Append(testtime);//testtime 

                mybuilder.Append("'");
                mybuilder.Append(",");

                if (state == 0)
                {
                    mybuilder.Append("'");
                    mybuilder.Append("FAIL");
                    mybuilder.Append("'");
                }
                else
                {
                    mybuilder.Append("'");
                    mybuilder.Append("PASS");
                    mybuilder.Append("'");
                }
            }
            //这里存储值
            m_dicTestResult[TestScrip] = mybuilder.ToString();//保存该项的测试结果 
#endif
            return 0;
        }

        public int OnItemFinishEx(object sender, object arg)
        {
            if (this.InvokeRequired)
            {
                return (int)Invoke(new delegateUiMessage(OnItemFinishEx), new object[] { sender, arg });
            }
            DictionaryEx dic = arg as DictionaryEx;

            int id = (int)dic["id"];
            int state = (int)dic["state"];
            string val = dic["value"] as string;
            string exinfo = dic["exinfo"] as string;

            if (exinfo != null)
            {
                UpdateLampStatue(exinfo, state, val);
            }
            return 0;
        }

        private void UpdateLampStatue(string remark,int nstatue,string value)
        {
            int nalsc = 1;
            int nlamp = 0;
            string[] strs = remark.Split(new char[]{'-'});
            if (strs != null&&strs.Length==2)
            {
                nalsc = Convert.ToInt32(strs[0]);
                nlamp = Convert.ToInt32(strs[1]);
            }
        }
        int OnTestFinish(object sender, object arg)
        {
            //把显示的状态置空
            DictionaryEx dic = arg as DictionaryEx;
            int id = (int)dic["id"];
            int state = (int)dic["state"];
            if (this.MdiParent != null)
            {
                (this.MdiParent as MainForm).m_frmState.OnNotifyShowTestFinish(id, state);
            }
            TestContext context = GT_UserInterface.GetTestContext(id);
            DateTime starttime = DateTime.ParseExact(context.m_dicContext[tmMarcos.kContextStartTime] as string,"yyyy-MM-dd_HH:mm:ss",null);
            DateTime datetimenow = DateTime.Now;

            TimeSpan ts1 = new TimeSpan(datetimenow.Ticks);
            TimeSpan ts2 = new TimeSpan(starttime.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            context.m_dicContext[tmMarcos.kContextEndTime] = System.DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");
            context.m_dicContext[tmMarcos.kContextTestTime] = string.Format("{0:f2}", ts.TotalSeconds);
            Console.WriteLine(context.m_dicContext[tmMarcos.kContextTestTime] as string);
            return 0;
        }

        

        int OnTestError(object sender, object arg)
        {
            if (this.InvokeRequired)
            {
                return (int)Invoke(new delegateUiMessage(OnTestError), new object[] { sender, arg });
            }

            DictionaryEx dic = arg as DictionaryEx;
            if (dic["exception"] != null)
            {
                Exception e = dic["exception"] as Exception;
                int ID = (int)dic["id"];
                (this.MdiParent as MainForm).m_frmState.OnNotifyShowTestFinish(ID,2);
                MessageBox.Show(e.Source + e.Message,"LuaError");//the 2.0.4 is different from the 2.0.1
            }
            return 0;
        }

        int OnGetSN(object sender, object arg)
        {
            if (this.InvokeRequired)
            {
                return (int)Invoke(new delegateUiMessage(OnGetSN), new object[] { sender, arg });
            }
            DictionaryEx dic = arg as DictionaryEx;
            int nid     = (int)dic["id"];
            string  str = dic[tmMarcos.kContextMLBSN] as string;
            tc.m_dicContext[tmMarcos.kContextMLBSN] = str;
            return 0;
        }

        static void FlashEntry(object arg)
        {
        }

       private void btnUnitStart_Click(object sender, EventArgs e)
       {
           GT_UserInterface.m_TestEngine.StartTest(m_UUTID);
       }

       private void bnUnitStop_Click(object sender, EventArgs e)
       {
           GT_UserInterface.m_TestEngine.StopTest(m_UUTID);
       }

       private void checkBoxNeedCode_CheckedChanged(object sender, EventArgs e)
       {
           TestContext.m_dicConfig[tmMarcos.kConfigScanBarcode] = (checkBoxNeedCode.Checked == true ? 1 : 0);

       }

       private void SetMLBSNContext(string str)
       {
           if (str != null)
           {
               tc.m_dicContext[tmMarcos.kContextMLBSN] = str;
           }
       }

       private void tbUnitSN_KeyPress(object sender, KeyPressEventArgs e)
       {
           if (e.KeyChar == (char)Keys.Enter)
           {
               SetMLBSNContext(tbUnitSN.Text);
               //if only one UUT enable 
               int count = 0;
               for (int i = 0; i < 6; i++)
               {
                   string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                   bool bEnable = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                   if (!bEnable)
                   {
                       continue;
                   }
                   count++;
               }
               if (count == 1)
               {

                   for (int i = 0; i < 6; i++)
                   {
                       string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                       bool bEnable = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                       if (!bEnable)
                       {
                           continue;
                       }
                       string sn = tbUnitSN.Text;
                       TestContext context = GT_UserInterface.GetTestContext(i);
                       context.m_dicContext[tmMarcos.kContextMLBSN] = sn;
                       (this.MdiParent as MainForm).m_frmState.SetSN(sn, i);
                   }
                   return;

               }
               frmSN frm = new frmSN(tbUnitSN.Text);
               if (frm.ShowDialog(this) == DialogResult.OK)
               {
                   for (int i = 0; i < 6; i++)
                   {
                       string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                       bool bEnable = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                       if (!bEnable)
                       {
                           continue;
                       }
                       string sn = frm.GetSN(i);
                       TestContext context = GT_UserInterface.GetTestContext(i);
                       context.m_dicContext[tmMarcos.kContextMLBSN] = sn;
                       (this.MdiParent as MainForm).m_frmState.SetSN(sn, i);
                   }
               }

               TestContext.m_dicConfig[tmMarcos.kConfigScanBarcode] = 1;
               checkBoxNeedCode.Checked = true;
               tbUnitSN.Text = ""; //Clean it.
           }
       }
    }
}
