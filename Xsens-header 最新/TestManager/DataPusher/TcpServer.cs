/****************************************************************
 * This work is original work authored by Craig Baird, released *
 * under the Code Project Open Licence (CPOL) 1.02;             *
 * http://www.codeproject.com/info/cpol10.aspx                  *
 * This work is provided as is, no guarentees are made as to    *
 * suitability of this work for any specific purpose, use it at *
 * your own risk.                                               *
 * If this work is redistributed in code form this header must  *
 * be included and unchanged.                                   *
 * Any modifications made, other than by the original author,   *
 * shall be listed below.                                       *
 * Where applicable any headers added with modifications shall  *
 * also be included.                                            *
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

namespace tcpServer
{
    public delegate void tcpServerConnectionChanged(TcpServerConnection connection);
    public delegate void tcpServerError(TcpServer server, Exception e);

    public partial class TcpServer //: Component
    {
        private List<TcpServerConnection> connections;
        private TcpListener listener;

        private Thread listenThread;
        private Thread sendThread;

        private bool m_isOpen;

        private int m_port;
        private int m_maxSendAttempts;
        private int m_idleTime;
        private int m_maxCallbackThreads;
        private int m_verifyConnectionInterval;
        private Encoding m_encoding;

        private Semaphore sem;
        private bool waiting;

        private int activeThreads;
        private object activeThreadsLock = new object();

        public event tcpServerConnectionChanged OnConnect = null;
        public event tcpServerConnectionChanged OnDataAvailable = null;
        public event tcpServerError OnError = null;

        public TcpServer()
        {
            //InitializeComponent();

            initialise();
        }

        //public TcpServer(IContainer container)
        //{
        //    container.Add(this);

        //    //InitializeComponent();

        //    initialise();
        //}

        private void initialise()
        {
            connections = new List<TcpServerConnection>();
            listener = null;

            listenThread = null;
            sendThread = null;

            m_port = -1;
            m_maxSendAttempts = 3;
            m_isOpen = false;
            m_idleTime = 50;
            m_maxCallbackThreads = 100;
            m_verifyConnectionInterval = 100;
            m_encoding = Encoding.ASCII;

            sem = new Semaphore(0,1);
            waiting = false;

            activeThreads = 0;
        }

        public int Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                if (m_port == value)
                {
                    return;
                }

                if (m_isOpen)
                {
                    throw new Exception("Invalid attempt to change port while still open.\nPlease close port before changing.");
                }

                m_port = value;
                if (listener == null)
                {
                    //this should only be called the first time.
                    listener = new TcpListener(IPAddress.Any, m_port);
                }
                else
                {
                    listener.Server.Bind(new IPEndPoint(IPAddress.Any, m_port));
                }
            }
        }

        public int MaxSendAttempts
        {
            get
            {
                return m_maxSendAttempts;
            }
            set
            {
                m_maxSendAttempts = value;
            }
        }

        [Browsable(false)]
        public bool IsOpen
        {
            get
            {
                return m_isOpen;
            }
            set
            {
                if (m_isOpen == value)
                {
                    return;
                }

                if (value)
                {
                    Open();
                }
                else
                {
                    Close();
                }
            }
        }

        public List<TcpServerConnection> Connections
        {
            get
            {
                List<TcpServerConnection> rv = new List<TcpServerConnection>();
                rv.AddRange(connections);
                return rv;
            }
        }

        public int IdleTime
        {
            get
            {
                return m_idleTime;
            }
            set
            {
                m_idleTime = value;
            }
        }

        public int MaxCallbackThreads
        {
            get
            {
                return m_maxCallbackThreads;
            }
            set
            {
                m_maxCallbackThreads = value;
            }
        }

        public int VerifyConnectionInterval
        {
            get
            {
                return m_verifyConnectionInterval;
            }
            set
            {
                m_verifyConnectionInterval = value;
            }
        }

        public Encoding Encoding
        {
            get
            {
                return m_encoding;
            }
            set
            {
                Encoding oldEncoding = m_encoding;
                m_encoding = value;
                foreach (TcpServerConnection client in connections)
                {
                    if (client.Encoding == oldEncoding)
                    {
                        client.Encoding = m_encoding;
                    }
                }
            }
        }

        public void setEncoding(Encoding encoding, bool changeAllClients)
        {
            Encoding oldEncoding = m_encoding;
            m_encoding = encoding;
            if (changeAllClients)
            {
                foreach (TcpServerConnection client in connections)
                {
                    client.Encoding = m_encoding;
                }
            }
        }

        private void runListener()
        {
            while (m_isOpen && m_port >= 0)
            {
                try
                {
                    if (listener.Pending())
                    {
                        TcpClient socket = listener.AcceptTcpClient();
                        TcpServerConnection conn = new TcpServerConnection(socket, m_encoding);

                        if (OnConnect != null)
                        {
                            lock (activeThreadsLock)
                            {
                                activeThreads++;
                            }
                            conn.CallbackThread = new Thread(() =>
                            {
                                OnConnect(conn);
                            });
                            conn.CallbackThread.Start();
                        }

                        lock (connections)
                        {
                            connections.Add(conn);
                        }
                    }
                    else
                    {
                        if(System.Threading.Thread.CurrentThread.IsAlive)
                             System.Threading.Thread.Sleep(m_idleTime);
                    }
                }
                catch (ThreadInterruptedException) { } //thread is interrupted when we quit
                catch (Exception e)
                {
                    if (m_isOpen && OnError != null)
                    {
                        OnError(this, e);
                    }
                }
            }
        }

        private void runSender()
        {
            while (m_isOpen && m_port >= 0)
            {
                try
                {
                    bool moreWork = false;
                    for (int i = 0; i < connections.Count; i++)
                    {
                        if (connections[i].CallbackThread != null)
                        {
                            try
                            {
                                connections[i].CallbackThread = null;
                                lock (activeThreadsLock)
                                {
                                    activeThreads--;
                                }
                            }
                            catch (Exception)
                            {
                                //an exception is thrown when setting thread and old thread hasn't terminated
                                //we don't need to handle the exception, it just prevents decrementing activeThreads
                            }
                        }

                        if (connections[i].CallbackThread != null) { }
                        else if (connections[i].connected() && 
                            (connections[i].LastVerifyTime.AddMilliseconds(m_verifyConnectionInterval) > DateTime.UtcNow || 
                             connections[i].verifyConnected()))
                        {
                            moreWork = moreWork || processConnection(connections[i]);
                        }
                        else
                        {
                            lock (connections)
                            {
                                connections.RemoveAt(i);
                                i--;
                            }
                        }
                    }

                    if (!moreWork)
                    {
                        System.Threading.Thread.Sleep(1);
                        lock (sem)
                        {
                            foreach (TcpServerConnection conn in connections)
                            {
                                if (conn.hasMoreWork())
                                {
                                    moreWork = true;
                                    break;
                                }
                            }
                        }
                        if (!moreWork)
                        {
                            waiting = true;
                            sem.WaitOne(m_idleTime);
                            waiting = false;
                        }
                    }
                }
                catch (ThreadInterruptedException) { } //thread is interrupted when we quit
                catch (Exception e)
                {
                    if (m_isOpen && OnError != null)
                    {
                        OnError(this, e);
                    }
                }
            }
        }

        private bool processConnection(TcpServerConnection conn)
        {
            bool moreWork = false;
            if (conn.processOutgoing(m_maxSendAttempts))
            {
                moreWork = true;
            }

            if (OnDataAvailable != null && activeThreads < m_maxCallbackThreads && conn.Socket.Available > 0)
            {
                lock (activeThreadsLock)
                {
                    activeThreads++;
                }
                conn.CallbackThread = new Thread(() =>
                {
                    OnDataAvailable(conn);
                });
                conn.CallbackThread.Start();
                Thread.Sleep(1);
            }
            return moreWork;
        }

        public void Open()
        {
            lock (this)
            {
                if (m_isOpen)
                {
                    //already open, no work to do
                    return;
                }
                if (m_port < 0)
                {
                    throw new Exception("Invalid port");
                }

                try
                {
                    listener.Start(5);
                }
                catch (Exception)
                {
                    listener.Stop();
                    listener = new TcpListener(IPAddress.Any, m_port);
                    listener.Start(5);
                }

                m_isOpen = true;

                listenThread = new Thread(new ThreadStart(runListener));
                listenThread.Start();

                sendThread = new Thread(new ThreadStart(runSender));
                sendThread.Start();
            }
        }

        public void Close()
        {
            if (!m_isOpen)
            {
                return;
            }

            lock (this)
            {
                m_isOpen = false;
                foreach (TcpServerConnection conn in connections)
                {
                    conn.forceDisconnect();
                }
                try
                {
                    if (listenThread.IsAlive)
                    {
                        listenThread.Interrupt();

                        Thread.Sleep(100);
                        if(listenThread.IsAlive)
                        {
                            listenThread.Abort();
                        }
                    }
                }
                catch (System.Security.SecurityException) { }
                try
                {
                    if (sendThread.IsAlive)
                    {
                        sendThread.Interrupt();

                        Thread.Sleep(100);
                        if(sendThread.IsAlive)
                        {
                            sendThread.Abort();
                        }
                    }
                }
                catch (System.Security.SecurityException) { }
            }
            listener.Stop();

            lock (connections)
            {
                connections.Clear();
            }

            listenThread = null;
            sendThread = null;
            GC.Collect();
        }

        public void Send(string data)
        {
            lock (sem)
            {
                foreach (TcpServerConnection conn in connections)
                {
                    conn.sendData(data);
                }
                Thread.Sleep(1);
                if (waiting)
                {
                    sem.Release();
                    waiting = false;
                }
            }
        }

        //
        public string ReadBuffer(int nindex = 0)
        {
            if (connections.Count > 0 && nindex >= 0 && nindex < connections.Count)
            {
                TcpClient client = connections[nindex].Socket;
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
                    string str = System.Text.Encoding.ASCII.GetString(data);
                    return str;
                }
                return null;
            }
            return null;
        }

        public bool IsConnect()
        {
            lock (connections)
            {
                return connections[0].verifyConnected();
            }
        }

    }
}
