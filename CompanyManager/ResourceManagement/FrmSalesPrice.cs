using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class FrmSalesPrice : CompanyManager.MDIBaseForm
    {
        HttpClient client = new HttpClient();
        List<PriceVO> priceList = new List<PriceVO>();
        ApiHelper service = new ApiHelper();
        List<CompanyCodeVO> companyLsit = new List<CompanyCodeVO>();
        ApiMessage<List<CompanyCodeVO>> company;
        string url = "/api/price/";
        public FrmSalesPrice()
        {
            InitializeComponent();
        }


        private void FrmSalesPrice_Load(object sender, EventArgs e)
        {
            //그리드뷰 초기화
            CommonUtil.SetInitGridView(dgvPrice);
            CommonUtil.SetDGVDesign_Num(dgvPrice);
            dgvPrice.RowHeadersVisible = true;
            CommonUtil.AddGridImageColumn(dgvPrice, Properties.Resources.Edit_16x16, "Edit", 40);
            CommonUtil.AddGridTextColumn(dgvPrice, "품목", "item_id", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "품명", "item_name", 120);
            CommonUtil.AddGridTextColumn(dgvPrice, "단위", "item_unit", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "환종", "price_currency", 60);
            CommonUtil.AddGridTextColumn(dgvPrice, "현재단가", "now", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "이전단가", "before", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "시작일", "price_sdate", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "종료일", "price_edate", 80);
            CommonUtil.AddGridTextColumn(dgvPrice, "비고", "price_comment", 250);

            //자재단가 불러오기 , 그리드뷰에 바인딩
            GetPriceList();
            //콤보박스 바인딩
            company = service.GetApiCaller<List<CompanyCodeVO>>($"{url}companyList");
            companyLsit = company.Data;
            companyLsit.Insert(0, new CompanyCodeVO() { company_id = -1, company_name = "전체" });
            CommonUtil.BindingComboBox(cboCompany, companyLsit, "company_id", "company_name");
        }

        private void GetPriceList()
        {
            ApiMessage<List<PriceVO>> pirce = service.GetApiCaller<List<PriceVO>>($"{url}S");
            dgvPrice.DataSource = priceList = pirce.Data;
        }
        private void btnNewPrice_Click(object sender, EventArgs e)
        {
            PopupSalesPrice popup = new PopupSalesPrice(priceList, companyLsit);
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                GetPriceList();
                btnSearch.PerformClick();
            }
        }

        private void dgvPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            PriceVO price = priceList.Find((elem) => elem.item_id.Equals(dgvPrice.Rows[e.RowIndex].Cells[1].Value.ToString()) && elem.price_edate.Equals(new DateTime(9999, 01, 01)));
            //priceList[e.RowIndex];
            PopupSalesPrice popup = new PopupSalesPrice(price.company_name, price.item_name, price.price_currency, price.now);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ItemID = price.item_id;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                GetPriceList();
                btnSearch.PerformClick();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var sResult = (from price
                           in priceList
                           where
                           (price.price_edate > dtpBaseDate.Value && price.price_sdate < dtpBaseDate.Value) &&
                           (txtItem.Text.Trim().Length < 0 || price.item_name.Contains(txtItem.Text)) &&
                           (Convert.ToInt32(cboCompany.SelectedValue) == -1 || price.company_id.Equals(cboCompany.SelectedValue))
                           select price).ToList();
            dgvPrice.DataSource = null;
            dgvPrice.DataSource = sResult;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            PopupPriceExcel popup = new PopupPriceExcel("PT002");
            popup.StartPosition = FormStartPosition.CenterParent;
            if (popup.ShowDialog() == DialogResult.OK)
            {
                GetPriceList();
                btnSearch.PerformClick();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dgvPrice);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "양식 다운로드";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(@"http://gdfinal.azurewebsites.net/ExcelForm/단가등록양식.xlsx", dlg.FileName + ".xlsx");
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
