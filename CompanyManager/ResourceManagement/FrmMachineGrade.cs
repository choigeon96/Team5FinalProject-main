using CompanyManager.Properties;
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
    public partial class FrmMachineGrade : CompanyManager.MDIBaseForm
    {
        List<MGradeVO> list = new List<MGradeVO>();
        List<MachinesVO> list2 = new List<MachinesVO>();
        MGradeVO mgvo = new MGradeVO();
        MachinesVO mvo = new MachinesVO();
        bool upflag = false;
        public FrmMachineGrade()
        {
            InitializeComponent();
        }

        private void FrmMachineGrade_Load(object sender, EventArgs e)
        {
            GetMachine();
            GetMachineGrade();
            RoadCombobox();
            txtUpEmp.Text = ((FrmMain)this.MdiParent).LoginInfo.emp_name.ToString();
        }

        private void GetMachineGrade()
        {
            CommonUtil.SetDGVDesign_Num(dgvMachineGrade);

            CommonUtil.AddGridImageColumn(dgvMachineGrade, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군 코드", "mgrade_code");
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군 명", "mgrade_name",90);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "상위시설", "mgrade_parent");
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "시설설명", "mgrade_comment", 80);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "사용유무", "mgrade_use",70);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "수정자", "up_emp", 60);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "수정시간", "up_date",141);
            CommonUtil.AddGridTextColumn(dgvMachineGrade, "설비군ID", "machine_grade", 0, false);

            dgvMachineGrade.AutoGenerateColumns = false;
            dgvMachineGrade.AllowUserToAddRows = false;

            MGradeRoad();
        }
        private void GetMachine()
        {
            CommonUtil.SetDGVDesign_Num(dgvMachine);

            CommonUtil.AddGridImageColumn(dgvMachine, Resources.Edit_16x16, "Edit", 30);
            CommonUtil.AddGridTextColumn(dgvMachine, "설비코드", "machine_id");
            CommonUtil.AddGridTextColumn(dgvMachine, "설비명", "machine_name");
            CommonUtil.AddGridTextColumn(dgvMachine, "소진창고", "use_warehouse_id",85);
            CommonUtil.AddGridTextColumn(dgvMachine, "양품창고", "ok_warehouse_id",85);
            CommonUtil.AddGridTextColumn(dgvMachine, "불량창고", "ng_warehouse_id",85);
            CommonUtil.AddGridTextColumn(dgvMachine, "외주여부", "m_os_use");
            CommonUtil.AddGridTextColumn(dgvMachine, "특이사항 및 비고", "machine_comment", 140);
            CommonUtil.AddGridTextColumn(dgvMachine, "사용유무", "machine_use");
            CommonUtil.AddGridTextColumn(dgvMachine, "수정자", "up_emp", 80);
            CommonUtil.AddGridTextColumn(dgvMachine, "수정시간", "up_date", 184);
            CommonUtil.AddGridTextColumn(dgvMachine, "설비군ID", "machine_grade",100 , false);

            dgvMachine.AutoGenerateColumns = false;
            dgvMachine.AllowUserToAddRows = false;
        }

        private void RoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboUse.DisplayMember = "name";
            cboUse.ValueMember = "code";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "USE_FLAG"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "" });
            cboUse.DataSource = temp;

            FactoryService service1 = new FactoryService();
            List<FactoryVO> combobox1 = service1.GetFactory();

            cboParent.DisplayMember = "factory_name";
            cboParent.ValueMember = "factory_id";

            List<FactoryVO> temp1 = (from factory_id in combobox1
                                     where factory_id.codename == "공장" && factory_id.factory_grade == "공장"
                                     select factory_id).ToList();
            temp1.Insert(0, new FactoryVO { factory_name = "", factory_id = 0 });
            cboParent.DataSource = temp1;
        }

        private void btnMGRegister_Click(object sender, EventArgs e)
        {
            btnCencel.PerformClick();
            pnlMGrade.Visible = true;
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            upflag = false;
            txtMGCode.Text = txtMGName.Text = txtComment.Text = lblMGrade.Text = "";
            cboUse.SelectedIndex = 0;
            pnlMGrade.Visible = false;
        }

        private void MGradeRoad()
        {
            MGradeService service = new MGradeService();
            list = service.GetMGrade();

            dgvMachineGrade.DataSource = list;
            dgvMachineGrade.ClearSelection();
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
                if (((FactoryVO)cbo.Items[result]).factory_name == item)
                {
                    return result;
                }
            }
            return 0;
        }

        private void dgvMachineGrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                mgvo.machine_grade = list[e.RowIndex].machine_grade;
                mgvo.mgrade_code = list[e.RowIndex].mgrade_code;
                mgvo.mgrade_name = list[e.RowIndex].mgrade_name;
                mgvo.mgrade_use = list[e.RowIndex].mgrade_use;
                mgvo.mgrade_comment = list[e.RowIndex].mgrade_comment;
                mgvo.mgrade_parent = list[e.RowIndex].mgrade_parent;
                if (e.ColumnIndex == 0)
                {
                    lblMGrade.Text = mgvo.machine_grade.ToString();
                    txtMGCode.Text = mgvo.mgrade_code;
                    txtMGName.Text = mgvo.mgrade_name;
                    cboUse.SelectedIndex = FindSelectedIndex(cboUse,mgvo.mgrade_use);
                    cboParent.SelectedIndex = FindSelectedIndex1(cboParent, mgvo.mgrade_parent);
                    txtComment.Text = mgvo.mgrade_comment;
                    upflag = true;
                    pnlMGrade.Visible = true;
                }
                MachineRoad(mgvo.machine_grade);
            }
        }

        private void btnMGCRU_Click(object sender, EventArgs e)
        {
            if (txtMGCode.Text.Length < 1 || txtMGName.Text.Length < 1 || cboUse.SelectedIndex < 1 || cboParent.SelectedIndex < 1)
            {
                MessageBox.Show("필수 입력 정보를 확인해주세요.");
                return;
            }

            MGradeVO vo = new MGradeVO
            {
                mgrade_code = txtMGCode.Text,
                mgrade_name = txtMGName.Text,
                mgrade_comment = txtComment.Text,
                up_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id.ToString(),
                up_date = DateTime.Now,
                mgrade_use = cboUse.SelectedValue.ToString(),
                mgrade_parent = cboParent.SelectedValue.ToString()
            };
            

            if (upflag)
                vo.machine_grade = Convert.ToInt32(lblMGrade.Text);

            if (upflag)
            {
                MGradeService service = new MGradeService();
                if (service.UpdateMGrade(vo))
                {
                    MessageBox.Show("수정에 성공하였습니다.");
                    MGradeRoad();
                    btnCencel.PerformClick();
                }
                else
                {
                    MessageBox.Show("수정에 실패하였습니다.");
                }
            }
            else
            {
                MGradeService service = new MGradeService();
                if (service.InsertMGrade(vo))
                {
                    MessageBox.Show("등록에 성공하였습니다.");
                    MGradeRoad();
                    btnCencel.PerformClick();
                }
                else
                {
                    MessageBox.Show("등록에 실패하였습니다.");
                }
            }
        }

        private void btnMGDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mgvo.mgrade_code))
            {
                MessageBox.Show("삭제할 설비군을 선택해주세요.");
                return;
            }
            if(list2.Count > 0 )
            {
                MessageBox.Show("해당 설비군에 속한 설비가 존재하여 삭제할 수 없습니다.");
                return;
            }
            if(MessageBox.Show("정말로 삭제하시겠습니까?","경고",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MGradeService service = new MGradeService();
                if(service.DeleteMGrade(mgvo.machine_grade))
                {
                    MessageBox.Show("삭제가 완료되었습니다.");
                    MGradeRoad();
                    btnCencel.PerformClick();

                }
                else
                {
                    MessageBox.Show("삭제에 실패하였습니다.");
                }
            }
        }

        private void dgvMachineGrade_DoubleClick(object sender, EventArgs e)
        {
            MachineRoad(mgvo.machine_grade);
        }

        private void MachineRoad(int mgrade)
        {
            dgvMachine.DataSource = null;
            MachineService service = new MachineService();
            list2 = service.GetMachine(mgrade);
            dgvMachine.DataSource = list2;
            dgvMachine.ClearSelection();
        }

        private void btnMDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(mvo.machine_id))
            {
                MessageBox.Show("삭제할 설비를 선택해주세요.");
                return;
            }

            if(MessageBox.Show("정말로 삭제하시겠습니까?", "경고",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MachineService service = new MachineService();
                if(service.DeleteMachine(mvo.machine_id))
                {
                    MessageBox.Show("삭제가 완료되었습니다.");
                    MachineRoad(mvo.machine_grade);
                }
            }
        }

        private void btnMRegister_Click(object sender, EventArgs e)
        {
            if(mgvo.machine_grade < 1)
            {
                MessageBox.Show("등록할 설비군을 선택해주세요.");
                return;
            }
            PopMachineCRUD pop = new PopMachineCRUD(mgvo.machine_grade,((FrmMain)this.MdiParent).LoginInfo);
            if(pop.ShowDialog() == DialogResult.OK)
            {
                MachineRoad(mgvo.machine_grade);
            }
        }

        private void dgvMachine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mvo.machine_id = list2[e.RowIndex].machine_id;
            mvo.machine_grade = list2[e.RowIndex].machine_grade;
            mvo.machine_name = list2[e.RowIndex].machine_name;
            mvo.machine_use = list2[e.RowIndex].machine_use;
            mvo.use_warehouse_id = list2[e.RowIndex].use_warehouse_id;
            mvo.ok_warehouse_id = list2[e.RowIndex].ok_warehouse_id;
            mvo.ng_warehouse_id = list2[e.RowIndex].ng_warehouse_id;
            mvo.m_os_use = list2[e.RowIndex].m_os_use;
            mvo.machine_comment = list2[e.RowIndex].machine_comment;

            if(e.ColumnIndex == 0)
            {
                PopMachineCRUD pop = new PopMachineCRUD(((FrmMain)this.MdiParent).LoginInfo, mvo);
                if(pop.ShowDialog() == DialogResult.OK)
                {
                    MachineRoad(mvo.machine_grade);
                }
            }
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            (DataTable, string) data = Util.CommonExcel.ReadExcelData();
            //제대로된 파일을 읽어 왔고 데이터가 있다면
            if (!string.IsNullOrEmpty(data.Item2) && data.Item1.Rows.Count > 0)
            {
                List<MGradeVO> temp = new List<MGradeVO>();

                foreach (DataRow row in data.Item1.Rows)
                {
                    #region 유효성검사
                    if (string.IsNullOrEmpty(row["mgrade_name"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["mgrade_code"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["mgrade_use"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["mgrade_parent"].ToString()))
                        continue;
                    #endregion
                    try
                    {
                        MGradeVO vo = new MGradeVO
                        {
                            mgrade_name = row["factory_grade"].ToString(),
                            mgrade_code = row["factory_type"].ToString(),
                            mgrade_use = row["factory_name"].ToString(),
                            mgrade_parent = row["factory_parent"].ToString(),
                            mgrade_comment = row["factory_use"].ToString(),
                            up_date = DateTime.Now,
                            up_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id.ToString()
                        };
                        temp.Add(vo);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("엑셀에 등록된 정보를 확인하여주세요");
                        break;
                    }

                }

                //정상적으로 읽은 값이 없다면. 리턴
                if (temp.Count < 1)
                {
                    MessageBox.Show("파일을 정상적으로 읽어오지 못했습니다. 내용을 확인해주세요");
                    return;
                }

                //값 등록

                Service.MGradeService service = new Service.MGradeService();

                if (service.ExcelImportMGrade(temp))
                {
                    MGradeRoad();
                }
                else
                {
                    MessageBox.Show("공장 창고 정보를 등록하지 못했습니다.");
                }

            }
            else
                MessageBox.Show("파일을 읽지 못하였습니다.");
        }

        private void btnExcelExport1_Click(object sender, EventArgs e)
        {
            if(list2.Count < 1)
            {
                MessageBox.Show("Excel Export할 데이터가 없습니다.");
                return;
            }
            CommonExcel.ExportExcel(dgvMachine);
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvMachineGrade);
        }
    }
}
