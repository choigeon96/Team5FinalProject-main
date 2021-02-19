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
    public partial class PopFactoryCRUD : CompanyManager.PopupBaseForm
    {
        EmployeeVO logininfo = new EmployeeVO();
        FactoryVO vo = new FactoryVO();
        bool upflag = false;
        bool whflag = false;

        public PopFactoryCRUD(EmployeeVO evo)
        {
            InitializeComponent();
            logininfo = evo;
        }
        public PopFactoryCRUD(EmployeeVO evo, FactoryVO vo, bool flag)
        {
            InitializeComponent();
            logininfo = evo;
            this.vo = vo;
            upflag = flag;
        }

        public PopFactoryCRUD(EmployeeVO evo, FactoryVO vo, bool upflag, bool whflag)
        {
            InitializeComponent();
            logininfo = evo;
            this.vo = vo;
            this.upflag = upflag;
            this.whflag = whflag;
        }

        private void PopFactoryCRUD_Load(object sender, EventArgs e)
        {
            txtUpEmp.Text = logininfo.emp_name;

            LoadCombobox();
            if (upflag)
            {
                SetUpdateData();           
            }
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
                if (((FactoryVO)cbo.Items[result]).factory_name == item)
                {
                    return result;
                }
            }
            return 0;
        }

        private int FindSelectedIndex2(ComboBox cbo, string item)
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

        private void SetUpdateData()
        {
            cboFGrade.SelectedValue = vo.factory_grade;
            if (whflag)
                cboParent.SelectedIndex = FindSelectedIndex(cboParent, vo.factory_parent);
            else
                cboFParent.SelectedIndex = FindSelectedIndex(cboFParent,vo.factory_parent);
            cboFType.SelectedIndex = FindSelectedIndex2(cboFType,vo.factory_type);
            txtFName.Text = vo.factory_name;
            cboFUse.SelectedIndex = FindSelectedIndex2(cboFUse, vo.factory_use);
            txtComment.Text = vo.factory_comment;

        }

        private void LoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboFGrade.DisplayMember = "name";
            cboFGrade.ValueMember = "name";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "FACTORY_GRADE"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFGrade.DataSource = temp;

            cboFType.DisplayMember = "name";
            cboFType.ValueMember = "code";
            temp = (from code in combobox
                    where code.category == "FACILITY_TYPE"
                    select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFType.DataSource = temp;

            cboFUse.DisplayMember = "name";
            cboFUse.ValueMember = "code";
            temp = (from code in combobox
                    where code.category == "USE_FLAG"
                    select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboFUse.DataSource = temp;

            FactoryService service1 = new FactoryService();
            List<FactoryVO> combobox1 = service1.GetFactory();

            cboParent.DisplayMember = "factory_name";
            cboParent.ValueMember = "factory_id";

            List<FactoryVO> temp1 = (from factory_id in combobox1
                                     where factory_id.codename == "공장" && factory_id.factory_grade == "공장"
                                     select factory_id).ToList();
            temp1.Insert(0, new FactoryVO { factory_name = "", factory_id = 0 });
            cboParent.DataSource = temp1;

            cboFParent.DisplayMember = "factory_name";
            cboFParent.ValueMember = "factory_name";

            List<FactoryVO> temp2 = (from factory_id in combobox1
                                     where factory_id.codename == "공장" && factory_id.factory_grade == "회사"
                                     select factory_id).ToList();
            temp2.Insert(0, new FactoryVO { factory_name = ""});
            cboFParent.DataSource = temp2;
        }

        private void btnCRU_Click(object sender, EventArgs e)
        {
            if (cboFGrade.SelectedIndex < 1)
            {
                MessageBox.Show("필수 입력 정보를 확인해주세요.");
                return;
            }
            else if (cboFGrade.SelectedIndex == 1)
            {
                if (cboFUse.SelectedIndex < 1 || txtFName.Text.Length < 1)
                {
                    MessageBox.Show("필수 입력 정보를 확인해주세요.");
                    return;
                }
            }
            else if (cboFGrade.SelectedIndex == 2)
            {
                if (cboFUse.SelectedIndex < 1 || cboFParent.SelectedIndex < 1 || txtFName.Text.Length < 1)
                {
                    MessageBox.Show("필수 입력 정보를 확인해주세요.");
                    return;
                }
            }
            else
            {
                if (cboFType.SelectedIndex < 1 || cboFUse.SelectedIndex < 1 || cboParent.SelectedIndex < 1 || txtFName.Text.Length < 1)
                {
                    MessageBox.Show("필수 입력 정보를 확인해주세요.");
                    return;
                }
                else
                {
                    whflag = true;
                }
            }

            if (!whflag)
            {
                FactoryVO fvo = new FactoryVO
                {
                    factory_grade = cboFGrade.SelectedValue.ToString(),
                    factory_name = txtFName.Text,
                    up_emp = logininfo.emp_id,
                    up_date = DateTime.Now,
                    factory_use = cboFUse.SelectedValue.ToString(),
                    factory_comment = txtComment.Text
                };
                if (cboFParent.Enabled)
                {
                    fvo.factory_parent = cboFParent.SelectedValue.ToString();
                }
                else
                    fvo.factory_parent = "없음";
                if (cboFType.Enabled)
                    fvo.factory_type = cboFType.SelectedValue.ToString();
                else
                    fvo.factory_type = "공장";


                if (upflag)
                {
                    fvo.factory_id = vo.factory_id;

                    FactoryService service = new FactoryService();
                    if (service.UpdateFactory(fvo))
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
                    FactoryService service = new FactoryService();
                    if (service.AddFactory(fvo))
                    {
                        MessageBox.Show("등록이 성공하였습니다.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("등록이 실패하였습니다.");
                    }
                }
            }
            else
            {
                FactoryVO fvo = new FactoryVO
                {
                    factory_grade = cboFGrade.SelectedValue.ToString(),
                    factory_name = txtFName.Text,
                    up_emp = logininfo.emp_id,
                    up_date = DateTime.Now,
                    factory_id = vo.factory_id,
                    factory_use = cboFUse.SelectedValue.ToString(),
                    factory_comment = txtComment.Text
                };

                if (cboFType.Enabled)
                {
                    fvo.factory_type = cboFType.SelectedValue.ToString();
                }

                if(cboParent.Enabled)
                {
                    fvo.factory_parent = cboParent.SelectedValue.ToString();
                }

                if (upflag)
                {
                    FactoryService service = new FactoryService();
                    if (service.UpdateWarehouse(fvo))
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
                    FactoryService service = new FactoryService();
                    if (service.AddWarehouse(fvo))
                    {
                        MessageBox.Show("등록이 성공하였습니다.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("등록이 실패하였습니다.");
                    }
                }
            }
    }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboFGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboFGrade.SelectedValue.ToString() == "창고")
            {
                cboFType.Enabled = true;
                cboParent.Enabled = true;
                cboFParent.Enabled = false;
                cboFParent.Visible = false;
                cboParent.Visible = true;
            }
            else if(cboFGrade.SelectedValue.ToString() == "공장")
            {
                cboParent.Enabled = false;
                cboFType.Enabled = false;
                cboFParent.Enabled = true;
                cboFParent.Visible = true;
                cboParent.Visible = false;
            }
            else
            {
                cboParent.Enabled = false;
                cboFType.Enabled = false;
                cboFParent.Enabled = false;
                cboFParent.Visible = true;
                cboParent.Visible = false;

            }
        }
    }
}
