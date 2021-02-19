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
    public partial class FrmStock : CompanyManager.MDIBaseForm
    {
        List<StockVO> list = new List<StockVO>();
        StockService service = new StockService();
        public FrmStock()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvStock);
            CommonUtil.SetDGVDesign_Num(dgvStock);
            CommonUtil.AddGridTextColumn(dgvStock, "창고코드", "warehouse_id", 80,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvStock, "창고", "warehouse_name", 120);
            CommonUtil.AddGridTextColumn(dgvStock, "품목", "item_id", 150);
            CommonUtil.AddGridTextColumn(dgvStock, "품명", "item_name", 150);
            CommonUtil.AddGridTextColumn(dgvStock, "품목타입", "item_type", 80,true , DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvStock, "단위", "item_unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvStock, "재고량", "stock", 80,true,DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvStock, "관리등급", "item_grade", 80);
            CommonUtil.AddGridTextColumn(dgvStock, "비고", "item_comment", 200);

        }



        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvStock);
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            BindingDGV();
            List<CodeVO> codes = service.GetCodes();
            var warehouses = (from wh in codes where new List<string> { "ALL", "WAREHOUSE" }.Contains(wh.category) select wh).ToList();
            CommonUtil.BindingComboBox(cboWarehouse, warehouses, "code", "name");
            var types = (from type in codes where new List<string> { "ALL", "ITEM_TYPE" }.Contains(type.category) select type).ToList();
            CommonUtil.BindingComboBox(cboItemType, types, "code", "name");
        }

        private void BindingDGV()
        {
            list = service.GetStockList();
            if (list.Count > 0)
            {
                dgvStock.DataSource = null;
                dgvStock.DataSource = list;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from stock in list
                                where
                                (
                                (cboWarehouse.Text.Equals("전체") || Convert.ToInt32(cboWarehouse.SelectedValue).Equals(stock.warehouse_id)) &&
                                (txtItem.Text.Length < 1 || stock.item_id.Equals(txtItem.Text) || stock.item_name.Contains(txtItem.Text)) &&
                                (cboItemType.Text.Equals("전체") || stock.item_type.Equals(cboItemType.Text))
                                )
                                select stock).ToList();
            dgvStock.DataSource = null;
            dgvStock.DataSource = searchResult;
        }
    }
}
