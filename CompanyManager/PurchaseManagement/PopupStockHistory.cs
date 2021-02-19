using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Util;

namespace CompanyManager
{
    public partial class PopupStockHistory : CompanyManager.PopupBaseForm
    {
        public PopupStockHistory()
        {
            InitializeComponent();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            CommonExcel.ExportExcel(dataGridView2);
        }
    }
}
