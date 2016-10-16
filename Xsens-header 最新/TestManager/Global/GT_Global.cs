using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using LuaInterface;

using System.Windows.Forms;
using System.Diagnostics;
namespace Global
{
    class GT_Global:IModule
    {
        public Engine m_TestEngine;
        public int Load(object sender, object arg)
        {
            DictionaryEx dic = arg as DictionaryEx;
            m_TestEngine = dic["engine"] as Engine;

            InitialGlobal();

            return 0;
        }
        public int RegisterModule(object sender, object arg)
        {
            for (int i = 0; i < m_TestEngine.GetEngineCore(null); i++)
            {
                ScriptEngine se = m_TestEngine.GetScriptEngine(i) as ScriptEngine;
                Lua lua = se.GetScriptHandle() as Lua;
                lua.RegisterFunction("Delay", this, this.GetType().GetMethod("Delay"));
                lua.RegisterFunction("Msgbox", this, this.GetType().GetMethod("msgbox"));
                lua.RegisterFunction("Log", this, this.GetType().GetMethod("Log"));

                lua.RegisterFunction("DbgLog", this, this.GetType().GetMethod("DbgLog"));

                //bit operation
                lua.RegisterFunction("bit_and", this, this.GetType().GetMethod("bit_and"));
                lua.RegisterFunction("bit_or", this, this.GetType().GetMethod("bit_or"));
                lua.RegisterFunction("bit_xor", this, this.GetType().GetMethod("bit_xor"));
                lua.RegisterFunction("bit_nor", this, this.GetType().GetMethod("bit_nor"));
                lua.RegisterFunction("get_bit", this, this.GetType().GetMethod("get_bit"));
                lua.RegisterFunction("rshift", this, this.GetType().GetMethod("rshift"));
                lua.RegisterFunction("lshift", this, this.GetType().GetMethod("lshift"));
                lua.RegisterFunction("Execute", this, this.GetType().GetMethod("Execute"));

                //Lock  
                 lua.RegisterFunction("Lock", this, this.GetType().GetMethod("Lock"));       
                 lua.RegisterFunction("UnLock", this, this.GetType().GetMethod("UnLock")); 


                //Test Context
                TestContext tc =m_TestEngine.GetTestContext(i) as TestContext;
                lua["TestContext"] = tc;//把上下文对象倒到各自的脚本环境中
                lua.DoString("tc = require \"Global\"");
            }
            return 0;
        }

        public int Initial(object sender, object arg)
        {
            return 0;
        }
        public int SelfTest(object sender, object arg)
        {
            return 0;
        }
        public int UnLoad(object sender, object arg)
        {
            return 0;
        }

        public void Lock()  
       {  
 
          System.Threading.Monitor.Enter("");  
       }  

        public void UnLock()  
       {  
         System.Threading.Monitor.Exit("");  
       } 

        //
        public void msgbox(string msg,string title,int btn,int ico)
        {
            MessageBox.Show(msg,title,(MessageBoxButtons)btn,(MessageBoxIcon)ico);
        }

        public void DbgLog(string msg,int id)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["msg"] = msg+"\r\n";
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kDegbugMessage, dic);
        }

        public void Log(string msg,int id)
        {
            DictionaryEx dic = new DictionaryEx();
            dic["id"] = id;
            dic["msg"] = msg+"\r\n";
            NotificationCenter.DefaultCenter().PostNotification(tmMarcos.kTestFlowMessage, dic);
        }
        //public function
        public void Delay(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }

        //位操作函数
        public byte bit_and(byte x, byte y)
        {
            byte ret = (byte)(x & y);
            return ret;
        }

        public byte bit_or(byte x, byte y)
        {

            return (byte)(x | y);
        }

        public byte bit_xor(byte x, byte y)
        {
            return (byte)(x ^ y);
        }

        public byte bit_nor(byte x, byte y)
        {
            return (byte)(~(x ^ y));
        }

        public byte get_bit(byte x, byte index)
        {
            return (byte)(x & (0x01 << index));
        }

        public byte rshift(int x, int nlen)
        {
            byte result = (byte)(x>>nlen);
            return result;
        }

        public int lshift(int x,int nlen)
        {
            int nvalue = x;
            return nvalue<< nlen;
        }
        public void Execute(string path)
        {
            Process process = new Process();
            process.StartInfo.FileName =path;
            process.StartInfo.UseShellExecute = true;
        //    process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();             
        }

        //Initial Global Information
        void InitialGlobal()
        {
            TestContext.m_dicGlobal[tmMarcos.kGlobalAppDir] = tmEnvironment.AppDir();
            TestContext.m_dicGlobal[tmMarcos.kConfigUartLogPath] = "UartLog";
            TestContext.m_dicGlobal[tmMarcos.kConfigTestFlowPath] = "TestFlow";

        }
    }

}
