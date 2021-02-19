using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using VO;
using System.IO;
using System.Diagnostics;
using Util;
using System.Net;

namespace CompanyManager
{
    public partial class FrmBOM : CompanyManager.MDIBaseForm
    {
        List<CodeVO> codeAllList;

        List<BOMVO> bomAllList;
        public FrmBOM()
        {
            InitializeComponent();
        }

        private void FrmBOM_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩

            cboUse.ValueMember = "code";
            cbodeployment.ValueMember = "code";


            cboUse.DisplayMember = "name";
            cbodeployment.DisplayMember = "name";
            LoadCombobox();

            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "id", "bom_id", 100,false);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "상위품목", "bom_parent_id", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "item_id", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "item_name", 300);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목유형", "item_type", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "단위", "item_unit", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "소요량", "bom_use_qty", 90);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "BOM레벨", "level", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "시작일", "start_date", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "종료일", "end_date", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "사용여부", "bom_use", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "소요계획", "plan_use", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "자동차감", "auto_deduction", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비", "machine_id", 110);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비명", "machine_name", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "비고", "bom_comment", 220);


            //dataGridView1.Rows.Add(null,null,null);

            //dataGridView1.RowHeadersWidth = 100;
            //MessageBox.Show(dataGridView1.Columns[0].Index.ToString()); 
        }

        private void LoadCombobox()
        {
            Service.BOMService service = new Service.BOMService();
            codeAllList = service.GetBOMCode();

            CodeVO co = new CodeVO { code = "", name = "" };
            List<CodeVO> temp = (from code in codeAllList
                                 where code.category.Equals("USE_FLAG")
                                 select code).ToList();
            temp.Insert(0, co);
            cboUse.DataSource = temp.ConvertAll(p => p);
            cbodeployment.SelectedIndex = 0;
        }

        private void btnAdd_Clickㅠ(object sender, EventArgs e)
        {
            PopUpBOM popup = new PopUpBOM();
            popup.codeAllList = codeAllList;
            popup.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo; //로그인정보 전달
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Service.BOMService service = new Service.BOMService();
                if (!service.AddBOM(popup.InsertList))
                {
                    MessageBox.Show("BOM정보 등록중 오류가 발생했습니다.");
                }
                else
                {
                    LoadCombobox();
                }
            }
            
        }

        private void btnexceladd_Click(object sender, EventArgs e)
        {
            (DataTable, string) data = Util.CommonExcel.ReadExcelData();
            //제대로된 파일을 읽어 왔고 데이터가 있다면
            if (!string.IsNullOrEmpty(data.Item2) && data.Item1.Rows.Count > 0)
            {
                List<BOMVO> temp = new List<BOMVO>();

                foreach (DataRow row in data.Item1.Rows)
                {
                    #region 유효성검사
                    if (string.IsNullOrEmpty(row["상위품목"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["품목"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["소요량"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["시작일"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["종료일"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["사용유무"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["자동차감"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["소요계획"].ToString()))
                        continue;
                    #endregion
                    try
                    {
                        BOMVO vo = new BOMVO();
                        vo.bom_parent_id = row["상위품목"].ToString();
                        vo.item_id = row["품목"].ToString();
                        vo.bom_use_qty = Convert.ToInt32(row["소요량"].ToString());
                        vo.start_date = Convert.ToDateTime(row["시작일"].ToString());
                        vo.end_date = Convert.ToDateTime(row["종료일"].ToString());
                        vo.bom_use = row["사용유무"].ToString() == "Y" ? "U0001" : "U0002";
                        vo.auto_deduction = row["자동차감"].ToString() == "Y" ? "U0001" : "U0002";
                        vo.plan_use = row["소요계획"].ToString() == "Y" ? "U0001" : "U0002";
                        vo.bom_comment = row["비고"].ToString();
                        vo.ins_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id;
                        vo.ins_date = DateTime.Now;

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
                Service.BOMService service = new Service.BOMService();


                if (!service.AddBOM(temp))
                {
                    MessageBox.Show("BOM 정보를 등록하지 못했습니다.");
                }
                else
                {
                    MessageBox.Show("BOM 정보등록했습니다.");
                }
                

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
            var temp = bomAllList.Find(p => p.bom_id == Convert.ToInt32(dataGridView1[2, e.RowIndex].Value));
            PopUpBOM pop = new PopUpBOM();
            pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            pop.codeAllList = codeAllList;
            pop.InsertInfo = temp;

            //수정할 값 가져ㅑ와서 수정
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.BOMService service = new Service.BOMService();
                if (!service.EditBOM(pop.InsertList))
                {
                    MessageBox.Show("BOM정보를 수정하지 못했습니다.");
                }
                else
                {
                    btnSearch.PerformClick();
                }

            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Service.BOMService service = new Service.BOMService();
            if (cbodeployment.Text == "역전개")
            {
                bomAllList = service.GetBOMReverse(txtSubject.Text, dtpdate.Value);
                //정전개 조회
                var temp = from bom in bomAllList
                           where bom.bom_use.Contains(cboUse.Text)
                           select bom;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = temp.ToList();
                dataGridView1.Columns["level"].Visible = false;
            }
            else
            {
               
                bomAllList = service.GetBOMForward(txtSubject.Text, dtpdate.Value);
                //정전개 조회
                var temp = from bom in bomAllList
                           where bom.bom_use.Contains(cboUse.Text)
                           select bom;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = temp.ToList();
                dataGridView1.Columns["level"].Visible = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && ((bool)row.Cells[0].Value))
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
                    var temp = bomAllList.Find(p => p.bom_id == Convert.ToInt32(row.Cells[2].Value.ToString()));

                    PopUpBOM pop = new PopUpBOM(true);
                    pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
                    pop.codeAllList = codeAllList;
                    pop.InsertInfo = temp;

                    pop.Show();

                }
            }

        }

        private void btndownexcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "양식 다운로드";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/BOM등록양식.xlsx", dlg.FileName + ".xlsx");
                    //File.Copy("../../ExcelForm/영업마스터양식.xlsx", dlg.FileName+".xlsx");
                    Process.Start(dlg.FileName + ".xlsx");
                }
                catch (Exception err)
                {
                    MessageBox.Show("다운로드중 오류가 발생하였습니다.\r\n 다시 시도하여 주십시오.");
                }
            }




            
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dataGridView1);
        }
    }
}
