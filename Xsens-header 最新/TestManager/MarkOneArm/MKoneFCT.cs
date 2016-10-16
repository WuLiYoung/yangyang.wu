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

namespace MKoneController
{
    public class MKoneFCT
    {
        //Just need define one serial port in here
        //on slot should crate one this object.
        public SerialPortEx m_ComPort;
        static string timeHard;
        

        public MKoneFCT()
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
            m_ComPort.WriteLine(cmd+"\r");
            int ret = m_ComPort.WaitDetect(500);   //default is 5's timeout
        //    return ret;
        }
        public string ReadString()
        {

            return m_ComPort.ReadInputBuffer();
        }

        public string ResetCircuit() {
            string cmd = "SBIT10,25,14=1,1,0";
            string cmdVolt = "SBIT47,45,43,41=1,1,0,0";
            SendCmd(cmdVolt);
            System.Threading.Thread.Sleep(50);
            SendCmd(cmd);
            int start = System.Environment.TickCount;
            while (true)
            {
                System.Threading.Thread.Sleep(50);
                SendCmd("ADD00R01");
                System.Threading.Thread.Sleep(50);
                string ret = ReadString();
                float v;
                if (ret.Length == 0)
                    continue;
                string volt = ret.Substring(10, 4);
                v = float.Parse(volt);
                if (v > 2.7)
                    break;
                int now = System.Environment.TickCount;
                int pastTime = now - start;
                if (pastTime > 15000)
                {
                    timeHard = "FAIL";
                    return "FAIL";
                }
            }
            int nowTime = System.Environment.TickCount;
            int pastTimeNow = nowTime - start;
            while (true)
            {
                string cmdVoltHard = "SBIT41,21=1,1";
                SendCmd(cmdVoltHard);
                System.Threading.Thread.Sleep(50);
                SendCmd("ADD00R01");
                System.Threading.Thread.Sleep(50);
                string ret = ReadString();
                float v;
                if (ret.Length == 0)
                    continue;
                string volt = ret.Substring(10, 4);
                v = float.Parse(volt);
                if (v > 2.7)
                    break;
                int now1 = System.Environment.TickCount;
                int pastTime1 = now1 - start;
                if (pastTime1 > 30000)
                {
                    timeHard = "FAIL";
                    return pastTimeNow.ToString();
                }
            }
            int nowHard = System.Environment.TickCount;
            int pastTimeHard = nowHard - start;
            timeHard = pastTimeHard.ToString();
            return pastTimeNow.ToString();
        }


        public string ResetCircuitHard()
        {
            return timeHard;
        }

        public string SoftLatch() {
            string cmdVolt3V0 = "SBIT47,45,43,41=1,0,0,0";
            string cmdVolt3V0Ldo = "SBIT47,45,43,41=1,0,1,1";
            string cmdOn = "SBIT10=1";
            string cmdOff = "SBIT10=0";
            SendCmd(cmdVolt3V0);
            System.Threading.Thread.Sleep(50);
            SendCmd(cmdOn);
            System.Threading.Thread.Sleep(1000);
            SendCmd(cmdOff);
            System.Threading.Thread.Sleep(50);
            SendCmd("ADD00R01");
            System.Threading.Thread.Sleep(50);
            string ret3v0 = ReadString();
            string volt1 = ret3v0.Substring(10, 4);
            float v1 = float.Parse(volt1);
            SendCmd(cmdVolt3V0Ldo);
            System.Threading.Thread.Sleep(50);
            SendCmd("ADD00R01");
            System.Threading.Thread.Sleep(50);
            string ret3voLdo = ReadString();
            string volt2 = ret3voLdo.Substring(10, 4);
            float v2 = float.Parse(volt2);
            if (v1 > 2.7 && v2 > 2.7)
                return "PASS";
            return "FAIL";
        }
/*
        private void Delay(int iInterval)
        {

            DateTime now = DateTime.Now;
            while (now.AddMilliseconds(iInterval) > DateTime.Now)
            {
            }
            return;
        } 
*/
      }
  
}
  //设置和获取串口参数
       