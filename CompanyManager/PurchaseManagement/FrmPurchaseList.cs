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
using DevExpress.XtraReports.UI;

namespace CompanyManager
{
    public partial class FrmPurchaseList : CompanyManager.MDIBaseForm
    {
        PurchaseService service = new PurchaseService();
        List<PurchasesListVO> list = new List<PurchasesListVO>();
        public FrmPurchaseList()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvPurchases);
            CommonUtil.SetDGVDesign_Num(dgvPurchases);
            CommonUtil.AddGridCheckColumn(dgvPurchases, "chk");
            dgvPurchases.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주번호", "purchase_id", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "업체명", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주상태", "purchase_state", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "품목", "item_id", 120);
            CommonUtil.AddGridTextColumn(dgvPurchases, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvPurchases, "단위", "unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "납기일", "due_date", 90, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주량", "pd_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "입고량", "in_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "취소량", "in_cqty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "취소가능량", "Cancellable", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주일", "ins_date", 90,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "pd_id", "pd_id", 90,false);

        }

        private void FrmPurchaseList_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            //dtpFrom.Value = DateTime.Now;
            dtpTo.Value = dtpFrom.Value.AddMonths(1);
            GetPurchasesList();

            List<CodeVO> codes = service.GetAllCodes();
            var companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "전체" });
            var states = (from state in codes where state.category.Equals("PURCHASES_STATE") select state).ToList();
            states.Insert(0, new CodeVO() { code = "", name = "전체" });
            var purchaseIDs = (from warehouse in codes where warehouse.category.Equals("PURCHASES_ID") select warehouse).ToList();
            purchaseIDs.Insert(0, new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            //CommonUtil.BindingComboBox(cboItem, items, "code", "name");
            CommonUtil.BindingComboBox(cboState, states, "code", "name");
            CommonUtil.BindingComboBox(cboPurchaseID, purchaseIDs, "code", "name");

        }

        private void GetPurchasesList()
        {
            list = service.GetPurchasesList(dtpFrom.Value, dtpTo.Value);
            dgvPurchases.DataSource = list;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            list = service.GetPurchasesList(dtpFrom.Value, dtpTo.Value);

            var search = (from purchases
                         in list
                          where (cboCompany.Text.Equals("전체") || purchases.company_name.Equals(cboCompany.Text)) &&
                                 (txtItem.Text.Length < 1 || purchases.item_id.Equals(txtItem.Text) || purchases.item_name.Contains(txtItem.Text)) &&
                                 (cboState.Text.Equals("전체") || purchases.purchase_state.Equals(cboState.Text)) &&
                                 (cboPurchaseID.Text.Equals("전체") || purchases.purchase_id.Equals(Convert.ToInt32(cboPurchaseID.Text)))
                          select purchases).ToList();


            dgvPurchases.DataSource = null;
            dgvPurchases.DataSource = search;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = new List<int>();
            for (int i = 0; i < dgvPurchases.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvPurchases[0, i].Value))
                {
                    selectedRows.Add(Convert.ToInt32(dgvPurchases["pd_id", i].Value));
                    if (Convert.ToInt32(dgvPurchases[9, i].Value) > 0)
                    {
                        MessageBox.Show("입고가 진행된 발주는 취소할 수 없습니다.");
                        return;
                    }
                }
            }
            if (selectedRows.Count < 1)
            {
                MessageBox.Show("발주 취소할 발주정보를 선택해 주십시오.");
                return;
            }
            bool result = service.DeletePurchases(selectedRows);

            if (result)
            {
                MessageBox.Show("삭제 성공");
                btnSearch.PerformClick();
            }
            else
                MessageBox.Show("삭제중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
        }

        private void btnDueChange_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = new List<int>();
            for (int i = 0; i < dgvPurchases.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvPurchases[0, i].Value))
                    selectedRows.Add(Convert.ToInt32(dgvPurchases["pd_id", i].Value));
            }

            if (selectedRows.Count > 1)
            {
                MessageBox.Show("납기일자를 변경할 발주정보를 하나만 선택해 주십시오.");
                return;
            }
            bool result = false;
            PopupDueDate popup = new PopupDueDate();
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                result = service.UpdateDueDate(selectedRows[0], popup.DueDate);
                if (result)
                {
                    MessageBox.Show("납기일자 변경 성공");
                    btnSearch.PerformClick();
                }
                else
                {
                    MessageBox.Show("납기일자를 변경하는중 오류가 발생하였습니다\r\n다시 시도하여 주십시오");
                    return;
                }
            }
                
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<PurchasesListVO> selectedRows = new List<PurchasesListVO>();
            for (int i = 0; i < dgvPurchases.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvPurchases[0, i].Value))
                {
                    PurchasesListVO vo = list.Find(elem => elem.pd_id == Convert.ToInt32(dgvPurchases["pd_id", i].Value));
                    selectedRows.Add(vo);
                }
            }

            if (selectedRows.Count > 1)
            {
                MessageBox.Show("발주서를 출력할 발주정보를 하나만 선택해 주십시오.");
                return;
            }

            (CompanyVO company,DataTable dt) =  service.GetOrderDraftInfo(selectedRows[0]);

            int totPrice = 0;
            foreach (DataRow row in dt.Rows)
            {
                totPrice += Convert.ToInt32(row["price"]);
            }
            rptPurchases rpt = new rptPurchases(selectedRows[0].purchase_id, totPrice, company);
            rpt.DataSource = dt;

            using (ReportPrintTool printTool = new ReportPrintTool(rpt))
            {
                printTool.ShowPreviewDialog();
            }
        }

        private void dgvPurchases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvPurchases);
        }
    }
}
