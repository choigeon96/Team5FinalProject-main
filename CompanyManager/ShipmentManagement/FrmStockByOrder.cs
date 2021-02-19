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
    public partial class FrmStockByOrder : CompanyManager.MDIBaseForm
    {
        List<StockByOrderVO> list = new List<StockByOrderVO>();
        StockByOrderService service = new StockByOrderService();
        public FrmStockByOrder()
        {
            InitializeComponent();
        }

        private void FrmStockByOrder_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvMove);
            CommonUtil.SetDGVDesign_Num(dgvMove);
            CommonUtil.SetDGVDesign_CheckBox(dgvMove);
            dgvMove.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvMove, "주문번호", "so_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvMove, "거래처명", "company_name", 130, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvMove, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvMove, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvMove, "단위", "item_unit", 60,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvMove, "주문일", "so_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvMove, "납기일", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvMove, "from창고", "From", 60, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvMove, "from창고재고", "stock", 100, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvMove, "To창고", "To", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvMove, "비고", "so_comment", 130, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvMove, "이동수량", "MoveQty", 80, true, DataGridViewContentAlignment.MiddleRight);


            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddMonths(1);
            BindingDGV();

            List<CodeVO> codes = service.GetCodes();
            var fw = (from wh in codes
                      where wh.category.Equals("FROM_WAREHOUSE") || wh.category.Equals("ALL")
                      select wh).ToList();
            CommonUtil.BindingComboBox(cboFrom, fw, "code", "name");
            var tw = (from wh in codes
                      where wh.category.Equals("TO_WAREHOUSE") || wh.category.Equals("ALL")
                      select wh).ToList();
            CommonUtil.BindingComboBox(cboTo, tw, "code", "name");
            var items = (from item in codes
                         where item.category.Equals("ITEM") || item.category.Equals("ALL")
                         select item).ToList();
            CommonUtil.BindingComboBox(cboItem, items, "code", "name");
        }

        private void BindingDGV()
        {
            list = service.GetMoveList(dtpFrom.Value, dtpTo.Value);
            dgvMove.DataSource = null;
            dgvMove.DataSource = list;
        }

        private void dgvMove_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            StockByOrderVO vo = list.Find(elem => elem.so_id.Equals(Convert.ToInt32(dgvMove["so_id", e.RowIndex].Value)));

            int totQty = 0;
            foreach (DataGridViewRow row in dgvMove.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                    totQty += Convert.ToInt32(row.Cells["MoveQty"].Value);
            }

            if (vo.stock - (totQty) < 0)
            {
                MessageBox.Show("재고가 부족하여 선택할 수 없습니다.");
                ((DataGridViewCheckBoxCell)dgvMove[e.ColumnIndex, e.RowIndex]).Value = false;
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (from vo in list
                                where
                                (
                                (cboFrom.Text.Equals("전체") || vo.From.Equals(cboFrom.Text)) &&
                                (cboTo.Text.Equals("전체") || vo.To.Equals(cboTo.Text)) &&
                                (cboItem.Text.Equals("전체") || vo.item_id.Equals(cboItem.SelectedValue.ToString()))
                                )
                                select vo).ToList();
            dgvMove.DataSource = null;
            dgvMove.DataSource = searchResult;
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            List<StockByOrderVO> selectedVOs = new List<StockByOrderVO>();
            foreach (DataGridViewRow row in dgvMove.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                    selectedVOs.Add(list.Find(elem => elem.so_id.Equals(Convert.ToInt32(row.Cells["so_id"].Value))));
            }
            if (selectedVOs.Count<1)
            {
                MessageBox.Show("이동할 내용을 선택하십시오.");
                return;
            }

            bool result = service.MoveToSalesWH(selectedVOs,((FrmMain)this.MdiParent).LoginInfo.emp_id);
            if (result)
            {
                MessageBox.Show("등록 성공");
                BindingDGV();
            }
            else
                MessageBox.Show("처리중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvMove);
        }
    }
}
