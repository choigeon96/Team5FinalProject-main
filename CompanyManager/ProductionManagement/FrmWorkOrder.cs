using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmWorkOrder : CompanyManager.MDIBaseForm
    {
        WorkOrderService service = new WorkOrderService();
        List<NewWorkOrderVO> list = new List<NewWorkOrderVO>();
        public FrmWorkOrder()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvWorkOrder);
            CommonUtil.SetDGVDesign(dgvWorkOrder);
            CommonUtil.SetDGVDesign_Num(dgvWorkOrder);
            dgvWorkOrder.RowHeadersVisible = true;
            CommonUtil.SetDGVDesign_CheckBox(dgvWorkOrder);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "작업지시번호", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획시작일", "wo_sdate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "지시일", "ins_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목", "item_id", 80);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품명", "item_name", 110);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비코드", "machine_id", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비명", "machine_name", 120);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "상태", "wo_state", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "wo_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "양품수량", "good_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "취소수량", "bad_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "완료(예정)일", "wo_edate", 160, true, DataGridViewContentAlignment.MiddleCenter);


        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmWorkOrder_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddMonths(1);
            BindingDGV();
            List<CodeVO> codes = service.GetCodes();
            var machines = (from machine in codes where machine.category.Equals("MACHINE") select machine).ToList();
            machines.Insert(0, new CodeVO() { code = "", name = "전체" });
            var states = (from state in codes where state.category.Equals("WO_STATE") select state).ToList();
            states.Insert(0, new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboMachine, machines, "code", "name");
            CommonUtil.BindingComboBox(cboState, states, "code", "name");
            cboDate.SelectedIndex = cboID.SelectedIndex = 0;
        }

        private void BindingDGV()
        {
            list = service.GetNewWorkOrderList(cboDate.Text, dtpFrom.Value, dtpTo.Value, false);
            dgvWorkOrder.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from wo in list
                                where
                                (
                                (txtID.Text.Length < 1 || (cboID.Text.Equals("작업/생산 ID") && wo.wo_id.Equals(Convert.ToInt32(txtID.Text)))
                                || (cboID.Text.Equals("품목 ID") && txtID.Text.Equals(wo.item_id))) &&
                                (cboState.Text.Equals("전체") || wo.wo_state.Equals(cboState.Text)) &&
                                (cboMachine.Text.Equals("전체") || cboMachine.SelectedValue.ToString().Equals(wo.machine_id))
                                )
                                select wo).ToList();
            dgvWorkOrder.DataSource = null;
            dgvWorkOrder.DataSource = searchResult;

        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            int idx = -1;
            foreach (DataGridViewRow row in dgvWorkOrder.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    idx = Convert.ToInt32(row.Cells["wo_id"].Value);
                    break;
                }
            }
            if (idx < 0)
            {
                MessageBox.Show("조회할 작업정보를 선택하십시오.");
                return;
            }

            PopupUseHistory popup = new PopupUseHistory(idx);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }

        private void dgvWorkOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvWorkOrder.Columns[e.ColumnIndex].Name.Equals("chk")) return;

            for (int i = 0; i < dgvWorkOrder.Rows.Count; i++)
            {
                if (i == e.RowIndex)
                    continue;
                ((DataGridViewCheckBoxCell)dgvWorkOrder.Rows[i].Cells["chk"]).Value = false;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvWorkOrder);
        }
    }
}
