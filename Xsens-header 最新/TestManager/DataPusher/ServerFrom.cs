using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using tcpServer;
using System.Net;
using System.Net.Sockets;

namespace DataPusher
{
    public partial class ServerFrom : Form
    {
        public delegate void invokeDelegate();

        public ServerFrom()
        {
            InitializeComponent();
            GT_DataPusher.m_object.OnConnect += new tcpServer.tcpServerConnectionChanged(this.tcpServer1_OnConnect);
            GT_DataPusher.m_object.OnDataAvailable += new tcpServer.tcpServerConnectionChanged(this.tcpServer1_OnDataAvailable);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            GT_DataPusher.m_object.Send(tbInput.Text);
            logData(true,tbInput.Text);
        }

        private void btnconfig_Click(object sender, EventArgs e)
        {
            int nport =Convert.ToInt32(textBoxPort.Text);
            GT_DataPusher.m_object.Close();
            GT_DataPusher.m_object.Port = nport;
            GT_DataPusher.m_object.Open();
            displayTcpServerStatus();
        }

        public void logData(bool sent, string text)
        {
            txtLog.Text += "\r\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt") + (sent ? " SENT:\r\n" : " RECEIVED:\r\n");
            txtLog.Text += text;
            txtLog.Text += "\r\n";
            if (txtLog.Lines.Length > 500)
            {
                string[] temp = new string[500];
                Array.Copy(txtLog.Lines, txtLog.Lines.Length - 500, temp, 0, 500);
                txtLog.Lines = temp;
            }
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void displayTcpServerStatus()
        {
            if (GT_DataPusher.m_object.IsOpen)
            {
                labelopen.Text = "PORT OPEN";
                labelopen.BackColor = Color.Lime;
            }
            else
            {
                labelopen.Text = "PORT NOT OPEN";
                labelopen.BackColor = Color.Red;
            }
        }

        private void tcpServer1_OnDataAvailable(tcpServer.TcpServerConnection connection)
        {
            byte[] data = readStream(connection.Socket);

            if (data != null)
            {
                string dataStr = Encoding.ASCII.GetString(data);

                invokeDelegate del = () =>
                {
                    logData(false, dataStr);
                };
                Invoke(del);

                data = null;
            }
        }

        protected byte[] readStream(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            if (stream.DataAvailable)
            {
                byte[] data = new byte[client.Available];

                int bytesRead = 0;
                try
                {
                    bytesRead = stream.Read(data, 0, data.Length);
                }
                catch (IOException)
                {
                }

                if (bytesRead < data.Length)
                {
                    byte[] lastData = data;
                    data = new byte[bytesRead];
                    Array.ConstrainedCopy(lastData, 0, data, 0, bytesRead);
                }
                return data;
            }
            return null;
        }

        private void tcpServer1_OnConnect(tcpServer.TcpServerConnection connection)
        {
            invokeDelegate setText = () => lbconnectstate.Text = GT_DataPusher.m_object.Connections.Count >0? "Connect" : "Not Connect";

            Invoke(setText);
        }

        private void BtnMacStart_Click(object sender, EventArgs e)
        {
            GT_DataPusher.m_object.Send("AA00013ZZ");
        }

        private void btnMacStatue_Click(object sender, EventArgs e)
        {
            GT_DataPusher.m_object.Send("AA00014ZZ");
        }
    }
}
