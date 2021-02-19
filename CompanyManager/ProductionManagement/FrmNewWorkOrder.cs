using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using Service;
using VO;
using System.Linq;

namespace CompanyManager
{

    public partial class FrmNewWorkOrder : CompanyManager.MDIBaseForm
    {
        WorkOrderService service = new WorkOrderService();
        List<NewWorkOrderVO> list = new List<NewWorkOrderVO>();
        public FrmNewWorkOrder()
        {
            InitializeComponent();



            CommonUtil.SetInitGridView(dgvWorkOrder);
            CommonUtil.SetDGVDesign_Num(dgvWorkOrder);
            CommonUtil.SetDGVDesign_CheckBox(dgvWorkOrder);
            CommonUtil.AddGridImageColumn(dgvWorkOrder, Properties.Resources.Edit_16x16, "Edit", 40);

            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품명", "item_name", 130);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "상태", "wo_state", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비코드", "machine_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비명", "machine_name", 120);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획수량", "plan_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "wo_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획시작일", "wo_sdate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "등록사유", "wo_comment", 80);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "소요시간", "taketime", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획완료일", "wo_edate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "작업지시번호", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FrmNewWorkOrder_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = dtpFrom.Value.AddDays(30);
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
            list = service.GetNewWorkOrderList(cboDate.Text, dtpFrom.Value, dtpTo.Value);
            dgvWorkOrder.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from wo in list
                                where
                                (txtID.Text.Length < 1 || (cboID.Text.Equals("품목 ID") && wo.item_id.Equals(txtID.Text))|| (cboID.Text.Equals("작업/생산 ID") && wo.wo_id.Equals(txtID.Text))) &&
                                (cboMachine.Text.Equals("전체") || wo.machine_id.Equals(cboMachine.SelectedValue.ToString())) &&
                                (cboState.Text.Equals("전체") || wo.wo_state.Equals(cboState.Text))
                                select wo).ToList();
            dgvWorkOrder.DataSource = null;
            dgvWorkOrder.DataSource = searchResult;

        }

        private void dgvWorkOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 1) return;
            NewWorkOrderVO selectedWO = list.Find(elem => elem.wo_id == Convert.ToInt32(dgvWorkOrder["wo_id", e.RowIndex].Value));
            //if (selectedWO.wo_sdate < DateTime.Now)
            //{
            //    MessageBox.Show("시작된 작업지시는 수정할 수 없습니다.");
            //    return;
            //}
            PopupNewWorkOrder popup = new PopupNewWorkOrder(selectedWO);
            if (popup.ShowDialog() == DialogResult.OK)
            {
                BindingDGV();
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = new List<int>();
            for (int i = 0; i < dgvWorkOrder.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvWorkOrder[0, i].Value))
                {
                    if (!(dgvWorkOrder["wo_state", i].Value.ToString().Equals("작업생성")))
                    {
                        MessageBox.Show("확정된 작업지시는 재확정 할 수 없습니다.");
                        return;
                    }
                    selectedRows.Add(Convert.ToInt32(dgvWorkOrder["wo_id", i].Value));
                }
            }
            if (selectedRows.Count < 1)
            {
                MessageBox.Show("확정할 작업을 선택해 주십시오.");
                return;
            }
            bool result = service.CommitWorkOrder(selectedRows, ((FrmMain)this.MdiParent).LoginInfo.emp_id);

            if (result)
            {
                MessageBox.Show("확정 성공");
                btnSearch.PerformClick();
            }
            else
                MessageBox.Show("확정중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
        }

        private void btnRegWO_Click(object sender, EventArgs e)
        {
            PopupNewWorkOrder popup = new PopupNewWorkOrder(((FrmMain)this.MdiParent).LoginInfo.emp_id);
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                BindingDGV();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {


            List<int> selectedRows = new List<int>();
            for (int i = 0; i < dgvWorkOrder.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvWorkOrder[0, i].Value))
                {
                    if (Convert.ToDateTime(dgvWorkOrder["wo_sdate", i].Value) < DateTime.Now)
                    {
                        MessageBox.Show("시작된 작업지시는 삭제 할 수 없습니다.");
                        return;
                    }
                    selectedRows.Add(Convert.ToInt32(dgvWorkOrder["wo_id", i].Value));
                }
            }
            if (selectedRows.Count < 1)
            {
                MessageBox.Show("삭제할 작업을 선택해 주십시오.");
                return;
            }
            if (!(MessageBox.Show("정말 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.OKCancel) == DialogResult.OK))
                return;
            bool result = service.DeleteWorkOrder(selectedRows);

            if (result)
            {
                MessageBox.Show("삭제 성공");
                btnSearch.PerformClick();
            }
            else
                MessageBox.Show("삭제중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvWorkOrder);
        }
    }
}
