using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using VO;
using Util;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace CompanyManager
{
    public partial class FrmSubjectManagement : CompanyManager.MDIBaseForm
    {
        List<CodeVO> codeAllList; //콤보박스 바인딩 데이터
        List<SubjectVO> subjectAllList;
        public FrmSubjectManagement()
        {
            InitializeComponent();
        }

        private void FrmSubjectManagement_Load(object sender, EventArgs e)
        {

            //콤보박스 설정


            cboOrderC.ValueMember = "code";
            cboWarehouseIN.ValueMember = "code";
            cboWarehouseOUT.ValueMember = "code";
            cboSubjectType.ValueMember = "code";
            cboUse.ValueMember = "code";
            cboSupplyC.ValueMember = "code";
            cboOrderC.DisplayMember = "Name";
            cboWarehouseIN.DisplayMember = "Name";
            cboWarehouseOUT.DisplayMember = "Name";
            cboSubjectType.DisplayMember = "Name";
            cboUse.DisplayMember = "Name";
            cboSupplyC.DisplayMember = "Name";
            LoadCombobox();


            // 그리드 뷰 설정
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.SetDGVDesign_CheckBox(dataGridView1);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목유형", "Item_type", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "Item_id", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "Item_name", 300);
            //Util.CommonUtil.AddGridTextColumn(dataGridView1, "규격", "", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위", "Item_unit", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위수량", "Item_unit_qty", 100);
            //Util.CommonUtil.AddGridTextColumn(dataGridView1, "환산단위", "", 100);
            //Util.CommonUtil.AddGridTextColumn(dataGridView1, "환산수량", "", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수입검사여부", "Import_inspection", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정검사여부", "Process_inspection", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "출하검사여부", "Shipment_inspection", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단종유무", "Extinction", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "유무상구분", "Free_of_charge", 120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "납품업체", "Supply_company", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "발주업체", "Order_company", 150);
            LoadSubjectList();

            //dataGridView1.Rows.Add(null, null, "반제품", "BACK_a02", "등받이", "5 x 12 inch", "EA", "0", null, null, "미사용", "미사용", "미사용", "미사용", null, "(주)에이더블유", "(주)에이더블유");


        }

        private void LoadSubjectList()
        {
            Service.SubjectService service = new Service.SubjectService();
            subjectAllList = service.GetSubjectList();

            dataGridView1.DataSource = subjectAllList;
        }

        //콤보박스 바인딩
        private void LoadCombobox()
        {
            Service.SubjectService service = new Service.SubjectService();
            codeAllList = service.GetSubjectCode();

            List<CodeVO> temp;
            CodeVO co = new CodeVO { code = "", name = "" };

            //발주업체, 납품업체
            temp = (from code in codeAllList
                    where code.category.Equals("company")
                    select code).ToList();
            temp.Insert(0, co);
            cboOrderC.DataSource = temp;
            cboSupplyC.DataSource = temp.ConvertAll(p => p);

            //입고창고
            temp = (from code in codeAllList
                    where code.category.Equals("warehouse")
                    select code).ToList();
            temp.Insert(0, co);
            cboWarehouseIN.DataSource = temp;

            //출고창고
            temp = (from code in codeAllList
                    where code.category.Equals("warehouse")
                    select code).ToList();
            temp.Insert(0, co);
            cboWarehouseOUT.DataSource = temp;

            //품목유형
            temp = (from code in codeAllList
                    where code.category.Equals("ITEM_TYPE")
                    select code).ToList();
            temp.Insert(0, co);
            cboSubjectType.DataSource = temp;

            //사용유무
            temp = (from code in codeAllList
                    where code.category.Equals("USE_FLAG")
                    select code).ToList();
            temp.Insert(0, co);
            cboUse.DataSource = temp;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PopUpSubject popup = new PopUpSubject();
            popup.CodeAllList = codeAllList;
            popup.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Service.SubjectService service = new Service.SubjectService();
                List<SubjectVO> temp = new List<SubjectVO>();
                temp.Add(popup.InsertInfo);
                if (!service.AddSubject(temp))
                {
                    MessageBox.Show("품목등록 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadSubjectList();
                }
                
            }
           
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (btnDown.Text == "V")
            {
                btnDown.Text = "ᐱ";
                int size = this.Size.Height;
                btnDown.Location = new Point(btnDown.Location.X, 71);
                btnSearch.Location = new Point(btnSearch.Location.X, 71);



                pnlSearch.Size = new Size(pnlSearch.Size.Width, 114);
                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance + 38;

            }
            else
            {
                btnDown.Text = "V";

                cboUse.SelectedIndex = 0;
                cboSubjectType.SelectedIndex = 0;

                btnDown.Location = new Point(btnDown.Location.X, 38);
                btnSearch.Location = new Point(btnSearch.Location.X, 38);
                pnlSearch.Size = new Size(pnlSearch.Size.Width, pnlSearch.Size.Height * 2 / 3);


                splitContainer1.SplitterDistance = splitContainer1.SplitterDistance - 38;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                EditCode(e);
            }
        }
        private void EditCode(DataGridViewCellEventArgs e)
        {
            //수정할 코드 정보 팝업창에 로드


            //해당 행의 정보를찾아서 팝업창에 등록
            var temp = subjectAllList.Find(p => p.Item_id == dataGridView1[3, e.RowIndex].Value.ToString());
            PopUpSubject pop = new PopUpSubject();
            pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            pop.CodeAllList = codeAllList;
            pop.InsertInfo = temp;

            //수정할 값 가져ㅑ와서 수정
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.SubjectService service = new Service.SubjectService();

                if (!service.EditSubject(pop.InsertInfo))
                {
                    MessageBox.Show("코드수정 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadSubjectList();
                }
            }

        }

       
        //엑셀 등록
        private void btnExcelInsert_Click(object sender, EventArgs e)
        {
            (DataTable, string) data = Util.CommonExcel.ReadExcelData();

            //제대로된 파일을 읽어 왔고 데이터가 있다면
            if (!string.IsNullOrEmpty(data.Item2) && data.Item1.Rows.Count > 0)
            {
                List<SubjectVO> temp = new List<SubjectVO>();

                foreach (DataRow row in data.Item1.Rows)
                {
                    #region 유효성검사
                    if (string.IsNullOrEmpty(row["품목"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["품명"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["단위"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["품목유형"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["수입검사여부"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["공정검사여부"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["출하검사여부"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["사용유무"].ToString()))
                    {
                        continue;
                    }
                    if (string.IsNullOrEmpty(row["단종유무"].ToString()))
                    {
                        continue;
                    }
                    #endregion
                    try
                    {
                        SubjectVO vo = new SubjectVO
                        {
                            Item_id = row["품목"].ToString(),
                            Item_name = row["품명"].ToString(),
                            Item_unit = row["단위"].ToString(),
                            Item_unit_qty = row["단위수량"].ToString() == "" ? 0 : Convert.ToInt32(row["단위수량"].ToString()),
                            Item_type = row["품목유형"].ToString(),
                            Import_inspection = row["수입검사여부"].ToString() == "Y" ? "U0001" : "U0002",
                            Process_inspection = row["공정검사여부"].ToString() == "Y" ? "U0001" : "U0002",
                            Shipment_inspection = row["출하검사여부"].ToString() == "Y" ? "U0001" : "U0002",
                            Free_of_charge = row["유무상구분"].ToString() == "Y" ? "U0001" : "U0002",
                            Order_company = row["발주업체"].ToString(),
                            Supply_company = row["납품업체"].ToString(),
                            Item_leadtime = row["Lead Time"].ToString() == "" ? 0 : Convert.ToInt32(row["Lead Time"].ToString()),
                            Item_lorder_qty = row["최소발주수량"].ToString() == "" ? 0 : Convert.ToInt32(row["최소발주수량"].ToString()),
                            Item_delivery_qty = row["표준불출수량"].ToString() == "" ? 0 : Convert.ToInt32(row["표준불출수량"].ToString()),
                            Item_safety_qty = row["안전재고수량"].ToString() == "" ? 0 : Convert.ToInt32(row["안전재고수량"].ToString()),
                            In_warehouse = row["입고창고"].ToString(),
                            Out_warehouse = row["출고창고"].ToString(),
                            Item_grade = row["관리등급"].ToString(),
                            Item_manager = row["담당자"].ToString(),
                            Item_comment = row["비고"].ToString(),
                            Item_use = row["사용유무"].ToString() == "Y" ? "U0001" : "U0002",
                            Extinction = row["단종유무"].ToString() == "Y" ? "U0001" : "U0002",
                            Up_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id,
                            Up_date = DateTime.Now
                        };
                        temp.Add(vo);
                    }
                    catch(Exception err)
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
                Service.SubjectService service = new Service.SubjectService();
                if (!service.AddSubject(temp))
                {
                    MessageBox.Show("품목등록 중 오류가 발생하였습니다.");
                }
                else
                {
                    LoadSubjectList();
                }

            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            

            //모든컬럼에 or로 검색
            var result = from  subject in subjectAllList
                         where subject.Item_id.ToLower().Contains(txtSubject.Text.Trim().ToLower()) &&
                               (subject.Order_company == null ? "": subject.Order_company.ToLower()).Contains(cboOrderC.Text.Trim().ToLower()) &&
                               (subject.Supply_company == null ? "" : subject.Supply_company).ToLower().Contains(cboSupplyC.Text.Trim().ToLower()) &&
                               (subject.In_warehouse == null ? "" : subject.In_warehouse).ToLower().Contains(cboWarehouseIN.Text.Trim().ToLower()) &&
                               (subject.Out_warehouse == null ? "" : subject.Out_warehouse).ToLower().Contains(cboWarehouseOUT.Text.Trim().ToLower()) &&
                               (subject.Item_manager == null ? "" : subject.Item_manager).ToLower().Contains(txtManager.Text.Trim().ToLower()) &&
                               subject.Item_type.ToLower().Contains(cboSubjectType.Text.Trim().ToLower()) &&
                               subject.Item_use.ToLower().Contains(cboUse.Text.Trim().ToLower()) 
                         select subject;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.ToList();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value!= null && ((bool)row.Cells[0].Value))
                {
                    count++;
                }
            }

            if (count > 1)
            {
                MessageBox.Show("한개의 항목만 선택해주세요");
                return;
            }
            else if (count == 0)
            {
                MessageBox.Show("항목을 선택해주세요");
                return;
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && ((bool)row.Cells[0].Value))
                {
                    var temp = subjectAllList.Find(p => p.Item_id == row.Cells[3].Value.ToString());

                    PopUpSubject pop = new PopUpSubject(false);
                    pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
                    pop.CodeAllList = codeAllList;
                    pop.InsertInfo = temp;

                    pop.Show();

                }
            }



            //해당 행의 정보를찾아서 팝업창에 등록
            //var temp = subjectAllList.Find(p => p.Item_id == dataGridView1[3, e.RowIndex].Value.ToString());
            //PopUpSubject pop = new PopUpSubject(true);
            //pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            //pop.CodeAllList = codeAllList;
            //pop.InsertInfo = temp;

            ////수정할 값 가져ㅑ와서 수정
            //pop.ShowDialog();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dataGridView1);
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
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/품목등록양식.xlsx", dlg.FileName + ".xlsx");
                    //File.Copy("../../ExcelForm/영업마스터양식.xlsx", dlg.FileName+".xlsx");
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

