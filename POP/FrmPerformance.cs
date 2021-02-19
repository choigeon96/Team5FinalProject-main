using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;
using System.Linq;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;
using System.Reflection;

namespace POP
{
    public partial class FrmPerformance : POP.BaseForm
    {
        
        #region Initialize fields
        private int CurrentPage = 1;
        int PagesCount = 1;
        int PageRows = 5;

        private static void OpenCreateForm_POP(string taskid, string ip, string port, string Machinname, string WorkUserName, string WorkUserName_id,int AllItemNum, string WorkItem, string OrderNum , Form parent)
        {
            Size formSize = new Size(1915, 1012);

            //string appName = Assembly.GetEntryAssembly().GetName().Name;
            //Type type = Type.GetType($"{appName}.FrmAction");


            //foreach (Form form in Application.OpenForms)
            //{
            //    if (form.GetType() == type)
            //    {
            //        form.Size = formSize;
            //        form.Activate();
            //        return;
            //    }
            //}

            //FrmAction(string taskid, string ip, string port, string Machinname,string WorkUserName, int AllItemNum, string WorkItem, string OrderNum)

            FrmAction frm = new FrmAction(taskid,ip,  port,  Machinname,  WorkUserName, WorkUserName_id, AllItemNum,  WorkItem,  OrderNum);
            frm.MdiParent = parent;
            frm.Show();
            frm.Location = new Point(0, 0);
            frm.Size = formSize;
            //호출 한 뒤 parent폼의 mdichild폼 위치 재설정필요
        }


        List<WorkOrderVO> list;
        List<WorkOrderVO> list2;
        List<WorkOrderVO> list3;
        List<WorkOrderVO> Templist;
        #endregion
        public string Task_ID { get { return lblTaskID.Text; } set { lblTaskID.Text = value; } }
        public string Task_IP { get { return lblIP.Text; } set { lblIP.Text = value; } }
        public string Task_Port { get { return lblPort.Text; } set { lblPort.Text = value; } }
        public string Task_Remark { get { return lblRemark.Text; } set { lblRemark.Text = value; } }



        UserControl1 ctrl;
        public FrmPerformance()
        {
            InitializeComponent();
           
        }
        

        private void FrmInspection_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
            DataLoad();
            ComboBoxBinding();
            Control();
            PagesCount = Convert.ToInt32(Math.Ceiling(list.Count * 1.0 / PageRows));

            CurrentPage = 1;
            RefreshPagination();
            RebindGridForPageChange();


           //// dataGridView1.RowHeadersVisible = true;
           // dataGridView1.RowHeadersWidth = 200;

           // //dataGridView2.RowHeadersVisible = true;
           // dataGridView2.RowHeadersWidth = 200;

           //// dataGridView3.RowHeadersVisible = true;
           // dataGridView3.RowHeadersWidth = 200;
        }

        private void Control()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                ctrl = new UserControl1();

                ctrl.Name = $"taskControl{i}";
                ctrl.Location = new Point(0, 0);
                ctrl.Size = new Size(300, 200);

                ctrl.Task_ID = tasks[i].taskID;
                ctrl.Task_IP = tasks[i].hostIP;
                ctrl.Task_Port = tasks[i].hostPort;
                ctrl.Task_Remark = tasks[i].remark;


                ctrl.IsTaskEnable = false;
                ctrl.ControlMDI = this;

                ctrl.RouteStart += Ctrl_RouteStart;
                panel1.Controls.Add(ctrl);
            }
        }

        private void Ctrl_RouteStart(object sender, EventArgs e)
        {
            DataLoad();



        }

        List<taskItem> tasks = (List<taskItem>)ConfigurationManager.GetSection("taskList");
        //UserControl1 ctrl;
       
        private void ComboBoxBinding()
        {
            MachineService service = new MachineService();
            List<MachineVO> machine = service.GetMachine();
            machine.Insert(0, new MachineVO { machine_name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machine, "machine_id", "machine_name");
        }
        
        private void DataLoad()
        {
            WorkOrderService service1 = new WorkOrderService();
            list = service1.GetWorkOrder();
            dataGridView1.DataSource = list;

            
            list2 = service1.GetWorkOrder2();
            dataGridView2.DataSource = list2;

            
            list3 = service1.GetWorkOrder3();
            dataGridView3.DataSource = list3;
        }

        private void GetdgvColumn()
        {
            #region 작업지시
            CommonUtil.SetDGVDesign_Num1(dataGridView1);
            dataGridView1.ColumnHeadersHeight = 50;
            

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_id", 445);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목 코드", "item_id", 445);
            CommonUtil.AddGridTextColumn(dataGridView1, "계획수량", "wo_qty", 445);
            CommonUtil.AddGridTextColumn(dataGridView1, "작업지시상태", "wo_state", 445);

            CommonUtil.AddGridTextColumn(dataGridView1, "계획번호", "prod_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "wo_people", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "시작시간", "wo_start", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "종료시간", "wo_end", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "ins_emp", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "up_emp", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "machine_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView1, "번호", "machine_name", 130, false);
            
            #endregion
            #region 작업시작
            CommonUtil.SetDGVDesign_Num1(dataGridView2);
            dataGridView2.ColumnHeadersHeight = 50;
            
            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "wo_id", 445);
            CommonUtil.AddGridTextColumn(dataGridView2, "품목 코드", "item_id", 445);
            CommonUtil.AddGridTextColumn(dataGridView2, "계획수량", "wo_qty", 445);
            CommonUtil.AddGridTextColumn(dataGridView2, "작업지시상태", "wo_state", 445);

            CommonUtil.AddGridTextColumn(dataGridView2, "계획번호", "prod_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "wo_people", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "시작시간", "wo_start", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "종료시간", "wo_end", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "ins_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "ins_emp", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "up_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "up_emp", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "machine_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView2, "번호", "machine_name", 130, false);
       
            #endregion
            #region 작업종료
            CommonUtil.SetDGVDesign_Num1(dataGridView3);
            dataGridView3.ColumnHeadersHeight = 50;
            
            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "wo_id", 445);
            CommonUtil.AddGridTextColumn(dataGridView3, "품목 코드", "item_id", 445);
            CommonUtil.AddGridTextColumn(dataGridView3, "계획수량", "wo_qty", 445);
            CommonUtil.AddGridTextColumn(dataGridView3, "작업지시상태", "wo_state", 445);

            CommonUtil.AddGridTextColumn(dataGridView3, "계획번호", "prod_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "wo_people", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "시작시간", "wo_start", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "종료시간", "wo_end", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "ins_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "ins_emp", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "up_date", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "up_emp", 130, false);

            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "machine_id", 130, false);
            CommonUtil.AddGridTextColumn(dataGridView3, "번호", "machine_name", 130, false);
         
            #endregion
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                MessageBox.Show("검색기간의 설정이 잘못되었습니다.");
                return;
            }
        }
        //int i = 0;
         
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = dataGridView1.CurrentRow.Index;

            textBox1.Text = dataGridView1[0, rowIndex].Value.ToString();
            textBox2.Text = dataGridView1[4, rowIndex].Value.ToString();//4
            //textBox3.Text = dataGridView1[6, rowIndex].Value.ToString();//6
            textBox4.Text = dataGridView1[1, rowIndex].Value.ToString();//1
            textBox5.Text = dataGridView1[13, rowIndex].Value.ToString();//13
            //textBox6.Text = dataGridView1[7, rowIndex].Value.ToString();//

            textBox7.Text = dataGridView1[2, rowIndex].Value.ToString();//
            textBox8.Text = (int.Parse(textBox11.Text) + int.Parse(textBox10.Text)).ToString() ;
            textBox9.Text= (int.Parse(textBox7.Text) - int.Parse(textBox8.Text)).ToString();
           
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].taskID == dataGridView1[12, rowIndex].Value.ToString())
                {
                    lblTaskID.Text = tasks[i].taskID;
                    lblIP.Text = tasks[i].hostIP;
                    lblPort.Text = tasks[i].hostPort;
                    lblRemark.Text = tasks[i].remark;

                    foreach (var ctrl in panel1.Controls)
                    {
                        if (ctrl is  UserControl1 taskCtrl)
                        {
                            taskCtrl.Visible = false;

                            if (taskCtrl.Task_ID.Equals(tasks[i].taskID))
                            {
                                taskCtrl.Visible = true;

                                taskCtrl.AllItemNum= Convert.ToInt32(dataGridView1[2, rowIndex].Value);//총오더량
                                taskCtrl.Machinname = Convert.ToString(dataGridView1[13, rowIndex].Value);
                                taskCtrl.WorkUserName = ((FrmMain2)this.MdiParent).Name;
                                taskCtrl.WorkUserName_id = ((FrmMain2)this.MdiParent).emp_id;
                                taskCtrl.WorkItem = Convert.ToString(dataGridView1[1, rowIndex].Value);
                                taskCtrl.Order_Num = Convert.ToString(dataGridView1[0, rowIndex].Value); //지시번호
                                
                                taskCtrl.WorkState= Convert.ToString(dataGridView1[3, rowIndex].Value);//작업상태
                                
                                    
                                
                                
                            }
                        }
                    }
                }

            }
         }
        
        /// <summary>
        /// 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboMachine.Text == "전체")
            {
                var list1 = (from all in list
                             where all.wo_sdate>=dateTimePicker1.Value.AddDays(-1)&&all.wo_sdate<=dateTimePicker2.Value select all).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list1;
            }
            else
            {
                var list1 = (from all in list
                             where all.wo_sdate >= dateTimePicker1.Value.AddDays(-1) && all.wo_sdate <=dateTimePicker2.Value && all.machine_name==cboMachine.Text
                             select all).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list1;
            }
        }
        /// <summary>
        /// 오늘날짜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = DateTime.Now.AddMinutes(10);
            dateTimePicker1.Value = DateTime.Now;
            
        }

     
       

       

        private void FrmPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton ToolStripButton = ((ToolStripButton)sender);

                //Determining the current page
                if (ToolStripButton == btnBackward)
                    CurrentPage--;
                else if (ToolStripButton == btnForward)
                    CurrentPage++;
                else if (ToolStripButton == btnLast)
                    CurrentPage = PagesCount;
                else if (ToolStripButton == btnFirst)
                    CurrentPage = 1;
                else
                    CurrentPage = Convert.ToInt32(ToolStripButton.Text, CultureInfo.InvariantCulture);

                if (CurrentPage < 1)
                    CurrentPage = 1;
                else if (CurrentPage > PagesCount)
                    CurrentPage = PagesCount;

                //Rebind the Datagridview with the data.
                RebindGridForPageChange();

                //Change the pagiantions buttons according to page number
                RefreshPagination();
            }
            catch (Exception) { }
        }
        private void RefreshPagination()
        {
            ToolStripButton[] items = new ToolStripButton[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4, toolStripButton5 };

            //pageStartIndex contains the first button number of pagination.
            int pageStartIndex = 1;

            if (PagesCount > 5 && CurrentPage > 2)
                pageStartIndex = CurrentPage - 2;

            if (PagesCount > 5 && CurrentPage > PagesCount - 2)
                pageStartIndex = PagesCount - 4;

            for (int i = pageStartIndex; i < pageStartIndex + 5; i++)
            {
                if (i > PagesCount)
                {
                    items[i - pageStartIndex].Visible = false;
                }
                else
                {
                    //Changing the page numbers
                    items[i - pageStartIndex].Text = i.ToString(CultureInfo.InvariantCulture);

                    //Setting the Appearance of the page number buttons
                    if (i == CurrentPage)
                    {
                        items[i - pageStartIndex].BackColor = Color.Black;
                        items[i - pageStartIndex].ForeColor = Color.White;
                    }
                    else
                    {
                        items[i - pageStartIndex].BackColor = Color.White;
                        items[i - pageStartIndex].ForeColor = Color.Black;
                    }
                }
            }

            //Enabling or Disalbing pagination first, last, previous , next buttons
            if (CurrentPage == 1)
                btnBackward.Enabled = btnFirst.Enabled = false;
            else
                btnBackward.Enabled = btnFirst.Enabled = true;

            if (CurrentPage == PagesCount)
                btnForward.Enabled = btnLast.Enabled = false;

            else
                btnForward.Enabled = btnLast.Enabled = true;
        }
        private void RebindGridForPageChange()
        {
            //Rebinding the Datagridview with data
            int datasourcestartIndex = (CurrentPage - 1) * PageRows;
            Templist = new List<WorkOrderVO>();
            for (int i = datasourcestartIndex; i < datasourcestartIndex + PageRows; i++)
            {
                if (i >= list.Count)
                    break;

                Templist.Add(list[i]);
            }

            dataGridView1.DataSource = Templist;
            dataGridView1.Refresh();
        }
    }
}
