using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CompanyManager
{
    public partial class FrmCommonCodeManagement : CompanyManager.MDIBaseForm
    {
        public FrmCommonCodeManagement()
        {
            InitializeComponent();
        }

        private void FrmCommonCodeManagement_Load(object sender, EventArgs e)
        {
            Image img = Properties.Resources.Edit_16x16;
            Util.CommonUtil.SetDGVDesign_Num(dataGridView1);
            Util.CommonUtil.AddGridCheckColumn(dataGridView1, "", 20);
            Util.CommonUtil.AddGridImageColumn(dataGridView1, img, "Edit", 40);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "코드", "", 100, textAlign: DataGridViewContentAlignment.MiddleCenter);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "카테고리", "", 200);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "코드명", "", 200);
            Util.CommonUtil.AddGridTextColumn(dataGridView1, "pCode", "", 150);
            


            dataGridView1.Rows.Add(null,null,"T0001","Number","AA",null);


        }
    }
}
