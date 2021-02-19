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
    public partial class FrmInboundState : CompanyManager.MDIBaseForm
    {
        InboundService service = new InboundService();
        List<InboundVO> list = new List<InboundVO>();
        List<CodeVO> codes = new List<CodeVO>();
        List<int> selectedIdx= new List<int>();
        public FrmInboundState()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvInbound);
            CommonUtil.SetDGVDesign_Num(dgvInbound);
            CommonUtil.SetDGVDesign_CheckBox(dgvInbound);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고번호", "in_id", 60);
            CommonUtil.AddGridTextColumn(dgvInbound, "pd_id", "purchase_id", 60);
            CommonUtil.AddGridTextColumn(dgvInbound, "업체", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "품목", "item_id", 110);
            CommonUtil.AddGridTextColumn(dgvInbound, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "단위", "unit", 100);
            CommonUtil.AddGridTextColumn(dgvInbound, "검사여부", "UseCheck", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주량", "pd_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "취소량", "CQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고량", "InQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고창고", "in_warehouse", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주일자", "PurchasesDate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고일자", "ins_date", 80, true, DataGridViewContentAlignment.MiddleCenter);



        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmInboundState_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
            BindingInboundList();
            BindingComboBox();
        }

        private void BindingInboundList()
        {
            (list, codes) = service.GetInboundList(dtpFrom.Value, dtpTo.Value.AddDays(1));
            dgvInbound.DataSource = list;
            selectedIdx.Clear();
        }

        private void BindingComboBox()
        {
            var companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "전체" });
            var warehouses = (from warehouse in codes where warehouse.category.Equals("WAREHOUSE") select warehouse).ToList();
            warehouses.Insert(0, new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            CommonUtil.BindingComboBox(cboWareHouse, warehouses, "code", "name");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingInboundList();
            var searchResult = (from inbound in list
                                where
                                (cboCompany.Text.Equals("전체")) || inbound.company_name.Equals(cboCompany.Text) &&
                                (cboWareHouse.Text.Equals("전체") || inbound.in_warehouse.Equals(cboWareHouse.Text)) &&
                                (txtInboundID.Text.Length < 1 || inbound.in_id.Equals(Convert.ToInt32(txtInboundID.Text))) &&
                                (txtPurchasesID.Text.Length < 1 || inbound.purchase_id.Equals(Convert.ToInt32(txtPurchasesID.Text))) &&
                                (txtItem.Text.Length < 1 || inbound.item_id.Equals(Convert.ToInt32(txtItem.Text)) || inbound.item_name.Contains(txtItem.Text))
                                select inbound).ToList();
            dgvInbound.DataSource = searchResult;
            BindingComboBox();


        }

        private void dgvInbound_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            if (Convert.ToBoolean(((DataGridViewCheckBoxCell)dgvInbound[0, e.RowIndex]).Value))
            {
                int idx = list.FindIndex(elem => elem.in_id == Convert.ToInt32(dgvInbound.Rows[e.RowIndex].Cells["in_id"].Value));
                if (idx == -1)
                    return;
                PopupInboundCancel popup = new PopupInboundCancel(list[idx].InQty - list[idx].CQty);
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    list[idx].CQty += Convert.ToInt32(popup.CancelQty);
                    selectedIdx.Add(list[idx].in_id);
                    dgvInbound.DataSource = null;
                    dgvInbound.DataSource = list;

                    foreach (DataGridViewRow row in dgvInbound.Rows)
                    {
                        if(selectedIdx.Contains(Convert.ToInt32(row.Cells["in_id"].Value)))
                        ((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
                    }
                }
                else
                {
                    ((DataGridViewCheckBoxCell)dgvInbound[0, e.RowIndex]).Value = false;
                    selectedIdx.Remove(idx);
                    return;
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<InboundVO> changedList = list.FindAll(elem => selectedIdx.Contains(elem.in_id));
            if (changedList.Count < 1)
            {
                MessageBox.Show("저장할 내용이 없습니다.");
                return;
            }

            bool result = service.InboundCancel(changedList);
            if (result)
            {
                MessageBox.Show("취소 성공");
                BindingInboundList();
                BindingComboBox();

            }
            else
            {
                MessageBox.Show("취소중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvInbound);
        }
    }
}
