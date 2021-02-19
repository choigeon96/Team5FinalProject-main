using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class PopupPriceExcel : CompanyManager.PopupBaseForm
    {
        List<PriceVO> list = new List<PriceVO>();
        ApiHelper service = new ApiHelper();
        string url = "/api/price/";
        string priceType = string.Empty;
        public PopupPriceExcel(string priceType)
        {
            InitializeComponent();
            this.priceType = priceType;
        }

        private void PopupPriceExcel_Load(object sender, EventArgs e)
        {
            CommonUtil.SetInitGridView(dgvPrice);
            CommonUtil.SetDGVDesign_Num(dgvPrice);
            CommonUtil.AddGridTextColumn(dgvPrice, "품목번호", "item_id", 60, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPrice, "품목명", "item_name", 100);
            CommonUtil.AddGridTextColumn(dgvPrice, "환종", "price_currency", 80, true, DataGridViewContentAlignment.MiddleCenter);
            CommonUtil.AddGridTextColumn(dgvPrice, "단가", "now", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvPrice, "비고", "price_comment", 80);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            dgvPrice.Rows.Clear();
            (DataTable dt, string fileName) = CommonExcel.ReadExcelData();
            txtFileName.Text = fileName;
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                PriceVO price = new PriceVO
                {
                    item_id = dt.Rows[i]["품목번호"].ToString(),
                    item_name = dt.Rows[i]["품목명"].ToString(),
                    now = Convert.ToDecimal(dt.Rows[i]["단가"]),
                    price_comment = dt.Rows[i]["비고"].ToString(),
                    price_sdate = DateTime.Now,
                    price_type = priceType,
                    price_currency = dt.Rows[i]["환종"].ToString(),
                };
                list.Add(price);
            }
            dgvPrice.DataSource = list;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApiMessage msg = service.PostApiCallerNone<List<PriceVO>>($"{url}ImportExcel", list);

            MessageBox.Show(msg.ResultMessage);

            if (msg.ResultCode.Equals("S"))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
