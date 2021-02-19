using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using VO;

namespace CompanyManager
{
    public partial class PopUpBOR : CompanyManager.PopupBaseForm
    {
        List<Control> validation = new List<Control>(); //유효성 검사할 컨트롤

        

        public BORVO InsertInfo { get; set; } //팝업창에 표시할 vo
        public List<CodeVO> CodeAllList { get; set; } //콤보박스에 바인딩할 코드리스트

        public EmployeeVO LoginInfo { get; set; } //로그인 정보
        public PopUpBOR()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "BOR";

            //유효성 검사할 컨트롤들 집어넣기
            validation.Add(cboItem);
            validation.Add(cboMacine);
            validation.Add(cboRoute);
            validation.Add(cboUse);
            validation.Add(txtPriority);
            validation.Add(txtTack);

            
        }
        public PopUpBOR(bool copy)
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "BOR";

            cboItem.Enabled = !copy;
            cboRoute.Enabled = !copy;
            cboMacine.Enabled = !copy;
            txtTack.ReadOnly = copy;
            txtpreceding.ReadOnly = copy;
            txtPriority.ReadOnly = copy;
            txtCompletion.ReadOnly = copy;
            cboUse.Enabled = !copy;
            txtComment.ReadOnly = copy;

            btnAdd.Visible = !copy;
            btnCancel.Location = new Point(291, 397);
            btnCancel.Text = "닫기";
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

        private void PopUpBOR_Load(object sender, EventArgs e)
        {
            //콤보박스 설정
            cboItem.DisplayMember = "name";
            cboRoute.DisplayMember = "name";
            cboMacine.DisplayMember = "name";
            cboUse.DisplayMember = "name";

            cboItem.ValueMember = "code";
            cboRoute.ValueMember = "code";
            cboMacine.ValueMember = "code";
            cboUse.ValueMember = "code";

            BindCbo();


            if (InsertInfo != null)
            {
                cboItem.SelectedIndex = FindSelectedIndex(cboItem, InsertInfo.Item_name.ToString());
                cboRoute.SelectedIndex = FindSelectedIndex(cboRoute, InsertInfo.Bor_route_name.ToString());
                cboMacine.SelectedIndex = FindSelectedIndex(cboMacine, InsertInfo.Machine_name.ToString());
                txtTack.Text = InsertInfo.Tacktime.ToString();
                txtpreceding.Text = InsertInfo.preceding_days == 0 ? "" : InsertInfo.preceding_days.ToString();
                txtPriority.Text = InsertInfo.Priority.ToString();
                txtCompletion.Text = InsertInfo.Completion_rate == 0 ? "" : InsertInfo.Completion_rate.ToString();
                cboUse.SelectedIndex = FindSelectedIndex(cboUse, InsertInfo.Bor_use.ToString());
                txtComment.Text = InsertInfo.Bor_comment;

            }
        }

        private void BindCbo()
        {
            List<CodeVO> temp;
            if (CodeAllList != null)
            {
                //품목
                temp = (from code in CodeAllList
                        where code.category == "item"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboItem.DataSource = temp;

                //공정
                temp = (from code in CodeAllList
                        where code.category == "ROUTE"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboRoute.DataSource = temp;

                //공정
                temp = (from code in CodeAllList
                        where code.category == "machine"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboMacine.DataSource = temp;

                //공정
                temp = (from code in CodeAllList
                        where code.category == "USE_FLAG"
                        select code).ToList();
                temp.Insert(0, new CodeVO { code = "", name = "" });
                cboUse.DataSource = temp;



            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //유효성 검사;
                Validation();
                

                BORVO vo = new BORVO();
                vo.Item_id = cboItem.SelectedValue.ToString();
                vo.Bor_route = cboRoute.SelectedValue.ToString();
                vo.Machine_id = cboMacine.SelectedValue.ToString();
                vo.Tacktime = Convert.ToInt32(txtTack.Text);
                vo.preceding_days = txtpreceding.Text == "" ? 0 : Convert.ToInt32(txtpreceding.Text);
                vo.Priority = Convert.ToInt32(txtPriority.Text);
                vo.Completion_rate = txtCompletion.Text == "" ? 0 : Convert.ToDecimal(txtCompletion.Text);
                vo.Bor_use = cboUse.SelectedValue.ToString();
                vo.Bor_comment = txtComment.Text;

                vo.Ins_date = DateTime.Now;
                vo.Ins_emp = Convert.ToInt32(LoginInfo.emp_id);

                //수정일 경우 borid 추가로 등록
                if(InsertInfo != null)
                {
                    vo.Bor_id = InsertInfo.Bor_id;
                }


                InsertInfo = vo;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message+"의 정보가 존재하지 않습니다.");
            }


        }

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
                if (e.KeyChar == 8) { }
                else if (e.KeyChar == '.') { }
                else { e.Handled = true; }
            }
        }



    }
}
