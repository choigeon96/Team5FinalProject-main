using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class FrmProductionPlan : CompanyManager.MDIBaseForm
    {
        public FrmProductionPlan()
        {
            InitializeComponent();
        }

        private void FrmProductionPlan_Load(object sender, EventArgs e)
        {
            dtpend.Value = dtpstart.Value.AddDays(30);

            //콤보박스 설정
            Service.PlanService service = new Service.PlanService();
            cboPlanid.DataSource = service.GetPlan_Id();
            cboPlanid.DisplayMember = "code";

            btnSearch.PerformClick();
        }
        private void SetDGV()
        {
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.SetDGVDesign_Num(dataGridView1);
            dataGridView1.AutoGenerateColumns = true;
            CommonUtil.AddGridTextColumn(dataGridView1, "설비", "설비", 200, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dataGridView1, "공정", "공정", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품목", "품목", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품명", "품명", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품명", "item_id", 120, false, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dataGridView1, "품명", "item_name", 120, false, DataGridViewContentAlignment.MiddleCenter);
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (DateTime.Compare(dtpstart.Value, dtpend.Value) > 0)
            {
                MessageBox.Show("종료일자는 시작일자보다 커야합니다.");
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            SetDGV();

            Service.PlanService service = new Service.PlanService();
            int plan_id = cboPlanid.Text == "" ? 0 : Convert.ToInt32(cboPlanid.Text);
            DataTable dt = service.GetProductionPlan(plan_id, dtpstart.Value, dtpend.Value);

            //품목정보로 검색
            var temp = from plan in dt.AsEnumerable()
                       where (plan.Field<string>("item_id").ToString().Contains(txtitem.Text) || plan.Field<string>("item_name").ToString().Contains(txtitem.Text)) 
                       select plan;

            dataGridView1.DataSource = temp.AsDataView();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dataGridView1);
        }
    }
}
