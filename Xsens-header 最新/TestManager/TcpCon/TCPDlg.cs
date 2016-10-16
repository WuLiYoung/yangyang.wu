using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using Senxda;
using XDA;
using System.Runtime.InteropServices;

namespace TcpCon
{
    public partial class TCPDlg : Form
    {
        #region DllImport Win32
        [DllImport("kernel32")]
        public static extern uint GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileSectionNames(byte[] lpReturnedString, int nSize, string lpFileName);
        #endregion

        #region DUT
        private bool bListening = false;
        private Int32 Baund = 115200;
        KbootPacketDecoder KbootDecoder = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder1 = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder2 = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder3 = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder4 = new KbootPacketDecoder();


        List<string> RecordData = new List<string>();
        List<string> RecordData1 = new List<string>();
        List<string> RecordData2 = new List<string>();
        List<string> RecordData3 = new List<string>();
        List<string> RecordData4 = new List<string>();

        private static IMUData[] UranusDataArray = new IMUData[5] { new IMUData(), new IMUData(), new IMUData(), new IMUData(), new IMUData() };

        #endregion

        double A0, A1, A2, A3, A4;
        double B0, B1, B2, B3, B4;
        double C0, C1, C2, C3, C4;

        int num = 0;
        List<double> RecordTempData = new List<double>();
        List<double> x = new List<double>();
        List<double> y = new List<double>();
        List<double> z = new List<double>();

        private string csv_oppath = @"C:\Intelli_TuoLuoYi\Output\";
        string retLoc = null;
        string retLoc1 = null;
        string retLoc2 = null;
        string retPicthArw = null;

        public TCPDlg()
        {
            InitializeComponent();
            this.timer1.Interval = 20;
            timer1.Enabled = true;
            GT_TCP.m_object.notifier += new TcpCon.Notify(OnReceiveData);
        }
        private void TCPDlg_Load(object sender, EventArgs e)
        {
            RefreshComPort(null, null);

            KbootDecoder.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived);
            KbootDecoder1.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived1);
            KbootDecoder2.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived2);
            KbootDecoder3.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived3);
            KbootDecoder4.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived4);



            GT_TCP.spSerialPortArray[0].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            GT_TCP.spSerialPortArray[0].BaudRate = 115200;

            GT_TCP.spSerialPortArray[1].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            GT_TCP.spSerialPortArray[1].BaudRate = 115200;

            GT_TCP.spSerialPortArray[2].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort2_DataReceived);
            GT_TCP.spSerialPortArray[2].BaudRate = 115200;

            GT_TCP.spSerialPortArray[3].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort3_DataReceived);
            GT_TCP.spSerialPortArray[3].BaudRate = 115200;

            GT_TCP.spSerialPortArray[4].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort4_DataReceived);
            GT_TCP.spSerialPortArray[4].BaudRate = 115200;
        }


        public void OnReceiveData(string str)
        {
            this.Message.AppendText(str);
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            string tcp = this.textBox_IP.Text;
            int port = int.Parse(this.textBox_Port.Text);
            GT_TCP.m_object.Connect_tcp(tcp, port);
        }

        private void button_Send_Click(object sender, EventArgs e)
        {

            string sendcmd = this.comboBox_Axis.Text + this.comboBox_Num.Text + this.comboBox_FunNum.Text + "S" + this.textBox_Loc.Text +"V" + textBox_Spe.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox_Loc1.Text
            string sendcmd1 = this.comboBox_Axis1.Text + this.comboBox_Num1.Text + this.comboBox_FunNum1.Text + "S" + this.textBox_Loc1.Text + "V" + textBox_Spe1.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string picth = this.textBox_Loc2.Text;
                double picthArw = double.Parse(picth);
                double retPicth = -picthArw;
                retPicthArw = Convert.ToString(retPicth);
            }
            else
            {
                retPicthArw = this.textBox_Loc2.Text;
            }
            string sendcmd2 = this.comboBox_Axis2.Text + this.comboBox_Num2.Text + this.comboBox_FunNum2.Text + "S" + retPicthArw + "V" + textBox_Spe2.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd2);
        }

        // send all cmd of senxda
        private void button3_Click(object sender, EventArgs e)
        {
            string loc = this.textBox_Loc.Text;
            double arw = double.Parse(loc);

            if (A0 <= arw && arw < A1)
            {
                double c = 90 * (arw - (A0)) / (A1 - (A0));  //电机实际走的位置             
                retLoc = Convert.ToString(c);
            }
            else if (A1 <= arw && arw <= A2)
            {
                double c = 90 * (arw - A1) / (A2 - A1) + 90;
                retLoc = Convert.ToString(c);
            }
            else if (A3 <= arw && arw < A0)
            {
                double c = 90 * (arw - (A0)) / (A0 - (A3));
                retLoc = Convert.ToString(c);
            }
            else if (A4 <= arw && arw < A3)
            {
                double c = 90 * (arw - (A3)) / (A3 - (A4)) - 90;
                retLoc = Convert.ToString(c);
            }
            else
            {
                retLoc = this.textBox_Loc.Text;
            }

            string loc1 = this.textBox_Loc1.Text;
            double arw1 = double.Parse(loc1);

            //double dMin;
            //double dMax;
            if (B0 <= arw1 && arw1 < B1)
            {
                double c = 90 * (arw1 - (B0)) / (B1 - (B0));  //电机实际走的位置             
                retLoc1 = Convert.ToString(c);
            }
            else if (B1 <= arw1 && arw1 <= B2)
            {
                double c = 90 * (arw1 - B1) / (B2 - B1) + 90;
                if (90 <= c && c <= 180)
                {
                    retLoc1 = Convert.ToString(c);
                }
                else
                {
                    double temp = c + 360;
                    c = 90 * (c - B1) / (B2 - B1) + 90;
                    retLoc1 = Convert.ToString(c);
                }
                retLoc1 = Convert.ToString(c);
            }
            else if (B3 <= arw1 && arw1 < B0)
            {
                double c = 90 * (arw1 - (B0)) / (B0 - (B3));
                retLoc1 = Convert.ToString(c);
            }
            else if (B4 <= arw1 && arw1 < B3)
            {
                double c = 90 * (arw1 - (B3)) / (B3 - (B4)) - 90;
                if (-180 <= c && c <= -90)
                {
                    retLoc1 = Convert.ToString(c);
                }
                else
                {
                    double temp = c - 360;
                    c = 90 * (temp - (B3)) / (B3 - (B4)) - 90;
                    retLoc1 = Convert.ToString(c);
                }
            }
            else
            {
                retLoc1 = this.textBox_Loc1.Text;
            }

            string loc2 = this.textBox_Loc2.Text;
            double arw2 = double.Parse(loc2);

            //double dMin;
            //double dMax;
            if (C0 <= arw2 && arw2 < C1)
            {
                double c = -90 * (arw2 - (C0)) / (C1 - (C0));  //电机实际走的位置             
                retLoc2 = Convert.ToString(c);
            }
            else if (C1 <= arw2 && arw2 <= C2)
            {
                double c = -90 * (arw2 - C1) / (C2 - C1) + 45;
                retLoc2 = Convert.ToString(c);
            }
            else if (C3 <= arw2 && arw2 < C0)
            {
                double c = -90 * (arw2 - (C0)) / (C0 - (C3));
                retLoc2 = Convert.ToString(c);
            }
            else if (C4 <= arw2 && arw2 < C3)
            {
                double c = -90 * (arw2 - (C3)) / (C3 - (C4)) - 45;
                retLoc2 = Convert.ToString(c);
            }
            else
            {
                retLoc2 = this.textBox_Loc2.Text;
            }

            string sendcmd = this.comboBox_Axis.Text + this.comboBox_Num.Text + this.comboBox_FunNum.Text + "S" + retLoc + "V" + textBox_Spe.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd);
            Thread.Sleep(100);
            string sendcmd1 = this.comboBox_Axis1.Text + this.comboBox_Num1.Text + this.comboBox_FunNum1.Text + "S" + retLoc1 + "V" + textBox_Spe1.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd1);
            Thread.Sleep(200);
            string sendcmd2 = this.comboBox_Axis2.Text + this.comboBox_Num2.Text + this.comboBox_FunNum2.Text + "S" + retLoc2 + "V" + textBox_Spe2.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd2);

        }
        private void OK_Click(object sender, EventArgs e)
        {
            GT_TCP.m_object.DisConnect_tcp();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (data._orientation != null)
            //{
            //    Console.WriteLine(data._orientation.x());
            //}
            
       
        }

        //老化指令
        #region 
        private void button5_Click(object sender, EventArgs e)
        {
            string sendcmd = "AUTO";
            GT_TCP.m_object.SendMsg(sendcmd);

            Thread.Sleep(100);

            string sendcmd1 = "START";
            GT_TCP.m_object.SendMsg(sendcmd1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string sendcmd = "ASTOP";
            GT_TCP.m_object.SendMsg(sendcmd);
        }
        #endregion
        //写入配置文件
        #region
        private void button4_Click(object sender, EventArgs e)
        {
            A0 = Class1.getA0;
            A1 = Class1.getA1;
            A2 = Class1.getA2;
            if (A2 < 0)
            {
                A2 = A2 + 360;
            }
            A3 = Class1.getA3;
            A4 = Class1.getA4;
            if (A4 > 0)
            {
                A4 = A4 - 360;
            }
            B0 = Class1.getB0;
            B1 = Class1.getB1;
            B2 = Class1.getB2;
            if (B2 < 0)
            {
                B2 = B2 + 360;
            }
            B3 = Class1.getB3;
            B4 = Class1.getB4;
            if (B4 > 0)
            {
                B4 = B4 - 360;
            }
            C0 = Class1.getC0;
            C1 = Class1.getC1;
            C2 = Class1.getC2;
            C3 = Class1.getC3;
            C4 = Class1.getC4;

            TCPDlg.SaveSetting("INIT", "KeyA0", Convert.ToString(A0), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyA1", Convert.ToString(A1), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyA2", Convert.ToString(A2), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyA3", Convert.ToString(A3), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyA4", Convert.ToString(A4), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyB0", Convert.ToString(B0), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyB1", Convert.ToString(B1), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyB2", Convert.ToString(B2), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyB3", Convert.ToString(B3), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyB4", Convert.ToString(B4), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyC0", Convert.ToString(C0), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyC1", Convert.ToString(C1), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyC2", Convert.ToString(C2), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyC3", Convert.ToString(C3), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            TCPDlg.SaveSetting("INIT", "KeyC4", Convert.ToString(C4), "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");

            Console.WriteLine("\r\n");
            Console.WriteLine(A0);
            Console.WriteLine(A1);
            Console.WriteLine(A2);
            Console.WriteLine(A3);
            Console.WriteLine(A4 + "\r\n");
            Console.WriteLine(B0);
            Console.WriteLine(B1);
            Console.WriteLine(B2);
            Console.WriteLine(B3);
            Console.WriteLine(B4 + "\r\n");
            Console.WriteLine(C0);
            Console.WriteLine(C1);
            Console.WriteLine(C2);
            Console.WriteLine(C3);
            Console.WriteLine(C4);

            
        }

        public static string GetSetting(string AppName, string KeyName, string DefValue, string strFile)
        {
            StringBuilder sb = new StringBuilder("", 1024);
            if (TCPDlg.GetPrivateProfileString(AppName, KeyName, DefValue, sb, 1024, strFile) >= 0)
                return sb.ToString();
            return DefValue;
        }
        public static bool SaveSetting(string AppName, string KeyName, string strValue, string strFile)
        {
            if (!TCPDlg.WritePrivateProfileString(AppName, KeyName, strValue, strFile)) return false;
            return true;
        }
        #endregion
        private void INIT_Click(object sender, EventArgs e)
        {


            string aa0 = TCPDlg.GetSetting("INIT", "KeyA0", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double A0 = double.Parse(aa0);
            string aa1 = TCPDlg.GetSetting("INIT", "KeyA1", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double A1 = double.Parse(aa1);
            string aa2 = TCPDlg.GetSetting("INIT", "KeyA2", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double A2 = double.Parse(aa2);                      
            string aa3 = TCPDlg.GetSetting("INIT", "KeyA3", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double A3 = double.Parse(aa3);                      
            string aa4 = TCPDlg.GetSetting("INIT", "KeyA4", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double A4 = double.Parse(aa4);                      
                                                                
            string bb0 = TCPDlg.GetSetting("INIT", "KeyB0", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double B0 = double.Parse(bb0);                      
            string bb1 = TCPDlg.GetSetting("INIT", "KeyB1", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double B1 = double.Parse(bb1);                      
            string bb2 = TCPDlg.GetSetting("INIT", "KeyB2", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double B2 = double.Parse(bb2);                      
            string bb3 = TCPDlg.GetSetting("INIT", "KeyB3", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double B3 = double.Parse(bb3);                     
            string bb4 = TCPDlg.GetSetting("INIT", "KeyB4", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double B4 = double.Parse(bb4);                      

            string cc0 = TCPDlg.GetSetting("INIT", "KeyC0", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double C0 = double.Parse(cc0);                      
            string cc1 = TCPDlg.GetSetting("INIT", "KeyC1", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double C1 = double.Parse(cc1);                      
            string cc2 = TCPDlg.GetSetting("INIT", "KeyC2", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double C2 = double.Parse(cc2);                      
            string cc3 = TCPDlg.GetSetting("INIT", "KeyC3", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double C3 = double.Parse(cc3);                      
            string cc4 = TCPDlg.GetSetting("INIT", "KeyC4", "", "C:\\Intelli_TuoLuoYi_INI\\TcpCon.ini");
            double C4 = double.Parse(cc4);

            Console.WriteLine("\r\n");
            Console.WriteLine(A0);
            Console.WriteLine(A1);
            Console.WriteLine(A2);
            Console.WriteLine(A3);
            Console.WriteLine(A4 + "\r\n");
            Console.WriteLine(B0);
            Console.WriteLine(B1);
            Console.WriteLine(B2);
            Console.WriteLine(B3);
            Console.WriteLine(B4 + "\r\n");
            Console.WriteLine(C0);
            Console.WriteLine(C1);
            Console.WriteLine(C2);
            Console.WriteLine(C3);
            Console.WriteLine(C4);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        //同时发送
        private void button7_Click(object sender, EventArgs e)
        {
            string sendcmd = this.comboBox_Axis.Text + this.comboBox_Num.Text + this.comboBox_FunNum.Text + "S" + textBox_Loc.Text + "V" + textBox_Spe.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd);
            Thread.Sleep(100);
            string sendcmd1 = this.comboBox_Axis1.Text + this.comboBox_Num1.Text + this.comboBox_FunNum1.Text + "S" + textBox_Loc1.Text + "V" + textBox_Spe1.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd1);
            Thread.Sleep(200);

            if (checkBox1.Checked == true)
            {
                string picth = this.textBox_Loc2.Text;
                double picthArw = double.Parse(picth);
                double retPicth = -picthArw;
                retPicthArw = Convert.ToString(retPicth);
            }
            else
            {
                retPicthArw = this.textBox_Loc2.Text;
            }
            string sendcmd2 = this.comboBox_Axis2.Text + this.comboBox_Num2.Text + this.comboBox_FunNum2.Text + "S" + retPicthArw + "V" + textBox_Spe2.Text + "END";
            GT_TCP.m_object.SendMsg(sendcmd2);
        }

        //零点
        private void button8_Click(object sender, EventArgs e)
        {
            string sendcmd = "A" + "01" + "01" + "S" + "0" + "V" + "50" + "END";
            GT_TCP.m_object.SendMsg(sendcmd);
            Thread.Sleep(100);
            string sendcmd1 = "A" + "02" + "01" + "S" + "0" + "V" + "50" + "END";
            GT_TCP.m_object.SendMsg(sendcmd1);
            Thread.Sleep(200);
            string sendcmd2 = "A" + "03" + "05" + "S" + "" + "V" + "50" + "END";
            GT_TCP.m_object.SendMsg(sendcmd2);
            
        }
        //临时数据采集命令
        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            double temp = double.Parse(this.stepBox.Text); //步长
            int count = 180 / (int)temp;
            for (int i = 0; i < count + 1; i++)
            {
                x.Add(temp * i);
                y.Add(temp * i);
                z.Add(temp * i);
                
            }
            for (int i = 0; i < count; i++)
            {
                x.Add(-temp * (i + 1));
                y.Add(-temp * (i + 1));
                z.Add(-temp * (i + 1));

            }

            for (int i = 0; i < x.Count; i++)
            {
                for (int j = 0; j < y.Count; j++)
                {
                    for (int q = 0; q < z.Count; q++)
                    {
                        if (form != null)
                        {
                            form.tempDataCallBack();
                        }
                        string sendcmd = "A" + "01"+ "01" + "S" + Convert.ToString(x[i]) + "V" +"100" + "END";
                        GT_TCP.m_object.SendMsg(sendcmd);
                        Thread.Sleep(100);
                        string sendcmd1 = "A" + "02" + "01" + "S" + Convert.ToString(y[j]) + "V" + "100" + "END";
                        GT_TCP.m_object.SendMsg(sendcmd1);
                        Thread.Sleep(200);
                        string sendcmd2 = "A" + "03" + "01" + "S" + Convert.ToString(z[q]) + "V" + "100" + "END";
                        GT_TCP.m_object.SendMsg(sendcmd2);

                        //Thread.Sleep(4000);

                    }
                }
            }
        }

        


        #region DUT COM Port
        private void RefreshComPort(object sender, EventArgs e)
        {
            
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                
                comboBox1.Items.Add(portName);
                comboBox2.Items.Add(portName);
                comboBox3.Items.Add(portName);
                comboBox4.Items.Add(portName);
                comboBox5.Items.Add(portName);

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (GT_TCP.spSerialPortArray[0].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_TCP.spSerialPortArray[0].Dispose();
                GT_TCP.spSerialPortArray[0].Close();
                timer2.Stop();
            }
            if (GT_TCP.spSerialPortArray[1].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_TCP.spSerialPortArray[1].Dispose();
                GT_TCP.spSerialPortArray[1].Close();
                timer3.Stop();
            }
            if (GT_TCP.spSerialPortArray[2].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_TCP.spSerialPortArray[2].Dispose();
                GT_TCP.spSerialPortArray[2].Close();
                timer4.Stop();
            }
            if (GT_TCP.spSerialPortArray[3].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_TCP.spSerialPortArray[3].Dispose();
                GT_TCP.spSerialPortArray[3].Close();
                timer5.Stop();
            }
            if (GT_TCP.spSerialPortArray[4].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_TCP.spSerialPortArray[4].Dispose();
                GT_TCP.spSerialPortArray[4].Close();
                timer6.Stop();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != null)
            {
                GT_TCP.spSerialPortArray[0].PortName = this.comboBox1.Text;
                GT_TCP.spSerialPortArray[0].BaudRate = Baund;
                GT_TCP.spSerialPortArray[0].Open();
                this.timer2.Start();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.Text != null)
            {
                GT_TCP.spSerialPortArray[1].PortName = this.comboBox1.Text;
                GT_TCP.spSerialPortArray[1].BaudRate = Baund;
                GT_TCP.spSerialPortArray[1].Open();
                this.timer3.Start();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.comboBox3.Text != null)
            {
                GT_TCP.spSerialPortArray[2].PortName = this.comboBox1.Text;
                GT_TCP.spSerialPortArray[2].BaudRate = Baund;
                GT_TCP.spSerialPortArray[2].Open();
                this.timer4.Start();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.comboBox4.Text != null)
            {
                GT_TCP.spSerialPortArray[3].PortName = this.comboBox1.Text;
                GT_TCP.spSerialPortArray[3].BaudRate = Baund;
                GT_TCP.spSerialPortArray[3].Open();
                this.timer5.Start();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (this.comboBox5.Text != null)
            {
                GT_TCP.spSerialPortArray[4].PortName = this.comboBox1.Text;
                GT_TCP.spSerialPortArray[4].BaudRate = Baund;
                GT_TCP.spSerialPortArray[4].Open();
                this.timer6.Start();
            }
        }

        private void button_LoadCsv_Click(object sender, EventArgs e)
        {
            string now1 = DateTime.Now.ToString();
            string now2 = now1.Replace(':', '-');
            string now = now2.Replace('/', '-');
            string file = csv_oppath + "DUT_" + "OutPut_" + "_" + now + ".csv";
            FileInfo fi = new FileInfo(file);

            string filePitch = csv_oppath + "DUT_Pitch_" + "OutPut_" + "_" + now + ".csv";
            FileInfo fiPitch = new FileInfo(filePitch);
            string fileRoll = csv_oppath + "DUT_Roll_" + "OutPut_" + "_" + now + ".csv";
            FileInfo fiRoll = new FileInfo(fileRoll);
            string fileYaw = csv_oppath + "DUT_Yaw_" + "OutPut_" + "_" + now + ".csv";
            FileInfo fiYaw = new FileInfo(fileYaw);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
                fiPitch.Directory.Create();
                fiRoll.Directory.Create();
                fiYaw.Directory.Create();
            }
            FileStream fs = new FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

            FileStream fsPitch = new FileStream(filePitch, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter swPitch = new StreamWriter(fsPitch, System.Text.Encoding.UTF8);
            FileStream fsRoll = new FileStream(fileRoll, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter swRoll = new StreamWriter(fsRoll, System.Text.Encoding.UTF8);
            FileStream fsYaw = new FileStream(fileYaw, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter swYaw = new StreamWriter(fsYaw, System.Text.Encoding.UTF8);


            int length = RecordData.Count / 3 - 10;
            sw.WriteLine("1,pitch,Roll,Yaw,2,pitch,Roll,Yaw,3,pitch,Roll,Yaw,4,pitch,Roll,Yaw,5,pitch,Roll,Yaw");
            swPitch.WriteLine("FeelingCurve Data longht:" + length);
            swRoll.WriteLine("FeelingCurve Data longht:" + length);
            swYaw.WriteLine("FeelingCurve Data longht:" + length);
            //dMax = count[0];
            //for (int i = 0; i < count.Length; i++)
            //{
            //    if (dMax >= count[i])
            //    {
            //        dMax = count[i];
            //    }
            //}

            int j = 0;
            double n = 0;
            for (int i = 0; i < RecordData.Count / 3 - 10; i = i + 1)
            {
                j = i * 3;
                n = i * 0.02;
                sw.WriteLine(
                      RecordData[j] + "," + RecordData[j + 1] + "," + RecordData[j + 2] + "," + "" + ","
                    + RecordData1[j] + "," + RecordData1[j + 1] + "," + RecordData1[j + 2] + "," + "" + ","
                    + RecordData2[j] + "," + RecordData2[j + 1] + "," + RecordData2[j + 2] + "," + "" + ","
                    + RecordData3[j] + "," + RecordData3[j + 1] + "," + RecordData3[j + 2] + "," + "" + ","
                    + RecordData4[j] + "," + RecordData4[j + 1] + "," + RecordData4[j + 2]

                    );
                //swPitch.WriteLine(n + "," + RecordData[j]);
                swPitch.WriteLine(n + "," + RecordData[j] + ","
                                          + RecordData1[j] + ","
                                          + RecordData2[j] + ","
                                          + RecordData3[j] + ","
                                          + RecordData4[j]);

                swRoll.WriteLine(n + "," + RecordData[j + 1] + ","
                                         + RecordData1[j + 1] + ","
                                         + RecordData2[j + 1] + ","
                                         + RecordData3[j + 1] + ","
                                         + RecordData4[j + 1]);

                swYaw.WriteLine(n + "," + RecordData[j + 2] + ","
                                         + RecordData1[j + 2] + ","
                                         + RecordData2[j + 2] + ","
                                         + RecordData3[j + 2] + ","
                                         + RecordData4[j + 2]);

                Console.WriteLine(i + "---" + j);
            }

            sw.Close();
            fs.Close();

            swPitch.Close();
            fsPitch.Close();
            swRoll.Close();
            fsRoll.Close();
            swYaw.Close();
            fsYaw.Close();
        }

        #endregion

        #region data processing

        public void OnKbootDecoderDataReceived(object sender, byte[] buf, int len)
        {
            UInt16 offset = 0;
            while (offset < len)
            {
                byte cmd = buf[offset];
                switch (cmd)
                {
                    case (byte)IMUData.DataID.kItemID:
                        UranusDataArray[0].ID = buf[offset + 1];
                        offset += 2;
                        break;
                    case (byte)IMUData.DataID.kItemAccRaw:
                        UranusDataArray[0].AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[0].AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[0].AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRaw:
                        UranusDataArray[0].GyroRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[0].GyroRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[0].GyroRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRaw:
                        UranusDataArray[0].MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[0].MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[0].MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdE:
                        UranusDataArray[0].AtdE[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                        UranusDataArray[0].AtdE[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                        UranusDataArray[0].AtdE[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAccRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdQ:
                        offset += 13;
                        break;
                    case (byte)IMUData.DataID.kItemTemp:
                        UranusDataArray[0].Temperature = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    case (byte)IMUData.DataID.kItemPressure:
                        UranusDataArray[0].Pressure = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    default:
                        //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                        return;
                }
            }
        }
        public void OnKbootDecoderDataReceived1(object sender, byte[] buf, int len)
        {
            UInt16 offset = 0;
            while (offset < len)
            {
                byte cmd = buf[offset];
                switch (cmd)
                {
                    case (byte)IMUData.DataID.kItemID:
                        UranusDataArray[1].ID = buf[offset + 1];
                        offset += 2;
                        break;
                    case (byte)IMUData.DataID.kItemAccRaw:
                        UranusDataArray[1].AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[1].AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[1].AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRaw:
                        UranusDataArray[1].GyroRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[1].GyroRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[1].GyroRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRaw:
                        UranusDataArray[1].MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[1].MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[1].MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdE:
                        UranusDataArray[1].AtdE[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                        UranusDataArray[1].AtdE[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                        UranusDataArray[1].AtdE[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAccRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdQ:
                        offset += 13;
                        break;
                    case (byte)IMUData.DataID.kItemTemp:
                        UranusDataArray[1].Temperature = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    case (byte)IMUData.DataID.kItemPressure:
                        UranusDataArray[1].Pressure = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    default:
                        //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                        return;
                }
            }
        }
        public void OnKbootDecoderDataReceived2(object sender, byte[] buf, int len)
        {
            UInt16 offset = 0;
            while (offset < len)
            {
                byte cmd = buf[offset];
                switch (cmd)
                {
                    case (byte)IMUData.DataID.kItemID:
                        UranusDataArray[2].ID = buf[offset + 1];
                        offset += 2;
                        break;
                    case (byte)IMUData.DataID.kItemAccRaw:
                        UranusDataArray[2].AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[2].AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[2].AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRaw:
                        UranusDataArray[2].GyroRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[2].GyroRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[2].GyroRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRaw:
                        UranusDataArray[2].MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[2].MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[2].MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdE:
                        UranusDataArray[2].AtdE[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                        UranusDataArray[2].AtdE[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                        UranusDataArray[2].AtdE[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAccRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdQ:
                        offset += 13;
                        break;
                    case (byte)IMUData.DataID.kItemTemp:
                        UranusDataArray[2].Temperature = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    case (byte)IMUData.DataID.kItemPressure:
                        UranusDataArray[2].Pressure = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    default:
                        //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                        return;
                }
            }
        }
        public void OnKbootDecoderDataReceived3(object sender, byte[] buf, int len)
        {
            UInt16 offset = 0;
            while (offset < len)
            {
                byte cmd = buf[offset];
                switch (cmd)
                {
                    case (byte)IMUData.DataID.kItemID:
                        UranusDataArray[3].ID = buf[offset + 1];
                        offset += 2;
                        break;
                    case (byte)IMUData.DataID.kItemAccRaw:
                        UranusDataArray[3].AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[3].AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[3].AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRaw:
                        UranusDataArray[3].GyroRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[3].GyroRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[3].GyroRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRaw:
                        UranusDataArray[3].MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[3].MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[3].MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdE:
                        UranusDataArray[3].AtdE[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                        UranusDataArray[3].AtdE[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                        UranusDataArray[3].AtdE[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAccRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdQ:
                        offset += 13;
                        break;
                    case (byte)IMUData.DataID.kItemTemp:
                        UranusDataArray[3].Temperature = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    case (byte)IMUData.DataID.kItemPressure:
                        UranusDataArray[3].Pressure = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    default:
                        //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                        return;
                }
            }
        }
        public void OnKbootDecoderDataReceived4(object sender, byte[] buf, int len)
        {
            UInt16 offset = 0;
            while (offset < len)
            {
                byte cmd = buf[offset];
                switch (cmd)
                {
                    case (byte)IMUData.DataID.kItemID:
                        UranusDataArray[4].ID = buf[offset + 1];
                        offset += 2;
                        break;
                    case (byte)IMUData.DataID.kItemAccRaw:
                        UranusDataArray[4].AccRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[4].AccRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[4].AccRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRaw:
                        UranusDataArray[4].GyroRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[4].GyroRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[4].GyroRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRaw:
                        UranusDataArray[4].MagRaw[0] = (Int16)(buf[offset + 1] + (buf[offset + 2] << 8));
                        UranusDataArray[4].MagRaw[1] = (Int16)(buf[offset + 3] + (buf[offset + 4] << 8));
                        UranusDataArray[4].MagRaw[2] = (Int16)(buf[offset + 5] + (buf[offset + 6] << 8));
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdE:
                        UranusDataArray[4].AtdE[0] = (float)(Int16)(buf[offset + 1] + (buf[offset + 2] << 8)) / 100;
                        UranusDataArray[4].AtdE[1] = (float)(Int16)(buf[offset + 3] + (buf[offset + 4] << 8)) / 100;
                        UranusDataArray[4].AtdE[2] = (float)(Int16)(buf[offset + 5] + (buf[offset + 6] << 8)) / 10;
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAccRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemGyoRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemMagRawFiltered:
                        offset += 7;
                        break;
                    case (byte)IMUData.DataID.kItemAtdQ:
                        offset += 13;
                        break;
                    case (byte)IMUData.DataID.kItemTemp:
                        UranusDataArray[4].Temperature = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    case (byte)IMUData.DataID.kItemPressure:
                        UranusDataArray[4].Pressure = (Int32)(buf[offset + 1] + (buf[offset + 2] << 8) + (buf[offset + 3] << 16) + (buf[offset + 4] << 24));
                        offset += 5;
                        break;
                    default:
                        //   if (Enum.IsDefined(typeof(IMUData.DataID), (IMUData.DataID)cmd))
                        return;
                }
            }
        }
        #endregion

        #region data display
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.labelRawData.Text = (UranusDataArray[0].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[0].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[0].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" );
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.labelRawData1.Text = (UranusDataArray[1].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[1].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[1].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n\r");
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            this.labelRawData2.Text = (UranusDataArray[2].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[2].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[2].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n\r");
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            this.labelRawData3.Text = (UranusDataArray[3].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[3].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[3].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n\r");
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            this.labelRawData4.Text = (UranusDataArray[4].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[4].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n\r" +
                                                 UranusDataArray[4].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n\r");
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            RecordData.Add(UranusDataArray[0].AtdE[0].ToString("f2"));
            RecordData.Add(UranusDataArray[0].AtdE[1].ToString("f2"));
            RecordData.Add(UranusDataArray[0].AtdE[2].ToString("f2"));

            RecordData1.Add(UranusDataArray[1].AtdE[0].ToString("f2"));
            RecordData1.Add(UranusDataArray[1].AtdE[1].ToString("f2"));
            RecordData1.Add(UranusDataArray[1].AtdE[2].ToString("f2"));

            RecordData2.Add(UranusDataArray[2].AtdE[0].ToString("f2"));
            RecordData2.Add(UranusDataArray[2].AtdE[1].ToString("f2"));
            RecordData2.Add(UranusDataArray[2].AtdE[2].ToString("f2"));

            RecordData3.Add(UranusDataArray[3].AtdE[0].ToString("f2"));
            RecordData3.Add(UranusDataArray[3].AtdE[1].ToString("f2"));
            RecordData3.Add(UranusDataArray[3].AtdE[2].ToString("f2"));

            RecordData4.Add(UranusDataArray[4].AtdE[0].ToString("f2"));
            RecordData4.Add(UranusDataArray[4].AtdE[1].ToString("f2"));
            RecordData4.Add(UranusDataArray[4].AtdE[2].ToString("f2"));
        }

        private void Button_Record_Click(object sender, EventArgs e)
        {
            timer7.Start();
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            timer7.Stop();
        }

        #endregion

        #region SerialPort_DataReceived Event

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_TCP.spSerialPortArray[0].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_TCP.spSerialPortArray[0].Read(readBuffer, 0, bytesToRead);
            KbootDecoder.Input(readBuffer);

        }
        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_TCP.spSerialPortArray[1].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_TCP.spSerialPortArray[1].Read(readBuffer, 0, bytesToRead);
            KbootDecoder1.Input(readBuffer);

        }
        private void SerialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_TCP.spSerialPortArray[2].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_TCP.spSerialPortArray[2].Read(readBuffer, 0, bytesToRead);
            KbootDecoder2.Input(readBuffer);

        }
        private void SerialPort3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_TCP.spSerialPortArray[3].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_TCP.spSerialPortArray[3].Read(readBuffer, 0, bytesToRead);
            KbootDecoder3.Input(readBuffer);

        }
        private void SerialPort4_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_TCP.spSerialPortArray[4].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_TCP.spSerialPortArray[4].Read(readBuffer, 0, bytesToRead);
            KbootDecoder4.Input(readBuffer);

        }
        #endregion


    }

}
