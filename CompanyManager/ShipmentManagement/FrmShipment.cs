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
    public partial class FrmShipment : CompanyManager.MDIBaseForm
    {
        List<ShipmentVO> list = new List<ShipmentVO>();
        ShipmentService service = new ShipmentService();
        public FrmShipment()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvShipment);
            CommonUtil.SetDGVDesign_Num(dgvShipment);
            CommonUtil.SetDGVDesign_CheckBox(dgvShipment);
            dgvShipment.RowHeadersVisible = false;
            CommonUtil.AddGridTextColumn(dgvShipment, "SO ID", "so_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객주문번호", "order_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "납기일", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "수요계획번호", "plan_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객사코드", "company_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객사", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "도착지", "DestinationName", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvShipment, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "주문수량", "Qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하수량", "SQty", 60, true, DataGridViewContentAlignment.MiddleRight);


        }

        private void FrmShipment_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddMonths(1);
            BindingDGV();
            List<CodeVO> codes = service.GetShipmentCodes();
            var froms = (from wh in codes where new List<string> { "ALL", "FROM" }.Contains(wh.category) select wh).ToList();
            CommonUtil.BindingComboBox(cboWarehouse, froms, "code", "name");
            var tos = (from wh in codes where new List<string> { "ALL", "TO" }.Contains(wh.category) select wh).ToList();
            CommonUtil.BindingComboBox(cboDest, tos, "code", "name");
            var companys = (from company in codes where new List<string> { "ALL", "COMPANY" }.Contains(company.category) select company).ToList();
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
        }

        private void BindingDGV()
        {
            list = service.GetTargetList(dtpFrom.Value, dtpTo.Value);
            dgvShipment.DataSource = null;
            dgvShipment.DataSource = list;
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

        private void btxExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvShipment);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from vo in list
                                where
                                (
                                (cboCompany.Text.Equals("전체") || vo.company_id.Equals(Convert.ToInt32(cboCompany.SelectedValue))) &&
                                (cboDest.Text.Equals("전체") || vo.DestinationID.Equals(Convert.ToInt32(cboDest.SelectedValue))) &&
                                (cboWarehouse.Text.Equals("전체") || vo.out_warehouse.Equals(Convert.ToInt32(cboWarehouse.SelectedValue))) &&
                                (txtItem.Text.Length < 1 || vo.item_id.Equals(txtItem.Text) || vo.item_name.Contains(txtItem.Text)) &&
                                (txtWOID.Text.Length < 1 || vo.order_id.Equals(txtWOID.Text)) &&
                                (txtSOID.Text.Length < 1 || vo.so_id.Equals(txtSOID.Text))
                                )
                                select vo).ToList();
            dgvShipment.DataSource = null;
            dgvShipment.DataSource = searchResult;
        }




        private void NumericCheck(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void dgvShipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            ShipmentVO vo = list.Find(elem => elem.so_id.Equals(Convert.ToInt32(dgvShipment.Rows[e.RowIndex].Cells["so_id"].Value)));
            int totQty = 0;
            foreach (DataGridViewRow row in dgvShipment.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) && row.Cells["item_id"].Value.ToString().Equals(vo.item_id))
                    totQty += Convert.ToInt32(row.Cells["Qty"].Value);
            }
            if (totQty > vo.RQty)
            {
                MessageBox.Show("재고가 부족하여 선택할 수 없습니다.");
                ((DataGridViewCheckBoxCell)dgvShipment[0, e.RowIndex]).Value = false;
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            List<ShipmentVO> selectedRows = new List<ShipmentVO>();
            foreach (DataGridViewRow row in dgvShipment.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                    selectedRows.Add(list.Find(elem => elem.so_id.Equals(Convert.ToInt32(row.Cells["so_id"].Value))));

            }
            if (selectedRows.Count < 1)
            {
                MessageBox.Show("출하할 항목을 선택하십시오.");
                return;
            }

            bool result = service.RegShipment(selectedRows, ((FrmMain)this.MdiParent).LoginInfo.emp_id);

            if (result)
            {
                MessageBox.Show("등록 성공");
                BindingDGV();
                return;
            }
            MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");
        }
    }
}
