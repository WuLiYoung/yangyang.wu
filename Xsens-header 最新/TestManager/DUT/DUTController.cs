using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO.Ports;
using TestStudio.Automation.TestManager.libCommon.Class;
using TestStudio.Automation.TestManager.libCommon.Interface;
using RyanStudio.Automation.TestManager.Common.Class.Driver;
using LuaInterface;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;




namespace DUT
{
    class DUTController
    {
        public SerialPortEx m_ComPort;


        public DUTController()
        {
            m_ComPort = new SerialPortEx();
            m_ComPort.SetDetectString("\r\n");
            
        }

        public bool Open(string portname,string setting)
        {
            m_ComPort.Setting = setting;
            m_ComPort.Open();
            return m_ComPort.IsOpen;
        }
        public void CloseSerial()
        {
            m_ComPort.Close();
        }
        

        public void Test(string cmd)
        {
            System.Windows.Forms.MessageBox.Show(cmd);
        }

        public void SendCmd(string cmd)
        {
            m_ComPort.ClearBuffer();
            m_ComPort.WriteLine(cmd);
            int ret = m_ComPort.WaitDetect(500);   //default is 5's timeout
        //    return ret;
        }

        public void SendHexCmd(string cmd)
        {
           
            string[] sArray = Regex.Split(cmd, "0x", RegexOptions.IgnoreCase);
            byte[] bArray = new byte[sArray.Length];
            for (int i = 1; i < sArray.Length; i++)
            {
                try
                {
                    bArray[i-1] = Convert.ToByte(sArray[i]);
                }
                catch (Exception e)
                {
                    string message = string.Format("Error: Hex command invalid:{0} {1}", cmd, bArray[0]);
                    MessageBox.Show(message);
                    break;
                }
            }

            //string message1 = string.Format("Debug: Hex command invalid:{0} {1} {2} {3}", cmd, bArray[0], bArray[1], sArray[0]);
           // MessageBox.Show(message1);

            m_ComPort.ClearBuffer();
            m_ComPort.Write(bArray, 0, bArray.Length);
            int ret = m_ComPort.WaitDetect(500);
          
        }


        public string ReadString()
        {

            return m_ComPort.ReadInputBuffer();
        }

        public string ReadHex()
        {
            byte []data = m_ComPort.ReadInputBufferHex();

            string hexSTR = "";
            StringBuilder strBuilder = new StringBuilder();

         
            for (int i = 0; i < data.Length; i++)
            {
               // string message = string.Format("data[{0}] = {1} str = {2}", data[i], Convert.ToInt32(data[i]),  string.Format("{0:X}",data[i]));
              //  MessageBox.Show(message);
              //  strBuilder.Append("0x");
                string newByte = string.Format("{0:X2}", data[i]);
                //MessageBox.Show(newByte);
                strBuilder.Append(newByte);
                hexSTR = strBuilder.ToString();
             //   MessageBox.Show(hexSTR);
            }
            // string message = string.Format("INFO: Hex command invalid:{0} {1}", data.Length,hexSTR);
           
           // MessageBox.Show(hexSTR);
            return hexSTR;
        }
    }
}
