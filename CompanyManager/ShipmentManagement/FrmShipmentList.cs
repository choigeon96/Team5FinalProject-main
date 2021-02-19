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
    public partial class FrmShipmentList : CompanyManager.MDIBaseForm
    {
        List<ShipmentVO> list = new List<ShipmentVO>();
        ShipmentService service = new ShipmentService();
        public FrmShipmentList()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvShipment);
            CommonUtil.SetDGVDesign_Num(dgvShipment);
            CommonUtil.SetDGVDesign_CheckBox(dgvShipment);
            dgvShipment.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvShipment, "고객주문번호", "order_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "SO ID", "so_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "고객사", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "도착지", "DestinationName", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvShipment, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvShipment, "납기일", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하일자", "ship_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvShipment, "주문수량", "Qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvShipment, "출하수량", "SQty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvShipment, "취소수량", "CQty", 60, true, DataGridViewContentAlignment.MiddleRight);

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }



        private void FrmShipmentList_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now.AddDays(1);
            BindingDGV();

            List<CodeVO> codes = service.GetShipmentCodes();
            var tos = (from wh in codes where new List<string> { "ALL", "TO" }.Contains(wh.category) select wh).ToList();
            CommonUtil.BindingComboBox(cboWarehouse, tos, "code", "name");
            var companys = (from company in codes where new List<string> { "ALL", "COMPANY" }.Contains(company.category) select company).ToList();
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
        }

        private void BindingDGV()
        {
            list = service.GetShipmentList(dtpFrom.Value, dtpTo.Value);
            dgvShipment.DataSource = null;
            dgvShipment.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from vo in list
                               where
                               (
                               (cboCompany.Text.Equals("전체")||vo.company_name.Equals(cboCompany.Text))&&
                               (cboWarehouse.Text.Equals("전체")||vo.DestinationName.Equals(cboWarehouse.Text))&&
                               (txtItem.Text.Length<1||vo.item_id.Equals(txtItem.Text)||vo.item_name.Contains(txtItem.Text))&&
                               (txtWOID.Text.Length<1||vo.order_id.Equals(txtWOID.Text))
                               )select vo).ToList();
            dgvShipment.DataSource = null;
            dgvShipment.DataSource = searchResult;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvShipment);
        }


    }
}
