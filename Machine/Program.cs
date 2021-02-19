using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Util;

namespace Machine
{
    public class Program
    {
        //private static LoggingUtility _log = new LoggingUtility("Log_Machine", Level.Error, 30);
        //public static LoggingUtility Log { get { return _log; } }

        //시작 Log.
        //("프로젝트명_클래스명_메서드명 상태")
        //Log.WriteInfo("DAC_Log4NetSampleCode_ErrorSample() 시작");

        //종료 Log.
        //Log.WriteInfo("DAC_Log4NetSampleCode_ErrorSample() 정상종료");

        //로그 오류
        //Log.WriteError("DAC_Log4NetSampleCode_ErrorSample() 오류", err);


        static void Main(string[] args)
        {
            Service1 service = new Service1();
            service.taskID = args[0];
            service.hostIP = args[1];
            service.hostPort = int.Parse(args[2]);
            service.Total = int.Parse(args[3]);
            service.OnStart();

            Console.ReadLine();



        }
    }
    public class Service1
    {
        LoggingUtility loggingUtility;
        TcpListener listener;
        Timer timer1;
        TcpClient tc;
        NetworkStream stream;

        LoggingUtility Log { get { return loggingUtility; } }

        public string taskID { get; set; }
        public string hostIP { get; set; }
        public int hostPort { get; set; }
        public int Total { get; set; }

        public void OnStart()
        {
            loggingUtility = LoggingUtility.GetLoggingUtility(taskID, Level.Debug, 30);

            Console.WriteLine("서비스 시작");
            Log.WriteInfo("서비스 시작");

            if (listener == null)
            {
                listener = new TcpListener(IPAddress.Parse(hostIP), hostPort);
            }

            AsyncEchoServer();
        }

        private async void AsyncEchoServer()
        {
            int time = int.Parse(ConfigurationManager.AppSettings["time"]);
            
            listener.Start();
            while (true)
            {
                tc = await listener.AcceptTcpClientAsync().ConfigureAwait(false);
                stream = tc.GetStream();

                timer1 = new Timer(time);
                timer1.Elapsed += Timer1_Elapsed;
                timer1.Enabled = true;
                timer1.AutoReset = true;
                // await Task.Factory.StartNew(AsyncTcpProcess, tc);
            }
        }
        int success = 0;
        int fail = 0;
        int process;
        //int total;
        
        //public void Total(int total)
        //{
        //    this.total = total;
        //}
        
        
        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Random rnd = new Random((int)DateTime.UtcNow.Ticks);
            int Produce = rnd.Next(0, 100);
            int percent= int.Parse(ConfigurationManager.AppSettings["percent"]);
            if (Produce < percent)
            {
                success += 1;
            }
            else
            {
                fail += 1;
            }
            process = ((success) * 100) / Total;
            string msg = $"{success}|{fail}|{process}|";

            byte[] buff = Encoding.Default.GetBytes(msg);
            stream.Write(buff, 0, buff.Length);
            //stream.Flush();
            Console.WriteLine(msg);

            if (Total <= success)
            {
                timer1.Stop();
                success = fail = 0;
                process = 0;
            }

            //50|2|1
            //string msg = $"{rnd.Next(1, 77)}|{rnd.Next(3, 5)}|{rnd.Next(0, 2)}";
            //byte[] buff = Encoding.Default.GetBytes(msg);

            //stream.Write(buff, 0, buff.Length);
            //Console.WriteLine(msg);
            //Log.WriteInfo("데이터전송: " + msg);

        }

        public void OnStop()
        {
            listener.Stop();
        }
   
    }
    
}
