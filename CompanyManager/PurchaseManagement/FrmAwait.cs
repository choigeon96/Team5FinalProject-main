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
    public partial class FrmAwait : CompanyManager.MDIBaseForm
    {
        List<InboundVO> purchasesList = new List<InboundVO>();
        List<InboundVO> selectedList = new List<InboundVO>();
        InboundService service = new InboundService();
        public FrmAwait()
        {
            InitializeComponent();


            CommonUtil.SetInitGridView(dgvPurchases);
            CommonUtil.SetDGVDesign_Num(dgvPurchases);
            CommonUtil.SetDGVDesign_CheckBox(dgvPurchases);
            dgvPurchases.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주일자", "PurchasesDate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주상세번호", "pd_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "업체", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvPurchases, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvPurchases, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvPurchases, "규격", "unit", 80);
            CommonUtil.AddGridTextColumn(dgvPurchases, "단위", "item_unit_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "검사여부", "UseCheck", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPurchases, "발주량", "pd_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "입고량", "InQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "잔량", "RQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPurchases, "납기일자", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);






            CommonUtil.SetInitGridView(dgvInbound);
            CommonUtil.SetDGVDesign_Num(dgvInbound);
            CommonUtil.SetDGVDesign_CheckBox(dgvInbound);
            dgvInbound.RowHeadersVisible = true;

            CommonUtil.AddGridTextColumn(dgvInbound, "발주상세번호", "pd_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "업체", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvInbound, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvInbound, "규격", "unit", 80);
            CommonUtil.AddGridTextColumn(dgvInbound, "단위", "item_unit_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "검사여부", "UseCheck", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvInbound, "발주량", "pd_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고량", "InQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "잔량", "RQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvInbound, "입고일자", "InboundDate", 80, true, DataGridViewContentAlignment.MiddleCenter);

        }

        private void FrmAwait_Load(object sender, EventArgs e)
        {
            List<CodeVO> codes = service.GetAllCodes();
            var companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { name = "전체", code = "", category = "COMPANY" });
            var prodIDs = (from prodID in codes where prodID.category.Equals("PROD_ID") select prodID).ToList();
            prodIDs.Insert(0, new CodeVO() { name = "전체", code = "", category = "PROD_ID" });

            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            CommonUtil.BindingComboBox(cboProductionID, prodIDs, "code", "name");

            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(14);
            GetPurchaseList();
        }

        private void GetPurchaseList()
        {
            purchasesList = service.GetPurchasesList(dtpFrom.Value, dtpTo.Value);
            dgvPurchases.DataSource = purchasesList;
            dgvInbound.DataSource = null;
            selectedList.Clear();
        }

        private void dgvPurchases_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            if (Convert.ToBoolean(((DataGridViewCheckBoxCell)dgvPurchases[0, e.RowIndex]).Value))
            {
                int pdID = Convert.ToInt32(dgvPurchases["pd_id", e.RowIndex].Value);
                PopupInboundQty popup = new PopupInboundQty(Convert.ToInt32(dgvPurchases["RQty", e.RowIndex].Value));
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    InboundVO newInbound = new InboundVO()
                    {
                        pd_id = purchasesList[e.RowIndex].pd_id,
                        company_name = purchasesList[e.RowIndex].company_name,
                        item_id = purchasesList[e.RowIndex].item_id,
                        item_name = purchasesList[e.RowIndex].item_name,
                        unit = purchasesList[e.RowIndex].unit,
                        item_unit_qty = purchasesList[e.RowIndex].item_unit_qty,
                        UseCheck = purchasesList[e.RowIndex].UseCheck,
                        pd_qty = purchasesList[e.RowIndex].pd_qty,
                        InQty = Convert.ToInt32(popup.InQty),
                        RQty = purchasesList[e.RowIndex].pd_qty - Convert.ToInt32(popup.InQty)- purchasesList[e.RowIndex].CQty- purchasesList[e.RowIndex].InQty,
                        warehouse_id = purchasesList[e.RowIndex].warehouse_id,
                        prod_id = purchasesList[e.RowIndex].prod_id
                    };
                    selectedList.Add(newInbound);
                }
                else
                {
                    ((DataGridViewCheckBoxCell)dgvPurchases[0, e.RowIndex]).Value = false;

                    return;
                }

            }
            else
            {
                selectedList.Remove(selectedList.Find(elem => elem.pd_id == purchasesList[e.RowIndex].pd_id));
            }
            dgvInbound.DataSource = null;
            dgvInbound.DataSource = selectedList;
        }

        private void dgvInbound_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNewInbound_Click(object sender, EventArgs e)
        {
            List<InboundVO> selectedRows = new List<InboundVO>();
            for (int i = 0; i < dgvInbound.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvInbound[0, i].Value))
                    selectedRows.Add(selectedList[i]);
            }

            bool result = service.NewInbound(selectedRows);
            if (result)
            {
                MessageBox.Show("등록 성공");
                GetPurchaseList();

            }
            else
            {
                MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetPurchaseList();
            purchasesList = (from purchases in purchasesList
                             where
                             (txtItem.Text.Length < 1 || purchases.item_id.Equals(txtItem.Text) || purchases.item_name.Contains(txtItem.Text)) &&
                             (cboCompany.Text.Equals("전체") || purchases.company_name.Equals(cboCompany.Text)) &&
                             (cboProductionID.Text.Equals("전체") || purchases.prod_id.Equals(Convert.ToInt32(cboProductionID.SelectedValue)))
                             select purchases).ToList();
            dgvPurchases.DataSource = null;
            dgvPurchases.DataSource = purchasesList;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvPurchases);
        }
    }
}
