using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.IO.FileStream;
using System.IO;
using System.Threading;
//using System.Threading.Tasks;
using System.Windows.Forms;
using XDA;
namespace Senxda
{
    public partial class Form1 : Form
    {
        //private MyXda ;
        public Data collectData = new Data();
        List<string> RecorIMUdData = new List<string>();
        private XsDevice _measuringDevice = null;
        private MyMtCallback _myMtCallback = null;
        private ConnectedMtData _connectedData = new ConnectedMtData();
        //public static ConnectedMtData _connectedData0;
        private string csv_oppath = @"C:\Intelli_TuoLuoYi\Output\";

        List<double> x = new List<double>();
        List<double> y = new List<double>();
        List<double> z = new List<double>();
        List<double> xyz = new List<double>();

        public delegate void temp();
        public temp tempDataCallBack;

        public Form1()
        {

            tempDataCallBack = new temp(tempData);


            InitializeComponent();
            GT_Senxda.m_object = new MyXda();
            this.btnScan_Click(null, null);
            rtbSteps.Text = "Press 'Scan' to scan for MTi / MTx / Mk4 devices";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;

            if (_measuringDevice != null)
                _measuringDevice.clearCallbackHandlers();
            if (_myMtCallback != null)
                _myMtCallback.Dispose();

            GT_Senxda.m_object.Dispose();
            GT_Senxda.m_object = null;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            rtbSteps.Text = "Scanning for devices...";
            btnScan.Enabled = false;
            Update();

            GT_Senxda.m_object.reset();
            GT_Senxda.m_object.scanPorts();
            if (GT_Senxda.m_object._DetectedDevices.Count > 0)
            {
                rtbSteps.Text = string.Format("Found {0} device(s)\n", GT_Senxda.m_object._DetectedDevices.Count);
                XsPortInfo portInfo = GT_Senxda.m_object._DetectedDevices[0];
                if (portInfo.deviceId().isMtMk4() || portInfo.deviceId().isFmt_X000() || portInfo.deviceId().isMt9c() || portInfo.deviceId().isLegacyMtig())
                {
                    rtbSteps.Text += "Opening port...\n";
                    GT_Senxda.m_object.openPort(portInfo);
                    MasterInfo ai = new MasterInfo(portInfo.deviceId());
                    ai.ComPort = portInfo.portName();
                    ai.BaudRate = portInfo.baudrate();

                    _measuringDevice = GT_Senxda.m_object.getDevice(ai.DeviceId);
                    ai.ProductCode = new XsString(_measuringDevice.productCode());

                    // Print information about detected MTi / MTx / MTmk4 device
                    rtbSteps.Text += string.Format("Found a device with id: {0} @ port: {1}, baudrate: {2}\n", _measuringDevice.deviceId().toXsString().toString(), ai.ComPort.toString(), ai.BaudRate);

                    // Create and attach callback handler to device
                    _myMtCallback = new MyMtCallback();
                    _measuringDevice.addCallbackHandler(_myMtCallback);

                    ConnectedMtData mtwData = new ConnectedMtData();

                    // connect signals
                    _myMtCallback.DataAvailable += new EventHandler<DataAvailableArgs>(_callbackHandler_DataAvailable);

                    // Put the device in configuration mode
                    rtbSteps.Text += "Putting device into configuration mode...\n";
                    if (!_measuringDevice.gotoConfig()) // Put the device into configuration mode before configuring the device
                    {
                        rtbSteps.Text = "Could not put device into configuration mode. Aborting.";
                        return;
                    }

                    // Configure the device. Note the differences between MTix and MTmk4
                    rtbSteps.Text += "Configuring the device...\n";
                    if (_measuringDevice.deviceId().isMt9c() || _measuringDevice.deviceId().isLegacyMtig())
                    {
                        XsOutputMode outputMode = XsOutputMode.XOM_Orientation; // output orientation data
                        XsOutputSettings outputSettings = XsOutputSettings.XOS_OrientationMode_Quaternion; // output orientation data as quaternion
                        XsDeviceMode deviceMode = new XsDeviceMode(100); // make a device mode with update rate: 100 Hz
                        deviceMode.setModeFlag(outputMode);
                        deviceMode.setSettingsFlag(outputSettings);

                        // set the device configuration
                        if (!_measuringDevice.setDeviceMode(deviceMode))
                        {
                            rtbSteps.Text = "Could not configure MTix device. Aborting.";
                            return;
                        }
                    }
                    else if (_measuringDevice.deviceId().isMtMk4() || _measuringDevice.deviceId().isFmt_X000())
                    {
                        XsOutputConfigurationArray configArray = new XsOutputConfigurationArray();
                        if (_measuringDevice.deviceId().isMtMk4_1() || _measuringDevice.deviceId().isMtMk4_10() || _measuringDevice.deviceId().isMtMk4_100() || _measuringDevice.deviceId().isFmt1010())
                        {
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_PacketCounter, 0));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_SampleTimeFine, 0));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_DeltaV, 100));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_DeltaQ, 100));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_MagneticField, 100));
                        }
                        else
                        {
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_PacketCounter, 0));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_SampleTimeFine, 0));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_Quaternion, 100));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_DeltaV, 100));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_DeltaQ, 100));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_MagneticField, 100));
                            configArray.push_back(new XsOutputConfiguration(XsDataIdentifier.XDI_StatusWord, 0));
                        }
                        if (!_measuringDevice.setOutputConfiguration(configArray))
                        {
                            rtbSteps.Text = "Could not configure MTmk4 device. Aborting.";
                            return;
                        }
                    }
                    else
                    {
                        rtbSteps.Text = "Unknown device while configuring. Aborting.";
                        return;
                    }

                    // Put the device in measurement mode
                    rtbSteps.Text += "Putting device into measurement mode...\n";
                    if (!_measuringDevice.gotoMeasurement())
                    {
                        rtbSteps.Text = "Could not put device into measurement mode. Aborting.";
                        return;
                    }
                    btnRecord.Enabled = true;
                }
                timer1.Interval = 20;
                timer1.Enabled = true;
            }
            else
            {
                rtbSteps.Text = "No devices detected. Press 'Scan' to retry.";
                btnScan.Enabled = true;
            }
        }

        public void record()
        {
            timer2.Start();
        }

        public void btnRecord_Click(object sender, EventArgs e)
        {
            timer2.Start();
            _measuringDevice.createLogFile(new XsString(textBoxFilename.Text));
            _measuringDevice.startRecording();
            btnRecord.Enabled = false;
            btnStop.Enabled = true;
        }

        public void btnStop_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            btnStop.Enabled = false;
            //timer1.Enabled = false;

            //if (_measuringDevice.isRecording())
            //    _measuringDevice.stopRecording();
            //_measuringDevice.gotoConfig();
            //_measuringDevice.clearCallbackHandlers();
            //_measuringDevice = null;

            btnScan.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (_connectedData._orientation != null)
            {
                rtbData.Text = string.Format("{0,-5:f2}, {1,-5:f2}, {2,-5:f2} [°]\n\n",
                                       _connectedData._orientation.z(),
                                       _connectedData._orientation.x(),
                                       _connectedData._orientation.y()
                                       );
                //Console.WriteLine(_connectedData._orientation.z());
            }

            if (_connectedData._calibratedData != null)
            {
                rtbData.Text += string.Format("{0,-5:f2}, {1,-5:f2}, {2,-5:f2} \n{3,-5:f2}, {4,-5:f2}, {5,-5:f2} \n{6,-5:f2}, {7,-5:f2}, {8,-5:f2} \n",
                                       _connectedData._calibratedData.m_acc.value(0),
                                       _connectedData._calibratedData.m_acc.value(1),
                                       _connectedData._calibratedData.m_acc.value(2),
                                       _connectedData._calibratedData.m_gyr.value(0),
                                       _connectedData._calibratedData.m_gyr.value(1),
                                       _connectedData._calibratedData.m_gyr.value(2),
                                       _connectedData._calibratedData.m_mag.value(0),
                                       _connectedData._calibratedData.m_mag.value(1),
                                       _connectedData._calibratedData.m_mag.value(2));
            }
        }

        void _callbackHandler_DataAvailable(object sender, DataAvailableArgs e)
        {
            if (InvokeRequired)
            {
                // Update UI, make sure this happens on the UI thread
                BeginInvoke(new Action(delegate { _callbackHandler_DataAvailable(sender, e); }));
            }
            else
            {
                //Getting Euler angles.
                XsEuler oriEuler = e.Packet.orientationEuler();
                _connectedData._orientation = oriEuler;
                XsCalibratedData calData = e.Packet.calibratedData();
                _connectedData._calibratedData = calData;
            }
        }

        private void OutPutCSV_Click(object sender, EventArgs e)
        {             
                
                    string now1 = DateTime.Now.ToString();
                    string now2 = now1.Replace(':', '-');
                    string now = now2.Replace('/', '-');
                    string file = csv_oppath + "标准IMU_" + "OutPut_" + "_" + now + ".csv";
                     FileInfo fi = new FileInfo(file);
                     if (!fi.Directory.Exists)
                     {
                         fi.Directory.Create();
                     }
                     FileStream fs = new FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                     StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                     sw.WriteLine("pitch,Roll,Yaw");

                     int j = 0;
                     for (int i = 0; i < RecorIMUdData.Count / 3 -10; i++)
                     {
                         j = i * 3;
                         sw.WriteLine(RecorIMUdData[j] + "," + RecorIMUdData[j + 1] + "," + RecorIMUdData[j + 2]);
                     }
                     sw.Close();
                     fs.Close();
                     //for (int j = 0; j < 1000; j++)
                     //{
                     
                     //}



        }

        private void rtbData_TextChanged(object sender, EventArgs e)
        {

        }

        
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            if (_connectedData._orientation != null)
            {
                switch (i)
                {
                    case 0:
                        Class1.setA0 = _connectedData._orientation.z();
                        Class1.setB0 = _connectedData._orientation.x();
                        Class1.setC0 = _connectedData._orientation.y();
                        break;

                    case 1:
                        Class1.setA1 = _connectedData._orientation.z();
                        Class1.setB1 = _connectedData._orientation.x();
                        Class1.setC1 = _connectedData._orientation.y();
                        break;

                    case 2:
                        Class1.setA2 = _connectedData._orientation.z();
                        Class1.setB2 = _connectedData._orientation.x();
                        Class1.setC2 = _connectedData._orientation.y();
                        break;

                    case 3:
                        Class1.setA3 = _connectedData._orientation.z();
                        Class1.setB3 = _connectedData._orientation.x();
                        Class1.setC3 = _connectedData._orientation.y();
                        break;

                    case 4:
                        Class1.setA4 = _connectedData._orientation.z();
                        Class1.setB4 = _connectedData._orientation.x();
                        Class1.setC4 = _connectedData._orientation.y();
                        break;
                    default:
                        break;
                }
            }
          
            i++;
            if (i == 5)
            {
                this.button1.Enabled = false;
            }

        }

        //临时数据
        int num = 0;
        public  void tempData()
        {

            if (_connectedData._orientation != null)
            {
                RecorIMUdData.Add(_connectedData._orientation.y().ToString("f2"));
                RecorIMUdData.Add(_connectedData._orientation.x().ToString("f2"));
                RecorIMUdData.Add(_connectedData._orientation.z().ToString("f2"));

            }
            //Console.WriteLine("------" + RecorIMUdData[num]);
            //Console.WriteLine("------" + RecorIMUdData[num + 1]);
            //Console.WriteLine("------" + RecorIMUdData[num + 2]);
            num++;
            Console.WriteLine("------" + num);

            if (num == 1)
            {
                double temp = double.Parse(this.textBox1.Text); //步长
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
                            xyz.Add(x[i]);
                            xyz.Add(y[j]);
                            xyz.Add(z[q]);
                        }
                    }
                }
            }
            if (num == x.Count * y.Count * z.Count)
            {
                string now1 = DateTime.Now.ToString();
                string now2 = now1.Replace(':', '-');
                string now = now2.Replace('/', '-');
                string file = csv_oppath + "IMU临时数据_" + "OutPut_" + "_" + now + ".csv";
                FileInfo fi = new FileInfo(file);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                FileStream fs = new FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

                sw.WriteLine("x,y,z,pitch,Roll,Yaw");
                int m = 0;
                for (int n = 0; n < RecorIMUdData.Count / 3; n++)
                {
                    m = n * 3;
                    sw.WriteLine(xyz[m] + "," + xyz[m + 1] + "," + xyz[m + 2] + "," + RecorIMUdData[m] + "," + RecorIMUdData[m + 1] + "," + RecorIMUdData[m + 2]);
                }


                sw.Close();
                fs.Close();

                num = 0;
                RecorIMUdData.RemoveAll(it => true);
                xyz.RemoveAll(it => true);
                x.RemoveAll(it => true);
                y.RemoveAll(it => true);
                z.RemoveAll(it => true);
            }
        }

        //确定步长
        private void button2_Click(object sender, EventArgs e)
        {
            double temp = double.Parse(this.textBox1.Text); //步长
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
                        xyz.Add(x[i]);
                        xyz.Add(y[j]);
                        xyz.Add(z[q]);
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RecorIMUdData.Add(_connectedData._orientation.y().ToString("f2"));
            RecorIMUdData.Add(_connectedData._orientation.x().ToString("f2"));
            RecorIMUdData.Add(_connectedData._orientation.z().ToString("f2"));
        }

        

       
     }
     public static class Class1
    {
        public static double A0;
        public static double A1;
        public static double A2;
        public static double A3;
        public static double A4;
        public static double B0;
        public static double B1;
        public static double B2;
        public static double B3;
        public static double B4;
        public static double C0;
        public static double C1;
        public static double C2;
        public static double C3;
        public static double C4;

        public static double getA0
        {
            get { return A0; }
        }

        public static double setA0
        {
            set { A0 = value; }
        }

        public static double getA1
        {
            get { return A1; }
        }

        public static double setA1
        {
            set { A1 = value; }
        }

        public static double getA2
        {
            get { return A2; }
        }

        public static double setA2
        {
            set { A2 = value; }
        }

        public static double getA3
        {
            get { return A3; }
        }

        public static double setA3
        {
            set { A3 = value; }
        }

        public static double getA4
        {
            get { return A4; }
        }

        public static double setA4
        {
            set { A4 = value; }
        }

        public static double getB0
        {
            get { return B0; }
        }

        public static double setB0
        {
            set { B0 = value; }
        }

        public static double getB1
        {
            get { return B1; }
        }

        public static double setB1
        {
            set { B1 = value; }
        }

        public static double getB2
        {
            get { return B2; }
        }

        public static double setB2
        {
            set { B2 = value; }
        }

        public static double getB3
        {
            get { return B3; }
        }

        public static double setB3
        {
            set { B3 = value; }
        }

        public static double getB4
        {
            get { return B4; }
        }

        public static double setB4
        {
            set { B4 = value; }
        }

        public static double getC0
        {
            get { return C0; }
        }

        public static double setC0
        {
            set { C0 = value; }
        }

        public static double getC1
        {
            get { return C1; }
        }

        public static double setC1
        {
            set { C1 = value; }
        }

        public static double getC2
        {
            get { return C2; }
        }

        public static double setC2
        {
            set { C2 = value; }
        }

        public static double getC3
        {
            get { return C3; }
        }

        public static double setC3
        {
            set { C3 = value; }
        }

        public static double getC4
        {
            get { return C4; }
        }

        public static double setC4
        {
            set { C4 = value; }
        }
    }
 }
