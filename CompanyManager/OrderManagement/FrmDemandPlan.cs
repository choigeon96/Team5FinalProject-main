using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Util;

namespace CompanyManager
{
    public partial class FrmDemandPlan : CompanyManager.MDIBaseForm
    {
        public FrmDemandPlan()
        {
            InitializeComponent();
            SetDGV();
            dtpend.Value = dtpstart.Value.AddDays(30);

        }

        private void SetDGV()
        {
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            CommonUtil.AddGridCheckColumn(dataGridView1, "");
            CommonUtil.AddGridTextColumn(dataGridView1, "Plan_Id", "plan_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "고객사코드", "company_id", 90, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "고객사명", "company_name", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "고객주문번호", "order_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "상태", "state", 100, true, DataGridViewContentAlignment.MiddleCenter);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void FrmDemandPlan_Load(object sender, EventArgs e)
        {
            //먼저 세팅된 정보로 조회
            btnSearch.PerformClick();



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpstart.Value, dtpend.Value) > 0)
            {
                MessageBox.Show("종료일자는 시작일자보다 커야합니다.");
                return;
            }


            Service.DemandService service = new Service.DemandService();
            DataTable dt = service.GetDemandPlan(dtpstart.Value,dtpend.Value);

            var temp = from plan in dt.AsEnumerable()
                              where (plan.Field<int>("company_id").ToString().Contains(txtcompany.Text) || plan.Field<string>("company_name").ToString().Contains(txtcompany.Text))&&
                                    plan.Field<int>("plan_id").ToString().Contains(txtpaneid.Text) &&
                                    plan.Field<string>("item_id").ToString().Contains(txtSubject.Text)
                              select plan;
         

            
            
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            SetDGV();

            dataGridView1.DataSource = temp.AsDataView();

           
            


            //dataGridView2.Columns[1].Visible = false;
        }

        private void ClearAutodgvColumns(int count)
        {
           
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            int count = 0;
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && ((bool)row.Cells[0].Value))
                {
                    count++;
                }
            }

            if (count > 1)
            {
                MessageBox.Show("한개의 항목만 선택해주세요");
                return;
            }
            else if (count == 0)
            {
                MessageBox.Show("항목을 선택해주세요");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && ((bool)row.Cells[0].Value))
                {
                    
                    Service.PlanService service = new Service.PlanService();
                    int result = service.AddProductionPlan(Convert.ToInt32(row.Cells[1].Value), ((FrmMain)this.MdiParent).LoginInfo.emp_id);
                    if (result == -2)
                    {
                        MessageBox.Show("이미 생성된 생산계획입니다.");
                    }
                    else if (result == -1)
                    {
                        MessageBox.Show("납기일에 맞춰 생산계획을 생성할 수 없습니다.");
                    }
                    else if (result == -3)
                    {
                        MessageBox.Show("생산계획 생성중 오류가 발생하였습니다.");
                    }
                    else
                    {
                        btnSearch.PerformClick();
                    }

                }
            }

            

        }

        private void button12_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dataGridView1);
        }
    }
}
