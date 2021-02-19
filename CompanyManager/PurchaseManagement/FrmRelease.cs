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
namespace CompanyManager
{
    public partial class FrmRelease : CompanyManager.MDIBaseForm
    {
        DispendService service = new DispendService();
        List<DispendWOVO> wos = new List<DispendWOVO>();
        List<DispendVO> list = new List<DispendVO>();
        public FrmRelease()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvWorkOrder);
            CommonUtil.SetDGVDesign_Num(dgvWorkOrder);
            CommonUtil.SetDGVDesign_CheckBox(dgvWorkOrder);
            dgvWorkOrder.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "계획시작일", "wo_sdate", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "작업지시ID", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비ID", "machine_id", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "설비명", "machine_name", 140, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목", "item_id", 140, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "품목명", "item_name", 160, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "지시수량", "wo_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "단위", "unit", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvWorkOrder, "상태명", "wo_state", 120, true, DataGridViewContentAlignment.MiddleCenter);



            CommonUtil.SetInitGridView(dgvDispend);
            CommonUtil.SetDGVDesign_Num(dgvDispend);
            CommonUtil.AddGridTextColumn(dgvDispend, "계획시작일자", "wo_sdate", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "작업지시ID", "wo_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "설비명", "machine_name", 130, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청창고", "in_warehouse", 110, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "불출창고", "use_warehouse_id", 110, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "품목", "item_id", 100, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "품명", "item_name", 130, true, DataGridViewContentAlignment.MiddleLeft);
            CommonUtil.AddGridTextColumn(dgvDispend, "재고량", "stock", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청수량", "required_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvDispend, "단위", "item_unit", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "상태", "wo_state", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvDispend, "요청일", "requestDate", 80, true, DataGridViewContentAlignment.MiddleCenter);

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmRelease_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now.AddDays(14);
            List<CodeVO> codes = service.GetMachineCodes();
            if (codes != null)
            {
                codes.Insert(0, new CodeVO() { name = "전체", code = "" });
                CommonUtil.BindingComboBox(cboMachine, codes, "code", "name");
            }
            BindingWorkOrder();
        }

        private void BindingWorkOrder()
        {
            wos = service.GetWorkOrderList(dtpFrom.Value, dtpTo.Value);
            if (wos == null)
            {
                MessageBox.Show("목록을 불러오는중 오류가 발생했습니다.");
                return;
            }
            dgvWorkOrder.DataSource = wos;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingWorkOrder();
            var searchResult = (from wo in wos
                                where
                                (
                                (txtItem.Text.Length < 1 || wo.item_id.Equals(txtItem.Text) || wo.item_name.Contains(txtItem.Text)) &&
                                (txtWOID.Text.Length < 1 || wo.wo_id.Equals(Convert.ToInt32(txtWOID.Text))) &&
                                (cboMachine.Text.Equals("전체") || wo.machine_id.Equals(cboMachine.SelectedValue.ToString()))
                                )
                                select wo).ToList();
            dgvWorkOrder.DataSource = null;
            dgvWorkOrder.DataSource = searchResult;
        }
        /// <summary>
        /// 여기부터
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //List<int> selectedRows = new List<int>();
            //for (int i = 0; i < dgvWorkOrder.Rows.Count; i++)
            //{
            //    if (Convert.ToBoolean(dgvWorkOrder[0, i].Value))
            //    {
            //        selectedRows.Add(Convert.ToInt32(dgvWorkOrder["wo_id", i].Value));
            //    }
            //}
            //if (selectedRows.Count < 1)
            //{
            //    MessageBox.Show("자재를 불출할 작업을 선택해 주십시오.");
            //    return;
            //}
            //bool result = service.GetDispendInfo(selectedRows);

            //if (result)
            //{
            //    MessageBox.Show("등록 성공");
            //    btnSearch.PerformClick();
            //}
            //else
            //    MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
        }

        private void dgvWorkOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvWorkOrder[0, e.RowIndex];
            int woID = Convert.ToInt32(dgvWorkOrder["wo_id", e.RowIndex].Value);
            if (Convert.ToBoolean(chk.EditedFormattedValue))
            {
                List<DispendVO> details = service.GetDispendInfo(woID);
                if (details.Count > 0)
                {
                    foreach (DispendVO dispendVO in details)
                    {
                        if (list.Exists(elem => elem.wo_id == dispendVO.wo_id && elem.item_id == dispendVO.item_id))
                            continue;
                        list.Add(dispendVO);
                    }
                }
            }
            else
            {
                list.RemoveAll(elem => elem.wo_id.Equals(woID));
            }

            dgvDispend.DataSource = null;
            dgvDispend.DataSource = list;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (list.Count < 1)
            {
                MessageBox.Show("자재불출을 요청할 작업지시를 선택해주십시오.");
            }
            bool result = service.InsertMetarialRelease(list,((FrmMain)this.MdiParent).LoginInfo.emp_id);
            if (result)
            {
                MessageBox.Show("등록 성공");
                BindingWorkOrder();
                dgvDispend.DataSource = null;
                list.Clear();
            }
            else
                MessageBox.Show("등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");
        }

        private void btnWorkOrderExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvWorkOrder);
        }

        private void btnDispendExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvDispend);
        }
    }
}
