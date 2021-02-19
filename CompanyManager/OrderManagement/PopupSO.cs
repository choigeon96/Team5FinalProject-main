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


    public partial class PopupSO : CompanyManager.PopupBaseForm
    {
        SalesOrderVO so = null;
        SalesOrderService service = new SalesOrderService();
        List<CodeVO> codes = null;

        public PopupSO(List<CodeVO> codes, SalesOrderVO so)
        {
            InitializeComponent();
            this.so = so;
            this.codes = codes;
            cboCompany.Enabled = cboItem.Enabled = cboCurrency.Enabled = cboMkt.Enabled = txtSQty.Enabled = false;
            //cboCompany.Text = so.company_name;
            txtOrderID.Text = string.IsNullOrEmpty(so.order_id) ? string.Empty : so.order_id;
            BindingComboBox(codes);
            cboCompany.SelectedItem = ((List<CodeVO>)cboCompany.DataSource).Find(e => e.code.Equals(so.company_id.ToString()));
            cboItem.SelectedItem = ((List<CodeVO>)cboItem.DataSource).Find(e => e.code.Equals(so.item_id));
            cboMkt.SelectedItem = ((List<CodeVO>)cboMkt.DataSource).Find(e => e.code.Equals(so.mkt));
            cboCurrency.SelectedItem = ((List<CodeVO>)cboCurrency.DataSource).Find(e => e.code.Equals(so.currency));
            CodeVO warehouse = ((List<CodeVO>)cboDest.DataSource).Find(e => e.name.Equals(so.warehouse_name));
            cboDest.SelectedIndex = warehouse == null ? 0 : cboDest.Items.IndexOf(warehouse);
            txtOQty.Text = so.so_o_qty.ToString();
            txtCQty.Text = so.so_c_qty.ToString();
            txtSQty.Text = so.so_s_qty.ToString();
            dtpDueDate.Value = so.due_date;
            txtComment.Text = string.IsNullOrEmpty(so.so_comment) ? string.Empty : so.so_comment;
            btnSave.Text = "수정";

            txtOQty.LostFocus += TxtOQty_LostFocus;
            txtCQty.LostFocus += TxtOQty_LostFocus;
        }

        public PopupSO(List<CodeVO> codes)
        {
            InitializeComponent();
            this.codes = codes;
            BindingComboBox(codes);
            txtCQty.Enabled = false;
        }

        private void TxtOQty_LostFocus(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            int qty = Convert.ToInt32(((TextBox)sender).Text);
            if ((txt.Equals(txtOQty) && so.so_o_qty > qty))
            {
                txt.Text = so.so_o_qty.ToString();
                MessageBox.Show("기존 수량보다 적은 값은 입력할 수 없습니다.");
            }
            if ((txt.Equals(txtCQty) && so.so_c_qty > qty))
            {
                txt.Text = so.so_c_qty.ToString();
                MessageBox.Show("기존 수량보다 적은 값은 입력할 수 없습니다.");
            }
            else if (txt.Equals(txtCQty) && so.so_o_qty < qty)
            {
                txt.Text = so.so_c_qty.ToString();
                MessageBox.Show("취소량은 주문량보다 적어야합니다.");
            }
        }

        private void BindingComboBox(List<CodeVO> codes)
        {
            var companys = (from company in codes where company.category.Equals("COMPANY") select company).ToList();
            companys.Insert(0, new CodeVO() { code = "", name = "선택" });
            var items = (from item in codes where item.category.Equals("ITEM") select item).ToList();
            items.Insert(0, new CodeVO() { code = "", name = "선택" });
            var warehouses = (from warehouse in codes where warehouse.category.Equals("WAREHOUSE") select warehouse).ToList();
            warehouses.Insert(0, new CodeVO() { code = "", name = "선택" });
            var markets = (from market in codes where market.category.Equals("MARKET") select market).ToList();
            markets.Insert(0, new CodeVO() { code = "", name = "선택" });
            var currencies = (from currency in codes where currency.category.Equals("CURRENCY") select currency).ToList();
            currencies.Insert(0, new CodeVO() { code = "", name = "선택" });
            CommonUtil.BindingComboBox(cboCompany, companys, "code", "name");
            CommonUtil.BindingComboBox(cboItem, items, "code", "name");
            CommonUtil.BindingComboBox(cboDest, warehouses, "code", "name");
            CommonUtil.BindingComboBox(cboMkt, markets, "code", "name");
            CommonUtil.BindingComboBox(cboCurrency, currencies, "code", "name");
        }

        private void PopupSO_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool result = false;
            string msg = string.Empty;
            if (so == null)
            {
                if (cboCurrency.SelectedValue.ToString().Length < 1 ||
                    cboMkt.SelectedValue.ToString().Length < 1 ||
                    cboCompany.SelectedValue.ToString().Length < 1 ||
                    cboItem.SelectedValue.ToString().Length < 1 ||
                    txtOQty.Text.Length < 1
                    )
                {
                    MessageBox.Show("필수항목을 모두 입력해주십시오.");
                    return;
                }
                SalesOrderVO so = new SalesOrderVO()
                {
                    company_id = Convert.ToInt32(cboCompany.SelectedValue),
                    order_id = txtOrderID.Text,
                    warehouse_id = cboDest.SelectedValue.ToString().Length < 1 ? string.Empty : cboDest.SelectedValue.ToString(),
                    item_id = cboItem.SelectedValue.ToString(),
                    due_date = dtpDueDate.Value,
                    so_o_qty = Convert.ToInt32(txtOQty.Text),
                    so_s_qty = txtSQty.Text.Length < 1 ? 0 : Convert.ToInt32(txtSQty.Text),
                    so_c_qty = txtCQty.Text.Length < 1 ? 0 : Convert.ToInt32(txtCQty.Text),
                    plan_date = DateTime.Now,
                    mkt = cboMkt.SelectedValue.ToString(),
                    currency =cboCurrency.SelectedValue.ToString(),
                    so_comment = txtComment.Text,
                };
                result = service.InsertSO(so);
            }
            else
            {
                so.order_id = txtOrderID.Text;
                so.warehouse_id = cboDest.SelectedValue.ToString();
                so.due_date = dtpDueDate.Value;
                so.so_o_qty = Convert.ToInt32(txtOQty.Text);
                so.so_c_qty = Convert.ToInt32(txtCQty.Text);
                so.so_comment = txtComment.Text;
                so.up_emp = "1";
                so.up_date = DateTime.Now;
                result = service.UpdateSO(so);
            }
            if (result)
            {
                MessageBox.Show("등록 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

    }
}

