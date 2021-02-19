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
    public partial class PopUpBOM : CompanyManager.PopupBaseForm
    {
        List<Control> validation = new List<Control>(); //유효성 검사할 컨트롤

        public List<CodeVO> codeAllList { get; set; } //콤보박스 바인딩 데이터
        public EmployeeVO LoginInfo { get; set; }
        public List<BOMVO> InsertList { get; set; } 
        public BOMVO InsertInfo { get; set; }

        string[] sort = "FP/SP/CI/RM/SM".Split('/');

        public PopUpBOM(bool copy = false)
        {
            InitializeComponent();
            validation.Add(cboParentsubject);
            validation.Add(cbosubject);
            validation.Add(txtuseqty);
            validation.Add(cbouse);
            validation.Add(cboauto);
            validation.Add(cboplan);

            if (copy)
            {
                btnSave.Visible = !copy;
                btnCancel.Location = new Point(287, 432);
                btnCancel.Text = "닫기";

                cboauto.Enabled = !copy;
                cboParentsubject.Enabled = !copy;
                cboplan.Enabled = !copy;
                cbosubject.Enabled = !copy;
                cbouse.Enabled = !copy;

                dtpstart.Enabled = !copy;
                dtpend.Enabled = !copy;
                txtcomment.ReadOnly = copy;
                txtupdate.ReadOnly = copy;
                txtupemp.ReadOnly = copy;
                txtuseqty.ReadOnly = copy;
            }

        }
        //유효성 검사
        private void Validation()
        {
            foreach (Control item in validation)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    throw new Exception(item.Tag.ToString());
                }
            }
        }
        private void PopUpBOM_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩 기본값 설정
            SetCbo();

            CodeVO co = new CodeVO { code = "", name = "" };
            CodeVO co2 = new CodeVO { code = "-", name = "-" , category = "-"};
            List<CodeVO> temp = temp = (from code in codeAllList
                                        where code.category.Equals("FP") ||
                                              code.category.Equals("SP") ||
                                              code.category.Equals("CI")
                                        select code).ToList();

            temp.Insert(0, co);
            temp.Insert(1, co2);
            cboParentsubject.DataSource = temp.ConvertAll(p => p);

            temp = (from code in codeAllList
                    where code.category.Equals("USE_FLAG")
                    select code).ToList();
            temp.Insert(0, co);
            cbouse.DataSource = temp.ConvertAll(p => p);
            cboauto.DataSource = temp.ConvertAll(p => p);
            cboplan.DataSource = temp.ConvertAll(p => p);

            dtpend.Value = dtpstart.Value.AddYears(2);
            txtupemp.Text = LoginInfo.emp_name;
            txtupdate.Text = DateTime.Now.ToString();


            if (InsertInfo != null)
            {
                cboParentsubject.SelectedIndex = FindSelectedIndex(cboParentsubject, InsertInfo.bom_parent_id);
                cbosubject.SelectedIndex = FindSelectedIndex(cbosubject, InsertInfo.item_id.Trim().StartsWith("└") ? InsertInfo.item_id.Trim().Substring(1).Trim() : InsertInfo.item_id.Trim());
                txtuseqty.Text = InsertInfo.bom_use_qty.ToString();
                dtpstart.Value = InsertInfo.start_date;
                dtpend.Value = InsertInfo.end_date;
                cbouse.SelectedIndex = FindSelectedIndex(cbouse, InsertInfo.bom_use);
                cboauto.SelectedIndex = FindSelectedIndex(cboauto, InsertInfo.auto_deduction);
                cboplan.SelectedIndex = FindSelectedIndex(cboplan, InsertInfo.plan_use);
                txtcomment.Text = InsertInfo.bom_comment;

                txtupemp.Text = InsertInfo.emp_name;
                txtupdate.Text = InsertInfo.up_date.ToString();
            }



        }

        private void SetCbo()
        {
            cboParentsubject.DisplayMember = "name";
            cbosubject.DisplayMember = "name";
            cbouse.DisplayMember = "name";
            cboauto.DisplayMember = "name";
            cboplan.DisplayMember = "name";

            cboParentsubject.ValueMember = "code";
            cbosubject.ValueMember = "code";
            cbouse.ValueMember = "code";
            cboauto.ValueMember = "code";
            cboplan.ValueMember = "code";
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
            for (result = 0; result < cbo.Items.Count; result++)
            {
                if (((CodeVO)cbo.Items[result]).code == item)
                {
                    return result;
                }
            }
            return 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //유효성 검사
            try
            {
                Validation();
                if (DateTime.Compare(dtpstart.Value, dtpend.Value) > 1)
                {
                    MessageBox.Show("종료일은 시작일보다 늦어야합니다.");
                    return;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }

            BOMVO vo = new BOMVO();
            vo.bom_parent_id = cboParentsubject.SelectedValue.ToString();
            vo.item_id = cbosubject.SelectedValue.ToString();
            vo.bom_use_qty = Convert.ToInt32(txtuseqty.Text);
            vo.start_date = dtpstart.Value;
            vo.end_date = dtpend.Value;
            vo.bom_use = cbouse.SelectedValue.ToString();
            vo.auto_deduction = cboauto.SelectedValue.ToString();
            vo.plan_use = cboplan.SelectedValue.ToString();
            vo.bom_comment = txtcomment.Text.ToString();
            vo.ins_emp = LoginInfo.emp_id;
            vo.ins_date = DateTime.Now;


            if (InsertInfo != null)
            {
                vo.bom_id = InsertInfo.bom_id;
            }

            List<BOMVO> temp = new List<BOMVO>();
            temp.Add(vo);
            InsertList = temp;


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //글자 수 제한
        private void limit20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 19)
            {
                if (e.KeyChar == 8)
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        //숫자만 칠수있게
        private void OnlyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!int.TryParse(e.KeyChar.ToString(), out int temp))
            {
                if (e.KeyChar == 8)
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void cboParentsubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CodeVO> temp = null;
            cbosubject.DataSource = temp;
            CodeVO co = new CodeVO { code = "", name = "" };
            SetCbo();
            //"FP/SP/CI/RM/SM"

            if (((CodeVO)cboParentsubject.SelectedItem).category == "-")
            {
                //제품을 선택했을때
                temp = temp = (from code in codeAllList
                               where code.category.Equals(sort[0]) ||
                                     code.category.Equals(sort[1]) ||
                                     code.category.Equals(sort[2]) ||
                                     code.category.Equals(sort[3]) ||
                                     code.category.Equals(sort[4])
                               select code).ToList();
                temp.Insert(0,co);
                cbosubject.DataSource = temp.ConvertAll(p => p);
            }
            else if(((CodeVO)cboParentsubject.SelectedItem).category == sort[0])
            {
                //제품을 선택했을때
                temp = temp = (from code in codeAllList
                               where code.category.Equals(sort[1]) ||
                                     code.category.Equals(sort[2]) ||
                                     code.category.Equals(sort[3]) ||
                                     code.category.Equals(sort[4])
                               select code).ToList();
                temp.Insert(0, co);
                cbosubject.DataSource = temp.ConvertAll(p => p);
            }
            else if (((CodeVO)cboParentsubject.SelectedItem).category == sort[1])
            {
                temp = temp = (from code in codeAllList
                               where code.category.Equals(sort[2]) ||
                                     code.category.Equals(sort[3]) ||
                                     code.category.Equals(sort[4])
                               select code).ToList();
                temp.Insert(0, co);
                cbosubject.DataSource = temp.ConvertAll(p => p);
            }
            else if (((CodeVO)cboParentsubject.SelectedItem).category == sort[2])
            {
                temp = temp = (from code in codeAllList
                               where code.category.Equals(sort[3]) ||
                                     code.category.Equals(sort[4])
                               select code).ToList();
                temp.Insert(0, co);
                cbosubject.DataSource = temp.ConvertAll(p => p);
            }
        }
    }
}
