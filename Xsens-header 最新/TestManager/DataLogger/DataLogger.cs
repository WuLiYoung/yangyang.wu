using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
//using FFTester;



namespace DataLogger
{
  public   class DataLogger
    {
        csvReport m_csvReport=new csvReport();
        StringBuilder Testflowlog = new StringBuilder();
        string testflow;
        int m_index = 0;
     //   Tester it = new Tester();

        public DataLogger()
        {
            
        }

        public int  SetFilepath( string  testflowpath)
        {
            testflow = testflowpath;

            return 0;
        
        }

        public int push_testflowlog(string mesage)
        {
          Testflowlog.AppendLine(mesage);
          return  0;
        
        }



        public DataLogger(int id)
        {
            m_index = id;
        }



        //Csv Logger
        public int SetFileHeader(string str)
        {
            m_csvReport.SetFileHeader(str);
            return 0;
        }

        public int push_CSV(string buffer)
        {
            m_csvReport.AddRecord(buffer);
            return 0;
        }

        public int csvReport(string filepath)
        {
            m_csvReport.GenerateReport(filepath);
            return 0;
        }

        //uart report
        public int writetwestflowlog()
        {
            StreamWriter write = File.AppendText(testflow);
            write.Write(Testflowlog.ToString());
            write.Close();
            Testflowlog = new StringBuilder();
            return 0;
        
        
        }//write test flow log
        public int uartLog(string filepath)
        {
            return 0;
        }

        //test flow report
        public int testflowLog(string filepath)
        {
            return 0;
        }

        //Data upload
        public int UploadData()
        {

            return 0;
        }

      // Query UUT
        public string GetUnitInfo(string info)
        {
            string dutInfo = "";
           // int ret = it.GetUnitInfo(info, ref dutInfo);
            return dutInfo;
        }

      // Upload data
        public long SaveResult(string info)
        {
           //  return it.SaveResult(info);
            return SaveResult(info);
        }
    }
}
