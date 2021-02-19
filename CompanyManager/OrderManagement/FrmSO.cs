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
    public partial class FrmSO : CompanyManager.MDIBaseForm
    {
        // service 객체
        SalesOrderService service = new SalesOrderService();
        // code목록 List
        List<CodeVO> codes = new List<CodeVO>();
        // 조횐된 SalesOrderVO 목록 List
        List<SalesOrderVO> list = new List<SalesOrderVO>();
        public FrmSO()
        {
            InitializeComponent();
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            CommonUtil.AddGridImageColumn(dgvSO, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvSO, "WORK_ORDER_ID", "order_id", 120, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "업체", "company_id", 60);
            CommonUtil.AddGridTextColumn(dgvSO, "업체명", "company_name", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "도착지명", "warehouse_name", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "item_id", 80);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "주문수량", "so_o_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "출고수량", "so_s_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "취소수량", "so_c_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "납기일", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "상태", "so_state", 90);
            CommonUtil.AddGridTextColumn(dgvSO, "비고", "so_comment", 80, true, DataGridViewContentAlignment.MiddleCenter);


        }

        /// <summary>
        /// 검색조건 접기/펼치기 버튼 클릭시 발생하는 메서드
        /// </summary>
        private void btnDown_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 컨트롤들의 초기값 설정, 그리드뷰 바인딩
        /// </summary>
        private void FrmSO_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = dtpFrom.Value.AddYears(1);
            codes = service.GetAllCodes();
            List<CodeVO> companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "전체" });
            //var items = (from item in codes where item.category.Equals("ITEM") select item).ToList();
            var states = (from state in codes where state.category.Equals("SO_STATE") select state).ToList();
            var warehouses = (from warehouse in codes where warehouse.category.Equals("WAREHOUSE") select warehouse).ToList();
            states.Insert(0, new CodeVO() { code = "", name = "전체" });
            warehouses.Insert(0, new CodeVO() { code = "", name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            //CommonUtil.BindingComboBox(cboItem, items, "code", "name");
            CommonUtil.BindingComboBox(cboState, states, "code", "name");
            CommonUtil.BindingComboBox(cboDest, warehouses, "code", "name");
            GetAllSO();
        }
        /// <summary>
        /// 검색 기간에 맞는 SalesOrder목록을 가져오는 메서드
        /// </summary>
        private void GetAllSO()
        {
            list = service.GetAllSO(dtpFrom.Value, dtpTo.Value);
            dgvSO.DataSource = list;
        }
        /// <summary>
        /// Edit 버튼 클릭시 발생하는 메서드
        /// </summary>
        private void dgvSO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit 클릭
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            if (dgvSO["so_state", e.RowIndex].Value.ToString().Equals("취소"))
                return;
            PopupSO popup = new PopupSO(codes, ((List<SalesOrderVO>)dgvSO.DataSource)[e.RowIndex]);
            if (popup.ShowDialog() == DialogResult.OK)
                GetAllSO();
        }
        /// <summary>
        /// 조회(검색) 버튼 클릭시 발생하는 메서드
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetAllSO();
            // 조회버튼 클릭
            var sResult = (from so in list
                           where
                           (so.due_date > dtpFrom.Value && so.due_date < dtpTo.Value) &&
                           (cboCompany.SelectedValue.ToString().Length < 1 || so.company_id.Equals(Convert.ToInt32(cboCompany.SelectedValue))) &&
                           so.order_id.Contains(txtOrderID.Text) &&
                           (cboState.SelectedValue.ToString().Length < 1 || so.so_state.Equals(cboState.Text)) &&
                           (txtItem.Text.Length < 1 || so.item_id.Equals(txtItem.Text) || so.item_name.Contains(txtItem.Text)) &&
                           (cboDest.SelectedValue.ToString().Length < 1 || so.warehouse_id.Equals(cboDest.SelectedValue.ToString()))
                           select so
           ).ToList();
            if (sResult.Count < 1)
            {
                MessageBox.Show("검색된 결과가 없습니다.");
                return;
            }
            dgvSO.DataSource = null;
            dgvSO.DataSource = sResult;
        }
        /// <summary>
        /// 등록일 DateTimePicker의 Format을 변경하는 메서드
        /// 폼 로드시 공백 / 값 변경시 값 출력
        /// </summary>
        private void dtpRegDate_ValueChanged_1(object sender, EventArgs e)
        {
            ((DateTimePicker)sender).Format = DateTimePickerFormat.Short;
        }
        /// <summary>
        /// 신규 등록 버튼 클릭시 발생하는 메서드
        /// </summary>
        private void btnNewSO_Click(object sender, EventArgs e)
        {
            PopupSO popup = new PopupSO(codes);
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                GetAllSO();
            }
        }
        /// <summary>
        /// 수요계획 생성 버튼 클릭시 발생하는 메서드 당일 계획대상 수요계획을 확정한다.
        /// </summary>
        private void btnDemandPlan_Click(object sender, EventArgs e)
        {
            List<SalesOrderVO> demandList = list.FindAll(elem => elem.plan_date <= (DateTime.Now) && elem.so_state.Equals("영업마스터생성"));
            if (demandList.Count < 1)
            {
                MessageBox.Show("수요계획 생산 대상이 없습니다.");
                return;
            }
            bool result = service.RegDemandPlan(demandList);
            if (!result)
            {
                MessageBox.Show("수요계획을 생성하는중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
                return;
            }
            MessageBox.Show("수요계획이 생성되었습니다.");
            GetAllSO();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvSO);
        }
    }
}
