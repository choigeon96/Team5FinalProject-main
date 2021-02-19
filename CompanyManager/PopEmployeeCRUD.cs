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
    public partial class PopEmployeeCRUD : CompanyManager.PopupBaseForm
    {
        EmployeeVO evo = new EmployeeVO();
        List<DeptVO> combobox;
        int id;
        bool upflag = false;
        bool idchk = false;
        public PopEmployeeCRUD(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        public PopEmployeeCRUD(int id, EmployeeVO vo,bool flag)
        {
            InitializeComponent();
            this.id = id;
            evo = vo;
            upflag = flag;
        }

        private void PopEmployeeCRUD_Load(object sender, EventArgs e)
        {
            txtUp_Emp.Text = id.ToString();
            RoadComboBox();
            if (upflag)
                SetUpdateData();
        }

        private void SetUpdateData()
        {
            txtEmpID.Text = evo.emp_id.ToString();
            txtEmpID.ReadOnly = true;
            txtPassword.Text = evo.emp_password;
            txtEmpName.Text = evo.emp_name;
            cboDept.SelectedValue = evo.dept_name;
            dtpEmp.Value = Convert.ToDateTime(evo.hire_date);
        }

        public void RoadComboBox()
        {
            EmployeeService service = new EmployeeService();
            combobox = service.GetDept();

            cboDept.DisplayMember = "dept_name";
            cboDept.ValueMember = "dept_name";
            List<DeptVO> temp = (from dept in combobox
                                 select dept).ToList();
            temp.Insert(0, new DeptVO { dept_id = 0, dept_name = "" });
            cboDept.DataSource = temp;
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtEmpID.Text.Length < 1 || txtPassword.Text.Length < 1 || cboDept.SelectedIndex < 1 || txtEmpName.Text.Length < 1 || idchk)
            {
                MessageBox.Show("필수 입력 정보를 확인해주세요.");
                return;
            }

            EmployeeVO evo = new EmployeeVO
            {
                emp_id = Convert.ToInt32(txtEmpID.Text),
                emp_password = txtPassword.Text,
                emp_name = txtEmpName.Text,
                dept_no = lbldept_id.Text,
                hire_date = dtpEmp.Value,
                up_emp = txtUp_Emp.Text,
                up_date = DateTime.Now
            };

            if(upflag)
            {
                EmployeeService service = new EmployeeService();
                if(service.UpdateEmployee(evo))
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
                EmployeeService service = new EmployeeService();
                if(service.AddEmployee(evo))
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

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < combobox.Count; i++)
            {
                if (cboDept.SelectedValue.ToString() == combobox[i].dept_name)
                {
                    lbldept_id.Text = combobox[i].dept_id.ToString();
                    return;
                }
            }
        }

        private void txtEmpID_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool bCheck = char.IsNumber(e.KeyChar) || e.KeyChar == 13 || e.KeyChar == '\b';
            TextBox temp = (TextBox)sender;
            int length = txtEmpID.Text.Length;

            if (!bCheck)
            {
                lblIDchk.Text = "숫자만 입력하세요!";
                lblIDchk.ForeColor = Color.Red;
                temp.Select(length, temp.Text.Length);
                idchk = true;
            }
            else
            {
                lblIDchk.Text = "";
                lblIDchk.ForeColor = Color.Black;
                idchk = false;
            }
        }

        private void txtEmpID_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtEmpID.Text, out int i))
            {
                lblIDchk.Text = "숫자만 입력되지 않았습니다.";
                lblIDchk.ForeColor = Color.Red;
                txtEmpID.Select(0, txtEmpID.Text.Length);
                idchk = true;
            }
            else
                idchk = false;
        }
    }
}
