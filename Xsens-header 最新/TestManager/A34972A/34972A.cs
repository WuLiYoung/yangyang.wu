using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace A34972A
{
    public class A34972A
    {
        public static Double[] OHMData = new Double[80];
        public  string Device = "34972A";
        public int resourceManager = -1;
        public int session = -1;
        public  int viError,outCount, readCount,maxCount=1024;
        public  byte[] data = new byte[256];
        public  byte[] dataR = new byte[1024];
        public  object m_34972Lock = new object();
        public  bool IsOhmExecuted = false;
        public  bool IsCurExecuted = false;
        public  bool IsOpenExecuted= false;
        
        public  int OpenRM()
        {
            if (resourceManager < 0)
            {
                viError = visa32.viOpenDefaultRM(out resourceManager);
                if (viError < visa32.VI_SUCCESS)
                    throw new ApplicationException("Failed to open 34972A");
            }
            return resourceManager;
        }

        public  int OpenSession(string resourceAddress, int resourceManager)
        {
            if (session < 0)
            {
                    viError = visa32.viOpen(resourceManager, resourceAddress,
                            visa32.VI_NO_LOCK,
                            visa32.VI_TMO_IMMEDIATE, out session);
                    if (viError < visa32.VI_SUCCESS)
                    {
                        System.Text.StringBuilder error = new System.Text.StringBuilder(256);
                        visa32.viStatusDesc(resourceManager, viError, error);
                        System.Windows.Forms.MessageBox.Show("Failed to open 34972A");
                    }
            }
            return session;
        }

        private  int WriteBytes(int sec, int requestCount, byte[] data)
        {
            if (resourceManager >= 0 && session > 0)
            {
                viError = visa32.viWrite(sec, data, requestCount, out outCount);
                if (viError < visa32.VI_SUCCESS)
                {
                    System.Text.StringBuilder error = new System.Text.StringBuilder(256);
                    visa32.viStatusDesc(sec, viError, error);
                    //throw new ApplicationException(error.ToString());
                    System.Windows.Forms.MessageBox.Show("Failed to Write 34972A");
                }
            }
            return outCount;
        }
        private  int ReadBytes(int sec, int maxCount, out byte[] dataR)
        {
            dataR = new Byte[maxCount];           
            viError = visa32.viRead(sec, dataR, maxCount, out readCount);
            if (viError < visa32.VI_SUCCESS)
            {
                System.Text.StringBuilder error =
                        new System.Text.StringBuilder(256);
                visa32.viStatusDesc(sec, viError, error);
                //throw new ApplicationException(error.ToString());
                System.Windows.Forms.MessageBox.Show("Failed to Read 34972A");
            }
            return readCount;
        }
        public  int WriteCmd(string cmd)
        {
            data = Encoding.Default.GetBytes(cmd);
            WriteBytes( session, data.Length, data);
            return outCount;
        }
        public  string ReadCmd()
        {

            ReadBytes(session, maxCount, out dataR);
            string ret = Encoding.Default.GetString(dataR);
            return ret;
        }
        private  Double ChangeDataToD(string strData)
        {
            Double dData = 0.0;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDouble(Double.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }
       public  Double GetOhmData(int Index)
       {
            
            System.Threading.Thread.Sleep(200);
            return OHMData[Index];
       }


        public void OpenDevice()
        {   
            OpenRM();
            OpenSession(Device, resourceManager);
        }
        public  void storyOhmData(string par,int delay)
        {
            lock (m_34972Lock)
            {
                WriteCmd(par);
                System.Threading.Thread.Sleep(delay);
                string ret = ReadCmd();
                string[] RET = ret.Split(',');
                int i = 0;
                foreach (string S in RET)
                {
                    OHMData[i] = ChangeDataToD(S);
                    i++;
                }
            }
        }
  
 
        public bool setOhmExecuted()
        {   
            IsOhmExecuted=true;
            return IsOhmExecuted;
        }
 
        public bool ResetOhmExecuted()
        {
            IsOhmExecuted = false;
            return IsOhmExecuted;
        }
      
        public bool CheckOhmExecuted()
        {
            return IsOhmExecuted;
        }
        public double ReadCurrent(string str)
        {
            lock (m_34972Lock)
            {
                WriteCmd(str);
                Thread.Sleep(200);
                return ChangeDataToD(ReadCmd());
            }
        }
            
       
        
    }
}
