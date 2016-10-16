using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TestStudio.Automation.TestManager.libCommon.Class;

namespace DataLogger
{
    class csvReport
    {
        string m_strHeader="";
        string m_buffer="";
        public csvReport()
        {
        }
        public int SetFileHeader(string buffer)
        {
            m_strHeader = buffer;
            return 0;
        }

        public int AddRecord(string buffer)
        {
            m_buffer += buffer;
            return 0;
        }

        public int GenerateReport(string filepath)
        {
            try
            {               
                lock ("Write_Csv")
                {
                    clearSNbuffer();
                    CheckFile(filepath);
                    StreamWriter write = File.AppendText(filepath);
                    write.Write(m_buffer);
                    write.Close();
                    m_buffer = "";
                    
                }            
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public void clearSNbuffer()
        {
            for (int i = 0; i < 6; i++)
            {
                string key = string.Format("{0}{1}", tmMarcos.kUUTEnable, i);
                bool bEnable = Convert.ToBoolean(TestContext.m_dicConfig[key]);
                if (bEnable)
                {
                    if (GT_DataLogger.m_TestEngine.IsTesting(i) > 0)
                    {
                        return;
                    }
                    TestContext context = GT_DataLogger.GetTestContext(i);
                    context.m_dicContext[tmMarcos.kContextMLBSN] = "";
                    return;
                }
            }
            return;
            }           
        


        public int Clear()
        {
            m_strHeader = "";
            m_buffer = "";
            return 0;
        }

        int CheckFile(string filepath)
        {
            if (File.Exists(filepath))
            {
            }
            else
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filepath));
                File.WriteAllText(filepath, m_strHeader);
            }

            return 0;
        }
    }
}
