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
    public partial class FrmDispend : CompanyManager.MDIBaseForm
    {
        DispendService service = new DispendService();
        List<DispendVO> list = new List<DispendVO>();

        public FrmDispend()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvDispend);
            CommonUtil.SetDGVDesign_Num(dgvDispend);
            CommonUtil.SetDGVDesign_CheckBox(dgvDispend);
            dgvDispend.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvDispend, "작업지시ID", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청일", "ins_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "품목", "item_id", 120);
            CommonUtil.AddGridTextColumn(dgvDispend, "품명", "item_name", 140);
            CommonUtil.AddGridTextColumn(dgvDispend, "단위", "item_unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "품목유형", "item_type", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청창고", "to_warehouse_id", 120);
            CommonUtil.AddGridTextColumn(dgvDispend, "불출창고", "from_warehouse_id", 120);
            CommonUtil.AddGridTextColumn(dgvDispend, "현재고", "stock", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청수량", "mr_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDispend, "상태", "mr_state", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "자재불출번호", "mr_id", 10, false);


        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDispend_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(30);

            BindingDGV();
            List<CodeVO> codes = service.GetDispendCode();

            var whs = (from wh in codes where wh.category.Equals("WAREHOUSE") || wh.category.Equals("ALL") select wh).ToList();
            CommonUtil.BindingComboBox(cboWarehouse, whs, "code", "name");
            var machines = (from machine in codes where machine.category.Equals("MACHINE") || machine.category.Equals("ALL") select machine).ToList();
            CommonUtil.BindingComboBox(cboMachine, machines, "code", "name");
            var states = (from state in codes where state.category.Equals("MR_STATE") || state.category.Equals("ALL") select state).ToList();
            CommonUtil.BindingComboBox(cboState, states, "code", "name");
            cboStock.SelectedIndex = 0;

        }

        private void BindingDGV()
        {
            list = service.GetDispendList(dtpFrom.Value, dtpTo.Value);
            dgvDispend.DataSource = null;
            dgvDispend.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();

            var searchResult = (from item in list
                                where
                                (
                                (cboMachine.Text.Equals("전체") || item.from_warehouse_id.Equals(cboWarehouse.Text)) &&
                                (txtItem.Text.Length < 1 || item.item_id.Equals(txtItem.Text) || item.item_name.Contains(txtItem.Text)) &&
                                (txtWoID.Text.Length < 1 || item.wo_id.Equals(Convert.ToInt32(txtWoID.Text))) &&
                                (cboMachine.Text.Equals("전체") || item.machine_name.Equals(cboMachine.Text)) &&
                                (cboState.Text.Equals("전체") || item.mr_state.Equals(cboState.Text)) &&
                                (cboStock.Text.Equals("전체") || (cboStock.Text.Equals("가능") && (item.stock - item.mr_qty >= 0)) || (cboStock.Text.Equals("불가능") && (item.stock - item.mr_qty < 0)))
                                )
                                select item).ToList();
            dgvDispend.DataSource = null;
            dgvDispend.DataSource = searchResult;

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "V")
            {
                btnDown.Text = "ᐱ";
                int size = this.Size.Height;
                btnDown.Location = new Point(btnDown.Location.X, 71);
                btnSearch.Location = new Point(btnSearch.Location.X, 70);



                pnlSearch.Size = new Size(pnlSearch.Size.Width, 114);
                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance + 38;

            }
            else
            {
                btnDown.Text = "V";

                btnDown.Location = new Point(btnDown.Location.X, 38);
                btnSearch.Location = new Point(btnSearch.Location.X, 37);
                pnlSearch.Size = new Size(pnlSearch.Size.Width, pnlSearch.Size.Height * 2 / 3);


                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance - 38;
            }
        }

        private void btnOutbound_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = new List<int>();
            foreach (DataGridViewRow item in dgvDispend.Rows)
            {
                if (Convert.ToBoolean(item.Cells[0].Value))
                    selectedRows.Add(Convert.ToInt32(item.Cells["mr_id"].Value));
            }
            if (selectedRows.Count < 1)
            {
                MessageBox.Show("자재불출할 내용을 선택해주십시오.");
                return;
            }
            bool result = service.MetarialRelease(selectedRows,((FrmMain)this.MdiParent).LoginInfo.emp_id);
            if (result)
            {
                MessageBox.Show("불출 완료");
                BindingDGV();
            }
            else
            {
                MessageBox.Show("처리중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");
                return;
            }
        }

        private void dgvDispend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            if (Convert.ToInt32(dgvDispend["stock", e.RowIndex].Value) - Convert.ToInt32(dgvDispend["mr_qty", e.RowIndex].Value) < 0)
            {
                MessageBox.Show("재고가 부족하여 선택할 수 없습니다.");
                ((DataGridViewCheckBoxCell)dgvDispend[0, e.RowIndex]).Value = false;
            }
            if(dgvDispend["mr_state",e.RowIndex].Value.ToString().Equals("완료"))
            {
                MessageBox.Show("완료된 불출요청은 선택할 수 없습니다.");
                ((DataGridViewCheckBoxCell)dgvDispend[0, e.RowIndex]).Value = false;
            }
        }

        private void btxExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvDispend);
        }
    }
}
