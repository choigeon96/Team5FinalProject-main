using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;
using Service;
using VO;
using System.Linq;

namespace CompanyManager
{
    public partial class PopupPurchase : CompanyManager.PopupBaseForm
    {
        PurchaseService service = new PurchaseService();
        List<PurchasesVO> list;
        public PopupPurchase()
        {
            InitializeComponent();


            CommonUtil.SetInitGridView(dgvCompany);
            CommonUtil.SetDGVDesign_Num(dgvCompany);
            CommonUtil.SetDGVDesign_CheckBox(dgvCompany);
            dgvCompany.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvCompany, "업체", "company_name", 200, true, DataGridViewContentAlignment.MiddleCenter);



            CommonUtil.SetInitGridView(dgvItem);
            CommonUtil.SetDGVDesign_Num(dgvItem);
            CommonUtil.SetDGVDesign_CheckBox(dgvItem);
            dgvItem.RowHeadersVisible = true;
            CommonUtil.AddGridTextColumn(dgvItem, "업체", "company_name", 80);
            CommonUtil.AddGridTextColumn(dgvItem, "품목", "item_id", 80);
            CommonUtil.AddGridTextColumn(dgvItem, "품명", "item_name", 150);
            CommonUtil.AddGridTextColumn(dgvItem, "발주수량", "p_qty", 80, true, DataGridViewContentAlignment.MiddleRight);
            CommonUtil.AddGridTextColumn(dgvItem, "창고", "warehouse_name", 80);
            CommonUtil.AddGridTextColumn(dgvItem, "납기일", "DueDate", 80, true, DataGridViewContentAlignment.MiddleCenter);

        }



        private void PopupPurchase_Load(object sender, EventArgs e)
        {
            list = service.GetPurchasesDemand();
            dgvItem.DataSource = list;
            List<string> companys = (from company in list select company.company_name).ToList();
            companys = companys.Distinct().ToList();
            foreach (string company in companys)
            {
                dgvCompany.Rows.Add(null, company);
            }
            dgvItem.CellValueChanged += DgvItem_CellValueChanged;
        }

        private void DgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;
            if (!Convert.ToBoolean(dgvItem[0, e.RowIndex].Value))
            {
                foreach (DataGridViewRow row in dgvCompany.Rows)
                {
                    if (row.Cells[1].Value.Equals(dgvItem[1, e.RowIndex].Value.ToString()))
                    {
                        ((DataGridViewCheckBoxCell)row.Cells[0]).Value = false;
                        break;
                    }
                }
            }
            else
            {
                string companyName = dgvItem[1, e.RowIndex].Value.ToString();
                bool IsAllChecked = true;
                foreach (DataGridViewRow row in dgvItem.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(companyName) && !Convert.ToBoolean(row.Cells[0].Value))
                    {
                        IsAllChecked = false;
                        break;
                    }
                }
                foreach (DataGridViewRow row in dgvCompany.Rows)
                {
                    if (row.Cells[1].Value.ToString().Equals(companyName))
                    {
                        ((DataGridViewCheckBoxCell)row.Cells[0]).Value = IsAllChecked;
                        break;
                    }
                }
            }

        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            List<PurchasesVO> selectedRows = new List<PurchasesVO>();
            for (int i = 0; i < dgvItem.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvItem[0, i].Value))
                    selectedRows.Add(list[i]);
            }

            bool result = service.NewPurchases(selectedRows);
            if (result)
            {
                MessageBox.Show("발주 성공");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("발주 등록중 오류가 발생하였습니다.\r\n다시 시도하여 주십시오");
            }

        }

        private void dgvCompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
                return;

            string selectedCompany = dgvCompany[1, e.RowIndex].Value.ToString();
            foreach (DataGridViewRow row in dgvItem.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(selectedCompany))
                    ((DataGridViewCheckBoxCell)row.Cells[0]).Value = Convert.ToBoolean(dgvCompany[0, e.RowIndex].Value);
            }


        }
    }
}
