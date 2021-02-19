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
    public partial class FrmFactoryList : CompanyManager.MDIBaseForm
    {
        List<FactoryVO> list = new List<FactoryVO>();
        List<FactoryVO> chklist = new List<FactoryVO>();
        List<FactoryVO> chklist2 = new List<FactoryVO>();
        FactoryVO fvo = new FactoryVO();
        public FrmFactoryList()
        {
            InitializeComponent();
        }

        private void FrmFactoryList_Load(object sender, EventArgs e)
        {
            GetdgvColumn();
            DataRoad();
            RoadCombobox();
        }

        private void GetdgvColumn()
        {
            CommonUtil.SetDGVDesign_Num(dgvFactory);

            CommonUtil.SetDGVDesign_CheckBox(dgvFactory);
            CommonUtil.AddGridImageColumn(dgvFactory, Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설군", "factory_grade");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설구분", "factory_type");
            CommonUtil.AddGridTextColumn(dgvFactory, "시설명", "factory_name", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "상위시설", "factory_parent", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "시설설명", "factory_comment", 150);
            CommonUtil.AddGridTextColumn(dgvFactory, "사용유무", "factory_use");
            CommonUtil.AddGridTextColumn(dgvFactory, "수정자", "up_emp", 120);
            CommonUtil.AddGridTextColumn(dgvFactory, "수정시간", "up_date", 160);
            CommonUtil.AddGridTextColumn(dgvFactory, "id", "factory_id", 100, false);

            dgvFactory.AutoGenerateColumns = false;
            dgvFactory.AllowUserToAddRows = false;
        }

        private void DataRoad()
        {
            FactoryService service = new FactoryService();

            list = service.GetFactory();

            dgvFactory.DataSource = list;
            dgvFactory.ClearSelection();
        }

        private void RoadCombobox()
        {
            CodeService service = new CodeService();
            List<CodeVO> combobox = service.GetAllCommonCode();

            cboFGrade.DisplayMember = "name";
            cboFGrade.ValueMember = "name";
            List<CodeVO> temp = (from code in combobox
                                 where code.category == "FACTORY_GRADE"
                                 select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "전체" });
            cboFGrade.DataSource = temp;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            PopFactoryCRUD pop = new PopFactoryCRUD(((FrmMain)this.MdiParent).LoginInfo);
            if (pop.ShowDialog() == DialogResult.OK)
            {
                DataRoad();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtCodeName.Text.Length < 1 && cboFGrade.SelectedIndex == 0)
            {
                DataRoad();
            }
            else if (txtCodeName.Text.Length > 0 && cboFGrade.SelectedIndex != 0)
            {
                var sResult = (from factory_grade
                               in list
                               where
                               factory_grade.factory_name.Contains(txtCodeName.Text) && factory_grade.factory_grade.Equals(cboFGrade.SelectedValue)
                               select factory_grade).ToList();
                dgvFactory.DataSource = null;
                dgvFactory.DataSource = sResult;
            }
            else if(txtCodeName.Text.Length > 0 && cboFGrade.SelectedIndex == 0)
            {
                var sResult = (from factory_grade
                            in list
                                where
                                factory_grade.factory_name.Contains(txtCodeName.Text)
                                select factory_grade).ToList();
                dgvFactory.DataSource = null;
                dgvFactory.DataSource = sResult;
            }
            else
            {
                var sResult = (from factory_grade
                               in list
                               where
                               factory_grade.factory_grade.Equals(cboFGrade.SelectedValue)
                               select factory_grade).ToList();
                dgvFactory.DataSource = null;
                dgvFactory.DataSource = sResult;
            }

        }

        private void dgvFactory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                fvo.factory_id = list[e.RowIndex].factory_id;
                fvo.factory_grade = list[e.RowIndex].factory_grade;
                fvo.factory_type = list[e.RowIndex].factory_type;
                fvo.factory_name = list[e.RowIndex].factory_name;
                fvo.factory_parent = list[e.RowIndex].factory_parent;
                fvo.factory_comment = list[e.RowIndex].factory_comment;
                fvo.factory_use = list[e.RowIndex].factory_use;
                fvo.codename = list[e.RowIndex].codename;
                if (e.ColumnIndex == 1)
                {
                    if(list[e.RowIndex].codename == "공장")
                    {
                        PopFactoryCRUD pop = new PopFactoryCRUD(((FrmMain)this.MdiParent).LoginInfo, fvo, true);
                        if (pop.ShowDialog() == DialogResult.OK)
                        {
                            DataRoad();
                        }
                    }
                    else
                    {
                        PopFactoryCRUD pop = new PopFactoryCRUD(((FrmMain)this.MdiParent).LoginInfo, fvo, true, true);
                        if (pop.ShowDialog() == DialogResult.OK)
                        {
                            DataRoad();
                        }
                    }
                    
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvFactory.RowCount; i++)
            {
                if (dgvFactory[0, i].Value != null && (bool)dgvFactory[0, i].Value)
                {
                    if (list[i].factory_grade == "창고")
                        chklist2.Add(list[i]);
                    else
                        chklist.Add(list[i]);
                }
                //else
                //{
                //    var temp = chklist.Find(p => p.factory_id == list[i].factory_id );
                //    chklist.Remove(temp);
                //}
            }

            if (chklist.Count < 1 && chklist2.Count < 1)
            {
                MessageBox.Show("삭제할 데이터를 선택해주세요.");
                return;
            }
            if (MessageBox.Show($"정말로 삭제하시겠습니까?", "경고", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                FactoryService service = new FactoryService();
                if (service.DeleteFactory(chklist) && service.DeleteWareHouse(chklist2))
                {
                    MessageBox.Show("삭제되었습니다.");
                    chklist.Clear();
                    chklist2.Clear();
                    DataRoad();
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
                List<FactoryVO> temp = new List<FactoryVO>();
                List<FactoryVO> temp2 = new List<FactoryVO>();

                foreach (DataRow row in data.Item1.Rows)
                {
                    #region 유효성검사
                    if (string.IsNullOrEmpty(row["factory_grade"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["factory_type"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["factory_name"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["factory_parent"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["factory_use"].ToString()))
                        continue;
                    #endregion
                    try
                    {
                        FactoryVO vo = new FactoryVO
                        {
                            factory_grade = row["factory_grade"].ToString(),
                            factory_type = row["factory_type"].ToString(),
                            factory_name = row["factory_name"].ToString(),
                            factory_parent = row["factory_parent"].ToString(),
                            factory_use = row["factory_use"].ToString(),
                            factory_comment = row["factory_comment"].ToString(),
                            up_date = DateTime.Now,
                            up_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id
                        };
                        if (vo.factory_grade == "창고")
                        {
                            temp2.Add(vo);
                        }
                        else
                        {
                            temp.Add(vo);
                        }
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

                Service.FactoryService service = new Service.FactoryService();

                if (service.ExcelImportFactory(temp) && service.ExcelImportWareHouse(temp2))
                {
                    DataRoad();
                }
                else
                {
                    MessageBox.Show("공장 창고 정보를 등록하지 못했습니다.");
                }

            }
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvFactory);
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
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/공창창고등록양식.xlsx", dlg.FileName + ".xlsx");
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
