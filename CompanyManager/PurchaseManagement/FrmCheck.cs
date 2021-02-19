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
    public partial class FrmCheck : CompanyManager.MDIBaseForm
    {
    CheckService service = new CheckService();
        List<CheckVO> list = new List<CheckVO>();
        public FrmCheck()
        {
            InitializeComponent();

            CommonUtil.SetInitGridView(dgvCheck);
            CommonUtil.SetDGVDesign_Num(dgvCheck);
            CommonUtil.AddGridTextColumn(dgvCheck, "검사번호", "ch_id", 60,true,DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheck, "검사일", "ins_date", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheck, "담당자", "emp_name",120);
            CommonUtil.AddGridTextColumn(dgvCheck, "품목", "item_id", 120);
            CommonUtil.AddGridTextColumn(dgvCheck, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvCheck, "단위", "unit", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvCheck, "검사수량", "ch_qty", 70, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCheck, "양품수량", "good_qty", 70, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCheck, "불량수량", "bad_qty", 70, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvCheck, "불량사유", "bad_comment", 200);

        }

        private void FrmCheck_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
            List<CodeVO> companys = service.GetCompanyList();
            companys.Insert(0, new CodeVO() { name = "전체", code = "" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            GetCheckList();
        }

        private void GetCheckList()
        {
            list = service.GetCheckList(dtpFrom.Value, dtpTo.Value);
            dgvCheck.DataSource = null;
            dgvCheck.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetCheckList();
            var searchResult = (from check in list
                                where
                                (cboCompany.Text.Equals("전체") || cboCompany.Text.Equals(check.company_name)) &&
                                (txtID.Text.Length < 1 || check.item_id.Equals(txtID.Text) || check.item_name.Contains(txtID.Text))
                                select check).ToList();
            dgvCheck.DataSource = null;
            dgvCheck.DataSource = searchResult;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvCheck);
        }
    }
}
