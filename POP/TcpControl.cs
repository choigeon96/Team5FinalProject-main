using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POP
{
    public class TcpControl
    {
        public TcpClient client;
        public NetworkStream dataStream;

        public TcpControl(string host, int port)
        {
            client = new TcpClient(host, port);
            dataStream = client.GetStream();
        }

        public bool Send(byte[] data)
        {
            try
            {
                dataStream.Write(data, 0, data.Length);
                dataStream.Flush();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine($"[{MethodBase.GetCurrentMethod().Name}] : {err.Message}");
                return false;
            }
        }

        /// <summary>
        /// 접속상태 체크
        /// </summary>
        /// <returns></returns>
        public bool CheckClientConnection()
        {
            bool bStatus = false;
            try
            {
                if (client != null && client.Client != null && client.Client.Connected)
                {
                    if (client.Client.Available == 0
                         && client.Client.Poll(2000, SelectMode.SelectRead))
                        bStatus = false;
                    else
                        bStatus = true;
                }

                return bStatus;
            }
            catch
            {
                return false;
            }
        }
    }
}
