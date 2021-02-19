using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopupCode : CompanyManager.PopupBaseForm
    {
        public string Code 
        {
            get { return txtCode.Text.Trim(); }
            set 
            {
                txtCode.ReadOnly = true;
                txtCode.Text = value; 
            }
        }
        public string CodeName
        {
            get { return txtCodeName.Text.Trim(); }
            set { txtCodeName.Text = value; }
        }
        public string Category
        {
            get { return txtCategory.Text.Trim(); }
            set { txtCategory.Text = value; }
        }
        public string Pcode
        {
            get { return txtpCode.Text.Trim(); }
            set { txtpCode.Text = value; }
        }
        public PopupCode()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "공통코드";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //유효성 검사
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("코드를 입력해주세요");
                return;
            }

            if (string.IsNullOrEmpty(txtCodeName.Text))
            {
                MessageBox.Show("코드명을 입력해주세요");
                return;
            }

            if (string.IsNullOrEmpty(txtCategory.Text))
            {
                MessageBox.Show("카테고리명을 입력해주세요");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length > 19)
            {
                if(e.KeyChar == 8)
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        
    }
}
