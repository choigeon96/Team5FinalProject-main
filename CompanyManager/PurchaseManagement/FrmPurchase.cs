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
    public partial class FrmPurchase : CompanyManager.MDIBaseForm
    {
        PurchaseService service = new PurchaseService();
        public FrmPurchase()
        {
            InitializeComponent();
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            PopupPurchase popup = new PopupPurchase();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ShowDialog();
        }
        #region // dgv muiltiline header
        private void dgvPurchases_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPurchases_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void dgvPurchases_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void dgvPurchases_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

        }
        #endregion

        private void FrmPurchase_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTO.Value = DateTime.Now.AddDays(10);
            List<CodeVO> codes =service.GetAllCodes();
            var companys = (from company in codes where company.category.Equals("COMPANY_CODE") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "전체" });
            var warehouses = (from warehouse in codes where warehouse.category.Equals("WAREHOUSE") select warehouse).ToList();
            warehouses.Insert(0, new CodeVO() { code = "", name = "전체" });
            var itemTypes = (from type in codes where type.category.Equals("ITEM_TYPE") select type).ToList();
            itemTypes.Insert(0, new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            CommonUtil.BindingComboBox(cboItemCategory, itemTypes, "code", "name");
            CommonUtil.BindingComboBox(cboWarehouse, warehouses, "code", "name");

            dtpFrom.Value = DateTime.Now;
            dtpTO.Value = dtpFrom.Value.AddDays(15);

            CommonUtil.SetInitGridView(dgvPurchases);
            CommonUtil.SetDGVDesign(dgvPurchases);
            CommonUtil.SetDGVDesign_Num(dgvPurchases);
            dgvPurchases.RowHeadersVisible = true;
            dgvPurchases.AutoGenerateColumns = true;
            dgvPurchases.DataSource = service.GetDGVInfo(dtpFrom.Value, dtpTO.Value);
            dgvPurchases.Columns["item_id"].HeaderText = "품목";
            dgvPurchases.Columns["item_id"].Width = 100;
            dgvPurchases.Columns["item_id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPurchases.Columns["item_name"].HeaderText = "품명";
            dgvPurchases.Columns["item_name"].Width = 120;
            dgvPurchases.Columns["item_type"].HeaderText = "품목유형";
            dgvPurchases.Columns["item_type"].Width = 60;
            dgvPurchases.Columns["항목"].HeaderText = "항목";
            dgvPurchases.Columns["항목"].Width = 80;
            dgvPurchases.Columns["company_name"].Visible = false;
            dgvPurchases.Columns["warehouse_name"].Visible = false;

            for (int i = 5; i < dgvPurchases.Columns.Count; i++)
            {
                dgvPurchases.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

        }

        private void dgvPurchases_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvPurchases.DataSource = service.GetDGVInfo(dtpFrom.Value, dtpTO.Value);


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
