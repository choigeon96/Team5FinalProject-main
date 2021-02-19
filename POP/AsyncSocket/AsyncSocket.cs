using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LibSocketManager
{
    public class StateObject
    {
        private const int BUFFER_SIZE = 327680;

        private Socket worker;
        private byte[] buffer;

        public StateObject(Socket worker)
        {
            this.worker = worker;
            this.buffer = new byte[BUFFER_SIZE];
        }

        public Socket Worker
        {
            get { return this.worker; }
            set { this.worker = value; }
        }

        public byte[] Buffer
        {
            get { return this.buffer; }
            set { this.buffer = value; }
        }

        public int BufferSize
        {
            get { return BUFFER_SIZE; }
        }
    } // end of class StateObject

    /// <summary>
    /// 비동기 소켓에서 발생한 에러 처리를 위한 이벤트 Argument Class
    /// </summary>
    public class AsyncSocketErrorEventArgs : EventArgs
    {
        private readonly Exception exception;
        private readonly int id = 0;
        private readonly string strIP = "127.0.0.1:6001";

        public AsyncSocketErrorEventArgs(int id, Exception exception)
        {
            this.id = id;
            this.exception = exception;
        }

        public AsyncSocketErrorEventArgs(string strIP, Exception exception)
        {
            this.strIP = strIP;
            this.exception = exception;
        }

        public Exception AsyncSocketException
        {
            get { return this.exception; }
        }

        public int ID
        {
            get { return this.id; }
        }

        public string IP
        {
            get { return this.strIP; }
        }
    }

    /// <summary>
    /// 비동기 소켓의 연결 및 연결해제 이벤트 처리를 위한 Argument Class
    /// </summary>
    public class AsyncSocketConnectionEventArgs : EventArgs
    {
        private readonly int id = 0;

        public AsyncSocketConnectionEventArgs(int id)
        {
            this.id = id;
        }

        public int ID
        {
            get { return this.id; }
        }
    }

    /// <summary>
    /// 비동기 소캣의 데이터 전송 이벤트 처리를 위한 Argument Class
    /// </summary>
    public class AsyncSocketSendEventArgs : EventArgs
    {
        private readonly int id = 0;
        private readonly int sendBytes;

        public AsyncSocketSendEventArgs(int id, int sendBytes)
        {
            this.id = id;
            this.sendBytes = sendBytes;
        }

        public int SendBytes
        {
            get { return this.sendBytes; }
        }

        public int ID
        {
            get { return this.id; }
        }
    }

    /// <summary>
    /// 비동기 소켓의 데이터 수신 이벤트 처리를 위한 Argument Class
    /// </summary>
    public class AsyncSocketReceiveEventArgs : EventArgs
    {
        private readonly int id = 0;
        private readonly string strIP = "127.0.0.1:6001";
        private readonly int receiveBytes;
        private readonly byte[] receiveData;

        public AsyncSocketReceiveEventArgs(int id, int receiveBytes, byte[] receiveData)
        {
            this.id = id;
            this.receiveBytes = receiveBytes;
            this.receiveData = receiveData;
        }

        public AsyncSocketReceiveEventArgs(string ip, int receiveBytes, byte[] receiveData)
        {
            this.strIP = ip;
            this.receiveBytes = receiveBytes;
            this.receiveData = receiveData;
        }

        public int ReceiveBytes
        {
            get { return this.receiveBytes; }
        }

        public byte[] ReceiveData
        {
            get { return this.receiveData; }
        }

        public int ID
        {
            get { return this.id; }
        }

        public string IP
        {
            get { return this.strIP; }
        }
    }

    /// <summary>
    /// 비동기 서버의 Accept 이벤트를 위한 Argument Class
    /// </summary>
    public class AsyncSocketAcceptEventArgs : EventArgs
    {
        private readonly Socket conn;

        public AsyncSocketAcceptEventArgs(Socket conn)
        {
            this.conn = conn;
        }

        public Socket Worker
        {
            get { return this.conn; }
        }
    }

    ///
    /// delegate 정의
    /// 
    public delegate void AsyncSocketErrorEventHandler(object sender, AsyncSocketErrorEventArgs e);
    public delegate void AsyncSocketConnectEventHandler(object sender, AsyncSocketConnectionEventArgs e);
    public delegate void AsyncSocketCloseEventHandler(object sender, AsyncSocketConnectionEventArgs e);
    public delegate void AsyncSocketSendEventHandler(object sender, AsyncSocketSendEventArgs e);
    public delegate void AsyncSocketReceiveEventHandler(object sender, AsyncSocketReceiveEventArgs e);
    public delegate void AsyncSocketAcceptEventHandler(object sender, AsyncSocketAcceptEventArgs e);

    public class AsyncSocketClass
    {
        protected int id;
        protected string strIP;

        // Event Handler
        public event AsyncSocketErrorEventHandler OnError;
        public event AsyncSocketConnectEventHandler OnConnect;
        public event AsyncSocketCloseEventHandler OnClose;
        public event AsyncSocketSendEventHandler OnSend;
        public event AsyncSocketReceiveEventHandler OnReceive;
        public event AsyncSocketAcceptEventHandler OnAccept;

        public AsyncSocketClass()
        {
            this.id = -1;
        }

        public int ID
        {
            get { return this.id; }
        }

        public string IP
        {
            get { return this.strIP; }
        }

        protected virtual void ErrorOccured(AsyncSocketErrorEventArgs e)
        {
            AsyncSocketErrorEventHandler handler = OnError;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void Connected(AsyncSocketConnectionEventArgs e)
        {
            AsyncSocketConnectEventHandler handler = OnConnect;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void Closed(AsyncSocketConnectionEventArgs e)
        {
            AsyncSocketCloseEventHandler handler = OnClose;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void Sent(AsyncSocketSendEventArgs e)
        {
            AsyncSocketSendEventHandler handler = OnSend;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void Received(AsyncSocketReceiveEventArgs e)
        {
            AsyncSocketReceiveEventHandler handler = OnReceive;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void Accepted(AsyncSocketAcceptEventArgs e)
        {
            AsyncSocketAcceptEventHandler handler = OnAccept;

            if (handler != null)
                handler(this, e);
        }

    } // end of class AsyncSocketClass
}
