using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VO;

namespace CompanyManager
{
    public partial class PopupSample : CompanyManager.PopupBaseForm
    {
        public PopupSample()
        {
            InitializeComponent();
        }

        private void SampleControl_Load(object sender, EventArgs e)
        {
            //dataGridView2.DataSource = Util.CommonExcel.ReadExcelData<MenuVO>("Sheet1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
