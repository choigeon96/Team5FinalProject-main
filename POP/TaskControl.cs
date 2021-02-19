using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP
{
    public partial class TaskControl : UserControl
    {
        

        public string Task_ID { get { return lblTaskID.Text; } set { lblTaskID.Text = value; } }
        public string Task_IP { get { return lblIP.Text; } set { lblIP.Text = value; } }
        public string Task_Port { get { return lblPort.Text; } set { lblPort.Text = value; } }
        public string Task_Remark { get { return lblRemark.Text; } set { lblRemark.Text = value; } }

        int process_id = 0;

        public bool IsTaskEnable
        {
            get
            {
                return btnStop.Enabled;
            }
            set
            {
                if (value)
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    btnShow.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    btnShow.Enabled = false;
                }
            }
        }

        public TaskControl()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string server = @"C:\Users\HB\Desktop\파이널팀프\Machine\bin\Debug\Machine.exe";
            Process pro = Process.Start(server, $"{Task_ID} {Task_IP} {Task_Port}");
            process_id = pro.Id;

            //frm = new frmPLCTask(Task_ID, Task_IP, Task_Port);
            //frm.Show();
            //frm.Hide();

            IsTaskEnable = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
           // frm.Show();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //frm.bExit = true;
            //frm.Close();
            //IsTaskEnable = false;

            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id.Equals(process_id))
                { 
                    process.Kill();
                    
                }
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLogViewer log = new frmLogViewer();
            log.OpenFileName = $"Logs\\{Task_ID}.log";
            log.ShowDialog();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
