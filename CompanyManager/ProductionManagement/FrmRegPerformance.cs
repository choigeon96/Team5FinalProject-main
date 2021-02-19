using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;
using Service;
using System.Linq;

namespace CompanyManager
{
    public partial class FrmRegPerformance : CompanyManager.MDIBaseForm
    {
        PerformanceService service = new PerformanceService();
        List<PerformanceVO> list = new List<PerformanceVO>();
        public FrmRegPerformance()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvPerformance);
            CommonUtil.SetDGVDesign_Num(dgvPerformance);
            CommonUtil.AddGridCheckColumn(dgvPerformance, "");
            CommonUtil.AddGridTextColumn(dgvPerformance, "실적번호", "performance_id", 80, false, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "작업지시ID", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "계획일", "wo_sdate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "설비", "machine_id", 100);
            CommonUtil.AddGridTextColumn(dgvPerformance, "설비명", "machine_name", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvPerformance, "품목명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvPerformance, "상태", "wo_state", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPerformance, "양품창고", "good_wh", 80);
            CommonUtil.AddGridTextColumn(dgvPerformance, "불량창고", "bad_wh", 80);
            CommonUtil.AddGridTextColumn(dgvPerformance, "지시수량", "wo_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPerformance, "양품수량", "performance_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPerformance, "잔량", "Rqty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPerformance, "확정여부", "p_state", 60, true, DataGridViewContentAlignment.MiddleCenter);

            List<CodeVO> codes = service.GetAllCodes();
            var emps = (from emp in codes where emp.category.Equals("EMPLOYEE") || emp.category.Equals("ALL") select emp).ToList();
            CommonUtil.BindingComboBox(cboEmployee, emps, "code", "name");
            var machines = (from machine in codes where machine.category.Equals("MACHINE") || machine.category.Equals("ALL") select machine).ToList();
            CommonUtil.BindingComboBox(cboMachine, machines, "code", "name");
            var states = (from state in codes where state.category.Equals("WO_STATE") || state.category.Equals("ALL") select state).ToList();
            CommonUtil.BindingComboBox(cboState, states, "code", "name");

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    

        private void FrmRegPerformance_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddMonths(1);
            BindingDGV();
        }

        private void BindingDGV()
        {
            list = service.GetPerformanceList(dtpFrom.Value, dtpTo.Value);
            dgvPerformance.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();

            var searchResult = (from performance in list
                                where
                                (
                                 (cboState.Text.Equals("전체") || performance.wo_state.Equals(cboState.Text)) &&
                                 (cboEmployee.Text.Equals("전체") || performance.ins_emp.Equals(cboEmployee.Text)) &&
                                 (cboMachine.Text.Equals("전체") || performance.machine_id.Equals(cboMachine.SelectedValue.ToString())) &&
                                 (txtID.Text.Length < 1 || (cboID.Text.Contains("WO") && performance.wo_id.Equals(Convert.ToInt32(txtID.Text))))
                                )
                                select performance).ToList();

            dgvPerformance.DataSource = null;
            dgvPerformance.DataSource = searchResult;
           
            
        }

        private void btnRegPerformance_Click(object sender, EventArgs e)
        {
            List<int> selectedIDs = new List<int>();
            foreach (DataGridViewRow row in dgvPerformance.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value)&&row.Cells["p_state"].Value.ToString().Equals("대기"))
                    selectedIDs.Add(Convert.ToInt32(row.Cells["performance_id"].Value));
            }

            if (selectedIDs.Count < 1)
            {
                MessageBox.Show("실적 등록할 내용을 선택하십시오.");
                return;
            }
            bool result =  service.PerformanceCommit(selectedIDs,((FrmMain)this.MdiParent).LoginInfo.emp_id);
            if (result)
            {
                MessageBox.Show("실적 등록 성공");
                BindingDGV();
            }
            else
                MessageBox.Show("실적 등록에 실패하였습니다.\r\n다시 시도하여 주십시오.");
        }

        private void dgvPerformance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dgvPerformance["p_state", e.RowIndex].Value.ToString().Equals("확정"))
            {
                MessageBox.Show("이미 확정된 실적입니다.");
                ((DataGridViewCheckBoxCell)dgvPerformance[0, e.RowIndex]).Value = false;
            }
        }
    }
}
