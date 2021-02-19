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
    public partial class FrmInbound : CompanyManager.MDIBaseForm
    {
        InboundService service = new InboundService();
        List<InboundVO> list = new List<InboundVO>();
        List<InboundVO> selectedList = new List<InboundVO>();

        public FrmInbound()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvWait);
            CommonUtil.SetDGVDesign_Num(dgvWait);
            CommonUtil.SetDGVDesign_CheckBox(dgvWait);
            dgvWait.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvWait, "발주일자", "PurchasesDate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "발주상세번호", "pd_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "업체", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvWait, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvWait, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvWait, "규격", "unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "단위", "item_unit_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "검사여부", "UseCheck", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWait, "발주량", "pd_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "입고량", "InQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "잔량", "RQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWait, "납기일자", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);

            CommonUtil.SetInitGridView(dgvInbound);
            CommonUtil.SetDGVDesign_Num(dgvInbound);
            CommonUtil.SetDGVDesign_CheckBox(dgvInbound);
            dgvInbound.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvInbound, "생산번호", "prod_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주일자", "PurchasesDate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주상세번호", "pd_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "업체", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvInbound, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "규격", "unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "단위", "item_unit_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주량", "pd_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고량", "RQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "납기일자", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고일자", "InboundDate", 80, true, DataGridViewContentAlignment.MiddleCenter);

        }

        private void FrmInbound_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(14);
            GetWaitList();

            List<CodeVO> codes = service.GetInboundCodes();
            var companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0,new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            var prodIDs = (from prodID in codes where prodID.category.Equals("PROD_ID") select prodID).ToList();
            prodIDs.Insert(0,new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboProdID, prodIDs, "code", "name");
            var purchasesIDs = (from purchasesID in codes where purchasesID.category.Equals("PURCHASES_ID") select purchasesID).ToList();
            purchasesIDs.Insert(0,new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboPurchasesID, purchasesIDs, "code", "name");
        }

        private void GetWaitList()
        {
            selectedList.Clear();
            list = service.GetWaitList(dtpFrom.Value, dtpTo.Value);
            dgvWait.DataSource = list;
            dgvInbound.DataSource = null;
        }

        private void dgvWait_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            int pdID = Convert.ToInt32(dgvWait["pd_id", e.RowIndex].Value);
            if (Convert.ToBoolean(((DataGridViewCheckBoxCell)dgvWait[0, e.RowIndex]).Value))
            {
                List<InboundVO> newInbound = service.GetWaitDetail(pdID);
                newInbound.ForEach(elem => selectedList.Add(elem));
            }

            else
            {
                selectedList.RemoveAll(elem => selectedList.FindAll(element => element.pd_id == pdID).Contains(elem));
            }
            dgvInbound.DataSource = null;
            dgvInbound.DataSource = selectedList;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = new List<int>();
            for (int i = 0; i < dgvInbound.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvInbound[0, i].Value))
                    selectedRows.Add(selectedList[i].in_id);
            }

            bool result = service.InboundCommit(selectedRows);
            if (result)
            {
                MessageBox.Show("등록 성공");
                GetWaitList();
            }
            else
            {
                MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetWaitList();
            var searchResult = (from inbound in list
                                where (cboCompany.Text.Equals("전체") || inbound.company_name.Equals(cboCompany.Text)) &&
                                      (cboProdID.Text.Equals("전체") || inbound.prod_id.Equals(Convert.ToInt32(cboProdID.Text)) &&
                                      (cboPurchasesID.Text.Equals("전체") || inbound.purchase_id.Equals(cboPurchasesID.Text)) &&
                                      (txtItem.Text.Length < 1 || inbound.item_id.Equals(txtItem.Text) || inbound.item_name.Contains(txtItem.Text)))
                                select inbound
                                      ).ToList();
            dgvWait.DataSource = null;
            dgvWait.DataSource = searchResult;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvWait);
        }
    }
}
