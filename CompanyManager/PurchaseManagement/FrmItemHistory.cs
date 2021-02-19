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
    public partial class FrmItemHistory : CompanyManager.MDIBaseForm
    {
        List<IOVO> list = new List<IOVO>();
        IOService service = new IOService();
        List<CodeVO> ioTypes = new List<CodeVO>();
        public FrmItemHistory()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvIO);
            CommonUtil.SetDGVDesign_Num(dgvIO);
            CommonUtil.AddGridTextColumn(dgvIO, "입출고일", "IODate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvIO, "구분", "Gubun", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvIO, "카테고리", "IOType", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvIO, "FROM창고", "From", 100);
            CommonUtil.AddGridTextColumn(dgvIO, "창고", "To", 100);
            CommonUtil.AddGridTextColumn(dgvIO, "품목", "item_id", 150);
            CommonUtil.AddGridTextColumn(dgvIO, "품명", "item_name", 180);
            CommonUtil.AddGridTextColumn(dgvIO, "단위", "item_unit", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvIO, "품목형태", "item_type", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvIO, "수불량", "IOQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvIO, "관리등급", "item_grade", 100, true, DataGridViewContentAlignment.MiddleCenter);


        }



        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void FrmItemHistory_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            BindingDGV();

            List<CodeVO> codes = service.GetCodes();

            ioTypes = (from type in codes
                       where new List<string> { "ALL", "INBOUND_STATE", "OUTBOUND_TYPE" }.Contains(type.category)
                       select type).ToList();

            var ios = (from io in codes
                       where new List<string> { "ALL", "IO_TYPE" }.Contains(io.category)
                       select io).ToList();
            CommonUtil.BindingComboBox(cboIO, ios, "code", "name");
            var warehouses = (from warehouse in codes
                              where new List<string> { "ALL", "WAREHOUSE" }.Contains(warehouse.category)
                              select warehouse).ToList();
            CommonUtil.BindingComboBox(cboWarehouse, warehouses, "code", "name");
            var itemTypes = (from types in codes
                             where new List<string> { "ALL", "ITEM_TYPE" }.Contains(types.category)
                             select types).ToList();
            CommonUtil.BindingComboBox(cboItemType, itemTypes, "code", "name");
        }
        
        private void BindingDGV()
        {
            list = service.GetIOList(dtpFrom.Value, dtpTo.Value.AddDays(1));
            dgvIO.DataSource = null;
            dgvIO.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from io in list
                                where
                                (
                                (cboWarehouse.Text.Equals("전체") || io.From.Equals(cboWarehouse.Text) || io.To.Equals(cboWarehouse.Text)) &&
                                (txtItem.Text.Length < 1 || io.item_id.Equals(txtItem.Text) || io.item_name.Contains(txtItem.Text)) &&
                                (cboItemType.Text.Equals("전체") || io.item_type.Equals(cboItemType.Text)) &&
                                (cboIO.Text.Equals("전체") || io.Gubun.Equals(cboIO.Text)) &&
                                (cboIOType.Text.Equals("전체") || io.IOType.Equals(cboIOType.Text))
                                )
                                select io).ToList();
            dgvIO.DataSource = null;
            dgvIO.DataSource = searchResult;
        }

        private void cboIO_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CodeVO> newCodes = new List<CodeVO>();
            if (cboIO.Text.Equals("입고"))
                newCodes = (from inbound in ioTypes where inbound.category.Equals("ALL") || inbound.category.Equals("INBOUND_STATE") select inbound).ToList();
            else if (cboIO.Text.Equals("출고"))
                newCodes = (from outbound in ioTypes where outbound.category.Equals("ALL") || outbound.category.Equals("OUTBOUND_TYPE") select outbound).ToList();
            else newCodes = ioTypes;

            cboIOType.DataSource = null;
            CommonUtil.BindingComboBox(cboIOType, newCodes, "code", "name");
        }
    }
}
