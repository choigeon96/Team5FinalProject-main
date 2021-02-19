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
    public partial class FrmSalesClose : CompanyManager.MDIBaseForm
    {
        List<SOVO> list = new List<SOVO>();
        List<SOVO> chklist = new List<SOVO>();

        public FrmSalesClose()
        {
            InitializeComponent();

        }

        private void GetSO()
        {
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            CommonUtil.SetDGVDesign_CheckBox(dgvSO);
            CommonUtil.AddGridTextColumn(dgvSO, "SO ID", "so_id", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "PO ID", "po_id", 100, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "고객사", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "도착지", "company_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "MARKET", "mkt", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "주문수량", "so_o_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "출하수량", "so_s_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "취소수량", "so_c_qty", 60, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "매출확정수량", "s_cf_qty", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "매출확정금액", "s_cf_price", 90, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvSO, "마감일자", "due_date", 80, true, DataGridViewContentAlignment.MiddleCenter);

            SOListRoad();
        }

        private void SOListRoad()
        {
            SalesOrderService service = new SalesOrderService();
            list = service.GetSOList();

            dgvSO.DataSource = list;
            dgvSO.ClearSelection();

        }

        private void FrmSalesClose_Load(object sender, EventArgs e)
        {
            GetSO();
            RoadCombobox();
            dtpEnd.Value = dtpfrom.Value.AddDays(30);
            dtpfrom.Value = dtpfrom.Value.AddDays(-1);
        }

        private void btnMaGam_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSO.RowCount; i++)
            {
                if (dgvSO[0, i].Value != null && (bool)dgvSO[0, i].Value)
                {
                    chklist.Insert(0, list[i]);
                    chklist[0].up_emp = ((FrmMain)this.MdiParent).LoginInfo.up_emp;
                    chklist[0].up_date = DateTime.Now;
                }
                else
                {
                    var temp = chklist.Find(p => p.so_id == list[i].so_id);
                    chklist.Remove(temp);
                }
            }
            if (chklist.Count < 1)
            {
                MessageBox.Show("마감처리할 데이터를 선택해주세요.");
                return;
            }
            

            if(MessageBox.Show("선택한 데이터를 마감 처리하시겠습니까?","마감",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SalesOrderService service = new SalesOrderService();
                if(service.MaGamProcess(chklist))
                {
                    chklist.Clear();
                    MessageBox.Show("마감처리 완료되었습니다.");
                    SOListRoad();
                }
            }
        }
        private void RoadCombobox()
        {
            CompanyService service = new CompanyService();
            List<CompanyVO> combobox = service.GetCompany();

            cboCompany.DisplayMember = "company_name";
            cboCompany.ValueMember = "company_name";
            List<CompanyVO> temp = (from company_id in combobox
                                    select company_id).ToList();
            temp.Insert(0, new CompanyVO { company_name = "전체" });
            cboCompany.DataSource = temp;

            cboDestination.DisplayMember = "company_name";
            cboDestination.ValueMember = "company_name";
            List<CompanyVO> temp1 = (from company_id in combobox
                                    select company_id).ToList();
            temp1.Insert(0, new CompanyVO { company_name = "전체" });
            cboDestination.DataSource = temp1;

            CodeService service1 = new CodeService();
            List<CodeVO> combobox1 = service1.GetAllCommonCode();

            cboMKT.DisplayMember = "name";
            cboMKT.ValueMember = "name";
            List<CodeVO> temp2 = (from code in combobox1
                                     where code.category.Equals("MARKET")
                                     select code).ToList();
            temp2.Insert(0, new CodeVO { code = "", name = "전체" });
            cboMKT.DataSource = temp2;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var sResult = (from so_id in list
                            where (dtpfrom.Value <= so_id.due_date && dtpEnd.Value >= so_id.due_date) &&
                                  (cboCompany.SelectedValue.ToString().Equals("전체") || so_id.company_name.Equals(cboCompany.SelectedValue.ToString())) &&
                                  (cboDestination.SelectedValue.ToString().Equals("전체") || so_id.company_name.Equals(cboDestination.SelectedValue.ToString())) &&
                                  (cboMKT.SelectedValue.ToString().Equals("전체") || so_id.mkt.Equals(cboMKT.SelectedValue.ToString())) &&
                                  (so_id.item_name.Contains(txtitem.Text) || so_id.item_id.Contains(txtitem.Text)) && so_id.so_id.ToString().Contains(txtSO_id.Text)
                            select so_id).ToList();
            dgvSO.DataSource = null;
            dgvSO.DataSource = sResult;
            
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvSO);
        }
    }
}
