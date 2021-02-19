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
    public partial class PopMachineCRUD : CompanyManager.PopupBaseForm
    {
        private bool upflag = false;
        EmployeeVO evo = new EmployeeVO();
        MachinesVO vo = new MachinesVO();
        public PopMachineCRUD(int mgrade, EmployeeVO evo)
        {
            InitializeComponent();
            vo.machine_grade = mgrade;
            this.evo = evo;
        }

        public PopMachineCRUD(EmployeeVO evo, MachinesVO vo)
        {
            InitializeComponent();
            this.evo = evo;
            this.vo = vo;
            upflag = true;
            txtMachineID.ReadOnly = true;
        }

        private void RoadCombobox()
        {
            FactoryService service = new FactoryService();
            List<WareHouseVO> combobox = service.GetWarehouse();

            cboUseWh.DisplayMember = "warehouse_name";
            cboUseWh.ValueMember = "warehouse_id";
            List<WareHouseVO> temp = (from code in combobox
                                    select code).ToList();
            temp.Insert(0, new WareHouseVO { warehouse_type = "", warehouse_name = "" });
            cboUseWh.DataSource = temp;

            List<WareHouseVO> temp1 = (from code in combobox
                                    select code).ToList();
            temp1.Insert(0, new WareHouseVO { warehouse_type = "", warehouse_name = "" });

            cboOKWh.DisplayMember = "warehouse_name";
            cboOKWh.ValueMember = "warehouse_id";
            cboOKWh.DataSource = temp1;

            List<WareHouseVO> temp2 = (from code in combobox
                                    select code).ToList();
            temp2.Insert(0, new WareHouseVO { warehouse_type = "", warehouse_name = "" });

            cboNGWh.DisplayMember = "warehouse_name";
            cboNGWh.ValueMember = "warehouse_id";
            cboNGWh.DataSource = temp2;


            CodeService service1 = new CodeService();
            List<CodeVO> combobox1 = service1.GetAllCommonCode();

            cboUse.DisplayMember = "name";
            cboUse.ValueMember = "code";
            List<CodeVO> list = (from code in combobox1
                                 where code.category == "USE_FLAG"
                                 select code).ToList();
            list.Insert(0, new CodeVO { code = "", name = "" });
            cboUse.DataSource = list;

            cboOSuse.DisplayMember = "name";
            cboOSuse.ValueMember = "code";
            List<CodeVO> list1 = (from code in combobox1
                                 where code.category == "USE_FLAG"
                                 select code).ToList();
            list1.Insert(0, new CodeVO { code = "", name = "" });
            cboOSuse.DataSource = list1;

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
                if (((WareHouseVO)cbo.Items[result]).warehouse_name == item)
                {
                    return result;
                }
            }
            return 0;
        }

        private void PopMachineCRUD_Load(object sender, EventArgs e)
        {
            RoadCombobox();
            txtUpEmp.Text = evo.emp_name;
            if(upflag)
            {
                txtMachineID.Text = vo.machine_id;
                txtMachineName.Text = vo.machine_name;
                cboUse.SelectedIndex = FindSelectedIndex(cboUse,vo.machine_use);
                cboUseWh.SelectedIndex = FindSelectedIndex2(cboUseWh,vo.use_warehouse_id);
                cboOKWh.SelectedIndex = FindSelectedIndex2(cboOKWh, vo.ok_warehouse_id);
                cboNGWh.SelectedIndex = FindSelectedIndex2(cboNGWh, vo.ng_warehouse_id);
                txtComment.Text = vo.machine_comment;
                cboOSuse.SelectedIndex = FindSelectedIndex(cboOSuse,vo.m_os_use);
                
            }    
        }

        private void btnCRU_Click(object sender, EventArgs e)
        {
            if (txtMachineID.Text.Length < 1 || txtMachineName.Text.Length < 1 || cboUse.SelectedIndex < 1 || cboUseWh.SelectedIndex < 1 ||
                cboOKWh.SelectedIndex < 1 || cboNGWh.SelectedIndex < 1)
            {
                MessageBox.Show("필수 입력 정보를 확인해주세요.");
                return;
            }


            MachinesVO mvo = new MachinesVO
            {
                machine_id = txtMachineID.Text,
                machine_grade = vo.machine_grade,
                machine_name = txtMachineName.Text,
                machine_use = cboUse.SelectedValue.ToString(),
                use_warehouse_id = cboUseWh.SelectedValue.ToString(),
                ok_warehouse_id = cboOKWh.SelectedValue.ToString(),
                ng_warehouse_id = cboNGWh.SelectedValue.ToString(),
                up_date = DateTime.Now,
                up_emp = evo.emp_id.ToString()

            };
            if (cboOSuse.SelectedIndex < 1)
            {
                cboOSuse.SelectedIndex = FindSelectedIndex(cboOSuse, "미사용");
                mvo.m_os_use = cboOSuse.SelectedValue.ToString();
            }
            else
            {
                mvo.m_os_use = cboOSuse.SelectedValue.ToString();
            }

            if (txtComment.Text.Length < 1)
                mvo.machine_comment = "";
            else
                mvo.machine_comment = txtComment.Text;

            if (upflag)
            {
                MachineService service = new MachineService();
                if (service.UpdateMachine(mvo))
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
                MachineService service = new MachineService();
                if (service.InsertMachine(mvo))
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

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
