using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopupInboundCancel : CompanyManager.PopupBaseForm
    {
        private int maxCnt;
        public decimal CancelQty { get => numericUpDown1.Value; }
        public PopupInboundCancel(int maxCnt)
        {
            InitializeComponent();
            this.maxCnt = maxCnt;
            numericUpDown1.Maximum = 99999999;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("취소 수량을 입력해주십시오.");
                return;
            }
            if (numericUpDown1.Value > maxCnt)
            {
                MessageBox.Show("입고량보다 큰 수량은 입력할 수 없습니다.");
                numericUpDown1.Value = 0;
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
