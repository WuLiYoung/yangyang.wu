using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;

namespace TcpCon
{
    public class TcpCon
    {
        private TcpClient client = null;
        private Thread client_th;
        public delegate void Notify(string value);
        public event Notify notifier;

        public TcpCon()
        {
              
        }

        public TcpCon(string ip, int port)
        {
            try
            {
                client = new TcpClient(ip, port);
                ThreadStart threadStart = new ThreadStart(AcceptMsg);
                client_th = new Thread(threadStart);
                client_th.Start();
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Error:"+e.ToString());
            }
            
        }

        public void Connect_tcp(string ip,int port)
        {
            try
            {

                if (client == null || !client.Connected)
                {
                    client = new TcpClient(ip, port);
                    ThreadStart threadStart = new ThreadStart(AcceptMsg);
                    client_th = new Thread(threadStart);
                    client_th.Start();
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show("Error:" + e.ToString());
            }

        }

        public void DisConnect_tcp()
        {
            try
            {
                if (client.Connected)
                {
                    client.Close();
                }
            }
            catch(System.Exception e)
            {
                MessageBox.Show("Error:" + e.ToString());
            }
        }

        public void AcceptMsg()
        {
            NetworkStream ns = client.GetStream();
            while (true)
            {
                try
                {
                    byte[] bytes = new byte[1024];
                    int bytesread = ns.Read(bytes, 0, bytes.Length);
                    String msg = Encoding.Default.GetString(bytes, 0, bytesread);
                    msg = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")  + " ReceiveMsg" + "]: " + msg + "\r\n";
                    if (notifier != null)
                    {
                        string str = msg;
                        notifier.Invoke(str);
                    }
                    ns.Flush();
                }
                catch (System.Exception e)
                {
                    MessageBox.Show("Error:与服务器断开连接"+ e);
                    break;
                }
            }
        }

        public void SendMsg(String str)
        {
            if (client == null)
            {
                return;
            }
            String msg = str;
            msg = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " SendMsg " + "]: " + msg + "\r\n";
            if (notifier != null)
            {
                notifier.Invoke(msg);
            }           
            NetworkStream sendStream = client.GetStream();
            Byte[] sendBytes = Encoding.Default.GetBytes(str);
            sendStream.Write(sendBytes, 0, sendBytes.Length);
            sendStream.Flush();
        }

    }
}
