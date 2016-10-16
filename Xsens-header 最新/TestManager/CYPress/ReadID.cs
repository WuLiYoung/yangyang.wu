using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using C28Instrument;


namespace CYPress
{
    public class ReadID
    {
        static string[] IDoutput= new string[10];
        static string DIR= System.AppDomain.CurrentDomain.BaseDirectory;
        static string fileName = DIR+"for Discovery ID\\ping CC for Rev06 DVK\\cc_flash_GET_MODE.exe";
        public static string[] NameID = { "Msg Header", "ID header", "Cert Stat VDO", "Product VDO", "Product Type VDO" };
        public static int CYLock = 0; //0 IS IDEL; 1 IS BUSY;
        public static object m_cyLock = new object();
        public static ReadID m_ReadID = new ReadID();
        public static string[] Ret = new string[5];

        public string[] Getid()
        {
            lock (m_cyLock)
            {
                executeID();
                Ret.Initialize();
                for (int i = 0; i <= 4; i++)
                {
                    var values = from n in IDoutput where n.StartsWith(NameID[i]) select n;
                    string Val = null;
                    if (values != null && values.Count<string>() > 0)
                    {
                        string value = values.Last();
                        value = value.Trim();
                        int IndexStart = value.IndexOf('0');
                        Val = value.Substring(IndexStart, value.Length - IndexStart);
                        Ret[i] = Val;

                    }
                }

                return Ret;
                
            }
        }
        public static string[] GetID()
        {
            return m_ReadID.Getid();
        }
        public static void executeID()
        {
            Process p = new Process();
            //string fileName = "C:\\project\\A145\\Cypress\\20150918\\for Discovery ID\\ping CC for Rev06 DVK\\cc_flash_GET_MODE.exe";
            p.StartInfo.FileName = fileName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine("1");
            string output = p.StandardOutput.ReadToEnd();
            char[] seprator = { '\n', '\r' };
            IDoutput = output.Split(seprator);
        }
        
    }
}
