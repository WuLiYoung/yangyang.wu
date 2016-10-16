using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Globalization;
using System.Resources;
using System.Diagnostics;
using System.IO;
using Senxda;
using XDA;
using System.Collections.Generic;

namespace SensDut
{
    public partial class MainForm : Form
    {
        private bool bListening = false;

        private string csv_oppath = @"C:\Intelli_TuoLuoYi\Output\";

        private Int32 Baund = 115200;
        KbootPacketDecoder KbootDecoder = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder1 = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder2 = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder3 = new KbootPacketDecoder();
        KbootPacketDecoder KbootDecoder4 = new KbootPacketDecoder();

        IMUData UranusData = new IMUData();

        List<string> RecordData = new List<string>();
        List<string> RecordData1 = new List<string>();
        List<string> RecordData2 = new List<string>();
        List<string> RecordData3 = new List<string>();
        List<string> RecordData4 = new List<string>();



        private static IMUData[] UranusDataArray = new IMUData[5] { new IMUData(), new IMUData(), new IMUData(), new IMUData(), new IMUData() };       
        private SerialPort spSerialPort;

           
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //GT_SensDut.spSerialPortArray[0].Open;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshComPort(null, null);
            Baund = 115200;
            spSerialPort.BaudRate = 115200;

            SetBaudrate(Baund);
            KbootDecoder.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived);
            KbootDecoder1.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived1);
            KbootDecoder2.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived2);
            KbootDecoder3.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived3);
            KbootDecoder4.OnPacketRecieved += new KbootPacketDecoder.KBootDecoderDataReceivedEventHandler(OnKbootDecoderDataReceived4);



            GT_SensDut.spSerialPortArray[0].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort_DataReceived);
            GT_SensDut.spSerialPortArray[0].BaudRate = 115200;

            GT_SensDut.spSerialPortArray[1].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            GT_SensDut.spSerialPortArray[1].BaudRate = 115200;

            GT_SensDut.spSerialPortArray[2].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort2_DataReceived);
            GT_SensDut.spSerialPortArray[2].BaudRate = 115200;

            GT_SensDut.spSerialPortArray[3].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort3_DataReceived);
            GT_SensDut.spSerialPortArray[3].BaudRate = 115200;

            GT_SensDut.spSerialPortArray[4].DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort4_DataReceived);
            GT_SensDut.spSerialPortArray[4].BaudRate = 115200;
        }
        

        #region COM port operation

        private void SetBaudrate(int iBaund)
        {
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
            toolStripMenuItem10.Checked = false;
            toolStripMenuItem11.Checked = false;
            switch (iBaund)
            {
                case 2400: toolStripMenuItem2.Checked = true; break;
                case 4800: toolStripMenuItem3.Checked = true; break;
                case 9600: toolStripMenuItem4.Checked = true; break;
                case 19200: toolStripMenuItem5.Checked = true; break;
                case 38400: toolStripMenuItem6.Checked = true; break;
                case 57600: toolStripMenuItem7.Checked = true; break;
                case 115200: toolStripMenuItem8.Checked = true; break;
                case 230400: toolStripMenuItem9.Checked = true; break;
                case 460800: toolStripMenuItem10.Checked = true; break;
                case 921600: toolStripMenuItem11.Checked = true; break;
            }
          //  spSerialPort.BaudRate = iBaund;
            for (int i = 0; i < 6; i++)
                GT_SensDut.spSerialPortArray[i].BaudRate = iBaund;
        }

        private void RefreshComPort(object sender, EventArgs e)
        {
            toolStripComSet.DropDownItems.Clear();
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                toolStripComSet.DropDownItems.Add(portName, null, PortSelect);
                comboBox1.Items.Add(portName);
                comboBox2.Items.Add(portName);
                comboBox3.Items.Add(portName);
                comboBox4.Items.Add(portName);
                comboBox5.Items.Add(portName);
               
                // if ((GT_SensDut.spSerialPortArray[0].IsOpen) & (GT_SensDut.spSerialPortArray[0].PortName == portName))
                //{
                //    ToolStripMenuItem menu = (ToolStripMenuItem)toolStripComSet.DropDownItems[toolStripComSet.DropDownItems.Count - 1];
                //    menu.Checked = true;       
                //}
               
            }
            toolStripComSet.DropDownItems.Add(new ToolStripSeparator());
            toolStripComSet.DropDownItems.Add("Close", null, PortClose);
        }

        private void PortSelect(object sender, EventArgs e)
        {
            //ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            //try
            //{
            //    PortClose(null, null);
            //    //////////////////////////////////
            //    GT_SensDut.spSerialPortArray[0].PortName = menu.Text;
            //    GT_SensDut.spSerialPortArray[0].BaudRate = Baund;
            //    GT_SensDut.spSerialPortArray[0].Open();
            //    menu.Checked = true;

            //    timer3.Start();

            //}
            //catch (Exception ex)
            //{
            //    menu.Checked = false;
            //}

        }
        private void PortClose(object sender, EventArgs e)
        {
            for (int i = 0; i < toolStripComSet.DropDownItems.Count - 2; i++)
            {
                ToolStripMenuItem tempMenu = (ToolStripMenuItem)toolStripComSet.DropDownItems[i];
                tempMenu.Checked = false;
            }

            //////////////////////////////////
            if (GT_SensDut.spSerialPortArray[0].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_SensDut.spSerialPortArray[0].Dispose();
                GT_SensDut.spSerialPortArray[0].Close();
                timer3.Stop();
            }
            if (GT_SensDut.spSerialPortArray[1].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_SensDut.spSerialPortArray[1].Dispose();
                GT_SensDut.spSerialPortArray[1].Close();
                timer2.Stop();
            }
            if (GT_SensDut.spSerialPortArray[2].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_SensDut.spSerialPortArray[2].Dispose();
                GT_SensDut.spSerialPortArray[2].Close();
                timer4.Stop();
            }
            if (GT_SensDut.spSerialPortArray[3].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_SensDut.spSerialPortArray[3].Dispose();
                GT_SensDut.spSerialPortArray[3].Close();
                timer5.Stop();
            }
            if (GT_SensDut.spSerialPortArray[4].IsOpen)
            {
                //bClosing = true;
                while (bListening) Application.DoEvents();
                GT_SensDut.spSerialPortArray[4].Dispose();
                GT_SensDut.spSerialPortArray[4].Close();
                timer6.Stop();
            }
            
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

        private void DisplayRefresh(object sender, EventArgs e)
        {
            double Pa = 0;
            Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(UranusDataArray[0].Pressure) / (double)101325), 0.190295));

            labelRawData.Text = (UranusDataArray[0].AccRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 (UranusDataArray[0].AccRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 (UranusDataArray[0].AccRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 (UranusDataArray[0].GyroRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 (UranusDataArray[0].GyroRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 (UranusDataArray[0].GyroRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[0].MagRaw[0].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[0].MagRaw[1].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[0].MagRaw[2].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[0].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[0].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[0].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[0].Pressure.ToString("0").PadLeft(4, ' ') + "Pa " + Pa.ToString("f0") + "m\r\n" +
                                                UranusDataArray[0].ID.ToString().PadLeft(5, ' ');


            


           
        }
        private void DisplayRefresh1(object sender, EventArgs e)
        {
            double Pa = 0;
            Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(UranusDataArray[1].Pressure) / (double)101325), 0.190295));

            labelRawData1.Text = (UranusDataArray[1].AccRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[1].AccRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[1].AccRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[1].GyroRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[1].GyroRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[1].GyroRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[1].MagRaw[0].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[1].MagRaw[1].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[1].MagRaw[2].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[1].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[1].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[1].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[1].Pressure.ToString("0").PadLeft(4, ' ') + "Pa " + Pa.ToString("f0") + "m\r\n" +
                                                UranusDataArray[1].ID.ToString().PadLeft(5, ' ');
        }
        private void DisplayRefresh2(object sender, EventArgs e)
        {
            double Pa = 0;
            Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(UranusDataArray[2].Pressure) / (double)101325), 0.190295));

            labelRawData2.Text = (UranusDataArray[2].AccRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[2].AccRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[2].AccRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[2].GyroRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[2].GyroRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                (UranusDataArray[2].GyroRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[2].MagRaw[0].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[2].MagRaw[1].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[2].MagRaw[2].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                                 UranusDataArray[2].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[2].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[2].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                                 UranusDataArray[2].Pressure.ToString("0").PadLeft(4, ' ') + "Pa " + Pa.ToString("f0") + "m\r\n" +
                                                UranusDataArray[2].ID.ToString().PadLeft(5, ' ');
        }
        private void DisplayRefresh3(object sender, EventArgs e)
        {
            double Pa = 0;
            Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(UranusDataArray[3].Pressure) / (double)101325), 0.190295));

            labelRawData3.Text = (UranusDataArray[3].AccRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[3].AccRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[3].AccRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[3].GyroRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[3].GyroRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[3].GyroRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[3].MagRaw[0].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[3].MagRaw[1].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[3].MagRaw[2].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[3].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                     UranusDataArray[3].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                     UranusDataArray[3].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                     UranusDataArray[3].Pressure.ToString("0").PadLeft(4, ' ') + "Pa " + Pa.ToString("f0") + "m\r\n" +
                                    UranusDataArray[3].ID.ToString().PadLeft(5, ' ');
        }
        private void DisplayRefresh4(object sender, EventArgs e)
        {
            double Pa = 0;
            Pa = (double)44330 * (1.0 - Math.Pow((Convert.ToDouble(UranusDataArray[4].Pressure) / (double)101325), 0.190295));

            labelRawData4.Text = (UranusDataArray[4].AccRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[4].AccRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[4].AccRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[4].GyroRaw[0]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[4].GyroRaw[1]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     (UranusDataArray[4].GyroRaw[2]).ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[4].MagRaw[0].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[4].MagRaw[1].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[4].MagRaw[2].ToString("0").PadLeft(5, ' ') + " \r\n" +
                                     UranusDataArray[4].AtdE[0].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                     UranusDataArray[4].AtdE[1].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                     UranusDataArray[4].AtdE[2].ToString("f2").PadLeft(6, ' ') + " °\r\n" +
                                     UranusDataArray[4].Pressure.ToString("0").PadLeft(4, ' ') + "Pa " + Pa.ToString("f0") + "m\r\n" +
                                    UranusDataArray[4].ID.ToString().PadLeft(5, ' ');
        }


        #endregion

        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_SensDut.spSerialPortArray[0].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_SensDut.spSerialPortArray[0].Read(readBuffer, 0, bytesToRead);
            KbootDecoder.Input(readBuffer);

        }
        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_SensDut.spSerialPortArray[1].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_SensDut.spSerialPortArray[1].Read(readBuffer, 0, bytesToRead);
            KbootDecoder1.Input(readBuffer);

        }
        private void SerialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_SensDut.spSerialPortArray[2].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_SensDut.spSerialPortArray[2].Read(readBuffer, 0, bytesToRead);
            KbootDecoder2.Input(readBuffer);

        }
        private void SerialPort3_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_SensDut.spSerialPortArray[3].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_SensDut.spSerialPortArray[3].Read(readBuffer, 0, bytesToRead);
            KbootDecoder3.Input(readBuffer);

        }
        private void SerialPort4_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            int bytesToRead = GT_SensDut.spSerialPortArray[4].BytesToRead;
            byte[] readBuffer = new byte[bytesToRead];
            GT_SensDut.spSerialPortArray[4].Read(readBuffer, 0, bytesToRead);
            KbootDecoder4.Input(readBuffer);

        }
        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
               // PortClose(null, null);
            }
            catch { }

        }
        #region UI choose baud
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Baund = 2400;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Baund = 4800;
            SetBaudrate(Baund);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Baund = 9600;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Baund = 19200;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Baund = 38400;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Baund = 57600;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            Baund = 115200;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            Baund = 230400;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            Baund = 460800;
            SetBaudrate(Baund);
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            Baund = 921600;
            SetBaudrate(Baund);
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
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

                swRoll.WriteLine(n + "," + RecordData[j+1] + ","
                                         + RecordData1[j+1] + ","
                                         + RecordData2[j+1] + ","
                                         + RecordData3[j+1] + ","
                                         + RecordData4[j+1]);

                swYaw.WriteLine(n + "," + RecordData[j+2] + ","
                                         + RecordData1[j+2] + ","
                                         + RecordData2[j+2] + ","
                                         + RecordData3[j+2] + ","
                                         + RecordData4[j+2]);

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

        private void button_Stop_Click(object sender, EventArgs e)
        {
          
            timer7.Stop();
        }

        private void Button_Record_Click(object sender, EventArgs e)
        {
            
            timer7.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != null)
            {
                GT_SensDut.spSerialPortArray[0].PortName = this.comboBox1.Text;
                GT_SensDut.spSerialPortArray[0].BaudRate = Baund;
                GT_SensDut.spSerialPortArray[0].Open();
                this.timer3.Start();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.comboBox2.Text != null)
            {
                GT_SensDut.spSerialPortArray[1].PortName = this.comboBox2.Text;
                GT_SensDut.spSerialPortArray[1].BaudRate = Baund;
                GT_SensDut.spSerialPortArray[1].Open();
                this.timer2.Start();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.comboBox3.Text != null)
            {
                GT_SensDut.spSerialPortArray[2].PortName = this.comboBox3.Text;
                GT_SensDut.spSerialPortArray[2].BaudRate = Baund;
                GT_SensDut.spSerialPortArray[2].Open();
                this.timer4.Start();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.comboBox4.Text != null)
            {
                GT_SensDut.spSerialPortArray[3].PortName = this.comboBox4.Text;
                GT_SensDut.spSerialPortArray[3].BaudRate = Baund;
                GT_SensDut.spSerialPortArray[3].Open();
                this.timer5.Start();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.comboBox5.Text != null)
            {
                GT_SensDut.spSerialPortArray[4].PortName = this.comboBox5.Text;
                GT_SensDut.spSerialPortArray[4].BaudRate = Baund;
                GT_SensDut.spSerialPortArray[4].Open();
                this.timer6.Start();
            }
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


    }
}
