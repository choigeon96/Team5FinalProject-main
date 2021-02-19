using CompanyManager.Properties;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmEmployee : CompanyManager.PopupBaseForm
    {
        List<EmployeeVO> list = new List<EmployeeVO>();
        EmployeeVO evo = new EmployeeVO();
        List<DeptVO> combobox;
        int id;
        int listbox;
        bool chk;
        public FrmEmployee(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
            DataRoad();
            RoadCombobox();
            RoadDept();

        }



        private void RoadCombobox()
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

        private void RoadDept()
        {
            lbDept.Items.Clear();
            for (int i = 0; i < combobox.Count; i++)
            {
                lbDept.DisplayMember = "DeptName";
                for (int j = 0; j < combobox.Count; j++)
                {
                    if (i+1 == combobox[j].dept_id)
                    {
                        lbDept.Items.Add(string.Concat(combobox[j].dept_id, "#", combobox[j].dept_name));
                        break;
                    }
                }
            }
        }

        private void DataRoad()
        {
            EmployeeService service = new EmployeeService();
            list = service.GetAllEmployee();

            dgvEmployee.DataSource = list;
            dgvEmployee.ClearSelection();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dgvEmployee);

            CommonUtil.AddGridImageColumn(dgvEmployee, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvEmployee, "ID", "emp_id", 80);
            CommonUtil.AddGridTextColumn(dgvEmployee, "Password", "emp_password");
            CommonUtil.AddGridTextColumn(dgvEmployee, "직원명", "emp_name", 70);
            CommonUtil.AddGridTextColumn(dgvEmployee, "부서명", "dept_name", 70);
            CommonUtil.AddGridTextColumn(dgvEmployee, "입사일", "hire_date");
            CommonUtil.AddGridTextColumn(dgvEmployee, "수정자", "up_emp", 80);
            CommonUtil.AddGridTextColumn(dgvEmployee, "수정시간", "up_date", 147);

            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.AllowUserToAddRows = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            if (txtEmpName.Text.Length < 1 && cboDept.SelectedIndex == 0)
            {
                DataRoad();
            }
            else if (txtEmpName.Text.Length > 0 && cboDept.SelectedIndex != 0)
            {
                var sResult = (from emp_id
                                in list
                                where
                                emp_id.emp_name.Contains(txtEmpName.Text) && emp_id.dept_name.Equals(cboDept.SelectedValue)
                                select emp_id).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = sResult;
            }
            else if (txtEmpName.Text.Length > 0 && cboDept.SelectedIndex == 0)
            {
                var sResult = (from emp_id
                            in list
                                where
                                emp_id.emp_name.Contains(txtEmpName.Text)
                                select emp_id).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = sResult;
            }
            else
            {
                var sResult = (from emp_id
                                in list
                                where
                                emp_id.dept_name.Equals(cboDept.SelectedValue)
                                select emp_id).ToList();
                dgvEmployee.DataSource = null;
                dgvEmployee.DataSource = sResult;
            }

           
        }

        private void btnEmpRegister_Click(object sender, EventArgs e)
        {
            PopEmployeeCRUD pop = new PopEmployeeCRUD(id);
            if(pop.ShowDialog() == DialogResult.OK)
            {
                DataRoad();
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                evo.emp_id = list[e.RowIndex].emp_id;
                evo.emp_password = list[e.RowIndex].emp_password;
                evo.emp_name = list[e.RowIndex].emp_name;
                evo.dept_name = list[e.RowIndex].dept_name;
                evo.hire_date = list[e.RowIndex].hire_date;
                if (e.ColumnIndex == 0)
                {
                    PopEmployeeCRUD pop = new PopEmployeeCRUD(id, evo, true);
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        DataRoad();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(evo == null)
            {
                MessageBox.Show("삭제할 직원을 선택해주세요.");
                return;
            }

            if(MessageBox.Show($"{evo.emp_name}을 정말로 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EmployeeService service = new EmployeeService();
                if(service.DeleteEmployee(evo.emp_id))
                {
                    MessageBox.Show("직원 정보가 삭제되었습니다.");
                    DataRoad();
                }
                else
                {
                    MessageBox.Show("직원 정보 삭제에 실패하였습니다.");
                }
            }
        }

        private void lbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            listbox = lbDept.SelectedIndex;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(lbDept.Items[lbDept.Items.Count - 1].ToString().Substring(0, lbDept.Items[lbDept.Items.Count - 1].ToString().IndexOf("#"))) + 1;
            pnlDept.Visible = true;
            txtDeptNo.Text = no.ToString();
            txtDeptNo.Focus();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            lbDept.Items.RemoveAt(listbox);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RoadDept();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            txtDeptName.Text = "";
            txtDeptNo.Text = "";
            pnlDept.Visible = false;
            lblchk.Text = "";
            btnAdd.Focus();
        }

        private void txtDeptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            bool bCheck = char.IsNumber(e.KeyChar) || e.KeyChar == 13 || e.KeyChar == '\b';
            TextBox temp = (TextBox)sender;
            int length = txtDeptNo.Text.Length;
            if (!bCheck)
            {
                lblchk.Text = "숫자만 입력하세요";
                lblchk.ForeColor = Color.Red;
                temp.Select(length, temp.Text.Length);
                chk = false;
            }
            else
            {
                lblchk.Text = "";
                chk = true;
            }
        }

        private void txtDeptNo_Leave_1(object sender, EventArgs e)
        {
            if (txtDeptNo.Text.Length > 0)
            {
                if (!int.TryParse(txtDeptNo.Text, out int i))
                {
                    lblchk.Text = "숫자만 입력하세요";
                    lblchk.ForeColor = Color.Red;
                    chk = false;
                }
                else
                {
                    lblchk.Text = "";
                    chk = true;
                }
            }
        }

        private void btnListAdd_Click(object sender, EventArgs e)
        {
            if (!chk || txtDeptName.Text.Length < 1)
            {
                MessageBox.Show("입력한 정보를 확인해주세요.");
                return;
            }

            lbDept.Items.Add(string.Concat(txtDeptNo.Text, "#", txtDeptName.Text));
            btnCencel.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("저장하시겠습니까?", "확인",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<DeptVO> list = new List<DeptVO>();
                for (int i = 0; i < lbDept.Items.Count; i++)
                {
                    DeptVO vo = new DeptVO();
                    string dept = lbDept.Items[i].ToString();
                    vo.dept_id = Convert.ToInt32(dept.Substring(0, dept.IndexOf("#")));
                    vo.dept_name = dept.Substring(dept.IndexOf("#") + 1);
                    list.Add(vo);
                }

                EmployeeService service = new EmployeeService();
                if(service.UpdateDept(list))
                {
                    combobox = service.GetDept();
                    MessageBox.Show("저장이 완료되었습니다.");
                    RoadDept();
                }
                else
                {
                    MessageBox.Show("저장에 실패하였습니다.");
                }
                
            }
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            (DataTable, string) data = Util.CommonExcel.ReadExcelData();
            //제대로된 파일을 읽어 왔고 데이터가 있다면
            if (!string.IsNullOrEmpty(data.Item2) && data.Item1.Rows.Count > 0)
            {
                //List<EmployeeVO> temp = new List<EmployeeVO>();

                //foreach (DataRow row in data.Item1.Rows)
                //{
                //    #region 유효성검사
                //    if (string.IsNullOrEmpty(row["아이디"].ToString()))
                //        continue;
                //    if (string.IsNullOrEmpty(row["패스워드"].ToString()))
                //        continue;
                //    if (string.IsNullOrEmpty(row["직원명"].ToString()))
                //        continue;
                //    if (string.IsNullOrEmpty(row["부서"].ToString()))
                //        continue;

                //    #endregion
                //    try
                //    {
                //        EmployeeVO vo = new EmployeeVO
                //        {
                //            emp_id = Convert.ToInt32(row["아이디"].ToString()),
                //            emp_password = row["패스워드"].ToString(),
                //            emp_name = row["직원명"].ToString(),
                //            dept_no = row["부서"].ToString(),
                //            hire_date = Convert.ToDateTime(row["입사일"].ToString()),
                //            up_date = DateTime.Now,
                //            up_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id.ToString()
                //        };
                //        temp.Add(vo);
                //    }
                //    catch (Exception err)
                //    {
                //        MessageBox.Show("엑셀에 등록된 정보를 확인하여주세요");
                //        break;
                //    }

                //}

                ////정상적으로 읽은 값이 없다면. 리턴
                //if (temp.Count < 1)
                //{
                //    MessageBox.Show("파일을 정상적으로 읽어오지 못했습니다. 내용을 확인해주세요");
                //    return;
                //}

                ////값 등록

                //Service.EmployeeService service = new Service.EmployeeService();

                //if (service.ExcelImportEmployee(temp))
                //{
                //    DataRoad();
                //}
                //else
                //{
                //    MessageBox.Show("직원 정보를 등록하지 못했습니다.");
                //}

            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvEmployee);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "양식 다운로드";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WebClient wc = new WebClient();
                    //wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/공창창고등록양식.xlsx", dlg.FileName + ".xlsx");
                    File.Copy("../../ExcelForm/직원등록양식.xlsx", dlg.FileName + ".xlsx");
                    Process.Start(dlg.FileName + ".xlsx");
                }
                catch (Exception err)
                {
                    MessageBox.Show("다운로드중 오류가 발생하였습니다.\r\n 다시 시도하여 주십시오.");
                }
            }
        }
    }
}
