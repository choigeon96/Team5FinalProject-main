using Machine;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;

namespace POP
{
    public partial class UserControl1 : UserControl
    {
        //FrmAction frm;

        public event EventHandler RouteStart;

        public FrmPerformance ControlMDI { get; set; }
        public FrmAction Frm { get; set; }
        
        public string Task_ID { get { return lblTaskID.Text; } set { lblTaskID.Text = value; } }
        public string Task_IP { get { return lblIP.Text; } set { lblIP.Text = value; } }
        public string Task_Port { get { return lblPort.Text; } set { lblPort.Text = value; } }
        public string Task_Remark { get { return lblRemark.Text; } set { lblRemark.Text = value; } }
        public string Order_Num { get { return lblOrderNum.Text; } set { lblOrderNum.Text = value; } }//지시번호
        public string Machinname { get; set; }//머신네임
        public int AllItemNum { get; set; }//총오더량
        public string WorkUserName { get; set; }//작업자
        public string WorkUserName_id { get; set; }//작업자id
        public string WorkItem { get; set; }//작업아이템

        public string WorkState { get; set; }//작업상태

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

        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
            string server = ConfigurationManager.AppSettings["MachineEXE"];
            
            Process pro = Process.Start(server, $"{Task_ID} {Task_IP} {Task_Port} {AllItemNum}");
            process_id = pro.Id;

            //F_ASSY
            //H_ASSY_01
            //MF01
            //MF02
            //OS"

            Frm = new FrmAction(Task_ID, Task_IP, Task_Port, Machinname, WorkUserName, WorkUserName_id, AllItemNum, WorkItem, Order_Num);
            Frm.MdiParent = ControlMDI.ParentForm;
            Frm.Location = new Point(0, 0);
            Frm.process_id = pro.Id;
            Frm.Show();
            Frm.Hide();
            MachineService service = new MachineService();
            Runid= service.MachineRun(Task_ID, WorkUserName_id);
            if(Runid>0)
            {
                WorkOrderService service1 = new WorkOrderService();
                service1.StartWorkOrder(Convert.ToInt32(Order_Num), WorkUserName_id);
                RouteStart(sender, null);

            }
            else
            {

            }
            IsTaskEnable = true;

            

        }
        int Runid;
        private void btnShow_Click(object sender, EventArgs e)
        {
            //Frm.MdiParent = ControlMDI.ParentForm;
            Frm.Show();
            Frm.Activate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Frm.bExit = true;
            Frm.Close();
            IsTaskEnable = false;

            foreach (Process process in Process.GetProcesses())
            {
                if (process.Id.Equals(process_id))
                {
                    process.Kill();

                }
            }
            MachineService service = new MachineService();
            bool bFlag = service.MachineEnd(Runid, WorkUserName_id);
            if(bFlag)
            {
                WorkOrderService service1 = new WorkOrderService();
                service1.EndWorkOrder(Convert.ToInt32(Order_Num), WorkUserName_id);
                RouteStart(sender, null);
            }
            else
            {

            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            frmLogViewer log = new frmLogViewer();
            log.OpenFileName = $"Logs\\{Task_ID}.log";
            log.ShowDialog();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
          
        }

        private void UserControl1_VisibleChanged(object sender, EventArgs e)
        {

            //if (WorkState == "작업종료")
            //{
            //    btnStart.Enabled = false;
            //}
        }
    }
}
