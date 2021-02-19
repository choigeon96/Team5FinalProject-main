using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class PopCompanyCRUD : CompanyManager.PopupBaseForm
    {
        EmployeeVO evo;
        bool upflag = false;
        CompanyVO cvo;
        public PopCompanyCRUD(EmployeeVO vo)
        {
            InitializeComponent();
            evo = vo;
        }

        public PopCompanyCRUD(EmployeeVO evo, CompanyVO vo)
        {
            InitializeComponent();
            this.evo = evo;
            this.cvo = vo;
            upflag = true;
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtCName.Text.Length < 1 || cboCType.SelectedIndex < 1 || cboUse.SelectedIndex < 1 || cboCBType.SelectedIndex < 1 || cboEmp.SelectedIndex < 1)
            {
                MessageBox.Show("필수 입력 정보를 확인해주세요.");
                return;
            }

            CompanyVO vo = new CompanyVO
            {
                company_name = txtCName.Text,
                company_type = cboCType.SelectedValue.ToString(),
                company_use = cboUse.SelectedValue.ToString(),
                company_ceo = txtCEO.Text,
                company_btype = cboCBType.SelectedValue.ToString(),
                company_manager = cboEmp.SelectedValue.ToString(),
                company_email = txtEmail.Text,
                company_phone = txtPhone.Text,
                company_faxnum = txtFNum.Text,
                up_emp = evo.emp_id.ToString(),
                up_date = DateTime.Now,
                company_comment = txtCComment.Text,
            };

            if (txtBNum.Text.Length < 10 && txtBNum.Text.Length > 0)
            {
                MessageBox.Show("사업자 등록 번호를 확인해주세요.");
                return;
            }
            else if(txtBNum.Text.Length == 10)
                vo.company_bnum = string.Concat($"{txtBNum.Text.Substring(0, 3)}-{txtBNum.Text.Substring(3, 2)}-{txtBNum.Text.Substring(5)}");

            if (upflag)
            {
                vo.company_id = cvo.company_id;
                CompanyService service = new CompanyService();
                if (service.UpdateCompany(vo))
                {
                    MessageBox.Show("수정에 성공하였습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("수정에 실패하였습니다.");
                }
            }
            else
            {
                CompanyService service = new CompanyService();
                if (service.InsertCompany(vo))
                {
                    MessageBox.Show("등록에 성공하였습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("등록에 실패하였습니다.");
                }
            }
        }

        private void RoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboCType.DisplayMember = "name";
            cboCType.ValueMember = "code";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "VENDOR_TYPE"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboCType.DataSource = temp;

            cboCBType.DisplayMember = "name";
            cboCBType.ValueMember = "code";
            List<CodeVO> temp1 = (from code in combobox
                                  where code.category == "BUSINESS_TYPE"
                                  select code).ToList();
            temp1.Insert(0, new CodeVO { code = "", name = "" });
            cboCBType.DataSource = temp1;

            cboUse.DisplayMember = "name";
            cboUse.ValueMember = "code";
            List<CodeVO> temp2 = (from code in combobox
                                  where code.category == "USE_FLAG"
                                  select code).ToList();
            temp2.Insert(0, new CodeVO { code = "", name = "" });
            cboUse.DataSource = temp2;

            EmployeeService service1 = new EmployeeService();
            List<EmployeeVO> combobox1 = service1.GetAllEmployee();

            cboEmp.DisplayMember = "emp_name";
            cboEmp.ValueMember = "emp_id";

            List<EmployeeVO> temp3 = (from emp_id in combobox1
                                      select emp_id).ToList();
            temp3.Insert(0, new EmployeeVO { emp_id = 0, emp_name = "" });
            cboEmp.DataSource = temp3;
        }

        private void PopCompanyCRUD_Load(object sender, EventArgs e)
        {
            RoadCombobox();
            txtUpEmp.Text = evo.emp_name;
            if(upflag)
            {
                SetData();
            }
        }

        private void SetData()
        {
            txtCName.Text = cvo.company_name;
            cboCType.SelectedIndex = FindSelectedIndex(cboCType, cvo.company_type);
            cboUse.SelectedIndex = FindSelectedIndex(cboUse, cvo.company_use);
            txtCEO.Text = cvo.company_ceo;
            cboCBType.SelectedIndex = FindSelectedIndex(cboCBType, cvo.company_btype);
            cboEmp.SelectedIndex = FindSelectedIndex1(cboEmp, cvo.company_manager);
            txtEmail.Text = cvo.company_email;
            txtPhone.Text = cvo.company_phone;
            txtFNum.Text = cvo.company_faxnum;
            txtCComment.Text = cvo.company_comment;

            if (cvo.company_bnum == null)
                txtBNum.Text = "";
            else
                txtBNum.Text = string.Concat(cvo.company_bnum.Substring(0, 3), cvo.company_bnum.Substring(4, 2), cvo.company_bnum.Substring(7, 5));

        }

        private int FindSelectedIndex(ComboBox cbo, string item)
        {
            //빈값이면 리턴0
            if (item == "")
            {
                return 0;
            }

            int result;
            for (result = 0; result < cbo.Items.Count; result++)
            {
                if (((CodeVO)cbo.Items[result]).name == item)
                {
                    return result;
                }
            }
            return 0;
        }

        private int FindSelectedIndex1(ComboBox cbo, string item)
        {
            //빈값이면 리턴0
            if (item == "")
            {
                return 0;
            }

            int result;
            for (result = 0; result < cbo.Items.Count; result++)
            {
                if (((EmployeeVO)cbo.Items[result]).emp_name == item)
                {
                    return result;
                }
            }
            return 0;
        }

        private void txtBNum_Leave(object sender, EventArgs e)
        {
            if (txtBNum.Text.Length < 10 && txtBNum.Text.Length > 0)
                MessageBox.Show("사업자등록번호 10자리를 입력해주세요.");
        }
    }
}
