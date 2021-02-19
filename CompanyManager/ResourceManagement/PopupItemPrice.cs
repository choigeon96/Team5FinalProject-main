using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Util;
using VO;

namespace CompanyManager
{
    public partial class PopupItemPrice : CompanyManager.PopupBaseForm
    {
        ApiHelper service = new ApiHelper();
        string url = "/api/price/";
        List<ItemCodeVO> items = new List<ItemCodeVO>();
        List<CompanyCodeVO> companys = new List<CompanyCodeVO>();
        List<PriceVO> price = new List<PriceVO>();
        public string ItemID = string.Empty;
        string companyName, itemName, currency;
        bool IsEdit = false;

        public PopupItemPrice(List<PriceVO> price, List<CompanyCodeVO> company)
        {
            InitializeComponent();
            this.price = price;
            this.companys = company;
        }

        public PopupItemPrice(string companyName, string itemName, string currency, decimal before)
        {
            InitializeComponent();
            cboCompany.Enabled = cboItem.Enabled = cboCurrency.Enabled = txtBeforePrice.Enabled = false;
            cboCompany.DropDownStyle = cboItem.DropDownStyle = ComboBoxStyle.DropDown;
            cboCompany.Text = companyName;
            cboItem.Text = itemName;
            cboCurrency.Text = currency;
            txtBeforePrice.Text = before.ToString();
            IsEdit = true;
        }

        private void PopupItemPrice_Load(object sender, EventArgs e)
        {
            if (ItemID.Length > 0 || IsEdit)
                return;
            //콤보박스 바인딩
            CommonUtil.BindingComboBox(cboCompany, companys, "company_id", "company_name");
            ApiMessage<List<ItemCodeVO>> item = service.GetApiCaller<List<ItemCodeVO>>($"{url}itemList");
            items = item.Data;

            CodeService code = new CodeService();
            string[] categorys = { "currency" };
            Dictionary<string, List<CodeVO>> codeList = code.GetCommonCode(categorys);
            CommonUtil.BindingComboBox(cboCurrency, codeList["currency"], "code", "name");
        }




        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsEdit)
                return;
            cboItem.DataSource = null;
            if (ItemID.Length > 0)
                return;
            if (string.IsNullOrEmpty(cboCompany.Text))
                return;
            var cItem = (from item
                         in items
                         where item.supply_company.Equals(cboCompany.SelectedValue)
                         select item).ToList();
            if (cItem.Count < 1)
                return;
            CommonUtil.BindingComboBox(cboItem, cItem, "item_id", "item_name");
        }

        private void cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ItemID.Length > 0 || IsEdit)
                return;
            decimal before = 0;
            try
            {
                before = (from v
                          in price
                          where v.item_id.Equals(cboItem.SelectedValue) && v.price_edate > dtpStartDate.Value
                                && v.price_currency.Equals(cboCurrency.SelectedValue.ToString())
                          select v.now).ToArray()[0];
            }
            catch
            {
                before = 0;
            }

            txtBeforePrice.Text = ((int)before).ToString();
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboItem_SelectedIndexChanged(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PriceVO newPrice = new PriceVO
            {
                now = Convert.ToDecimal(txtNowPrice.Text),
                item_id = ItemID.Length < 1 ? cboItem.SelectedValue.ToString() : ItemID,
                price_sdate = dtpStartDate.Value,
                price_comment = txtComment.Text,
                price_type = "PT001",
                price_currency = cboCurrency.Text
            };
            ApiMessage msg = service.PostApiCallerNone<PriceVO>($"{url}InsUpPrice", newPrice);

            MessageBox.Show(msg.ResultMessage);

            if (msg.ResultCode.Equals("S"))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
