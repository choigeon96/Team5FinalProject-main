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
    public partial class FrmMoveProcess : CompanyManager.MDIBaseForm
    {
        List<MoveVO> list = new List<MoveVO>();
        List<MoveVO> checkedList = new List<MoveVO>();
        MoveService service = new MoveService();
        public FrmMoveProcess()
        {
            InitializeComponent();


        }
        private void FrmMoveProcess_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvStock);
            CommonUtil.SetDGVDesign_Num(dgvStock);
            CommonUtil.SetDGVDesign_CheckBox(dgvStock);
            CommonUtil.AddGridTextColumn(dgvStock, "작업지시ID", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvStock, "품목", "item_id", 130);
            CommonUtil.AddGridTextColumn(dgvStock, "품명", "item_name", 150, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvStock, "불출창고", "ok_warehouse_name", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvStock, "이동창고", "use_warehouse_name", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvStock, "품목타입", "item_type", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvStock, "현재고", "Rqty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvStock, "이동수량", "wo_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvStock, "단위", "item_unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvStock, "비고", "item_comment", 150, true, DataGridViewContentAlignment.MiddleLeft);



            CommonUtil.SetInitGridView(dgvMove);
            CommonUtil.SetDGVDesign_Num(dgvMove);
            CommonUtil.SetDGVDesign_CheckBox(dgvMove);
            CommonUtil.AddGridTextColumn(dgvMove, "품목", "item_id", 150);
            CommonUtil.AddGridTextColumn(dgvMove, "품명", "item_name", 150);
            CommonUtil.AddGridTextColumn(dgvMove, "불출창고", "ok_warehouse_name", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvMove, "이동창고", "use_warehouse_name", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvMove, "현재고", "Rqty", 100, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvMove, "이동수량", "wo_qty", 100, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvMove, "단위", "item_unit", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvMove, "이동일자", "MoveDate", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvMove, "비고", "item_comment", 200);
            dgvMove.RowHeadersVisible =  dgvStock.RowHeadersVisible = true;


            List<CodeVO> codes = service.GetCodes();
            var types = (from type in codes where type.category.Equals("ITEM_TYPE") || type.category.Equals("ALL") select type).ToList();
            CommonUtil.BindingComboBox(cboItemType, types, "code", "name");
            var warehouses= (from wh in codes where wh.category.Equals("WAREHOUSE")||wh.category.Equals("ALL") select wh).ToList();
            CommonUtil.BindingComboBox(cboWarehouse, warehouses, "code", "name");
            cboStock.Text = "전체";
            BindingDGV();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingDGV();
            var searchResult = (
                                from move in list
                                where (
                                        (cboWarehouse.Text.Equals("전체") || move.ok_warehouse_name.Equals(cboWarehouse.Text) || move.use_warehouse_name.Equals(cboWarehouse.Text)) &&
                                        (cboItemType.Text.Equals("전체") || move.item_type.Equals(cboItemType.Text)) &&
                                        (txtItem.Text.Length < 1 || move.item_id.Equals(txtItem.Text) || move.item_name.Contains(txtItem.Text)) &&
                                        (cboStock.Text.Equals("전체") || (cboStock.Text.Equals("가능") && (move.Rqty - move.wo_qty) >= 0) || (cboStock.Text.Equals("불가능") && (move.Rqty - move.wo_qty) < 0))
                                      )
                                select move
                               ).ToList();
            dgvStock.DataSource = null;
            dgvStock.DataSource = searchResult;
            MatchDetailList();
        }

        private void BindingDGV()
        {
            list = service.GetMoveStockList();
            dgvStock.DataSource = null;
            dgvStock.DataSource = list;
            //MatchDetailList();
        }

        private void MatchDetailList()
        {
            foreach (DataGridViewRow row in dgvStock.Rows)
            {
                bool IsChecked = checkedList.Contains(checkedList.Find(elem => elem.wo_id.Equals(Convert.ToInt32(row.Cells["wo_id"].Value)) &&
                                                      elem.item_id.Equals(row.Cells["item_id"].Value.ToString())));
                if (IsChecked)
                    ((DataGridViewCheckBoxCell)row.Cells[0]).Value = true;
            }
        }

        private void dgvStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            bool IsChecked = Convert.ToBoolean(((DataGridViewCheckBoxCell)dgvStock[0, e.RowIndex]).EditedFormattedValue);

            MoveVO move = list.Find(elem => elem.wo_id.Equals(Convert.ToInt32(dgvStock["wo_id", e.RowIndex].Value)) && elem.item_id.Equals(dgvStock["item_id", e.RowIndex].Value.ToString()));
            if (IsChecked)
            {
                int sumQty = 0;
                checkedList.ForEach(elem => sumQty = elem.item_id.Equals(move.item_id) && elem.use_warehouse_name.Equals(move.use_warehouse_name) ? sumQty + elem.wo_qty : sumQty);
                if (move.wo_qty > move.Rqty || sumQty >= move.Rqty)
                {
                    MessageBox.Show("재고가 부족하여 이동할 수 없습니다.");
                    ((DataGridViewCheckBoxCell)dgvStock[0, e.RowIndex]).Value = false;
                    return;
                }

                if (checkedList.Contains(move))
                    return;

                checkedList.Add(move);
                dgvMove.DataSource = null;
                dgvMove.DataSource = checkedList;
            }
            else
            {
                checkedList.Remove(checkedList.Find(elem => elem.wo_id.Equals(Convert.ToInt32(dgvStock["wo_id", e.RowIndex].Value)) && elem.item_id.Equals(dgvStock["item_id", e.RowIndex].Value.ToString())));
                dgvMove.DataSource = null;
                dgvMove.DataSource = checkedList;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgvMove.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dgvMove.Rows[i].Cells[0].Value))
                    continue;
                checkedList.Remove(checkedList[i]);
            }
            dgvMove.DataSource = null;
            dgvMove.DataSource = checkedList;
            BindingDGV();
            MatchDetailList();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            List<MoveVO> selectedRows = new List<MoveVO>();
            for (int i = 0; i < dgvMove.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dgvMove.Rows[i].Cells[0].Value))
                    continue;
                selectedRows.Add(checkedList[i]);
            }
            if (checkedList.Count < 1)
            {
                MessageBox.Show("공정이동할 항목을 선택하십시오.");
                return;
            }
            bool result = service.ApplyMove(selectedRows,((FrmMain)this.MdiParent).LoginInfo.emp_id);
            if (result)
            {
                MessageBox.Show("등록 성공");

                checkedList.RemoveAll(elem => selectedRows.Contains(elem));
                dgvMove.DataSource = null;
                dgvMove.DataSource = checkedList;
                BindingDGV();
                MatchDetailList();
            }
            else
                MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");

        }
    }
}
