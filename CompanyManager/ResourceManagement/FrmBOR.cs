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
    public partial class FrmBOR : CompanyManager.MDIBaseForm
    {

        List<CodeVO> codeAllList;
        List<BORVO> borAllList;
        public FrmBOR()
        {
            InitializeComponent();
        }

        private void FrmBOR_Load(object sender, EventArgs e)
        {
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "borid", "bor_id", 150,false);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품목", "Item_id", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "품명", "Item_name", 300);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정", "Bor_route", 150);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정명", "Bor_route_name", 120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비", "Machine_id", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "설비명", "Machine_name", 120);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "Tack Time(Sec)", "Tacktime", 110,true, DataGridViewContentAlignment.MiddleRight);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "우선순위", "Priority", 110, true, DataGridViewContentAlignment.MiddleRight);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "공정선행일(Day)", "preceding_days", 110, true, DataGridViewContentAlignment.MiddleRight);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수율", "Completion_rate", 80);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "사용유무", "Bor_use", 100, true, DataGridViewContentAlignment.MiddleCenter);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "비고", "Bor_comment", 100);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수정자", "emp_name", 110, true, DataGridViewContentAlignment.MiddleCenter);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "수정일", "Ins_date", 300, true, DataGridViewContentAlignment.MiddleCenter);


            LoadBORList();
            
            //dataGridView1.Rows.Add(null, null, "CHAIR_01", "나무 1인용 의자", "B-ASSY", "조립공정", "F_ASSY_01", "최종조립1반", "180", "1", null, null,"사용",null, "관리자","2018-10-28 09:08:16");

            //품목리스트, 공정리스트, 설비리스트, 공통코드

            Service.BORService service = new Service.BORService();
            codeAllList = service.GetBORCode();

            cboRoute.DisplayMember = "name";
            cboRoute.ValueMember = "code";
            List < CodeVO > temp = (from code in codeAllList
                                   where code.category == "ROUTE"
                                   select code).ToList();
            temp.Insert(0, new CodeVO { code = "", name = "전체" });
            cboRoute.DataSource = temp;
            cboRoute.SelectedIndex = 0;
        }

        private void LoadBORList()
        {
            Service.BORService service = new Service.BORService();
            borAllList = service.GetBORList();
            dataGridView1.DataSource = borAllList;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PopUpBOR popup = new PopUpBOR();
            popup.CodeAllList = codeAllList;
            popup.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                Service.BORService service = new Service.BORService();
                List<BORVO> list = new List<BORVO>();
                list.Add(popup.InsertInfo);
                if (!service.AddBORList(list))
                {
                    MessageBox.Show("BOR 정보를 등록하지 못했습니다.");
                }
                else
                {
                    LoadBORList();
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
            var temp = borAllList.Find(p => p.Bor_id == Convert.ToInt32(dataGridView1[2, e.RowIndex].Value));
            PopUpBOR pop = new PopUpBOR();
            pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
            pop.CodeAllList = codeAllList;
            pop.InsertInfo = temp;

            //수정할 값 가져ㅑ와서 수정
            if (pop.ShowDialog() == DialogResult.OK)
            {
                Service.BORService service = new Service.BORService();
                if (!service.EditBOR(pop.InsertInfo))
                {
                    MessageBox.Show("BOR정보를 수정하지 못했습니다.");
                }
                else
                {
                    LoadBORList();
                }

            }
            

        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            (DataTable, string) data = Util.CommonExcel.ReadExcelData();
            //제대로된 파일을 읽어 왔고 데이터가 있다면
            if (!string.IsNullOrEmpty(data.Item2) && data.Item1.Rows.Count > 0)
            {
                List<BORVO> temp = new List<BORVO>();

                foreach (DataRow row in data.Item1.Rows)
                {
                    #region 유효성검사
                    if (string.IsNullOrEmpty(row["품목"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["공정"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["설비"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["Tact Time(Sec)"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["우선순위"].ToString()))
                        continue;
                    if (string.IsNullOrEmpty(row["사용유무"].ToString()))
                        continue;
                    #endregion
                    try
                    {
                        BORVO vo = new BORVO
                        {
                            Item_id = row["품목"].ToString(),
                            Bor_route = row["공정"].ToString(),
                            Machine_id = row["설비"].ToString(),
                            Tacktime = Convert.ToInt32(row["Tact Time(Sec)"].ToString()),
                            preceding_days = row["공정선행일(day)"].ToString() == "" ? 0 : Convert.ToInt32(row["공정선행일(day)"].ToString()),
                            Priority = Convert.ToInt32(row["우선순위"].ToString()),
                            Completion_rate = row["수율"].ToString() == "" ? 0 : Convert.ToDecimal(row["수율"].ToString()),
                            Bor_use = row["사용유무"].ToString(),
                            Bor_comment = row["비고"].ToString(),
                            Ins_date = DateTime.Now,
                            Ins_emp = ((FrmMain)this.MdiParent).LoginInfo.emp_id
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
                Service.BORService service = new Service.BORService();
                
                
                if (!service.AddBORList(temp))
                {
                    MessageBox.Show("BOR 정보를 등록하지 못했습니다.");
                }
                else
                {
                    LoadBORList();
                }

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
                    var temp = borAllList.Find(p => p.Item_id == row.Cells[3].Value.ToString());

                    PopUpBOR pop = new PopUpBOR(true);
                    pop.LoginInfo = ((FrmMain)this.MdiParent).LoginInfo;
                    pop.CodeAllList = codeAllList;
                    pop.InsertInfo = temp;

                    pop.Show();

                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            ////모든컬럼에 or로 검색
            var temp = (from bor in borAllList
                        where bor.Bor_route.Contains(cboRoute.SelectedValue.ToString())
                        select bor).ToList();

            var result = from bor in temp
                          where (bor.Item_name.Contains(txtItmeID.Text) ||
                                bor.Item_id.Contains(txtItmeID.Text) )&&
                                (bor.Machine_name.Contains(txtmachine.Text)||
                                bor.Machine_id.Contains(txtmachine.Text))
                          select bor;



            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.ToList();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "양식 다운로드";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/BOR등록양식.xlsx", dlg.FileName + ".xlsx");
                    //File.Copy("../../ExcelForm/영업마스터양식.xlsx", dlg.FileName+".xlsx");
                    Process.Start(dlg.FileName + ".xlsx");
                }
                catch (Exception err)
                {
                    MessageBox.Show("다운로드중 오류가 발생하였습니다.\r\n 다시 시도하여 주십시오.");
                }
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dataGridView1);
        }
    }
}
