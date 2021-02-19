using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopupMenu : CompanyManager.PopupBaseForm
    {
        public string MenuName 
        {
            get{ return txtMenuName.Text.Trim(); }
            set{ txtMenuName.Text = value; }
        }

        public PopupMenu()
        {
            InitializeComponent();
            popupTitleBar1.HeaderText = "메뉴관리";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //메뉴명 입력 검사
            if (string.IsNullOrEmpty(txtMenuName.Text))
            {
                MessageBox.Show("메뉴명을 입력해주세요");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtMenuName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
