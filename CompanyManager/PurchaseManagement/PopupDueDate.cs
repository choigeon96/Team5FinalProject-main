using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class PopupDueDate : CompanyManager.PopupBaseForm
    {
        public DateTime DueDate { get => dateTimePicker1.Value; }
        public PopupDueDate()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("납기일자를 확인해주십시오");
                dateTimePicker1.Value = DateTime.Now;
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
