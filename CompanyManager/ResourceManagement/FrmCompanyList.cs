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
    public partial class FrmCompanyList : CompanyManager.MDIBaseForm
    {
        List<CompanyVO> list = new List<CompanyVO>();
        CompanyVO vo = new CompanyVO();
        public FrmCompanyList()
        {
            InitializeComponent();
        }

        private void FrmCompanyList_Load(object sender, EventArgs e)
        {
            GetCompany();
            RoadCombobox();
            CompanyRoad();
        }

        private void GetCompany()
        {
            CommonUtil.SetDGVDesign_Num(dgvCompany);

            CommonUtil.AddGridImageColumn(dgvCompany, Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvCompany, "업체명", "company_name");
            CommonUtil.AddGridTextColumn(dgvCompany, "업체타입명", "company_type");
            CommonUtil.AddGridTextColumn(dgvCompany, "대표자명", "company_ceo");
            CommonUtil.AddGridTextColumn(dgvCompany, "사업자등록번호", "company_bnum");
            CommonUtil.AddGridTextColumn(dgvCompany, "업종", "company_btype");
            CommonUtil.AddGridTextColumn(dgvCompany, "담당자", "company_manager");
            CommonUtil.AddGridTextColumn(dgvCompany, "이메일", "company_email");
            CommonUtil.AddGridTextColumn(dgvCompany, "전화번호", "company_phone");
            CommonUtil.AddGridTextColumn(dgvCompany, "팩스", "company_faxnum");
            CommonUtil.AddGridTextColumn(dgvCompany, "사용유무", "company_use");
            CommonUtil.AddGridTextColumn(dgvCompany, "업체정보", "company_comment");
            CommonUtil.AddGridTextColumn(dgvCompany, "수정자", "up_emp");
            CommonUtil.AddGridTextColumn(dgvCompany, "수정시간", "up_date", 160);

            dgvCompany.AutoGenerateColumns = false;
            dgvCompany.AllowUserToAddRows = false;

        }

        private void RoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboCompanyType.DisplayMember = "name";
            cboCompanyType.ValueMember = "name";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "VENDOR_TYPE"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "전체" });
            cboCompanyType.DataSource = temp;

            cboBtype.DisplayMember = "name";
            cboBtype.ValueMember = "name";
            List<CodeVO> temp1 = (from code in combobox
                                 where code.category == "BUSINESS_TYPE"
                                 select code).ToList();
            temp1.Insert(0, new CodeVO { code = "", name = "전체" });
            cboBtype.DataSource = temp1;
        }

        private void CompanyRoad()
        {
            CompanyService service = new CompanyService();
            list = service.GetCompany();

            dgvCompany.DataSource = list;
            dgvCompany.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtBNum.Text.Length < 1 && txtCName.Text.Length < 1 && cboBtype.SelectedIndex < 1 && cboCompanyType.SelectedIndex < 1)
            {
                CompanyRoad();
            }
            else
            {
                List<CompanyVO> temp = (from company_id in list
                                        where company_id.company_name.Contains($"{txtCName.Text}") &&
                                              (txtBNum.Text.Length < 10 ||
                                              company_id.company_bnum.Equals(string.Concat($"{txtBNum.Text.Substring(0, 3)}-{txtBNum.Text.Substring(3, 2)}-{txtBNum.Text.Substring(5)}"))) &&
                                              (cboBtype.SelectedValue.ToString().Equals("전체") || company_id.company_btype.Equals(cboBtype.SelectedValue.ToString())) &&
                                              (cboCompanyType.SelectedValue.ToString().Equals("전체") || company_id.company_type.Equals(cboCompanyType.SelectedValue.ToString()))
                                        select company_id).ToList();
                dgvCompany.DataSource = temp;
                dgvCompany.ClearSelection();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PopCompanyCRUD pop = new PopCompanyCRUD(((FrmMain)this.MdiParent).LoginInfo);
            if(pop.ShowDialog() == DialogResult.OK)
            {
                CompanyRoad();
            }
        }

        private void dgvCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                vo.company_name = list[e.RowIndex].company_name;
                vo.company_type = list[e.RowIndex].company_type;
                vo.company_use = list[e.RowIndex].company_use;
                vo.company_ceo = list[e.RowIndex].company_ceo;
                vo.company_bnum = list[e.RowIndex].company_bnum;
                vo.company_btype = list[e.RowIndex].company_btype;
                vo.company_manager = list[e.RowIndex].company_manager;
                vo.company_email = list[e.RowIndex].company_email;
                vo.company_phone = list[e.RowIndex].company_phone;
                vo.company_faxnum = list[e.RowIndex].company_faxnum;
                vo.company_comment = list[e.RowIndex].company_comment;
                vo.up_date = DateTime.Now;
                vo.company_id = list[e.RowIndex].company_id;

                if (e.ColumnIndex == 0)
                {
                    PopCompanyCRUD pop = new PopCompanyCRUD(((FrmMain)this.MdiParent).LoginInfo, vo);
                    if (pop.ShowDialog() == DialogResult.OK)
                    {
                        CompanyRoad();
                    }
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(vo.company_type))
            {
                MessageBox.Show("삭제할 업체 데이터를 선택해주세요.");
                return;
            }

            if(MessageBox.Show("정말로 삭제하시겠습니까?","경고",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                CompanyService service = new CompanyService();
                if (service.DeleteCompany(vo.company_id))
                {
                    MessageBox.Show("삭제에 성공하였습니다.");
                    CompanyRoad();

                }
                else
                    MessageBox.Show("삭제에 실패하였습니다.");
            }
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            (DataTable, string) data = Util.CommonExcel.ReadExcelData();
            //제대로된 파일을 읽어 왔고 데이터가 있다면
            if (!string.IsNullOrEmpty(data.Item2) && data.Item1.Rows.Count > 0)
            {
                List<CompanyVO> temp = new List<CompanyVO>();

                foreach (DataRow row in data.Item1.Rows)
                {
                    #region 유효성검사
                    if (string.IsNullOrEmpty(row["company_name"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["company_type"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["company_btype"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["company_manager"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["company_use"].ToString()))
                        continue;
                    #endregion
                    try
                    {
                        CompanyVO vo = new CompanyVO
                        {
                            company_name = row["company_name"].ToString(),
                            company_type = row["company_type"].ToString(),
                            company_ceo = row["company_ceo"].ToString(),
                            company_bnum = row["company_bnum"].ToString(),
                            company_btype = row["company_btype"].ToString(),
                            company_manager = row["company_manager"].ToString(),
                            company_email = row["company_email"].ToString(),
                            company_phone = row["company_phone"].ToString(),
                            company_faxnum = row["company_faxnum"].ToString(),
                            company_use = row["company_use"].ToString(),
                            company_comment = row["company_comment"].ToString(),
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

                Service.CompanyService service = new Service.CompanyService();

                if (service.ExcelImportCompany(temp))
                {
                    CompanyRoad();
                }
                else
                {
                    MessageBox.Show("업체 정보를 등록하지 못했습니다.");
                }

            }
            else
                MessageBox.Show("파일을 읽지 못했습니다.");
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvCompany);
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
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/업체등록양식.xlsx", dlg.FileName + ".xlsx");
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
