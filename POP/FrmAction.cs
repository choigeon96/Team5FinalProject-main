using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Net;
using log4net.Core;
using Machine;
using Service;
using VO;

namespace POP
{
    public partial class FrmAction : POP.BaseForm
    {//
        TcpControl client;
        NetworkStream recvData;
        SqlConnection conn;

        string hostIP;
        int hostPort;
        int taskID;
        string pgmID;

        bool logVisible = true;
        string clientName;
        string clientIP;

        public bool bExit = false;

        LoggingUtility _logging;
        public LoggingUtility Log { get { return _logging; } }
       

        ThreadPLCTask m_thread;
        int timer_CONNECT = 300;
        int timer_KEEP_ALIVE = 300;
        int timer_READ_PLC = 300;
        
        public FrmAction(string taskid, string ip, string port, string Machinname,string WorkUserName,string WorkUserName_id ,int AllItemNum, string WorkItem, string OrderNum)
        {
            InitializeComponent();
            textBox5.Text = Machinname;//머신네임
            textBox21.Text = AllItemNum.ToString();//총오더량
            textBox10.Text = OrderNum;//지시번호
            textBox11.Text = WorkUserName;//작업자
            textBox6.Text = WorkUserName_id;//작업자id
            textBox9.Text = WorkItem;//작업물건
            hostIP = ip;
            hostPort = int.Parse(port);
            //taskID = int.Parse(taskid.Replace("PLC_", ""));
            pgmID = taskid;

            _logging = new LoggingUtility(pgmID, Level.Debug, 30);

            timer_CONNECT = timer_Connects.Interval = int.Parse(ConfigurationManager.AppSettings["timer_Connect"]);
            timer_KEEP_ALIVE = int.Parse(ConfigurationManager.AppSettings["timer_KeepAlive"]);
            timer_READ_PLC = int.Parse(ConfigurationManager.AppSettings["timer_R_PLC"]);

            lblIP.Text = hostIP;
            lblPort.Text = hostPort.ToString();
            this.Text = textBox7.Text = taskid;

            Assembly assembly = Assembly.GetExecutingAssembly();
            lblVersion.Text = File.GetLastWriteTime(assembly.Location).ToString("yyyy.MM.dd");

            clientName = Dns.GetHostName();

            IPAddress[] locals = Dns.GetHostAddresses(clientName);
            if (locals.Length > 0)
            {
                clientIP = locals[1].ToString();
            }
        }

        public int process_id { get; set; }
        private void FrmAction_Load(object sender, EventArgs e)
        {

            button1.Enabled = false;
            button4.Enabled = false;
           

          
                

            try
            {
                Log.WriteInfo("DB서버 연결");

                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                conn.Open();

                m_thread = new ThreadPLCTask(conn, _logging, taskID, hostIP, hostPort, timer_CONNECT, timer_KEEP_ALIVE, timer_READ_PLC, clientName, clientIP);
                m_thread.ReadData += M_thread_ReadData;
                m_thread.ThreadStart();

                timer_Connects.Start();
            }
            catch (Exception err)
            {
                Log.WriteError("DB접속 실패:" + err.Message);
            }



        }
        /// <summary>
        /// 데이터를 수신받았을때 UI 컨트롤에 데이터 표현
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void M_thread_ReadData(object sender, ReadDataEventArgs args)
        {
            string info = args.Data;
            string[] arrData1 = info.Split('|');
            Log.WriteInfo($"성공 : {arrData1[0]}, 실패 : {arrData1[1]}, 진행률 {arrData1[2]}%");

            if (logVisible)
            {
                //if (listBox1.Items.Count > 50)
                //    listBox1.Items.Clear();

                //this.Invoke((MethodInvoker)(() => listBox1.Items.Add($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {args.Data}")));
               // this.Invoke((MethodInvoker)(() => listBox1.SelectedIndex = listBox1.Items.Count - 1));
            }
            
            this.Invoke((MethodInvoker)(() =>      txtReadPLC.Text = args.Data         ));
            this.Invoke(new Action(() =>
            {
                textBox27.Text = arrData1[0];
                textBox39.Text = arrData1[1];
                textBox17.Text = (int.Parse(arrData1[0]) + int.Parse(arrData1[1])).ToString();
                textBox14.Text = (int.Parse(textBox21.Text) - int.Parse(textBox27.Text)).ToString();

                progressBar1.Value = int.Parse(arrData1[2]);
                if(progressBar1.Value == 100)
                {
                    button3.PerformClick();
                }

               
                }));
        }



        private void FrmAction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bExit)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void FrmAction_FormClosed(object sender, FormClosedEventArgs e)
        {
            //로그 레퍼지토리 삭제
            Log.RemoveRepository(pgmID);

            //DB접속 종료
            conn.Close();

            //소켓 종료
            m_thread.ThreadStop();
        }




        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }
        
        //작업중지
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
            
            //timer_Connects.Stop();
            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id.Equals(process_id))
                {
                    process.Kill();

                }
            }
        }
        //작업다시시작
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
            
           
        }

        private void lblVersion_Click(object sender, EventArgs e)
        {

        }

      
        /// <summary>
        /// 기계와의 연결상태에 따라서 UI 컨트롤에 표시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Connects_Tick(object sender, EventArgs e)
        {
            try
            {
                if (m_thread.Connection)
                {
                    lblState.BackColor = Color.Green;
                }
                else
                {
                    lblState.BackColor = Color.Red;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            //CheckVO check = new CheckVO();
            //check.item_id = textBox9.Text;
            //check.ch_qty = int.Parse(textBox21.Text);
            //check.good_qty = int.Parse(textBox27.Text);
            //check.bad_qty = int.Parse(textBox39.Text);
            //check.emp = textBox11.Text;



            //CheckService service = new CheckService();
            //int ch_id = service.GetChID(check);



            PerformanceVO performance = new PerformanceVO();
            performance.wo_id = int.Parse(textBox10.Text);
            performance.item_id = textBox9.Text;
            //performance.ch_id = ch_id;
            performance.performance_qty = int.Parse(textBox27.Text);
            performance.bad_qty= int.Parse(textBox39.Text);

            performance.ins_emp = textBox6.Text;

            PerformanceService service1 = new PerformanceService();
            bool bFlag = service1.PerformanceCommit2(performance);
            if (bFlag)
            {
                //WorkOrderService service2 = new WorkOrderService();
                //service1.EndWorkOrder(Convert.ToInt32(Order_Num), WorkUserName);

            }
            else
            {
                //실패
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
