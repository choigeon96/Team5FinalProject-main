using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmSOUpload : CompanyManager.MDIBaseForm
    {
        DataTable dt;
        List<SalesOrderVO> list = new List<SalesOrderVO>();
        public FrmSOUpload()
        {
            InitializeComponent();

        }



        private void FrmSOUpload_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvSO);
            CommonUtil.SetDGVDesign_Num(dgvSO);
            dgvSO.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvSO, "planDate", "planDate", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "WORK_ORDER_ID", "고객 주문번호", 150, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "업체", "업체 ID", 60);
            CommonUtil.AddGridTextColumn(dgvSO, "업체명", "납품처", 100);
            CommonUtil.AddGridTextColumn(dgvSO, "품목", "품목", 80);
            CommonUtil.AddGridTextColumn(dgvSO, "품명", "품목명", 120);
            CommonUtil.AddGridTextColumn(dgvSO, "MKT", "MKT", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "환종", "환종", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "수량", "수량", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "납기일", "납기일", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvSO, "비고", "비고", 200, true);


        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            PopupSoUpload popup = new PopupSoUpload();
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                if (popup.DT == null)
                {
                    MessageBox.Show("파일을 불러오는중 오류가 발생하였습니다.");
                    return;
                }
                dgvSO.DataSource = dt = popup.DT;
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSO.Rows.Count < 1)
                {
                    MessageBox.Show("파일을 먼저 등록해주십시오.");
                    return;
                }
                list.Clear();
                foreach (DataGridViewRow row in dgvSO.Rows)
                {
                    SalesOrderVO sales = new SalesOrderVO()
                    {
                        plan_date = Convert.ToDateTime(row.Cells["planDate"].Value),
                        order_id = row.Cells["고객 주문번호"].Value.ToString(),
                        company_id = Convert.ToInt32(row.Cells["업체 ID"].Value),
                        mkt = row.Cells["MKT"].Value.ToString().Equals("내수") ? "MKT01" : "MKT02",
                        item_id = row.Cells["품목"].Value.ToString(),
                        currency = row.Cells["환종"].Value.ToString(),
                        so_o_qty = Convert.ToInt32(row.Cells["수량"].Value),
                        due_date = Convert.ToDateTime(row.Cells["납기일"].Value),
                        so_comment = row.Cells["비고"].Value == null ? string.Empty : row.Cells["비고"].Value.ToString(),
                    };
                    list.Add(sales);
                }
                SalesOrderService service = new SalesOrderService();
                bool result = service.CommitSO(list);
                if (result)
                {
                    MessageBox.Show("영업마스터가 생성되었습니다.");
                    dgvSO.DataSource = null;
                }
                else
                    MessageBox.Show("영업마스터 생성중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");
            }
            catch (Exception err)
            {
                MessageBox.Show("영업마스터 생성중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오.");
            }
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
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/영업마스터양식.xlsx", dlg.FileName + ".xlsx");
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
